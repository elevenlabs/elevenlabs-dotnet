using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(WidgetFeedbackMode.WidgetFeedbackModeSerializer))]
[Serializable]
public readonly record struct WidgetFeedbackMode : IStringEnum
{
    public static readonly WidgetFeedbackMode None = new(Values.None);

    public static readonly WidgetFeedbackMode During = new(Values.During);

    public static readonly WidgetFeedbackMode End = new(Values.End);

    public WidgetFeedbackMode(string value)
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
    public static WidgetFeedbackMode FromCustom(string value)
    {
        return new WidgetFeedbackMode(value);
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

    public static bool operator ==(WidgetFeedbackMode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(WidgetFeedbackMode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(WidgetFeedbackMode value) => value.Value;

    public static explicit operator WidgetFeedbackMode(string value) => new(value);

    internal class WidgetFeedbackModeSerializer : JsonConverter<WidgetFeedbackMode>
    {
        public override WidgetFeedbackMode Read(
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
            return new WidgetFeedbackMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WidgetFeedbackMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WidgetFeedbackMode ReadAsPropertyName(
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
            return new WidgetFeedbackMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WidgetFeedbackMode value,
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
        public const string None = "none";

        public const string During = "during";

        public const string End = "end";
    }
}
