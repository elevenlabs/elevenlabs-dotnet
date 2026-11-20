using System.Net;
using System.Reflection;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;

namespace ElevenLabs.Tests;

/// <summary>The shared CLI project fixture (copied from elevenlabs-js <c>docs/agents-as-code/fixtures/project/cli-graph</c>), embedded by project-relative path.</summary>
internal static class CliProjectFixture
{
    private const string Prefix = "AgentProjectFixtures/cli-graph/";

    /// <summary>Every fixture file, keyed by its path relative to the project root, with its exact text.</summary>
    public static Dictionary<string, string> Files()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var files = new Dictionary<string, string>();
        foreach (var name in assembly.GetManifestResourceNames().Select(n => n.Replace('\\', '/')).Where(n => n.StartsWith(Prefix)))
        {
            using var stream = assembly.GetManifestResourceStream(name)
                ?? assembly.GetManifestResourceStream(name.Replace('/', '\\'))!;
            using var reader = new StreamReader(stream, new UTF8Encoding(false));
            files[name.Substring(Prefix.Length)] = reader.ReadToEnd();
        }
        return files;
    }

    public static JsonObject Json(string path) => (JsonObject)JsonNode.Parse(Files()[path])!;

    /// <summary>Writes <paramref name="files"/> into a new temporary directory and returns it.</summary>
    public static string WriteTree(IReadOnlyDictionary<string, string> files)
    {
        var dir = TempDir();
        foreach (var file in files)
        {
            var path = Path.Combine(dir, file.Key);
            Directory.CreateDirectory(Path.GetDirectoryName(path)!);
            File.WriteAllText(path, file.Value, new UTF8Encoding(false));
        }
        return dir;
    }

    public static string TempDir()
    {
        var dir = Path.Combine(Path.GetTempPath(), "agents-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(dir);
        return dir;
    }

    /// <summary>Every file under <paramref name="dir"/>, keyed by its path relative to it with forward slashes.</summary>
    public static Dictionary<string, string> ReadTree(string dir) =>
        Directory
            .EnumerateFiles(dir, "*", SearchOption.AllDirectories)
            .ToDictionary(
                path => Path.GetRelativePath(dir, path).Replace('\\', '/'),
                path => File.ReadAllText(path, new UTF8Encoding(false))
            );
}

/// <summary>
/// An in-memory stand-in for the agents and tools endpoints push and pull use, behind the real client stack.
/// Mirrors elevenlabs-js <c>tests/custom/agents/agent/fakeServer.ts</c>.
/// </summary>
internal sealed class FakeAgentServer : HttpMessageHandler
{
    public sealed record Call(string Method, string Path, Dictionary<string, string> Query, JsonObject? Body);

    public sealed class FakeTool
    {
        public required JsonObject Config { get; set; }
        public List<string> UsedBy { get; set; } = new();
    }

    public Dictionary<string, FakeTool> Tools { get; } = new();
    public Dictionary<string, JsonObject> Agents { get; } = new();

    /// <summary>Branch configs by <c>agentId/branchId</c>. Only the main branch counts for <c>used_by_agent_id</c>, as in the API.</summary>
    public Dictionary<string, JsonObject> Branches { get; } = new();
    public List<Call> Calls { get; } = new();

    /// <summary>Fails every request whose <c>METHOD path</c> matches.</summary>
    public Regex? FailOn { get; set; }

    /// <summary>Called with each request as it arrives.</summary>
    public Action<Call>? OnCall { get; set; }

    private int _next = 1;

    public void AddTool(string id, JsonObject config, params string[] usedBy) =>
        Tools[id] = new FakeTool { Config = config, UsedBy = usedBy.ToList() };

    public void AddAgent(string id, JsonObject config) => Agents[id] = config;

    public ElevenLabsClient Client() =>
        new(
            "test",
            new ClientOptions
            {
                BaseUrl = "https://api.test/",
                HttpClient = new HttpClient(this, disposeHandler: false),
                MaxRetries = 0,
            }
        );

