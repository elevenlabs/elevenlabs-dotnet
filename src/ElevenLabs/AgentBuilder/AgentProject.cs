using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using ElevenLabs.AgentTools;

namespace ElevenLabs.AgentBuilder;

// Inside the namespace, so it wins over the generated ElevenLabs.Tool model.
using Tool = ElevenLabs.AgentTools.Tool;

/// <summary>
/// An agents-as-code project in the ElevenLabs CLI's layout: <c>agents.json</c> and <c>tools.json</c> list the
/// agents and tools with their ids, and each one's config sits in <c>agent_configs/</c> or <c>tool_configs/</c> in
/// API format. A project made by <c>elevenlabs agents init</c> / <c>pull</c> works here, and one written here works
/// with the CLI.
/// </summary>
/// <remarks>
/// Pass it to <c>Agents.PushAsync(agent, new AgentPushOptions { Project = project })</c> and
/// <c>Agents.PullAsync(agentId, new AgentPullOptions { Project = project })</c>: the project records which agent and
/// tools on the server each definition is, so pushing again updates them instead of making copies. Files are written
/// only by push and pull, once they know every id, and a file nothing changed keeps its exact text. YAML and TOML
/// configs, <c>tests.json</c> and creating branches aren't supported yet.
/// Hand-written (see <c>.fernignore</c>); mirrors <c>AgentProject</c> in the JS SDK (see <c>agent-spec.md</c>).
/// </remarks>
/// <example>
/// <code>
/// var project = AgentProject.Open(".");
/// var agent = project.GetAgent("Support line");
/// agent.Update(new AgentOptions { Prompt = "..." });
/// await client.Agents.PushAsync(agent, new AgentPushOptions { Project = project });
/// </code>
/// </example>
public sealed class AgentProject
{
    internal const string AgentsFile = "agents.json";
    internal const string ToolsFile = "tools.json";
    internal const string AgentConfigsDir = "agent_configs";
    internal const string ToolConfigsDir = "tool_configs";

    private static readonly Regex JsonPath = new(@"\.json$", RegexOptions.IgnoreCase);

    private sealed class AgentEntry
    {
        public string Config = "";
        public string? Id;
        public string? BranchId;
        public string? VersionId;

        /// <summary>Branch entries as loaded (<c>{ "config", "branch_id", "version_id"? }</c>), by branch name.</summary>
        public JsonObject? Branches;
    }

    private sealed class ToolEntry
    {
        public string Type = "";
        public string Config = "";
        public string? Id;
    }

    private sealed class AgentSlot
    {
        public AgentSlot(AgentEntry entry, Agent agent)
        {
            Entry = entry;
            Agent = agent;
        }

        public AgentEntry Entry { get; }
        public Agent Agent { get; set; }
    }

    private sealed class ToolSlot
    {
        public ToolSlot(ToolEntry entry, Tool tool)
        {
            Entry = entry;
            Tool = tool;
        }

        public ToolEntry Entry { get; }
        public Tool Tool { get; set; }

        /// <summary>The config as loaded, in API format, sent as-is while the tool is unchanged so unmodeled fields survive.</summary>
        public JsonObject? Raw { get; set; }

        /// <summary>The tool's modeled definition as loaded, to tell whether it was edited (or rebuilt differently) since.</summary>
        public string? Baseline { get; set; }
    }

    private readonly string? _root;
    private readonly Dictionary<string, string> _files;
    private readonly List<AgentSlot> _agents = new();
    private readonly List<ToolSlot> _tools = new();

    /// <summary>Paths written since loading, with their new contents, in the order they were first written.</summary>
    private readonly List<string> _changedOrder = new();
    private readonly Dictionary<string, string> _changed = new();

    /// <summary>Paths in use on disk, so new files don't overwrite one the project doesn't list.</summary>
    private readonly HashSet<string> _taken;

