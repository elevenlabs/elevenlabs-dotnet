using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Nodes;
using ElevenLabs.Core;

namespace ElevenLabs.AgentWorkflows;

/// <summary>
/// An agent workflow, written as code. The workflow itself is the start node: calling a verb on it branches from
/// the start. Build it with the verbs and routing methods, then <see cref="Build"/> it into the request model that
/// <c>agents.Create()</c> / <c>agents.Update()</c> accept, or <see cref="ToJsonString"/> it to store as config.
/// </summary>
/// <example>
/// <code>
/// var wf = new Workflow();
/// var triage = wf.Converse("triage", "Find out what the caller needs");
/// var lookup = triage.When("Caller gave an order number").Tool("lookup_order", new[] { "tool_123" });
/// lookup.OnResult(
///     success: ok => ok.Converse("resolve", "Explain the order status").End(),
///     failure: failed => failed.Transfer("human", Destination.Phone("+15551234567")));
/// </code>
/// </example>
public sealed class Workflow : WorkflowChain
{
    /// <param name="preventSubagentLoops">Stops the conversation from re-entering a subagent it already visited.</param>
    public Workflow(bool? preventSubagentLoops = null)
        : base(new WorkflowGraph())
    {
        Graph.AddNode(Graph.StartId, new JsonObject { ["type"] = "start" });
        Graph.PreventSubagentLoops = preventSubagentLoops;
    }

    /// <summary>Loads the workflow of an existing agent (the result of <c>agents.Get()</c>) so it can be edited.</summary>
    public static Workflow FromAgent(GetAgentResponseModel agent) => FromModelNode(SerializeWorkflow(agent.Workflow));

    /// <summary>Loads a workflow from a get-agent response's <c>workflow</c> field.</summary>
    public static Workflow FromAgent(AgentWorkflowResponseModel workflow) => FromModelNode(SerializeWorkflow(workflow));

    /// <summary>Loads a workflow request model so it can be edited.</summary>
    public static Workflow FromAgent(AgentWorkflowRequestModel workflow) => FromModelNode(SerializeWorkflow(workflow));

    /// <summary>
    /// Loads a workflow stored as API-format JSON (snake_case), for example from <see cref="ToJsonString"/> or a CLI
    /// <c>agent_configs/*.json</c> file. The input is either a workflow or a whole agent config with a <c>workflow</c> key.
    /// </summary>
    public static Workflow FromJson(string json) => FromJson(JsonNode.Parse(json) ?? new JsonObject());

    /// <summary>Loads a workflow from a parsed JSON node (a workflow, or an agent config with a <c>workflow</c> key).</summary>
    public static Workflow FromJson(JsonNode parsed)
    {
        var raw =
            parsed is JsonObject obj && obj.ContainsKey("workflow") ? obj["workflow"] as JsonObject : parsed as JsonObject;
        var wf = new Workflow();
        if (raw != null)
        {
            wf.Graph.Load(raw);
        }
        return wf;
    }

    /// <summary>The id of the start node: <c>"start_node"</c>, the id the API requires, or whatever a loaded workflow uses.</summary>
    public string StartId => Graph.StartId;

    /// <summary>Ids of every node, in the order they were added.</summary>
    public IReadOnlyList<string> NodeIds => Graph.NodeOrder.ToList();

    /// <summary>Opens a branch from the start node that is followed when <paramref name="condition"/> holds.</summary>
    public WorkflowBranch When(Condition condition, Condition? back = null) => Branch(Graph, Graph.StartId, condition, back);

    /// <summary>Opens a branch from the start node, followed when the LLM judges <paramref name="condition"/> to be true.</summary>
    public WorkflowBranch When(string condition, Condition? back = null) => When(Condition.Llm(condition), back);

    /// <summary>Opens a branch from the start node, followed when <paramref name="condition"/> evaluates to true.</summary>
    public WorkflowBranch When(Expr condition, Condition? back = null) => When(Condition.Expr(condition), back);

    /// <summary>A handle to an existing node, for editing it or going to it.</summary>
    public WorkflowNode Node(string id)
    {
        if (!Graph.ContainsNode(id))
        {
            Graph.Issue("unknown_node", $"There is no node \"{id}\"", id);
        }
        return new WorkflowNode(Graph, id);
    }

    /// <summary>Removes a node and every edge to or from it.</summary>
    public Workflow Remove(string id)
    {
        if (id == Graph.StartId)
        {
            Graph.Issue("cannot_remove_start", "The start node can't be removed", id);
            return this;
        }
        Graph.RemoveNode(id);
        Graph.Edges = Graph.Edges.Where(edge => edge.Source != id && edge.Target != id).ToList();
        return this;
    }

