using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The MIME type of the encoded audio.</summary>
[JsonConverter(typeof(InlineAudioReferenceMimeType.InlineAudioReferenceMimeTypeSerializer))]
[Serializable]
public readonly record struct InlineAudioReferenceMimeType : IStringEnum
{
    public static readonly InlineAudioReferenceMimeType AudioMpeg = new(Values.AudioMpeg);

    public static readonly InlineAudioReferenceMimeType AudioWav = new(Values.AudioWav);

    public InlineAudioReferenceMimeType(string value)
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
    public static InlineAudioReferenceMimeType FromCustom(string value)
    {
        return new InlineAudioReferenceMimeType(value);
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

    public static bool operator ==(InlineAudioReferenceMimeType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(InlineAudioReferenceMimeType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(InlineAudioReferenceMimeType value) => value.Value;

    public static explicit operator InlineAudioReferenceMimeType(string value) => new(value);

    internal class InlineAudioReferenceMimeTypeSerializer
        : JsonConverter<InlineAudioReferenceMimeType>
    {
        public override InlineAudioReferenceMimeType Read(
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
            return new InlineAudioReferenceMimeType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            InlineAudioReferenceMimeType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override InlineAudioReferenceMimeType ReadAsPropertyName(
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
            return new InlineAudioReferenceMimeType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            InlineAudioReferenceMimeType value,
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
        public const string AudioMpeg = "audio/mpeg";

        public const string AudioWav = "audio/wav";
    }
}
