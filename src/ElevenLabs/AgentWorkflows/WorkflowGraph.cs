using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;

namespace ElevenLabs.AgentWorkflows;

// Inside the namespace, so it wins over the generated ElevenLabs.Tool model.
using Tool = ElevenLabs.AgentTools.Tool;

/// <summary>
/// Mutable state shared by a <see cref="Workflow"/> and every node handle created from it. Nodes are kept in wire
/// format (<see cref="JsonObject"/>), in insertion order.
/// </summary>
internal sealed class WorkflowGraph
{
    // Canonical option name -> API field, per node type.
    private static readonly Dictionary<string, Dictionary<string, string>> Fields = new()
    {
        ["start"] = new() { ["position"] = "position" },
        ["end"] = new() { ["position"] = "position" },
        ["override_agent"] = new()
        {
            ["position"] = "position",
            ["prompt"] = "additional_prompt",
            ["label"] = "label",
            ["tool_ids"] = "additional_tool_ids",
            ["knowledge_base"] = "additional_knowledge_base",
            ["conversation_config"] = "conversation_config",
            ["entry_behavior"] = "entry_behavior",
        },
        ["tool"] = new() { ["position"] = "position" },
        ["phone_number"] = new()
        {
            ["position"] = "position",
            ["transfer_type"] = "transfer_type",
            ["custom_sip_headers"] = "custom_sip_headers",
            ["sip_refer_play_dialtone"] = "sip_refer_play_dialtone",
            ["uui"] = "uui",
            ["post_dial_digits"] = "post_dial_digits",
        },
        ["standalone_agent"] = new()
        {
            ["position"] = "position",
            ["delay_ms"] = "delay_ms",
            ["transfer_message"] = "transfer_message",
            ["enable_transferred_agent_first_message"] = "enable_transferred_agent_first_message",
            ["preserve_client_tts_overrides"] = "preserve_client_tts_overrides",
            ["preserve_voice_settings"] = "preserve_voice_settings",
        },
    };

    private static readonly Dictionary<string, string> NodeKind = new()
    {
        ["start"] = "start",
        ["end"] = "end",
        ["override_agent"] = "subagent",
        ["tool"] = "tool",
        ["phone_number"] = "phone/SIP transfer",
        ["standalone_agent"] = "agent transfer",
    };

    private static readonly string[] TransferTypes = { "phone_number", "standalone_agent" };

    private readonly List<string> _nodeOrder = new();
    private readonly Dictionary<string, JsonObject> _nodes = new();

    public List<GraphEdge> Edges { get; set; } = new();
    public List<WorkflowIssue> Issues { get; } = new();
    public string StartId { get; set; } = "start_node";

    /// <summary>Each loaded node's <c>edge_order</c>, as edges. <c>Build()</c> keeps this order and appends edges added since.</summary>
    public Dictionary<string, List<GraphEdge>> LoadedOrder { get; } = new();
    public bool? PreventSubagentLoops { get; set; }

    public IReadOnlyList<string> NodeOrder => _nodeOrder;

    private readonly Dictionary<string, Tool> _toolRefs = new();
    private readonly List<string> _toolRefOrder = new();

    /// <summary><c>Tool</c> objects referenced by nodes, by placeholder, in the order they were first referenced.</summary>
    public IEnumerable<KeyValuePair<string, Tool>> ToolRefs =>
        _toolRefOrder.Select(key => new KeyValuePair<string, Tool>(key, _toolRefs[key]));

    /// <summary>The <c>Tool</c> object a placeholder stands for, or <c>null</c> for a plain tool id.</summary>
    public Tool? ToolRefFor(string id) => _toolRefs.TryGetValue(id, out var tool) ? tool : null;

    public void SetToolRef(string key, Tool tool)
    {
        if (!_toolRefs.ContainsKey(key))
        {
            _toolRefOrder.Add(key);
        }
        _toolRefs[key] = tool;
    }

    /// <summary>The placeholder a <c>Tool</c> object stands under in the graph until <c>Build()</c> swaps in its id.</summary>
    public static string ToolPlaceholder(string name) => $"<tool:{name}>";

    /// <summary>A tool id as shown in messages: the name for a <c>Tool</c> object's placeholder.</summary>
    public static string DisplayTool(string id)
    {
        var match = Regex.Match(id, "^<tool:(.*)>$", RegexOptions.Singleline);
        return match.Success ? match.Groups[1].Value : id;
    }

