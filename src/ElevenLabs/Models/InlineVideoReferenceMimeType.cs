using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The MIME type of the encoded video.</summary>
[JsonConverter(typeof(InlineVideoReferenceMimeType.InlineVideoReferenceMimeTypeSerializer))]
[Serializable]
public readonly record struct InlineVideoReferenceMimeType : IStringEnum
{
    public static readonly InlineVideoReferenceMimeType VideoMp4 = new(Values.VideoMp4);

    public static readonly InlineVideoReferenceMimeType VideoQuicktime = new(Values.VideoQuicktime);

    public static readonly InlineVideoReferenceMimeType VideoWebm = new(Values.VideoWebm);

    public InlineVideoReferenceMimeType(string value)
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
    public static InlineVideoReferenceMimeType FromCustom(string value)
    {
        return new InlineVideoReferenceMimeType(value);
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

    public static bool operator ==(InlineVideoReferenceMimeType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(InlineVideoReferenceMimeType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(InlineVideoReferenceMimeType value) => value.Value;

    public static explicit operator InlineVideoReferenceMimeType(string value) => new(value);

    internal class InlineVideoReferenceMimeTypeSerializer
        : JsonConverter<InlineVideoReferenceMimeType>
    {
        public override InlineVideoReferenceMimeType Read(
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
            return new InlineVideoReferenceMimeType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            InlineVideoReferenceMimeType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override InlineVideoReferenceMimeType ReadAsPropertyName(
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
            return new InlineVideoReferenceMimeType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            InlineVideoReferenceMimeType value,
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
        public const string VideoMp4 = "video/mp4";

        public const string VideoQuicktime = "video/quicktime";

        public const string VideoWebm = "video/webm";
    }
}
