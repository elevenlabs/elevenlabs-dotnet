// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ReceiveTextToDialogueWebsocketMessageMulti.JsonConverter))]
[Serializable]
public class ReceiveTextToDialogueWebsocketMessageMulti
{
    private ReceiveTextToDialogueWebsocketMessageMulti(string type, object? value)
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
    /// Create a ReceiveTextToDialogueWebsocketMessageMulti from a AudioChunkMulti value.
    /// </summary>
    public static ReceiveTextToDialogueWebsocketMessageMulti FromAudioChunkMulti(
        global::ElevenLabs.AudioChunkMulti value
    ) => new("audioChunkMulti", value);

    /// <summary>
    /// Create a ReceiveTextToDialogueWebsocketMessageMulti from a FinalAudioForTurnMulti value.
    /// </summary>
    public static ReceiveTextToDialogueWebsocketMessageMulti FromFinalAudioForTurnMulti(
        global::ElevenLabs.FinalAudioForTurnMulti value
    ) => new("finalAudioForTurnMulti", value);

    /// <summary>
    /// Create a ReceiveTextToDialogueWebsocketMessageMulti from a FinalMulti value.
    /// </summary>
    public static ReceiveTextToDialogueWebsocketMessageMulti FromFinalMulti(
        global::ElevenLabs.FinalMulti value
    ) => new("finalMulti", value);