    /// <summary>The calls that change something, as <c>METHOD path</c>.</summary>
    public List<string> Writes() => Calls.Where(c => c.Method != "GET").Select(c => $"{c.Method} {c.Path}").ToList();

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var uri = request.RequestUri!;
        var method = request.Method.Method;
        var text = request.Content == null ? null : await request.Content.ReadAsStringAsync(cancellationToken);
        var body = string.IsNullOrEmpty(text) ? null : JsonNode.Parse(text) as JsonObject;
        var query = ParseQuery(uri.Query);
        var path = uri.AbsolutePath;
        var call = new Call(method, path, query, body);
        Calls.Add(call);
        OnCall?.Invoke(call);
        if (FailOn?.IsMatch($"{method} {path}") == true)
        {
            return Json(new JsonObject { ["detail"] = "boom" }, HttpStatusCode.InternalServerError);
        }
        var parts = path.Split('/'); // /v1/convai/<kind>/<id>
        var kind = parts.Length > 3 ? parts[3] : null;
        var id = parts.Length > 4 ? parts[4] : null;
        if (kind == "tools")
        {
            if (method == "GET" && id == null)
            {
                query.TryGetValue("used_by_agent_id", out var agentId);
                var tools = new JsonArray();
                foreach (var tool in Tools.Where(t => agentId == null || t.Value.UsedBy.Contains(agentId)))
                {
                    tools.Add(ToolResponse(tool.Key, tool.Value.Config));
                }
                return Json(new JsonObject { ["tools"] = tools, ["has_more"] = false });
            }
            if (method == "POST")
            {
                var toolId = $"tool_new_{_next++}";
                var config = (JsonObject)body!["tool_config"]!.DeepClone();
                Tools[toolId] = new FakeTool { Config = config };
                return Json(ToolResponse(toolId, config));
            }
            if (id == null || !Tools.TryGetValue(id, out var existing))
            {
                return Json(new JsonObject { ["detail"] = "not found" }, HttpStatusCode.NotFound);
            }
            if (method == "PATCH")
            {
                existing.Config = (JsonObject)body!["tool_config"]!.DeepClone();
            }
            return Json(ToolResponse(id, existing.Config));
        }
        if (kind == "agents" && id != null)
        {
            if (method == "POST" && id == "create")
            {
                var agentId = $"agent_new_{_next++}";
                StoreAgent(agentId, body!);
                return Json(new JsonObject { ["agent_id"] = agentId });
            }
            if (query.TryGetValue("branch_id", out var branchId))
            {
                var key = $"{id}/{branchId}";
                if (method == "PATCH")
                {
                    Branches[key] = Merge(Branches.TryGetValue(key, out var old) ? old : null, body!);
                }
                return Branches.TryGetValue(key, out var branch)
                    ? Json(AgentResponse(id, branch))
                    : Json(new JsonObject { ["detail"] = "not found" }, HttpStatusCode.NotFound);
            }
            if (method == "PATCH")
            {
                StoreAgent(id, Merge(Agents.TryGetValue(id, out var old) ? old : null, body!));
                return Json(AgentResponse(id, Agents[id]));
            }
            return Agents.TryGetValue(id, out var agent)
                ? Json(AgentResponse(id, agent))
                : Json(new JsonObject { ["detail"] = "not found" }, HttpStatusCode.NotFound);
        }
        throw new InvalidOperationException($"unexpected request {method} {path}");
    }

    /// <summary>A shallow merge, like <c>{ ...old, ...body }</c>.</summary>
    private static JsonObject Merge(JsonObject? old, JsonObject body)
    {
        var merged = (JsonObject?)old?.DeepClone() ?? new JsonObject();
        foreach (var field in body)
        {
            merged[field.Key] = field.Value?.DeepClone();
        }
        return merged;
    }

    private void StoreAgent(string agentId, JsonObject config)
    {
        Agents[agentId] = (JsonObject)config.DeepClone();
        var ids = new List<string>();
        if (config["conversation_config"]?["agent"]?["prompt"]?["tool_ids"] is JsonArray promptIds)
        {
            ids.AddRange(promptIds.Select(i => i!.GetValue<string>()));
        }
        foreach (var node in (config["workflow"]?["nodes"] as JsonObject ?? new JsonObject()))
        {
            foreach (var tool in node.Value?["tools"] as JsonArray ?? new JsonArray())
            {
                ids.Add(tool!["tool_id"]!.GetValue<string>());
            }
            foreach (var extra in node.Value?["additional_tool_ids"] as JsonArray ?? new JsonArray())
            {
                ids.Add(extra!.GetValue<string>());
            }
        }
        foreach (var tool in Tools)
        {
            tool.Value.UsedBy.Remove(agentId);
            if (ids.Contains(tool.Key))
            {
                tool.Value.UsedBy.Add(agentId);
            }
        }
    }

    private static JsonObject ToolResponse(string id, JsonObject config) =>
        new()
        {
            ["id"] = id,
            ["tool_config"] = config.DeepClone(),
            ["access_info"] = new JsonObject
            {
                ["is_creator"] = true,
                ["creator_name"] = "a",
                ["creator_email"] = "a@example.com",
                ["role"] = "admin",
            },
            ["usage_stats"] = new JsonObject { ["avg_latency_secs"] = 0.1 },
        };

    /// <summary>The defaults the API fills into a stored workflow, which the response model requires.</summary>
    private static JsonObject WithServerDefaults(JsonObject workflow)
    {
        var nodes = new JsonObject();
        foreach (var node in workflow["nodes"] as JsonObject ?? new JsonObject())
        {
            var model = (JsonObject)node.Value!.DeepClone();
            if (model["type"]?.GetValue<string>() == "override_agent")
            {
                var withDefaults = new JsonObject
                {
                    ["conversation_config"] = new JsonObject(),
                    ["additional_knowledge_base"] = new JsonArray(),
                    ["additional_tool_ids"] = new JsonArray(),
                    ["entry_behavior"] = "generate_immediately",
                    ["allow_interruptions_on_entry"] = true,
                };
                model = Merge(withDefaults, model);
            }
            nodes[node.Key] = model;
        }
        var edges = new JsonObject();
        foreach (var edge in workflow["edges"] as JsonObject ?? new JsonObject())
        {
            edges[edge.Key] = Merge(new JsonObject { ["reroutes"] = new JsonArray() }, (JsonObject)edge.Value!);
        }
        var result = Merge(new JsonObject { ["prevent_subagent_loops"] = false }, workflow);
        result["nodes"] = nodes;
        result["edges"] = edges;
        return result;
    }

    private static JsonObject AgentResponse(string id, JsonObject config)
    {
        var response = Merge(
            new JsonObject
            {
                ["agent_id"] = id,
                ["metadata"] = new JsonObject { ["created_at_unix_secs"] = 1, ["updated_at_unix_secs"] = 1 },
                ["created_at_unix_secs"] = 1,
                ["updated_at_unix_secs"] = 1,
                ["version_id"] = "ver_1",
            },
            config
        );
        if (config["workflow"] is JsonObject workflow)
        {
            response["workflow"] = WithServerDefaults(workflow);
        }
        return response;
    }

    private static Dictionary<string, string> ParseQuery(string query)
    {
        var result = new Dictionary<string, string>();
        foreach (var pair in query.TrimStart('?').Split('&', StringSplitOptions.RemoveEmptyEntries))
        {
            var eq = pair.IndexOf('=');
            var key = Uri.UnescapeDataString(eq < 0 ? pair : pair.Substring(0, eq));
            result[key] = eq < 0 ? "" : Uri.UnescapeDataString(pair.Substring(eq + 1));
        }
        return result;
    }

    private static HttpResponseMessage Json(JsonNode body, HttpStatusCode status = HttpStatusCode.OK) =>
        new(status) { Content = new StringContent(body.ToJsonString(), Encoding.UTF8, "application/json") };
}
