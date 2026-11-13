using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>How eagerly translation starts while the speaker is still talking. 'high' starts translating soonest for the lowest latency. 'low' waits for more of the sentence, giving higher quality translations with more delay.</summary>
[JsonConverter(typeof(TranslationRealtimeEagerness.TranslationRealtimeEagernessSerializer))]
[Serializable]
public readonly record struct TranslationRealtimeEagerness : IStringEnum
{
    public static readonly TranslationRealtimeEagerness Low = new(Values.Low);

    public static readonly TranslationRealtimeEagerness Medium = new(Values.Medium);

    public static readonly TranslationRealtimeEagerness High = new(Values.High);

    public TranslationRealtimeEagerness(string value)
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
    public static TranslationRealtimeEagerness FromCustom(string value)
    {
        return new TranslationRealtimeEagerness(value);
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

    public static bool operator ==(TranslationRealtimeEagerness value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TranslationRealtimeEagerness value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TranslationRealtimeEagerness value) => value.Value;

    public static explicit operator TranslationRealtimeEagerness(string value) => new(value);

    internal class TranslationRealtimeEagernessSerializer
        : JsonConverter<TranslationRealtimeEagerness>
    {
        public override TranslationRealtimeEagerness Read(
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
            return new TranslationRealtimeEagerness(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TranslationRealtimeEagerness value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TranslationRealtimeEagerness ReadAsPropertyName(
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
            return new TranslationRealtimeEagerness(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TranslationRealtimeEagerness value,
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
