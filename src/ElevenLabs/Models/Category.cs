using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The category of the voice.</summary>
[JsonConverter(typeof(Category.CategorySerializer))]
[Serializable]
public readonly record struct Category : IStringEnum
{
    public static readonly Category Generated = new(Values.Generated);

    public static readonly Category Cloned = new(Values.Cloned);

    public static readonly Category Premade = new(Values.Premade);

    public static readonly Category Professional = new(Values.Professional);

    public static readonly Category Famous = new(Values.Famous);

    public static readonly Category HighQuality = new(Values.HighQuality);

    public Category(string value)
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
    public static Category FromCustom(string value)
    {
        return new Category(value);
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

    public static bool operator ==(Category value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(Category value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(Category value) => value.Value;

    public static explicit operator Category(string value) => new(value);

    internal class CategorySerializer : JsonConverter<Category>
    {
        public override Category Read(
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
            return new Category(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            Category value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override Category ReadAsPropertyName(
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
            return new Category(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            Category value,
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
        public const string Generated = "generated";

        public const string Cloned = "cloned";

        public const string Premade = "premade";

        public const string Professional = "professional";

        public const string Famous = "famous";

        public const string HighQuality = "high_quality";
    }
}
