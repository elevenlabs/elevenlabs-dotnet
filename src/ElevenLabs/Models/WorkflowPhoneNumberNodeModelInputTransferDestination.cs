// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(WorkflowPhoneNumberNodeModelInputTransferDestination.JsonConverter))]
[Serializable]
public record WorkflowPhoneNumberNodeModelInputTransferDestination
{
    internal WorkflowPhoneNumberNodeModelInputTransferDestination(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of WorkflowPhoneNumberNodeModelInputTransferDestination with <see cref="WorkflowPhoneNumberNodeModelInputTransferDestination.Phone"/>.
    /// </summary>
    public WorkflowPhoneNumberNodeModelInputTransferDestination(
        WorkflowPhoneNumberNodeModelInputTransferDestination.Phone value
    )
    {
        Type = "phone";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of WorkflowPhoneNumberNodeModelInputTransferDestination with <see cref="WorkflowPhoneNumberNodeModelInputTransferDestination.PhoneDynamicVariable"/>.
    /// </summary>
    public WorkflowPhoneNumberNodeModelInputTransferDestination(
        WorkflowPhoneNumberNodeModelInputTransferDestination.PhoneDynamicVariable value
    )
    {
        Type = "phone_dynamic_variable";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of WorkflowPhoneNumberNodeModelInputTransferDestination with <see cref="WorkflowPhoneNumberNodeModelInputTransferDestination.SipUri"/>.
    /// </summary>
    public WorkflowPhoneNumberNodeModelInputTransferDestination(
        WorkflowPhoneNumberNodeModelInputTransferDestination.SipUri value
    )
    {
        Type = "sip_uri";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of WorkflowPhoneNumberNodeModelInputTransferDestination with <see cref="WorkflowPhoneNumberNodeModelInputTransferDestination.SipUriDynamicVariable"/>.
    /// </summary>
    public WorkflowPhoneNumberNodeModelInputTransferDestination(
        WorkflowPhoneNumberNodeModelInputTransferDestination.SipUriDynamicVariable value
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
    /// Returns the value as a <see cref="global::ElevenLabs.PhoneNumberTransferDestination"/> if <see cref="Type"/> is 'phone', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'phone'.</exception>
    public global::ElevenLabs.PhoneNumberTransferDestination AsPhone() =>
        IsPhone
            ? (global::ElevenLabs.PhoneNumberTransferDestination)Value!
            : throw new global::System.Exception(
                "WorkflowPhoneNumberNodeModelInputTransferDestination.Type is not 'phone'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.PhoneNumberDynamicVariableTransferDestination"/> if <see cref="Type"/> is 'phone_dynamic_variable', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'phone_dynamic_variable'.</exception>
    public global::ElevenLabs.PhoneNumberDynamicVariableTransferDestination AsPhoneDynamicVariable() =>
        IsPhoneDynamicVariable
            ? (global::ElevenLabs.PhoneNumberDynamicVariableTransferDestination)Value!
            : throw new global::System.Exception(
                "WorkflowPhoneNumberNodeModelInputTransferDestination.Type is not 'phone_dynamic_variable'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SipUriTransferDestination"/> if <see cref="Type"/> is 'sip_uri', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'sip_uri'.</exception>
    public global::ElevenLabs.SipUriTransferDestination AsSipUri() =>
        IsSipUri
            ? (global::ElevenLabs.SipUriTransferDestination)Value!
            : throw new global::System.Exception(
                "WorkflowPhoneNumberNodeModelInputTransferDestination.Type is not 'sip_uri'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SipUriDynamicVariableTransferDestination"/> if <see cref="Type"/> is 'sip_uri_dynamic_variable', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'sip_uri_dynamic_variable'.</exception>
    public global::ElevenLabs.SipUriDynamicVariableTransferDestination AsSipUriDynamicVariable() =>
        IsSipUriDynamicVariable
            ? (global::ElevenLabs.SipUriDynamicVariableTransferDestination)Value!
            : throw new global::System.Exception(
                "WorkflowPhoneNumberNodeModelInputTransferDestination.Type is not 'sip_uri_dynamic_variable'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.PhoneNumberTransferDestination, T> onPhone,
        Func<
            global::ElevenLabs.PhoneNumberDynamicVariableTransferDestination,
            T
        > onPhoneDynamicVariable,
        Func<global::ElevenLabs.SipUriTransferDestination, T> onSipUri,
        Func<
            global::ElevenLabs.SipUriDynamicVariableTransferDestination,
            T
        > onSipUriDynamicVariable,
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
        Action<global::ElevenLabs.PhoneNumberTransferDestination> onPhone,
        Action<global::ElevenLabs.PhoneNumberDynamicVariableTransferDestination> onPhoneDynamicVariable,
        Action<global::ElevenLabs.SipUriTransferDestination> onSipUri,
        Action<global::ElevenLabs.SipUriDynamicVariableTransferDestination> onSipUriDynamicVariable,
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
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.PhoneNumberTransferDestination"/> and returns true if successful.
    /// </summary>
    public bool TryAsPhone(out global::ElevenLabs.PhoneNumberTransferDestination? value)
    {
        if (Type == "phone")
        {
            value = (global::ElevenLabs.PhoneNumberTransferDestination)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.PhoneNumberDynamicVariableTransferDestination"/> and returns true if successful.
    /// </summary>
    public bool TryAsPhoneDynamicVariable(
        out global::ElevenLabs.PhoneNumberDynamicVariableTransferDestination? value
    )
    {
        if (Type == "phone_dynamic_variable")
        {
            value = (global::ElevenLabs.PhoneNumberDynamicVariableTransferDestination)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SipUriTransferDestination"/> and returns true if successful.
    /// </summary>
    public bool TryAsSipUri(out global::ElevenLabs.SipUriTransferDestination? value)
    {
        if (Type == "sip_uri")
        {
            value = (global::ElevenLabs.SipUriTransferDestination)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SipUriDynamicVariableTransferDestination"/> and returns true if successful.
    /// </summary>
    public bool TryAsSipUriDynamicVariable(
        out global::ElevenLabs.SipUriDynamicVariableTransferDestination? value
    )
    {
        if (Type == "sip_uri_dynamic_variable")
        {
            value = (global::ElevenLabs.SipUriDynamicVariableTransferDestination)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator WorkflowPhoneNumberNodeModelInputTransferDestination(
        WorkflowPhoneNumberNodeModelInputTransferDestination.Phone value
    ) => new(value);

    public static implicit operator WorkflowPhoneNumberNodeModelInputTransferDestination(
        WorkflowPhoneNumberNodeModelInputTransferDestination.PhoneDynamicVariable value
    ) => new(value);

    public static implicit operator WorkflowPhoneNumberNodeModelInputTransferDestination(
        WorkflowPhoneNumberNodeModelInputTransferDestination.SipUri value
    ) => new(value);

    public static implicit operator WorkflowPhoneNumberNodeModelInputTransferDestination(
        WorkflowPhoneNumberNodeModelInputTransferDestination.SipUriDynamicVariable value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<WorkflowPhoneNumberNodeModelInputTransferDestination>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(WorkflowPhoneNumberNodeModelInputTransferDestination).IsAssignableFrom(
                typeToConvert
            );

        public override WorkflowPhoneNumberNodeModelInputTransferDestination Read(
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
                "phone" => json.Deserialize<global::ElevenLabs.PhoneNumberTransferDestination?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.PhoneNumberTransferDestination"
                    ),
                "phone_dynamic_variable" =>
                    json.Deserialize<global::ElevenLabs.PhoneNumberDynamicVariableTransferDestination?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.PhoneNumberDynamicVariableTransferDestination"
                        ),
                "sip_uri" => json.Deserialize<global::ElevenLabs.SipUriTransferDestination?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.SipUriTransferDestination"
                    ),
                "sip_uri_dynamic_variable" =>
                    json.Deserialize<global::ElevenLabs.SipUriDynamicVariableTransferDestination?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.SipUriDynamicVariableTransferDestination"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new WorkflowPhoneNumberNodeModelInputTransferDestination(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WorkflowPhoneNumberNodeModelInputTransferDestination value,
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

        public override WorkflowPhoneNumberNodeModelInputTransferDestination ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new WorkflowPhoneNumberNodeModelInputTransferDestination(
                stringValue,
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WorkflowPhoneNumberNodeModelInputTransferDestination value,
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
        public Phone(global::ElevenLabs.PhoneNumberTransferDestination value)
        {
            Value = value;
        }

        internal global::ElevenLabs.PhoneNumberTransferDestination Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator WorkflowPhoneNumberNodeModelInputTransferDestination.Phone(
            global::ElevenLabs.PhoneNumberTransferDestination value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for phone_dynamic_variable
    /// </summary>
    [Serializable]
    public struct PhoneDynamicVariable
    {
        public PhoneDynamicVariable(
            global::ElevenLabs.PhoneNumberDynamicVariableTransferDestination value
        )
        {
            Value = value;
        }

        internal global::ElevenLabs.PhoneNumberDynamicVariableTransferDestination Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator WorkflowPhoneNumberNodeModelInputTransferDestination.PhoneDynamicVariable(
            global::ElevenLabs.PhoneNumberDynamicVariableTransferDestination value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for sip_uri
    /// </summary>
    [Serializable]
    public struct SipUri
    {
        public SipUri(global::ElevenLabs.SipUriTransferDestination value)
        {
            Value = value;
        }

        internal global::ElevenLabs.SipUriTransferDestination Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator WorkflowPhoneNumberNodeModelInputTransferDestination.SipUri(
            global::ElevenLabs.SipUriTransferDestination value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for sip_uri_dynamic_variable
    /// </summary>
    [Serializable]
    public struct SipUriDynamicVariable
    {
        public SipUriDynamicVariable(
            global::ElevenLabs.SipUriDynamicVariableTransferDestination value
        )
        {
            Value = value;
        }

        internal global::ElevenLabs.SipUriDynamicVariableTransferDestination Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator WorkflowPhoneNumberNodeModelInputTransferDestination.SipUriDynamicVariable(
            global::ElevenLabs.SipUriDynamicVariableTransferDestination value
        ) => new(value);
    }
}
