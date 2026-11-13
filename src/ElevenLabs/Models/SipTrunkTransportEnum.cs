using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(SipTrunkTransportEnum.SipTrunkTransportEnumSerializer))]
[Serializable]
public readonly record struct SipTrunkTransportEnum : IStringEnum
{
    public static readonly SipTrunkTransportEnum Auto = new(Values.Auto);

    public static readonly SipTrunkTransportEnum Udp = new(Values.Udp);

    public static readonly SipTrunkTransportEnum Tcp = new(Values.Tcp);

    public static readonly SipTrunkTransportEnum Tls = new(Values.Tls);

    public SipTrunkTransportEnum(string value)
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
    public static SipTrunkTransportEnum FromCustom(string value)
    {
        return new SipTrunkTransportEnum(value);
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

    public static bool operator ==(SipTrunkTransportEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SipTrunkTransportEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SipTrunkTransportEnum value) => value.Value;

    public static explicit operator SipTrunkTransportEnum(string value) => new(value);

    internal class SipTrunkTransportEnumSerializer : JsonConverter<SipTrunkTransportEnum>
    {
        public override SipTrunkTransportEnum Read(
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
            return new SipTrunkTransportEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SipTrunkTransportEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SipTrunkTransportEnum ReadAsPropertyName(
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
            return new SipTrunkTransportEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SipTrunkTransportEnum value,
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
        public const string Auto = "auto";

        public const string Udp = "udp";

        public const string Tcp = "tcp";

        public const string Tls = "tls";
    }
}
