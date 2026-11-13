// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ReceiveMessage.JsonConverter))]
[Serializable]
public class ReceiveMessage
{
    private ReceiveMessage(string type, object? value)
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
    /// Create a ReceiveMessage from a AudioOutput value.
    /// </summary>
    public static ReceiveMessage FromAudioOutput(global::ElevenLabs.AudioOutput value) =>
        new("audioOutput", value);

    /// <summary>
    /// Create a ReceiveMessage from a FinalOutput value.
    /// </summary>
    public static ReceiveMessage FromFinalOutput(global::ElevenLabs.FinalOutput value) =>
        new("finalOutput", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "audioOutput".
    /// </summary>
    public bool IsAudioOutput() => Type == "audioOutput";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "finalOutput".
    /// </summary>
    public bool IsFinalOutput() => Type == "finalOutput";

    /// <summary>
    /// Returns the value as a AudioOutput if <see cref="Type"/> is "audioOutput", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'audioOutput'.</exception>
    public global::ElevenLabs.AudioOutput AsAudioOutput() =>
        IsAudioOutput()
            ? (global::ElevenLabs.AudioOutput)Value!
            : throw new ElevenLabsClientException("Union type is not 'audioOutput'");

    /// <summary>
    /// Returns the value as a FinalOutput if <see cref="Type"/> is "finalOutput", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'finalOutput'.</exception>
    public global::ElevenLabs.FinalOutput AsFinalOutput() =>
        IsFinalOutput()
            ? (global::ElevenLabs.FinalOutput)Value!
            : throw new ElevenLabsClientException("Union type is not 'finalOutput'");

    /// <summary>
    /// Attempts to cast the value to a AudioOutput and returns true if successful.
    /// </summary>
    public bool TryGetAudioOutput(out global::ElevenLabs.AudioOutput? value)
    {
        if (Type == "audioOutput")
        {
            value = (global::ElevenLabs.AudioOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a FinalOutput and returns true if successful.
    /// </summary>
    public bool TryGetFinalOutput(out global::ElevenLabs.FinalOutput? value)
    {
        if (Type == "finalOutput")
        {
            value = (global::ElevenLabs.FinalOutput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        global::System.Func<global::ElevenLabs.AudioOutput, T> onAudioOutput,
        global::System.Func<global::ElevenLabs.FinalOutput, T> onFinalOutput
    )
    {
        return Type switch
        {
            "audioOutput" => onAudioOutput(AsAudioOutput()),
            "finalOutput" => onFinalOutput(AsFinalOutput()),
            _ => throw new ElevenLabsClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<global::ElevenLabs.AudioOutput> onAudioOutput,
        global::System.Action<global::ElevenLabs.FinalOutput> onFinalOutput
    )
    {
        switch (Type)
        {
            case "audioOutput":
                onAudioOutput(AsAudioOutput());
                break;
            case "finalOutput":
                onFinalOutput(AsFinalOutput());
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
        if (obj is not ReceiveMessage other)
            return false;
        if (Type != other.Type)
            return false;
        return System.Collections.Generic.EqualityComparer<object?>.Default.Equals(
            Value,
            other.Value
        );
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator ReceiveMessage(global::ElevenLabs.AudioOutput value) =>
        new("audioOutput", value);

    public static implicit operator ReceiveMessage(global::ElevenLabs.FinalOutput value) =>
        new("finalOutput", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<ReceiveMessage>
    {
        public override ReceiveMessage? Read(
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
                        "audioOutput",
                        typeof(global::ElevenLabs.AudioOutput),
                        global::System.Array.Empty<string>()
                    ),
                    ("finalOutput", typeof(global::ElevenLabs.FinalOutput), new[] { "is_final" }),
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
                            return new ReceiveMessage(key, value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next candidate type.
                    }
                }
            }

            throw new JsonException(
                $"Cannot deserialize JSON token {reader.TokenType} into ReceiveMessage"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReceiveMessage value,
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

        public override ReceiveMessage ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            ReceiveMessage result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReceiveMessage value,
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
