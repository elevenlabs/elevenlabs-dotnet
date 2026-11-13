using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Preset tone for an SMS message body.</summary>
[JsonConverter(typeof(SmsTemplateStyle.SmsTemplateStyleSerializer))]
[Serializable]
public readonly record struct SmsTemplateStyle : IStringEnum
{
    public static readonly SmsTemplateStyle Friendly = new(Values.Friendly);

    public static readonly SmsTemplateStyle Professional = new(Values.Professional);

    public static readonly SmsTemplateStyle Concise = new(Values.Concise);

    public SmsTemplateStyle(string value)
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
    public static SmsTemplateStyle FromCustom(string value)
    {
        return new SmsTemplateStyle(value);
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

    public static bool operator ==(SmsTemplateStyle value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SmsTemplateStyle value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SmsTemplateStyle value) => value.Value;

    public static explicit operator SmsTemplateStyle(string value) => new(value);

    internal class SmsTemplateStyleSerializer : JsonConverter<SmsTemplateStyle>
    {
        public override SmsTemplateStyle Read(
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
            return new SmsTemplateStyle(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SmsTemplateStyle value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SmsTemplateStyle ReadAsPropertyName(
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
            return new SmsTemplateStyle(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SmsTemplateStyle value,
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
        public const string Friendly = "friendly";

        public const string Professional = "professional";

        public const string Concise = "concise";
    }
}
