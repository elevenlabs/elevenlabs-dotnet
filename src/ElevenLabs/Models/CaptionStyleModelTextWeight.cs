using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(CaptionStyleModelTextWeight.CaptionStyleModelTextWeightSerializer))]
[Serializable]
public readonly record struct CaptionStyleModelTextWeight : IStringEnum
{
    public static readonly CaptionStyleModelTextWeight Normal = new(Values.Normal);

    public static readonly CaptionStyleModelTextWeight Bold = new(Values.Bold);

    public static readonly CaptionStyleModelTextWeight NineHundred = new(Values.NineHundred);

    public CaptionStyleModelTextWeight(string value)
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
    public static CaptionStyleModelTextWeight FromCustom(string value)
    {
        return new CaptionStyleModelTextWeight(value);
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

    public static bool operator ==(CaptionStyleModelTextWeight value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CaptionStyleModelTextWeight value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CaptionStyleModelTextWeight value) => value.Value;

    public static explicit operator CaptionStyleModelTextWeight(string value) => new(value);

    internal class CaptionStyleModelTextWeightSerializer
        : JsonConverter<CaptionStyleModelTextWeight>
    {
        public override CaptionStyleModelTextWeight Read(
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
            return new CaptionStyleModelTextWeight(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CaptionStyleModelTextWeight value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CaptionStyleModelTextWeight ReadAsPropertyName(
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
            return new CaptionStyleModelTextWeight(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CaptionStyleModelTextWeight value,
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

        public const string Bold = "bold";

        public const string NineHundred = "900";
    }
}
