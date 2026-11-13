// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AstNodeInput.JsonConverter))]
[Serializable]
public record AstNodeInput
{
    internal AstNodeInput(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of AstNodeInput with <see cref="AstNodeInput.AddOperator"/>.
    /// </summary>
    public AstNodeInput(AstNodeInput.AddOperator value)
    {
        Type = "add_operator";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AstNodeInput with <see cref="AstNodeInput.AndOperator"/>.
    /// </summary>
    public AstNodeInput(AstNodeInput.AndOperator value)
    {
        Type = "and_operator";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AstNodeInput with <see cref="AstNodeInput.BooleanLiteral"/>.
    /// </summary>
    public AstNodeInput(AstNodeInput.BooleanLiteral value)
    {
        Type = "boolean_literal";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AstNodeInput with <see cref="AstNodeInput.ConditionalOperator"/>.
    /// </summary>
    public AstNodeInput(AstNodeInput.ConditionalOperator value)
    {
        Type = "conditional_operator";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AstNodeInput with <see cref="AstNodeInput.DivOperator"/>.
    /// </summary>
    public AstNodeInput(AstNodeInput.DivOperator value)
    {
        Type = "div_operator";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AstNodeInput with <see cref="AstNodeInput.DynamicVariable"/>.
    /// </summary>
    public AstNodeInput(AstNodeInput.DynamicVariable value)
    {
        Type = "dynamic_variable";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AstNodeInput with <see cref="AstNodeInput.EqOperator"/>.
    /// </summary>
    public AstNodeInput(AstNodeInput.EqOperator value)
    {
        Type = "eq_operator";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AstNodeInput with <see cref="AstNodeInput.GtOperator"/>.
    /// </summary>
    public AstNodeInput(AstNodeInput.GtOperator value)
    {
        Type = "gt_operator";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AstNodeInput with <see cref="AstNodeInput.GteOperator"/>.
    /// </summary>
    public AstNodeInput(AstNodeInput.GteOperator value)
    {
        Type = "gte_operator";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AstNodeInput with <see cref="AstNodeInput.Llm"/>.
    /// </summary>
    public AstNodeInput(AstNodeInput.Llm value)
    {
        Type = "llm";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AstNodeInput with <see cref="AstNodeInput.LtOperator"/>.
    /// </summary>
    public AstNodeInput(AstNodeInput.LtOperator value)
    {
        Type = "lt_operator";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AstNodeInput with <see cref="AstNodeInput.LteOperator"/>.
    /// </summary>
    public AstNodeInput(AstNodeInput.LteOperator value)
    {
        Type = "lte_operator";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AstNodeInput with <see cref="AstNodeInput.MulOperator"/>.
    /// </summary>
    public AstNodeInput(AstNodeInput.MulOperator value)
    {
        Type = "mul_operator";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AstNodeInput with <see cref="AstNodeInput.NeqOperator"/>.
    /// </summary>
    public AstNodeInput(AstNodeInput.NeqOperator value)
    {
        Type = "neq_operator";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AstNodeInput with <see cref="AstNodeInput.NullLiteral"/>.
    /// </summary>
    public AstNodeInput(AstNodeInput.NullLiteral value)
    {
        Type = "null_literal";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AstNodeInput with <see cref="AstNodeInput.NumberLiteral"/>.
    /// </summary>
    public AstNodeInput(AstNodeInput.NumberLiteral value)
    {
        Type = "number_literal";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AstNodeInput with <see cref="AstNodeInput.OrOperator"/>.
    /// </summary>
    public AstNodeInput(AstNodeInput.OrOperator value)
    {
        Type = "or_operator";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AstNodeInput with <see cref="AstNodeInput.StringLiteral"/>.
    /// </summary>
    public AstNodeInput(AstNodeInput.StringLiteral value)
    {
        Type = "string_literal";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of AstNodeInput with <see cref="AstNodeInput.SubOperator"/>.
    /// </summary>
    public AstNodeInput(AstNodeInput.SubOperator value)
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
    /// Returns the value as a <see cref="global::ElevenLabs.AstAdditionOperatorNodeInput"/> if <see cref="Type"/> is 'add_operator', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'add_operator'.</exception>
    public global::ElevenLabs.AstAdditionOperatorNodeInput AsAddOperator() =>
        IsAddOperator
            ? (global::ElevenLabs.AstAdditionOperatorNodeInput)Value!
            : throw new global::System.Exception("AstNodeInput.Type is not 'add_operator'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AstAndOperatorNodeInput"/> if <see cref="Type"/> is 'and_operator', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'and_operator'.</exception>
    public global::ElevenLabs.AstAndOperatorNodeInput AsAndOperator() =>
        IsAndOperator
            ? (global::ElevenLabs.AstAndOperatorNodeInput)Value!
            : throw new global::System.Exception("AstNodeInput.Type is not 'and_operator'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AstBooleanNodeInput"/> if <see cref="Type"/> is 'boolean_literal', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'boolean_literal'.</exception>
    public global::ElevenLabs.AstBooleanNodeInput AsBooleanLiteral() =>
        IsBooleanLiteral
            ? (global::ElevenLabs.AstBooleanNodeInput)Value!
            : throw new global::System.Exception("AstNodeInput.Type is not 'boolean_literal'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AstConditionalOperatorNodeInput"/> if <see cref="Type"/> is 'conditional_operator', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'conditional_operator'.</exception>
    public global::ElevenLabs.AstConditionalOperatorNodeInput AsConditionalOperator() =>
        IsConditionalOperator
            ? (global::ElevenLabs.AstConditionalOperatorNodeInput)Value!
            : throw new global::System.Exception("AstNodeInput.Type is not 'conditional_operator'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AstDivisionOperatorNodeInput"/> if <see cref="Type"/> is 'div_operator', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'div_operator'.</exception>
    public global::ElevenLabs.AstDivisionOperatorNodeInput AsDivOperator() =>
        IsDivOperator
            ? (global::ElevenLabs.AstDivisionOperatorNodeInput)Value!
            : throw new global::System.Exception("AstNodeInput.Type is not 'div_operator'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AstDynamicVariableNodeInput"/> if <see cref="Type"/> is 'dynamic_variable', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'dynamic_variable'.</exception>
    public global::ElevenLabs.AstDynamicVariableNodeInput AsDynamicVariable() =>
        IsDynamicVariable
            ? (global::ElevenLabs.AstDynamicVariableNodeInput)Value!
            : throw new global::System.Exception("AstNodeInput.Type is not 'dynamic_variable'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AstEqualsOperatorNodeInput"/> if <see cref="Type"/> is 'eq_operator', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'eq_operator'.</exception>
    public global::ElevenLabs.AstEqualsOperatorNodeInput AsEqOperator() =>
        IsEqOperator
            ? (global::ElevenLabs.AstEqualsOperatorNodeInput)Value!
            : throw new global::System.Exception("AstNodeInput.Type is not 'eq_operator'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AstGreaterThanOperatorNodeInput"/> if <see cref="Type"/> is 'gt_operator', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'gt_operator'.</exception>
    public global::ElevenLabs.AstGreaterThanOperatorNodeInput AsGtOperator() =>
        IsGtOperator
            ? (global::ElevenLabs.AstGreaterThanOperatorNodeInput)Value!
            : throw new global::System.Exception("AstNodeInput.Type is not 'gt_operator'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AstGreaterThanOrEqualsOperatorNodeInput"/> if <see cref="Type"/> is 'gte_operator', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'gte_operator'.</exception>
    public global::ElevenLabs.AstGreaterThanOrEqualsOperatorNodeInput AsGteOperator() =>
        IsGteOperator
            ? (global::ElevenLabs.AstGreaterThanOrEqualsOperatorNodeInput)Value!
            : throw new global::System.Exception("AstNodeInput.Type is not 'gte_operator'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AstllmNodeInput"/> if <see cref="Type"/> is 'llm', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'llm'.</exception>
    public global::ElevenLabs.AstllmNodeInput AsLlm() =>
        IsLlm
            ? (global::ElevenLabs.AstllmNodeInput)Value!
            : throw new global::System.Exception("AstNodeInput.Type is not 'llm'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AstLessThanOperatorNodeInput"/> if <see cref="Type"/> is 'lt_operator', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'lt_operator'.</exception>
    public global::ElevenLabs.AstLessThanOperatorNodeInput AsLtOperator() =>
        IsLtOperator
            ? (global::ElevenLabs.AstLessThanOperatorNodeInput)Value!
            : throw new global::System.Exception("AstNodeInput.Type is not 'lt_operator'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AstLessThanOrEqualsOperatorNodeInput"/> if <see cref="Type"/> is 'lte_operator', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'lte_operator'.</exception>
    public global::ElevenLabs.AstLessThanOrEqualsOperatorNodeInput AsLteOperator() =>
        IsLteOperator
            ? (global::ElevenLabs.AstLessThanOrEqualsOperatorNodeInput)Value!
            : throw new global::System.Exception("AstNodeInput.Type is not 'lte_operator'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AstMultiplicationOperatorNodeInput"/> if <see cref="Type"/> is 'mul_operator', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'mul_operator'.</exception>
    public global::ElevenLabs.AstMultiplicationOperatorNodeInput AsMulOperator() =>
        IsMulOperator
            ? (global::ElevenLabs.AstMultiplicationOperatorNodeInput)Value!
            : throw new global::System.Exception("AstNodeInput.Type is not 'mul_operator'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AstNotEqualsOperatorNodeInput"/> if <see cref="Type"/> is 'neq_operator', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'neq_operator'.</exception>
    public global::ElevenLabs.AstNotEqualsOperatorNodeInput AsNeqOperator() =>
        IsNeqOperator
            ? (global::ElevenLabs.AstNotEqualsOperatorNodeInput)Value!
            : throw new global::System.Exception("AstNodeInput.Type is not 'neq_operator'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AstNullNodeInput"/> if <see cref="Type"/> is 'null_literal', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'null_literal'.</exception>
    public global::ElevenLabs.AstNullNodeInput AsNullLiteral() =>
        IsNullLiteral
            ? (global::ElevenLabs.AstNullNodeInput)Value!
            : throw new global::System.Exception("AstNodeInput.Type is not 'null_literal'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AstNumberNodeInput"/> if <see cref="Type"/> is 'number_literal', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'number_literal'.</exception>
    public global::ElevenLabs.AstNumberNodeInput AsNumberLiteral() =>
        IsNumberLiteral
            ? (global::ElevenLabs.AstNumberNodeInput)Value!
            : throw new global::System.Exception("AstNodeInput.Type is not 'number_literal'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AstOrOperatorNodeInput"/> if <see cref="Type"/> is 'or_operator', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'or_operator'.</exception>
    public global::ElevenLabs.AstOrOperatorNodeInput AsOrOperator() =>
        IsOrOperator
            ? (global::ElevenLabs.AstOrOperatorNodeInput)Value!
            : throw new global::System.Exception("AstNodeInput.Type is not 'or_operator'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AstStringNodeInput"/> if <see cref="Type"/> is 'string_literal', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'string_literal'.</exception>
    public global::ElevenLabs.AstStringNodeInput AsStringLiteral() =>
        IsStringLiteral
            ? (global::ElevenLabs.AstStringNodeInput)Value!
            : throw new global::System.Exception("AstNodeInput.Type is not 'string_literal'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.AstSubtractionOperatorNodeInput"/> if <see cref="Type"/> is 'sub_operator', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'sub_operator'.</exception>
    public global::ElevenLabs.AstSubtractionOperatorNodeInput AsSubOperator() =>
        IsSubOperator
            ? (global::ElevenLabs.AstSubtractionOperatorNodeInput)Value!
            : throw new global::System.Exception("AstNodeInput.Type is not 'sub_operator'");

    public T Match<T>(
        Func<global::ElevenLabs.AstAdditionOperatorNodeInput, T> onAddOperator,
        Func<global::ElevenLabs.AstAndOperatorNodeInput, T> onAndOperator,
        Func<global::ElevenLabs.AstBooleanNodeInput, T> onBooleanLiteral,
        Func<global::ElevenLabs.AstConditionalOperatorNodeInput, T> onConditionalOperator,
        Func<global::ElevenLabs.AstDivisionOperatorNodeInput, T> onDivOperator,
        Func<global::ElevenLabs.AstDynamicVariableNodeInput, T> onDynamicVariable,
        Func<global::ElevenLabs.AstEqualsOperatorNodeInput, T> onEqOperator,
        Func<global::ElevenLabs.AstGreaterThanOperatorNodeInput, T> onGtOperator,
        Func<global::ElevenLabs.AstGreaterThanOrEqualsOperatorNodeInput, T> onGteOperator,
        Func<global::ElevenLabs.AstllmNodeInput, T> onLlm,
        Func<global::ElevenLabs.AstLessThanOperatorNodeInput, T> onLtOperator,
        Func<global::ElevenLabs.AstLessThanOrEqualsOperatorNodeInput, T> onLteOperator,
        Func<global::ElevenLabs.AstMultiplicationOperatorNodeInput, T> onMulOperator,
        Func<global::ElevenLabs.AstNotEqualsOperatorNodeInput, T> onNeqOperator,
        Func<global::ElevenLabs.AstNullNodeInput, T> onNullLiteral,
        Func<global::ElevenLabs.AstNumberNodeInput, T> onNumberLiteral,
        Func<global::ElevenLabs.AstOrOperatorNodeInput, T> onOrOperator,
        Func<global::ElevenLabs.AstStringNodeInput, T> onStringLiteral,
        Func<global::ElevenLabs.AstSubtractionOperatorNodeInput, T> onSubOperator,
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
        Action<global::ElevenLabs.AstAdditionOperatorNodeInput> onAddOperator,
        Action<global::ElevenLabs.AstAndOperatorNodeInput> onAndOperator,
        Action<global::ElevenLabs.AstBooleanNodeInput> onBooleanLiteral,
        Action<global::ElevenLabs.AstConditionalOperatorNodeInput> onConditionalOperator,
        Action<global::ElevenLabs.AstDivisionOperatorNodeInput> onDivOperator,
        Action<global::ElevenLabs.AstDynamicVariableNodeInput> onDynamicVariable,
        Action<global::ElevenLabs.AstEqualsOperatorNodeInput> onEqOperator,
        Action<global::ElevenLabs.AstGreaterThanOperatorNodeInput> onGtOperator,
        Action<global::ElevenLabs.AstGreaterThanOrEqualsOperatorNodeInput> onGteOperator,
        Action<global::ElevenLabs.AstllmNodeInput> onLlm,
        Action<global::ElevenLabs.AstLessThanOperatorNodeInput> onLtOperator,
        Action<global::ElevenLabs.AstLessThanOrEqualsOperatorNodeInput> onLteOperator,
        Action<global::ElevenLabs.AstMultiplicationOperatorNodeInput> onMulOperator,
        Action<global::ElevenLabs.AstNotEqualsOperatorNodeInput> onNeqOperator,
        Action<global::ElevenLabs.AstNullNodeInput> onNullLiteral,
        Action<global::ElevenLabs.AstNumberNodeInput> onNumberLiteral,
        Action<global::ElevenLabs.AstOrOperatorNodeInput> onOrOperator,
        Action<global::ElevenLabs.AstStringNodeInput> onStringLiteral,
        Action<global::ElevenLabs.AstSubtractionOperatorNodeInput> onSubOperator,
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
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AstAdditionOperatorNodeInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsAddOperator(out global::ElevenLabs.AstAdditionOperatorNodeInput? value)
    {
        if (Type == "add_operator")
        {
            value = (global::ElevenLabs.AstAdditionOperatorNodeInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AstAndOperatorNodeInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsAndOperator(out global::ElevenLabs.AstAndOperatorNodeInput? value)
    {
        if (Type == "and_operator")
        {
            value = (global::ElevenLabs.AstAndOperatorNodeInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AstBooleanNodeInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsBooleanLiteral(out global::ElevenLabs.AstBooleanNodeInput? value)
    {
        if (Type == "boolean_literal")
        {
            value = (global::ElevenLabs.AstBooleanNodeInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AstConditionalOperatorNodeInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsConditionalOperator(
        out global::ElevenLabs.AstConditionalOperatorNodeInput? value
    )
    {
        if (Type == "conditional_operator")
        {
            value = (global::ElevenLabs.AstConditionalOperatorNodeInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AstDivisionOperatorNodeInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsDivOperator(out global::ElevenLabs.AstDivisionOperatorNodeInput? value)
    {
        if (Type == "div_operator")
        {
            value = (global::ElevenLabs.AstDivisionOperatorNodeInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AstDynamicVariableNodeInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsDynamicVariable(out global::ElevenLabs.AstDynamicVariableNodeInput? value)
    {
        if (Type == "dynamic_variable")
        {
            value = (global::ElevenLabs.AstDynamicVariableNodeInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AstEqualsOperatorNodeInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsEqOperator(out global::ElevenLabs.AstEqualsOperatorNodeInput? value)
    {
        if (Type == "eq_operator")
        {
            value = (global::ElevenLabs.AstEqualsOperatorNodeInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AstGreaterThanOperatorNodeInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsGtOperator(out global::ElevenLabs.AstGreaterThanOperatorNodeInput? value)
    {
        if (Type == "gt_operator")
        {
            value = (global::ElevenLabs.AstGreaterThanOperatorNodeInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AstGreaterThanOrEqualsOperatorNodeInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsGteOperator(
        out global::ElevenLabs.AstGreaterThanOrEqualsOperatorNodeInput? value
    )
    {
        if (Type == "gte_operator")
        {
            value = (global::ElevenLabs.AstGreaterThanOrEqualsOperatorNodeInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AstllmNodeInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsLlm(out global::ElevenLabs.AstllmNodeInput? value)
    {
        if (Type == "llm")
        {
            value = (global::ElevenLabs.AstllmNodeInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AstLessThanOperatorNodeInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsLtOperator(out global::ElevenLabs.AstLessThanOperatorNodeInput? value)
    {
        if (Type == "lt_operator")
        {
            value = (global::ElevenLabs.AstLessThanOperatorNodeInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AstLessThanOrEqualsOperatorNodeInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsLteOperator(out global::ElevenLabs.AstLessThanOrEqualsOperatorNodeInput? value)
    {
        if (Type == "lte_operator")
        {
            value = (global::ElevenLabs.AstLessThanOrEqualsOperatorNodeInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AstMultiplicationOperatorNodeInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsMulOperator(out global::ElevenLabs.AstMultiplicationOperatorNodeInput? value)
    {
        if (Type == "mul_operator")
        {
            value = (global::ElevenLabs.AstMultiplicationOperatorNodeInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AstNotEqualsOperatorNodeInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsNeqOperator(out global::ElevenLabs.AstNotEqualsOperatorNodeInput? value)
    {
        if (Type == "neq_operator")
        {
            value = (global::ElevenLabs.AstNotEqualsOperatorNodeInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AstNullNodeInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsNullLiteral(out global::ElevenLabs.AstNullNodeInput? value)
    {
        if (Type == "null_literal")
        {
            value = (global::ElevenLabs.AstNullNodeInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AstNumberNodeInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsNumberLiteral(out global::ElevenLabs.AstNumberNodeInput? value)
    {
        if (Type == "number_literal")
        {
            value = (global::ElevenLabs.AstNumberNodeInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AstOrOperatorNodeInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsOrOperator(out global::ElevenLabs.AstOrOperatorNodeInput? value)
    {
        if (Type == "or_operator")
        {
            value = (global::ElevenLabs.AstOrOperatorNodeInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AstStringNodeInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsStringLiteral(out global::ElevenLabs.AstStringNodeInput? value)
    {
        if (Type == "string_literal")
        {
            value = (global::ElevenLabs.AstStringNodeInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.AstSubtractionOperatorNodeInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsSubOperator(out global::ElevenLabs.AstSubtractionOperatorNodeInput? value)
    {
        if (Type == "sub_operator")
        {
            value = (global::ElevenLabs.AstSubtractionOperatorNodeInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator AstNodeInput(AstNodeInput.AddOperator value) => new(value);

    public static implicit operator AstNodeInput(AstNodeInput.AndOperator value) => new(value);

    public static implicit operator AstNodeInput(AstNodeInput.BooleanLiteral value) => new(value);

    public static implicit operator AstNodeInput(AstNodeInput.ConditionalOperator value) =>
        new(value);

    public static implicit operator AstNodeInput(AstNodeInput.DivOperator value) => new(value);

    public static implicit operator AstNodeInput(AstNodeInput.DynamicVariable value) => new(value);

    public static implicit operator AstNodeInput(AstNodeInput.EqOperator value) => new(value);

    public static implicit operator AstNodeInput(AstNodeInput.GtOperator value) => new(value);

    public static implicit operator AstNodeInput(AstNodeInput.GteOperator value) => new(value);

    public static implicit operator AstNodeInput(AstNodeInput.Llm value) => new(value);

    public static implicit operator AstNodeInput(AstNodeInput.LtOperator value) => new(value);

    public static implicit operator AstNodeInput(AstNodeInput.LteOperator value) => new(value);

    public static implicit operator AstNodeInput(AstNodeInput.MulOperator value) => new(value);

    public static implicit operator AstNodeInput(AstNodeInput.NeqOperator value) => new(value);

    public static implicit operator AstNodeInput(AstNodeInput.NullLiteral value) => new(value);

    public static implicit operator AstNodeInput(AstNodeInput.NumberLiteral value) => new(value);

    public static implicit operator AstNodeInput(AstNodeInput.OrOperator value) => new(value);

    public static implicit operator AstNodeInput(AstNodeInput.StringLiteral value) => new(value);

    public static implicit operator AstNodeInput(AstNodeInput.SubOperator value) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<AstNodeInput>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(AstNodeInput).IsAssignableFrom(typeToConvert);

        public override AstNodeInput Read(
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

            // Strip the discriminant property to prevent it from leaking into AdditionalProperties
            var jsonObject = System.Text.Json.Nodes.JsonObject.Create(json);
            jsonObject?.Remove("type");
            var jsonWithoutDiscriminator =
                jsonObject != null ? JsonSerializer.SerializeToElement(jsonObject, options) : json;

            var value = discriminator switch
            {
                "add_operator" =>
                    json.Deserialize<global::ElevenLabs.AstAdditionOperatorNodeInput?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.AstAdditionOperatorNodeInput"
                        ),
                "and_operator" => json.Deserialize<global::ElevenLabs.AstAndOperatorNodeInput?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.AstAndOperatorNodeInput"
                    ),
                "boolean_literal" => json.Deserialize<global::ElevenLabs.AstBooleanNodeInput?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.AstBooleanNodeInput"
                    ),
                "conditional_operator" =>
                    json.Deserialize<global::ElevenLabs.AstConditionalOperatorNodeInput?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.AstConditionalOperatorNodeInput"
                        ),
                "div_operator" =>
                    json.Deserialize<global::ElevenLabs.AstDivisionOperatorNodeInput?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.AstDivisionOperatorNodeInput"
                        ),
                "dynamic_variable" =>
                    json.Deserialize<global::ElevenLabs.AstDynamicVariableNodeInput?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.AstDynamicVariableNodeInput"
                        ),
                "eq_operator" => json.Deserialize<global::ElevenLabs.AstEqualsOperatorNodeInput?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.AstEqualsOperatorNodeInput"
                    ),
                "gt_operator" =>
                    json.Deserialize<global::ElevenLabs.AstGreaterThanOperatorNodeInput?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.AstGreaterThanOperatorNodeInput"
                        ),
                "gte_operator" =>
                    json.Deserialize<global::ElevenLabs.AstGreaterThanOrEqualsOperatorNodeInput?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.AstGreaterThanOrEqualsOperatorNodeInput"
                        ),
                "llm" => jsonWithoutDiscriminator.Deserialize<global::ElevenLabs.AstllmNodeInput?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.AstllmNodeInput"
                    ),
                "lt_operator" => json.Deserialize<global::ElevenLabs.AstLessThanOperatorNodeInput?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.AstLessThanOperatorNodeInput"
                    ),
                "lte_operator" =>
                    json.Deserialize<global::ElevenLabs.AstLessThanOrEqualsOperatorNodeInput?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.AstLessThanOrEqualsOperatorNodeInput"
                        ),
                "mul_operator" =>
                    json.Deserialize<global::ElevenLabs.AstMultiplicationOperatorNodeInput?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.AstMultiplicationOperatorNodeInput"
                        ),
                "neq_operator" =>
                    json.Deserialize<global::ElevenLabs.AstNotEqualsOperatorNodeInput?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.AstNotEqualsOperatorNodeInput"
                        ),
                "null_literal" => json.Deserialize<global::ElevenLabs.AstNullNodeInput?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.AstNullNodeInput"
                    ),
                "number_literal" => json.Deserialize<global::ElevenLabs.AstNumberNodeInput?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.AstNumberNodeInput"
                    ),
                "or_operator" => json.Deserialize<global::ElevenLabs.AstOrOperatorNodeInput?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.AstOrOperatorNodeInput"
                    ),
                "string_literal" => json.Deserialize<global::ElevenLabs.AstStringNodeInput?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.AstStringNodeInput"
                    ),
                "sub_operator" =>
                    json.Deserialize<global::ElevenLabs.AstSubtractionOperatorNodeInput?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.AstSubtractionOperatorNodeInput"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new AstNodeInput(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AstNodeInput value,
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

        public override AstNodeInput ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new AstNodeInput(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AstNodeInput value,
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
        public AddOperator(global::ElevenLabs.AstAdditionOperatorNodeInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AstAdditionOperatorNodeInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AstNodeInput.AddOperator(
            global::ElevenLabs.AstAdditionOperatorNodeInput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for and_operator
    /// </summary>
    [Serializable]
    public struct AndOperator
    {
        public AndOperator(global::ElevenLabs.AstAndOperatorNodeInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AstAndOperatorNodeInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AstNodeInput.AndOperator(
            global::ElevenLabs.AstAndOperatorNodeInput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for boolean_literal
    /// </summary>
    [Serializable]
    public struct BooleanLiteral
    {
        public BooleanLiteral(global::ElevenLabs.AstBooleanNodeInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AstBooleanNodeInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AstNodeInput.BooleanLiteral(
            global::ElevenLabs.AstBooleanNodeInput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for conditional_operator
    /// </summary>
    [Serializable]
    public struct ConditionalOperator
    {
        public ConditionalOperator(global::ElevenLabs.AstConditionalOperatorNodeInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AstConditionalOperatorNodeInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AstNodeInput.ConditionalOperator(
            global::ElevenLabs.AstConditionalOperatorNodeInput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for div_operator
    /// </summary>
    [Serializable]
    public struct DivOperator
    {
        public DivOperator(global::ElevenLabs.AstDivisionOperatorNodeInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AstDivisionOperatorNodeInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AstNodeInput.DivOperator(
            global::ElevenLabs.AstDivisionOperatorNodeInput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for dynamic_variable
    /// </summary>
    [Serializable]
    public struct DynamicVariable
    {
        public DynamicVariable(global::ElevenLabs.AstDynamicVariableNodeInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AstDynamicVariableNodeInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AstNodeInput.DynamicVariable(
            global::ElevenLabs.AstDynamicVariableNodeInput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for eq_operator
    /// </summary>
    [Serializable]
    public struct EqOperator
    {
        public EqOperator(global::ElevenLabs.AstEqualsOperatorNodeInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AstEqualsOperatorNodeInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AstNodeInput.EqOperator(
            global::ElevenLabs.AstEqualsOperatorNodeInput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for gt_operator
    /// </summary>
    [Serializable]
    public struct GtOperator
    {
        public GtOperator(global::ElevenLabs.AstGreaterThanOperatorNodeInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AstGreaterThanOperatorNodeInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AstNodeInput.GtOperator(
            global::ElevenLabs.AstGreaterThanOperatorNodeInput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for gte_operator
    /// </summary>
    [Serializable]
    public struct GteOperator
    {
        public GteOperator(global::ElevenLabs.AstGreaterThanOrEqualsOperatorNodeInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AstGreaterThanOrEqualsOperatorNodeInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AstNodeInput.GteOperator(
            global::ElevenLabs.AstGreaterThanOrEqualsOperatorNodeInput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for llm
    /// </summary>
    [Serializable]
    public struct Llm
    {
        public Llm(global::ElevenLabs.AstllmNodeInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AstllmNodeInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AstNodeInput.Llm(
            global::ElevenLabs.AstllmNodeInput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for lt_operator
    /// </summary>
    [Serializable]
    public struct LtOperator
    {
        public LtOperator(global::ElevenLabs.AstLessThanOperatorNodeInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AstLessThanOperatorNodeInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AstNodeInput.LtOperator(
            global::ElevenLabs.AstLessThanOperatorNodeInput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for lte_operator
    /// </summary>
    [Serializable]
    public struct LteOperator
    {
        public LteOperator(global::ElevenLabs.AstLessThanOrEqualsOperatorNodeInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AstLessThanOrEqualsOperatorNodeInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AstNodeInput.LteOperator(
            global::ElevenLabs.AstLessThanOrEqualsOperatorNodeInput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for mul_operator
    /// </summary>
    [Serializable]
    public struct MulOperator
    {
        public MulOperator(global::ElevenLabs.AstMultiplicationOperatorNodeInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AstMultiplicationOperatorNodeInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AstNodeInput.MulOperator(
            global::ElevenLabs.AstMultiplicationOperatorNodeInput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for neq_operator
    /// </summary>
    [Serializable]
    public struct NeqOperator
    {
        public NeqOperator(global::ElevenLabs.AstNotEqualsOperatorNodeInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AstNotEqualsOperatorNodeInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AstNodeInput.NeqOperator(
            global::ElevenLabs.AstNotEqualsOperatorNodeInput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for null_literal
    /// </summary>
    [Serializable]
    public struct NullLiteral
    {
        public NullLiteral(global::ElevenLabs.AstNullNodeInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AstNullNodeInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AstNodeInput.NullLiteral(
            global::ElevenLabs.AstNullNodeInput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for number_literal
    /// </summary>
    [Serializable]
    public struct NumberLiteral
    {
        public NumberLiteral(global::ElevenLabs.AstNumberNodeInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AstNumberNodeInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AstNodeInput.NumberLiteral(
            global::ElevenLabs.AstNumberNodeInput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for or_operator
    /// </summary>
    [Serializable]
    public struct OrOperator
    {
        public OrOperator(global::ElevenLabs.AstOrOperatorNodeInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AstOrOperatorNodeInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AstNodeInput.OrOperator(
            global::ElevenLabs.AstOrOperatorNodeInput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for string_literal
    /// </summary>
    [Serializable]
    public struct StringLiteral
    {
        public StringLiteral(global::ElevenLabs.AstStringNodeInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AstStringNodeInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AstNodeInput.StringLiteral(
            global::ElevenLabs.AstStringNodeInput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for sub_operator
    /// </summary>
    [Serializable]
    public struct SubOperator
    {
        public SubOperator(global::ElevenLabs.AstSubtractionOperatorNodeInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.AstSubtractionOperatorNodeInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator AstNodeInput.SubOperator(
            global::ElevenLabs.AstSubtractionOperatorNodeInput value
        ) => new(value);
    }
}
