using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(WidgetPlacement.WidgetPlacementSerializer))]
[Serializable]
public readonly record struct WidgetPlacement : IStringEnum
{
    public static readonly WidgetPlacement TopLeft = new(Values.TopLeft);

    public static readonly WidgetPlacement Top = new(Values.Top);

    public static readonly WidgetPlacement TopRight = new(Values.TopRight);

    public static readonly WidgetPlacement BottomLeft = new(Values.BottomLeft);

    public static readonly WidgetPlacement Bottom = new(Values.Bottom);

    public static readonly WidgetPlacement BottomRight = new(Values.BottomRight);

    public WidgetPlacement(string value)
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
    public static WidgetPlacement FromCustom(string value)
    {
        return new WidgetPlacement(value);
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

    public static bool operator ==(WidgetPlacement value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(WidgetPlacement value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(WidgetPlacement value) => value.Value;

    public static explicit operator WidgetPlacement(string value) => new(value);

    internal class WidgetPlacementSerializer : JsonConverter<WidgetPlacement>
    {
        public override WidgetPlacement Read(
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
            return new WidgetPlacement(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WidgetPlacement value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WidgetPlacement ReadAsPropertyName(
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
            return new WidgetPlacement(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WidgetPlacement value,
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
        public const string TopLeft = "top-left";

        public const string Top = "top";

        public const string TopRight = "top-right";

        public const string BottomLeft = "bottom-left";

        public const string Bottom = "bottom";

        public const string BottomRight = "bottom-right";
    }
}
