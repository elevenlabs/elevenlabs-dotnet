// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(CompositionPlanChunksItem.JsonConverter))]
[Serializable]
public class CompositionPlanChunksItem
{
    private CompositionPlanChunksItem(string type, object? value)
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
    /// Create a CompositionPlanChunksItem from a GenerationChunkInput value.
    /// </summary>
    public static CompositionPlanChunksItem FromGenerationChunkInput(
        global::ElevenLabs.GenerationChunkInput value
    ) => new("generationChunkInput", value);

    /// <summary>
    /// Create a CompositionPlanChunksItem from a AudioRefChunk value.
    /// </summary>
    public static CompositionPlanChunksItem FromAudioRefChunk(
        global::ElevenLabs.AudioRefChunk value
    ) => new("audioRefChunk", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "generationChunkInput".
    /// </summary>
    public bool IsGenerationChunkInput() => Type == "generationChunkInput";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "audioRefChunk".
    /// </summary>
    public bool IsAudioRefChunk() => Type == "audioRefChunk";

    /// <summary>
    /// Returns the value as a GenerationChunkInput if <see cref="Type"/> is "generationChunkInput", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'generationChunkInput'.</exception>
    public global::ElevenLabs.GenerationChunkInput AsGenerationChunkInput() =>
        IsGenerationChunkInput()
            ? (global::ElevenLabs.GenerationChunkInput)Value!
            : throw new ElevenLabsClientException("Union type is not 'generationChunkInput'");

    /// <summary>
    /// Returns the value as a AudioRefChunk if <see cref="Type"/> is "audioRefChunk", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'audioRefChunk'.</exception>
    public global::ElevenLabs.AudioRefChunk AsAudioRefChunk() =>
        IsAudioRefChunk()
            ? (global::ElevenLabs.AudioRefChunk)Value!
            : throw new ElevenLabsClientException("Union type is not 'audioRefChunk'");

    /// <summary>
    /// Attempts to cast the value to a GenerationChunkInput and returns true if successful.
    /// </summary>
    public bool TryGetGenerationChunkInput(out global::ElevenLabs.GenerationChunkInput? value)
    {
        if (Type == "generationChunkInput")
        {
            value = (global::ElevenLabs.GenerationChunkInput)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a AudioRefChunk and returns true if successful.
    /// </summary>
    public bool TryGetAudioRefChunk(out global::ElevenLabs.AudioRefChunk? value)
    {
        if (Type == "audioRefChunk")
        {
            value = (global::ElevenLabs.AudioRefChunk)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        global::System.Func<global::ElevenLabs.GenerationChunkInput, T> onGenerationChunkInput,
        global::System.Func<global::ElevenLabs.AudioRefChunk, T> onAudioRefChunk
    )
    {
        return Type switch
        {
            "generationChunkInput" => onGenerationChunkInput(AsGenerationChunkInput()),
            "audioRefChunk" => onAudioRefChunk(AsAudioRefChunk()),
            _ => throw new ElevenLabsClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<global::ElevenLabs.GenerationChunkInput> onGenerationChunkInput,
        global::System.Action<global::ElevenLabs.AudioRefChunk> onAudioRefChunk
    )
    {
        switch (Type)
        {
            case "generationChunkInput":
                onGenerationChunkInput(AsGenerationChunkInput());
                break;
            case "audioRefChunk":
                onAudioRefChunk(AsAudioRefChunk());
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
        if (obj is not CompositionPlanChunksItem other)
            return false;
        if (Type != other.Type)
            return false;
        return System.Collections.Generic.EqualityComparer<object?>.Default.Equals(
            Value,
            other.Value
        );
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator CompositionPlanChunksItem(
        global::ElevenLabs.GenerationChunkInput value
    ) => new("generationChunkInput", value);

    public static implicit operator CompositionPlanChunksItem(
        global::ElevenLabs.AudioRefChunk value
    ) => new("audioRefChunk", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<CompositionPlanChunksItem>
    {
        public override CompositionPlanChunksItem? Read(
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
                    ("generationChunkInput", typeof(global::ElevenLabs.GenerationChunkInput)),
                    ("audioRefChunk", typeof(global::ElevenLabs.AudioRefChunk)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            return new CompositionPlanChunksItem(key, value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next candidate type.
                    }
                }
            }

            throw new JsonException(
                $"Cannot deserialize JSON token {reader.TokenType} into CompositionPlanChunksItem"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            CompositionPlanChunksItem value,
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

        public override CompositionPlanChunksItem ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            CompositionPlanChunksItem result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CompositionPlanChunksItem value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
