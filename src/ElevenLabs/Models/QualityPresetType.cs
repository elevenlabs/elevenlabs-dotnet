using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(QualityPresetType.QualityPresetTypeSerializer))]
[Serializable]
public readonly record struct QualityPresetType : IStringEnum
{
    public static readonly QualityPresetType Standard = new(Values.Standard);

    public static readonly QualityPresetType High = new(Values.High);

    public static readonly QualityPresetType Ultra = new(Values.Ultra);

    public static readonly QualityPresetType UltraLossless = new(Values.UltraLossless);

    public QualityPresetType(string value)
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
    public static QualityPresetType FromCustom(string value)
    {
        return new QualityPresetType(value);
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

    public static bool operator ==(QualityPresetType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(QualityPresetType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(QualityPresetType value) => value.Value;

    public static explicit operator QualityPresetType(string value) => new(value);

    internal class QualityPresetTypeSerializer : JsonConverter<QualityPresetType>
    {
        public override QualityPresetType Read(
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
            return new QualityPresetType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            QualityPresetType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override QualityPresetType ReadAsPropertyName(
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
            return new QualityPresetType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            QualityPresetType value,
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
        public const string Standard = "standard";

        public const string High = "high";

        public const string Ultra = "ultra";

        public const string UltraLossless = "ultra_lossless";
    }
}
