// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(TransferRuleInputProviderConfigsItem.JsonConverter))]
[Serializable]
public record TransferRuleInputProviderConfigsItem
{
    internal TransferRuleInputProviderConfigsItem(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of TransferRuleInputProviderConfigsItem with <see cref="TransferRuleInputProviderConfigsItem.Exotel"/>.
    /// </summary>
    public TransferRuleInputProviderConfigsItem(TransferRuleInputProviderConfigsItem.Exotel value)
    {
        Type = "exotel";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of TransferRuleInputProviderConfigsItem with <see cref="TransferRuleInputProviderConfigsItem.SipTrunk"/>.
    /// </summary>
    public TransferRuleInputProviderConfigsItem(TransferRuleInputProviderConfigsItem.SipTrunk value)
    {
        Type = "sip_trunk";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of TransferRuleInputProviderConfigsItem with <see cref="TransferRuleInputProviderConfigsItem.Twilio"/>.
    /// </summary>
    public TransferRuleInputProviderConfigsItem(TransferRuleInputProviderConfigsItem.Twilio value)
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
    /// Returns true if <see cref="Type"/> is "sip_trunk"
    /// </summary>
    public bool IsSipTrunk => Type == "sip_trunk";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "twilio"
    /// </summary>
    public bool IsTwilio => Type == "twilio";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ExotelTransferInput"/> if <see cref="Type"/> is 'exotel', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'exotel'.</exception>
    public global::ElevenLabs.ExotelTransferInput AsExotel() =>
        IsExotel
            ? (global::ElevenLabs.ExotelTransferInput)Value!
            : throw new global::System.Exception(
                "TransferRuleInputProviderConfigsItem.Type is not 'exotel'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SipTransferInput"/> if <see cref="Type"/> is 'sip_trunk', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'sip_trunk'.</exception>
    public global::ElevenLabs.SipTransferInput AsSipTrunk() =>
        IsSipTrunk
            ? (global::ElevenLabs.SipTransferInput)Value!
            : throw new global::System.Exception(
                "TransferRuleInputProviderConfigsItem.Type is not 'sip_trunk'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TwilioTransferInput"/> if <see cref="Type"/> is 'twilio', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'twilio'.</exception>
    public global::ElevenLabs.TwilioTransferInput AsTwilio() =>
        IsTwilio
            ? (global::ElevenLabs.TwilioTransferInput)Value!
            : throw new global::System.Exception(
                "TransferRuleInputProviderConfigsItem.Type is not 'twilio'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.ExotelTransferInput, T> onExotel,
        Func<global::ElevenLabs.SipTransferInput, T> onSipTrunk,
        Func<global::ElevenLabs.TwilioTransferInput, T> onTwilio,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "exotel" => onExotel(AsExotel()),
            "sip_trunk" => onSipTrunk(AsSipTrunk()),
            "twilio" => onTwilio(AsTwilio()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.ExotelTransferInput> onExotel,
        Action<global::ElevenLabs.SipTransferInput> onSipTrunk,
        Action<global::ElevenLabs.TwilioTransferInput> onTwilio,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "exotel":
                onExotel(AsExotel());
                break;
            case "sip_trunk":
                onSipTrunk(AsSipTrunk());
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
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ExotelTransferInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsExotel(out global::ElevenLabs.ExotelTransferInput? value)
    {
        if (Type == "exotel")
        {
            value = (global::ElevenLabs.ExotelTransferInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SipTransferInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsSipTrunk(out global::ElevenLabs.SipTransferInput? value)
    {
        if (Type == "sip_trunk")
        {
            value = (global::ElevenLabs.SipTransferInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TwilioTransferInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsTwilio(out global::ElevenLabs.TwilioTransferInput? value)
    {
        if (Type == "twilio")
        {
            value = (global::ElevenLabs.TwilioTransferInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator TransferRuleInputProviderConfigsItem(
        TransferRuleInputProviderConfigsItem.Exotel value
    ) => new(value);

    public static implicit operator TransferRuleInputProviderConfigsItem(
        TransferRuleInputProviderConfigsItem.SipTrunk value
    ) => new(value);

    public static implicit operator TransferRuleInputProviderConfigsItem(
        TransferRuleInputProviderConfigsItem.Twilio value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<TransferRuleInputProviderConfigsItem>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(TransferRuleInputProviderConfigsItem).IsAssignableFrom(typeToConvert);

        public override TransferRuleInputProviderConfigsItem Read(
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
                "exotel" => json.Deserialize<global::ElevenLabs.ExotelTransferInput?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.ExotelTransferInput"
                    ),
                "sip_trunk" => json.Deserialize<global::ElevenLabs.SipTransferInput?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.SipTransferInput"
                    ),
                "twilio" => json.Deserialize<global::ElevenLabs.TwilioTransferInput?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.TwilioTransferInput"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new TransferRuleInputProviderConfigsItem(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TransferRuleInputProviderConfigsItem value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "exotel" => JsonSerializer.SerializeToNode(value.Value, options),
                    "sip_trunk" => JsonSerializer.SerializeToNode(value.Value, options),
                    "twilio" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override TransferRuleInputProviderConfigsItem ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new TransferRuleInputProviderConfigsItem(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TransferRuleInputProviderConfigsItem value,
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
        public Exotel(global::ElevenLabs.ExotelTransferInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ExotelTransferInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator TransferRuleInputProviderConfigsItem.Exotel(
            global::ElevenLabs.ExotelTransferInput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for sip_trunk
    /// </summary>
    [Serializable]
    public struct SipTrunk
    {
        public SipTrunk(global::ElevenLabs.SipTransferInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.SipTransferInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator TransferRuleInputProviderConfigsItem.SipTrunk(
            global::ElevenLabs.SipTransferInput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for twilio
    /// </summary>
    [Serializable]
    public struct Twilio
    {
        public Twilio(global::ElevenLabs.TwilioTransferInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TwilioTransferInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator TransferRuleInputProviderConfigsItem.Twilio(
            global::ElevenLabs.TwilioTransferInput value
        ) => new(value);
    }
}
