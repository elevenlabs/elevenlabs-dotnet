using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The type of the word or sound. 'audio_event' is used for non-word sounds like laughter or footsteps.</summary>
[JsonConverter(
    typeof(SpeechToTextWordResponseModelType.SpeechToTextWordResponseModelTypeSerializer)
)]
[Serializable]
public readonly record struct SpeechToTextWordResponseModelType : IStringEnum
{
    public static readonly SpeechToTextWordResponseModelType Word = new(Values.Word);

    public static readonly SpeechToTextWordResponseModelType Spacing = new(Values.Spacing);

    public static readonly SpeechToTextWordResponseModelType AudioEvent = new(Values.AudioEvent);

    public SpeechToTextWordResponseModelType(string value)
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
    public static SpeechToTextWordResponseModelType FromCustom(string value)
    {
        return new SpeechToTextWordResponseModelType(value);
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

    public static bool operator ==(SpeechToTextWordResponseModelType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SpeechToTextWordResponseModelType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SpeechToTextWordResponseModelType value) => value.Value;

    public static explicit operator SpeechToTextWordResponseModelType(string value) => new(value);

    internal class SpeechToTextWordResponseModelTypeSerializer
        : JsonConverter<SpeechToTextWordResponseModelType>
    {
        public override SpeechToTextWordResponseModelType Read(
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
            return new SpeechToTextWordResponseModelType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SpeechToTextWordResponseModelType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SpeechToTextWordResponseModelType ReadAsPropertyName(
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
            return new SpeechToTextWordResponseModelType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SpeechToTextWordResponseModelType value,
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
        public const string Word = "word";

        public const string Spacing = "spacing";

        public const string AudioEvent = "audio_event";
    }
}
