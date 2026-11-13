// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ReceiveMessageMulti.JsonConverter))]
[Serializable]
public class ReceiveMessageMulti
{
    private ReceiveMessageMulti(string type, object? value)
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
    /// Create a ReceiveMessageMulti from a AudioOutputMulti value.
    /// </summary>
    public static ReceiveMessageMulti FromAudioOutputMulti(
        global::ElevenLabs.AudioOutputMulti value
    ) => new("audioOutputMulti", value);

    /// <summary>
    /// Create a ReceiveMessageMulti from a FinalOutputMulti value.
    /// </summary>
    public static ReceiveMessageMulti FromFinalOutputMulti(
        global::ElevenLabs.FinalOutputMulti value
    ) => new("finalOutputMulti", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "audioOutputMulti".
    /// </summary>
    public bool IsAudioOutputMulti() => Type == "audioOutputMulti";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "finalOutputMulti".
    /// </summary>
    public bool IsFinalOutputMulti() => Type == "finalOutputMulti";

    /// <summary>
    /// Returns the value as a AudioOutputMulti if <see cref="Type"/> is "audioOutputMulti", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'audioOutputMulti'.</exception>
    public global::ElevenLabs.AudioOutputMulti AsAudioOutputMulti() =>
        IsAudioOutputMulti()
            ? (global::ElevenLabs.AudioOutputMulti)Value!
            : throw new ElevenLabsClientException("Union type is not 'audioOutputMulti'");

    /// <summary>
    /// Returns the value as a FinalOutputMulti if <see cref="Type"/> is "finalOutputMulti", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'finalOutputMulti'.</exception>
    public global::ElevenLabs.FinalOutputMulti AsFinalOutputMulti() =>
        IsFinalOutputMulti()
            ? (global::ElevenLabs.FinalOutputMulti)Value!
            : throw new ElevenLabsClientException("Union type is not 'finalOutputMulti'");

    /// <summary>
    /// Attempts to cast the value to a AudioOutputMulti and returns true if successful.
    /// </summary>
    public bool TryGetAudioOutputMulti(out global::ElevenLabs.AudioOutputMulti? value)
    {
        if (Type == "audioOutputMulti")
        {
            value = (global::ElevenLabs.AudioOutputMulti)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a FinalOutputMulti and returns true if successful.
    /// </summary>
    public bool TryGetFinalOutputMulti(out global::ElevenLabs.FinalOutputMulti? value)
    {
        if (Type == "finalOutputMulti")
        {
            value = (global::ElevenLabs.FinalOutputMulti)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        global::System.Func<global::ElevenLabs.AudioOutputMulti, T> onAudioOutputMulti,
        global::System.Func<global::ElevenLabs.FinalOutputMulti, T> onFinalOutputMulti
    )
    {
        return Type switch
        {
            "audioOutputMulti" => onAudioOutputMulti(AsAudioOutputMulti()),
            "finalOutputMulti" => onFinalOutputMulti(AsFinalOutputMulti()),
            _ => throw new ElevenLabsClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<global::ElevenLabs.AudioOutputMulti> onAudioOutputMulti,
        global::System.Action<global::ElevenLabs.FinalOutputMulti> onFinalOutputMulti
    )
    {
        switch (Type)
        {
            case "audioOutputMulti":
                onAudioOutputMulti(AsAudioOutputMulti());
                break;
            case "finalOutputMulti":
                onFinalOutputMulti(AsFinalOutputMulti());
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
        if (obj is not ReceiveMessageMulti other)
            return false;
        if (Type != other.Type)
            return false;
        return System.Collections.Generic.EqualityComparer<object?>.Default.Equals(
            Value,
            other.Value
        );
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator ReceiveMessageMulti(
        global::ElevenLabs.AudioOutputMulti value
    ) => new("audioOutputMulti", value);

    public static implicit operator ReceiveMessageMulti(
        global::ElevenLabs.FinalOutputMulti value
    ) => new("finalOutputMulti", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<ReceiveMessageMulti>
    {
        public override ReceiveMessageMulti? Read(
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
                        "audioOutputMulti",
                        typeof(global::ElevenLabs.AudioOutputMulti),
                        global::System.Array.Empty<string>()
                    ),
                    (
                        "finalOutputMulti",
                        typeof(global::ElevenLabs.FinalOutputMulti),
                        new[] { "is_final", "context_id" }
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
                            return new ReceiveMessageMulti(key, value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next candidate type.
                    }
                }
            }

            throw new JsonException(
                $"Cannot deserialize JSON token {reader.TokenType} into ReceiveMessageMulti"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReceiveMessageMulti value,
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
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override ReceiveMessageMulti ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            ReceiveMessageMulti result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReceiveMessageMulti value,
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