    private AgentProject(IReadOnlyDictionary<string, string> files, string? directory, string? root, IEnumerable<string> taken)
    {
        Directory = directory;
        _root = root;
        _files = new Dictionary<string, string>();
        foreach (var file in files)
        {
            _files[ProjectFormat.NormalizePath(file.Key)] = file.Value;
        }
        _taken = new HashSet<string>(_files.Keys.Concat(taken.Select(ProjectFormat.NormalizePath)));
        Load();
    }

    /// <summary>
    /// A project from file contents, keyed by path relative to the project root. No I/O. Only <c>agents.json</c>,
    /// <c>tools.json</c> and the config files they list are read; missing index files mean an empty project.
    /// </summary>
    /// <exception cref="AgentProjectException">A file is missing, malformed, or in a format the SDK can't read yet.</exception>
    public static AgentProject FromFiles(IReadOnlyDictionary<string, string> files) =>
        new(files ?? throw new ArgumentNullException(nameof(files)), null, null, Enumerable.Empty<string>());

    /// <summary>
    /// Reads the project in <paramref name="directory"/>. A directory without <c>agents.json</c> and
    /// <c>tools.json</c> opens as an empty project, and <see cref="Save"/> creates them.
    /// </summary>
    /// <exception cref="AgentProjectException">
    /// A file is missing or malformed, a config path leads outside the project, or a config is YAML or TOML.
    /// </exception>
    public static AgentProject Open(string directory)
    {
        var (files, taken, root) = ProjectFiles.ReadProject(directory ?? throw new ArgumentNullException(nameof(directory)));
        return new AgentProject(files, directory, root, taken);
    }

    /// <summary>The directory the project was opened from, or <c>null</c> for <see cref="FromFiles"/>. <see cref="Save"/> writes there.</summary>
    public string? Directory { get; }

    /// <summary>Every agent in the project, in <c>agents.json</c> order.</summary>
    public IReadOnlyList<Agent> Agents => _agents.Select(slot => slot.Agent).ToList();

    /// <summary>Every tool in <c>tools.json</c>, in order.</summary>
    public IReadOnlyList<Tool> Tools => _tools.Select(slot => slot.Tool).ToList();

    /// <summary>
    /// The agent named <paramref name="name"/>. The same object every time, so edits to it are what
    /// <c>Agents.PushAsync(agent, ...)</c> with this project sends.
    /// </summary>
    /// <exception cref="AgentProjectException">No agent, or more than one, has that name.</exception>
    public Agent GetAgent(string name)
    {
        var matches = _agents.Where(slot => slot.Agent.Name == name).ToList();
        if (matches.Count != 1)
        {
            throw new AgentProjectException(
                matches.Count == 0
                    ? $"No agent named \"{name}\" in {AgentsFile}"
                    : $"{matches.Count} agents in {AgentsFile} are named \"{name}\""
            );
        }
        return matches[0].Agent;
    }

    /// <summary>The id <c>agents.json</c> records for this agent, if it was pushed or pulled.</summary>
    public string? GetAgentId(Agent agent) => AgentSlotFor(agent)?.Entry.Id;

    /// <summary>The id <c>tools.json</c> records for this tool, if it was pushed or pulled.</summary>
    public string? GetToolId(Tool tool) => ToolSlotFor(tool)?.Entry.Id;

    /// <summary>
    /// The project's files, keyed by path: the index files and every config they list (branch configs included),
    /// with what push and pull wrote since loading. Files nothing changed keep their exact text.
    /// </summary>
    public IReadOnlyDictionary<string, string> ToFiles()
    {
        var files = new Dictionary<string, string>
        {
            [AgentsFile] = Current(AgentsFile) ?? AgentsIndex(),
            [ToolsFile] = Current(ToolsFile) ?? ToolsIndex(),
        };
        var configs = _agents
            .Select(slot => slot.Entry.Config)
            .Concat(_agents.SelectMany(slot => BranchConfigs(slot.Entry)))
            .Concat(_tools.Select(slot => slot.Entry.Config));
        foreach (var path in configs)
        {
            if (Current(ProjectFormat.NormalizePath(path)) is string text)
            {
                files[path] = text;
            }
        }
        return files;
    }

