// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(WhatsAppChannelConfigModeConfig.JsonConverter))]
[Serializable]
public record WhatsAppChannelConfigModeConfig
{
    internal WhatsAppChannelConfigModeConfig(string type, object? value)
    {
        Mode = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of WhatsAppChannelConfigModeConfig with <see cref="WhatsAppChannelConfigModeConfig.Message"/>.
    /// </summary>
    public WhatsAppChannelConfigModeConfig(WhatsAppChannelConfigModeConfig.Message value)
    {
        Mode = "message";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of WhatsAppChannelConfigModeConfig with <see cref="WhatsAppChannelConfigModeConfig.Voice"/>.
    /// </summary>
    public WhatsAppChannelConfigModeConfig(WhatsAppChannelConfigModeConfig.Voice value)
    {
        Mode = "voice";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("mode")]
    public string Mode { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="Mode"/> is "message"
    /// </summary>
    public bool IsMessage => Mode == "message";

    /// <summary>
    /// Returns true if <see cref="Mode"/> is "voice"
    /// </summary>
    public bool IsVoice => Mode == "voice";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.WhatsAppMessageConfig"/> if <see cref="Mode"/> is 'message', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Mode"/> is not 'message'.</exception>
    public global::ElevenLabs.WhatsAppMessageConfig AsMessage() =>
        IsMessage
            ? (global::ElevenLabs.WhatsAppMessageConfig)Value!
            : throw new global::System.Exception(
                "WhatsAppChannelConfigModeConfig.Mode is not 'message'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.WhatsAppVoiceConfig"/> if <see cref="Mode"/> is 'voice', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Mode"/> is not 'voice'.</exception>
    public global::ElevenLabs.WhatsAppVoiceConfig AsVoice() =>
        IsVoice
            ? (global::ElevenLabs.WhatsAppVoiceConfig)Value!
            : throw new global::System.Exception(
                "WhatsAppChannelConfigModeConfig.Mode is not 'voice'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.WhatsAppMessageConfig, T> onMessage,
        Func<global::ElevenLabs.WhatsAppVoiceConfig, T> onVoice,
        Func<string, object?, T> onUnknown_
    )
    {
        return Mode switch
        {
            "message" => onMessage(AsMessage()),
            "voice" => onVoice(AsVoice()),
            _ => onUnknown_(Mode, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.WhatsAppMessageConfig> onMessage,
        Action<global::ElevenLabs.WhatsAppVoiceConfig> onVoice,
        Action<string, object?> onUnknown_
    )
    {
        switch (Mode)
        {
            case "message":
                onMessage(AsMessage());
                break;
            case "voice":
                onVoice(AsVoice());
                break;
            default:
                onUnknown_(Mode, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.WhatsAppMessageConfig"/> and returns true if successful.
    /// </summary>
    public bool TryAsMessage(out global::ElevenLabs.WhatsAppMessageConfig? value)
    {
        if (Mode == "message")
        {
            value = (global::ElevenLabs.WhatsAppMessageConfig)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.WhatsAppVoiceConfig"/> and returns true if successful.
    /// </summary>
    public bool TryAsVoice(out global::ElevenLabs.WhatsAppVoiceConfig? value)
    {
        if (Mode == "voice")
        {
            value = (global::ElevenLabs.WhatsAppVoiceConfig)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator WhatsAppChannelConfigModeConfig(
        WhatsAppChannelConfigModeConfig.Message value
    ) => new(value);

    public static implicit operator WhatsAppChannelConfigModeConfig(
        WhatsAppChannelConfigModeConfig.Voice value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<WhatsAppChannelConfigModeConfig>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(WhatsAppChannelConfigModeConfig).IsAssignableFrom(typeToConvert);

        public override WhatsAppChannelConfigModeConfig Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (!json.TryGetProperty("mode", out var discriminatorElement))
            {
                throw new JsonException("Missing discriminator property 'mode'");
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException("Discriminator property 'mode' is null");
                }

                throw new JsonException(
                    $"Discriminator property 'mode' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException("Discriminator property 'mode' is null");

            var value = discriminator switch
            {
                "message" => json.Deserialize<global::ElevenLabs.WhatsAppMessageConfig?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.WhatsAppMessageConfig"
                    ),
                "voice" => json.Deserialize<global::ElevenLabs.WhatsAppVoiceConfig?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.WhatsAppVoiceConfig"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new WhatsAppChannelConfigModeConfig(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WhatsAppChannelConfigModeConfig value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Mode switch
                {
                    "message" => JsonSerializer.SerializeToNode(value.Value, options),
                    "voice" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["mode"] = value.Mode;
            json.WriteTo(writer, options);
        }

        public override WhatsAppChannelConfigModeConfig ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new WhatsAppChannelConfigModeConfig(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WhatsAppChannelConfigModeConfig value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Mode);
        }
    }

    /// <summary>
    /// Discriminated union type for message
    /// </summary>
    [Serializable]
    public struct Message
    {
        public Message(global::ElevenLabs.WhatsAppMessageConfig value)
        {
            Value = value;
        }

        internal global::ElevenLabs.WhatsAppMessageConfig Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator WhatsAppChannelConfigModeConfig.Message(
            global::ElevenLabs.WhatsAppMessageConfig value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for voice
    /// </summary>
    [Serializable]
    public struct Voice
    {
        public Voice(global::ElevenLabs.WhatsAppVoiceConfig value)
        {
            Value = value;
        }

        internal global::ElevenLabs.WhatsAppVoiceConfig Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator WhatsAppChannelConfigModeConfig.Voice(
            global::ElevenLabs.WhatsAppVoiceConfig value
        ) => new(value);
    }
}
