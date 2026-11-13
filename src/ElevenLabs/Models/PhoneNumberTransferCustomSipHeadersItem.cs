// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(PhoneNumberTransferCustomSipHeadersItem.JsonConverter))]
[Serializable]
public record PhoneNumberTransferCustomSipHeadersItem
{
    internal PhoneNumberTransferCustomSipHeadersItem(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of PhoneNumberTransferCustomSipHeadersItem with <see cref="PhoneNumberTransferCustomSipHeadersItem.Dynamic"/>.
    /// </summary>
    public PhoneNumberTransferCustomSipHeadersItem(
        PhoneNumberTransferCustomSipHeadersItem.Dynamic value
    )
    {
        Type = "dynamic";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of PhoneNumberTransferCustomSipHeadersItem with <see cref="PhoneNumberTransferCustomSipHeadersItem.Static"/>.
    /// </summary>
    public PhoneNumberTransferCustomSipHeadersItem(
        PhoneNumberTransferCustomSipHeadersItem.Static value
    )
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
    /// Returns the value as a <see cref="global::ElevenLabs.CustomSipHeaderWithDynamicVariable"/> if <see cref="Type"/> is 'dynamic', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'dynamic'.</exception>
    public global::ElevenLabs.CustomSipHeaderWithDynamicVariable AsDynamic() =>
        IsDynamic
            ? (global::ElevenLabs.CustomSipHeaderWithDynamicVariable)Value!
            : throw new global::System.Exception(
                "PhoneNumberTransferCustomSipHeadersItem.Type is not 'dynamic'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.CustomSipHeader"/> if <see cref="Type"/> is 'static', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'static'.</exception>
    public global::ElevenLabs.CustomSipHeader AsStatic() =>
        IsStatic
            ? (global::ElevenLabs.CustomSipHeader)Value!
            : throw new global::System.Exception(
                "PhoneNumberTransferCustomSipHeadersItem.Type is not 'static'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.CustomSipHeaderWithDynamicVariable, T> onDynamic,
        Func<global::ElevenLabs.CustomSipHeader, T> onStatic,
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
        Action<global::ElevenLabs.CustomSipHeaderWithDynamicVariable> onDynamic,
        Action<global::ElevenLabs.CustomSipHeader> onStatic,
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
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.CustomSipHeaderWithDynamicVariable"/> and returns true if successful.
    /// </summary>
    public bool TryAsDynamic(out global::ElevenLabs.CustomSipHeaderWithDynamicVariable? value)
    {
        if (Type == "dynamic")
        {
            value = (global::ElevenLabs.CustomSipHeaderWithDynamicVariable)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.CustomSipHeader"/> and returns true if successful.
    /// </summary>
    public bool TryAsStatic(out global::ElevenLabs.CustomSipHeader? value)
    {
        if (Type == "static")
        {
            value = (global::ElevenLabs.CustomSipHeader)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator PhoneNumberTransferCustomSipHeadersItem(
        PhoneNumberTransferCustomSipHeadersItem.Dynamic value
    ) => new(value);

    public static implicit operator PhoneNumberTransferCustomSipHeadersItem(
        PhoneNumberTransferCustomSipHeadersItem.Static value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<PhoneNumberTransferCustomSipHeadersItem>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(PhoneNumberTransferCustomSipHeadersItem).IsAssignableFrom(typeToConvert);

        public override PhoneNumberTransferCustomSipHeadersItem Read(
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
                "dynamic" =>
                    json.Deserialize<global::ElevenLabs.CustomSipHeaderWithDynamicVariable?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.CustomSipHeaderWithDynamicVariable"
                        ),
                "static" => json.Deserialize<global::ElevenLabs.CustomSipHeader?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.CustomSipHeader"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new PhoneNumberTransferCustomSipHeadersItem(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PhoneNumberTransferCustomSipHeadersItem value,
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

        public override PhoneNumberTransferCustomSipHeadersItem ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new PhoneNumberTransferCustomSipHeadersItem(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PhoneNumberTransferCustomSipHeadersItem value,
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
        public Dynamic(global::ElevenLabs.CustomSipHeaderWithDynamicVariable value)
        {
            Value = value;
        }

        internal global::ElevenLabs.CustomSipHeaderWithDynamicVariable Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PhoneNumberTransferCustomSipHeadersItem.Dynamic(
            global::ElevenLabs.CustomSipHeaderWithDynamicVariable value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for static
    /// </summary>
    [Serializable]
    public struct Static
    {
        public Static(global::ElevenLabs.CustomSipHeader value)
        {
            Value = value;
        }

        internal global::ElevenLabs.CustomSipHeader Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator PhoneNumberTransferCustomSipHeadersItem.Static(
            global::ElevenLabs.CustomSipHeader value
        ) => new(value);
    }
}
