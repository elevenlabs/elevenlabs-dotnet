using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ChapterContentBlockInputModelSubType.ChapterContentBlockInputModelSubTypeSerializer)
)]
[Serializable]
public readonly record struct ChapterContentBlockInputModelSubType : IStringEnum
{
    public static readonly ChapterContentBlockInputModelSubType P = new(Values.P);

    public static readonly ChapterContentBlockInputModelSubType H1 = new(Values.H1);

    public static readonly ChapterContentBlockInputModelSubType H2 = new(Values.H2);

    public static readonly ChapterContentBlockInputModelSubType H3 = new(Values.H3);

    public ChapterContentBlockInputModelSubType(string value)
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
    public static ChapterContentBlockInputModelSubType FromCustom(string value)
    {
        return new ChapterContentBlockInputModelSubType(value);
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

    public static bool operator ==(ChapterContentBlockInputModelSubType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ChapterContentBlockInputModelSubType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ChapterContentBlockInputModelSubType value) =>
        value.Value;

    public static explicit operator ChapterContentBlockInputModelSubType(string value) =>
        new(value);

    internal class ChapterContentBlockInputModelSubTypeSerializer
        : JsonConverter<ChapterContentBlockInputModelSubType>
    {
        public override ChapterContentBlockInputModelSubType Read(
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
            return new ChapterContentBlockInputModelSubType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ChapterContentBlockInputModelSubType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ChapterContentBlockInputModelSubType ReadAsPropertyName(
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
            return new ChapterContentBlockInputModelSubType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ChapterContentBlockInputModelSubType value,
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
        public const string P = "p";

        public const string H1 = "h1";

        public const string H2 = "h2";

        public const string H3 = "h3";
    }
}
