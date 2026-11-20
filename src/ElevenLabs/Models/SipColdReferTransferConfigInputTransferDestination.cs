// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(SipColdReferTransferConfigInputTransferDestination.JsonConverter))]
[Serializable]
public record SipColdReferTransferConfigInputTransferDestination
{
    internal SipColdReferTransferConfigInputTransferDestination(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of SipColdReferTransferConfigInputTransferDestination with <see cref="SipColdReferTransferConfigInputTransferDestination.Phone"/>.
    /// </summary>
    public SipColdReferTransferConfigInputTransferDestination(
        SipColdReferTransferConfigInputTransferDestination.Phone value
    )
    {
        Type = "phone";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SipColdReferTransferConfigInputTransferDestination with <see cref="SipColdReferTransferConfigInputTransferDestination.PhoneDynamicVariable"/>.
    /// </summary>
    public SipColdReferTransferConfigInputTransferDestination(
        SipColdReferTransferConfigInputTransferDestination.PhoneDynamicVariable value
    )
    {
        Type = "phone_dynamic_variable";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SipColdReferTransferConfigInputTransferDestination with <see cref="SipColdReferTransferConfigInputTransferDestination.SipUri"/>.
    /// </summary>
    public SipColdReferTransferConfigInputTransferDestination(
        SipColdReferTransferConfigInputTransferDestination.SipUri value
    )
    {
        Type = "sip_uri";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SipColdReferTransferConfigInputTransferDestination with <see cref="SipColdReferTransferConfigInputTransferDestination.SipUriDynamicVariable"/>.
    /// </summary>
    public SipColdReferTransferConfigInputTransferDestination(
        SipColdReferTransferConfigInputTransferDestination.SipUriDynamicVariable value
    )
    {
        Type = "sip_uri_dynamic_variable";
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
    /// Returns true if <see cref="Type"/> is "phone"
    /// </summary>
    public bool IsPhone => Type == "phone";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "phone_dynamic_variable"
    /// </summary>
    public bool IsPhoneDynamicVariable => Type == "phone_dynamic_variable";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "sip_uri"
    /// </summary>
    public bool IsSipUri => Type == "sip_uri";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "sip_uri_dynamic_variable"
    /// </summary>
    public bool IsSipUriDynamicVariable => Type == "sip_uri_dynamic_variable";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.PhoneDestinationInput"/> if <see cref="Type"/> is 'phone', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'phone'.</exception>
    public global::ElevenLabs.PhoneDestinationInput AsPhone() =>
        IsPhone
            ? (global::ElevenLabs.PhoneDestinationInput)Value!
            : throw new global::System.Exception(
                "SipColdReferTransferConfigInputTransferDestination.Type is not 'phone'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.PhoneDynamicVariableDestinationInput"/> if <see cref="Type"/> is 'phone_dynamic_variable', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'phone_dynamic_variable'.</exception>
    public global::ElevenLabs.PhoneDynamicVariableDestinationInput AsPhoneDynamicVariable() =>
        IsPhoneDynamicVariable
            ? (global::ElevenLabs.PhoneDynamicVariableDestinationInput)Value!
            : throw new global::System.Exception(
                "SipColdReferTransferConfigInputTransferDestination.Type is not 'phone_dynamic_variable'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SipUriDestinationInput"/> if <see cref="Type"/> is 'sip_uri', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'sip_uri'.</exception>
    public global::ElevenLabs.SipUriDestinationInput AsSipUri() =>
        IsSipUri
            ? (global::ElevenLabs.SipUriDestinationInput)Value!
            : throw new global::System.Exception(
                "SipColdReferTransferConfigInputTransferDestination.Type is not 'sip_uri'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SipUriDynamicVariableDestinationInput"/> if <see cref="Type"/> is 'sip_uri_dynamic_variable', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'sip_uri_dynamic_variable'.</exception>
    public global::ElevenLabs.SipUriDynamicVariableDestinationInput AsSipUriDynamicVariable() =>
        IsSipUriDynamicVariable
            ? (global::ElevenLabs.SipUriDynamicVariableDestinationInput)Value!
            : throw new global::System.Exception(
                "SipColdReferTransferConfigInputTransferDestination.Type is not 'sip_uri_dynamic_variable'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.PhoneDestinationInput, T> onPhone,
        Func<global::ElevenLabs.PhoneDynamicVariableDestinationInput, T> onPhoneDynamicVariable,
        Func<global::ElevenLabs.SipUriDestinationInput, T> onSipUri,
        Func<global::ElevenLabs.SipUriDynamicVariableDestinationInput, T> onSipUriDynamicVariable,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "phone" => onPhone(AsPhone()),
            "phone_dynamic_variable" => onPhoneDynamicVariable(AsPhoneDynamicVariable()),
            "sip_uri" => onSipUri(AsSipUri()),
            "sip_uri_dynamic_variable" => onSipUriDynamicVariable(AsSipUriDynamicVariable()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.PhoneDestinationInput> onPhone,
        Action<global::ElevenLabs.PhoneDynamicVariableDestinationInput> onPhoneDynamicVariable,
        Action<global::ElevenLabs.SipUriDestinationInput> onSipUri,
        Action<global::ElevenLabs.SipUriDynamicVariableDestinationInput> onSipUriDynamicVariable,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "phone":
                onPhone(AsPhone());
                break;
            case "phone_dynamic_variable":
                onPhoneDynamicVariable(AsPhoneDynamicVariable());
                break;
            case "sip_uri":
                onSipUri(AsSipUri());
                break;
            case "sip_uri_dynamic_variable":
                onSipUriDynamicVariable(AsSipUriDynamicVariable());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.PhoneDestinationInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsPhone(out global::ElevenLabs.PhoneDestinationInput? value)
    {
        if (Type == "phone")
        {
            value = (global::ElevenLabs.PhoneDestinationInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.PhoneDynamicVariableDestinationInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsPhoneDynamicVariable(
        out global::ElevenLabs.PhoneDynamicVariableDestinationInput? value
    )
    {
        if (Type == "phone_dynamic_variable")
        {
            value = (global::ElevenLabs.PhoneDynamicVariableDestinationInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SipUriDestinationInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsSipUri(out global::ElevenLabs.SipUriDestinationInput? value)
    {
        if (Type == "sip_uri")
        {
            value = (global::ElevenLabs.SipUriDestinationInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SipUriDynamicVariableDestinationInput"/> and returns true if successful.
    /// </summary>
    public bool TryAsSipUriDynamicVariable(
        out global::ElevenLabs.SipUriDynamicVariableDestinationInput? value
    )
    {
        if (Type == "sip_uri_dynamic_variable")
        {
            value = (global::ElevenLabs.SipUriDynamicVariableDestinationInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator SipColdReferTransferConfigInputTransferDestination(
        SipColdReferTransferConfigInputTransferDestination.Phone value
    ) => new(value);

    public static implicit operator SipColdReferTransferConfigInputTransferDestination(
        SipColdReferTransferConfigInputTransferDestination.PhoneDynamicVariable value
    ) => new(value);

    public static implicit operator SipColdReferTransferConfigInputTransferDestination(
        SipColdReferTransferConfigInputTransferDestination.SipUri value
    ) => new(value);

    public static implicit operator SipColdReferTransferConfigInputTransferDestination(
        SipColdReferTransferConfigInputTransferDestination.SipUriDynamicVariable value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<SipColdReferTransferConfigInputTransferDestination>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(SipColdReferTransferConfigInputTransferDestination).IsAssignableFrom(
                typeToConvert
            );

        public override SipColdReferTransferConfigInputTransferDestination Read(
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
                "phone" => json.Deserialize<global::ElevenLabs.PhoneDestinationInput?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.PhoneDestinationInput"
                    ),
                "phone_dynamic_variable" =>
                    json.Deserialize<global::ElevenLabs.PhoneDynamicVariableDestinationInput?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.PhoneDynamicVariableDestinationInput"
                        ),
                "sip_uri" => json.Deserialize<global::ElevenLabs.SipUriDestinationInput?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.SipUriDestinationInput"
                    ),
                "sip_uri_dynamic_variable" =>
                    json.Deserialize<global::ElevenLabs.SipUriDynamicVariableDestinationInput?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.SipUriDynamicVariableDestinationInput"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new SipColdReferTransferConfigInputTransferDestination(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SipColdReferTransferConfigInputTransferDestination value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "phone" => JsonSerializer.SerializeToNode(value.Value, options),
                    "phone_dynamic_variable" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "sip_uri" => JsonSerializer.SerializeToNode(value.Value, options),
                    "sip_uri_dynamic_variable" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override SipColdReferTransferConfigInputTransferDestination ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new SipColdReferTransferConfigInputTransferDestination(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SipColdReferTransferConfigInputTransferDestination value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for phone
    /// </summary>
    [Serializable]
    public struct Phone
    {
        public Phone(global::ElevenLabs.PhoneDestinationInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.PhoneDestinationInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SipColdReferTransferConfigInputTransferDestination.Phone(
            global::ElevenLabs.PhoneDestinationInput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for phone_dynamic_variable
    /// </summary>
    [Serializable]
    public struct PhoneDynamicVariable
    {
        public PhoneDynamicVariable(global::ElevenLabs.PhoneDynamicVariableDestinationInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.PhoneDynamicVariableDestinationInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SipColdReferTransferConfigInputTransferDestination.PhoneDynamicVariable(
            global::ElevenLabs.PhoneDynamicVariableDestinationInput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for sip_uri
    /// </summary>
    [Serializable]
    public struct SipUri
    {
        public SipUri(global::ElevenLabs.SipUriDestinationInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.SipUriDestinationInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SipColdReferTransferConfigInputTransferDestination.SipUri(
            global::ElevenLabs.SipUriDestinationInput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for sip_uri_dynamic_variable
    /// </summary>
    [Serializable]
    public struct SipUriDynamicVariable
    {
        public SipUriDynamicVariable(global::ElevenLabs.SipUriDynamicVariableDestinationInput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.SipUriDynamicVariableDestinationInput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SipColdReferTransferConfigInputTransferDestination.SipUriDynamicVariable(
            global::ElevenLabs.SipUriDynamicVariableDestinationInput value
        ) => new(value);
    }
}