    /// <summary>Swaps <c>Tool</c> objects for placeholders, remembering each one, and returns the node's tool ids.</summary>
    public List<string> RefTools(string nodeId, IEnumerable<ToolRef> refs)
    {
        var inThisNode = new Dictionary<string, Tool>();
        var ids = new List<string>();
        foreach (var reference in refs)
        {
            if (reference.Tool == null)
            {
                ids.Add(reference.Id ?? throw new ArgumentException("A ToolRef needs an id or a Tool", nameof(refs)));
                continue;
            }
            var tool = reference.Tool;
            var key = ToolPlaceholder(tool.Name);
            // A different tool of the same name conflicts if this node or another node still uses it; one left
            // behind by a removed or edited node doesn't.
            inThisNode.TryGetValue(key, out var clash);
            if (clash == null && _toolRefs.TryGetValue(key, out var known) && UsesPlaceholder(key, nodeId))
            {
                clash = known;
            }
            inThisNode[key] = tool;
            if (clash != null && !ReferenceEquals(clash, tool))
            {
                Issue("duplicate_tool_name", $"Node \"{nodeId}\" uses a different tool also named \"{tool.Name}\"", nodeId);
            }
            SetToolRef(key, tool);
            ids.Add(key);
        }
        return ids;
    }

    private bool UsesPlaceholder(string key, string exceptNodeId)
    {
        foreach (var id in _nodeOrder)
        {
            if (id != exceptNodeId && NodeToolIds(_nodes[id]).Contains(key))
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>The tool ids (or placeholders) a node uses: a tool node's tools, or a subagent's extra tools.</summary>
    public static List<string> NodeToolIds(JsonObject model)
    {
        var ids = new List<string>();
        if (model["tools"] is JsonArray tools)
        {
            foreach (var tool in tools)
            {
                if (tool is JsonObject locator && Str(locator["tool_id"]) is string toolId)
                {
                    ids.Add(toolId);
                }
            }
        }
        if (model["additional_tool_ids"] is JsonArray extra)
        {
            foreach (var item in extra)
            {
                if (Str(item) is string toolId)
                {
                    ids.Add(toolId);
                }
            }
        }
        return ids;
    }

    /// <summary>A copy of a node with its tool ids mapped: a tool node's tools, or a subagent's extra tools.</summary>
    public static JsonObject MapNodeToolIds(JsonObject model, Func<string, string> map)
    {
        var type = TypeOf(model);
        if (type == "tool" && model["tools"] is JsonArray tools)
        {
            var copy = (JsonObject)model.DeepClone();
            foreach (var tool in (JsonArray)copy["tools"]!)
            {
                if (tool is JsonObject locator && Str(locator["tool_id"]) is string toolId)
                {
                    locator["tool_id"] = map(toolId);
                }
            }
            return copy;
        }
        if (type == "override_agent" && model["additional_tool_ids"] is JsonArray)
        {
            var copy = (JsonObject)model.DeepClone();
            var mapped = new JsonArray();
            foreach (var item in (JsonArray)copy["additional_tool_ids"]!)
            {
                mapped.Add(Str(item) is string toolId ? JsonValue.Create(map(toolId)) : item?.DeepClone());
            }
            copy["additional_tool_ids"] = mapped;
            return copy;
        }
        return model;
    }

    /// <summary>Swaps tool ids for the <c>Tool</c> objects they stand for. Ids missing from <paramref name="byId"/> stay as they are.</summary>
    public void BindTools(IReadOnlyDictionary<string, Tool> byId)
    {
        string Swap(string id)
        {
            if (!byId.TryGetValue(id, out var tool))
            {
                return id;
            }
            var key = ToolPlaceholder(tool.Name);
            SetToolRef(key, tool);
            return key;
        }
        foreach (var id in _nodeOrder.ToList())
        {
            _nodes[id] = MapNodeToolIds(_nodes[id], Swap);
        }
    }

    private static string? Str(JsonNode? node) =>
        node is JsonValue value && value.GetValueKind() == System.Text.Json.JsonValueKind.String
            ? value.GetValue<string>()
            : null;

    public bool ContainsNode(string id) => _nodes.ContainsKey(id);

    public JsonObject GetNode(string id) => _nodes[id];

    public void SetNode(string id, JsonObject model) => _nodes[id] = model;

    public void RemoveNode(string id)
    {
        if (_nodes.Remove(id))
        {
            _nodeOrder.Remove(id);
        }
    }

    public void Issue(string code, string message, string? nodeId) =>
        Issues.Add(new WorkflowIssue(code, WorkflowSeverity.Error, message, nodeId));

    public void AddNode(string id, JsonObject model)
    {
        if (!_nodes.TryGetValue(id, out var existing))
        {
            _nodes[id] = model;
            _nodeOrder.Add(id);
        }
        else if (!(TypeOf(existing) == "end" && TypeOf(model) == "end"))
        {
            Issue("duplicate_node_id", $"Node id \"{id}\" is used by more than one node", id);
        }
    }

    /// <summary>Applies canonical options to a node model. The special options are passed separately; the rest map through <see cref="Fields"/>.</summary>
    public JsonObject ApplyOptions(
        string id,
        JsonObject model,
        Destination? destination,
        IReadOnlyList<string>? toolIds,
        JsonObject? schemaOverrides,
        Dictionary<string, JsonNode?> rest
    )
    {
        var node = (JsonObject)model.DeepClone();

        if (destination != null)
        {
            var type = TypeOf(node);
            if (type == "phone_number" || type == "standalone_agent")
            {
                var dest = destination.ToWire();
                var destType = TypeOf(dest);
                if (destType != type)
                {
                    var position = node["position"]?.DeepClone();
                    node = (JsonObject)dest.DeepClone();
                    if (position != null)
                    {
                        node["position"] = position;
                    }
                }
                else
                {
                    if (type == "standalone_agent")
                    {
                        // A new agent destination starts at that agent's default entry point, not the old one's.
                        node.Remove("agent_id");
                        node.Remove("node_id");
                        node.Remove("branch_id");
                    }
                    foreach (var kv in dest)
                    {
                        node[kv.Key] = kv.Value?.DeepClone();
                    }
                }
            }
            else
            {
                InvalidOption(id, "destination", type);
            }
        }

        var fieldsInput = new Dictionary<string, JsonNode?>(rest);
        var nodeType = TypeOf(node);
        if (schemaOverrides != null)
        {
            // A Tool object's overrides may be keyed by its name.
            var byPlaceholder = new JsonObject();
            foreach (var kv in schemaOverrides)
            {
                var placeholder = ToolPlaceholder(kv.Key);
                byPlaceholder[_toolRefs.ContainsKey(placeholder) ? placeholder : kv.Key] = kv.Value?.DeepClone();
            }
            schemaOverrides = byPlaceholder;
        }
        if (nodeType == "tool")
        {
            var existing = node["tools"] as JsonArray;
            var ids =
                toolIds != null
                    ? toolIds.ToList()
                    : existing?.Select(t => t!["tool_id"]!.GetValue<string>()).ToList() ?? new List<string>();
            if (schemaOverrides != null)
            {
                foreach (var kv in schemaOverrides)
                {
                    if (!ids.Contains(kv.Key))
                    {
                        Issue(
                            "invalid_option",
                            $"Node \"{id}\" has schema overrides for tool \"{DisplayTool(kv.Key)}\", which it doesn't run",
                            id
                        );
                    }
                }
            }
            var tools = new JsonArray();
            foreach (var toolId in ids)
            {
                JsonNode? overrides = null;
                if (schemaOverrides != null && schemaOverrides.ContainsKey(toolId))
                {
                    overrides = schemaOverrides[toolId]?.DeepClone();
                }
                else if (existing != null)
                {
                    overrides = existing
                        .FirstOrDefault(t => t!["tool_id"]?.GetValue<string>() == toolId)
                        ?["schema_overrides"]
                        ?.DeepClone();
                }
                var tool = new JsonObject { ["tool_id"] = toolId };
                if (overrides != null)
                {
                    tool["schema_overrides"] = overrides;
                }
                tools.Add(tool);
            }
            node["tools"] = tools;
        }
        else
        {
            if (schemaOverrides != null)
            {
                InvalidOption(id, "schema_overrides", nodeType);
            }
            if (toolIds != null)
            {
                var arr = new JsonArray();
                foreach (var toolId in toolIds)
                {
                    arr.Add(toolId);
                }
                fieldsInput["tool_ids"] = arr;
            }
        }

        // Node kinds without a dedicated field map (e.g. generated say/update_state) still accept
        // position, which is common to every node kind.
        var fields = Fields.TryGetValue(nodeType ?? "", out var f)
            ? f
            : new Dictionary<string, string> { ["position"] = "position" };
        foreach (var kv in fieldsInput)
        {
            if (kv.Value == null)
            {
                continue;
            }
            if (!fields.TryGetValue(kv.Key, out var field))
            {
                InvalidOption(id, kv.Key, nodeType);
            }
            else
            {
                node[field] = kv.Value.DeepClone();
            }
        }
        return node;
    }

    /// <summary>Replaces the graph's contents with an existing wire-format workflow, keeping ids, positions and edge order.</summary>
    public void Load(JsonObject workflow)
    {
        _nodes.Clear();
        _nodeOrder.Clear();
        Edges = new List<GraphEdge>();
        Issues.Clear();
        LoadedOrder.Clear();
        _toolRefs.Clear();
        _toolRefOrder.Clear();
        PreventSubagentLoops = (workflow["prevent_subagent_loops"] as JsonValue)?.GetValue<bool>();

        var nodes = workflow["nodes"] as JsonObject ?? new JsonObject();
        var edges = workflow["edges"] as JsonObject ?? new JsonObject();

        foreach (var kv in nodes)
        {
            var model = new JsonObject();
            foreach (var field in (JsonObject)kv.Value!)
            {
                if (field.Key != "edge_order")
                {
                    model[field.Key] = field.Value?.DeepClone();
                }
            }
            _nodes[kv.Key] = model;
            _nodeOrder.Add(kv.Key);
        }

        StartId = nodes.FirstOrDefault(kv => TypeOf((JsonObject)kv.Value!) == "start").Key ?? "start_node";
        if (!_nodes.ContainsKey(StartId))
        {
            _nodes[StartId] = new JsonObject { ["type"] = "start" };
            _nodeOrder.Add(StartId);
        }

        // Rebuild the edge list in each node's edge_order, so that Build() reproduces it.
        var placed = new Dictionary<string, GraphEdge>();

        void AddEdge(string edgeId)
        {
            if (placed.ContainsKey(edgeId) || edges[edgeId] is not JsonObject edge)
            {
                return;
            }
            var graphEdge = new GraphEdge(
                edge["source"]?.GetValue<string>() ?? "",
                edge["target"]?.GetValue<string>() ?? ""
            )
            {
                Id = edgeId,
                ForwardCondition = (JsonObject?)edge["forward_condition"]?.DeepClone(),
                BackwardCondition = (JsonObject?)edge["backward_condition"]?.DeepClone(),
            };
            var extra = new JsonObject();
            foreach (var field in edge)
            {
                if (field.Key is "source" or "target" or "forward_condition" or "backward_condition")
                {
                    continue;
                }
                extra[field.Key] = field.Value?.DeepClone();
            }
            graphEdge.Extra = extra;
            placed[edgeId] = graphEdge;
            Edges.Add(graphEdge);
        }

        foreach (var kv in nodes)
        {
            var order = (kv.Value as JsonObject)?["edge_order"] as JsonArray;
            var loaded = new List<GraphEdge>();
            if (order != null)
            {
                foreach (var edgeIdNode in order)
                {
                    var edgeId = edgeIdNode!.GetValue<string>();
                    AddEdge(edgeId);
                    if (placed.TryGetValue(edgeId, out var e))
                    {
                        loaded.Add(e);
                    }
                }
            }
            LoadedOrder[kv.Key] = loaded;
        }
        foreach (var kv in edges)
        {
            AddEdge(kv.Key);
        }
    }

    private void InvalidOption(string id, string option, string? nodeType)
    {
        var kind = nodeType != null && NodeKind.TryGetValue(nodeType, out var k) ? k : $"\"{nodeType}\"";
        Issue("invalid_option", $"Option \"{option}\" doesn't apply to {kind} node \"{id}\"", id);
    }

    private static string? TypeOf(JsonObject model) => (model["type"] as JsonValue)?.GetValue<string>();
}
