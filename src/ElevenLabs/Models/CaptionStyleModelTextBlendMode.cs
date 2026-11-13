using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(CaptionStyleModelTextBlendMode.CaptionStyleModelTextBlendModeSerializer))]
[Serializable]
public readonly record struct CaptionStyleModelTextBlendMode : IStringEnum
{
    public static readonly CaptionStyleModelTextBlendMode Normal = new(Values.Normal);

    public static readonly CaptionStyleModelTextBlendMode Difference = new(Values.Difference);

    public static readonly CaptionStyleModelTextBlendMode Multiply = new(Values.Multiply);

    public CaptionStyleModelTextBlendMode(string value)
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
    public static CaptionStyleModelTextBlendMode FromCustom(string value)
    {
        return new CaptionStyleModelTextBlendMode(value);
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

    public static bool operator ==(CaptionStyleModelTextBlendMode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CaptionStyleModelTextBlendMode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CaptionStyleModelTextBlendMode value) => value.Value;

    public static explicit operator CaptionStyleModelTextBlendMode(string value) => new(value);

    internal class CaptionStyleModelTextBlendModeSerializer
        : JsonConverter<CaptionStyleModelTextBlendMode>
    {
        public override CaptionStyleModelTextBlendMode Read(
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
            return new CaptionStyleModelTextBlendMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CaptionStyleModelTextBlendMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CaptionStyleModelTextBlendMode ReadAsPropertyName(
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
            return new CaptionStyleModelTextBlendMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CaptionStyleModelTextBlendMode value,
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
        public const string Normal = "normal";

        public const string Difference = "difference";

        public const string Multiply = "multiply";
    }
}
