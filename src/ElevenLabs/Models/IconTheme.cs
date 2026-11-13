using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(IconTheme.IconThemeSerializer))]
[Serializable]
public readonly record struct IconTheme : IStringEnum
{
    public static readonly IconTheme Light = new(Values.Light);

    public static readonly IconTheme Dark = new(Values.Dark);

    public IconTheme(string value)
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
    public static IconTheme FromCustom(string value)
    {
        return new IconTheme(value);
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

    public static bool operator ==(IconTheme value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(IconTheme value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(IconTheme value) => value.Value;

    public static explicit operator IconTheme(string value) => new(value);

    internal class IconThemeSerializer : JsonConverter<IconTheme>
    {
        public override IconTheme Read(
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
            return new IconTheme(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            IconTheme value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override IconTheme ReadAsPropertyName(
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
            return new IconTheme(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            IconTheme value,
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
        public const string Light = "light";

        public const string Dark = "dark";
    }
}