    /// <summary>
    /// Splices new nodes into the edge from <paramref name="sourceId"/> to <paramref name="targetId"/>. <paramref name="insert"/>
    /// receives a branch carrying that edge's conditions and returns the last new node, which is then connected to
    /// <paramref name="targetId"/>. Returns that node, or <c>null</c> if there is no such edge or the callback returned nothing.
    /// </summary>
    public WorkflowNode? InsertBetween(string sourceId, string targetId, Func<WorkflowBranch, WorkflowNode?> insert)
    {
        var index = Graph.Edges.FindIndex(edge => edge.Source == sourceId && edge.Target == targetId);
        if (index == -1)
        {
            Graph.Issue("unknown_edge", $"There is no edge from \"{sourceId}\" to \"{targetId}\" to insert into", sourceId);
            return null;
        }
        var original = Graph.Edges[index];
        Graph.Edges.RemoveAt(index);
        var before = Graph.Edges.Count;
        var last = insert(
            new WorkflowBranch(
                Graph,
                new EdgeOrigin(sourceId, original.ForwardCondition ?? Condition.Always().ToWire(), original.BackwardCondition)
            )
        );

        // Put the first new edge back where the original was, so the source's edge order is unchanged.
        var firstHop = -1;
        for (var i = before; i < Graph.Edges.Count; i++)
        {
            if (Graph.Edges[i].Source == sourceId)
            {
                firstHop = i;
                break;
            }
        }
        if (firstHop != -1)
        {
            var edge = Graph.Edges[firstHop];
            Graph.Edges.RemoveAt(firstHop);
            Graph.Edges.Insert(index, edge);
            if (Graph.LoadedOrder.TryGetValue(sourceId, out var loaded))
            {
                for (var slot = 0; slot < loaded.Count; slot++)
                {
                    if (ReferenceEquals(loaded[slot], original))
                    {
                        loaded[slot] = edge;
                        break;
                    }
                }
            }
        }

        if (last == null)
        {
            Graph.Issue(
                "missing_insert_result",
                $"InsertBetween(\"{sourceId}\", \"{targetId}\") must return the last inserted node",
                sourceId
            );
            return null;
        }
        if (last.Type == "tool")
        {
            last.OnSuccess().GoTo(targetId);
        }
        else
        {
            last.GoTo(targetId);
        }
        return last;
    }

    /// <summary>
    /// Validates the workflow and returns it in the shape <c>agents.Create()</c> and <c>agents.Update()</c> accept.
    /// </summary>
    /// <exception cref="WorkflowValidationException">Listing every problem, if the workflow is invalid.</exception>
    public AgentWorkflowRequestModel Build(Action<WorkflowIssue>? onWarning = null)
    {
        var wire = ToWireObject(onWarning);
        return JsonUtils.Deserialize<AgentWorkflowRequestModel>(wire.ToJsonString());
    }

    /// <summary>The workflow in API format (snake_case keys, sorted at every level), for storing as config. Validates like <see cref="Build"/>.</summary>
    public JsonObject ToJson() => (JsonObject)Wire.Canonicalize(ToWireObject(null))!;

    /// <summary><see cref="ToJson"/> as a string with 2-space indentation and a trailing newline: the canonical file format.</summary>
    public string ToJsonString() => Wire.ToCanonicalString(ToWireObject(null));

    private protected override EdgeOrigin Origin() => new(Graph.StartId, Condition.Always().ToWire());

    private static Workflow FromModelNode(JsonObject? workflow)
    {
        var wf = new Workflow();
        if (workflow != null)
        {
            wf.Graph.Load(workflow);
        }
        return wf;
    }

    private static JsonObject? SerializeWorkflow(object? workflow) =>
        workflow == null ? null : JsonUtils.SerializeToNode(workflow) as JsonObject;

