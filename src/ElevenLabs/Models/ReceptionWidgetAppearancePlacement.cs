using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Where on the page the widget sits.</summary>
[JsonConverter(
    typeof(ReceptionWidgetAppearancePlacement.ReceptionWidgetAppearancePlacementSerializer)
)]
[Serializable]
public readonly record struct ReceptionWidgetAppearancePlacement : IStringEnum
{
    public static readonly ReceptionWidgetAppearancePlacement TopLeft = new(Values.TopLeft);

    public static readonly ReceptionWidgetAppearancePlacement Top = new(Values.Top);

    public static readonly ReceptionWidgetAppearancePlacement TopRight = new(Values.TopRight);

    public static readonly ReceptionWidgetAppearancePlacement BottomLeft = new(Values.BottomLeft);

    public static readonly ReceptionWidgetAppearancePlacement Bottom = new(Values.Bottom);

    public static readonly ReceptionWidgetAppearancePlacement BottomRight = new(Values.BottomRight);

    public ReceptionWidgetAppearancePlacement(string value)
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
    public static ReceptionWidgetAppearancePlacement FromCustom(string value)
    {
        return new ReceptionWidgetAppearancePlacement(value);
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

    public static bool operator ==(ReceptionWidgetAppearancePlacement value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ReceptionWidgetAppearancePlacement value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ReceptionWidgetAppearancePlacement value) => value.Value;

    public static explicit operator ReceptionWidgetAppearancePlacement(string value) => new(value);

    internal class ReceptionWidgetAppearancePlacementSerializer
        : JsonConverter<ReceptionWidgetAppearancePlacement>
    {
        public override ReceptionWidgetAppearancePlacement Read(
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
            return new ReceptionWidgetAppearancePlacement(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReceptionWidgetAppearancePlacement value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ReceptionWidgetAppearancePlacement ReadAsPropertyName(
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
            return new ReceptionWidgetAppearancePlacement(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReceptionWidgetAppearancePlacement value,
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
