// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ResponseGetAgentResponseTestByIdV1ConvaiAgentTestingTestIdGet.JsonConverter))]
[Serializable]
public record ResponseGetAgentResponseTestByIdV1ConvaiAgentTestingTestIdGet
{
    internal ResponseGetAgentResponseTestByIdV1ConvaiAgentTestingTestIdGet(
        string type,
        object? value
    )
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of ResponseGetAgentResponseTestByIdV1ConvaiAgentTestingTestIdGet with <see cref="ResponseGetAgentResponseTestByIdV1ConvaiAgentTestingTestIdGet.Llm"/>.
    /// </summary>
    public ResponseGetAgentResponseTestByIdV1ConvaiAgentTestingTestIdGet(
        ResponseGetAgentResponseTestByIdV1ConvaiAgentTestingTestIdGet.Llm value
    )
    {
        Type = "llm";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ResponseGetAgentResponseTestByIdV1ConvaiAgentTestingTestIdGet with <see cref="ResponseGetAgentResponseTestByIdV1ConvaiAgentTestingTestIdGet.Tool"/>.
    /// </summary>
    public ResponseGetAgentResponseTestByIdV1ConvaiAgentTestingTestIdGet(
        ResponseGetAgentResponseTestByIdV1ConvaiAgentTestingTestIdGet.Tool value
    )
    {
        Type = "tool";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ResponseGetAgentResponseTestByIdV1ConvaiAgentTestingTestIdGet with <see cref="ResponseGetAgentResponseTestByIdV1ConvaiAgentTestingTestIdGet.Simulation"/>.
    /// </summary>
    public ResponseGetAgentResponseTestByIdV1ConvaiAgentTestingTestIdGet(
        ResponseGetAgentResponseTestByIdV1ConvaiAgentTestingTestIdGet.Simulation value
    )
    {
        Type = "simulation";
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
    /// Returns true if <see cref="Type"/> is "llm"
    /// </summary>
    public bool IsLlm => Type == "llm";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "tool"
    /// </summary>
    public bool IsTool => Type == "tool";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "simulation"
    /// </summary>
    public bool IsSimulation => Type == "simulation";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.GetResponseUnitTestResponseModel"/> if <see cref="Type"/> is 'llm', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'llm'.</exception>
    public global::ElevenLabs.GetResponseUnitTestResponseModel AsLlm() =>
        IsLlm
            ? (global::ElevenLabs.GetResponseUnitTestResponseModel)Value!
            : throw new global::System.Exception(
                "ResponseGetAgentResponseTestByIdV1ConvaiAgentTestingTestIdGet.Type is not 'llm'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.GetToolCallUnitTestResponseModel"/> if <see cref="Type"/> is 'tool', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'tool'.</exception>
    public global::ElevenLabs.GetToolCallUnitTestResponseModel AsTool() =>
        IsTool
            ? (global::ElevenLabs.GetToolCallUnitTestResponseModel)Value!
            : throw new global::System.Exception(
                "ResponseGetAgentResponseTestByIdV1ConvaiAgentTestingTestIdGet.Type is not 'tool'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.GetSimulationTestResponseModel"/> if <see cref="Type"/> is 'simulation', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'simulation'.</exception>
    public global::ElevenLabs.GetSimulationTestResponseModel AsSimulation() =>
        IsSimulation
            ? (global::ElevenLabs.GetSimulationTestResponseModel)Value!
            : throw new global::System.Exception(
                "ResponseGetAgentResponseTestByIdV1ConvaiAgentTestingTestIdGet.Type is not 'simulation'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.GetResponseUnitTestResponseModel, T> onLlm,
        Func<global::ElevenLabs.GetToolCallUnitTestResponseModel, T> onTool,
        Func<global::ElevenLabs.GetSimulationTestResponseModel, T> onSimulation,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "llm" => onLlm(AsLlm()),
            "tool" => onTool(AsTool()),
            "simulation" => onSimulation(AsSimulation()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.GetResponseUnitTestResponseModel> onLlm,
        Action<global::ElevenLabs.GetToolCallUnitTestResponseModel> onTool,
        Action<global::ElevenLabs.GetSimulationTestResponseModel> onSimulation,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "llm":
                onLlm(AsLlm());
                break;
            case "tool":
                onTool(AsTool());
                break;
            case "simulation":
                onSimulation(AsSimulation());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.GetResponseUnitTestResponseModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsLlm(out global::ElevenLabs.GetResponseUnitTestResponseModel? value)
    {
        if (Type == "llm")
        {
            value = (global::ElevenLabs.GetResponseUnitTestResponseModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.GetToolCallUnitTestResponseModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsTool(out global::ElevenLabs.GetToolCallUnitTestResponseModel? value)
    {
        if (Type == "tool")
        {
            value = (global::ElevenLabs.GetToolCallUnitTestResponseModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.GetSimulationTestResponseModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsSimulation(out global::ElevenLabs.GetSimulationTestResponseModel? value)
    {
        if (Type == "simulation")
        {
            value = (global::ElevenLabs.GetSimulationTestResponseModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator ResponseGetAgentResponseTestByIdV1ConvaiAgentTestingTestIdGet(
        ResponseGetAgentResponseTestByIdV1ConvaiAgentTestingTestIdGet.Llm value
    ) => new(value);

    public static implicit operator ResponseGetAgentResponseTestByIdV1ConvaiAgentTestingTestIdGet(
        ResponseGetAgentResponseTestByIdV1ConvaiAgentTestingTestIdGet.Tool value
    ) => new(value);

    public static implicit operator ResponseGetAgentResponseTestByIdV1ConvaiAgentTestingTestIdGet(
        ResponseGetAgentResponseTestByIdV1ConvaiAgentTestingTestIdGet.Simulation value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<ResponseGetAgentResponseTestByIdV1ConvaiAgentTestingTestIdGet>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(ResponseGetAgentResponseTestByIdV1ConvaiAgentTestingTestIdGet).IsAssignableFrom(
                typeToConvert
            );

        public override ResponseGetAgentResponseTestByIdV1ConvaiAgentTestingTestIdGet Read(
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
                "llm" => json.Deserialize<global::ElevenLabs.GetResponseUnitTestResponseModel?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.GetResponseUnitTestResponseModel"
                    ),
                "tool" => json.Deserialize<global::ElevenLabs.GetToolCallUnitTestResponseModel?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.GetToolCallUnitTestResponseModel"
                    ),
                "simulation" =>
                    json.Deserialize<global::ElevenLabs.GetSimulationTestResponseModel?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.GetSimulationTestResponseModel"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new ResponseGetAgentResponseTestByIdV1ConvaiAgentTestingTestIdGet(
                discriminator,
                value
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ResponseGetAgentResponseTestByIdV1ConvaiAgentTestingTestIdGet value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "llm" => JsonSerializer.SerializeToNode(value.Value, options),
                    "tool" => JsonSerializer.SerializeToNode(value.Value, options),
                    "simulation" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override ResponseGetAgentResponseTestByIdV1ConvaiAgentTestingTestIdGet ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new ResponseGetAgentResponseTestByIdV1ConvaiAgentTestingTestIdGet(
                stringValue,
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ResponseGetAgentResponseTestByIdV1ConvaiAgentTestingTestIdGet value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for llm
    /// </summary>
    [Serializable]
    public struct Llm
    {
        public Llm(global::ElevenLabs.GetResponseUnitTestResponseModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.GetResponseUnitTestResponseModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ResponseGetAgentResponseTestByIdV1ConvaiAgentTestingTestIdGet.Llm(
            global::ElevenLabs.GetResponseUnitTestResponseModel value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for tool
    /// </summary>
    [Serializable]
    public struct Tool
    {
        public Tool(global::ElevenLabs.GetToolCallUnitTestResponseModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.GetToolCallUnitTestResponseModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ResponseGetAgentResponseTestByIdV1ConvaiAgentTestingTestIdGet.Tool(
            global::ElevenLabs.GetToolCallUnitTestResponseModel value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for simulation
    /// </summary>
    [Serializable]
    public struct Simulation
    {
        public Simulation(global::ElevenLabs.GetSimulationTestResponseModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.GetSimulationTestResponseModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ResponseGetAgentResponseTestByIdV1ConvaiAgentTestingTestIdGet.Simulation(
            global::ElevenLabs.GetSimulationTestResponseModel value
        ) => new(value);
    }
}
