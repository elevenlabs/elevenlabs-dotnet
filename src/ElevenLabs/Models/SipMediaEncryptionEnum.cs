using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(SipMediaEncryptionEnum.SipMediaEncryptionEnumSerializer))]
[Serializable]
public readonly record struct SipMediaEncryptionEnum : IStringEnum
{
    public static readonly SipMediaEncryptionEnum Disabled = new(Values.Disabled);

    public static readonly SipMediaEncryptionEnum Allowed = new(Values.Allowed);

    public static readonly SipMediaEncryptionEnum Required = new(Values.Required);

    public SipMediaEncryptionEnum(string value)
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
    public static SipMediaEncryptionEnum FromCustom(string value)
    {
        return new SipMediaEncryptionEnum(value);
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

    public static bool operator ==(SipMediaEncryptionEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SipMediaEncryptionEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SipMediaEncryptionEnum value) => value.Value;

    public static explicit operator SipMediaEncryptionEnum(string value) => new(value);

    internal class SipMediaEncryptionEnumSerializer : JsonConverter<SipMediaEncryptionEnum>
    {
        public override SipMediaEncryptionEnum Read(
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
            return new SipMediaEncryptionEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SipMediaEncryptionEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SipMediaEncryptionEnum ReadAsPropertyName(
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
            return new SipMediaEncryptionEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SipMediaEncryptionEnum value,
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
        public const string Disabled = "disabled";

        public const string Allowed = "allowed";

        public const string Required = "required";
    }
}
