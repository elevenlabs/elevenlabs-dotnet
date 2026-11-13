using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The type of the rule.</summary>
[JsonConverter(
    typeof(PronunciationDictionaryPhonemeRuleRequestModelType.PronunciationDictionaryPhonemeRuleRequestModelTypeSerializer)
)]
[Serializable]
public readonly record struct PronunciationDictionaryPhonemeRuleRequestModelType : IStringEnum
{
    public static readonly PronunciationDictionaryPhonemeRuleRequestModelType Phoneme = new(
        Values.Phoneme
    );

    public PronunciationDictionaryPhonemeRuleRequestModelType(string value)
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
    public static PronunciationDictionaryPhonemeRuleRequestModelType FromCustom(string value)
    {
        return new PronunciationDictionaryPhonemeRuleRequestModelType(value);
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
        PronunciationDictionaryPhonemeRuleRequestModelType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        PronunciationDictionaryPhonemeRuleRequestModelType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        PronunciationDictionaryPhonemeRuleRequestModelType value
    ) => value.Value;

    public static explicit operator PronunciationDictionaryPhonemeRuleRequestModelType(
        string value
    ) => new(value);

    internal class PronunciationDictionaryPhonemeRuleRequestModelTypeSerializer
        : JsonConverter<PronunciationDictionaryPhonemeRuleRequestModelType>
    {
        public override PronunciationDictionaryPhonemeRuleRequestModelType Read(
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
            return new PronunciationDictionaryPhonemeRuleRequestModelType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PronunciationDictionaryPhonemeRuleRequestModelType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PronunciationDictionaryPhonemeRuleRequestModelType ReadAsPropertyName(
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
            return new PronunciationDictionaryPhonemeRuleRequestModelType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PronunciationDictionaryPhonemeRuleRequestModelType value,
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
        public const string Phoneme = "phoneme";
    }
}
