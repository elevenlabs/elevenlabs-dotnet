// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(SipColdConferenceTransferConfigOutputTransferDestination.JsonConverter))]
[Serializable]
public record SipColdConferenceTransferConfigOutputTransferDestination
{
    internal SipColdConferenceTransferConfigOutputTransferDestination(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of SipColdConferenceTransferConfigOutputTransferDestination with <see cref="SipColdConferenceTransferConfigOutputTransferDestination.Phone"/>.
    /// </summary>
    public SipColdConferenceTransferConfigOutputTransferDestination(
        SipColdConferenceTransferConfigOutputTransferDestination.Phone value
    )
    {
        Type = "phone";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SipColdConferenceTransferConfigOutputTransferDestination with <see cref="SipColdConferenceTransferConfigOutputTransferDestination.PhoneDynamicVariable"/>.
    /// </summary>
    public SipColdConferenceTransferConfigOutputTransferDestination(
        SipColdConferenceTransferConfigOutputTransferDestination.PhoneDynamicVariable value
    )
    {
        Type = "phone_dynamic_variable";
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
    /// Returns the value as a <see cref="global::ElevenLabs.PhoneDestinationOutput"/> if <see cref="Type"/> is 'phone', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'phone'.</exception>
    public global::ElevenLabs.PhoneDestinationOutput AsPhone() =>
        IsPhone
            ? (global::ElevenLabs.PhoneDestinationOutput)Value!
            : throw new global::System.Exception(
                "SipColdConferenceTransferConfigOutputTransferDestination.Type is not 'phone'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.PhoneDynamicVariableDestinationOutput"/> if <see cref="Type"/> is 'phone_dynamic_variable', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'phone_dynamic_variable'.</exception>
    public global::ElevenLabs.PhoneDynamicVariableDestinationOutput AsPhoneDynamicVariable() =>
        IsPhoneDynamicVariable
            ? (global::ElevenLabs.PhoneDynamicVariableDestinationOutput)Value!
            : throw new global::System.Exception(
                "SipColdConferenceTransferConfigOutputTransferDestination.Type is not 'phone_dynamic_variable'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.PhoneDestinationOutput, T> onPhone,
        Func<global::ElevenLabs.PhoneDynamicVariableDestinationOutput, T> onPhoneDynamicVariable,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "phone" => onPhone(AsPhone()),
            "phone_dynamic_variable" => onPhoneDynamicVariable(AsPhoneDynamicVariable()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.PhoneDestinationOutput> onPhone,
        Action<global::ElevenLabs.PhoneDynamicVariableDestinationOutput> onPhoneDynamicVariable,
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
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.PhoneDestinationOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsPhone(out global::ElevenLabs.PhoneDestinationOutput? value)
    {
        if (Type == "phone")
        {
            value = (global::ElevenLabs.PhoneDestinationOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.PhoneDynamicVariableDestinationOutput"/> and returns true if successful.
    /// </summary>
    public bool TryAsPhoneDynamicVariable(
        out global::ElevenLabs.PhoneDynamicVariableDestinationOutput? value
    )
    {
        if (Type == "phone_dynamic_variable")
        {
            value = (global::ElevenLabs.PhoneDynamicVariableDestinationOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator SipColdConferenceTransferConfigOutputTransferDestination(
        SipColdConferenceTransferConfigOutputTransferDestination.Phone value
    ) => new(value);

    public static implicit operator SipColdConferenceTransferConfigOutputTransferDestination(
        SipColdConferenceTransferConfigOutputTransferDestination.PhoneDynamicVariable value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<SipColdConferenceTransferConfigOutputTransferDestination>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(SipColdConferenceTransferConfigOutputTransferDestination).IsAssignableFrom(
                typeToConvert
            );

        public override SipColdConferenceTransferConfigOutputTransferDestination Read(
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
                "phone" => json.Deserialize<global::ElevenLabs.PhoneDestinationOutput?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.PhoneDestinationOutput"
                    ),
                "phone_dynamic_variable" =>
                    json.Deserialize<global::ElevenLabs.PhoneDynamicVariableDestinationOutput?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.PhoneDynamicVariableDestinationOutput"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new SipColdConferenceTransferConfigOutputTransferDestination(
                discriminator,
                value
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            SipColdConferenceTransferConfigOutputTransferDestination value,
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
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override SipColdConferenceTransferConfigOutputTransferDestination ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new SipColdConferenceTransferConfigOutputTransferDestination(
                stringValue,
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SipColdConferenceTransferConfigOutputTransferDestination value,
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
        public Phone(global::ElevenLabs.PhoneDestinationOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.PhoneDestinationOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SipColdConferenceTransferConfigOutputTransferDestination.Phone(
            global::ElevenLabs.PhoneDestinationOutput value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for phone_dynamic_variable
    /// </summary>
    [Serializable]
    public struct PhoneDynamicVariable
    {
        public PhoneDynamicVariable(global::ElevenLabs.PhoneDynamicVariableDestinationOutput value)
        {
            Value = value;
        }

        internal global::ElevenLabs.PhoneDynamicVariableDestinationOutput Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SipColdConferenceTransferConfigOutputTransferDestination.PhoneDynamicVariable(
            global::ElevenLabs.PhoneDynamicVariableDestinationOutput value
        ) => new(value);
    }
}
