using System.Collections.Generic;
using System.Linq;

namespace ElevenLabs.AgentWorkflows;

/// <summary>Breadth-first depths from the start node, keeping visiting order.</summary>
internal sealed class Depths
{
    public List<string> Order { get; } = new();
    public Dictionary<string, int> Map { get; } = new();

    public void Set(string id, int depth)
    {
        if (!Map.ContainsKey(id))
        {
            Order.Add(id);
        }
        Map[id] = depth;
    }

    public bool Has(string id) => Map.ContainsKey(id);
}

internal static class Validate
{
    /// <summary>Checks that need the finished graph. Problems found while chaining are already in <c>graph.Issues</c>.</summary>
    public static List<WorkflowIssue> Run(WorkflowGraph graph)
    {
        var issues = new List<WorkflowIssue>(graph.Issues);
        var endsWithEdges = new HashSet<string>();

        void Error(string code, string message, string? nodeId) =>
            issues.Add(new WorkflowIssue(code, WorkflowSeverity.Error, message, nodeId));

        var merged = ReverseEdgeMerges(graph);
        var connected = new HashSet<string>();
        for (var i = 0; i < graph.Edges.Count; i++)
        {
            if (merged.ContainsKey(i))
            {
                continue;
            }
            var edge = graph.Edges[i];
            // The API allows one edge per pair of nodes, in either direction.
            var pair = string.Join(
                "\u0000",
                new[] { edge.Source, edge.Target }.OrderBy(s => s, System.StringComparer.Ordinal)
            );
            if (connected.Contains(pair))
            {
                Error(
                    "duplicate_edge",
                    $"Edge \"{edge.Source}\" → \"{edge.Target}\" connects two nodes that already have an edge between them, "
                        + "and the API allows only one. Give the existing edge a different condition, or remove one",
                    edge.Source
                );
            }
            connected.Add(pair);
        }

        foreach (var edge in graph.Edges)
        {
            var name = $"\"{edge.Source}\" → \"{edge.Target}\"";
            if (edge.Source == edge.Target)
            {
                Error("self_loop", $"Edge {name} connects a node to itself, which the API doesn't allow", edge.Source);
            }
            foreach (var id in new[] { edge.Source, edge.Target })
            {
                if (!graph.ContainsNode(id))
                {
                    Error("unknown_node", $"Edge {name} refers to unknown node \"{id}\"", id);
                }
            }
            if (edge.Target == graph.StartId)
            {
                Error(
                    "edge_into_start",
                    $"Edge {name} points into the start node; go to the first node after it instead",
                    edge.Source
                );
            }

            var sourceType = graph.ContainsNode(edge.Source)
                ? (graph.GetNode(edge.Source)["type"] as System.Text.Json.Nodes.JsonValue)?.GetValue<string>()
                : null;
            var conditionType = (edge.ForwardCondition?["type"] as System.Text.Json.Nodes.JsonValue)?.GetValue<string>();
            if (sourceType == "end" && !endsWithEdges.Contains(edge.Source))
            {
                endsWithEdges.Add(edge.Source);
                Error("end_has_outgoing_edges", $"End node \"{edge.Source}\" can't have outgoing edges", edge.Source);
            }
            if (sourceType == "tool" && conditionType != "result")
            {
                Error(
                    "tool_edge_needs_result",
                    $"Edge {name} leaves a tool node, so it must use OnSuccess() or OnFailure()",
                    edge.Source
                );
            }
            if (sourceType != null && sourceType != "tool" && conditionType == "result")
            {
                Error(
                    "result_edge_needs_tool",
                    $"Edge {name} uses OnSuccess()/OnFailure(), which only applies to tool nodes",
                    edge.Source
                );
            }
        }

        foreach (var id in graph.NodeOrder)
        {
            var type = (graph.GetNode(id)["type"] as System.Text.Json.Nodes.JsonValue)?.GetValue<string>();
            if (!NodeTypes.ModelKnows(type))
            {
                issues.Add(
                    new WorkflowIssue(
                        "unknown_node_type",
                        WorkflowSeverity.Warning,
                        $"Node \"{id}\" has type \"{type}\", which this SDK version doesn't model. Build() keeps it as given "
                            + "but can't type it, and agents.Create()/agents.Update() would reject it. Upgrade the SDK, or "
                            + "send ToJson() through the request's additional body parameters.",
                        id
                    )
                );
            }
        }

        var reachable = DepthsFrom(graph);
        foreach (var id in graph.NodeOrder)
        {
            if (!reachable.Has(id))
            {
                issues.Add(
                    new WorkflowIssue(
                        "unreachable_node",
                        WorkflowSeverity.Warning,
                        $"Node \"{id}\" can't be reached from the start node",
                        id
                    )
                );
            }
        }
        return issues;
    }

    /// <summary>
    /// Edges the API stores as the backward condition of another edge: index of the later edge -> index of the
    /// earlier one. The later edge goes the opposite way between the same two nodes, and neither has a backward
    /// condition of its own.
    /// </summary>
    public static Dictionary<int, int> ReverseEdgeMerges(WorkflowGraph graph)
    {
        var merges = new Dictionary<int, int>();
        var taken = new HashSet<int>();
        for (var j = 0; j < graph.Edges.Count; j++)
        {
            var later = graph.Edges[j];
            if (later.Source == later.Target || later.BackwardCondition != null || later.ForwardCondition == null)
            {
                continue;
            }
            var found = -1;
            for (var k = 0; k < j; k++)
            {
                var earlier = graph.Edges[k];
                if (
                    !taken.Contains(k)
                    && !merges.ContainsKey(k)
                    && earlier.Source == later.Target
                    && earlier.Target == later.Source
                    && earlier.BackwardCondition == null
                )
                {
                    found = k;
                    break;
                }
            }
            if (found != -1)
            {
                merges[j] = found;
                taken.Add(found);
            }
        }
        return merges;
    }

    /// <summary>
    /// Breadth-first depth of every node reachable from the start node, in visiting order. Edges are followed
    /// forward first; only when that runs out does a backward condition lead on, from an edge's target to a source
    /// not yet visited.
    /// </summary>
    public static Depths DepthsFrom(WorkflowGraph graph)
    {
        var depths = new Depths();

        void Visit(string id, int depth)
        {
            depths.Set(id, depth);
            var queue = new Queue<string>();
            queue.Enqueue(id);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                foreach (var edge in graph.Edges)
                {
                    if (edge.Source == current && !depths.Has(edge.Target) && graph.ContainsNode(edge.Target))
                    {
                        depths.Set(edge.Target, depths.Map[current] + 1);
                        queue.Enqueue(edge.Target);
                    }
                }
            }
        }

        Visit(graph.StartId, 0);
        while (true)
        {
            GraphEdge? back = null;
            foreach (var edge in graph.Edges)
            {
                if (
                    edge.BackwardCondition != null
                    && depths.Has(edge.Target)
                    && !depths.Has(edge.Source)
                    && graph.ContainsNode(edge.Source)
                )
                {
                    back = edge;
                    break;
                }
            }
            if (back == null)
            {
                return depths;
            }
            Visit(back.Source, depths.Map[back.Target] + 1);
        }
    }
}
