using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(VoiceSafetyControl.VoiceSafetyControlSerializer))]
[Serializable]
public readonly record struct VoiceSafetyControl : IStringEnum
{
    public static readonly VoiceSafetyControl None = new(Values.None);

    public static readonly VoiceSafetyControl Ban = new(Values.Ban);

    public static readonly VoiceSafetyControl Captcha = new(Values.Captcha);

    public static readonly VoiceSafetyControl EnterpriseBan = new(Values.EnterpriseBan);

    public static readonly VoiceSafetyControl EnterpriseCaptcha = new(Values.EnterpriseCaptcha);

    public VoiceSafetyControl(string value)
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
    public static VoiceSafetyControl FromCustom(string value)
    {
        return new VoiceSafetyControl(value);
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

    public static bool operator ==(VoiceSafetyControl value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(VoiceSafetyControl value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(VoiceSafetyControl value) => value.Value;

    public static explicit operator VoiceSafetyControl(string value) => new(value);

    internal class VoiceSafetyControlSerializer : JsonConverter<VoiceSafetyControl>
    {
        public override VoiceSafetyControl Read(
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
            return new VoiceSafetyControl(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            VoiceSafetyControl value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override VoiceSafetyControl ReadAsPropertyName(
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
            return new VoiceSafetyControl(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            VoiceSafetyControl value,
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
        public const string None = "NONE";

        public const string Ban = "BAN";

        public const string Captcha = "CAPTCHA";

        public const string EnterpriseBan = "ENTERPRISE_BAN";

        public const string EnterpriseCaptcha = "ENTERPRISE_CAPTCHA";
    }
}
