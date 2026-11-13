// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(MusicAllowedOutputFormats.JsonConverter))]
[Serializable]
public class MusicAllowedOutputFormats
{
    private MusicAllowedOutputFormats(string type, object? value)
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
    /// Create a MusicAllowedOutputFormats from a AllowedOutputFormats value.
    /// </summary>
    public static MusicAllowedOutputFormats FromAllowedOutputFormats(
        global::ElevenLabs.AllowedOutputFormats value
    ) => new("allowedOutputFormats", value);

    /// <summary>
    /// Create a MusicAllowedOutputFormats from a MusicOnlyOutputFormats value.
    /// </summary>
    public static MusicAllowedOutputFormats FromMusicOnlyOutputFormats(
        global::ElevenLabs.MusicOnlyOutputFormats value
    ) => new("musicOnlyOutputFormats", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "allowedOutputFormats".
    /// </summary>
    public bool IsAllowedOutputFormats() => Type == "allowedOutputFormats";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "musicOnlyOutputFormats".
    /// </summary>
    public bool IsMusicOnlyOutputFormats() => Type == "musicOnlyOutputFormats";

    /// <summary>
    /// Returns the value as a AllowedOutputFormats if <see cref="Type"/> is "allowedOutputFormats", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'allowedOutputFormats'.</exception>
    public global::ElevenLabs.AllowedOutputFormats AsAllowedOutputFormats() =>
        IsAllowedOutputFormats()
            ? (global::ElevenLabs.AllowedOutputFormats)Value!
            : throw new ElevenLabsClientException("Union type is not 'allowedOutputFormats'");

    /// <summary>
    /// Returns the value as a MusicOnlyOutputFormats if <see cref="Type"/> is "musicOnlyOutputFormats", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'musicOnlyOutputFormats'.</exception>
    public global::ElevenLabs.MusicOnlyOutputFormats AsMusicOnlyOutputFormats() =>
        IsMusicOnlyOutputFormats()
            ? (global::ElevenLabs.MusicOnlyOutputFormats)Value!
            : throw new ElevenLabsClientException("Union type is not 'musicOnlyOutputFormats'");

    /// <summary>
    /// Attempts to cast the value to a AllowedOutputFormats and returns true if successful.
    /// </summary>
    public bool TryGetAllowedOutputFormats(out global::ElevenLabs.AllowedOutputFormats? value)
    {
        if (Type == "allowedOutputFormats")
        {
            value = (global::ElevenLabs.AllowedOutputFormats)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a MusicOnlyOutputFormats and returns true if successful.
    /// </summary>
    public bool TryGetMusicOnlyOutputFormats(out global::ElevenLabs.MusicOnlyOutputFormats? value)
    {
        if (Type == "musicOnlyOutputFormats")
        {
            value = (global::ElevenLabs.MusicOnlyOutputFormats)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        global::System.Func<global::ElevenLabs.AllowedOutputFormats, T> onAllowedOutputFormats,
        global::System.Func<global::ElevenLabs.MusicOnlyOutputFormats, T> onMusicOnlyOutputFormats
    )
    {
        return Type switch
        {
            "allowedOutputFormats" => onAllowedOutputFormats(AsAllowedOutputFormats()),
            "musicOnlyOutputFormats" => onMusicOnlyOutputFormats(AsMusicOnlyOutputFormats()),
            _ => throw new ElevenLabsClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<global::ElevenLabs.AllowedOutputFormats> onAllowedOutputFormats,
        global::System.Action<global::ElevenLabs.MusicOnlyOutputFormats> onMusicOnlyOutputFormats
    )
    {
        switch (Type)
        {
            case "allowedOutputFormats":
                onAllowedOutputFormats(AsAllowedOutputFormats());
                break;
            case "musicOnlyOutputFormats":
                onMusicOnlyOutputFormats(AsMusicOnlyOutputFormats());
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
        if (obj is not MusicAllowedOutputFormats other)
            return false;
        if (Type != other.Type)
            return false;
        return System.Collections.Generic.EqualityComparer<object?>.Default.Equals(
            Value,
            other.Value
        );
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator MusicAllowedOutputFormats(
        global::ElevenLabs.AllowedOutputFormats value
    ) => new("allowedOutputFormats", value);

    public static implicit operator MusicAllowedOutputFormats(
        global::ElevenLabs.MusicOnlyOutputFormats value
    ) => new("musicOnlyOutputFormats", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<MusicAllowedOutputFormats>
    {
        public override MusicAllowedOutputFormats? Read(
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

                MusicAllowedOutputFormats stringEnumResult = new(
                    "allowedOutputFormats",
                    (global::ElevenLabs.AllowedOutputFormats)stringValue
                );
                return stringEnumResult;
            }

            throw new JsonException(
                $"Cannot deserialize JSON token {reader.TokenType} into MusicAllowedOutputFormats"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            MusicAllowedOutputFormats value,
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

        public override MusicAllowedOutputFormats ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            MusicAllowedOutputFormats result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            MusicAllowedOutputFormats value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
