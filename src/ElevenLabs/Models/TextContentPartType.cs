using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(TextContentPartType.TextContentPartTypeSerializer))]
[Serializable]
public readonly record struct TextContentPartType : IStringEnum
{
    public static readonly TextContentPartType Text = new(Values.Text);

    public TextContentPartType(string value)
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
    public static TextContentPartType FromCustom(string value)
    {
        return new TextContentPartType(value);
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

    public static bool operator ==(TextContentPartType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TextContentPartType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TextContentPartType value) => value.Value;

    public static explicit operator TextContentPartType(string value) => new(value);

    internal class TextContentPartTypeSerializer : JsonConverter<TextContentPartType>
    {
        public override TextContentPartType Read(
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
            return new TextContentPartType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TextContentPartType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TextContentPartType ReadAsPropertyName(
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
            return new TextContentPartType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TextContentPartType value,
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
        public const string Text = "text";
    }
}
