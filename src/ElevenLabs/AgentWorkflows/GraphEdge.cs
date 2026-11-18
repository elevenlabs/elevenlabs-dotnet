using System.Text.Json.Nodes;

namespace ElevenLabs.AgentWorkflows;

/// <summary>
/// An edge in the workflow graph. Compared by reference identity: two edges with the same fields are still two
/// different edges, so a plain class (not a record) is used deliberately.
/// </summary>
internal sealed class GraphEdge
{
    public GraphEdge(string source, string target)
    {
        Source = source;
        Target = target;
    }

    public string Source { get; set; }
    public string Target { get; set; }
    public JsonObject? ForwardCondition { get; set; }
    public JsonObject? BackwardCondition { get; set; }

    /// <summary>Set for edges loaded from an existing workflow; generated at build time otherwise.</summary>
    public string? Id { get; set; }

    /// <summary>Other fields of a loaded edge, such as <c>reroutes</c> (editor bend points), written back as they were.</summary>
    public JsonObject Extra { get; set; } = new();
}

/// <summary>Where the next edge starts and which conditions it carries.</summary>
internal sealed class EdgeOrigin
{
    public EdgeOrigin(string source, JsonObject forwardCondition, JsonObject? backwardCondition = null)
    {
        Source = source;
        ForwardCondition = forwardCondition;
        BackwardCondition = backwardCondition;
    }

    public string Source { get; }
    public JsonObject ForwardCondition { get; }
    public JsonObject? BackwardCondition { get; }
}
