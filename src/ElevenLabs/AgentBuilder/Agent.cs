using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Nodes;
using ElevenLabs.AgentTools;
using ElevenLabs.AgentWorkflows;
using ElevenLabs.Core;

namespace ElevenLabs.AgentBuilder;

// Inside the namespace, so it wins over the generated ElevenLabs.Tool model.
using Tool = ElevenLabs.AgentTools.Tool;

/// <summary>The settings an agent can be given in code. Every one is optional, so <see cref="Agent.Update"/> takes the same options.</summary>
public sealed class AgentOptions
{
    /// <summary>The agent's instructions: <c>conversation_config.agent.prompt.prompt</c>.</summary>
    public string? Prompt { get; set; }

    /// <summary>What the agent says first: <c>conversation_config.agent.first_message</c>.</summary>
    public string? FirstMessage { get; set; }

    /// <summary><c>conversation_config.agent.language</c>, e.g. <c>"en"</c>.</summary>
    public string? Language { get; set; }

    /// <summary><c>conversation_config.agent.prompt.llm</c>.</summary>
    public Llm? Llm { get; set; }

    /// <summary><c>conversation_config.agent.prompt.temperature</c>.</summary>
    public double? Temperature { get; set; }

    /// <summary><c>conversation_config.tts.voice_id</c>.</summary>
    public string? VoiceId { get; set; }

    /// <summary><c>conversation_config.tts.model_id</c>.</summary>
    public TtsConversationalModel? TtsModel { get; set; }

    /// <summary><c>tags</c>.</summary>
    public IReadOnlyList<string>? Tags { get; set; }

    /// <summary>
    /// Tools the agent can use anywhere. Webhook and client tools are created or updated by <c>Agents.PushAsync()</c>
    /// and attached by id; system tools go into <c>prompt.built_in_tools</c>. Replaces the agent's tools on
    /// <c>Update()</c>.
    /// </summary>
    public IReadOnlyList<Tool>? Tools { get; set; }

    /// <summary>Ids of existing tools to attach as they are. <c>Agents.PushAsync()</c> doesn't create or change them.</summary>
    public IReadOnlyList<string>? ToolIds { get; set; }

    /// <summary>The agent's workflow. Its tool nodes can take <c>Tool</c> objects, which <c>Agents.PushAsync()</c> manages too.</summary>
    public Workflow? Workflow { get; set; }

    /// <summary>
    /// Any other conversation settings, merged under the typed options above. Setting a field here that a typed
    /// option also sets is reported by <c>Validate()</c>.
    /// </summary>
    public ConversationalConfig? ConversationConfig { get; set; }

    /// <summary>Platform settings (privacy, evaluation, widget...), merged the same way.</summary>
    public AgentPlatformSettingsRequestModel? PlatformSettings { get; set; }
}

/// <summary>
/// An agent, written as code: its settings, its tools and its workflow in one definition. Push it with
/// <c>client.Agents.PushAsync(agent)</c>, which creates or updates the tools and the agent together.
/// </summary>
/// <remarks>
/// An agent holds no client: it can be validated without an API key, and pushed to several workspaces.
/// Hand-written (see <c>.fernignore</c>); mirrors <c>Agent</c> in the JS SDK (see <c>agent-spec.md</c>).
/// </remarks>
/// <example>
/// <code>
/// var agent = new Agent("Support line", new AgentOptions
/// {
///     Prompt = "You are a support agent for Acme.",
///     FirstMessage = "Hi, how can I help?",
///     Tools = new Tool[] { SystemTool.EndCall(), getOrder },
///     Workflow = wf,
/// });
/// var result = await client.Agents.PushAsync(agent);
/// </code>
/// </example>
public sealed class Agent
{
    private enum TypedKey
    {
        Prompt,
        FirstMessage,
        Language,
        Llm,
        Temperature,
        VoiceId,
        TtsModel,
    }

    private static readonly IReadOnlyList<string> PromptPath = TypedOption(TypedKey.Prompt, "").Path;

    private static readonly IReadOnlyDictionary<string, Tool> NoTools = new Dictionary<string, Tool>();

    private string _name;
    private readonly Dictionary<TypedKey, object> _typed = new();
    private readonly List<TypedKey> _typedOrder = new();
    private JsonArray? _tags;
    private List<Tool> _tools = new();
    private List<string> _toolIds = new();
    private Workflow? _workflow;

