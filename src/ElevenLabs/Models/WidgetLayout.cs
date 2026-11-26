using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(WidgetLayout.WidgetLayoutSerializer))]
[Serializable]
public readonly record struct WidgetLayout : IStringEnum
{
    public static readonly WidgetLayout Default = new(Values.Default);

    public static readonly WidgetLayout SidePanel = new(Values.SidePanel);

    public WidgetLayout(string value)
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
    public static WidgetLayout FromCustom(string value)
    {
        return new WidgetLayout(value);
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

    public static bool operator ==(WidgetLayout value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(WidgetLayout value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(WidgetLayout value) => value.Value;

    public static explicit operator WidgetLayout(string value) => new(value);

    internal class WidgetLayoutSerializer : JsonConverter<WidgetLayout>
    {
        public override WidgetLayout Read(
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
            return new WidgetLayout(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WidgetLayout value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WidgetLayout ReadAsPropertyName(
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
            return new WidgetLayout(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WidgetLayout value,
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
        public const string Default = "default";

        public const string SidePanel = "side-panel";
    }
}
