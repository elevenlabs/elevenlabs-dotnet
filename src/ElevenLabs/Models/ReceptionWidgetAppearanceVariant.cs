using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Widget size, from the smallest ('tiny') to the largest ('full').</summary>
[JsonConverter(typeof(ReceptionWidgetAppearanceVariant.ReceptionWidgetAppearanceVariantSerializer))]
[Serializable]
public readonly record struct ReceptionWidgetAppearanceVariant : IStringEnum
{
    public static readonly ReceptionWidgetAppearanceVariant Tiny = new(Values.Tiny);

    public static readonly ReceptionWidgetAppearanceVariant Compact = new(Values.Compact);

    public static readonly ReceptionWidgetAppearanceVariant Full = new(Values.Full);

    public ReceptionWidgetAppearanceVariant(string value)
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
    public static ReceptionWidgetAppearanceVariant FromCustom(string value)
    {
        return new ReceptionWidgetAppearanceVariant(value);
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

    public static bool operator ==(ReceptionWidgetAppearanceVariant value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ReceptionWidgetAppearanceVariant value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ReceptionWidgetAppearanceVariant value) => value.Value;

    public static explicit operator ReceptionWidgetAppearanceVariant(string value) => new(value);

    internal class ReceptionWidgetAppearanceVariantSerializer
        : JsonConverter<ReceptionWidgetAppearanceVariant>
    {
        public override ReceptionWidgetAppearanceVariant Read(
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
            return new ReceptionWidgetAppearanceVariant(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReceptionWidgetAppearanceVariant value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ReceptionWidgetAppearanceVariant ReadAsPropertyName(
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
            return new ReceptionWidgetAppearanceVariant(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReceptionWidgetAppearanceVariant value,
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
        public const string Tiny = "tiny";

        public const string Compact = "compact";

        public const string Full = "full";
    }
}
