// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(WorkflowEdgeModelOutputBackwardCondition.JsonConverter))]
[Serializable]
public record WorkflowEdgeModelOutputBackwardCondition
{
    internal WorkflowEdgeModelOutputBackwardCondition(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of WorkflowEdgeModelOutputBackwardCondition with <see cref="WorkflowEdgeModelOutputBackwardCondition.Expression"/>.
    /// </summary>
    public WorkflowEdgeModelOutputBackwardCondition(
        WorkflowEdgeModelOutputBackwardCondition.Expression value
    )
    {
        Type = "expression";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of WorkflowEdgeModelOutputBackwardCondition with <see cref="WorkflowEdgeModelOutputBackwardCondition.Llm"/>.
    /// </summary>
    public WorkflowEdgeModelOutputBackwardCondition(
        WorkflowEdgeModelOutputBackwardCondition.Llm value
    )
    {
        Type = "llm";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of WorkflowEdgeModelOutputBackwardCondition with <see cref="WorkflowEdgeModelOutputBackwardCondition.Result"/>.
    /// </summary>
    public WorkflowEdgeModelOutputBackwardCondition(
        WorkflowEdgeModelOutputBackwardCondition.Result value
    )
    {
        Type = "result";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of WorkflowEdgeModelOutputBackwardCondition with <see cref="WorkflowEdgeModelOutputBackwardCondition.Unconditional"/>.
    /// </summary>
    public WorkflowEdgeModelOutputBackwardCondition(
        WorkflowEdgeModelOutputBackwardCondition.Unconditional value
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
    /// Returns the value as a <see cref="global::ElevenLabs.WorkflowExpressionConditionModelOutput"/> if <see cref="Type"/> is 'expression', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'expression'.</exception>
    public global::ElevenLabs.WorkflowExpressionConditionModelOutput AsExpression() =>
        IsExpression
            ? (global::ElevenLabs.WorkflowExpressionConditionModelOutput)Value!
            : throw new global::System.Exception(
                "WorkflowEdgeModelOutputBackwardCondition.Type is not 'expression'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.WorkflowLlmConditionModelOutput"/> if <see cref="Type"/> is 'llm', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'llm'.</exception>
    public global::ElevenLabs.WorkflowLlmConditionModelOutput AsLlm() =>
        IsLlm
            ? (global::ElevenLabs.WorkflowLlmConditionModelOutput)Value!
            : throw new global::System.Exception(
                "WorkflowEdgeModelOutputBackwardCondition.Type is not 'llm'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.WorkflowResultConditionModelOutput"/> if <see cref="Type"/> is 'result', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'result'.</exception>
    public global::ElevenLabs.WorkflowResultConditionModelOutput AsResult() =>
        IsResult
            ? (global::ElevenLabs.WorkflowResultConditionModelOutput)Value!
            : throw new global::System.Exception(
                "WorkflowEdgeModelOutputBackwardCondition.Type is not 'result'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.WorkflowUnconditionalModelOutput"/> if <see cref="Type"/> is 'unconditional', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'unconditional'.</exception>
    public global::ElevenLabs.WorkflowUnconditionalModelOutput AsUnconditional() =>
        IsUnconditional
            ? (global::ElevenLabs.WorkflowUnconditionalModelOutput)Value!
            : throw new global::System.Exception(
                "WorkflowEdgeModelOutputBackwardCondition.Type is not 'unconditional'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.WorkflowExpressionConditionModelOutput, T> onExpression,
        Func<global::ElevenLabs.WorkflowLlmConditionModelOutput, T> onLlm,
        Func<global::ElevenLabs.WorkflowResultConditionModelOutput, T> onResult,
        Func<global::ElevenLabs.WorkflowUnconditionalModelOutput, T> onUnconditional,
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
        Action<global::ElevenLabs.WorkflowExpressionConditionModelOutput> onExpression,
        Action<global::ElevenLabs.WorkflowLlmConditionModelOutput> onLlm,
        Action<global::ElevenLabs.WorkflowResultConditionModelOutput> onResult,
        Action<global::ElevenLabs.WorkflowUnconditionalModelOutput> onUnconditional,
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
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.WorkflowExpressionConditionModelOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsExpression(
        out global::ElevenLabs.WorkflowExpressionConditionModelOutput? value
    )
    {
        if (Type == "expression")
        {
            value = (global::ElevenLabs.WorkflowExpressionConditionModelOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.WorkflowLlmConditionModelOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsLlm(out global::ElevenLabs.WorkflowLlmConditionModelOutput? value)
    {
        if (Type == "llm")
        {
            value = (global::ElevenLabs.WorkflowLlmConditionModelOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.WorkflowResultConditionModelOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsResult(out global::ElevenLabs.WorkflowResultConditionModelOutput? value)
    {
        if (Type == "result")
        {
            value = (global::ElevenLabs.WorkflowResultConditionModelOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.WorkflowUnconditionalModelOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsUnconditional(out global::ElevenLabs.WorkflowUnconditionalModelOutput? value)
    {
        if (Type == "unconditional")
        {
            value = (global::ElevenLabs.WorkflowUnconditionalModelOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator WorkflowEdgeModelOutputBackwardCondition(
        WorkflowEdgeModelOutputBackwardCondition.Expression value
    ) => new(value);

    public static implicit operator WorkflowEdgeModelOutputBackwardCondition(
        WorkflowEdgeModelOutputBackwardCondition.Llm value
    ) => new(value);

    public static implicit operator WorkflowEdgeModelOutputBackwardCondition(
        WorkflowEdgeModelOutputBackwardCondition.Result value
    ) => new(value);

    public static implicit operator WorkflowEdgeModelOutputBackwardCondition(
        WorkflowEdgeModelOutputBackwardCondition.Unconditional value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<WorkflowEdgeModelOutputBackwardCondition>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(WorkflowEdgeModelOutputBackwardCondition).IsAssignableFrom(typeToConvert);

        public override WorkflowEdgeModelOutputBackwardCondition Read(
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
                    json.Deserialize<global::ElevenLabs.WorkflowExpressionConditionModelOutput?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.WorkflowExpressionConditionModelOutput"
                        ),
                "llm" => json.Deserialize<global::ElevenLabs.WorkflowLlmConditionModelOutput?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.WorkflowLlmConditionModelOutput"
                    ),
                "result" =>
                    json.Deserialize<global::ElevenLabs.WorkflowResultConditionModelOutput?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.WorkflowResultConditionModelOutput"
                        ),
                "unconditional" =>
                    json.Deserialize<global::ElevenLabs.WorkflowUnconditionalModelOutput?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.WorkflowUnconditionalModelOutput"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new WorkflowEdgeModelOutputBackwardCondition(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WorkflowEdgeModelOutputBackwardCondition value,
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

        public override WorkflowEdgeModelOutputBackwardCondition ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new WorkflowEdgeModelOutputBackwardCondition(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WorkflowEdgeModelOutputBackwardCondition value,
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
        public Expression(global::ElevenLabs.WorkflowExpressionConditionModelOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.WorkflowExpressionConditionModelOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator WorkflowEdgeModelOutputBackwardCondition.Expression(
            global::ElevenLabs.WorkflowExpressionConditionModelOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for llm
    /// </summary>
    [Serializable]
    public struct Llm
    {
        public Llm(global::ElevenLabs.WorkflowLlmConditionModelOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.WorkflowLlmConditionModelOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator WorkflowEdgeModelOutputBackwardCondition.Llm(
            global::ElevenLabs.WorkflowLlmConditionModelOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for result
    /// </summary>
    [Serializable]
    public struct Result
    {
        public Result(global::ElevenLabs.WorkflowResultConditionModelOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.WorkflowResultConditionModelOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator WorkflowEdgeModelOutputBackwardCondition.Result(
            global::ElevenLabs.WorkflowResultConditionModelOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for unconditional
    /// </summary>
    [Serializable]
    public struct Unconditional
    {
        public Unconditional(global::ElevenLabs.WorkflowUnconditionalModelOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.WorkflowUnconditionalModelOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator WorkflowEdgeModelOutputBackwardCondition.Unconditional(
            global::ElevenLabs.WorkflowUnconditionalModelOutput value
        ) => new(value);
    }
}
