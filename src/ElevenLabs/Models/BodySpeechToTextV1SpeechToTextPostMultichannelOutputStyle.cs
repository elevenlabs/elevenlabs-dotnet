using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Controls the response shape when use_multi_channel is enabled. 'separate' (default) returns one transcript per channel under 'transcripts'. 'combined' merges all channels into a single transcript whose words are sorted by start time, each carrying a 'channel_index' - matching the single-channel response shape. 'combined' requires timestamps (timestamps_granularity must not be 'none') and does not support entity detection or redaction.</summary>
[JsonConverter(
    typeof(BodySpeechToTextV1SpeechToTextPostMultichannelOutputStyle.BodySpeechToTextV1SpeechToTextPostMultichannelOutputStyleSerializer)
)]
[Serializable]
public readonly record struct BodySpeechToTextV1SpeechToTextPostMultichannelOutputStyle
    : IStringEnum
{
    public static readonly BodySpeechToTextV1SpeechToTextPostMultichannelOutputStyle Separate = new(
        Values.Separate
    );

    public static readonly BodySpeechToTextV1SpeechToTextPostMultichannelOutputStyle Combined = new(
        Values.Combined
    );

    public BodySpeechToTextV1SpeechToTextPostMultichannelOutputStyle(string value)
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
    public static BodySpeechToTextV1SpeechToTextPostMultichannelOutputStyle FromCustom(string value)
    {
        return new BodySpeechToTextV1SpeechToTextPostMultichannelOutputStyle(value);
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

    public static bool operator ==(
        BodySpeechToTextV1SpeechToTextPostMultichannelOutputStyle value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BodySpeechToTextV1SpeechToTextPostMultichannelOutputStyle value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        BodySpeechToTextV1SpeechToTextPostMultichannelOutputStyle value
    ) => value.Value;

    public static explicit operator BodySpeechToTextV1SpeechToTextPostMultichannelOutputStyle(
        string value
    ) => new(value);

    internal class BodySpeechToTextV1SpeechToTextPostMultichannelOutputStyleSerializer
        : JsonConverter<BodySpeechToTextV1SpeechToTextPostMultichannelOutputStyle>
    {
        public override BodySpeechToTextV1SpeechToTextPostMultichannelOutputStyle Read(
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
            return new BodySpeechToTextV1SpeechToTextPostMultichannelOutputStyle(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BodySpeechToTextV1SpeechToTextPostMultichannelOutputStyle value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BodySpeechToTextV1SpeechToTextPostMultichannelOutputStyle ReadAsPropertyName(
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
            return new BodySpeechToTextV1SpeechToTextPostMultichannelOutputStyle(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BodySpeechToTextV1SpeechToTextPostMultichannelOutputStyle value,
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
        public const string Separate = "separate";

        public const string Combined = "combined";
    }
}
