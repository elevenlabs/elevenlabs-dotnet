// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ReceiveTextToDialogueWebsocketMessage.JsonConverter))]
[Serializable]
public class ReceiveTextToDialogueWebsocketMessage
{
    private ReceiveTextToDialogueWebsocketMessage(string type, object? value)
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
    /// Create a ReceiveTextToDialogueWebsocketMessage from a AudioChunk value.
    /// </summary>
    public static ReceiveTextToDialogueWebsocketMessage FromAudioChunk(
        global::ElevenLabs.AudioChunk value
    ) => new("audioChunk", value);

    /// <summary>
    /// Create a ReceiveTextToDialogueWebsocketMessage from a FinalAudioForTurn value.
    /// </summary>
    public static ReceiveTextToDialogueWebsocketMessage FromFinalAudioForTurn(
        global::ElevenLabs.FinalAudioForTurn value
    ) => new("finalAudioForTurn", value);

    /// <summary>
    /// Create a ReceiveTextToDialogueWebsocketMessage from a Final value.
    /// </summary>
    public static ReceiveTextToDialogueWebsocketMessage FromFinal(global::ElevenLabs.Final value) =>
        new("final", value);

    /// <summary>
    /// Create a ReceiveTextToDialogueWebsocketMessage from a Error value.
    /// </summary>
    public static ReceiveTextToDialogueWebsocketMessage FromError(global::ElevenLabs.Error value) =>
        new("error", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "audioChunk".
    /// </summary>
    public bool IsAudioChunk() => Type == "audioChunk";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "finalAudioForTurn".
    /// </summary>
    public bool IsFinalAudioForTurn() => Type == "finalAudioForTurn";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "final".
    /// </summary>
    public bool IsFinal() => Type == "final";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "error".
    /// </summary>
    public bool IsError() => Type == "error";

    /// <summary>
    /// Returns the value as a AudioChunk if <see cref="Type"/> is "audioChunk", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'audioChunk'.</exception>
    public global::ElevenLabs.AudioChunk AsAudioChunk() =>
        IsAudioChunk()
            ? (global::ElevenLabs.AudioChunk)Value!
            : throw new ElevenLabsClientException("Union type is not 'audioChunk'");

    /// <summary>
    /// Returns the value as a FinalAudioForTurn if <see cref="Type"/> is "finalAudioForTurn", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'finalAudioForTurn'.</exception>
    public global::ElevenLabs.FinalAudioForTurn AsFinalAudioForTurn() =>
        IsFinalAudioForTurn()
            ? (global::ElevenLabs.FinalAudioForTurn)Value!
            : throw new ElevenLabsClientException("Union type is not 'finalAudioForTurn'");

    /// <summary>
    /// Returns the value as a Final if <see cref="Type"/> is "final", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'final'.</exception>
    public global::ElevenLabs.Final AsFinal() =>
        IsFinal()
            ? (global::ElevenLabs.Final)Value!
            : throw new ElevenLabsClientException("Union type is not 'final'");

    /// <summary>
    /// Returns the value as a Error if <see cref="Type"/> is "error", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'error'.</exception>
    public global::ElevenLabs.Error AsError() =>
        IsError()
            ? (global::ElevenLabs.Error)Value!
            : throw new ElevenLabsClientException("Union type is not 'error'");

    /// <summary>
    /// Attempts to cast the value to a AudioChunk and returns true if successful.
    /// </summary>
    public bool TryGetAudioChunk(out global::ElevenLabs.AudioChunk? value)
    {
        if (Type == "audioChunk")
        {
            value = (global::ElevenLabs.AudioChunk)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a FinalAudioForTurn and returns true if successful.
    /// </summary>
    public bool TryGetFinalAudioForTurn(out global::ElevenLabs.FinalAudioForTurn? value)
    {
        if (Type == "finalAudioForTurn")
        {
            value = (global::ElevenLabs.FinalAudioForTurn)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a Final and returns true if successful.
    /// </summary>
    public bool TryGetFinal(out global::ElevenLabs.Final? value)
    {
        if (Type == "final")
        {
            value = (global::ElevenLabs.Final)Value!;
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
        global::System.Func<global::ElevenLabs.AudioChunk, T> onAudioChunk,
        global::System.Func<global::ElevenLabs.FinalAudioForTurn, T> onFinalAudioForTurn,
        global::System.Func<global::ElevenLabs.Final, T> onFinal,
        global::System.Func<global::ElevenLabs.Error, T> onError
    )
    {
        return Type switch
        {
            "audioChunk" => onAudioChunk(AsAudioChunk()),
            "finalAudioForTurn" => onFinalAudioForTurn(AsFinalAudioForTurn()),
            "final" => onFinal(AsFinal()),
            "error" => onError(AsError()),
            _ => throw new ElevenLabsClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<global::ElevenLabs.AudioChunk> onAudioChunk,
        global::System.Action<global::ElevenLabs.FinalAudioForTurn> onFinalAudioForTurn,
        global::System.Action<global::ElevenLabs.Final> onFinal,
        global::System.Action<global::ElevenLabs.Error> onError
    )
    {
        switch (Type)
        {
            case "audioChunk":
                onAudioChunk(AsAudioChunk());
                break;
            case "finalAudioForTurn":
                onFinalAudioForTurn(AsFinalAudioForTurn());
                break;
            case "final":
                onFinal(AsFinal());
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
        if (obj is not ReceiveTextToDialogueWebsocketMessage other)
            return false;
        if (Type != other.Type)
            return false;
        return System.Collections.Generic.EqualityComparer<object?>.Default.Equals(
            Value,
            other.Value
        );
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator ReceiveTextToDialogueWebsocketMessage(
        global::ElevenLabs.AudioChunk value
    ) => new("audioChunk", value);

    public static implicit operator ReceiveTextToDialogueWebsocketMessage(
        global::ElevenLabs.FinalAudioForTurn value
    ) => new("finalAudioForTurn", value);

    public static implicit operator ReceiveTextToDialogueWebsocketMessage(
        global::ElevenLabs.Final value
    ) => new("final", value);

    public static implicit operator ReceiveTextToDialogueWebsocketMessage(
        global::ElevenLabs.Error value
    ) => new("error", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<ReceiveTextToDialogueWebsocketMessage>
    {
        public override ReceiveTextToDialogueWebsocketMessage? Read(
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
                        "audioChunk",
                        typeof(global::ElevenLabs.AudioChunk),
                        new[] { "audio", "alignment", "normalized_alignment" }
                    ),
                    (
                        "finalAudioForTurn",
                        typeof(global::ElevenLabs.FinalAudioForTurn),
                        new[] { "is_final_audio_for_turn" }
                    ),
                    (
                        "final",
                        typeof(global::ElevenLabs.Final),
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
                            return new ReceiveTextToDialogueWebsocketMessage(key, value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next candidate type.
                    }
                }
            }

            throw new JsonException(
                $"Cannot deserialize JSON token {reader.TokenType} into ReceiveTextToDialogueWebsocketMessage"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReceiveTextToDialogueWebsocketMessage value,
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

        public override ReceiveTextToDialogueWebsocketMessage ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            ReceiveTextToDialogueWebsocketMessage result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReceiveTextToDialogueWebsocketMessage value,
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
