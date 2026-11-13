// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(UnitTestRunResponseModelTestInfo.JsonConverter))]
[Serializable]
public record UnitTestRunResponseModelTestInfo
{
    internal UnitTestRunResponseModelTestInfo(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of UnitTestRunResponseModelTestInfo with <see cref="UnitTestRunResponseModelTestInfo.Llm"/>.
    /// </summary>
    public UnitTestRunResponseModelTestInfo(UnitTestRunResponseModelTestInfo.Llm value)
    {
        Type = "llm";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of UnitTestRunResponseModelTestInfo with <see cref="UnitTestRunResponseModelTestInfo.Simulation"/>.
    /// </summary>
    public UnitTestRunResponseModelTestInfo(UnitTestRunResponseModelTestInfo.Simulation value)
    {
        Type = "simulation";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of UnitTestRunResponseModelTestInfo with <see cref="UnitTestRunResponseModelTestInfo.Tool"/>.
    /// </summary>
    public UnitTestRunResponseModelTestInfo(UnitTestRunResponseModelTestInfo.Tool value)
    {
        Type = "tool";
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
    /// Returns true if <see cref="Type"/> is "simulation"
    /// </summary>
    public bool IsSimulation => Type == "simulation";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "tool"
    /// </summary>
    public bool IsTool => Type == "tool";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ResponseUnitTestModel"/> if <see cref="Type"/> is 'llm', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'llm'.</exception>
    public global::ElevenLabs.ResponseUnitTestModel AsLlm() =>
        IsLlm
            ? (global::ElevenLabs.ResponseUnitTestModel)Value!
            : throw new global::System.Exception(
                "UnitTestRunResponseModelTestInfo.Type is not 'llm'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SimulationTestModel"/> if <see cref="Type"/> is 'simulation', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'simulation'.</exception>
    public global::ElevenLabs.SimulationTestModel AsSimulation() =>
        IsSimulation
            ? (global::ElevenLabs.SimulationTestModel)Value!
            : throw new global::System.Exception(
                "UnitTestRunResponseModelTestInfo.Type is not 'simulation'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ToolCallUnitTestModel"/> if <see cref="Type"/> is 'tool', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'tool'.</exception>
    public global::ElevenLabs.ToolCallUnitTestModel AsTool() =>
        IsTool
            ? (global::ElevenLabs.ToolCallUnitTestModel)Value!
            : throw new global::System.Exception(
                "UnitTestRunResponseModelTestInfo.Type is not 'tool'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.ResponseUnitTestModel, T> onLlm,
        Func<global::ElevenLabs.SimulationTestModel, T> onSimulation,
        Func<global::ElevenLabs.ToolCallUnitTestModel, T> onTool,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "llm" => onLlm(AsLlm()),
            "simulation" => onSimulation(AsSimulation()),
            "tool" => onTool(AsTool()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.ResponseUnitTestModel> onLlm,
        Action<global::ElevenLabs.SimulationTestModel> onSimulation,
        Action<global::ElevenLabs.ToolCallUnitTestModel> onTool,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "llm":
                onLlm(AsLlm());
                break;
            case "simulation":
                onSimulation(AsSimulation());
                break;
            case "tool":
                onTool(AsTool());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ResponseUnitTestModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsLlm(out global::ElevenLabs.ResponseUnitTestModel? value)
    {
        if (Type == "llm")
        {
            value = (global::ElevenLabs.ResponseUnitTestModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SimulationTestModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsSimulation(out global::ElevenLabs.SimulationTestModel? value)
    {
        if (Type == "simulation")
        {
            value = (global::ElevenLabs.SimulationTestModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ToolCallUnitTestModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsTool(out global::ElevenLabs.ToolCallUnitTestModel? value)
    {
        if (Type == "tool")
        {
            value = (global::ElevenLabs.ToolCallUnitTestModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator UnitTestRunResponseModelTestInfo(
        UnitTestRunResponseModelTestInfo.Llm value
    ) => new(value);

    public static implicit operator UnitTestRunResponseModelTestInfo(
        UnitTestRunResponseModelTestInfo.Simulation value
    ) => new(value);

    public static implicit operator UnitTestRunResponseModelTestInfo(
        UnitTestRunResponseModelTestInfo.Tool value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<UnitTestRunResponseModelTestInfo>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(UnitTestRunResponseModelTestInfo).IsAssignableFrom(typeToConvert);

        public override UnitTestRunResponseModelTestInfo Read(
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
                "llm" => json.Deserialize<global::ElevenLabs.ResponseUnitTestModel?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.ResponseUnitTestModel"
                    ),
                "simulation" => json.Deserialize<global::ElevenLabs.SimulationTestModel?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.SimulationTestModel"
                    ),
                "tool" => json.Deserialize<global::ElevenLabs.ToolCallUnitTestModel?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.ToolCallUnitTestModel"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new UnitTestRunResponseModelTestInfo(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UnitTestRunResponseModelTestInfo value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "llm" => JsonSerializer.SerializeToNode(value.Value, options),
                    "simulation" => JsonSerializer.SerializeToNode(value.Value, options),
                    "tool" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override UnitTestRunResponseModelTestInfo ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new UnitTestRunResponseModelTestInfo(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UnitTestRunResponseModelTestInfo value,
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
        public Llm(global::ElevenLabs.ResponseUnitTestModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ResponseUnitTestModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator UnitTestRunResponseModelTestInfo.Llm(
            global::ElevenLabs.ResponseUnitTestModel value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for simulation
    /// </summary>
    [Serializable]
    public struct Simulation
    {
        public Simulation(global::ElevenLabs.SimulationTestModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.SimulationTestModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator UnitTestRunResponseModelTestInfo.Simulation(
            global::ElevenLabs.SimulationTestModel value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for tool
    /// </summary>
    [Serializable]
    public struct Tool
    {
        public Tool(global::ElevenLabs.ToolCallUnitTestModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ToolCallUnitTestModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator UnitTestRunResponseModelTestInfo.Tool(
            global::ElevenLabs.ToolCallUnitTestModel value
        ) => new(value);
    }
}