    /// <summary>A loaded workflow nobody has edited yet, kept in API format so it round-trips exactly.</summary>
    private JsonObject? _rawWorkflow;
    private IReadOnlyDictionary<string, Tool> _toolsById = NoTools;

    /// <summary>The loaded <c>tool_ids</c>, so a loaded agent keeps its tool order.</summary>
    private List<string> _loadedToolIds = new();

    /// <summary>Whether <c>Tools</c> or <c>ToolIds</c> was given (even empty), so the agent sets <c>tool_ids</c> rather than leaving it alone.</summary>
    private bool _toolListGiven;

    /// <summary>Loaded system tools with their config as loaded, sent as-is while the tool is unchanged.</summary>
    private readonly Dictionary<Tool, (JsonNode Raw, string? Baseline)> _loadedSystem = new(ReferenceComparer<Tool>.Instance);

    /// <summary>Settings loaded from a config, in API format. Typed options and raw options are applied on top.</summary>
    private JsonObject _base = new();
    private readonly List<ConversationalConfig> _rawConversationConfig = new();
    private readonly List<AgentPlatformSettingsRequestModel> _rawPlatformSettings = new();

    /// <param name="name">The agent's name.</param>
    /// <param name="options">Its settings, tools and workflow.</param>
    public Agent(string name, AgentOptions? options = null)
    {
        _name = name ?? throw new ArgumentNullException(nameof(name));
        if (options != null)
        {
            Update(options);
        }
    }

    /// <summary>
    /// Loads an agent config in API format (snake_case): a CLI <c>agent_configs/*.json</c> file, or the
    /// <see cref="ToJson"/> of an agent. Tool ids found in <paramref name="toolsById"/> become <c>Tool</c> objects the
    /// agent manages; the rest stay as <see cref="ToolIds"/>. Fields this SDK doesn't model are kept, so an unedited
    /// agent round-trips exactly.
    /// </summary>
    public static Agent FromJson(string json, IReadOnlyDictionary<string, Tool>? toolsById = null) =>
        FromJson(
            JsonNode.Parse(json) ?? throw new ArgumentException("The agent JSON is null", nameof(json)),
            toolsById
        );

    /// <summary>Loads a parsed API-format agent config. See <see cref="FromJson(string, IReadOnlyDictionary{string, Tool}?)"/>.</summary>
    public static Agent FromJson(JsonNode json, IReadOnlyDictionary<string, Tool>? toolsById = null)
    {
        var parsed =
            json.DeepClone() as JsonObject ?? throw new ArgumentException("An agent config must be a JSON object", nameof(json));
        var agent = new Agent(AgentWire.Str(parsed["name"]) ?? "");
        var tags = parsed["tags"] as JsonArray;
        var workflow = parsed["workflow"] as JsonObject;
        parsed.Remove("name");
        parsed.Remove("tags");
        parsed.Remove("workflow");
        agent._base = parsed;
        agent._tags = tags == null ? null : (JsonArray)tags.DeepClone();
        agent._toolsById = toolsById ?? NoTools;

        if (AgentWire.GetPath(parsed, AgentWire.ToolIdsPath) is JsonArray ids)
        {
            AgentWire.SetPath(parsed, AgentWire.ToolIdsPath, null);
            agent._loadedToolIds = AgentWire.StrList(ids);
            foreach (var id in agent._loadedToolIds)
            {
                if (agent._toolsById.TryGetValue(id, out var tool))
                {
                    agent._tools.Add(tool);
                }
                else
                {
                    agent._toolIds.Add(id);
                }
            }
            agent._toolListGiven = true;
        }

        // System tools become SystemTool objects, so replacing Tools replaces them like on an agent built in code.
        if (AgentWire.GetPath(parsed, AgentWire.BuiltInToolsPath) is JsonObject builtIn)
        {
            foreach (var key in builtIn.Select(field => field.Key).ToList())
            {
                if (builtIn[key] is not JsonObject raw)
                {
                    continue;
                }
                try
                {
                    var withType = new JsonObject { ["type"] = "system" };
                    foreach (var field in raw)
                    {
                        withType[field.Key] = field.Value?.DeepClone();
                    }
                    var tool = Tool.FromJson(withType);
                    if (tool is not SystemTool system || system.SystemToolType != key)
                    {
                        continue;
                    }
                    agent._tools.Add(tool);
                    agent._loadedSystem[tool] = (raw.DeepClone(), SafeJson(tool));
                    builtIn.Remove(key);
                }
                catch (Exception)
                {
                    // Kept in the config as it is.
                }
            }
            if (builtIn.Count == 0)
            {
                AgentWire.SetPath(parsed, AgentWire.BuiltInToolsPath, null);
            }
        }

        agent._rawWorkflow = workflow == null ? null : (JsonObject)workflow.DeepClone();
        return agent;
    }

