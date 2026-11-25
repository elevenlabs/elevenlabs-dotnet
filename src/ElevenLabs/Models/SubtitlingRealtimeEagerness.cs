using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>How eagerly translation starts while the speaker is still talking. 'high' starts translating soonest, so subtitles appear sooner. 'low' waits for more of the sentence, giving higher quality translations with more delay.</summary>
[JsonConverter(typeof(SubtitlingRealtimeEagerness.SubtitlingRealtimeEagernessSerializer))]
[Serializable]
public readonly record struct SubtitlingRealtimeEagerness : IStringEnum
{
    public static readonly SubtitlingRealtimeEagerness Low = new(Values.Low);

    public static readonly SubtitlingRealtimeEagerness Medium = new(Values.Medium);

    public static readonly SubtitlingRealtimeEagerness High = new(Values.High);

    public SubtitlingRealtimeEagerness(string value)
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
    public static SubtitlingRealtimeEagerness FromCustom(string value)
    {
        return new SubtitlingRealtimeEagerness(value);
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

    public static bool operator ==(SubtitlingRealtimeEagerness value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SubtitlingRealtimeEagerness value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SubtitlingRealtimeEagerness value) => value.Value;

    public static explicit operator SubtitlingRealtimeEagerness(string value) => new(value);

    internal class SubtitlingRealtimeEagernessSerializer
        : JsonConverter<SubtitlingRealtimeEagerness>
    {
        public override SubtitlingRealtimeEagerness Read(
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
            return new SubtitlingRealtimeEagerness(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SubtitlingRealtimeEagerness value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SubtitlingRealtimeEagerness ReadAsPropertyName(
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
            return new SubtitlingRealtimeEagerness(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SubtitlingRealtimeEagerness value,
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
        public const string Low = "low";

        public const string Medium = "medium";

        public const string High = "high";
    }
}
