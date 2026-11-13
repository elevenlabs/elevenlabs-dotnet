// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Agents.McpServers;

[JsonConverter(typeof(McpToolConfigOverrideUpdateRequestModelInputOverrides.JsonConverter))]
[Serializable]
public record McpToolConfigOverrideUpdateRequestModelInputOverrides
{
    internal McpToolConfigOverrideUpdateRequestModelInputOverrides(string type, object? value)
    {
        Source = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of McpToolConfigOverrideUpdateRequestModelInputOverrides with <see cref="McpToolConfigOverrideUpdateRequestModelInputOverrides.Constant"/>.
    /// </summary>
    public McpToolConfigOverrideUpdateRequestModelInputOverrides(
        McpToolConfigOverrideUpdateRequestModelInputOverrides.Constant value
    )
    {
        Source = "constant";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of McpToolConfigOverrideUpdateRequestModelInputOverrides with <see cref="McpToolConfigOverrideUpdateRequestModelInputOverrides.DynamicVariable"/>.
    /// </summary>
    public McpToolConfigOverrideUpdateRequestModelInputOverrides(
        McpToolConfigOverrideUpdateRequestModelInputOverrides.DynamicVariable value
    )
    {
        Source = "dynamic_variable";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of McpToolConfigOverrideUpdateRequestModelInputOverrides with <see cref="McpToolConfigOverrideUpdateRequestModelInputOverrides.Llm"/>.
    /// </summary>
    public McpToolConfigOverrideUpdateRequestModelInputOverrides(
        McpToolConfigOverrideUpdateRequestModelInputOverrides.Llm value
    )
    {
        Source = "llm";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of McpToolConfigOverrideUpdateRequestModelInputOverrides with <see cref="McpToolConfigOverrideUpdateRequestModelInputOverrides.Omit"/>.
    /// </summary>
    public McpToolConfigOverrideUpdateRequestModelInputOverrides(
        McpToolConfigOverrideUpdateRequestModelInputOverrides.Omit value
    )
    {
        Source = "omit";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("source")]
    public string Source { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="Source"/> is "constant"
    /// </summary>
    public bool IsConstant => Source == "constant";

    /// <summary>
    /// Returns true if <see cref="Source"/> is "dynamic_variable"
    /// </summary>
    public bool IsDynamicVariable => Source == "dynamic_variable";

    /// <summary>
    /// Returns true if <see cref="Source"/> is "llm"
    /// </summary>
    public bool IsLlm => Source == "llm";

    /// <summary>
    /// Returns true if <see cref="Source"/> is "omit"
    /// </summary>
    public bool IsOmit => Source == "omit";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ConstantSchemaOverride"/> if <see cref="Source"/> is 'constant', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Source"/> is not 'constant'.</exception>
    public global::ElevenLabs.ConstantSchemaOverride AsConstant() =>
        IsConstant
            ? (global::ElevenLabs.ConstantSchemaOverride)Value!
            : throw new global::System.Exception(
                "McpToolConfigOverrideUpdateRequestModelInputOverrides.Source is not 'constant'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.DynamicVariableSchemaOverride"/> if <see cref="Source"/> is 'dynamic_variable', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Source"/> is not 'dynamic_variable'.</exception>
    public global::ElevenLabs.DynamicVariableSchemaOverride AsDynamicVariable() =>
        IsDynamicVariable
            ? (global::ElevenLabs.DynamicVariableSchemaOverride)Value!
            : throw new global::System.Exception(
                "McpToolConfigOverrideUpdateRequestModelInputOverrides.Source is not 'dynamic_variable'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.LlmSchemaOverride"/> if <see cref="Source"/> is 'llm', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Source"/> is not 'llm'.</exception>
    public global::ElevenLabs.LlmSchemaOverride AsLlm() =>
        IsLlm
            ? (global::ElevenLabs.LlmSchemaOverride)Value!
            : throw new global::System.Exception(
                "McpToolConfigOverrideUpdateRequestModelInputOverrides.Source is not 'llm'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.OmitSchemaOverride"/> if <see cref="Source"/> is 'omit', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Source"/> is not 'omit'.</exception>
    public global::ElevenLabs.OmitSchemaOverride AsOmit() =>
        IsOmit
            ? (global::ElevenLabs.OmitSchemaOverride)Value!
            : throw new global::System.Exception(
                "McpToolConfigOverrideUpdateRequestModelInputOverrides.Source is not 'omit'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.ConstantSchemaOverride, T> onConstant,
        Func<global::ElevenLabs.DynamicVariableSchemaOverride, T> onDynamicVariable,
        Func<global::ElevenLabs.LlmSchemaOverride, T> onLlm,
        Func<global::ElevenLabs.OmitSchemaOverride, T> onOmit,
        Func<string, object?, T> onUnknown_
    )
    {
        return Source switch
        {
            "constant" => onConstant(AsConstant()),
            "dynamic_variable" => onDynamicVariable(AsDynamicVariable()),
            "llm" => onLlm(AsLlm()),
            "omit" => onOmit(AsOmit()),
            _ => onUnknown_(Source, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.ConstantSchemaOverride> onConstant,
        Action<global::ElevenLabs.DynamicVariableSchemaOverride> onDynamicVariable,
        Action<global::ElevenLabs.LlmSchemaOverride> onLlm,
        Action<global::ElevenLabs.OmitSchemaOverride> onOmit,
        Action<string, object?> onUnknown_
    )
    {
        switch (Source)
        {
            case "constant":
                onConstant(AsConstant());
                break;
            case "dynamic_variable":
                onDynamicVariable(AsDynamicVariable());
                break;
            case "llm":
                onLlm(AsLlm());
                break;
            case "omit":
                onOmit(AsOmit());
                break;
            default:
                onUnknown_(Source, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ConstantSchemaOverride"/> and returns true if successful.
    /// </summary>
    public bool TryAsConstant(out global::ElevenLabs.ConstantSchemaOverride? value)
    {
        if (Source == "constant")
        {
            value = (global::ElevenLabs.ConstantSchemaOverride)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.DynamicVariableSchemaOverride"/> and returns true if successful.
    /// </summary>
    public bool TryAsDynamicVariable(out global::ElevenLabs.DynamicVariableSchemaOverride? value)
    {
        if (Source == "dynamic_variable")
        {
            value = (global::ElevenLabs.DynamicVariableSchemaOverride)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.LlmSchemaOverride"/> and returns true if successful.
    /// </summary>
    public bool TryAsLlm(out global::ElevenLabs.LlmSchemaOverride? value)
    {
        if (Source == "llm")
        {
            value = (global::ElevenLabs.LlmSchemaOverride)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.OmitSchemaOverride"/> and returns true if successful.
    /// </summary>
    public bool TryAsOmit(out global::ElevenLabs.OmitSchemaOverride? value)
    {
        if (Source == "omit")
        {
            value = (global::ElevenLabs.OmitSchemaOverride)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator McpToolConfigOverrideUpdateRequestModelInputOverrides(
        McpToolConfigOverrideUpdateRequestModelInputOverrides.Constant value
    ) => new(value);

    public static implicit operator McpToolConfigOverrideUpdateRequestModelInputOverrides(
        McpToolConfigOverrideUpdateRequestModelInputOverrides.DynamicVariable value
    ) => new(value);

    public static implicit operator McpToolConfigOverrideUpdateRequestModelInputOverrides(
        McpToolConfigOverrideUpdateRequestModelInputOverrides.Llm value
    ) => new(value);

    public static implicit operator McpToolConfigOverrideUpdateRequestModelInputOverrides(
        McpToolConfigOverrideUpdateRequestModelInputOverrides.Omit value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<McpToolConfigOverrideUpdateRequestModelInputOverrides>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(McpToolConfigOverrideUpdateRequestModelInputOverrides).IsAssignableFrom(
                typeToConvert
            );

        public override McpToolConfigOverrideUpdateRequestModelInputOverrides Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (!json.TryGetProperty("source", out var discriminatorElement))
            {
                throw new JsonException("Missing discriminator property 'source'");
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException("Discriminator property 'source' is null");
                }

                throw new JsonException(
                    $"Discriminator property 'source' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException("Discriminator property 'source' is null");

            var value = discriminator switch
            {
                "constant" => json.Deserialize<global::ElevenLabs.ConstantSchemaOverride?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.ConstantSchemaOverride"
                    ),
                "dynamic_variable" =>
                    json.Deserialize<global::ElevenLabs.DynamicVariableSchemaOverride?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.DynamicVariableSchemaOverride"
                        ),
                "llm" => json.Deserialize<global::ElevenLabs.LlmSchemaOverride?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.LlmSchemaOverride"
                    ),
                "omit" => json.Deserialize<global::ElevenLabs.OmitSchemaOverride?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.OmitSchemaOverride"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new McpToolConfigOverrideUpdateRequestModelInputOverrides(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            McpToolConfigOverrideUpdateRequestModelInputOverrides value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Source switch
                {
                    "constant" => JsonSerializer.SerializeToNode(value.Value, options),
                    "dynamic_variable" => JsonSerializer.SerializeToNode(value.Value, options),
                    "llm" => JsonSerializer.SerializeToNode(value.Value, options),
                    "omit" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["source"] = value.Source;
            json.WriteTo(writer, options);
        }

        public override McpToolConfigOverrideUpdateRequestModelInputOverrides ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new McpToolConfigOverrideUpdateRequestModelInputOverrides(
                stringValue,
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            McpToolConfigOverrideUpdateRequestModelInputOverrides value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Source);
        }
    }

    /// <summary>
    /// Discriminated union type for constant
    /// </summary>
    [Serializable]
    public struct Constant
    {
        public Constant(global::ElevenLabs.ConstantSchemaOverride value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ConstantSchemaOverride Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator McpToolConfigOverrideUpdateRequestModelInputOverrides.Constant(
            global::ElevenLabs.ConstantSchemaOverride value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for dynamic_variable
    /// </summary>
    [Serializable]
    public struct DynamicVariable
    {
        public DynamicVariable(global::ElevenLabs.DynamicVariableSchemaOverride value)
        {
            Value = value;
        }

        internal global::ElevenLabs.DynamicVariableSchemaOverride Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator McpToolConfigOverrideUpdateRequestModelInputOverrides.DynamicVariable(
            global::ElevenLabs.DynamicVariableSchemaOverride value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for llm
    /// </summary>
    [Serializable]
    public struct Llm
    {
        public Llm(global::ElevenLabs.LlmSchemaOverride value)
        {
            Value = value;
        }

        internal global::ElevenLabs.LlmSchemaOverride Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator McpToolConfigOverrideUpdateRequestModelInputOverrides.Llm(
            global::ElevenLabs.LlmSchemaOverride value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for omit
    /// </summary>
    [Serializable]
    public struct Omit
    {
        public Omit(global::ElevenLabs.OmitSchemaOverride value)
        {
            Value = value;
        }

        internal global::ElevenLabs.OmitSchemaOverride Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator McpToolConfigOverrideUpdateRequestModelInputOverrides.Omit(
            global::ElevenLabs.OmitSchemaOverride value
        ) => new(value);
    }
}