    /// <summary>Validates, merges reverse edges, lays out positions and assembles the wire-format workflow object.</summary>
    internal JsonObject ToWireObject(Action<WorkflowIssue>? onWarning)
    {
        var issues = Validate.Run(Graph);
        var errors = issues.Where(issue => issue.Severity == WorkflowSeverity.Error).ToList();
        if (errors.Count > 0)
        {
            throw new WorkflowValidationException(errors);
        }
        if (onWarning != null)
        {
            foreach (var warning in issues.Where(issue => issue.Severity == WorkflowSeverity.Warning))
            {
                onWarning(warning);
            }
        }

        // An edge that goes back the way another one came is sent as that edge's backward condition.
        var merges = Validate.ReverseEdgeMerges(Graph);
        var kept = new List<GraphEdge>();
        for (var i = 0; i < Graph.Edges.Count; i++)
        {
            if (!merges.ContainsKey(i))
            {
                kept.Add(Graph.Edges[i]);
            }
        }
        var ids = AssignEdgeIds(kept);
        var idOf = new Dictionary<GraphEdge, string>();
        for (var k = 0; k < kept.Count; k++)
        {
            idOf[kept[k]] = ids[k];
        }

        var positions = Layout.Run(Graph);
        var outgoing = new Dictionary<string, List<GraphEdge>>();
        var edgesOut = new JsonObject();

        void AddToOrder(string nodeId, GraphEdge edge)
        {
            if (!outgoing.TryGetValue(nodeId, out var list))
            {
                list = new List<GraphEdge>();
                outgoing[nodeId] = list;
            }
            list.Add(edge);
        }

        for (var i = 0; i < Graph.Edges.Count; i++)
        {
            var edge = Graph.Edges[i];
            if (merges.TryGetValue(i, out var into))
            {
                var reverse = Graph.Edges[into];
                AddToOrder(edge.Source, reverse);
                ((JsonObject)edgesOut[idOf[reverse]]!)["backward_condition"] = edge.ForwardCondition!.DeepClone();
                continue;
            }
            AddToOrder(edge.Source, edge);
            // The API lists an edge with a backward condition among its target's outgoing edges as well.
            if (edge.BackwardCondition != null)
            {
                AddToOrder(edge.Target, edge);
            }
            var wire = new JsonObject();
            foreach (var extra in edge.Extra)
            {
                wire[extra.Key] = extra.Value?.DeepClone();
            }
            wire["source"] = edge.Source;
            wire["target"] = edge.Target;
            if (edge.ForwardCondition != null)
            {
                wire["forward_condition"] = edge.ForwardCondition.DeepClone();
            }
            if (edge.BackwardCondition != null)
            {
                wire["backward_condition"] = edge.BackwardCondition.DeepClone();
            }
            edgesOut[idOf[edge]] = wire;
        }

        var nodesOut = new JsonObject();
        foreach (var id in Graph.NodeOrder)
        {
            var model = Graph.GetNode(id);
            var outNode = new JsonObject();
            foreach (var field in model)
            {
                outNode[field.Key] = field.Value?.DeepClone();
            }
            outNode["position"] = positions[id].DeepClone();
            var loaded = Graph.LoadedOrder.TryGetValue(id, out var lo) ? lo : new List<GraphEdge>();
            var current = outgoing.TryGetValue(id, out var cur) ? cur : new List<GraphEdge>();
            var orderArr = new JsonArray();
            foreach (var edge in EdgeOrder(loaded, current))
            {
                orderArr.Add(idOf[edge]);
            }
            outNode["edge_order"] = orderArr;
            nodesOut[id] = outNode;
        }

        var workflow = new JsonObject { ["nodes"] = nodesOut, ["edges"] = edgesOut };
        if (Graph.PreventSubagentLoops != null)
        {
            workflow["prevent_subagent_loops"] = Graph.PreventSubagentLoops.Value;
        }
        return workflow;
    }

    /// <summary>A loaded node's order for the edges it still has, then any others in edge-list order.</summary>
    private static List<GraphEdge> EdgeOrder(List<GraphEdge> loaded, List<GraphEdge> current)
    {
        var kept = loaded.Where(current.Contains).ToList();
        var result = new List<GraphEdge>(kept);
        result.AddRange(current.Where(edge => !kept.Contains(edge)));
        return result;
    }

    /// <summary>Loaded edges keep their ids. New ones get <c>source__target</c>, with <c>__2</c>, <c>__3</c>... on collision.</summary>
    private static List<string> AssignEdgeIds(List<GraphEdge> edges)
    {
        var taken = new HashSet<string>(edges.Where(edge => edge.Id != null).Select(edge => edge.Id!));
        var ids = new List<string>();
        foreach (var edge in edges)
        {
            if (edge.Id != null)
            {
                ids.Add(edge.Id);
                continue;
            }
            var baseId = $"{edge.Source}__{edge.Target}";
            var id = baseId;
            var n = 2;
            while (taken.Contains(id))
            {
                id = $"{baseId}__{n}";
                n++;
            }
            taken.Add(id);
            ids.Add(id);
        }
        return ids;
    }
}
