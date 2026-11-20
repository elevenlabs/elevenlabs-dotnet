using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(FileInputMimeType.FileInputMimeTypeSerializer))]
[Serializable]
public readonly record struct FileInputMimeType : IStringEnum
{
    public static readonly FileInputMimeType ImagePng = new(Values.ImagePng);

    public static readonly FileInputMimeType ImageJpeg = new(Values.ImageJpeg);

    public static readonly FileInputMimeType ImageGif = new(Values.ImageGif);

    public static readonly FileInputMimeType ImageWebp = new(Values.ImageWebp);

    public static readonly FileInputMimeType ApplicationPdf = new(Values.ApplicationPdf);

    public static readonly FileInputMimeType TextPlain = new(Values.TextPlain);

    public FileInputMimeType(string value)
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
    public static FileInputMimeType FromCustom(string value)
    {
        return new FileInputMimeType(value);
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

    public static bool operator ==(FileInputMimeType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FileInputMimeType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FileInputMimeType value) => value.Value;

    public static explicit operator FileInputMimeType(string value) => new(value);

    internal class FileInputMimeTypeSerializer : JsonConverter<FileInputMimeType>
    {
        public override FileInputMimeType Read(
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
            return new FileInputMimeType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FileInputMimeType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FileInputMimeType ReadAsPropertyName(
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
            return new FileInputMimeType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FileInputMimeType value,
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
        public const string ImagePng = "image/png";

        public const string ImageJpeg = "image/jpeg";

        public const string ImageGif = "image/gif";

        public const string ImageWebp = "image/webp";

        public const string ApplicationPdf = "application/pdf";

        public const string TextPlain = "text/plain";
    }
}
