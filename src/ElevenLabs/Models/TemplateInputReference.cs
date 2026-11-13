// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(TemplateInputReference.JsonConverter))]
[Serializable]
public record TemplateInputReference
{
    internal TemplateInputReference(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of TemplateInputReference with <see cref="TemplateInputReference.Asset"/>.
    /// </summary>
    public TemplateInputReference(TemplateInputReference.Asset value)
    {
        Type = "asset";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of TemplateInputReference with <see cref="TemplateInputReference.Generation"/>.
    /// </summary>
    public TemplateInputReference(TemplateInputReference.Generation value)
    {
        Type = "generation";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of TemplateInputReference with <see cref="TemplateInputReference.InlineBase64"/>.
    /// </summary>
    public TemplateInputReference(TemplateInputReference.InlineBase64 value)
    {
        Type = "inline_base64";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of TemplateInputReference with <see cref="TemplateInputReference.Voice"/>.
    /// </summary>
    public TemplateInputReference(TemplateInputReference.Voice value)
    {
        Type = "voice";
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
    /// Returns true if <see cref="Type"/> is "voice"
    /// </summary>
    public bool IsVoice => Type == "voice";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.StaticAssetReference"/> if <see cref="Type"/> is 'asset', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'asset'.</exception>
    public global::ElevenLabs.StaticAssetReference AsAsset() =>
        IsAsset
            ? (global::ElevenLabs.StaticAssetReference)Value!
            : throw new global::System.Exception("TemplateInputReference.Type is not 'asset'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.GenerationReference"/> if <see cref="Type"/> is 'generation', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'generation'.</exception>
    public global::ElevenLabs.GenerationReference AsGeneration() =>
        IsGeneration
            ? (global::ElevenLabs.GenerationReference)Value!
            : throw new global::System.Exception("TemplateInputReference.Type is not 'generation'");

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.InlineBase64Reference"/> if <see cref="Type"/> is 'inline_base64', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'inline_base64'.</exception>
    public global::ElevenLabs.InlineBase64Reference AsInlineBase64() =>
        IsInlineBase64
            ? (global::ElevenLabs.InlineBase64Reference)Value!
            : throw new global::System.Exception(
                "TemplateInputReference.Type is not 'inline_base64'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.VoiceReference"/> if <see cref="Type"/> is 'voice', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'voice'.</exception>
    public global::ElevenLabs.VoiceReference AsVoice() =>
        IsVoice
            ? (global::ElevenLabs.VoiceReference)Value!
            : throw new global::System.Exception("TemplateInputReference.Type is not 'voice'");

    public T Match<T>(
        Func<global::ElevenLabs.StaticAssetReference, T> onAsset,
        Func<global::ElevenLabs.GenerationReference, T> onGeneration,
        Func<global::ElevenLabs.InlineBase64Reference, T> onInlineBase64,
        Func<global::ElevenLabs.VoiceReference, T> onVoice,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "asset" => onAsset(AsAsset()),
            "generation" => onGeneration(AsGeneration()),
            "inline_base64" => onInlineBase64(AsInlineBase64()),
            "voice" => onVoice(AsVoice()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.StaticAssetReference> onAsset,
        Action<global::ElevenLabs.GenerationReference> onGeneration,
        Action<global::ElevenLabs.InlineBase64Reference> onInlineBase64,
        Action<global::ElevenLabs.VoiceReference> onVoice,
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
            case "voice":
                onVoice(AsVoice());
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
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.InlineBase64Reference"/> and returns true if successful.
    /// </summary>
    public bool TryAsInlineBase64(out global::ElevenLabs.InlineBase64Reference? value)
    {
        if (Type == "inline_base64")
        {
            value = (global::ElevenLabs.InlineBase64Reference)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.VoiceReference"/> and returns true if successful.
    /// </summary>
    public bool TryAsVoice(out global::ElevenLabs.VoiceReference? value)
    {
        if (Type == "voice")
        {
            value = (global::ElevenLabs.VoiceReference)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator TemplateInputReference(TemplateInputReference.Asset value) =>
        new(value);

    public static implicit operator TemplateInputReference(
        TemplateInputReference.Generation value
    ) => new(value);

    public static implicit operator TemplateInputReference(
        TemplateInputReference.InlineBase64 value
    ) => new(value);

    public static implicit operator TemplateInputReference(TemplateInputReference.Voice value) =>
        new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<TemplateInputReference>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(TemplateInputReference).IsAssignableFrom(typeToConvert);

        public override TemplateInputReference Read(
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
                "inline_base64" => json.Deserialize<global::ElevenLabs.InlineBase64Reference?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.InlineBase64Reference"
                    ),
                "voice" => json.Deserialize<global::ElevenLabs.VoiceReference?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.VoiceReference"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new TemplateInputReference(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TemplateInputReference value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "asset" => JsonSerializer.SerializeToNode(value.Value, options),
                    "generation" => JsonSerializer.SerializeToNode(value.Value, options),
                    "inline_base64" => JsonSerializer.SerializeToNode(value.Value, options),
                    "voice" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override TemplateInputReference ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new TemplateInputReference(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TemplateInputReference value,
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

        public static implicit operator TemplateInputReference.Asset(
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

        public static implicit operator TemplateInputReference.Generation(
            global::ElevenLabs.GenerationReference value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for inline_base64
    /// </summary>
    [Serializable]
    public struct InlineBase64
    {
        public InlineBase64(global::ElevenLabs.InlineBase64Reference value)
        {
            Value = value;
        }

        internal global::ElevenLabs.InlineBase64Reference Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator TemplateInputReference.InlineBase64(
            global::ElevenLabs.InlineBase64Reference value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for voice
    /// </summary>
    [Serializable]
    public struct Voice
    {
        public Voice(global::ElevenLabs.VoiceReference value)
        {
            Value = value;
        }

        internal global::ElevenLabs.VoiceReference Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator TemplateInputReference.Voice(
            global::ElevenLabs.VoiceReference value
        ) => new(value);
    }
}
