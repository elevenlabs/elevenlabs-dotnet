using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Nodes;
using ElevenLabs.Core;

namespace ElevenLabs.AgentWorkflows;

/// <summary>
/// A workflow expression, compiled to the API's expression AST. Built with the static constructors and the
/// instance operators; kept in wire format.
/// </summary>
/// <example>
/// <code>
/// Expr.AnyOf(Expr.Variable("tier").Eq("gold"), Expr.Variable("orders").Gte(10));
/// </code>
/// </example>
public sealed class Expr
{
    private readonly JsonObject _node;

    private Expr(JsonObject node) => _node = node;

    /// <summary>The value of a dynamic variable.</summary>
    public static Expr Variable(string name) => new(new JsonObject { ["type"] = "dynamic_variable", ["name"] = name });

    /// <summary>A string literal.</summary>
    public static Expr Literal(string value) => new(new JsonObject { ["type"] = "string_literal", ["value"] = value });

    /// <summary>A boolean literal.</summary>
    public static Expr Literal(bool value) => new(new JsonObject { ["type"] = "boolean_literal", ["value"] = value });

    /// <summary>An integer literal.</summary>
    public static Expr Literal(long value) => new(new JsonObject { ["type"] = "number_literal", ["value"] = value });

    /// <summary>A number literal.</summary>
    public static Expr Literal(double value) => new(new JsonObject { ["type"] = "number_literal", ["value"] = value });

    /// <summary>A null literal.</summary>
    public static Expr LiteralNull() => new(new JsonObject { ["type"] = "null_literal" });

    /// <summary>
    /// A value the LLM extracts from the conversation, described by <paramref name="description"/>. <paramref name="type"/>
    /// defaults to <c>"boolean"</c>; <paramref name="enumValues"/> lists the allowed values of a <c>"string"</c>.
    /// </summary>
    public static Expr Llm(string description, string type = "boolean", IEnumerable<string>? enumValues = null)
    {
        var schema = new JsonObject { ["type"] = type, ["description"] = description };
        if (enumValues != null)
        {
            var arr = new JsonArray();
            foreach (var value in enumValues)
            {
                arr.Add(value);
            }
            schema["enum"] = arr;
        }
        return new Expr(new JsonObject { ["type"] = "llm", ["value_schema"] = schema });
    }

    /// <summary>True when every expression is true.</summary>
    public static Expr AllOf(params Expr[] exprs) =>
        new(new JsonObject { ["type"] = "and_operator", ["children"] = Children(exprs) });

    /// <summary>True when at least one expression is true.</summary>
    public static Expr AnyOf(params Expr[] exprs) =>
        new(new JsonObject { ["type"] = "or_operator", ["children"] = Children(exprs) });

    /// <summary><paramref name="whenTrue"/> if <paramref name="condition"/> is true, otherwise <paramref name="whenFalse"/>.</summary>
    public static Expr IfElse(Expr condition, Expr whenTrue, Expr whenFalse) =>
        new(
            new JsonObject
            {
                ["type"] = "conditional_operator",
                ["condition"] = condition.ToWire(),
                // The API's AST uses these camelCase keys; carried through verbatim.
                ["trueExpression"] = whenTrue.ToWire(),
                ["falseExpression"] = whenFalse.ToWire(),
            }
        );

    /// <summary>Wraps an existing AST node, given as a generated model or a wire-format <see cref="JsonNode"/>.</summary>
    public static Expr FromModel(JsonNode node) => new((JsonObject)node.DeepClone());

    /// <summary>Wraps an existing generated <c>AstNodeInput</c> model.</summary>
    public static Expr FromModel(AstNodeInput node) =>
        new((JsonObject)JsonUtils.SerializeToNode(node)!);

    public Expr Eq(Expr other) => Binary("eq_operator", other);

    public Expr Eq(string other) => Binary("eq_operator", Literal(other));

    public Expr Eq(long other) => Binary("eq_operator", Literal(other));

    public Expr Eq(double other) => Binary("eq_operator", Literal(other));

    public Expr Eq(bool other) => Binary("eq_operator", Literal(other));

    public Expr Neq(Expr other) => Binary("neq_operator", other);

    public Expr Neq(string other) => Binary("neq_operator", Literal(other));

    public Expr Neq(long other) => Binary("neq_operator", Literal(other));

    public Expr Neq(double other) => Binary("neq_operator", Literal(other));

    public Expr Neq(bool other) => Binary("neq_operator", Literal(other));

    public Expr Gt(Expr other) => Binary("gt_operator", other);

    public Expr Gt(double other) => Binary("gt_operator", Literal(other));

    public Expr Gte(Expr other) => Binary("gte_operator", other);

    public Expr Gte(double other) => Binary("gte_operator", Literal(other));

    public Expr Lt(Expr other) => Binary("lt_operator", other);

    public Expr Lt(double other) => Binary("lt_operator", Literal(other));

    public Expr Lte(Expr other) => Binary("lte_operator", other);

    public Expr Lte(double other) => Binary("lte_operator", Literal(other));

    public Expr Add(Expr other) => Binary("add_operator", other);

    public Expr Add(double other) => Binary("add_operator", Literal(other));

    public Expr Sub(Expr other) => Binary("sub_operator", other);

    public Expr Sub(double other) => Binary("sub_operator", Literal(other));

    public Expr Mul(Expr other) => Binary("mul_operator", other);

    public Expr Mul(double other) => Binary("mul_operator", Literal(other));

    public Expr Div(Expr other) => Binary("div_operator", other);

    public Expr Div(double other) => Binary("div_operator", Literal(other));

    /// <summary>The expression in API wire format.</summary>
    internal JsonObject ToWire() => (JsonObject)_node.DeepClone();

    private Expr Binary(string type, Expr other) =>
        new(new JsonObject { ["type"] = type, ["left"] = ToWire(), ["right"] = other.ToWire() });

    private static JsonArray Children(IEnumerable<Expr> exprs)
    {
        var arr = new JsonArray();
        foreach (var expr in exprs)
        {
            arr.Add(expr.ToWire());
        }
        return arr;
    }
}
