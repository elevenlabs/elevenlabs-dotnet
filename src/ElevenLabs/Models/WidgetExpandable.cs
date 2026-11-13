using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(WidgetExpandable.WidgetExpandableSerializer))]
[Serializable]
public readonly record struct WidgetExpandable : IStringEnum
{
    public static readonly WidgetExpandable Never = new(Values.Never);

    public static readonly WidgetExpandable Mobile = new(Values.Mobile);

    public static readonly WidgetExpandable Desktop = new(Values.Desktop);

    public static readonly WidgetExpandable Always = new(Values.Always);

    public WidgetExpandable(string value)
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
    public static WidgetExpandable FromCustom(string value)
    {
        return new WidgetExpandable(value);
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

    public static bool operator ==(WidgetExpandable value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(WidgetExpandable value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(WidgetExpandable value) => value.Value;

    public static explicit operator WidgetExpandable(string value) => new(value);

    internal class WidgetExpandableSerializer : JsonConverter<WidgetExpandable>
    {
        public override WidgetExpandable Read(
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
            return new WidgetExpandable(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WidgetExpandable value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WidgetExpandable ReadAsPropertyName(
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
            return new WidgetExpandable(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WidgetExpandable value,
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
        public const string Never = "never";

        public const string Mobile = "mobile";

        public const string Desktop = "desktop";

        public const string Always = "always";
    }
}
