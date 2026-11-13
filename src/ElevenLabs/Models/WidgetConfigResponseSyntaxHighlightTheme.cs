using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(WidgetConfigResponseSyntaxHighlightTheme.WidgetConfigResponseSyntaxHighlightThemeSerializer)
)]
[Serializable]
public readonly record struct WidgetConfigResponseSyntaxHighlightTheme : IStringEnum
{
    public static readonly WidgetConfigResponseSyntaxHighlightTheme Light = new(Values.Light);

    public static readonly WidgetConfigResponseSyntaxHighlightTheme Dark = new(Values.Dark);

    public WidgetConfigResponseSyntaxHighlightTheme(string value)
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
    public static WidgetConfigResponseSyntaxHighlightTheme FromCustom(string value)
    {
        return new WidgetConfigResponseSyntaxHighlightTheme(value);
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
        WidgetConfigResponseSyntaxHighlightTheme value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        WidgetConfigResponseSyntaxHighlightTheme value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(WidgetConfigResponseSyntaxHighlightTheme value) =>
        value.Value;

    public static explicit operator WidgetConfigResponseSyntaxHighlightTheme(string value) =>
        new(value);

    internal class WidgetConfigResponseSyntaxHighlightThemeSerializer
        : JsonConverter<WidgetConfigResponseSyntaxHighlightTheme>
    {
        public override WidgetConfigResponseSyntaxHighlightTheme Read(
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
            return new WidgetConfigResponseSyntaxHighlightTheme(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WidgetConfigResponseSyntaxHighlightTheme value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WidgetConfigResponseSyntaxHighlightTheme ReadAsPropertyName(
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
            return new WidgetConfigResponseSyntaxHighlightTheme(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WidgetConfigResponseSyntaxHighlightTheme value,
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
