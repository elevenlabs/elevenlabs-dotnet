// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(WorkflowToolResponseModelInputStepsItem.JsonConverter))]
[Serializable]
public record WorkflowToolResponseModelInputStepsItem
{
    internal WorkflowToolResponseModelInputStepsItem(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of WorkflowToolResponseModelInputStepsItem with <see cref="WorkflowToolResponseModelInputStepsItem.Edge"/>.
    /// </summary>
    public WorkflowToolResponseModelInputStepsItem(
        WorkflowToolResponseModelInputStepsItem.Edge value
    )
    {
        Type = "edge";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of WorkflowToolResponseModelInputStepsItem with <see cref="WorkflowToolResponseModelInputStepsItem.MaxIterationsExceeded"/>.
    /// </summary>
    public WorkflowToolResponseModelInputStepsItem(
        WorkflowToolResponseModelInputStepsItem.MaxIterationsExceeded value
    )
    {
        Type = "max_iterations_exceeded";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of WorkflowToolResponseModelInputStepsItem with <see cref="WorkflowToolResponseModelInputStepsItem.NestedTools"/>.
    /// </summary>
    public WorkflowToolResponseModelInputStepsItem(
        WorkflowToolResponseModelInputStepsItem.NestedTools value
    )
    {
        Type = "nested_tools";
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
    /// Returns true if <see cref="Type"/> is "edge"
    /// </summary>
    public bool IsEdge => Type == "edge";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "max_iterations_exceeded"
    /// </summary>
    public bool IsMaxIterationsExceeded => Type == "max_iterations_exceeded";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "nested_tools"
    /// </summary>
    public bool IsNestedTools => Type == "nested_tools";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.WorkflowToolEdgeStepModel"/> if <see cref="Type"/> is 'edge', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'edge'.</exception>
    public global::ElevenLabs.WorkflowToolEdgeStepModel AsEdge() =>
        IsEdge
            ? (global::ElevenLabs.WorkflowToolEdgeStepModel)Value!
            : throw new global::System.Exception(
                "WorkflowToolResponseModelInputStepsItem.Type is not 'edge'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.WorkflowToolMaxIterationsExceededStepModel"/> if <see cref="Type"/> is 'max_iterations_exceeded', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'max_iterations_exceeded'.</exception>
    public global::ElevenLabs.WorkflowToolMaxIterationsExceededStepModel AsMaxIterationsExceeded() =>
        IsMaxIterationsExceeded
            ? (global::ElevenLabs.WorkflowToolMaxIterationsExceededStepModel)Value!
            : throw new global::System.Exception(
                "WorkflowToolResponseModelInputStepsItem.Type is not 'max_iterations_exceeded'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.WorkflowToolNestedToolsStepModelInput"/> if <see cref="Type"/> is 'nested_tools', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'nested_tools'.</exception>
    public global::ElevenLabs.WorkflowToolNestedToolsStepModelInput AsNestedTools() =>
        IsNestedTools
            ? (global::ElevenLabs.WorkflowToolNestedToolsStepModelInput)Value!
            : throw new global::System.Exception(
                "WorkflowToolResponseModelInputStepsItem.Type is not 'nested_tools'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.WorkflowToolEdgeStepModel, T> onEdge,
        Func<
            global::ElevenLabs.WorkflowToolMaxIterationsExceededStepModel,
            T
        > onMaxIterationsExceeded,
        Func<global::ElevenLabs.WorkflowToolNestedToolsStepModelInput, T> onNestedTools,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "edge" => onEdge(AsEdge()),
            "max_iterations_exceeded" => onMaxIterationsExceeded(AsMaxIterationsExceeded()),
            "nested_tools" => onNestedTools(AsNestedTools()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.WorkflowToolEdgeStepModel> onEdge,
        Action<global::ElevenLabs.WorkflowToolMaxIterationsExceededStepModel> onMaxIterationsExceeded,
        Action<global::ElevenLabs.WorkflowToolNestedToolsStepModelInput> onNestedTools,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "edge":
                onEdge(AsEdge());
                break;
            case "max_iterations_exceeded":
                onMaxIterationsExceeded(AsMaxIterationsExceeded());
                break;
            case "nested_tools":
                onNestedTools(AsNestedTools());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.WorkflowToolEdgeStepModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsEdge(out global::ElevenLabs.WorkflowToolEdgeStepModel? value)
    {
        if (Type == "edge")
        {
            value = (global::ElevenLabs.WorkflowToolEdgeStepModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.WorkflowToolMaxIterationsExceededStepModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsMaxIterationsExceeded(
        out global::ElevenLabs.WorkflowToolMaxIterationsExceededStepModel? value
    )
    {
        if (Type == "max_iterations_exceeded")
        {
            value = (global::ElevenLabs.WorkflowToolMaxIterationsExceededStepModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.WorkflowToolNestedToolsStepModelInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsNestedTools(
        out global::ElevenLabs.WorkflowToolNestedToolsStepModelInput? value
    )
    {
        if (Type == "nested_tools")
        {
            value = (global::ElevenLabs.WorkflowToolNestedToolsStepModelInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator WorkflowToolResponseModelInputStepsItem(
        WorkflowToolResponseModelInputStepsItem.Edge value
    ) => new(value);

    public static implicit operator WorkflowToolResponseModelInputStepsItem(
        WorkflowToolResponseModelInputStepsItem.MaxIterationsExceeded value
    ) => new(value);

    public static implicit operator WorkflowToolResponseModelInputStepsItem(
        WorkflowToolResponseModelInputStepsItem.NestedTools value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<WorkflowToolResponseModelInputStepsItem>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(WorkflowToolResponseModelInputStepsItem).IsAssignableFrom(typeToConvert);

        public override WorkflowToolResponseModelInputStepsItem Read(
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
                "edge" => json.Deserialize<global::ElevenLabs.WorkflowToolEdgeStepModel?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.WorkflowToolEdgeStepModel"
                    ),
                "max_iterations_exceeded" =>
                    json.Deserialize<global::ElevenLabs.WorkflowToolMaxIterationsExceededStepModel?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.WorkflowToolMaxIterationsExceededStepModel"
                        ),
                "nested_tools" =>
                    json.Deserialize<global::ElevenLabs.WorkflowToolNestedToolsStepModelInput?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.WorkflowToolNestedToolsStepModelInput"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new WorkflowToolResponseModelInputStepsItem(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WorkflowToolResponseModelInputStepsItem value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "edge" => JsonSerializer.SerializeToNode(value.Value, options),
                    "max_iterations_exceeded" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "nested_tools" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override WorkflowToolResponseModelInputStepsItem ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new WorkflowToolResponseModelInputStepsItem(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WorkflowToolResponseModelInputStepsItem value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for edge
    /// </summary>
    [Serializable]
    public struct Edge
    {
        public Edge(global::ElevenLabs.WorkflowToolEdgeStepModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.WorkflowToolEdgeStepModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator WorkflowToolResponseModelInputStepsItem.Edge(
            global::ElevenLabs.WorkflowToolEdgeStepModel value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for max_iterations_exceeded
    /// </summary>
    [Serializable]
    public struct MaxIterationsExceeded
    {
        public MaxIterationsExceeded(
            global::ElevenLabs.WorkflowToolMaxIterationsExceededStepModel value
        )
        {
            Value = value;
        }

        internal global::ElevenLabs.WorkflowToolMaxIterationsExceededStepModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator WorkflowToolResponseModelInputStepsItem.MaxIterationsExceeded(
            global::ElevenLabs.WorkflowToolMaxIterationsExceededStepModel value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for nested_tools
    /// </summary>
    [Serializable]
    public struct NestedTools
    {
        public NestedTools(global::ElevenLabs.WorkflowToolNestedToolsStepModelInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.WorkflowToolNestedToolsStepModelInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator WorkflowToolResponseModelInputStepsItem.NestedTools(
            global::ElevenLabs.WorkflowToolNestedToolsStepModelInput value
        ) => new(value);
    }
}
