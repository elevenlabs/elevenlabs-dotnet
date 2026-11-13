using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(CaptionStyleModelTextTransform.CaptionStyleModelTextTransformSerializer))]
[Serializable]
public readonly record struct CaptionStyleModelTextTransform : IStringEnum
{
    public static readonly CaptionStyleModelTextTransform None = new(Values.None);

    public static readonly CaptionStyleModelTextTransform Uppercase = new(Values.Uppercase);

    public CaptionStyleModelTextTransform(string value)
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
    public static CaptionStyleModelTextTransform FromCustom(string value)
    {
        return new CaptionStyleModelTextTransform(value);
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

    public static bool operator ==(CaptionStyleModelTextTransform value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CaptionStyleModelTextTransform value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CaptionStyleModelTextTransform value) => value.Value;

    public static explicit operator CaptionStyleModelTextTransform(string value) => new(value);

    internal class CaptionStyleModelTextTransformSerializer
        : JsonConverter<CaptionStyleModelTextTransform>
    {
        public override CaptionStyleModelTextTransform Read(
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
            return new CaptionStyleModelTextTransform(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CaptionStyleModelTextTransform value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CaptionStyleModelTextTransform ReadAsPropertyName(
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
            return new CaptionStyleModelTextTransform(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CaptionStyleModelTextTransform value,
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

        public const string Uppercase = "uppercase";
    }
}
