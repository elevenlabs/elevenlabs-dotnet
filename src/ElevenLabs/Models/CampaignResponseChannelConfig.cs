// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(CampaignResponseChannelConfig.JsonConverter))]
[Serializable]
public record CampaignResponseChannelConfig
{
    internal CampaignResponseChannelConfig(string type, object? value)
    {
        Channel = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of CampaignResponseChannelConfig with <see cref="CampaignResponseChannelConfig.Phone"/>.
    /// </summary>
    public CampaignResponseChannelConfig(CampaignResponseChannelConfig.Phone value)
    {
        Channel = "phone";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of CampaignResponseChannelConfig with <see cref="CampaignResponseChannelConfig.Whatsapp"/>.
    /// </summary>
    public CampaignResponseChannelConfig(CampaignResponseChannelConfig.Whatsapp value)
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
    /// Returns the value as a <see cref="global::ElevenLabs.PhoneChannelConfigOutput"/> if <see cref="Channel"/> is 'phone', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Channel"/> is not 'phone'.</exception>
    public global::ElevenLabs.PhoneChannelConfigOutput AsPhone() =>
        IsPhone
            ? (global::ElevenLabs.PhoneChannelConfigOutput)Value!
            : throw new global::System.Exception(
                "CampaignResponseChannelConfig.Channel is not 'phone'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.WhatsAppChannelConfig"/> if <see cref="Channel"/> is 'whatsapp', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Channel"/> is not 'whatsapp'.</exception>
    public global::ElevenLabs.WhatsAppChannelConfig AsWhatsapp() =>
        IsWhatsapp
            ? (global::ElevenLabs.WhatsAppChannelConfig)Value!
            : throw new global::System.Exception(
                "CampaignResponseChannelConfig.Channel is not 'whatsapp'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.PhoneChannelConfigOutput, T> onPhone,
        Func<global::ElevenLabs.WhatsAppChannelConfig, T> onWhatsapp,
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
        Action<global::ElevenLabs.PhoneChannelConfigOutput> onPhone,
        Action<global::ElevenLabs.WhatsAppChannelConfig> onWhatsapp,
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
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.PhoneChannelConfigOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsPhone(out global::ElevenLabs.PhoneChannelConfigOutput? value)
    {
        if (Channel == "phone")
        {
            value = (global::ElevenLabs.PhoneChannelConfigOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.WhatsAppChannelConfig"/> and returns true if successful.
    /// </summary>
    public bool TryAsWhatsapp(out global::ElevenLabs.WhatsAppChannelConfig? value)
    {
        if (Channel == "whatsapp")
        {
            value = (global::ElevenLabs.WhatsAppChannelConfig)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator CampaignResponseChannelConfig(
        CampaignResponseChannelConfig.Phone value
    ) => new(value);

    public static implicit operator CampaignResponseChannelConfig(
        CampaignResponseChannelConfig.Whatsapp value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<CampaignResponseChannelConfig>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(CampaignResponseChannelConfig).IsAssignableFrom(typeToConvert);

        public override CampaignResponseChannelConfig Read(
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
                "phone" => json.Deserialize<global::ElevenLabs.PhoneChannelConfigOutput?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.PhoneChannelConfigOutput"
                    ),
                "whatsapp" => json.Deserialize<global::ElevenLabs.WhatsAppChannelConfig?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.WhatsAppChannelConfig"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new CampaignResponseChannelConfig(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CampaignResponseChannelConfig value,
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

        public override CampaignResponseChannelConfig ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new CampaignResponseChannelConfig(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CampaignResponseChannelConfig value,
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
        public Phone(global::ElevenLabs.PhoneChannelConfigOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.PhoneChannelConfigOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator CampaignResponseChannelConfig.Phone(
            global::ElevenLabs.PhoneChannelConfigOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for whatsapp
    /// </summary>
    [Serializable]
    public struct Whatsapp
    {
        public Whatsapp(global::ElevenLabs.WhatsAppChannelConfig value)
        {
            Value = value;
        }

        internal global::ElevenLabs.WhatsAppChannelConfig Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator CampaignResponseChannelConfig.Whatsapp(
            global::ElevenLabs.WhatsAppChannelConfig value
        ) => new(value);
    }
}