    /// <summary>The paths push and pull changed since the project was loaded or last saved.</summary>
    public IReadOnlyList<string> ChangedFiles => _changedOrder.ToList();

    /// <summary>
    /// Writes the files push and pull changed to the project's directory, owner-only (<c>0600</c>), never through a
    /// symlink and never outside the project. <c>Agents.PushAsync()</c> and <c>PullAsync()</c> call this themselves
    /// for a project opened with <see cref="Open"/>. Returns the paths written.
    /// </summary>
    /// <exception cref="AgentProjectException">The project wasn't opened from a directory, or a path is unsafe to write.</exception>
    public IReadOnlyList<string> Save()
    {
        if (_root == null)
        {
            throw new AgentProjectException("This project wasn't opened from a directory; use ToFiles() instead");
        }
        var written = _changedOrder.Select(path => new KeyValuePair<string, string>(path, _changed[path])).ToList();
        if (written.Count == 0)
        {
            return Array.Empty<string>();
        }
        ProjectFiles.WriteProjectFiles(_root, written);
        foreach (var file in written)
        {
            _files[file.Key] = file.Value;
        }
        _changed.Clear();
        _changedOrder.Clear();
        return written.Select(file => file.Key).ToList();
    }

    internal bool OpenedFromDirectory => _root != null;

    /// <summary>The loaded config to send for a tool whose definition matches its project entry, so fields this SDK doesn't model survive.</summary>
    internal JsonObject? UnchangedRaw(Tool tool)
    {
        var slot = ToolSlotFor(tool);
        if (slot?.Raw == null || slot.Baseline == null)
        {
            return null;
        }
        return ToolComparison.ModeledJson(tool) == slot.Baseline ? slot.Raw : null;
    }

    /// <summary>Records a tool's id and the config now on the server, adding an entry if it's new. Push finds the entry by definition; pull, by id.</summary>
    internal void RecordTool(Tool tool, string id, JsonObject config, bool matchById = false)
    {
        var slot = matchById ? _tools.FirstOrDefault(s => s.Entry.Id == id) : ToolSlotFor(tool);
        if (slot == null)
        {
            var path = ProjectFormat.UniquePath(ToolConfigsDir, tool.Name, _taken);
            _taken.Add(path);
            slot = new ToolSlot(new ToolEntry { Type = KindName(tool), Config = path }, tool);
            _tools.Add(slot);
        }
        slot.Tool = tool;
        slot.Entry.Id = id;
        slot.Entry.Type = KindName(tool);
        slot.Raw = config;
        slot.Baseline = ToolComparison.ModeledJson(tool);
        Write(slot.Entry.Config, ProjectFormat.FormatConfig(config));
        Write(ToolsFile, ToolsIndex());
    }

    /// <summary>Records an agent's id and its config, adding an entry if it's new. Push matches like <see cref="RecordTool"/>.</summary>
    internal void RecordAgent(
        Agent agent,
        string id,
        JsonObject config,
        string? branchId = null,
        string? versionId = null,
        bool matchById = false
    )
    {
        var slot = matchById ? _agents.FirstOrDefault(s => s.Entry.Id == id) : AgentSlotFor(agent);
        if (slot == null)
        {
            var path = ProjectFormat.UniquePath(AgentConfigsDir, agent.Name, _taken);
            _taken.Add(path);
            slot = new AgentSlot(new AgentEntry { Config = path }, agent);
            _agents.Add(slot);
        }
        slot.Entry.Id = id;
        var branch = FindBranch(slot.Entry, branchId);
        // A branch has its own file; the slot's agent is the main branch's, which a branch must not replace.
        if (branch == null)
        {
            slot.Agent = agent;
        }
        // Like the CLI: the version the server reports, on the branch entry it belongs to.
        if (versionId != null)
        {
            if (branch != null)
            {
                branch["version_id"] = versionId;
            }
            else
            {
                slot.Entry.VersionId = versionId;
            }
        }
        Write((branch == null ? null : AgentWire.Str(branch["config"])) ?? slot.Entry.Config, ProjectFormat.FormatConfig(config));
        Write(AgentsFile, AgentsIndex());
    }

