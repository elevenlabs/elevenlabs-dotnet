using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ScribeChunkSizeExceededErrorMessageType.ScribeChunkSizeExceededErrorMessageTypeSerializer)
)]
[Serializable]
public readonly record struct ScribeChunkSizeExceededErrorMessageType : IStringEnum
{
    public static readonly ScribeChunkSizeExceededErrorMessageType ChunkSizeExceeded = new(
        Values.ChunkSizeExceeded
    );

    public ScribeChunkSizeExceededErrorMessageType(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static ScribeChunkSizeExceededErrorMessageType FromCustom(string value)
    {
        return new ScribeChunkSizeExceededErrorMessageType(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(ScribeChunkSizeExceededErrorMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ScribeChunkSizeExceededErrorMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ScribeChunkSizeExceededErrorMessageType value) =>
        value.Value;

    public static explicit operator ScribeChunkSizeExceededErrorMessageType(string value) =>
        new(value);

    internal class ScribeChunkSizeExceededErrorMessageTypeSerializer
        : JsonConverter<ScribeChunkSizeExceededErrorMessageType>
    {
        public override ScribeChunkSizeExceededErrorMessageType Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new ScribeChunkSizeExceededErrorMessageType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ScribeChunkSizeExceededErrorMessageType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ScribeChunkSizeExceededErrorMessageType ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new ScribeChunkSizeExceededErrorMessageType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ScribeChunkSizeExceededErrorMessageType value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string ChunkSizeExceeded = "chunk_size_exceeded";
    }
}