    /// <summary>
    /// Create a ReceiveTextToDialogueWebsocketMessageMulti from a Error value.
    /// </summary>
    public static ReceiveTextToDialogueWebsocketMessageMulti FromError(
        global::ElevenLabs.Error value
    ) => new("error", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "audioChunkMulti".
    /// </summary>
    public bool IsAudioChunkMulti() => Type == "audioChunkMulti";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "finalAudioForTurnMulti".
    /// </summary>
    public bool IsFinalAudioForTurnMulti() => Type == "finalAudioForTurnMulti";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "finalMulti".
    /// </summary>
    public bool IsFinalMulti() => Type == "finalMulti";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "error".
    /// </summary>
    public bool IsError() => Type == "error";

    /// <summary>
    /// Returns the value as a AudioChunkMulti if <see cref="Type"/> is "audioChunkMulti", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'audioChunkMulti'.</exception>
    public global::ElevenLabs.AudioChunkMulti AsAudioChunkMulti() =>
        IsAudioChunkMulti()
            ? (global::ElevenLabs.AudioChunkMulti)Value!
            : throw new ElevenLabsClientException("Union type is not 'audioChunkMulti'");

    /// <summary>
    /// Returns the value as a FinalAudioForTurnMulti if <see cref="Type"/> is "finalAudioForTurnMulti", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'finalAudioForTurnMulti'.</exception>
    public global::ElevenLabs.FinalAudioForTurnMulti AsFinalAudioForTurnMulti() =>
        IsFinalAudioForTurnMulti()
            ? (global::ElevenLabs.FinalAudioForTurnMulti)Value!
            : throw new ElevenLabsClientException("Union type is not 'finalAudioForTurnMulti'");

    /// <summary>
    /// Returns the value as a FinalMulti if <see cref="Type"/> is "finalMulti", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'finalMulti'.</exception>
    public global::ElevenLabs.FinalMulti AsFinalMulti() =>
        IsFinalMulti()
            ? (global::ElevenLabs.FinalMulti)Value!
            : throw new ElevenLabsClientException("Union type is not 'finalMulti'");

    /// <summary>
    /// Returns the value as a Error if <see cref="Type"/> is "error", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'error'.</exception>
    public global::ElevenLabs.Error AsError() =>
        IsError()
            ? (global::ElevenLabs.Error)Value!
            : throw new ElevenLabsClientException("Union type is not 'error'");

    /// <summary>
    /// Attempts to cast the value to a AudioChunkMulti and returns true if successful.
    /// </summary>
    public bool TryGetAudioChunkMulti(out global::ElevenLabs.AudioChunkMulti? value)
    {
        if (Type == "audioChunkMulti")
        {
            value = (global::ElevenLabs.AudioChunkMulti)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a FinalAudioForTurnMulti and returns true if successful.
    /// </summary>
    public bool TryGetFinalAudioForTurnMulti(out global::ElevenLabs.FinalAudioForTurnMulti? value)
    {
        if (Type == "finalAudioForTurnMulti")
        {
            value = (global::ElevenLabs.FinalAudioForTurnMulti)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a FinalMulti and returns true if successful.
    /// </summary>
    public bool TryGetFinalMulti(out global::ElevenLabs.FinalMulti? value)
    {
        if (Type == "finalMulti")
        {
            value = (global::ElevenLabs.FinalMulti)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a Error and returns true if successful.
    /// </summary>
    public bool TryGetError(out global::ElevenLabs.Error? value)
    {
        if (Type == "error")
        {
            value = (global::ElevenLabs.Error)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        global::System.Func<global::ElevenLabs.AudioChunkMulti, T> onAudioChunkMulti,
        global::System.Func<global::ElevenLabs.FinalAudioForTurnMulti, T> onFinalAudioForTurnMulti,
        global::System.Func<global::ElevenLabs.FinalMulti, T> onFinalMulti,
        global::System.Func<global::ElevenLabs.Error, T> onError
    )
    {
        return Type switch
        {
            "audioChunkMulti" => onAudioChunkMulti(AsAudioChunkMulti()),
            "finalAudioForTurnMulti" => onFinalAudioForTurnMulti(AsFinalAudioForTurnMulti()),
            "finalMulti" => onFinalMulti(AsFinalMulti()),
            "error" => onError(AsError()),
            _ => throw new ElevenLabsClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<global::ElevenLabs.AudioChunkMulti> onAudioChunkMulti,
        global::System.Action<global::ElevenLabs.FinalAudioForTurnMulti> onFinalAudioForTurnMulti,
        global::System.Action<global::ElevenLabs.FinalMulti> onFinalMulti,
        global::System.Action<global::ElevenLabs.Error> onError
    )
    {
        switch (Type)
        {
            case "audioChunkMulti":
                onAudioChunkMulti(AsAudioChunkMulti());
                break;
            case "finalAudioForTurnMulti":
                onFinalAudioForTurnMulti(AsFinalAudioForTurnMulti());
                break;
            case "finalMulti":
                onFinalMulti(AsFinalMulti());
                break;
            case "error":
                onError(AsError());
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
        if (obj is not ReceiveTextToDialogueWebsocketMessageMulti other)
            return false;
        if (Type != other.Type)
            return false;
        return System.Collections.Generic.EqualityComparer<object?>.Default.Equals(
            Value,
            other.Value
        );
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator ReceiveTextToDialogueWebsocketMessageMulti(
        global::ElevenLabs.AudioChunkMulti value
    ) => new("audioChunkMulti", value);

    public static implicit operator ReceiveTextToDialogueWebsocketMessageMulti(
        global::ElevenLabs.FinalAudioForTurnMulti value
    ) => new("finalAudioForTurnMulti", value);

    public static implicit operator ReceiveTextToDialogueWebsocketMessageMulti(
        global::ElevenLabs.FinalMulti value
    ) => new("finalMulti", value);

    public static implicit operator ReceiveTextToDialogueWebsocketMessageMulti(
        global::ElevenLabs.Error value
    ) => new("error", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<ReceiveTextToDialogueWebsocketMessageMulti>
    {
        public override ReceiveTextToDialogueWebsocketMessageMulti? Read(
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

                var types = new (string Key, global::System.Type Type, string[] AnyOfKeys)[]
                {
                    (
                        "audioChunkMulti",
                        typeof(global::ElevenLabs.AudioChunkMulti),
                        new[] { "audio", "alignment", "normalized_alignment", "context_id" }
                    ),
                    (
                        "finalAudioForTurnMulti",
                        typeof(global::ElevenLabs.FinalAudioForTurnMulti),
                        new[] { "is_final_audio_for_turn", "context_id" }
                    ),
                    (
                        "finalMulti",
                        typeof(global::ElevenLabs.FinalMulti),
                        global::System.Array.Empty<string>()
                    ),
                    (
                        "error",
                        typeof(global::ElevenLabs.Error),
                        global::System.Array.Empty<string>()
                    ),
                };

                foreach (var (key, type, anyOfKeys) in types)
                {
                    // A member whose properties are all optional deserializes from any object, so it
                    // only gets a turn when the payload carries one of its own keys.
                    if (anyOfKeys.Length > 0 && !HasAnyProperty(document, anyOfKeys))
                    {
                        continue;
                    }

                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            return new ReceiveTextToDialogueWebsocketMessageMulti(key, value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next candidate type.
                    }
                }
            }

            throw new JsonException(
                $"Cannot deserialize JSON token {reader.TokenType} into ReceiveTextToDialogueWebsocketMessageMulti"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReceiveTextToDialogueWebsocketMessageMulti value,
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
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override ReceiveTextToDialogueWebsocketMessageMulti ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            ReceiveTextToDialogueWebsocketMessageMulti result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReceiveTextToDialogueWebsocketMessageMulti value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }

        private static bool HasAnyProperty(JsonDocument document, string[] keys)
        {
            foreach (var key in keys)
            {
                if (document.RootElement.TryGetProperty(key, out _))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