    /// <summary>The agent's name.</summary>
    public string Name => _name;

    /// <summary>
    /// The agent's workflow, or <c>null</c> if it has none. A loaded workflow is turned into a <see cref="AgentWorkflows.Workflow"/>
    /// the first time it's read here, with its tool ids swapped for the <c>Tool</c> objects the agent knows, so it can be edited.
    /// </summary>
    public Workflow? Workflow
    {
        get
        {
            if (_workflow == null && _rawWorkflow != null)
            {
                _workflow = AgentWorkflows.Workflow.FromJson(_rawWorkflow, _toolsById);
                _rawWorkflow = null;
            }
            return _workflow;
        }
    }

    /// <summary>The ids of existing tools attached as they are, which <c>Agents.PushAsync()</c> doesn't manage.</summary>
    public IReadOnlyList<string> ToolIds => _toolIds.ToList();

    /// <summary>
    /// Changes the agent. Typed options, <c>Tools</c>, <c>ToolIds</c> and <c>Workflow</c> replace what was there;
    /// <c>ConversationConfig</c> and <c>PlatformSettings</c> merge.
    /// </summary>
    /// <param name="options">The options to change. Unset ones are left alone.</param>
    /// <param name="name">A new name, if given.</param>
    public Agent Update(AgentOptions options, string? name = null)
    {
        if (options == null)
        {
            throw new ArgumentNullException(nameof(options));
        }
        if (name != null)
        {
            _name = name;
        }
        SetTyped(TypedKey.Prompt, options.Prompt);
        SetTyped(TypedKey.FirstMessage, options.FirstMessage);
        SetTyped(TypedKey.Language, options.Language);
        SetTyped(TypedKey.Llm, options.Llm);
        SetTyped(TypedKey.Temperature, options.Temperature);
        SetTyped(TypedKey.VoiceId, options.VoiceId);
        SetTyped(TypedKey.TtsModel, options.TtsModel);
        if (options.Tags != null)
        {
            _tags = ToArray(options.Tags);
        }
        if (options.Tools != null)
        {
            _tools = options.Tools.ToList();
            _toolListGiven = true;
        }
        if (options.ToolIds != null)
        {
            _toolIds = options.ToolIds.ToList();
            _toolListGiven = true;
        }
        if (options.Workflow != null)
        {
            _workflow = options.Workflow;
            _rawWorkflow = null;
        }
        if (options.ConversationConfig != null)
        {
            _rawConversationConfig.Add(options.ConversationConfig);
        }
        if (options.PlatformSettings != null)
        {
            _rawPlatformSettings.Add(options.PlatformSettings);
        }
        return this;
    }

    /// <summary>Adds a tool the agent can use anywhere.</summary>
    public Agent AddTool(Tool tool)
    {
        _tools.Add(tool ?? throw new ArgumentNullException(nameof(tool)));
        _toolListGiven = true;
        return this;
    }

    /// <summary>
    /// Every webhook and client tool the agent and its workflow use, each once, in first-use order: the tools
    /// <c>Agents.PushAsync()</c> creates or updates. System tools aren't included; they live inside the agent's config.
    /// </summary>
    public IReadOnlyList<Tool> Tools()
    {
        var seen = new HashSet<Tool>(ReferenceComparer<Tool>.Instance);
        return _tools.Concat(WorkflowTools()).Where(tool => tool.Kind != ToolKind.System && seen.Add(tool)).ToList();
    }

    /// <summary>
    /// Checks everything that doesn't need tool ids: the tools, the workflow, the settings, and that no two tools
    /// share a name. CI can run this without an API key.
    /// </summary>
    /// <param name="onWarning">Called for each non-fatal problem, such as an agent without a prompt.</param>
    /// <exception cref="AgentValidationException">Listing every problem, if the agent is invalid.</exception>
    public void Validate(Action<AgentIssue>? onWarning = null) => Assemble(null, onWarning);

