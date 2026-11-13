// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AstNodeOutput.JsonConverter))]
[Serializable]
public record AstNodeOutput
{
    internal AstNodeOutput(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of AstNodeOutput with <see cref="AstNodeOutput.AddOperator"/>.
    /// </summary>
    public AstNodeOutput(AstNodeOutput.AddOperator value)
    {
        Type = "add_operator";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AstNodeOutput with <see cref="AstNodeOutput.AndOperator"/>.
    /// </summary>
    public AstNodeOutput(AstNodeOutput.AndOperator value)
    {
        Type = "and_operator";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AstNodeOutput with <see cref="AstNodeOutput.BooleanLiteral"/>.
    /// </summary>
    public AstNodeOutput(AstNodeOutput.BooleanLiteral value)
    {
        Type = "boolean_literal";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AstNodeOutput with <see cref="AstNodeOutput.ConditionalOperator"/>.
    /// </summary>
    public AstNodeOutput(AstNodeOutput.ConditionalOperator value)
    {
        Type = "conditional_operator";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AstNodeOutput with <see cref="AstNodeOutput.DivOperator"/>.
    /// </summary>
    public AstNodeOutput(AstNodeOutput.DivOperator value)
    {
        Type = "div_operator";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AstNodeOutput with <see cref="AstNodeOutput.DynamicVariable"/>.
    /// </summary>
    public AstNodeOutput(AstNodeOutput.DynamicVariable value)
    {
        Type = "dynamic_variable";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AstNodeOutput with <see cref="AstNodeOutput.EqOperator"/>.
    /// </summary>
    public AstNodeOutput(AstNodeOutput.EqOperator value)
    {
        Type = "eq_operator";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AstNodeOutput with <see cref="AstNodeOutput.GtOperator"/>.
    /// </summary>
    public AstNodeOutput(AstNodeOutput.GtOperator value)
    {
        Type = "gt_operator";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AstNodeOutput with <see cref="AstNodeOutput.GteOperator"/>.
    /// </summary>
    public AstNodeOutput(AstNodeOutput.GteOperator value)
    {
        Type = "gte_operator";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AstNodeOutput with <see cref="AstNodeOutput.Llm"/>.
    /// </summary>
    public AstNodeOutput(AstNodeOutput.Llm value)
    {
        Type = "llm";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AstNodeOutput with <see cref="AstNodeOutput.LtOperator"/>.
    /// </summary>
    public AstNodeOutput(AstNodeOutput.LtOperator value)
    {
        Type = "lt_operator";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AstNodeOutput with <see cref="AstNodeOutput.LteOperator"/>.
    /// </summary>
    public AstNodeOutput(AstNodeOutput.LteOperator value)
    {
        Type = "lte_operator";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AstNodeOutput with <see cref="AstNodeOutput.MulOperator"/>.
    /// </summary>
    public AstNodeOutput(AstNodeOutput.MulOperator value)
    {
        Type = "mul_operator";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AstNodeOutput with <see cref="AstNodeOutput.NeqOperator"/>.
    /// </summary>
    public AstNodeOutput(AstNodeOutput.NeqOperator value)
    {
        Type = "neq_operator";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AstNodeOutput with <see cref="AstNodeOutput.NullLiteral"/>.
    /// </summary>
    public AstNodeOutput(AstNodeOutput.NullLiteral value)
    {
        Type = "null_literal";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AstNodeOutput with <see cref="AstNodeOutput.NumberLiteral"/>.
    /// </summary>
    public AstNodeOutput(AstNodeOutput.NumberLiteral value)
    {
        Type = "number_literal";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AstNodeOutput with <see cref="AstNodeOutput.OrOperator"/>.
    /// </summary>
    public AstNodeOutput(AstNodeOutput.OrOperator value)
    {
        Type = "or_operator";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AstNodeOutput with <see cref="AstNodeOutput.StringLiteral"/>.
    /// </summary>
    public AstNodeOutput(AstNodeOutput.StringLiteral value)
    {
        Type = "string_literal";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AstNodeOutput with <see cref="AstNodeOutput.SubOperator"/>.
    /// </summary>
    public AstNodeOutput(AstNodeOutput.SubOperator value)
    {
        Type = "sub_operator";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="Type"/> is "add_operator"
    /// </summary>
    public bool IsAddOperator => Type == "add_operator";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "and_operator"
    /// </summary>
    public bool IsAndOperator => Type == "and_operator";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "boolean_literal"
    /// </summary>
    public bool IsBooleanLiteral => Type == "boolean_literal";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "conditional_operator"
    /// </summary>
    public bool IsConditionalOperator => Type == "conditional_operator";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "div_operator"
    /// </summary>
    public bool IsDivOperator => Type == "div_operator";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "dynamic_variable"
    /// </summary>
    public bool IsDynamicVariable => Type == "dynamic_variable";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eq_operator"
    /// </summary>
    public bool IsEqOperator => Type == "eq_operator";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "gt_operator"
    /// </summary>
    public bool IsGtOperator => Type == "gt_operator";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "gte_operator"
    /// </summary>
    public bool IsGteOperator => Type == "gte_operator";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "llm"
    /// </summary>
    public bool IsLlm => Type == "llm";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "lt_operator"
    /// </summary>
    public bool IsLtOperator => Type == "lt_operator";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "lte_operator"
    /// </summary>
    public bool IsLteOperator => Type == "lte_operator";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "mul_operator"
    /// </summary>
    public bool IsMulOperator => Type == "mul_operator";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "neq_operator"
    /// </summary>
    public bool IsNeqOperator => Type == "neq_operator";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "null_literal"
    /// </summary>
    public bool IsNullLiteral => Type == "null_literal";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "number_literal"
    /// </summary>
    public bool IsNumberLiteral => Type == "number_literal";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "or_operator"
    /// </summary>
    public bool IsOrOperator => Type == "or_operator";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "string_literal"
    /// </summary>
    public bool IsStringLiteral => Type == "string_literal";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "sub_operator"
    /// </summary>
    public bool IsSubOperator => Type == "sub_operator";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AstAdditionOperatorNodeOutput"/> if <see cref="Type"/> is 'add_operator', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'add_operator'.</exception>
    public global::ElevenLabs.AstAdditionOperatorNodeOutput AsAddOperator() =>
        IsAddOperator
            ? (global::ElevenLabs.AstAdditionOperatorNodeOutput)Value!
            : throw new global::System.Exception("AstNodeOutput.Type is not 'add_operator'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AstAndOperatorNodeOutput"/> if <see cref="Type"/> is 'and_operator', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'and_operator'.</exception>
    public global::ElevenLabs.AstAndOperatorNodeOutput AsAndOperator() =>
        IsAndOperator
            ? (global::ElevenLabs.AstAndOperatorNodeOutput)Value!
            : throw new global::System.Exception("AstNodeOutput.Type is not 'and_operator'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AstBooleanNodeOutput"/> if <see cref="Type"/> is 'boolean_literal', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'boolean_literal'.</exception>
    public global::ElevenLabs.AstBooleanNodeOutput AsBooleanLiteral() =>
        IsBooleanLiteral
            ? (global::ElevenLabs.AstBooleanNodeOutput)Value!
            : throw new global::System.Exception("AstNodeOutput.Type is not 'boolean_literal'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AstConditionalOperatorNodeOutput"/> if <see cref="Type"/> is 'conditional_operator', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'conditional_operator'.</exception>
    public global::ElevenLabs.AstConditionalOperatorNodeOutput AsConditionalOperator() =>
        IsConditionalOperator
            ? (global::ElevenLabs.AstConditionalOperatorNodeOutput)Value!
            : throw new global::System.Exception(
                "AstNodeOutput.Type is not 'conditional_operator'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AstDivisionOperatorNodeOutput"/> if <see cref="Type"/> is 'div_operator', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'div_operator'.</exception>
    public global::ElevenLabs.AstDivisionOperatorNodeOutput AsDivOperator() =>
        IsDivOperator
            ? (global::ElevenLabs.AstDivisionOperatorNodeOutput)Value!
            : throw new global::System.Exception("AstNodeOutput.Type is not 'div_operator'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AstDynamicVariableNodeOutput"/> if <see cref="Type"/> is 'dynamic_variable', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'dynamic_variable'.</exception>
    public global::ElevenLabs.AstDynamicVariableNodeOutput AsDynamicVariable() =>
        IsDynamicVariable
            ? (global::ElevenLabs.AstDynamicVariableNodeOutput)Value!
            : throw new global::System.Exception("AstNodeOutput.Type is not 'dynamic_variable'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AstEqualsOperatorNodeOutput"/> if <see cref="Type"/> is 'eq_operator', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'eq_operator'.</exception>
    public global::ElevenLabs.AstEqualsOperatorNodeOutput AsEqOperator() =>
        IsEqOperator
            ? (global::ElevenLabs.AstEqualsOperatorNodeOutput)Value!
            : throw new global::System.Exception("AstNodeOutput.Type is not 'eq_operator'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AstGreaterThanOperatorNodeOutput"/> if <see cref="Type"/> is 'gt_operator', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'gt_operator'.</exception>
    public global::ElevenLabs.AstGreaterThanOperatorNodeOutput AsGtOperator() =>
        IsGtOperator
            ? (global::ElevenLabs.AstGreaterThanOperatorNodeOutput)Value!
            : throw new global::System.Exception("AstNodeOutput.Type is not 'gt_operator'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AstGreaterThanOrEqualsOperatorNodeOutput"/> if <see cref="Type"/> is 'gte_operator', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'gte_operator'.</exception>
    public global::ElevenLabs.AstGreaterThanOrEqualsOperatorNodeOutput AsGteOperator() =>
        IsGteOperator
            ? (global::ElevenLabs.AstGreaterThanOrEqualsOperatorNodeOutput)Value!
            : throw new global::System.Exception("AstNodeOutput.Type is not 'gte_operator'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AstllmNodeOutput"/> if <see cref="Type"/> is 'llm', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'llm'.</exception>
    public global::ElevenLabs.AstllmNodeOutput AsLlm() =>
        IsLlm
            ? (global::ElevenLabs.AstllmNodeOutput)Value!
            : throw new global::System.Exception("AstNodeOutput.Type is not 'llm'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AstLessThanOperatorNodeOutput"/> if <see cref="Type"/> is 'lt_operator', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'lt_operator'.</exception>
    public global::ElevenLabs.AstLessThanOperatorNodeOutput AsLtOperator() =>
        IsLtOperator
            ? (global::ElevenLabs.AstLessThanOperatorNodeOutput)Value!
            : throw new global::System.Exception("AstNodeOutput.Type is not 'lt_operator'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AstLessThanOrEqualsOperatorNodeOutput"/> if <see cref="Type"/> is 'lte_operator', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'lte_operator'.</exception>
    public global::ElevenLabs.AstLessThanOrEqualsOperatorNodeOutput AsLteOperator() =>
        IsLteOperator
            ? (global::ElevenLabs.AstLessThanOrEqualsOperatorNodeOutput)Value!
            : throw new global::System.Exception("AstNodeOutput.Type is not 'lte_operator'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AstMultiplicationOperatorNodeOutput"/> if <see cref="Type"/> is 'mul_operator', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'mul_operator'.</exception>
    public global::ElevenLabs.AstMultiplicationOperatorNodeOutput AsMulOperator() =>
        IsMulOperator
            ? (global::ElevenLabs.AstMultiplicationOperatorNodeOutput)Value!
            : throw new global::System.Exception("AstNodeOutput.Type is not 'mul_operator'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AstNotEqualsOperatorNodeOutput"/> if <see cref="Type"/> is 'neq_operator', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'neq_operator'.</exception>
    public global::ElevenLabs.AstNotEqualsOperatorNodeOutput AsNeqOperator() =>
        IsNeqOperator
            ? (global::ElevenLabs.AstNotEqualsOperatorNodeOutput)Value!
            : throw new global::System.Exception("AstNodeOutput.Type is not 'neq_operator'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AstNullNodeOutput"/> if <see cref="Type"/> is 'null_literal', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'null_literal'.</exception>
    public global::ElevenLabs.AstNullNodeOutput AsNullLiteral() =>
        IsNullLiteral
            ? (global::ElevenLabs.AstNullNodeOutput)Value!
            : throw new global::System.Exception("AstNodeOutput.Type is not 'null_literal'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AstNumberNodeOutput"/> if <see cref="Type"/> is 'number_literal', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'number_literal'.</exception>
    public global::ElevenLabs.AstNumberNodeOutput AsNumberLiteral() =>
        IsNumberLiteral
            ? (global::ElevenLabs.AstNumberNodeOutput)Value!
            : throw new global::System.Exception("AstNodeOutput.Type is not 'number_literal'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AstOrOperatorNodeOutput"/> if <see cref="Type"/> is 'or_operator', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'or_operator'.</exception>
    public global::ElevenLabs.AstOrOperatorNodeOutput AsOrOperator() =>
        IsOrOperator
            ? (global::ElevenLabs.AstOrOperatorNodeOutput)Value!
            : throw new global::System.Exception("AstNodeOutput.Type is not 'or_operator'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AstStringNodeOutput"/> if <see cref="Type"/> is 'string_literal', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'string_literal'.</exception>
    public global::ElevenLabs.AstStringNodeOutput AsStringLiteral() =>
        IsStringLiteral
            ? (global::ElevenLabs.AstStringNodeOutput)Value!
            : throw new global::System.Exception("AstNodeOutput.Type is not 'string_literal'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AstSubtractionOperatorNodeOutput"/> if <see cref="Type"/> is 'sub_operator', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'sub_operator'.</exception>
    public global::ElevenLabs.AstSubtractionOperatorNodeOutput AsSubOperator() =>
        IsSubOperator
            ? (global::ElevenLabs.AstSubtractionOperatorNodeOutput)Value!
            : throw new global::System.Exception("AstNodeOutput.Type is not 'sub_operator'");

    public T Match<T>(
        Func<global::ElevenLabs.AstAdditionOperatorNodeOutput, T> onAddOperator,
        Func<global::ElevenLabs.AstAndOperatorNodeOutput, T> onAndOperator,
        Func<global::ElevenLabs.AstBooleanNodeOutput, T> onBooleanLiteral,
        Func<global::ElevenLabs.AstConditionalOperatorNodeOutput, T> onConditionalOperator,
        Func<global::ElevenLabs.AstDivisionOperatorNodeOutput, T> onDivOperator,
        Func<global::ElevenLabs.AstDynamicVariableNodeOutput, T> onDynamicVariable,
        Func<global::ElevenLabs.AstEqualsOperatorNodeOutput, T> onEqOperator,
        Func<global::ElevenLabs.AstGreaterThanOperatorNodeOutput, T> onGtOperator,
        Func<global::ElevenLabs.AstGreaterThanOrEqualsOperatorNodeOutput, T> onGteOperator,
        Func<global::ElevenLabs.AstllmNodeOutput, T> onLlm,
        Func<global::ElevenLabs.AstLessThanOperatorNodeOutput, T> onLtOperator,
        Func<global::ElevenLabs.AstLessThanOrEqualsOperatorNodeOutput, T> onLteOperator,
        Func<global::ElevenLabs.AstMultiplicationOperatorNodeOutput, T> onMulOperator,
        Func<global::ElevenLabs.AstNotEqualsOperatorNodeOutput, T> onNeqOperator,
        Func<global::ElevenLabs.AstNullNodeOutput, T> onNullLiteral,
        Func<global::ElevenLabs.AstNumberNodeOutput, T> onNumberLiteral,
        Func<global::ElevenLabs.AstOrOperatorNodeOutput, T> onOrOperator,
        Func<global::ElevenLabs.AstStringNodeOutput, T> onStringLiteral,
        Func<global::ElevenLabs.AstSubtractionOperatorNodeOutput, T> onSubOperator,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "add_operator" => onAddOperator(AsAddOperator()),
            "and_operator" => onAndOperator(AsAndOperator()),
            "boolean_literal" => onBooleanLiteral(AsBooleanLiteral()),
            "conditional_operator" => onConditionalOperator(AsConditionalOperator()),
            "div_operator" => onDivOperator(AsDivOperator()),
            "dynamic_variable" => onDynamicVariable(AsDynamicVariable()),
            "eq_operator" => onEqOperator(AsEqOperator()),
            "gt_operator" => onGtOperator(AsGtOperator()),
            "gte_operator" => onGteOperator(AsGteOperator()),
            "llm" => onLlm(AsLlm()),
            "lt_operator" => onLtOperator(AsLtOperator()),
            "lte_operator" => onLteOperator(AsLteOperator()),
            "mul_operator" => onMulOperator(AsMulOperator()),
            "neq_operator" => onNeqOperator(AsNeqOperator()),
            "null_literal" => onNullLiteral(AsNullLiteral()),
            "number_literal" => onNumberLiteral(AsNumberLiteral()),
            "or_operator" => onOrOperator(AsOrOperator()),
            "string_literal" => onStringLiteral(AsStringLiteral()),
            "sub_operator" => onSubOperator(AsSubOperator()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.AstAdditionOperatorNodeOutput> onAddOperator,
        Action<global::ElevenLabs.AstAndOperatorNodeOutput> onAndOperator,
        Action<global::ElevenLabs.AstBooleanNodeOutput> onBooleanLiteral,
        Action<global::ElevenLabs.AstConditionalOperatorNodeOutput> onConditionalOperator,
        Action<global::ElevenLabs.AstDivisionOperatorNodeOutput> onDivOperator,
        Action<global::ElevenLabs.AstDynamicVariableNodeOutput> onDynamicVariable,
        Action<global::ElevenLabs.AstEqualsOperatorNodeOutput> onEqOperator,
        Action<global::ElevenLabs.AstGreaterThanOperatorNodeOutput> onGtOperator,
        Action<global::ElevenLabs.AstGreaterThanOrEqualsOperatorNodeOutput> onGteOperator,
        Action<global::ElevenLabs.AstllmNodeOutput> onLlm,
        Action<global::ElevenLabs.AstLessThanOperatorNodeOutput> onLtOperator,
        Action<global::ElevenLabs.AstLessThanOrEqualsOperatorNodeOutput> onLteOperator,
        Action<global::ElevenLabs.AstMultiplicationOperatorNodeOutput> onMulOperator,
        Action<global::ElevenLabs.AstNotEqualsOperatorNodeOutput> onNeqOperator,
        Action<global::ElevenLabs.AstNullNodeOutput> onNullLiteral,
        Action<global::ElevenLabs.AstNumberNodeOutput> onNumberLiteral,
        Action<global::ElevenLabs.AstOrOperatorNodeOutput> onOrOperator,
        Action<global::ElevenLabs.AstStringNodeOutput> onStringLiteral,
        Action<global::ElevenLabs.AstSubtractionOperatorNodeOutput> onSubOperator,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "add_operator":
                onAddOperator(AsAddOperator());
                break;
            case "and_operator":
                onAndOperator(AsAndOperator());
                break;
            case "boolean_literal":
                onBooleanLiteral(AsBooleanLiteral());
                break;
            case "conditional_operator":
                onConditionalOperator(AsConditionalOperator());
                break;
            case "div_operator":
                onDivOperator(AsDivOperator());
                break;
            case "dynamic_variable":
                onDynamicVariable(AsDynamicVariable());
                break;
            case "eq_operator":
                onEqOperator(AsEqOperator());
                break;
            case "gt_operator":
                onGtOperator(AsGtOperator());
                break;
            case "gte_operator":
                onGteOperator(AsGteOperator());
                break;
            case "llm":
                onLlm(AsLlm());
                break;
            case "lt_operator":
                onLtOperator(AsLtOperator());
                break;
            case "lte_operator":
                onLteOperator(AsLteOperator());
                break;
            case "mul_operator":
                onMulOperator(AsMulOperator());
                break;
            case "neq_operator":
                onNeqOperator(AsNeqOperator());
                break;
            case "null_literal":
                onNullLiteral(AsNullLiteral());
                break;
            case "number_literal":
                onNumberLiteral(AsNumberLiteral());
                break;
            case "or_operator":
                onOrOperator(AsOrOperator());
                break;
            case "string_literal":
                onStringLiteral(AsStringLiteral());
                break;
            case "sub_operator":
                onSubOperator(AsSubOperator());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AstAdditionOperatorNodeOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsAddOperator(out global::ElevenLabs.AstAdditionOperatorNodeOutput? value)
    {
        if (Type == "add_operator")
        {
            value = (global::ElevenLabs.AstAdditionOperatorNodeOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AstAndOperatorNodeOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsAndOperator(out global::ElevenLabs.AstAndOperatorNodeOutput? value)
    {
        if (Type == "and_operator")
        {
            value = (global::ElevenLabs.AstAndOperatorNodeOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AstBooleanNodeOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsBooleanLiteral(out global::ElevenLabs.AstBooleanNodeOutput? value)
    {
        if (Type == "boolean_literal")
        {
            value = (global::ElevenLabs.AstBooleanNodeOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AstConditionalOperatorNodeOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsConditionalOperator(
        out global::ElevenLabs.AstConditionalOperatorNodeOutput? value
    )
    {
        if (Type == "conditional_operator")
        {
            value = (global::ElevenLabs.AstConditionalOperatorNodeOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AstDivisionOperatorNodeOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsDivOperator(out global::ElevenLabs.AstDivisionOperatorNodeOutput? value)
    {
        if (Type == "div_operator")
        {
            value = (global::ElevenLabs.AstDivisionOperatorNodeOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AstDynamicVariableNodeOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsDynamicVariable(out global::ElevenLabs.AstDynamicVariableNodeOutput? value)
    {
        if (Type == "dynamic_variable")
        {
            value = (global::ElevenLabs.AstDynamicVariableNodeOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AstEqualsOperatorNodeOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsEqOperator(out global::ElevenLabs.AstEqualsOperatorNodeOutput? value)
    {
        if (Type == "eq_operator")
        {
            value = (global::ElevenLabs.AstEqualsOperatorNodeOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AstGreaterThanOperatorNodeOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsGtOperator(out global::ElevenLabs.AstGreaterThanOperatorNodeOutput? value)
    {
        if (Type == "gt_operator")
        {
            value = (global::ElevenLabs.AstGreaterThanOperatorNodeOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AstGreaterThanOrEqualsOperatorNodeOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsGteOperator(
        out global::ElevenLabs.AstGreaterThanOrEqualsOperatorNodeOutput? value
    )
    {
        if (Type == "gte_operator")
        {
            value = (global::ElevenLabs.AstGreaterThanOrEqualsOperatorNodeOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AstllmNodeOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsLlm(out global::ElevenLabs.AstllmNodeOutput? value)
    {
        if (Type == "llm")
        {
            value = (global::ElevenLabs.AstllmNodeOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AstLessThanOperatorNodeOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsLtOperator(out global::ElevenLabs.AstLessThanOperatorNodeOutput? value)
    {
        if (Type == "lt_operator")
        {
            value = (global::ElevenLabs.AstLessThanOperatorNodeOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AstLessThanOrEqualsOperatorNodeOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsLteOperator(
        out global::ElevenLabs.AstLessThanOrEqualsOperatorNodeOutput? value
    )
    {
        if (Type == "lte_operator")
        {
            value = (global::ElevenLabs.AstLessThanOrEqualsOperatorNodeOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AstMultiplicationOperatorNodeOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsMulOperator(out global::ElevenLabs.AstMultiplicationOperatorNodeOutput? value)
    {
        if (Type == "mul_operator")
        {
            value = (global::ElevenLabs.AstMultiplicationOperatorNodeOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AstNotEqualsOperatorNodeOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsNeqOperator(out global::ElevenLabs.AstNotEqualsOperatorNodeOutput? value)
    {
        if (Type == "neq_operator")
        {
            value = (global::ElevenLabs.AstNotEqualsOperatorNodeOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AstNullNodeOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsNullLiteral(out global::ElevenLabs.AstNullNodeOutput? value)
    {
        if (Type == "null_literal")
        {
            value = (global::ElevenLabs.AstNullNodeOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AstNumberNodeOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsNumberLiteral(out global::ElevenLabs.AstNumberNodeOutput? value)
    {
        if (Type == "number_literal")
        {
            value = (global::ElevenLabs.AstNumberNodeOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AstOrOperatorNodeOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsOrOperator(out global::ElevenLabs.AstOrOperatorNodeOutput? value)
    {
        if (Type == "or_operator")
        {
            value = (global::ElevenLabs.AstOrOperatorNodeOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AstStringNodeOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsStringLiteral(out global::ElevenLabs.AstStringNodeOutput? value)
    {
        if (Type == "string_literal")
        {
            value = (global::ElevenLabs.AstStringNodeOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AstSubtractionOperatorNodeOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsSubOperator(out global::ElevenLabs.AstSubtractionOperatorNodeOutput? value)
    {
        if (Type == "sub_operator")
        {
            value = (global::ElevenLabs.AstSubtractionOperatorNodeOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator AstNodeOutput(AstNodeOutput.AddOperator value) => new(value);

    public static implicit operator AstNodeOutput(AstNodeOutput.AndOperator value) => new(value);

    public static implicit operator AstNodeOutput(AstNodeOutput.BooleanLiteral value) => new(value);

    public static implicit operator AstNodeOutput(AstNodeOutput.ConditionalOperator value) =>
        new(value);

    public static implicit operator AstNodeOutput(AstNodeOutput.DivOperator value) => new(value);

    public static implicit operator AstNodeOutput(AstNodeOutput.DynamicVariable value) =>
        new(value);

    public static implicit operator AstNodeOutput(AstNodeOutput.EqOperator value) => new(value);

    public static implicit operator AstNodeOutput(AstNodeOutput.GtOperator value) => new(value);

    public static implicit operator AstNodeOutput(AstNodeOutput.GteOperator value) => new(value);

    public static implicit operator AstNodeOutput(AstNodeOutput.Llm value) => new(value);

    public static implicit operator AstNodeOutput(AstNodeOutput.LtOperator value) => new(value);

    public static implicit operator AstNodeOutput(AstNodeOutput.LteOperator value) => new(value);

    public static implicit operator AstNodeOutput(AstNodeOutput.MulOperator value) => new(value);

    public static implicit operator AstNodeOutput(AstNodeOutput.NeqOperator value) => new(value);

    public static implicit operator AstNodeOutput(AstNodeOutput.NullLiteral value) => new(value);

    public static implicit operator AstNodeOutput(AstNodeOutput.NumberLiteral value) => new(value);

    public static implicit operator AstNodeOutput(AstNodeOutput.OrOperator value) => new(value);

    public static implicit operator AstNodeOutput(AstNodeOutput.StringLiteral value) => new(value);

    public static implicit operator AstNodeOutput(AstNodeOutput.SubOperator value) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<AstNodeOutput>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(AstNodeOutput).IsAssignableFrom(typeToConvert);

        public override AstNodeOutput Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (!json.TryGetProperty("type", out var discriminatorElement))
            {
                throw new JsonException("Missing discriminator property 'type'");
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException("Discriminator property 'type' is null");
                }

                throw new JsonException(
                    $"Discriminator property 'type' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException("Discriminator property 'type' is null");

            var value = discriminator switch
            {
                "add_operator" =>
                    json.Deserialize<global::ElevenLabs.AstAdditionOperatorNodeOutput?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.AstAdditionOperatorNodeOutput"
                        ),
                "and_operator" => json.Deserialize<global::ElevenLabs.AstAndOperatorNodeOutput?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.AstAndOperatorNodeOutput"
                    ),
                "boolean_literal" => json.Deserialize<global::ElevenLabs.AstBooleanNodeOutput?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.AstBooleanNodeOutput"
                    ),
                "conditional_operator" =>
                    json.Deserialize<global::ElevenLabs.AstConditionalOperatorNodeOutput?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.AstConditionalOperatorNodeOutput"
                        ),
                "div_operator" =>
                    json.Deserialize<global::ElevenLabs.AstDivisionOperatorNodeOutput?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.AstDivisionOperatorNodeOutput"
                        ),
                "dynamic_variable" =>
                    json.Deserialize<global::ElevenLabs.AstDynamicVariableNodeOutput?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.AstDynamicVariableNodeOutput"
                        ),
                "eq_operator" => json.Deserialize<global::ElevenLabs.AstEqualsOperatorNodeOutput?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.AstEqualsOperatorNodeOutput"
                    ),
                "gt_operator" =>
                    json.Deserialize<global::ElevenLabs.AstGreaterThanOperatorNodeOutput?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.AstGreaterThanOperatorNodeOutput"
                        ),
                "gte_operator" =>
                    json.Deserialize<global::ElevenLabs.AstGreaterThanOrEqualsOperatorNodeOutput?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.AstGreaterThanOrEqualsOperatorNodeOutput"
                        ),
                "llm" => json.Deserialize<global::ElevenLabs.AstllmNodeOutput?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.AstllmNodeOutput"
                    ),
                "lt_operator" =>
                    json.Deserialize<global::ElevenLabs.AstLessThanOperatorNodeOutput?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.AstLessThanOperatorNodeOutput"
                        ),
                "lte_operator" =>
                    json.Deserialize<global::ElevenLabs.AstLessThanOrEqualsOperatorNodeOutput?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.AstLessThanOrEqualsOperatorNodeOutput"
                        ),
                "mul_operator" =>
                    json.Deserialize<global::ElevenLabs.AstMultiplicationOperatorNodeOutput?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.AstMultiplicationOperatorNodeOutput"
                        ),
                "neq_operator" =>
                    json.Deserialize<global::ElevenLabs.AstNotEqualsOperatorNodeOutput?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.AstNotEqualsOperatorNodeOutput"
                        ),
                "null_literal" => json.Deserialize<global::ElevenLabs.AstNullNodeOutput?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.AstNullNodeOutput"
                    ),
                "number_literal" => json.Deserialize<global::ElevenLabs.AstNumberNodeOutput?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.AstNumberNodeOutput"
                    ),
                "or_operator" => json.Deserialize<global::ElevenLabs.AstOrOperatorNodeOutput?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.AstOrOperatorNodeOutput"
                    ),
                "string_literal" => json.Deserialize<global::ElevenLabs.AstStringNodeOutput?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.AstStringNodeOutput"
                    ),
                "sub_operator" =>
                    json.Deserialize<global::ElevenLabs.AstSubtractionOperatorNodeOutput?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.AstSubtractionOperatorNodeOutput"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new AstNodeOutput(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AstNodeOutput value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "add_operator" => JsonSerializer.SerializeToNode(value.Value, options),
                    "and_operator" => JsonSerializer.SerializeToNode(value.Value, options),
                    "boolean_literal" => JsonSerializer.SerializeToNode(value.Value, options),
                    "conditional_operator" => JsonSerializer.SerializeToNode(value.Value, options),
                    "div_operator" => JsonSerializer.SerializeToNode(value.Value, options),
                    "dynamic_variable" => JsonSerializer.SerializeToNode(value.Value, options),
                    "eq_operator" => JsonSerializer.SerializeToNode(value.Value, options),
                    "gt_operator" => JsonSerializer.SerializeToNode(value.Value, options),
                    "gte_operator" => JsonSerializer.SerializeToNode(value.Value, options),
                    "llm" => JsonSerializer.SerializeToNode(value.Value, options),
                    "lt_operator" => JsonSerializer.SerializeToNode(value.Value, options),
                    "lte_operator" => JsonSerializer.SerializeToNode(value.Value, options),
                    "mul_operator" => JsonSerializer.SerializeToNode(value.Value, options),
                    "neq_operator" => JsonSerializer.SerializeToNode(value.Value, options),
                    "null_literal" => JsonSerializer.SerializeToNode(value.Value, options),
                    "number_literal" => JsonSerializer.SerializeToNode(value.Value, options),
                    "or_operator" => JsonSerializer.SerializeToNode(value.Value, options),
                    "string_literal" => JsonSerializer.SerializeToNode(value.Value, options),
                    "sub_operator" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override AstNodeOutput ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new AstNodeOutput(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AstNodeOutput value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for add_operator
    /// </summary>
    [Serializable]
    public struct AddOperator
    {
        public AddOperator(global::ElevenLabs.AstAdditionOperatorNodeOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AstAdditionOperatorNodeOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AstNodeOutput.AddOperator(
            global::ElevenLabs.AstAdditionOperatorNodeOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for and_operator
    /// </summary>
    [Serializable]
    public struct AndOperator
    {
        public AndOperator(global::ElevenLabs.AstAndOperatorNodeOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AstAndOperatorNodeOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AstNodeOutput.AndOperator(
            global::ElevenLabs.AstAndOperatorNodeOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for boolean_literal
    /// </summary>
    [Serializable]
    public struct BooleanLiteral
    {
        public BooleanLiteral(global::ElevenLabs.AstBooleanNodeOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AstBooleanNodeOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AstNodeOutput.BooleanLiteral(
            global::ElevenLabs.AstBooleanNodeOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for conditional_operator
    /// </summary>
    [Serializable]
    public struct ConditionalOperator
    {
        public ConditionalOperator(global::ElevenLabs.AstConditionalOperatorNodeOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AstConditionalOperatorNodeOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AstNodeOutput.ConditionalOperator(
            global::ElevenLabs.AstConditionalOperatorNodeOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for div_operator
    /// </summary>
    [Serializable]
    public struct DivOperator
    {
        public DivOperator(global::ElevenLabs.AstDivisionOperatorNodeOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AstDivisionOperatorNodeOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AstNodeOutput.DivOperator(
            global::ElevenLabs.AstDivisionOperatorNodeOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for dynamic_variable
    /// </summary>
    [Serializable]
    public struct DynamicVariable
    {
        public DynamicVariable(global::ElevenLabs.AstDynamicVariableNodeOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AstDynamicVariableNodeOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AstNodeOutput.DynamicVariable(
            global::ElevenLabs.AstDynamicVariableNodeOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for eq_operator
    /// </summary>
    [Serializable]
    public struct EqOperator
    {
        public EqOperator(global::ElevenLabs.AstEqualsOperatorNodeOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AstEqualsOperatorNodeOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AstNodeOutput.EqOperator(
            global::ElevenLabs.AstEqualsOperatorNodeOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for gt_operator
    /// </summary>
    [Serializable]
    public struct GtOperator
    {
        public GtOperator(global::ElevenLabs.AstGreaterThanOperatorNodeOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AstGreaterThanOperatorNodeOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AstNodeOutput.GtOperator(
            global::ElevenLabs.AstGreaterThanOperatorNodeOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for gte_operator
    /// </summary>
    [Serializable]
    public struct GteOperator
    {
        public GteOperator(global::ElevenLabs.AstGreaterThanOrEqualsOperatorNodeOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AstGreaterThanOrEqualsOperatorNodeOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AstNodeOutput.GteOperator(
            global::ElevenLabs.AstGreaterThanOrEqualsOperatorNodeOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for llm
    /// </summary>
    [Serializable]
    public struct Llm
    {
        public Llm(global::ElevenLabs.AstllmNodeOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AstllmNodeOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AstNodeOutput.Llm(
            global::ElevenLabs.AstllmNodeOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for lt_operator
    /// </summary>
    [Serializable]
    public struct LtOperator
    {
        public LtOperator(global::ElevenLabs.AstLessThanOperatorNodeOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AstLessThanOperatorNodeOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AstNodeOutput.LtOperator(
            global::ElevenLabs.AstLessThanOperatorNodeOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for lte_operator
    /// </summary>
    [Serializable]
    public struct LteOperator
    {
        public LteOperator(global::ElevenLabs.AstLessThanOrEqualsOperatorNodeOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AstLessThanOrEqualsOperatorNodeOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AstNodeOutput.LteOperator(
            global::ElevenLabs.AstLessThanOrEqualsOperatorNodeOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for mul_operator
    /// </summary>
    [Serializable]
    public struct MulOperator
    {
        public MulOperator(global::ElevenLabs.AstMultiplicationOperatorNodeOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AstMultiplicationOperatorNodeOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AstNodeOutput.MulOperator(
            global::ElevenLabs.AstMultiplicationOperatorNodeOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for neq_operator
    /// </summary>
    [Serializable]
    public struct NeqOperator
    {
        public NeqOperator(global::ElevenLabs.AstNotEqualsOperatorNodeOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AstNotEqualsOperatorNodeOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AstNodeOutput.NeqOperator(
            global::ElevenLabs.AstNotEqualsOperatorNodeOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for null_literal
    /// </summary>
    [Serializable]
    public struct NullLiteral
    {
        public NullLiteral(global::ElevenLabs.AstNullNodeOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AstNullNodeOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AstNodeOutput.NullLiteral(
            global::ElevenLabs.AstNullNodeOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for number_literal
    /// </summary>
    [Serializable]
    public struct NumberLiteral
    {
        public NumberLiteral(global::ElevenLabs.AstNumberNodeOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AstNumberNodeOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AstNodeOutput.NumberLiteral(
            global::ElevenLabs.AstNumberNodeOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for or_operator
    /// </summary>
    [Serializable]
    public struct OrOperator
    {
        public OrOperator(global::ElevenLabs.AstOrOperatorNodeOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AstOrOperatorNodeOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AstNodeOutput.OrOperator(
            global::ElevenLabs.AstOrOperatorNodeOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for string_literal
    /// </summary>
    [Serializable]
    public struct StringLiteral
    {
        public StringLiteral(global::ElevenLabs.AstStringNodeOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AstStringNodeOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AstNodeOutput.StringLiteral(
            global::ElevenLabs.AstStringNodeOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for sub_operator
    /// </summary>
    [Serializable]
    public struct SubOperator
    {
        public SubOperator(global::ElevenLabs.AstSubtractionOperatorNodeOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AstSubtractionOperatorNodeOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AstNodeOutput.SubOperator(
            global::ElevenLabs.AstSubtractionOperatorNodeOutput value
        ) => new(value);
    }
}
