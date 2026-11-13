// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Agents;

[JsonConverter(typeof(SubmitCampaignRequestChannelConfig.JsonConverter))]
[Serializable]
public record SubmitCampaignRequestChannelConfig
{
    internal SubmitCampaignRequestChannelConfig(string type, object? value)
    {
        Channel = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of SubmitCampaignRequestChannelConfig with <see cref="SubmitCampaignRequestChannelConfig.Phone"/>.
    /// </summary>
    public SubmitCampaignRequestChannelConfig(SubmitCampaignRequestChannelConfig.Phone value)
    {
        Channel = "phone";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SubmitCampaignRequestChannelConfig with <see cref="SubmitCampaignRequestChannelConfig.Whatsapp"/>.
    /// </summary>
    public SubmitCampaignRequestChannelConfig(SubmitCampaignRequestChannelConfig.Whatsapp value)
    {
        Channel = "whatsapp";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("channel")]
    public string Channel { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="Channel"/> is "phone"
    /// </summary>
    public bool IsPhone => Channel == "phone";

    /// <summary>
    /// Returns true if <see cref="Channel"/> is "whatsapp"
    /// </summary>
    public bool IsWhatsapp => Channel == "whatsapp";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.PhoneChannelConfigInput"/> if <see cref="Channel"/> is 'phone', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Channel"/> is not 'phone'.</exception>
    public global::ElevenLabs.PhoneChannelConfigInput AsPhone() =>
        IsPhone
            ? (global::ElevenLabs.PhoneChannelConfigInput)Value!
            : throw new global::System.Exception(
                "SubmitCampaignRequestChannelConfig.Channel is not 'phone'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SubmitWhatsAppChannelConfig"/> if <see cref="Channel"/> is 'whatsapp', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Channel"/> is not 'whatsapp'.</exception>
    public global::ElevenLabs.SubmitWhatsAppChannelConfig AsWhatsapp() =>
        IsWhatsapp
            ? (global::ElevenLabs.SubmitWhatsAppChannelConfig)Value!
            : throw new global::System.Exception(
                "SubmitCampaignRequestChannelConfig.Channel is not 'whatsapp'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.PhoneChannelConfigInput, T> onPhone,
        Func<global::ElevenLabs.SubmitWhatsAppChannelConfig, T> onWhatsapp,
        Func<string, object?, T> onUnknown_
    )
    {
        return Channel switch
        {
            "phone" => onPhone(AsPhone()),
            "whatsapp" => onWhatsapp(AsWhatsapp()),
            _ => onUnknown_(Channel, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.PhoneChannelConfigInput> onPhone,
        Action<global::ElevenLabs.SubmitWhatsAppChannelConfig> onWhatsapp,
        Action<string, object?> onUnknown_
    )
    {
        switch (Channel)
        {
            case "phone":
                onPhone(AsPhone());
                break;
            case "whatsapp":
                onWhatsapp(AsWhatsapp());
                break;
            default:
                onUnknown_(Channel, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.PhoneChannelConfigInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsPhone(out global::ElevenLabs.PhoneChannelConfigInput? value)
    {
        if (Channel == "phone")
        {
            value = (global::ElevenLabs.PhoneChannelConfigInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SubmitWhatsAppChannelConfig"/> and returns true if successful.
    /// </summary>
    public bool TryAsWhatsapp(out global::ElevenLabs.SubmitWhatsAppChannelConfig? value)
    {
        if (Channel == "whatsapp")
        {
            value = (global::ElevenLabs.SubmitWhatsAppChannelConfig)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator SubmitCampaignRequestChannelConfig(
        SubmitCampaignRequestChannelConfig.Phone value
    ) => new(value);

    public static implicit operator SubmitCampaignRequestChannelConfig(
        SubmitCampaignRequestChannelConfig.Whatsapp value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<SubmitCampaignRequestChannelConfig>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(SubmitCampaignRequestChannelConfig).IsAssignableFrom(typeToConvert);

        public override SubmitCampaignRequestChannelConfig Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (!json.TryGetProperty("channel", out var discriminatorElement))
            {
                throw new JsonException("Missing discriminator property 'channel'");
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException("Discriminator property 'channel' is null");
                }

                throw new JsonException(
                    $"Discriminator property 'channel' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException("Discriminator property 'channel' is null");

            var value = discriminator switch
            {
                "phone" => json.Deserialize<global::ElevenLabs.PhoneChannelConfigInput?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.PhoneChannelConfigInput"
                    ),
                "whatsapp" => json.Deserialize<global::ElevenLabs.SubmitWhatsAppChannelConfig?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.SubmitWhatsAppChannelConfig"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new SubmitCampaignRequestChannelConfig(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SubmitCampaignRequestChannelConfig value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Channel switch
                {
                    "phone" => JsonSerializer.SerializeToNode(value.Value, options),
                    "whatsapp" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["channel"] = value.Channel;
            json.WriteTo(writer, options);
        }

        public override SubmitCampaignRequestChannelConfig ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new SubmitCampaignRequestChannelConfig(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SubmitCampaignRequestChannelConfig value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Channel);
        }
    }

    /// <summary>
    /// Discriminated union type for phone
    /// </summary>
    [Serializable]
    public struct Phone
    {
        public Phone(global::ElevenLabs.PhoneChannelConfigInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.PhoneChannelConfigInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SubmitCampaignRequestChannelConfig.Phone(
            global::ElevenLabs.PhoneChannelConfigInput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for whatsapp
    /// </summary>
    [Serializable]
    public struct Whatsapp
    {
        public Whatsapp(global::ElevenLabs.SubmitWhatsAppChannelConfig value)
        {
            Value = value;
        }

        internal global::ElevenLabs.SubmitWhatsAppChannelConfig Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SubmitCampaignRequestChannelConfig.Whatsapp(
            global::ElevenLabs.SubmitWhatsAppChannelConfig value
        ) => new(value);
    }
}