    /// <summary>
    /// The agent config in API format (snake_case keys, sorted at every level): the shape of a CLI
    /// <c>agent_configs/*.json</c> file. Validates like <see cref="Validate"/>, and also needs every managed tool's id.
    /// </summary>
    /// <param name="toolIds">
    /// The id of each webhook and client tool the agent uses, by tool name. <c>Agents.PushAsync()</c> passes these
    /// after creating or updating the tools. Every such tool needs one.
    /// </param>
    /// <param name="onWarning">Called for each non-fatal problem.</param>
    /// <exception cref="AgentValidationException">Listing every problem, if the agent is invalid or a tool has no id.</exception>
    public JsonObject ToJson(IReadOnlyDictionary<string, string>? toolIds = null, Action<AgentIssue>? onWarning = null) =>
        Assemble(toolIds ?? new Dictionary<string, string>(), onWarning);

    /// <summary>
    /// <see cref="ToJson"/> parsed into the request model <c>Agents.CreateAsync()</c> accepts. The generated model
    /// keeps fields this SDK doesn't model, so nothing is lost.
    /// </summary>
    /// <exception cref="AgentValidationException">Listing every problem, if the agent is invalid or a tool has no id.</exception>
    public BodyCreateAgentV1ConvaiAgentsCreatePost Build(
        IReadOnlyDictionary<string, string>? toolIds = null,
        Action<AgentIssue>? onWarning = null
    ) => JsonUtils.Deserialize<BodyCreateAgentV1ConvaiAgentsCreatePost>(ToJson(toolIds, onWarning).ToJsonString());

    private void SetTyped(TypedKey key, object? value)
    {
        if (value == null)
        {
            return;
        }
        if (!_typed.ContainsKey(key))
        {
            _typedOrder.Add(key);
        }
        _typed[key] = value;
    }

    private IEnumerable<Tool> WorkflowTools()
    {
        if (_workflow != null)
        {
            return _workflow.Tools();
        }
        return AgentWire
            .RawWorkflowToolIds(_rawWorkflow)
            .Select(id => _toolsById.TryGetValue(id, out var tool) ? tool : null)
            .OfType<Tool>();
    }

    /// <summary>
    /// Where a typed option goes, as the piece of the generated <see cref="ConversationalConfig"/> it sets. Written
    /// against the generated types, so a renamed field fails to compile; the generated serializer gives the API format.
    /// </summary>
    private static ConversationalConfig Piece(TypedKey key, object value) =>
        key switch
        {
            TypedKey.Prompt => new() { Agent = new() { Prompt = new() { Prompt = (string)value } } },
            TypedKey.FirstMessage => new() { Agent = new() { FirstMessage = (string)value } },
            TypedKey.Language => new() { Agent = new() { Language = (string)value } },
            TypedKey.Llm => new() { Agent = new() { Prompt = new() { Llm = (Llm)value } } },
            TypedKey.Temperature => new() { Agent = new() { Prompt = new() { Temperature = (double)value } } },
            TypedKey.VoiceId => new() { Tts = new() { VoiceId = (string)value } },
            TypedKey.TtsModel => new() { Tts = new() { ModelId = (TtsConversationalModel)value } },
            _ => throw new ArgumentOutOfRangeException(nameof(key)),
        };

    /// <summary>The API-format path a typed option sets, and its value in API format.</summary>
    private static (List<string> Path, JsonNode? Wire) TypedOption(TypedKey key, object value)
    {
        var wire = JsonUtils.SerializeToNode(Piece(key, value));
        var path = new List<string> { "conversation_config" };
        while (wire is JsonObject obj && obj.Count == 1)
        {
            var field = obj.First();
            path.Add(field.Key);
            wire = field.Value;
        }
        return (path, wire?.DeepClone());
    }

