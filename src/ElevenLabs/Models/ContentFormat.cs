using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>
/// Canonical representation of a knowledge base document's stored content.
///
/// HTML is the legacy default; documents created before this field existed are
/// interpreted as HTML.
/// </summary>
[JsonConverter(typeof(ContentFormat.ContentFormatSerializer))]
[Serializable]
public readonly record struct ContentFormat : IStringEnum
{
    public static readonly ContentFormat Html = new(Values.Html);

    public static readonly ContentFormat Markdown = new(Values.Markdown);

    public ContentFormat(string value)
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
    public static ContentFormat FromCustom(string value)
    {
        return new ContentFormat(value);
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

    public static bool operator ==(ContentFormat value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ContentFormat value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ContentFormat value) => value.Value;

    public static explicit operator ContentFormat(string value) => new(value);

    internal class ContentFormatSerializer : JsonConverter<ContentFormat>
    {
        public override ContentFormat Read(
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
            return new ContentFormat(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ContentFormat value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ContentFormat ReadAsPropertyName(
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
            return new ContentFormat(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ContentFormat value,
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
        public const string Html = "html";

        public const string Markdown = "markdown";
    }
}
