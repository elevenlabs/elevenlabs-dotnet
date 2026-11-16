using System.Text.Json.Nodes;

namespace ElevenLabs.AgentWorkflows;

/// <summary>
/// When an edge may be followed. A plain string passed to <c>When()</c> is shorthand for <see cref="Llm"/>, and an
/// <see cref="Expr"/> is shorthand for <see cref="Expr(Expr, string)"/>. <c>label</c> is shown on the edge in the
/// workflow editor.
/// </summary>
public sealed class Condition
{
    private readonly JsonObject _model;

    private Condition(JsonObject model) => _model = model;

    /// <summary>Followed when the LLM judges <paramref name="condition"/> to be true.</summary>
    public static Condition Llm(string condition, string? label = null) =>
        new(Labelled(new JsonObject { ["type"] = "llm", ["condition"] = condition }, label));

    /// <summary>Followed when <paramref name="expression"/> evaluates to true.</summary>
    public static Condition Expr(Expr expression, string? label = null) =>
        new(Labelled(new JsonObject { ["type"] = "expression", ["expression"] = expression.ToWire() }, label));

    /// <summary>Always followed.</summary>
    public static Condition Always(string? label = null) =>
        new(Labelled(new JsonObject { ["type"] = "unconditional" }, label));

    /// <summary>Followed when every tool in a tool node succeeded.</summary>
    public static Condition Success(string? label = null) =>
        new(Labelled(new JsonObject { ["type"] = "result", ["successful"] = true }, label));

    /// <summary>Followed when any tool in a tool node failed.</summary>
    public static Condition Failure(string? label = null) =>
        new(Labelled(new JsonObject { ["type"] = "result", ["successful"] = false }, label));

    /// <summary>The condition in API wire format.</summary>
    internal JsonObject ToWire() => (JsonObject)_model.DeepClone();

    private static JsonObject Labelled(JsonObject model, string? label)
    {
        if (label != null)
        {
            model["label"] = label;
        }
        return model;
    }
}
