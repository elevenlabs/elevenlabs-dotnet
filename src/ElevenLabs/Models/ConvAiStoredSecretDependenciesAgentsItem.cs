// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ConvAiStoredSecretDependenciesAgentsItem.JsonConverter))]
[Serializable]
public record ConvAiStoredSecretDependenciesAgentsItem
{
    internal ConvAiStoredSecretDependenciesAgentsItem(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of ConvAiStoredSecretDependenciesAgentsItem with <see cref="ConvAiStoredSecretDependenciesAgentsItem.Available"/>.
    /// </summary>
    public ConvAiStoredSecretDependenciesAgentsItem(
        ConvAiStoredSecretDependenciesAgentsItem.Available value
    )
    {
        Type = "available";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ConvAiStoredSecretDependenciesAgentsItem with <see cref="ConvAiStoredSecretDependenciesAgentsItem.Unknown"/>.
    /// </summary>
    public ConvAiStoredSecretDependenciesAgentsItem(
        ConvAiStoredSecretDependenciesAgentsItem.Unknown value
    )
    {
        Type = "unknown";
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
    /// Returns true if <see cref="Type"/> is "available"
    /// </summary>
    public bool IsAvailable => Type == "available";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "unknown"
    /// </summary>
    public bool IsUnknown => Type == "unknown";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.DependentAvailableAgentIdentifier"/> if <see cref="Type"/> is 'available', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'available'.</exception>
    public global::ElevenLabs.DependentAvailableAgentIdentifier AsAvailable() =>
        IsAvailable
            ? (global::ElevenLabs.DependentAvailableAgentIdentifier)Value!
            : throw new global::System.Exception(
                "ConvAiStoredSecretDependenciesAgentsItem.Type is not 'available'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.DependentUnknownAgentIdentifier"/> if <see cref="Type"/> is 'unknown', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'unknown'.</exception>
    public global::ElevenLabs.DependentUnknownAgentIdentifier AsUnknown() =>
        IsUnknown
            ? (global::ElevenLabs.DependentUnknownAgentIdentifier)Value!
            : throw new global::System.Exception(
                "ConvAiStoredSecretDependenciesAgentsItem.Type is not 'unknown'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.DependentAvailableAgentIdentifier, T> onAvailable,
        Func<global::ElevenLabs.DependentUnknownAgentIdentifier, T> onUnknown,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "available" => onAvailable(AsAvailable()),
            "unknown" => onUnknown(AsUnknown()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.DependentAvailableAgentIdentifier> onAvailable,
        Action<global::ElevenLabs.DependentUnknownAgentIdentifier> onUnknown,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "available":
                onAvailable(AsAvailable());
                break;
            case "unknown":
                onUnknown(AsUnknown());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.DependentAvailableAgentIdentifier"/> and returns true if successful.
    /// </summary>
    public bool TryAsAvailable(out global::ElevenLabs.DependentAvailableAgentIdentifier? value)
    {
        if (Type == "available")
        {
            value = (global::ElevenLabs.DependentAvailableAgentIdentifier)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.DependentUnknownAgentIdentifier"/> and returns true if successful.
    /// </summary>
    public bool TryAsUnknown(out global::ElevenLabs.DependentUnknownAgentIdentifier? value)
    {
        if (Type == "unknown")
        {
            value = (global::ElevenLabs.DependentUnknownAgentIdentifier)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator ConvAiStoredSecretDependenciesAgentsItem(
        ConvAiStoredSecretDependenciesAgentsItem.Available value
    ) => new(value);

    public static implicit operator ConvAiStoredSecretDependenciesAgentsItem(
        ConvAiStoredSecretDependenciesAgentsItem.Unknown value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<ConvAiStoredSecretDependenciesAgentsItem>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(ConvAiStoredSecretDependenciesAgentsItem).IsAssignableFrom(typeToConvert);

        public override ConvAiStoredSecretDependenciesAgentsItem Read(
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
                "available" =>
                    json.Deserialize<global::ElevenLabs.DependentAvailableAgentIdentifier?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.DependentAvailableAgentIdentifier"
                        ),
                "unknown" => json.Deserialize<global::ElevenLabs.DependentUnknownAgentIdentifier?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.DependentUnknownAgentIdentifier"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new ConvAiStoredSecretDependenciesAgentsItem(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConvAiStoredSecretDependenciesAgentsItem value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "available" => JsonSerializer.SerializeToNode(value.Value, options),
                    "unknown" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override ConvAiStoredSecretDependenciesAgentsItem ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new ConvAiStoredSecretDependenciesAgentsItem(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConvAiStoredSecretDependenciesAgentsItem value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for available
    /// </summary>
    [Serializable]
    public struct Available
    {
        public Available(global::ElevenLabs.DependentAvailableAgentIdentifier value)
        {
            Value = value;
        }

        internal global::ElevenLabs.DependentAvailableAgentIdentifier Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ConvAiStoredSecretDependenciesAgentsItem.Available(
            global::ElevenLabs.DependentAvailableAgentIdentifier value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for unknown
    /// </summary>
    [Serializable]
    public struct Unknown
    {
        public Unknown(global::ElevenLabs.DependentUnknownAgentIdentifier value)
        {
            Value = value;
        }

        internal global::ElevenLabs.DependentUnknownAgentIdentifier Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ConvAiStoredSecretDependenciesAgentsItem.Unknown(
            global::ElevenLabs.DependentUnknownAgentIdentifier value
        ) => new(value);
    }
}
