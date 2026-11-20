using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(TextOutputItemType.TextOutputItemTypeSerializer))]
[Serializable]
public readonly record struct TextOutputItemType : IStringEnum
{
    public static readonly TextOutputItemType Text = new(Values.Text);

    public TextOutputItemType(string value)
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
    public static TextOutputItemType FromCustom(string value)
    {
        return new TextOutputItemType(value);
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

    public static bool operator ==(TextOutputItemType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TextOutputItemType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TextOutputItemType value) => value.Value;

    public static explicit operator TextOutputItemType(string value) => new(value);

    internal class TextOutputItemTypeSerializer : JsonConverter<TextOutputItemType>
    {
        public override TextOutputItemType Read(
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
            return new TextOutputItemType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TextOutputItemType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TextOutputItemType ReadAsPropertyName(
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
            return new TextOutputItemType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TextOutputItemType value,
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