    /// <summary>
    /// Rejects a branch the project has no file for, before anything is written: its settings would otherwise land in
    /// the main branch's file, and a later CLI push would send them to the main branch.
    /// </summary>
    internal void CheckBranch(Agent agent, string? branchId) => CheckBranchOf(AgentSlotFor(agent), agent.Name, branchId);

    /// <summary><see cref="CheckBranch"/> for pull, which finds the agent by id.</summary>
    internal void CheckBranchById(string agentId, string? branchId) =>
        CheckBranchOf(_agents.FirstOrDefault(s => s.Entry.Id == agentId), agentId, branchId);

    private void CheckBranchOf(AgentSlot? slot, string label, string? branchId)
    {
        if (branchId == null || slot?.Entry.BranchId == branchId)
        {
            return;
        }
        if (slot == null || FindBranch(slot.Entry, branchId) == null)
        {
            throw new AgentProjectException(
                $"Branch {branchId} of \"{label}\" has no config file in {AgentsFile}. Add it under \"branches\" "
                    + "(the CLI's `agents pull --all-branches` does), or push the main branch"
            );
        }
    }

    private static JsonObject? FindBranch(AgentEntry entry, string? branchId) =>
        branchId == null
            ? null
            : (entry.Branches ?? new JsonObject())
                .Select(field => field.Value as JsonObject)
                .FirstOrDefault(branch => branch != null && AgentWire.Str(branch["branch_id"]) == branchId);

    private static IEnumerable<string> BranchConfigs(AgentEntry entry) =>
        (entry.Branches ?? new JsonObject())
            .Select(field => AgentWire.Str((field.Value as JsonObject)?["config"]))
            .OfType<string>();

    /// <summary>The entry for an agent: the one it was loaded from, else the only one with its name.</summary>
    private AgentSlot? AgentSlotFor(Agent agent) =>
        _agents.FirstOrDefault(slot => ReferenceEquals(slot.Agent, agent))
        ?? Single(_agents.Where(slot => slot.Agent.Name == agent.Name).ToList(), AgentsFile, agent.Name);

    /// <summary>The entry for a tool: the one it was loaded from, else the only one with its name.</summary>
    private ToolSlot? ToolSlotFor(Tool tool) =>
        _tools.FirstOrDefault(slot => ReferenceEquals(slot.Tool, tool))
        ?? Single(_tools.Where(slot => slot.Tool.Name == tool.Name).ToList(), ToolsFile, tool.Name);

    private static T? Single<T>(List<T> matches, string index, string name)
        where T : class
    {
        if (matches.Count > 1)
        {
            throw new AgentProjectException($"{matches.Count} entries in {index} are named \"{name}\"; push the loaded one");
        }
        return matches.FirstOrDefault();
    }

    private string? Current(string path) =>
        _changed.TryGetValue(path, out var changed) ? changed : _files.TryGetValue(path, out var text) ? text : null;

    private void Write(string path, string text)
    {
        var key = ProjectFormat.NormalizePath(path);
        if (_files.TryGetValue(key, out var loaded) && loaded == text)
        {
            if (_changed.Remove(key))
            {
                _changedOrder.Remove(key);
            }
            return;
        }
        if (!_changed.ContainsKey(key))
        {
            _changedOrder.Add(key);
        }
        _changed[key] = text;
    }

