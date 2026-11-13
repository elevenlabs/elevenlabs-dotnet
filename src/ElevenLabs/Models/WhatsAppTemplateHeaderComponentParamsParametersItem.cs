// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(WhatsAppTemplateHeaderComponentParamsParametersItem.JsonConverter))]
[Serializable]
public record WhatsAppTemplateHeaderComponentParamsParametersItem
{
    internal WhatsAppTemplateHeaderComponentParamsParametersItem(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of WhatsAppTemplateHeaderComponentParamsParametersItem with <see cref="WhatsAppTemplateHeaderComponentParamsParametersItem.Document"/>.
    /// </summary>
    public WhatsAppTemplateHeaderComponentParamsParametersItem(
        WhatsAppTemplateHeaderComponentParamsParametersItem.Document value
    )
    {
        Type = "document";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of WhatsAppTemplateHeaderComponentParamsParametersItem with <see cref="WhatsAppTemplateHeaderComponentParamsParametersItem.Image"/>.
    /// </summary>
    public WhatsAppTemplateHeaderComponentParamsParametersItem(
        WhatsAppTemplateHeaderComponentParamsParametersItem.Image value
    )
    {
        Type = "image";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of WhatsAppTemplateHeaderComponentParamsParametersItem with <see cref="WhatsAppTemplateHeaderComponentParamsParametersItem.Location"/>.
    /// </summary>
    public WhatsAppTemplateHeaderComponentParamsParametersItem(
        WhatsAppTemplateHeaderComponentParamsParametersItem.Location value
    )
    {
        Type = "location";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of WhatsAppTemplateHeaderComponentParamsParametersItem with <see cref="WhatsAppTemplateHeaderComponentParamsParametersItem.Text"/>.
    /// </summary>
    public WhatsAppTemplateHeaderComponentParamsParametersItem(
        WhatsAppTemplateHeaderComponentParamsParametersItem.Text value
    )
    {
        Type = "text";
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
    /// Returns true if <see cref="Type"/> is "document"
    /// </summary>
    public bool IsDocument => Type == "document";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "image"
    /// </summary>
    public bool IsImage => Type == "image";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "location"
    /// </summary>
    public bool IsLocation => Type == "location";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "text"
    /// </summary>
    public bool IsText => Type == "text";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.WhatsAppTemplateDocumentParam"/> if <see cref="Type"/> is 'document', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'document'.</exception>
    public global::ElevenLabs.WhatsAppTemplateDocumentParam AsDocument() =>
        IsDocument
            ? (global::ElevenLabs.WhatsAppTemplateDocumentParam)Value!
            : throw new global::System.Exception(
                "WhatsAppTemplateHeaderComponentParamsParametersItem.Type is not 'document'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.WhatsAppTemplateImageParam"/> if <see cref="Type"/> is 'image', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'image'.</exception>
    public global::ElevenLabs.WhatsAppTemplateImageParam AsImage() =>
        IsImage
            ? (global::ElevenLabs.WhatsAppTemplateImageParam)Value!
            : throw new global::System.Exception(
                "WhatsAppTemplateHeaderComponentParamsParametersItem.Type is not 'image'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.WhatsAppTemplateLocationParam"/> if <see cref="Type"/> is 'location', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'location'.</exception>
    public global::ElevenLabs.WhatsAppTemplateLocationParam AsLocation() =>
        IsLocation
            ? (global::ElevenLabs.WhatsAppTemplateLocationParam)Value!
            : throw new global::System.Exception(
                "WhatsAppTemplateHeaderComponentParamsParametersItem.Type is not 'location'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.WhatsAppTemplateTextParam"/> if <see cref="Type"/> is 'text', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'text'.</exception>
    public global::ElevenLabs.WhatsAppTemplateTextParam AsText() =>
        IsText
            ? (global::ElevenLabs.WhatsAppTemplateTextParam)Value!
            : throw new global::System.Exception(
                "WhatsAppTemplateHeaderComponentParamsParametersItem.Type is not 'text'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.WhatsAppTemplateDocumentParam, T> onDocument,
        Func<global::ElevenLabs.WhatsAppTemplateImageParam, T> onImage,
        Func<global::ElevenLabs.WhatsAppTemplateLocationParam, T> onLocation,
        Func<global::ElevenLabs.WhatsAppTemplateTextParam, T> onText,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "document" => onDocument(AsDocument()),
            "image" => onImage(AsImage()),
            "location" => onLocation(AsLocation()),
            "text" => onText(AsText()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.WhatsAppTemplateDocumentParam> onDocument,
        Action<global::ElevenLabs.WhatsAppTemplateImageParam> onImage,
        Action<global::ElevenLabs.WhatsAppTemplateLocationParam> onLocation,
        Action<global::ElevenLabs.WhatsAppTemplateTextParam> onText,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "document":
                onDocument(AsDocument());
                break;
            case "image":
                onImage(AsImage());
                break;
            case "location":
                onLocation(AsLocation());
                break;
            case "text":
                onText(AsText());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.WhatsAppTemplateDocumentParam"/> and returns true if successful.
    /// </summary>
    public bool TryAsDocument(out global::ElevenLabs.WhatsAppTemplateDocumentParam? value)
    {
        if (Type == "document")
        {
            value = (global::ElevenLabs.WhatsAppTemplateDocumentParam)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.WhatsAppTemplateImageParam"/> and returns true if successful.
    /// </summary>
    public bool TryAsImage(out global::ElevenLabs.WhatsAppTemplateImageParam? value)
    {
        if (Type == "image")
        {
            value = (global::ElevenLabs.WhatsAppTemplateImageParam)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.WhatsAppTemplateLocationParam"/> and returns true if successful.
    /// </summary>
    public bool TryAsLocation(out global::ElevenLabs.WhatsAppTemplateLocationParam? value)
    {
        if (Type == "location")
        {
            value = (global::ElevenLabs.WhatsAppTemplateLocationParam)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.WhatsAppTemplateTextParam"/> and returns true if successful.
    /// </summary>
    public bool TryAsText(out global::ElevenLabs.WhatsAppTemplateTextParam? value)
    {
        if (Type == "text")
        {
            value = (global::ElevenLabs.WhatsAppTemplateTextParam)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator WhatsAppTemplateHeaderComponentParamsParametersItem(
        WhatsAppTemplateHeaderComponentParamsParametersItem.Document value
    ) => new(value);

    public static implicit operator WhatsAppTemplateHeaderComponentParamsParametersItem(
        WhatsAppTemplateHeaderComponentParamsParametersItem.Image value
    ) => new(value);

    public static implicit operator WhatsAppTemplateHeaderComponentParamsParametersItem(
        WhatsAppTemplateHeaderComponentParamsParametersItem.Location value
    ) => new(value);

    public static implicit operator WhatsAppTemplateHeaderComponentParamsParametersItem(
        WhatsAppTemplateHeaderComponentParamsParametersItem.Text value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<WhatsAppTemplateHeaderComponentParamsParametersItem>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(WhatsAppTemplateHeaderComponentParamsParametersItem).IsAssignableFrom(
                typeToConvert
            );

        public override WhatsAppTemplateHeaderComponentParamsParametersItem Read(
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
                "document" => json.Deserialize<global::ElevenLabs.WhatsAppTemplateDocumentParam?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.WhatsAppTemplateDocumentParam"
                    ),
                "image" => json.Deserialize<global::ElevenLabs.WhatsAppTemplateImageParam?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.WhatsAppTemplateImageParam"
                    ),
                "location" => json.Deserialize<global::ElevenLabs.WhatsAppTemplateLocationParam?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.WhatsAppTemplateLocationParam"
                    ),
                "text" => json.Deserialize<global::ElevenLabs.WhatsAppTemplateTextParam?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.WhatsAppTemplateTextParam"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new WhatsAppTemplateHeaderComponentParamsParametersItem(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WhatsAppTemplateHeaderComponentParamsParametersItem value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "document" => JsonSerializer.SerializeToNode(value.Value, options),
                    "image" => JsonSerializer.SerializeToNode(value.Value, options),
                    "location" => JsonSerializer.SerializeToNode(value.Value, options),
                    "text" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override WhatsAppTemplateHeaderComponentParamsParametersItem ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new WhatsAppTemplateHeaderComponentParamsParametersItem(
                stringValue,
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WhatsAppTemplateHeaderComponentParamsParametersItem value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for document
    /// </summary>
    [Serializable]
    public struct Document
    {
        public Document(global::ElevenLabs.WhatsAppTemplateDocumentParam value)
        {
            Value = value;
        }

        internal global::ElevenLabs.WhatsAppTemplateDocumentParam Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator WhatsAppTemplateHeaderComponentParamsParametersItem.Document(
            global::ElevenLabs.WhatsAppTemplateDocumentParam value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for image
    /// </summary>
    [Serializable]
    public struct Image
    {
        public Image(global::ElevenLabs.WhatsAppTemplateImageParam value)
        {
            Value = value;
        }

        internal global::ElevenLabs.WhatsAppTemplateImageParam Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator WhatsAppTemplateHeaderComponentParamsParametersItem.Image(
            global::ElevenLabs.WhatsAppTemplateImageParam value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for location
    /// </summary>
    [Serializable]
    public struct Location
    {
        public Location(global::ElevenLabs.WhatsAppTemplateLocationParam value)
        {
            Value = value;
        }

        internal global::ElevenLabs.WhatsAppTemplateLocationParam Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator WhatsAppTemplateHeaderComponentParamsParametersItem.Location(
            global::ElevenLabs.WhatsAppTemplateLocationParam value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for text
    /// </summary>
    [Serializable]
    public struct Text
    {
        public Text(global::ElevenLabs.WhatsAppTemplateTextParam value)
        {
            Value = value;
        }

        internal global::ElevenLabs.WhatsAppTemplateTextParam Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator WhatsAppTemplateHeaderComponentParamsParametersItem.Text(
            global::ElevenLabs.WhatsAppTemplateTextParam value
        ) => new(value);
    }
}
