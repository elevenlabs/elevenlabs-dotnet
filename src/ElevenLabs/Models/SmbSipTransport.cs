using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>
/// Signalling transport for outbound SIP INVITEs.
///
/// Values match the Agents platform ``SIPTrunkTransportEnum`` so the SMB adapter
/// maps by value. ``AUTO`` is omitted: the Agents UI hides it too, since it can
/// pick UDP, which is known to misbehave (CAI-299). Reception defaults to TLS.
/// </summary>
[JsonConverter(typeof(SmbSipTransport.SmbSipTransportSerializer))]
[Serializable]
public readonly record struct SmbSipTransport : IStringEnum
{
    public static readonly SmbSipTransport Udp = new(Values.Udp);

    public static readonly SmbSipTransport Tcp = new(Values.Tcp);

    public static readonly SmbSipTransport Tls = new(Values.Tls);

    public SmbSipTransport(string value)
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
    public static SmbSipTransport FromCustom(string value)
    {
        return new SmbSipTransport(value);
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

    public static bool operator ==(SmbSipTransport value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SmbSipTransport value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SmbSipTransport value) => value.Value;

    public static explicit operator SmbSipTransport(string value) => new(value);

    internal class SmbSipTransportSerializer : JsonConverter<SmbSipTransport>
    {
        public override SmbSipTransport Read(
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
            return new SmbSipTransport(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SmbSipTransport value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SmbSipTransport ReadAsPropertyName(
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
            return new SmbSipTransport(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SmbSipTransport value,
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
        public const string Udp = "udp";

        public const string Tcp = "tcp";

        public const string Tls = "tls";
    }
}
