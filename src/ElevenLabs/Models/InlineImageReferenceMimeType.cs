using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The MIME type of the encoded image.</summary>
[JsonConverter(typeof(InlineImageReferenceMimeType.InlineImageReferenceMimeTypeSerializer))]
[Serializable]
public readonly record struct InlineImageReferenceMimeType : IStringEnum
{
    public static readonly InlineImageReferenceMimeType ImageJpeg = new(Values.ImageJpeg);

    public static readonly InlineImageReferenceMimeType ImagePng = new(Values.ImagePng);

    public static readonly InlineImageReferenceMimeType ImageWebp = new(Values.ImageWebp);

    public static readonly InlineImageReferenceMimeType ImageHeic = new(Values.ImageHeic);

    public static readonly InlineImageReferenceMimeType ImageHeif = new(Values.ImageHeif);

    public InlineImageReferenceMimeType(string value)
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
    public static InlineImageReferenceMimeType FromCustom(string value)
    {
        return new InlineImageReferenceMimeType(value);
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

    public static bool operator ==(InlineImageReferenceMimeType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(InlineImageReferenceMimeType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(InlineImageReferenceMimeType value) => value.Value;

    public static explicit operator InlineImageReferenceMimeType(string value) => new(value);

    internal class InlineImageReferenceMimeTypeSerializer
        : JsonConverter<InlineImageReferenceMimeType>
    {
        public override InlineImageReferenceMimeType Read(
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
            return new InlineImageReferenceMimeType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            InlineImageReferenceMimeType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override InlineImageReferenceMimeType ReadAsPropertyName(
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
            return new InlineImageReferenceMimeType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            InlineImageReferenceMimeType value,
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
    }
}
