// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ListPhoneNumbersResponseItem.JsonConverter))]
[Serializable]
public record ListPhoneNumbersResponseItem
{
    internal ListPhoneNumbersResponseItem(string type, object? value)
    {
        Provider = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of ListPhoneNumbersResponseItem with <see cref="ListPhoneNumbersResponseItem.Twilio"/>.
    /// </summary>
    public ListPhoneNumbersResponseItem(ListPhoneNumbersResponseItem.Twilio value)
    {
        Provider = "twilio";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ListPhoneNumbersResponseItem with <see cref="ListPhoneNumbersResponseItem.Exotel"/>.
    /// </summary>
    public ListPhoneNumbersResponseItem(ListPhoneNumbersResponseItem.Exotel value)
    {
        Provider = "exotel";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ListPhoneNumbersResponseItem with <see cref="ListPhoneNumbersResponseItem.SipTrunk"/>.
    /// </summary>
    public ListPhoneNumbersResponseItem(ListPhoneNumbersResponseItem.SipTrunk value)
    {
        Provider = "sip_trunk";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("provider")]
    public string Provider { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="Provider"/> is "twilio"
    /// </summary>
    public bool IsTwilio => Provider == "twilio";

    /// <summary>
    /// Returns true if <see cref="Provider"/> is "exotel"
    /// </summary>
    public bool IsExotel => Provider == "exotel";

    /// <summary>
    /// Returns true if <see cref="Provider"/> is "sip_trunk"
    /// </summary>
    public bool IsSipTrunk => Provider == "sip_trunk";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.GetPhoneNumberTwilioResponseModel"/> if <see cref="Provider"/> is 'twilio', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Provider"/> is not 'twilio'.</exception>
    public global::ElevenLabs.GetPhoneNumberTwilioResponseModel AsTwilio() =>
        IsTwilio
            ? (global::ElevenLabs.GetPhoneNumberTwilioResponseModel)Value!
            : throw new global::System.Exception(
                "ListPhoneNumbersResponseItem.Provider is not 'twilio'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.GetPhoneNumberExotelResponseModel"/> if <see cref="Provider"/> is 'exotel', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Provider"/> is not 'exotel'.</exception>
    public global::ElevenLabs.GetPhoneNumberExotelResponseModel AsExotel() =>
        IsExotel
            ? (global::ElevenLabs.GetPhoneNumberExotelResponseModel)Value!
            : throw new global::System.Exception(
                "ListPhoneNumbersResponseItem.Provider is not 'exotel'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.GetPhoneNumberSipTrunkResponseModel"/> if <see cref="Provider"/> is 'sip_trunk', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Provider"/> is not 'sip_trunk'.</exception>
    public global::ElevenLabs.GetPhoneNumberSipTrunkResponseModel AsSipTrunk() =>
        IsSipTrunk
            ? (global::ElevenLabs.GetPhoneNumberSipTrunkResponseModel)Value!
            : throw new global::System.Exception(
                "ListPhoneNumbersResponseItem.Provider is not 'sip_trunk'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.GetPhoneNumberTwilioResponseModel, T> onTwilio,
        Func<global::ElevenLabs.GetPhoneNumberExotelResponseModel, T> onExotel,
        Func<global::ElevenLabs.GetPhoneNumberSipTrunkResponseModel, T> onSipTrunk,
        Func<string, object?, T> onUnknown_
    )
    {
        return Provider switch
        {
            "twilio" => onTwilio(AsTwilio()),
            "exotel" => onExotel(AsExotel()),
            "sip_trunk" => onSipTrunk(AsSipTrunk()),
            _ => onUnknown_(Provider, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.GetPhoneNumberTwilioResponseModel> onTwilio,
        Action<global::ElevenLabs.GetPhoneNumberExotelResponseModel> onExotel,
        Action<global::ElevenLabs.GetPhoneNumberSipTrunkResponseModel> onSipTrunk,
        Action<string, object?> onUnknown_
    )
    {
        switch (Provider)
        {
            case "twilio":
                onTwilio(AsTwilio());
                break;
            case "exotel":
                onExotel(AsExotel());
                break;
            case "sip_trunk":
                onSipTrunk(AsSipTrunk());
                break;
            default:
                onUnknown_(Provider, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.GetPhoneNumberTwilioResponseModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsTwilio(out global::ElevenLabs.GetPhoneNumberTwilioResponseModel? value)
    {
        if (Provider == "twilio")
        {
            value = (global::ElevenLabs.GetPhoneNumberTwilioResponseModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.GetPhoneNumberExotelResponseModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsExotel(out global::ElevenLabs.GetPhoneNumberExotelResponseModel? value)
    {
        if (Provider == "exotel")
        {
            value = (global::ElevenLabs.GetPhoneNumberExotelResponseModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.GetPhoneNumberSipTrunkResponseModel"/> and returns true if successful.
    /// </summary>
    public bool TryAsSipTrunk(out global::ElevenLabs.GetPhoneNumberSipTrunkResponseModel? value)
    {
        if (Provider == "sip_trunk")
        {
            value = (global::ElevenLabs.GetPhoneNumberSipTrunkResponseModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator ListPhoneNumbersResponseItem(
        ListPhoneNumbersResponseItem.Twilio value
    ) => new(value);

    public static implicit operator ListPhoneNumbersResponseItem(
        ListPhoneNumbersResponseItem.Exotel value
    ) => new(value);

    public static implicit operator ListPhoneNumbersResponseItem(
        ListPhoneNumbersResponseItem.SipTrunk value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<ListPhoneNumbersResponseItem>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(ListPhoneNumbersResponseItem).IsAssignableFrom(typeToConvert);

        public override ListPhoneNumbersResponseItem Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (!json.TryGetProperty("provider", out var discriminatorElement))
            {
                throw new JsonException("Missing discriminator property 'provider'");
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException("Discriminator property 'provider' is null");
                }

                throw new JsonException(
                    $"Discriminator property 'provider' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException("Discriminator property 'provider' is null");

            var value = discriminator switch
            {
                "twilio" => json.Deserialize<global::ElevenLabs.GetPhoneNumberTwilioResponseModel?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.GetPhoneNumberTwilioResponseModel"
                    ),
                "exotel" => json.Deserialize<global::ElevenLabs.GetPhoneNumberExotelResponseModel?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.GetPhoneNumberExotelResponseModel"
                    ),
                "sip_trunk" =>
                    json.Deserialize<global::ElevenLabs.GetPhoneNumberSipTrunkResponseModel?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.GetPhoneNumberSipTrunkResponseModel"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new ListPhoneNumbersResponseItem(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListPhoneNumbersResponseItem value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Provider switch
                {
                    "twilio" => JsonSerializer.SerializeToNode(value.Value, options),
                    "exotel" => JsonSerializer.SerializeToNode(value.Value, options),
                    "sip_trunk" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["provider"] = value.Provider;
            json.WriteTo(writer, options);
        }

        public override ListPhoneNumbersResponseItem ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new ListPhoneNumbersResponseItem(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListPhoneNumbersResponseItem value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Provider);
        }
    }

    /// <summary>
    /// Discriminated union type for twilio
    /// </summary>
    [Serializable]
    public struct Twilio
    {
        public Twilio(global::ElevenLabs.GetPhoneNumberTwilioResponseModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.GetPhoneNumberTwilioResponseModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ListPhoneNumbersResponseItem.Twilio(
            global::ElevenLabs.GetPhoneNumberTwilioResponseModel value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for exotel
    /// </summary>
    [Serializable]
    public struct Exotel
    {
        public Exotel(global::ElevenLabs.GetPhoneNumberExotelResponseModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.GetPhoneNumberExotelResponseModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ListPhoneNumbersResponseItem.Exotel(
            global::ElevenLabs.GetPhoneNumberExotelResponseModel value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for sip_trunk
    /// </summary>
    [Serializable]
    public struct SipTrunk
    {
        public SipTrunk(global::ElevenLabs.GetPhoneNumberSipTrunkResponseModel value)
        {
            Value = value;
        }

        internal global::ElevenLabs.GetPhoneNumberSipTrunkResponseModel Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ListPhoneNumbersResponseItem.SipTrunk(
            global::ElevenLabs.GetPhoneNumberSipTrunkResponseModel value
        ) => new(value);
    }
}
