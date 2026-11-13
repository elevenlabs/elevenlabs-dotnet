using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(CaptionStyleModelTextStyle.CaptionStyleModelTextStyleSerializer))]
[Serializable]
public readonly record struct CaptionStyleModelTextStyle : IStringEnum
{
    public static readonly CaptionStyleModelTextStyle Normal = new(Values.Normal);

    public static readonly CaptionStyleModelTextStyle Italic = new(Values.Italic);

    public CaptionStyleModelTextStyle(string value)
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
    public static CaptionStyleModelTextStyle FromCustom(string value)
    {
        return new CaptionStyleModelTextStyle(value);
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

    public static bool operator ==(CaptionStyleModelTextStyle value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CaptionStyleModelTextStyle value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CaptionStyleModelTextStyle value) => value.Value;

    public static explicit operator CaptionStyleModelTextStyle(string value) => new(value);

    internal class CaptionStyleModelTextStyleSerializer : JsonConverter<CaptionStyleModelTextStyle>
    {
        public override CaptionStyleModelTextStyle Read(
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
            return new CaptionStyleModelTextStyle(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CaptionStyleModelTextStyle value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CaptionStyleModelTextStyle ReadAsPropertyName(
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
            return new CaptionStyleModelTextStyle(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CaptionStyleModelTextStyle value,
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

        public const string Italic = "italic";
    }
}
