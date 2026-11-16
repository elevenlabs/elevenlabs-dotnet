using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Nodes;

namespace ElevenLabs.AgentWorkflows;

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
                            $"Node \"{id}\" has schema overrides for tool \"{kv.Key}\", which it doesn't run",
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

        var fields = Fields.TryGetValue(nodeType ?? "", out var f) ? f : new Dictionary<string, string>();
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