    private void Load()
    {
        var agentsIndex = ReadIndex(AgentsFile, "agents");
        var toolsIndex = ReadIndex(ToolsFile, "tools");

        var byId = new Dictionary<string, Tool>();
        foreach (var item in toolsIndex)
        {
            var entry = new ToolEntry
            {
                Type = AgentWire.Str(item["type"]) ?? "",
                Config = ConfigPathOf(item, ToolsFile),
                Id = AgentWire.Str(item["id"]),
            };
            var raw = ReadConfig(entry.Config, ToolsFile);
            Tool tool;
            try
            {
                tool = Tool.FromJson(raw);
            }
            catch (Exception ex)
            {
                throw new AgentProjectException($"{entry.Config} isn't a valid tool config: {ex.Message}");
            }
            _tools.Add(new ToolSlot(entry, tool) { Raw = raw, Baseline = ToolComparison.ModeledJson(tool) });
            if (entry.Id != null)
            {
                byId[entry.Id] = tool;
            }
        }
        foreach (var item in agentsIndex)
        {
            var entry = new AgentEntry
            {
                Config = ConfigPathOf(item, AgentsFile),
                Id = AgentWire.Str(item["id"]),
                BranchId = AgentWire.Str(item["branch_id"]),
                VersionId = AgentWire.Str(item["version_id"]),
                Branches = item["branches"]?.DeepClone() as JsonObject,
            };
            var raw = ReadConfig(entry.Config, AgentsFile);
            _agents.Add(new AgentSlot(entry, Agent.FromJson(raw, byId)));
        }
    }

    private static string ConfigPathOf(JsonObject entry, string index) =>
        AgentWire.Str(entry["config"]) ?? throw new AgentProjectException($"{index} has an entry without a \"config\" path");

    private List<JsonObject> ReadIndex(string path, string key)
    {
        if (!_files.TryGetValue(path, out var text))
        {
            return new List<JsonObject>();
        }
        JsonNode? parsed;
        try
        {
            parsed = JsonNode.Parse(text);
        }
        catch (JsonException ex)
        {
            throw new AgentProjectException($"{path} isn't valid JSON: {ex.Message}");
        }
        return (parsed?[key] as JsonArray ?? new JsonArray()).OfType<JsonObject>().ToList();
    }

    private JsonObject ReadConfig(string path, string index)
    {
        if (!JsonPath.IsMatch(path))
        {
            throw new AgentProjectException(
                $"{index} points at {path}: only JSON config files are supported yet (YAML and TOML aren't)"
            );
        }
        if (!_files.TryGetValue(ProjectFormat.NormalizePath(path), out var text))
        {
            throw new AgentProjectException($"{index} points at {path}, which doesn't exist");
        }
        try
        {
            return JsonNode.Parse(text) as JsonObject ?? throw new AgentProjectException($"{path} isn't a JSON object");
        }
        catch (JsonException ex)
        {
            throw new AgentProjectException($"{path} isn't valid JSON: {ex.Message}");
        }
    }

    private string AgentsIndex()
    {
        var agents = new JsonArray();
        foreach (var slot in _agents)
        {
            // The CLI writes fields in this order and leaves unset ones out.
            var entry = new JsonObject { ["config"] = slot.Entry.Config };
            if (slot.Entry.Id != null)
            {
                entry["id"] = slot.Entry.Id;
            }
            if (slot.Entry.BranchId != null)
            {
                entry["branch_id"] = slot.Entry.BranchId;
            }
            if (slot.Entry.VersionId != null)
            {
                entry["version_id"] = slot.Entry.VersionId;
            }
            if (slot.Entry.Branches != null)
            {
                entry["branches"] = slot.Entry.Branches.DeepClone();
            }
            agents.Add(entry);
        }
        return ProjectFormat.FormatIndex(new JsonObject { ["agents"] = agents });
    }

    private string ToolsIndex()
    {
        var tools = new JsonArray();
        foreach (var slot in _tools)
        {
            var entry = new JsonObject { ["type"] = slot.Entry.Type, ["config"] = slot.Entry.Config };
            if (slot.Entry.Id != null)
            {
                entry["id"] = slot.Entry.Id;
            }
            tools.Add(entry);
        }
        return ProjectFormat.FormatIndex(new JsonObject { ["tools"] = tools });
    }

    private static string KindName(Tool tool) =>
        tool.Kind switch
        {
            ToolKind.Webhook => "webhook",
            ToolKind.Client => "client",
            ToolKind.System => "system",
            _ => "other",
        };
}
