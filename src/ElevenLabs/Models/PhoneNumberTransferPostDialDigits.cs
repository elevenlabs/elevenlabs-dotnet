// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(PhoneNumberTransferPostDialDigits.JsonConverter))]
[Serializable]
public record PhoneNumberTransferPostDialDigits
{
    internal PhoneNumberTransferPostDialDigits(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of PhoneNumberTransferPostDialDigits with <see cref="PhoneNumberTransferPostDialDigits.Dynamic"/>.
    /// </summary>
    public PhoneNumberTransferPostDialDigits(PhoneNumberTransferPostDialDigits.Dynamic value)
    {
        Type = "dynamic";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of PhoneNumberTransferPostDialDigits with <see cref="PhoneNumberTransferPostDialDigits.Static"/>.
    /// </summary>
    public PhoneNumberTransferPostDialDigits(PhoneNumberTransferPostDialDigits.Static value)
    {
        Type = "static";
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
    /// Returns true if <see cref="Type"/> is "dynamic"
    /// </summary>
    public bool IsDynamic => Type == "dynamic";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "static"
    /// </summary>
    public bool IsStatic => Type == "static";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.PostDialDigitsDynamicVariable"/> if <see cref="Type"/> is 'dynamic', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'dynamic'.</exception>
    public global::ElevenLabs.PostDialDigitsDynamicVariable AsDynamic() =>
        IsDynamic
            ? (global::ElevenLabs.PostDialDigitsDynamicVariable)Value!
            : throw new global::System.Exception(
                "PhoneNumberTransferPostDialDigits.Type is not 'dynamic'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.PostDialDigitsStatic"/> if <see cref="Type"/> is 'static', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'static'.</exception>
    public global::ElevenLabs.PostDialDigitsStatic AsStatic() =>
        IsStatic
            ? (global::ElevenLabs.PostDialDigitsStatic)Value!
            : throw new global::System.Exception(
                "PhoneNumberTransferPostDialDigits.Type is not 'static'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.PostDialDigitsDynamicVariable, T> onDynamic,
        Func<global::ElevenLabs.PostDialDigitsStatic, T> onStatic,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "dynamic" => onDynamic(AsDynamic()),
            "static" => onStatic(AsStatic()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.PostDialDigitsDynamicVariable> onDynamic,
        Action<global::ElevenLabs.PostDialDigitsStatic> onStatic,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "dynamic":
                onDynamic(AsDynamic());
                break;
            case "static":
                onStatic(AsStatic());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.PostDialDigitsDynamicVariable"/> and returns true if successful.
    /// </summary>
    public bool TryAsDynamic(out global::ElevenLabs.PostDialDigitsDynamicVariable? value)
    {
        if (Type == "dynamic")
        {
            value = (global::ElevenLabs.PostDialDigitsDynamicVariable)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.PostDialDigitsStatic"/> and returns true if successful.
    /// </summary>
    public bool TryAsStatic(out global::ElevenLabs.PostDialDigitsStatic? value)
    {
        if (Type == "static")
        {
            value = (global::ElevenLabs.PostDialDigitsStatic)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator PhoneNumberTransferPostDialDigits(
        PhoneNumberTransferPostDialDigits.Dynamic value
    ) => new(value);

    public static implicit operator PhoneNumberTransferPostDialDigits(
        PhoneNumberTransferPostDialDigits.Static value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<PhoneNumberTransferPostDialDigits>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(PhoneNumberTransferPostDialDigits).IsAssignableFrom(typeToConvert);

        public override PhoneNumberTransferPostDialDigits Read(
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
                "dynamic" => json.Deserialize<global::ElevenLabs.PostDialDigitsDynamicVariable?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.PostDialDigitsDynamicVariable"
                    ),
                "static" => json.Deserialize<global::ElevenLabs.PostDialDigitsStatic?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.PostDialDigitsStatic"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new PhoneNumberTransferPostDialDigits(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PhoneNumberTransferPostDialDigits value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "dynamic" => JsonSerializer.SerializeToNode(value.Value, options),
                    "static" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override PhoneNumberTransferPostDialDigits ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new PhoneNumberTransferPostDialDigits(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PhoneNumberTransferPostDialDigits value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for dynamic
    /// </summary>
    [Serializable]
    public struct Dynamic
    {
        public Dynamic(global::ElevenLabs.PostDialDigitsDynamicVariable value)
        {
            Value = value;
        }

        internal global::ElevenLabs.PostDialDigitsDynamicVariable Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PhoneNumberTransferPostDialDigits.Dynamic(
            global::ElevenLabs.PostDialDigitsDynamicVariable value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for static
    /// </summary>
    [Serializable]
    public struct Static
    {
        public Static(global::ElevenLabs.PostDialDigitsStatic value)
        {
            Value = value;
        }

        internal global::ElevenLabs.PostDialDigitsStatic Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PhoneNumberTransferPostDialDigits.Static(
            global::ElevenLabs.PostDialDigitsStatic value
        ) => new(value);
    }
}
