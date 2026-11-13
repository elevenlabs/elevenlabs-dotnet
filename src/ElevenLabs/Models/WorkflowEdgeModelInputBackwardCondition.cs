// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(WorkflowEdgeModelInputBackwardCondition.JsonConverter))]
[Serializable]
public record WorkflowEdgeModelInputBackwardCondition
{
    internal WorkflowEdgeModelInputBackwardCondition(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of WorkflowEdgeModelInputBackwardCondition with <see cref="WorkflowEdgeModelInputBackwardCondition.Expression"/>.
    /// </summary>
    public WorkflowEdgeModelInputBackwardCondition(
        WorkflowEdgeModelInputBackwardCondition.Expression value
    )
    {
        Type = "expression";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of WorkflowEdgeModelInputBackwardCondition with <see cref="WorkflowEdgeModelInputBackwardCondition.Llm"/>.
    /// </summary>
    public WorkflowEdgeModelInputBackwardCondition(
        WorkflowEdgeModelInputBackwardCondition.Llm value
    )
    {
        Type = "llm";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of WorkflowEdgeModelInputBackwardCondition with <see cref="WorkflowEdgeModelInputBackwardCondition.Result"/>.
    /// </summary>
    public WorkflowEdgeModelInputBackwardCondition(
        WorkflowEdgeModelInputBackwardCondition.Result value
    )
    {
        Type = "result";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of WorkflowEdgeModelInputBackwardCondition with <see cref="WorkflowEdgeModelInputBackwardCondition.Unconditional"/>.
    /// </summary>
    public WorkflowEdgeModelInputBackwardCondition(
        WorkflowEdgeModelInputBackwardCondition.Unconditional value
    )
    {
        Type = "unconditional";
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
    /// Returns true if <see cref="Type"/> is "expression"
    /// </summary>
    public bool IsExpression => Type == "expression";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "llm"
    /// </summary>
    public bool IsLlm => Type == "llm";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "result"
    /// </summary>
    public bool IsResult => Type == "result";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "unconditional"
    /// </summary>
    public bool IsUnconditional => Type == "unconditional";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.WorkflowExpressionConditionModelInput"/> if <see cref="Type"/> is 'expression', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'expression'.</exception>
    public global::ElevenLabs.WorkflowExpressionConditionModelInput AsExpression() =>
        IsExpression
            ? (global::ElevenLabs.WorkflowExpressionConditionModelInput)Value!
            : throw new global::System.Exception(
                "WorkflowEdgeModelInputBackwardCondition.Type is not 'expression'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.WorkflowLlmConditionModelInput"/> if <see cref="Type"/> is 'llm', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'llm'.</exception>
    public global::ElevenLabs.WorkflowLlmConditionModelInput AsLlm() =>
        IsLlm
            ? (global::ElevenLabs.WorkflowLlmConditionModelInput)Value!
            : throw new global::System.Exception(
                "WorkflowEdgeModelInputBackwardCondition.Type is not 'llm'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.WorkflowResultConditionModelInput"/> if <see cref="Type"/> is 'result', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'result'.</exception>
    public global::ElevenLabs.WorkflowResultConditionModelInput AsResult() =>
        IsResult
            ? (global::ElevenLabs.WorkflowResultConditionModelInput)Value!
            : throw new global::System.Exception(
                "WorkflowEdgeModelInputBackwardCondition.Type is not 'result'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.WorkflowUnconditionalModelInput"/> if <see cref="Type"/> is 'unconditional', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'unconditional'.</exception>
    public global::ElevenLabs.WorkflowUnconditionalModelInput AsUnconditional() =>
        IsUnconditional
            ? (global::ElevenLabs.WorkflowUnconditionalModelInput)Value!
            : throw new global::System.Exception(
                "WorkflowEdgeModelInputBackwardCondition.Type is not 'unconditional'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.WorkflowExpressionConditionModelInput, T> onExpression,
        Func<global::ElevenLabs.WorkflowLlmConditionModelInput, T> onLlm,
        Func<global::ElevenLabs.WorkflowResultConditionModelInput, T> onResult,
        Func<global::ElevenLabs.WorkflowUnconditionalModelInput, T> onUnconditional,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "expression" => onExpression(AsExpression()),
            "llm" => onLlm(AsLlm()),
            "result" => onResult(AsResult()),
            "unconditional" => onUnconditional(AsUnconditional()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.WorkflowExpressionConditionModelInput> onExpression,
        Action<global::ElevenLabs.WorkflowLlmConditionModelInput> onLlm,
        Action<global::ElevenLabs.WorkflowResultConditionModelInput> onResult,
        Action<global::ElevenLabs.WorkflowUnconditionalModelInput> onUnconditional,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "expression":
                onExpression(AsExpression());
                break;
            case "llm":
                onLlm(AsLlm());
                break;
            case "result":
                onResult(AsResult());
                break;
            case "unconditional":
                onUnconditional(AsUnconditional());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.WorkflowExpressionConditionModelInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsExpression(out global::ElevenLabs.WorkflowExpressionConditionModelInput? value)
    {
        if (Type == "expression")
        {
            value = (global::ElevenLabs.WorkflowExpressionConditionModelInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.WorkflowLlmConditionModelInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsLlm(out global::ElevenLabs.WorkflowLlmConditionModelInput? value)
    {
        if (Type == "llm")
        {
            value = (global::ElevenLabs.WorkflowLlmConditionModelInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.WorkflowResultConditionModelInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsResult(out global::ElevenLabs.WorkflowResultConditionModelInput? value)
    {
        if (Type == "result")
        {
            value = (global::ElevenLabs.WorkflowResultConditionModelInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.WorkflowUnconditionalModelInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsUnconditional(out global::ElevenLabs.WorkflowUnconditionalModelInput? value)
    {
        if (Type == "unconditional")
        {
            value = (global::ElevenLabs.WorkflowUnconditionalModelInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator WorkflowEdgeModelInputBackwardCondition(
        WorkflowEdgeModelInputBackwardCondition.Expression value
    ) => new(value);

    public static implicit operator WorkflowEdgeModelInputBackwardCondition(
        WorkflowEdgeModelInputBackwardCondition.Llm value
    ) => new(value);

    public static implicit operator WorkflowEdgeModelInputBackwardCondition(
        WorkflowEdgeModelInputBackwardCondition.Result value
    ) => new(value);

    public static implicit operator WorkflowEdgeModelInputBackwardCondition(
        WorkflowEdgeModelInputBackwardCondition.Unconditional value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<WorkflowEdgeModelInputBackwardCondition>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(WorkflowEdgeModelInputBackwardCondition).IsAssignableFrom(typeToConvert);

        public override WorkflowEdgeModelInputBackwardCondition Read(
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
                "expression" =>
                    json.Deserialize<global::ElevenLabs.WorkflowExpressionConditionModelInput?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.WorkflowExpressionConditionModelInput"
                        ),
                "llm" => json.Deserialize<global::ElevenLabs.WorkflowLlmConditionModelInput?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.WorkflowLlmConditionModelInput"
                    ),
                "result" => json.Deserialize<global::ElevenLabs.WorkflowResultConditionModelInput?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.WorkflowResultConditionModelInput"
                    ),
                "unconditional" =>
                    json.Deserialize<global::ElevenLabs.WorkflowUnconditionalModelInput?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.WorkflowUnconditionalModelInput"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new WorkflowEdgeModelInputBackwardCondition(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WorkflowEdgeModelInputBackwardCondition value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "expression" => JsonSerializer.SerializeToNode(value.Value, options),
                    "llm" => JsonSerializer.SerializeToNode(value.Value, options),
                    "result" => JsonSerializer.SerializeToNode(value.Value, options),
                    "unconditional" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override WorkflowEdgeModelInputBackwardCondition ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new WorkflowEdgeModelInputBackwardCondition(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WorkflowEdgeModelInputBackwardCondition value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for expression
    /// </summary>
    [Serializable]
    public struct Expression
    {
        public Expression(global::ElevenLabs.WorkflowExpressionConditionModelInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.WorkflowExpressionConditionModelInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator WorkflowEdgeModelInputBackwardCondition.Expression(
            global::ElevenLabs.WorkflowExpressionConditionModelInput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for llm
    /// </summary>
    [Serializable]
    public struct Llm
    {
        public Llm(global::ElevenLabs.WorkflowLlmConditionModelInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.WorkflowLlmConditionModelInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator WorkflowEdgeModelInputBackwardCondition.Llm(
            global::ElevenLabs.WorkflowLlmConditionModelInput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for result
    /// </summary>
    [Serializable]
    public struct Result
    {
        public Result(global::ElevenLabs.WorkflowResultConditionModelInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.WorkflowResultConditionModelInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator WorkflowEdgeModelInputBackwardCondition.Result(
            global::ElevenLabs.WorkflowResultConditionModelInput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for unconditional
    /// </summary>
    [Serializable]
    public struct Unconditional
    {
        public Unconditional(global::ElevenLabs.WorkflowUnconditionalModelInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.WorkflowUnconditionalModelInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator WorkflowEdgeModelInputBackwardCondition.Unconditional(
            global::ElevenLabs.WorkflowUnconditionalModelInput value
        ) => new(value);
    }
}
