using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(CaptionStyleModelTextAlign.CaptionStyleModelTextAlignSerializer))]
[Serializable]
public readonly record struct CaptionStyleModelTextAlign : IStringEnum
{
    public static readonly CaptionStyleModelTextAlign Start = new(Values.Start);

    public static readonly CaptionStyleModelTextAlign Center = new(Values.Center);

    public static readonly CaptionStyleModelTextAlign End = new(Values.End);

    public CaptionStyleModelTextAlign(string value)
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
    public static CaptionStyleModelTextAlign FromCustom(string value)
    {
        return new CaptionStyleModelTextAlign(value);
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

    public static bool operator ==(CaptionStyleModelTextAlign value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CaptionStyleModelTextAlign value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CaptionStyleModelTextAlign value) => value.Value;

    public static explicit operator CaptionStyleModelTextAlign(string value) => new(value);

    internal class CaptionStyleModelTextAlignSerializer : JsonConverter<CaptionStyleModelTextAlign>
    {
        public override CaptionStyleModelTextAlign Read(
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
            return new CaptionStyleModelTextAlign(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CaptionStyleModelTextAlign value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CaptionStyleModelTextAlign ReadAsPropertyName(
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
            return new CaptionStyleModelTextAlign(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CaptionStyleModelTextAlign value,
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
        public const string Start = "start";

        public const string Center = "center";

        public const string End = "end";
    }
}
