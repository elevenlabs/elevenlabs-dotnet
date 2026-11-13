// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(MusicOutputFormat.JsonConverter))]
[Serializable]
public class MusicOutputFormat
{
    private MusicOutputFormat(string type, object? value)
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
    /// Create a MusicOutputFormat from a MusicAllowedOutputFormats value.
    /// </summary>
    public static MusicOutputFormat FromMusicAllowedOutputFormats(
        global::ElevenLabs.MusicAllowedOutputFormats value
    ) => new("musicAllowedOutputFormats", value);

    /// <summary>
    /// Create a MusicOutputFormat from a MusicOutputFormat2 value.
    /// </summary>
    public static MusicOutputFormat FromMusicOutputFormat2(
        global::ElevenLabs.MusicOutputFormat2 value
    ) => new("musicOutputFormat2", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "musicAllowedOutputFormats".
    /// </summary>
    public bool IsMusicAllowedOutputFormats() => Type == "musicAllowedOutputFormats";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "musicOutputFormat2".
    /// </summary>
    public bool IsMusicOutputFormat2() => Type == "musicOutputFormat2";

    /// <summary>
    /// Returns the value as a MusicAllowedOutputFormats if <see cref="Type"/> is "musicAllowedOutputFormats", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'musicAllowedOutputFormats'.</exception>
    public global::ElevenLabs.MusicAllowedOutputFormats AsMusicAllowedOutputFormats() =>
        IsMusicAllowedOutputFormats()
            ? (global::ElevenLabs.MusicAllowedOutputFormats)Value!
            : throw new ElevenLabsClientException("Union type is not 'musicAllowedOutputFormats'");

    /// <summary>
    /// Returns the value as a MusicOutputFormat2 if <see cref="Type"/> is "musicOutputFormat2", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'musicOutputFormat2'.</exception>
    public global::ElevenLabs.MusicOutputFormat2 AsMusicOutputFormat2() =>
        IsMusicOutputFormat2()
            ? (global::ElevenLabs.MusicOutputFormat2)Value!
            : throw new ElevenLabsClientException("Union type is not 'musicOutputFormat2'");

    /// <summary>
    /// Attempts to cast the value to a MusicAllowedOutputFormats and returns true if successful.
    /// </summary>
    public bool TryGetMusicAllowedOutputFormats(
        out global::ElevenLabs.MusicAllowedOutputFormats? value
    )
    {
        if (Type == "musicAllowedOutputFormats")
        {
            value = (global::ElevenLabs.MusicAllowedOutputFormats)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a MusicOutputFormat2 and returns true if successful.
    /// </summary>
    public bool TryGetMusicOutputFormat2(out global::ElevenLabs.MusicOutputFormat2? value)
    {
        if (Type == "musicOutputFormat2")
        {
            value = (global::ElevenLabs.MusicOutputFormat2)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        global::System.Func<
            global::ElevenLabs.MusicAllowedOutputFormats,
            T
        > onMusicAllowedOutputFormats,
        global::System.Func<global::ElevenLabs.MusicOutputFormat2, T> onMusicOutputFormat2
    )
    {
        return Type switch
        {
            "musicAllowedOutputFormats" => onMusicAllowedOutputFormats(
                AsMusicAllowedOutputFormats()
            ),
            "musicOutputFormat2" => onMusicOutputFormat2(AsMusicOutputFormat2()),
            _ => throw new ElevenLabsClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<global::ElevenLabs.MusicAllowedOutputFormats> onMusicAllowedOutputFormats,
        global::System.Action<global::ElevenLabs.MusicOutputFormat2> onMusicOutputFormat2
    )
    {
        switch (Type)
        {
            case "musicAllowedOutputFormats":
                onMusicAllowedOutputFormats(AsMusicAllowedOutputFormats());
                break;
            case "musicOutputFormat2":
                onMusicOutputFormat2(AsMusicOutputFormat2());
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
        if (obj is not MusicOutputFormat other)
            return false;
        if (Type != other.Type)
            return false;
        return System.Collections.Generic.EqualityComparer<object?>.Default.Equals(
            Value,
            other.Value
        );
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator MusicOutputFormat(
        global::ElevenLabs.MusicAllowedOutputFormats value
    ) => new("musicAllowedOutputFormats", value);

    public static implicit operator MusicOutputFormat(
        global::ElevenLabs.MusicOutputFormat2 value
    ) => new("musicOutputFormat2", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<MusicOutputFormat>
    {
        public override MusicOutputFormat? Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            if (reader.TokenType == JsonTokenType.String)
            {
                var stringValue = reader.GetString()!;

                MusicOutputFormat stringEnumResult = new(
                    "musicOutputFormat2",
                    (global::ElevenLabs.MusicOutputFormat2)stringValue
                );
                return stringEnumResult;
            }

            if (reader.TokenType == JsonTokenType.StartObject)
            {
                var document = JsonDocument.ParseValue(ref reader);

                var types = new (string Key, global::System.Type Type)[]
                {
                    (
                        "musicAllowedOutputFormats",
                        typeof(global::ElevenLabs.MusicAllowedOutputFormats)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            return new MusicOutputFormat(key, value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next candidate type.
                    }
                }
            }

            throw new JsonException(
                $"Cannot deserialize JSON token {reader.TokenType} into MusicOutputFormat"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            MusicOutputFormat value,
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

        public override MusicOutputFormat ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            MusicOutputFormat result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            MusicOutputFormat value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
