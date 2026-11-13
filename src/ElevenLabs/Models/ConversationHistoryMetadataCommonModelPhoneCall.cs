// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ConversationHistoryMetadataCommonModelPhoneCall.JsonConverter))]
[Serializable]
public record ConversationHistoryMetadataCommonModelPhoneCall
{
    internal ConversationHistoryMetadataCommonModelPhoneCall(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of ConversationHistoryMetadataCommonModelPhoneCall with <see cref="ConversationHistoryMetadataCommonModelPhoneCall.Exotel"/>.
    /// </summary>
    public ConversationHistoryMetadataCommonModelPhoneCall(
        ConversationHistoryMetadataCommonModelPhoneCall.Exotel value
    )
    {
        Type = "exotel";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ConversationHistoryMetadataCommonModelPhoneCall with <see cref="ConversationHistoryMetadataCommonModelPhoneCall.SipTrunking"/>.
    /// </summary>
    public ConversationHistoryMetadataCommonModelPhoneCall(
        ConversationHistoryMetadataCommonModelPhoneCall.SipTrunking value
    )
    {
        Type = "sip_trunking";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ConversationHistoryMetadataCommonModelPhoneCall with <see cref="ConversationHistoryMetadataCommonModelPhoneCall.Twilio"/>.
    /// </summary>
    public ConversationHistoryMetadataCommonModelPhoneCall(
        ConversationHistoryMetadataCommonModelPhoneCall.Twilio value
    )
    {
        Type = "twilio";
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
    /// Returns true if <see cref="Type"/> is "exotel"
    /// </summary>
    public bool IsExotel => Type == "exotel";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "sip_trunking"
    /// </summary>
    public bool IsSipTrunking => Type == "sip_trunking";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "twilio"
    /// </summary>
    public bool IsTwilio => Type == "twilio";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ConversationHistoryExotelPhoneCallModel"/> if <see cref="Type"/> is 'exotel', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'exotel'.</exception>
    public global::ElevenLabs.ConversationHistoryExotelPhoneCallModel AsExotel() =>
        IsExotel
            ? (global::ElevenLabs.ConversationHistoryExotelPhoneCallModel)Value!
            : throw new global::System.Exception(
                "ConversationHistoryMetadataCommonModelPhoneCall.Type is not 'exotel'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ConversationHistorySipTrunkingPhoneCallModel"/> if <see cref="Type"/> is 'sip_trunking', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'sip_trunking'.</exception>
    public global::ElevenLabs.ConversationHistorySipTrunkingPhoneCallModel AsSipTrunking() =>
        IsSipTrunking
            ? (global::ElevenLabs.ConversationHistorySipTrunkingPhoneCallModel)Value!
            : throw new global::System.Exception(
                "ConversationHistoryMetadataCommonModelPhoneCall.Type is not 'sip_trunking'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ConversationHistoryTwilioPhoneCallModel"/> if <see cref="Type"/> is 'twilio', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'twilio'.</exception>
    public global::ElevenLabs.ConversationHistoryTwilioPhoneCallModel AsTwilio() =>
        IsTwilio
            ? (global::ElevenLabs.ConversationHistoryTwilioPhoneCallModel)Value!
            : throw new global::System.Exception(
                "ConversationHistoryMetadataCommonModelPhoneCall.Type is not 'twilio'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.ConversationHistoryExotelPhoneCallModel, T> onExotel,
        Func<global::ElevenLabs.ConversationHistorySipTrunkingPhoneCallModel, T> onSipTrunking,
        Func<global::ElevenLabs.ConversationHistoryTwilioPhoneCallModel, T> onTwilio,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "exotel" => onExotel(AsExotel()),
            "sip_trunking" => onSipTrunking(AsSipTrunking()),
            "twilio" => onTwilio(AsTwilio()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.ConversationHistoryExotelPhoneCallModel> onExotel,
        Action<global::ElevenLabs.ConversationHistorySipTrunkingPhoneCallModel> onSipTrunking,
        Action<global::ElevenLabs.ConversationHistoryTwilioPhoneCallModel> onTwilio,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "exotel":
                onExotel(AsExotel());
                break;
            case "sip_trunking":
                onSipTrunking(AsSipTrunking());
                break;
            case "twilio":
                onTwilio(AsTwilio());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ConversationHistoryExotelPhoneCallModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsExotel(out global::ElevenLabs.ConversationHistoryExotelPhoneCallModel? value)
    {
        if (Type == "exotel")
        {
            value = (global::ElevenLabs.ConversationHistoryExotelPhoneCallModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ConversationHistorySipTrunkingPhoneCallModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsSipTrunking(
        out global::ElevenLabs.ConversationHistorySipTrunkingPhoneCallModel? value
    )
    {
        if (Type == "sip_trunking")
        {
            value = (global::ElevenLabs.ConversationHistorySipTrunkingPhoneCallModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ConversationHistoryTwilioPhoneCallModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsTwilio(out global::ElevenLabs.ConversationHistoryTwilioPhoneCallModel? value)
    {
        if (Type == "twilio")
        {
            value = (global::ElevenLabs.ConversationHistoryTwilioPhoneCallModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator ConversationHistoryMetadataCommonModelPhoneCall(
        ConversationHistoryMetadataCommonModelPhoneCall.Exotel value
    ) => new(value);

    public static implicit operator ConversationHistoryMetadataCommonModelPhoneCall(
        ConversationHistoryMetadataCommonModelPhoneCall.SipTrunking value
    ) => new(value);

    public static implicit operator ConversationHistoryMetadataCommonModelPhoneCall(
        ConversationHistoryMetadataCommonModelPhoneCall.Twilio value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<ConversationHistoryMetadataCommonModelPhoneCall>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(ConversationHistoryMetadataCommonModelPhoneCall).IsAssignableFrom(typeToConvert);

        public override ConversationHistoryMetadataCommonModelPhoneCall Read(
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
                "exotel" =>
                    json.Deserialize<global::ElevenLabs.ConversationHistoryExotelPhoneCallModel?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.ConversationHistoryExotelPhoneCallModel"
                        ),
                "sip_trunking" =>
                    json.Deserialize<global::ElevenLabs.ConversationHistorySipTrunkingPhoneCallModel?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.ConversationHistorySipTrunkingPhoneCallModel"
                        ),
                "twilio" =>
                    json.Deserialize<global::ElevenLabs.ConversationHistoryTwilioPhoneCallModel?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.ConversationHistoryTwilioPhoneCallModel"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new ConversationHistoryMetadataCommonModelPhoneCall(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConversationHistoryMetadataCommonModelPhoneCall value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "exotel" => JsonSerializer.SerializeToNode(value.Value, options),
                    "sip_trunking" => JsonSerializer.SerializeToNode(value.Value, options),
                    "twilio" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override ConversationHistoryMetadataCommonModelPhoneCall ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new ConversationHistoryMetadataCommonModelPhoneCall(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConversationHistoryMetadataCommonModelPhoneCall value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for exotel
    /// </summary>
    [Serializable]
    public struct Exotel
    {
        public Exotel(global::ElevenLabs.ConversationHistoryExotelPhoneCallModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ConversationHistoryExotelPhoneCallModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ConversationHistoryMetadataCommonModelPhoneCall.Exotel(
            global::ElevenLabs.ConversationHistoryExotelPhoneCallModel value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for sip_trunking
    /// </summary>
    [Serializable]
    public struct SipTrunking
    {
        public SipTrunking(global::ElevenLabs.ConversationHistorySipTrunkingPhoneCallModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ConversationHistorySipTrunkingPhoneCallModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ConversationHistoryMetadataCommonModelPhoneCall.SipTrunking(
            global::ElevenLabs.ConversationHistorySipTrunkingPhoneCallModel value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for twilio
    /// </summary>
    [Serializable]
    public struct Twilio
    {
        public Twilio(global::ElevenLabs.ConversationHistoryTwilioPhoneCallModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ConversationHistoryTwilioPhoneCallModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ConversationHistoryMetadataCommonModelPhoneCall.Twilio(
            global::ElevenLabs.ConversationHistoryTwilioPhoneCallModel value
        ) => new(value);
    }
}
