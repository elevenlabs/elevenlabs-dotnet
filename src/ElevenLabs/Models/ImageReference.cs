// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ImageReference.JsonConverter))]
[Serializable]
public record ImageReference
{
    internal ImageReference(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of ImageReference with <see cref="ImageReference.Asset"/>.
    /// </summary>
    public ImageReference(ImageReference.Asset value)
    {
        Type = "asset";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ImageReference with <see cref="ImageReference.Generation"/>.
    /// </summary>
    public ImageReference(ImageReference.Generation value)
    {
        Type = "generation";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ImageReference with <see cref="ImageReference.InlineBase64"/>.
    /// </summary>
    public ImageReference(ImageReference.InlineBase64 value)
    {
        Type = "inline_base64";
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
    /// Returns true if <see cref="Type"/> is "asset"
    /// </summary>
    public bool IsAsset => Type == "asset";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "generation"
    /// </summary>
    public bool IsGeneration => Type == "generation";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "inline_base64"
    /// </summary>
    public bool IsInlineBase64 => Type == "inline_base64";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.StaticAssetReference"/> if <see cref="Type"/> is 'asset', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'asset'.</exception>
    public global::ElevenLabs.StaticAssetReference AsAsset() =>
        IsAsset
            ? (global::ElevenLabs.StaticAssetReference)Value!
            : throw new global::System.Exception("ImageReference.Type is not 'asset'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.GenerationReference"/> if <see cref="Type"/> is 'generation', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'generation'.</exception>
    public global::ElevenLabs.GenerationReference AsGeneration() =>
        IsGeneration
            ? (global::ElevenLabs.GenerationReference)Value!
            : throw new global::System.Exception("ImageReference.Type is not 'generation'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.InlineImageReference"/> if <see cref="Type"/> is 'inline_base64', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'inline_base64'.</exception>
    public global::ElevenLabs.InlineImageReference AsInlineBase64() =>
        IsInlineBase64
            ? (global::ElevenLabs.InlineImageReference)Value!
            : throw new global::System.Exception("ImageReference.Type is not 'inline_base64'");

    public T Match<T>(
        Func<global::ElevenLabs.StaticAssetReference, T> onAsset,
        Func<global::ElevenLabs.GenerationReference, T> onGeneration,
        Func<global::ElevenLabs.InlineImageReference, T> onInlineBase64,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "asset" => onAsset(AsAsset()),
            "generation" => onGeneration(AsGeneration()),
            "inline_base64" => onInlineBase64(AsInlineBase64()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.StaticAssetReference> onAsset,
        Action<global::ElevenLabs.GenerationReference> onGeneration,
        Action<global::ElevenLabs.InlineImageReference> onInlineBase64,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "asset":
                onAsset(AsAsset());
                break;
            case "generation":
                onGeneration(AsGeneration());
                break;
            case "inline_base64":
                onInlineBase64(AsInlineBase64());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.StaticAssetReference"/> and returns true if successful.
    /// </summary>
    public bool TryAsAsset(out global::ElevenLabs.StaticAssetReference? value)
    {
        if (Type == "asset")
        {
            value = (global::ElevenLabs.StaticAssetReference)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.GenerationReference"/> and returns true if successful.
    /// </summary>
    public bool TryAsGeneration(out global::ElevenLabs.GenerationReference? value)
    {
        if (Type == "generation")
        {
            value = (global::ElevenLabs.GenerationReference)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.InlineImageReference"/> and returns true if successful.
    /// </summary>
    public bool TryAsInlineBase64(out global::ElevenLabs.InlineImageReference? value)
    {
        if (Type == "inline_base64")
        {
            value = (global::ElevenLabs.InlineImageReference)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator ImageReference(ImageReference.Asset value) => new(value);

    public static implicit operator ImageReference(ImageReference.Generation value) => new(value);

    public static implicit operator ImageReference(ImageReference.InlineBase64 value) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<ImageReference>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(ImageReference).IsAssignableFrom(typeToConvert);

        public override ImageReference Read(
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
                "asset" => json.Deserialize<global::ElevenLabs.StaticAssetReference?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.StaticAssetReference"
                    ),
                "generation" => json.Deserialize<global::ElevenLabs.GenerationReference?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.GenerationReference"
                    ),
                "inline_base64" => json.Deserialize<global::ElevenLabs.InlineImageReference?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.InlineImageReference"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new ImageReference(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ImageReference value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "asset" => JsonSerializer.SerializeToNode(value.Value, options),
                    "generation" => JsonSerializer.SerializeToNode(value.Value, options),
                    "inline_base64" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override ImageReference ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new ImageReference(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ImageReference value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for asset
    /// </summary>
    [Serializable]
    public struct Asset
    {
        public Asset(global::ElevenLabs.StaticAssetReference value)
        {
            Value = value;
        }

        internal global::ElevenLabs.StaticAssetReference Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ImageReference.Asset(
            global::ElevenLabs.StaticAssetReference value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for generation
    /// </summary>
    [Serializable]
    public struct Generation
    {
        public Generation(global::ElevenLabs.GenerationReference value)
        {
            Value = value;
        }

        internal global::ElevenLabs.GenerationReference Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ImageReference.Generation(
            global::ElevenLabs.GenerationReference value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for inline_base64
    /// </summary>
    [Serializable]
    public struct InlineBase64
    {
        public InlineBase64(global::ElevenLabs.InlineImageReference value)
        {
            Value = value;
        }

        internal global::ElevenLabs.InlineImageReference Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ImageReference.InlineBase64(
            global::ElevenLabs.InlineImageReference value
        ) => new(value);
    }
}
