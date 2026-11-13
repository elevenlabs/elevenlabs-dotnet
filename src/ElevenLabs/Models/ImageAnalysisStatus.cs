using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ImageAnalysisStatus.ImageAnalysisStatusSerializer))]
[Serializable]
public readonly record struct ImageAnalysisStatus : IStringEnum
{
    public static readonly ImageAnalysisStatus Processing = new(Values.Processing);

    public static readonly ImageAnalysisStatus Completed = new(Values.Completed);

    public static readonly ImageAnalysisStatus Failed = new(Values.Failed);

    public ImageAnalysisStatus(string value)
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
    public static ImageAnalysisStatus FromCustom(string value)
    {
        return new ImageAnalysisStatus(value);
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

    public static bool operator ==(ImageAnalysisStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ImageAnalysisStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ImageAnalysisStatus value) => value.Value;

    public static explicit operator ImageAnalysisStatus(string value) => new(value);

    internal class ImageAnalysisStatusSerializer : JsonConverter<ImageAnalysisStatus>
    {
        public override ImageAnalysisStatus Read(
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
            return new ImageAnalysisStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ImageAnalysisStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ImageAnalysisStatus ReadAsPropertyName(
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
            return new ImageAnalysisStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ImageAnalysisStatus value,
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
        public const string Processing = "processing";

        public const string Completed = "completed";

        public const string Failed = "failed";
    }
}