    /// <summary>
    /// Builds the API-format config. Without <paramref name="toolIds"/> (validation only), tools stand under placeholder
    /// ids and missing ids aren't reported.
    /// </summary>
    private JsonObject Assemble(IReadOnlyDictionary<string, string>? toolIds, Action<AgentIssue>? onWarning)
    {
        var issues = new List<AgentIssue>();
        var config = (JsonObject)_base.DeepClone();
        string IdOf(Tool tool) =>
            toolIds != null && toolIds.TryGetValue(tool.Name, out var id) ? id : WorkflowGraph.ToolPlaceholder(tool.Name);

        if (_name.Trim().Length == 0)
        {
            issues.Add(new AgentIssue("missing_name", AgentSeverity.Error, "The agent needs a name"));
        }

        // Raw options first, so the typed ones win and can be checked against them.
        var raw = new JsonObject();
        foreach (var settings in _rawConversationConfig)
        {
            if (ToWire(settings, "ConversationConfig", issues) is JsonObject wire)
            {
                AgentWire.DeepMerge(raw, new JsonObject { ["conversation_config"] = wire });
            }
        }
        foreach (var settings in _rawPlatformSettings)
        {
            if (ToWire(settings, "PlatformSettings", issues) is JsonObject wire)
            {
                AgentWire.DeepMerge(raw, new JsonObject { ["platform_settings"] = wire });
            }
        }
        AgentWire.DeepMerge(config, raw);

        foreach (var key in _typedOrder)
        {
            var (path, wire) = TypedOption(key, _typed[key]);
            if (AgentWire.HasPath(raw, path))
            {
                issues.Add(Conflict(key.ToString(), path));
            }
            AgentWire.SetPath(config, path, wire);
        }

        // Tools: every one validates, and no two different tools share a name.
        var byName = new Dictionary<string, Tool>();
        foreach (var tool in _tools.Concat(WorkflowTools()).ToList())
        {
            byName.TryGetValue(tool.Name, out var other);
            if (other != null && !ReferenceEquals(other, tool))
            {
                issues.Add(
                    new AgentIssue(
                        "duplicate_tool_name",
                        AgentSeverity.Error,
                        $"Two different tools are named \"{tool.Name}\"",
                        $"tools.{tool.Name}"
                    )
                );
            }
            if (other == null)
            {
                byName[tool.Name] = tool;
                try
                {
                    tool.BuildConfig();
                }
                catch (Exception ex)
                {
                    issues.Add(new AgentIssue("invalid_tool", AgentSeverity.Error, ex.Message, $"tools.{tool.Name}"));
                }
            }
        }

        var managed = _tools.Where(tool => tool.Kind != ToolKind.System).ToList();
        var system = _tools.OfType<SystemTool>().ToList();
        if (_toolListGiven)
        {
            if (AgentWire.HasPath(raw, AgentWire.ToolIdsPath))
            {
                issues.Add(Conflict("Tools", AgentWire.ToolIdsPath));
            }
            var ids = KeepOrder(_toolIds.Concat(managed.Select(IdOf)).ToList(), _loadedToolIds);
            AgentWire.SetPath(config, AgentWire.ToolIdsPath, ToArray(ids));
        }
        foreach (var tool in system)
        {
            var path = AgentWire.BuiltInToolsPath.Concat(new[] { tool.SystemToolType }).ToList();
            if (AgentWire.HasPath(raw, path))
            {
                issues.Add(Conflict("Tools", path));
            }
            JsonNode? wire;
            if (_loadedSystem.TryGetValue(tool, out var loaded) && loaded.Baseline != null && SafeJson(tool) == loaded.Baseline)
            {
                wire = loaded.Raw.DeepClone();
            }
            else
            {
                try
                {
                    wire = tool.ToJson();
                }
                catch (Exception)
                {
                    wire = null; // Already reported as invalid_tool.
                }
            }
            if (wire != null)
            {
                AgentWire.SetPath(config, path, wire);
            }
        }

        // Workflow: its own checks, plus tool nodes can only run webhook and client tools.
        if (_workflow != null)
        {
            var wfTools = _workflow.Tools();
            foreach (var tool in wfTools.Where(tool => tool.Kind == ToolKind.System))
            {
                issues.Add(
                    new AgentIssue(
                        "system_tool_in_workflow",
                        AgentSeverity.Error,
                        $"System tool \"{tool.Name}\" can't be used in a workflow node; add it to the agent's tools",
                        $"workflow.tools.{tool.Name}"
                    )
                );
            }
            var ids = new Dictionary<string, string>();
            foreach (var tool in wfTools)
            {
                ids[tool.Name] = IdOf(tool);
            }
            try
            {
                var wire = _workflow.ToWireObject(null, ids);
                JsonUtils.Deserialize<AgentWorkflowRequestModel>(wire.ToJsonString());
                config["workflow"] = wire;
            }
            catch (Exception ex)
            {
                issues.Add(new AgentIssue("invalid_workflow", AgentSeverity.Error, ex.Message, "workflow"));
            }
        }
        else if (_rawWorkflow != null)
        {
            // Check the loaded graph without replacing the raw copy, which keeps fields this SDK doesn't model.
            try
            {
                AgentWorkflows.Workflow.FromJson(_rawWorkflow).Build();
            }
            catch (Exception ex)
            {
                issues.Add(new AgentIssue("invalid_workflow", AgentSeverity.Error, ex.Message, "workflow"));
            }
            // Its managed tools may have new ids, e.g. when pushed as a new agent.
            config["workflow"] = AgentWire.MapRawWorkflowToolIds(
                (JsonObject)_rawWorkflow.DeepClone(),
                id =>
                    _toolsById.TryGetValue(id, out var tool)
                    && toolIds != null
                    && toolIds.TryGetValue(tool.Name, out var newId)
                        ? newId
                        : id
            );
        }

        if (toolIds != null)
        {
            foreach (var tool in Tools().Where(tool => !toolIds.ContainsKey(tool.Name)))
            {
                issues.Add(
                    new AgentIssue(
                        "unresolved_tool",
                        AgentSeverity.Error,
                        $"Tool \"{tool.Name}\" has no id yet. Push the agent with Agents.PushAsync(), or pass toolIds",
                        $"tools.{tool.Name}"
                    )
                );
            }
        }

        if (AgentWire.Str(AgentWire.GetPath(config, PromptPath)) == null)
        {
            issues.Add(
                new AgentIssue(
                    "missing_prompt",
                    AgentSeverity.Warning,
                    "The agent needs a prompt",
                    "conversation_config.agent.prompt.prompt"
                )
            );
        }

        var unique = Dedupe(issues);
        var errors = unique.Where(issue => issue.Severity == AgentSeverity.Error).ToList();
        if (errors.Count > 0)
        {
            throw new AgentValidationException(_name, errors);
        }
        if (onWarning != null)
        {
            foreach (var warning in unique.Where(issue => issue.Severity == AgentSeverity.Warning))
            {
                onWarning(warning);
            }
        }

        config["name"] = _name;
        if (config["conversation_config"] == null)
        {
            config["conversation_config"] = new JsonObject();
        }
        if (config["platform_settings"] == null)
        {
            config["platform_settings"] = new JsonObject();
        }
        config["tags"] = _tags?.DeepClone() ?? new JsonArray();
        return (JsonObject)Wire.Canonicalize(config)!;
    }

