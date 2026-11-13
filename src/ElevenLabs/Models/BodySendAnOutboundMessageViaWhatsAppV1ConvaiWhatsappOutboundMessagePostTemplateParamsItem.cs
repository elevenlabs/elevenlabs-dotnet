// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Agents;

[JsonConverter(
    typeof(BodySendAnOutboundMessageViaWhatsAppV1ConvaiWhatsappOutboundMessagePostTemplateParamsItem.JsonConverter)
)]
[Serializable]
public record BodySendAnOutboundMessageViaWhatsAppV1ConvaiWhatsappOutboundMessagePostTemplateParamsItem
{
    internal BodySendAnOutboundMessageViaWhatsAppV1ConvaiWhatsappOutboundMessagePostTemplateParamsItem(
        string type,
        object? value
    )
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of BodySendAnOutboundMessageViaWhatsAppV1ConvaiWhatsappOutboundMessagePostTemplateParamsItem with <see cref="BodySendAnOutboundMessageViaWhatsAppV1ConvaiWhatsappOutboundMessagePostTemplateParamsItem.Body"/>.
    /// </summary>
    public BodySendAnOutboundMessageViaWhatsAppV1ConvaiWhatsappOutboundMessagePostTemplateParamsItem(
        BodySendAnOutboundMessageViaWhatsAppV1ConvaiWhatsappOutboundMessagePostTemplateParamsItem.Body value
    )
    {
        Type = "body";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of BodySendAnOutboundMessageViaWhatsAppV1ConvaiWhatsappOutboundMessagePostTemplateParamsItem with <see cref="BodySendAnOutboundMessageViaWhatsAppV1ConvaiWhatsappOutboundMessagePostTemplateParamsItem.Button"/>.
    /// </summary>
    public BodySendAnOutboundMessageViaWhatsAppV1ConvaiWhatsappOutboundMessagePostTemplateParamsItem(
        BodySendAnOutboundMessageViaWhatsAppV1ConvaiWhatsappOutboundMessagePostTemplateParamsItem.Button value
    )
    {
        Type = "button";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of BodySendAnOutboundMessageViaWhatsAppV1ConvaiWhatsappOutboundMessagePostTemplateParamsItem with <see cref="BodySendAnOutboundMessageViaWhatsAppV1ConvaiWhatsappOutboundMessagePostTemplateParamsItem.Header"/>.
    /// </summary>
    public BodySendAnOutboundMessageViaWhatsAppV1ConvaiWhatsappOutboundMessagePostTemplateParamsItem(
        BodySendAnOutboundMessageViaWhatsAppV1ConvaiWhatsappOutboundMessagePostTemplateParamsItem.Header value
    )
    {
        Type = "header";
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
    /// Returns true if <see cref="Type"/> is "body"
    /// </summary>
    public bool IsBody => Type == "body";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "button"
    /// </summary>
    public bool IsButton => Type == "button";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "header"
    /// </summary>
    public bool IsHeader => Type == "header";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.WhatsAppTemplateBodyComponentParams"/> if <see cref="Type"/> is 'body', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'body'.</exception>
    public global::ElevenLabs.WhatsAppTemplateBodyComponentParams AsBody() =>
        IsBody
            ? (global::ElevenLabs.WhatsAppTemplateBodyComponentParams)Value!
            : throw new global::System.Exception(
                "BodySendAnOutboundMessageViaWhatsAppV1ConvaiWhatsappOutboundMessagePostTemplateParamsItem.Type is not 'body'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.WhatsAppTemplateButtonComponentParams"/> if <see cref="Type"/> is 'button', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'button'.</exception>
    public global::ElevenLabs.WhatsAppTemplateButtonComponentParams AsButton() =>
        IsButton
            ? (global::ElevenLabs.WhatsAppTemplateButtonComponentParams)Value!
            : throw new global::System.Exception(
                "BodySendAnOutboundMessageViaWhatsAppV1ConvaiWhatsappOutboundMessagePostTemplateParamsItem.Type is not 'button'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.WhatsAppTemplateHeaderComponentParams"/> if <see cref="Type"/> is 'header', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'header'.</exception>
    public global::ElevenLabs.WhatsAppTemplateHeaderComponentParams AsHeader() =>
        IsHeader
            ? (global::ElevenLabs.WhatsAppTemplateHeaderComponentParams)Value!
            : throw new global::System.Exception(
                "BodySendAnOutboundMessageViaWhatsAppV1ConvaiWhatsappOutboundMessagePostTemplateParamsItem.Type is not 'header'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.WhatsAppTemplateBodyComponentParams, T> onBody,
        Func<global::ElevenLabs.WhatsAppTemplateButtonComponentParams, T> onButton,
        Func<global::ElevenLabs.WhatsAppTemplateHeaderComponentParams, T> onHeader,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "body" => onBody(AsBody()),
            "button" => onButton(AsButton()),
            "header" => onHeader(AsHeader()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.WhatsAppTemplateBodyComponentParams> onBody,
        Action<global::ElevenLabs.WhatsAppTemplateButtonComponentParams> onButton,
        Action<global::ElevenLabs.WhatsAppTemplateHeaderComponentParams> onHeader,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "body":
                onBody(AsBody());
                break;
            case "button":
                onButton(AsButton());
                break;
            case "header":
                onHeader(AsHeader());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.WhatsAppTemplateBodyComponentParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsBody(out global::ElevenLabs.WhatsAppTemplateBodyComponentParams? value)
    {
        if (Type == "body")
        {
            value = (global::ElevenLabs.WhatsAppTemplateBodyComponentParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.WhatsAppTemplateButtonComponentParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsButton(out global::ElevenLabs.WhatsAppTemplateButtonComponentParams? value)
    {
        if (Type == "button")
        {
            value = (global::ElevenLabs.WhatsAppTemplateButtonComponentParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.WhatsAppTemplateHeaderComponentParams"/> and returns true if successful.
    /// </summary>
    public bool TryAsHeader(out global::ElevenLabs.WhatsAppTemplateHeaderComponentParams? value)
    {
        if (Type == "header")
        {
            value = (global::ElevenLabs.WhatsAppTemplateHeaderComponentParams)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator BodySendAnOutboundMessageViaWhatsAppV1ConvaiWhatsappOutboundMessagePostTemplateParamsItem(
        BodySendAnOutboundMessageViaWhatsAppV1ConvaiWhatsappOutboundMessagePostTemplateParamsItem.Body value
    ) => new(value);

    public static implicit operator BodySendAnOutboundMessageViaWhatsAppV1ConvaiWhatsappOutboundMessagePostTemplateParamsItem(
        BodySendAnOutboundMessageViaWhatsAppV1ConvaiWhatsappOutboundMessagePostTemplateParamsItem.Button value
    ) => new(value);

    public static implicit operator BodySendAnOutboundMessageViaWhatsAppV1ConvaiWhatsappOutboundMessagePostTemplateParamsItem(
        BodySendAnOutboundMessageViaWhatsAppV1ConvaiWhatsappOutboundMessagePostTemplateParamsItem.Header value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<BodySendAnOutboundMessageViaWhatsAppV1ConvaiWhatsappOutboundMessagePostTemplateParamsItem>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(BodySendAnOutboundMessageViaWhatsAppV1ConvaiWhatsappOutboundMessagePostTemplateParamsItem).IsAssignableFrom(
                typeToConvert
            );

        public override BodySendAnOutboundMessageViaWhatsAppV1ConvaiWhatsappOutboundMessagePostTemplateParamsItem Read(
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
                "body" => json.Deserialize<global::ElevenLabs.WhatsAppTemplateBodyComponentParams?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.WhatsAppTemplateBodyComponentParams"
                    ),
                "button" =>
                    json.Deserialize<global::ElevenLabs.WhatsAppTemplateButtonComponentParams?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.WhatsAppTemplateButtonComponentParams"
                        ),
                "header" =>
                    json.Deserialize<global::ElevenLabs.WhatsAppTemplateHeaderComponentParams?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.WhatsAppTemplateHeaderComponentParams"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new BodySendAnOutboundMessageViaWhatsAppV1ConvaiWhatsappOutboundMessagePostTemplateParamsItem(
                discriminator,
                value
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            BodySendAnOutboundMessageViaWhatsAppV1ConvaiWhatsappOutboundMessagePostTemplateParamsItem value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "body" => JsonSerializer.SerializeToNode(value.Value, options),
                    "button" => JsonSerializer.SerializeToNode(value.Value, options),
                    "header" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override BodySendAnOutboundMessageViaWhatsAppV1ConvaiWhatsappOutboundMessagePostTemplateParamsItem ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new BodySendAnOutboundMessageViaWhatsAppV1ConvaiWhatsappOutboundMessagePostTemplateParamsItem(
                stringValue,
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BodySendAnOutboundMessageViaWhatsAppV1ConvaiWhatsappOutboundMessagePostTemplateParamsItem value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for body
    /// </summary>
    [Serializable]
    public struct Body
    {
        public Body(global::ElevenLabs.WhatsAppTemplateBodyComponentParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.WhatsAppTemplateBodyComponentParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator BodySendAnOutboundMessageViaWhatsAppV1ConvaiWhatsappOutboundMessagePostTemplateParamsItem.Body(
            global::ElevenLabs.WhatsAppTemplateBodyComponentParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for button
    /// </summary>
    [Serializable]
    public struct Button
    {
        public Button(global::ElevenLabs.WhatsAppTemplateButtonComponentParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.WhatsAppTemplateButtonComponentParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator BodySendAnOutboundMessageViaWhatsAppV1ConvaiWhatsappOutboundMessagePostTemplateParamsItem.Button(
            global::ElevenLabs.WhatsAppTemplateButtonComponentParams value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for header
    /// </summary>
    [Serializable]
    public struct Header
    {
        public Header(global::ElevenLabs.WhatsAppTemplateHeaderComponentParams value)
        {
            Value = value;
        }

        internal global::ElevenLabs.WhatsAppTemplateHeaderComponentParams Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator BodySendAnOutboundMessageViaWhatsAppV1ConvaiWhatsappOutboundMessagePostTemplateParamsItem.Header(
            global::ElevenLabs.WhatsAppTemplateHeaderComponentParams value
        ) => new(value);
    }
}
