using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(SubtitlingPartialSubtitleMessageType.SubtitlingPartialSubtitleMessageTypeSerializer)
)]
[Serializable]
public readonly record struct SubtitlingPartialSubtitleMessageType : IStringEnum
{
    public static readonly SubtitlingPartialSubtitleMessageType PartialSubtitle = new(
        Values.PartialSubtitle
    );

    public SubtitlingPartialSubtitleMessageType(string value)
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
    public static SubtitlingPartialSubtitleMessageType FromCustom(string value)
    {
        return new SubtitlingPartialSubtitleMessageType(value);
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

    public static bool operator ==(SubtitlingPartialSubtitleMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SubtitlingPartialSubtitleMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SubtitlingPartialSubtitleMessageType value) =>
        value.Value;

    public static explicit operator SubtitlingPartialSubtitleMessageType(string value) =>
        new(value);

    internal class SubtitlingPartialSubtitleMessageTypeSerializer
        : JsonConverter<SubtitlingPartialSubtitleMessageType>
    {
        public override SubtitlingPartialSubtitleMessageType Read(
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
            return new SubtitlingPartialSubtitleMessageType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SubtitlingPartialSubtitleMessageType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SubtitlingPartialSubtitleMessageType ReadAsPropertyName(
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
            return new SubtitlingPartialSubtitleMessageType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SubtitlingPartialSubtitleMessageType value,
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
        public const string PartialSubtitle = "partial_subtitle";
    }
}
