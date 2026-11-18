using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Nodes;

namespace ElevenLabs.AgentWorkflows;

/// <summary>
/// Positions for the workflow editor. Nodes that already have a position keep it. The rest go in
/// column = breadth-first depth from the start node, row = order of discovery within that column, skipping rows
/// where a positioned node already sits. Unreachable nodes go in the column after the deepest one.
/// </summary>
internal static class Layout
{
    public const int ColumnWidth = 300;
    public const int RowHeight = 200;

    public static Dictionary<string, JsonObject> Run(WorkflowGraph graph)
    {
        var depths = Validate.DepthsFrom(graph);
        var lastColumn = (depths.Map.Count == 0 ? 0 : depths.Map.Values.Max()) + 1;

        var order = new List<string>(depths.Order);
        order.AddRange(graph.NodeOrder.Where(id => !depths.Has(id)));

        var rows = new Dictionary<int, int>();
        var positions = new Dictionary<string, JsonObject>();
        var occupied = new HashSet<(double X, double Y)>();
        foreach (var id in graph.NodeOrder)
        {
            if (graph.GetNode(id)["position"] is JsonObject pos)
            {
                occupied.Add((Wire.AsDouble(pos["x"]!), Wire.AsDouble(pos["y"]!)));
            }
        }

        foreach (var id in order)
        {
            if (graph.GetNode(id)["position"] is JsonObject existing)
            {
                positions[id] = existing;
                continue;
            }
            var column = depths.Has(id) ? depths.Map[id] : lastColumn;
            var row = rows.TryGetValue(column, out var r) ? r : 0;
            while (occupied.Contains(((double)(column * ColumnWidth), (double)(row * RowHeight))))
            {
                row++;
            }
            rows[column] = row + 1;
            occupied.Add(((double)(column * ColumnWidth), (double)(row * RowHeight)));
            positions[id] = new JsonObject { ["x"] = column * ColumnWidth, ["y"] = row * RowHeight };
        }
        return positions;
    }
}
