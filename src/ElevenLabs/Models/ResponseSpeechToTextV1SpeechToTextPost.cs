// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ResponseSpeechToTextV1SpeechToTextPost.JsonConverter))]
[Serializable]
public class ResponseSpeechToTextV1SpeechToTextPost
{
    private ResponseSpeechToTextV1SpeechToTextPost(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Type discriminator
    /// </summary>
    [JsonIgnore]
    public string Type { get; internal set; }

    /// <summary>
    /// Union value
    /// </summary>
    [JsonIgnore]
    public object? Value { get; internal set; }

    /// <summary>
    /// Create a ResponseSpeechToTextV1SpeechToTextPost from a SpeechToTextChunkResponseModel value.
    /// </summary>
    public static ResponseSpeechToTextV1SpeechToTextPost FromSpeechToTextChunkResponseModel(
        global::ElevenLabs.SpeechToTextChunkResponseModel value
    ) => new("speechToTextChunkResponseModel", value);

    /// <summary>
    /// Create a ResponseSpeechToTextV1SpeechToTextPost from a MultichannelSpeechToTextResponseModel value.
    /// </summary>
    public static ResponseSpeechToTextV1SpeechToTextPost FromMultichannelSpeechToTextResponseModel(
        global::ElevenLabs.MultichannelSpeechToTextResponseModel value
    ) => new("multichannelSpeechToTextResponseModel", value);

    /// <summary>
    /// Create a ResponseSpeechToTextV1SpeechToTextPost from a SpeechToTextWebhookResponseModel value.
    /// </summary>
    public static ResponseSpeechToTextV1SpeechToTextPost FromSpeechToTextWebhookResponseModel(
        global::ElevenLabs.SpeechToTextWebhookResponseModel value
    ) => new("speechToTextWebhookResponseModel", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "speechToTextChunkResponseModel".
    /// </summary>
    public bool IsSpeechToTextChunkResponseModel() => Type == "speechToTextChunkResponseModel";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "multichannelSpeechToTextResponseModel".
    /// </summary>
    public bool IsMultichannelSpeechToTextResponseModel() =>
        Type == "multichannelSpeechToTextResponseModel";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "speechToTextWebhookResponseModel".
    /// </summary>
    public bool IsSpeechToTextWebhookResponseModel() => Type == "speechToTextWebhookResponseModel";

    /// <summary>
    /// Returns the value as a SpeechToTextChunkResponseModel if <see cref="Type"/> is "speechToTextChunkResponseModel", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'speechToTextChunkResponseModel'.</exception>
    public global::ElevenLabs.SpeechToTextChunkResponseModel AsSpeechToTextChunkResponseModel() =>
        IsSpeechToTextChunkResponseModel()
            ? (global::ElevenLabs.SpeechToTextChunkResponseModel)Value!
            : throw new ElevenLabsClientException(
                "Union type is not 'speechToTextChunkResponseModel'"
            );

    /// <summary>
    /// Returns the value as a MultichannelSpeechToTextResponseModel if <see cref="Type"/> is "multichannelSpeechToTextResponseModel", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'multichannelSpeechToTextResponseModel'.</exception>
    public global::ElevenLabs.MultichannelSpeechToTextResponseModel AsMultichannelSpeechToTextResponseModel() =>
        IsMultichannelSpeechToTextResponseModel()
            ? (global::ElevenLabs.MultichannelSpeechToTextResponseModel)Value!
            : throw new ElevenLabsClientException(
                "Union type is not 'multichannelSpeechToTextResponseModel'"
            );

    /// <summary>
    /// Returns the value as a SpeechToTextWebhookResponseModel if <see cref="Type"/> is "speechToTextWebhookResponseModel", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'speechToTextWebhookResponseModel'.</exception>
    public global::ElevenLabs.SpeechToTextWebhookResponseModel AsSpeechToTextWebhookResponseModel() =>
        IsSpeechToTextWebhookResponseModel()
            ? (global::ElevenLabs.SpeechToTextWebhookResponseModel)Value!
            : throw new ElevenLabsClientException(
                "Union type is not 'speechToTextWebhookResponseModel'"
            );

    /// <summary>
    /// Attempts to cast the value to a SpeechToTextChunkResponseModel and returns true if successful.
    /// </summary>
    public bool TryGetSpeechToTextChunkResponseModel(
        out global::ElevenLabs.SpeechToTextChunkResponseModel? value
    )
    {
        if (Type == "speechToTextChunkResponseModel")
        {
            value = (global::ElevenLabs.SpeechToTextChunkResponseModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a MultichannelSpeechToTextResponseModel and returns true if successful.
    /// </summary>
    public bool TryGetMultichannelSpeechToTextResponseModel(
        out global::ElevenLabs.MultichannelSpeechToTextResponseModel? value
    )
    {
        if (Type == "multichannelSpeechToTextResponseModel")
        {
            value = (global::ElevenLabs.MultichannelSpeechToTextResponseModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a SpeechToTextWebhookResponseModel and returns true if successful.
    /// </summary>
    public bool TryGetSpeechToTextWebhookResponseModel(
        out global::ElevenLabs.SpeechToTextWebhookResponseModel? value
    )
    {
        if (Type == "speechToTextWebhookResponseModel")
        {
            value = (global::ElevenLabs.SpeechToTextWebhookResponseModel)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        global::System.Func<
            global::ElevenLabs.SpeechToTextChunkResponseModel,
            T
        > onSpeechToTextChunkResponseModel,
        global::System.Func<
            global::ElevenLabs.MultichannelSpeechToTextResponseModel,
            T
        > onMultichannelSpeechToTextResponseModel,
        global::System.Func<
            global::ElevenLabs.SpeechToTextWebhookResponseModel,
            T
        > onSpeechToTextWebhookResponseModel
    )
    {
        return Type switch
        {
            "speechToTextChunkResponseModel" => onSpeechToTextChunkResponseModel(
                AsSpeechToTextChunkResponseModel()
            ),
            "multichannelSpeechToTextResponseModel" => onMultichannelSpeechToTextResponseModel(
                AsMultichannelSpeechToTextResponseModel()
            ),
            "speechToTextWebhookResponseModel" => onSpeechToTextWebhookResponseModel(
                AsSpeechToTextWebhookResponseModel()
            ),
            _ => throw new ElevenLabsClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<global::ElevenLabs.SpeechToTextChunkResponseModel> onSpeechToTextChunkResponseModel,
        global::System.Action<global::ElevenLabs.MultichannelSpeechToTextResponseModel> onMultichannelSpeechToTextResponseModel,
        global::System.Action<global::ElevenLabs.SpeechToTextWebhookResponseModel> onSpeechToTextWebhookResponseModel
    )
    {
        switch (Type)
        {
            case "speechToTextChunkResponseModel":
                onSpeechToTextChunkResponseModel(AsSpeechToTextChunkResponseModel());
                break;
            case "multichannelSpeechToTextResponseModel":
                onMultichannelSpeechToTextResponseModel(AsMultichannelSpeechToTextResponseModel());
                break;
            case "speechToTextWebhookResponseModel":
                onSpeechToTextWebhookResponseModel(AsSpeechToTextWebhookResponseModel());
                break;
            default:
                throw new ElevenLabsClientException($"Unknown union type: {Type}");
        }
    }

    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode = Type.GetHashCode();
            if (Value != null)
            {
                hashCode = (hashCode * 397) ^ Value.GetHashCode();
            }
            return hashCode;
        }
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;
        if (ReferenceEquals(this, obj))
            return true;
        if (obj is not ResponseSpeechToTextV1SpeechToTextPost other)
            return false;
        if (Type != other.Type)
            return false;
        return System.Collections.Generic.EqualityComparer<object?>.Default.Equals(
            Value,
            other.Value
        );
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator ResponseSpeechToTextV1SpeechToTextPost(
        global::ElevenLabs.SpeechToTextChunkResponseModel value
    ) => new("speechToTextChunkResponseModel", value);

    public static implicit operator ResponseSpeechToTextV1SpeechToTextPost(
        global::ElevenLabs.MultichannelSpeechToTextResponseModel value
    ) => new("multichannelSpeechToTextResponseModel", value);

    public static implicit operator ResponseSpeechToTextV1SpeechToTextPost(
        global::ElevenLabs.SpeechToTextWebhookResponseModel value
    ) => new("speechToTextWebhookResponseModel", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<ResponseSpeechToTextV1SpeechToTextPost>
    {
        public override ResponseSpeechToTextV1SpeechToTextPost? Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            if (reader.TokenType == JsonTokenType.StartObject)
            {
                var document = JsonDocument.ParseValue(ref reader);

                var types = new (string Key, global::System.Type Type)[]
                {
                    (
                        "speechToTextChunkResponseModel",
                        typeof(global::ElevenLabs.SpeechToTextChunkResponseModel)
                    ),
                    (
                        "multichannelSpeechToTextResponseModel",
                        typeof(global::ElevenLabs.MultichannelSpeechToTextResponseModel)
                    ),
                    (
                        "speechToTextWebhookResponseModel",
                        typeof(global::ElevenLabs.SpeechToTextWebhookResponseModel)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            return new ResponseSpeechToTextV1SpeechToTextPost(key, value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next candidate type.
                    }
                }
            }

            throw new JsonException(
                $"Cannot deserialize JSON token {reader.TokenType} into ResponseSpeechToTextV1SpeechToTextPost"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ResponseSpeechToTextV1SpeechToTextPost value,
            JsonSerializerOptions options
        )
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }

            value.Visit(
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override ResponseSpeechToTextV1SpeechToTextPost ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            ResponseSpeechToTextV1SpeechToTextPost result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ResponseSpeechToTextV1SpeechToTextPost value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
