// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(TransferRuleOutputProviderConfigsItem.JsonConverter))]
[Serializable]
public record TransferRuleOutputProviderConfigsItem
{
    internal TransferRuleOutputProviderConfigsItem(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of TransferRuleOutputProviderConfigsItem with <see cref="TransferRuleOutputProviderConfigsItem.Exotel"/>.
    /// </summary>
    public TransferRuleOutputProviderConfigsItem(TransferRuleOutputProviderConfigsItem.Exotel value)
    {
        Type = "exotel";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of TransferRuleOutputProviderConfigsItem with <see cref="TransferRuleOutputProviderConfigsItem.SipTrunk"/>.
    /// </summary>
    public TransferRuleOutputProviderConfigsItem(
        TransferRuleOutputProviderConfigsItem.SipTrunk value
    )
    {
        Type = "sip_trunk";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of TransferRuleOutputProviderConfigsItem with <see cref="TransferRuleOutputProviderConfigsItem.Twilio"/>.
    /// </summary>
    public TransferRuleOutputProviderConfigsItem(TransferRuleOutputProviderConfigsItem.Twilio value)
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
    /// Returns the value as a <see cref="global::ElevenLabs.ExotelTransferOutput"/> if <see cref="Type"/> is 'exotel', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'exotel'.</exception>
    public global::ElevenLabs.ExotelTransferOutput AsExotel() =>
        IsExotel
            ? (global::ElevenLabs.ExotelTransferOutput)Value!
            : throw new global::System.Exception(
                "TransferRuleOutputProviderConfigsItem.Type is not 'exotel'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SipTransferOutput"/> if <see cref="Type"/> is 'sip_trunk', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'sip_trunk'.</exception>
    public global::ElevenLabs.SipTransferOutput AsSipTrunk() =>
        IsSipTrunk
            ? (global::ElevenLabs.SipTransferOutput)Value!
            : throw new global::System.Exception(
                "TransferRuleOutputProviderConfigsItem.Type is not 'sip_trunk'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TwilioTransferOutput"/> if <see cref="Type"/> is 'twilio', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'twilio'.</exception>
    public global::ElevenLabs.TwilioTransferOutput AsTwilio() =>
        IsTwilio
            ? (global::ElevenLabs.TwilioTransferOutput)Value!
            : throw new global::System.Exception(
                "TransferRuleOutputProviderConfigsItem.Type is not 'twilio'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.ExotelTransferOutput, T> onExotel,
        Func<global::ElevenLabs.SipTransferOutput, T> onSipTrunk,
        Func<global::ElevenLabs.TwilioTransferOutput, T> onTwilio,
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
        Action<global::ElevenLabs.ExotelTransferOutput> onExotel,
        Action<global::ElevenLabs.SipTransferOutput> onSipTrunk,
        Action<global::ElevenLabs.TwilioTransferOutput> onTwilio,
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
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ExotelTransferOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsExotel(out global::ElevenLabs.ExotelTransferOutput? value)
    {
        if (Type == "exotel")
        {
            value = (global::ElevenLabs.ExotelTransferOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SipTransferOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsSipTrunk(out global::ElevenLabs.SipTransferOutput? value)
    {
        if (Type == "sip_trunk")
        {
            value = (global::ElevenLabs.SipTransferOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TwilioTransferOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsTwilio(out global::ElevenLabs.TwilioTransferOutput? value)
    {
        if (Type == "twilio")
        {
            value = (global::ElevenLabs.TwilioTransferOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator TransferRuleOutputProviderConfigsItem(
        TransferRuleOutputProviderConfigsItem.Exotel value
    ) => new(value);

    public static implicit operator TransferRuleOutputProviderConfigsItem(
        TransferRuleOutputProviderConfigsItem.SipTrunk value
    ) => new(value);

    public static implicit operator TransferRuleOutputProviderConfigsItem(
        TransferRuleOutputProviderConfigsItem.Twilio value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<TransferRuleOutputProviderConfigsItem>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(TransferRuleOutputProviderConfigsItem).IsAssignableFrom(typeToConvert);

        public override TransferRuleOutputProviderConfigsItem Read(
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
                "exotel" => json.Deserialize<global::ElevenLabs.ExotelTransferOutput?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.ExotelTransferOutput"
                    ),
                "sip_trunk" => json.Deserialize<global::ElevenLabs.SipTransferOutput?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.SipTransferOutput"
                    ),
                "twilio" => json.Deserialize<global::ElevenLabs.TwilioTransferOutput?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.TwilioTransferOutput"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new TransferRuleOutputProviderConfigsItem(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TransferRuleOutputProviderConfigsItem value,
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

        public override TransferRuleOutputProviderConfigsItem ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new TransferRuleOutputProviderConfigsItem(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TransferRuleOutputProviderConfigsItem value,
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
        public Exotel(global::ElevenLabs.ExotelTransferOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ExotelTransferOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator TransferRuleOutputProviderConfigsItem.Exotel(
            global::ElevenLabs.ExotelTransferOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for sip_trunk
    /// </summary>
    [Serializable]
    public struct SipTrunk
    {
        public SipTrunk(global::ElevenLabs.SipTransferOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.SipTransferOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator TransferRuleOutputProviderConfigsItem.SipTrunk(
            global::ElevenLabs.SipTransferOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for twilio
    /// </summary>
    [Serializable]
    public struct Twilio
    {
        public Twilio(global::ElevenLabs.TwilioTransferOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TwilioTransferOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator TransferRuleOutputProviderConfigsItem.Twilio(
            global::ElevenLabs.TwilioTransferOutput value
        ) => new(value);
    }
}
