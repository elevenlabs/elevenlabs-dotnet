// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Flows;

[JsonConverter(typeof(TextToSpeechGenerationRequest.JsonConverter))]
[Serializable]
public record TextToSpeechGenerationRequest
{
    internal TextToSpeechGenerationRequest(string type, object? value)
    {
        ModelId = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of TextToSpeechGenerationRequest with <see cref="TextToSpeechGenerationRequest.ElevenFlashV2_5"/>.
    /// </summary>
    public TextToSpeechGenerationRequest(TextToSpeechGenerationRequest.ElevenFlashV2_5 value)
    {
        ModelId = "eleven_flash_v2_5";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of TextToSpeechGenerationRequest with <see cref="TextToSpeechGenerationRequest.ElevenMultilingualV2"/>.
    /// </summary>
    public TextToSpeechGenerationRequest(TextToSpeechGenerationRequest.ElevenMultilingualV2 value)
    {
        ModelId = "eleven_multilingual_v2";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of TextToSpeechGenerationRequest with <see cref="TextToSpeechGenerationRequest.ElevenV3"/>.
    /// </summary>
    public TextToSpeechGenerationRequest(TextToSpeechGenerationRequest.ElevenV3 value)
    {
        ModelId = "eleven_v3";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("model_id")]
    public string ModelId { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="ModelId"/> is "eleven_flash_v2_5"
    /// </summary>
    public bool IsElevenFlashV2_5 => ModelId == "eleven_flash_v2_5";

    /// <summary>
    /// Returns true if <see cref="ModelId"/> is "eleven_multilingual_v2"
    /// </summary>
    public bool IsElevenMultilingualV2 => ModelId == "eleven_multilingual_v2";

    /// <summary>
    /// Returns true if <see cref="ModelId"/> is "eleven_v3"
    /// </summary>
    public bool IsElevenV3 => ModelId == "eleven_v3";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ElevenFlashV25Request"/> if <see cref="ModelId"/> is 'eleven_flash_v2_5', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ModelId"/> is not 'eleven_flash_v2_5'.</exception>
    public global::ElevenLabs.ElevenFlashV25Request AsElevenFlashV2_5() =>
        IsElevenFlashV2_5
            ? (global::ElevenLabs.ElevenFlashV25Request)Value!
            : throw new global::System.Exception(
                "TextToSpeechGenerationRequest.ModelId is not 'eleven_flash_v2_5'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ElevenMultilingualV2Request"/> if <see cref="ModelId"/> is 'eleven_multilingual_v2', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ModelId"/> is not 'eleven_multilingual_v2'.</exception>
    public global::ElevenLabs.ElevenMultilingualV2Request AsElevenMultilingualV2() =>
        IsElevenMultilingualV2
            ? (global::ElevenLabs.ElevenMultilingualV2Request)Value!
            : throw new global::System.Exception(
                "TextToSpeechGenerationRequest.ModelId is not 'eleven_multilingual_v2'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.ElevenV3Request"/> if <see cref="ModelId"/> is 'eleven_v3', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ModelId"/> is not 'eleven_v3'.</exception>
    public global::ElevenLabs.ElevenV3Request AsElevenV3() =>
        IsElevenV3
            ? (global::ElevenLabs.ElevenV3Request)Value!
            : throw new global::System.Exception(
                "TextToSpeechGenerationRequest.ModelId is not 'eleven_v3'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.ElevenFlashV25Request, T> onElevenFlashV2_5,
        Func<global::ElevenLabs.ElevenMultilingualV2Request, T> onElevenMultilingualV2,
        Func<global::ElevenLabs.ElevenV3Request, T> onElevenV3,
        Func<string, object?, T> onUnknown_
    )
    {
        return ModelId switch
        {
            "eleven_flash_v2_5" => onElevenFlashV2_5(AsElevenFlashV2_5()),
            "eleven_multilingual_v2" => onElevenMultilingualV2(AsElevenMultilingualV2()),
            "eleven_v3" => onElevenV3(AsElevenV3()),
            _ => onUnknown_(ModelId, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.ElevenFlashV25Request> onElevenFlashV2_5,
        Action<global::ElevenLabs.ElevenMultilingualV2Request> onElevenMultilingualV2,
        Action<global::ElevenLabs.ElevenV3Request> onElevenV3,
        Action<string, object?> onUnknown_
    )
    {
        switch (ModelId)
        {
            case "eleven_flash_v2_5":
                onElevenFlashV2_5(AsElevenFlashV2_5());
                break;
            case "eleven_multilingual_v2":
                onElevenMultilingualV2(AsElevenMultilingualV2());
                break;
            case "eleven_v3":
                onElevenV3(AsElevenV3());
                break;
            default:
                onUnknown_(ModelId, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ElevenFlashV25Request"/> and returns true if successful.
    /// </summary>
    public bool TryAsElevenFlashV2_5(out global::ElevenLabs.ElevenFlashV25Request? value)
    {
        if (ModelId == "eleven_flash_v2_5")
        {
            value = (global::ElevenLabs.ElevenFlashV25Request)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ElevenMultilingualV2Request"/> and returns true if successful.
    /// </summary>
    public bool TryAsElevenMultilingualV2(out global::ElevenLabs.ElevenMultilingualV2Request? value)
    {
        if (ModelId == "eleven_multilingual_v2")
        {
            value = (global::ElevenLabs.ElevenMultilingualV2Request)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.ElevenV3Request"/> and returns true if successful.
    /// </summary>
    public bool TryAsElevenV3(out global::ElevenLabs.ElevenV3Request? value)
    {
        if (ModelId == "eleven_v3")
        {
            value = (global::ElevenLabs.ElevenV3Request)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator TextToSpeechGenerationRequest(
        TextToSpeechGenerationRequest.ElevenFlashV2_5 value
    ) => new(value);

    public static implicit operator TextToSpeechGenerationRequest(
        TextToSpeechGenerationRequest.ElevenMultilingualV2 value
    ) => new(value);

    public static implicit operator TextToSpeechGenerationRequest(
        TextToSpeechGenerationRequest.ElevenV3 value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<TextToSpeechGenerationRequest>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(TextToSpeechGenerationRequest).IsAssignableFrom(typeToConvert);

        public override TextToSpeechGenerationRequest Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (!json.TryGetProperty("model_id", out var discriminatorElement))
            {
                throw new JsonException("Missing discriminator property 'model_id'");
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException("Discriminator property 'model_id' is null");
                }

                throw new JsonException(
                    $"Discriminator property 'model_id' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException("Discriminator property 'model_id' is null");

            var value = discriminator switch
            {
                "eleven_flash_v2_5" => json.Deserialize<global::ElevenLabs.ElevenFlashV25Request?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.ElevenFlashV25Request"
                    ),
                "eleven_multilingual_v2" =>
                    json.Deserialize<global::ElevenLabs.ElevenMultilingualV2Request?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.ElevenMultilingualV2Request"
                        ),
                "eleven_v3" => json.Deserialize<global::ElevenLabs.ElevenV3Request?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.ElevenV3Request"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new TextToSpeechGenerationRequest(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TextToSpeechGenerationRequest value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.ModelId switch
                {
                    "eleven_flash_v2_5" => JsonSerializer.SerializeToNode(value.Value, options),
                    "eleven_multilingual_v2" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "eleven_v3" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["model_id"] = value.ModelId;
            json.WriteTo(writer, options);
        }

        public override TextToSpeechGenerationRequest ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new TextToSpeechGenerationRequest(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TextToSpeechGenerationRequest value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.ModelId);
        }
    }

    /// <summary>
    /// Discriminated union type for eleven_flash_v2_5
    /// </summary>
    [Serializable]
    public struct ElevenFlashV2_5
    {
        public ElevenFlashV2_5(global::ElevenLabs.ElevenFlashV25Request value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ElevenFlashV25Request Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator TextToSpeechGenerationRequest.ElevenFlashV2_5(
            global::ElevenLabs.ElevenFlashV25Request value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for eleven_multilingual_v2
    /// </summary>
    [Serializable]
    public struct ElevenMultilingualV2
    {
        public ElevenMultilingualV2(global::ElevenLabs.ElevenMultilingualV2Request value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ElevenMultilingualV2Request Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator TextToSpeechGenerationRequest.ElevenMultilingualV2(
            global::ElevenLabs.ElevenMultilingualV2Request value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for eleven_v3
    /// </summary>
    [Serializable]
    public struct ElevenV3
    {
        public ElevenV3(global::ElevenLabs.ElevenV3Request value)
        {
            Value = value;
        }

        internal global::ElevenLabs.ElevenV3Request Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator TextToSpeechGenerationRequest.ElevenV3(
            global::ElevenLabs.ElevenV3Request value
        ) => new(value);
    }
}
