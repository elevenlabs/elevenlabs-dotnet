using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Method for converting numbers to words before sending to TTS</summary>
[JsonConverter(typeof(TextNormalisationType.TextNormalisationTypeSerializer))]
[Serializable]
public readonly record struct TextNormalisationType : IStringEnum
{
    public static readonly TextNormalisationType SystemPrompt = new(Values.SystemPrompt);

    public static readonly TextNormalisationType Elevenlabs = new(Values.Elevenlabs);

    public TextNormalisationType(string value)
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
    public static TextNormalisationType FromCustom(string value)
    {
        return new TextNormalisationType(value);
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

    public static bool operator ==(TextNormalisationType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TextNormalisationType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TextNormalisationType value) => value.Value;

    public static explicit operator TextNormalisationType(string value) => new(value);

    internal class TextNormalisationTypeSerializer : JsonConverter<TextNormalisationType>
    {
        public override TextNormalisationType Read(
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
            return new TextNormalisationType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TextNormalisationType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TextNormalisationType ReadAsPropertyName(
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
            return new TextNormalisationType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TextNormalisationType value,
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
        public const string SystemPrompt = "system_prompt";

        public const string Elevenlabs = "elevenlabs";
    }
}
