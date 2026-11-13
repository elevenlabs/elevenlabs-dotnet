using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The MIME type of the encoded media.</summary>
[JsonConverter(typeof(InlineBase64ReferenceMimeType.InlineBase64ReferenceMimeTypeSerializer))]
[Serializable]
public readonly record struct InlineBase64ReferenceMimeType : IStringEnum
{
    public static readonly InlineBase64ReferenceMimeType ImageJpeg = new(Values.ImageJpeg);

    public static readonly InlineBase64ReferenceMimeType ImagePng = new(Values.ImagePng);

    public static readonly InlineBase64ReferenceMimeType ImageWebp = new(Values.ImageWebp);

    public static readonly InlineBase64ReferenceMimeType ImageHeic = new(Values.ImageHeic);

    public static readonly InlineBase64ReferenceMimeType ImageHeif = new(Values.ImageHeif);

    public static readonly InlineBase64ReferenceMimeType AudioMpeg = new(Values.AudioMpeg);

    public static readonly InlineBase64ReferenceMimeType AudioWav = new(Values.AudioWav);

    public static readonly InlineBase64ReferenceMimeType VideoMp4 = new(Values.VideoMp4);

    public static readonly InlineBase64ReferenceMimeType VideoQuicktime = new(
        Values.VideoQuicktime
    );

    public static readonly InlineBase64ReferenceMimeType VideoWebm = new(Values.VideoWebm);

    public InlineBase64ReferenceMimeType(string value)
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
    public static InlineBase64ReferenceMimeType FromCustom(string value)
    {
        return new InlineBase64ReferenceMimeType(value);
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

    public static bool operator ==(InlineBase64ReferenceMimeType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(InlineBase64ReferenceMimeType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(InlineBase64ReferenceMimeType value) => value.Value;

    public static explicit operator InlineBase64ReferenceMimeType(string value) => new(value);

    internal class InlineBase64ReferenceMimeTypeSerializer
        : JsonConverter<InlineBase64ReferenceMimeType>
    {
        public override InlineBase64ReferenceMimeType Read(
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
            return new InlineBase64ReferenceMimeType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            InlineBase64ReferenceMimeType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override InlineBase64ReferenceMimeType ReadAsPropertyName(
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
            return new InlineBase64ReferenceMimeType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            InlineBase64ReferenceMimeType value,
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
        public const string ImageJpeg = "image/jpeg";

        public const string ImagePng = "image/png";

        public const string ImageWebp = "image/webp";

        public const string ImageHeic = "image/heic";

        public const string ImageHeif = "image/heif";

        public const string AudioMpeg = "audio/mpeg";

        public const string AudioWav = "audio/wav";

        public const string VideoMp4 = "video/mp4";

        public const string VideoQuicktime = "video/quicktime";

        public const string VideoWebm = "video/webm";
    }
}