    private static JsonObject? ToWire(object settings, string option, List<AgentIssue> issues)
    {
        try
        {
            return JsonUtils.SerializeToNode(settings) as JsonObject ?? throw new ArgumentException("not a JSON object");
        }
        catch (Exception ex)
        {
            issues.Add(new AgentIssue("invalid_config", AgentSeverity.Error, $"Invalid {option}: {ex.Message}", option));
            return null;
        }
    }

    internal static string? SafeJson(Tool tool)
    {
        try
        {
            return tool.ToJsonString();
        }
        catch (Exception)
        {
            return null;
        }
    }

    /// <summary><paramref name="ids"/> with the ones in <paramref name="loaded"/> first, in that order, then the rest as they are.</summary>
    private static List<string> KeepOrder(List<string> ids, List<string> loaded)
    {
        int Rank(string id)
        {
            var i = loaded.IndexOf(id);
            return i == -1 ? loaded.Count : i;
        }
        return ids.Select((id, i) => (id, i)).OrderBy(x => Rank(x.id)).ThenBy(x => x.i).Select(x => x.id).ToList();
    }

    private static JsonArray ToArray(IEnumerable<string> values)
    {
        var arr = new JsonArray();
        foreach (var value in values)
        {
            arr.Add(value);
        }
        return arr;
    }

    private static AgentIssue Conflict(string option, IEnumerable<string> path)
    {
        var dotted = string.Join(".", path);
        return new AgentIssue(
            "option_conflict",
            AgentSeverity.Error,
            $"\"{option}\" and the raw config both set {dotted}; set it in one place",
            dotted
        );
    }

    private static List<AgentIssue> Dedupe(List<AgentIssue> issues)
    {
        var seen = new HashSet<string>();
        return issues.Where(issue => seen.Add($"{issue.Code}|{issue.Path}|{issue.Message}")).ToList();
    }
}
