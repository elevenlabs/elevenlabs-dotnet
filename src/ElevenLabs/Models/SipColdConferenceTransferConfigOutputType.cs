using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(SipColdConferenceTransferConfigOutputType.SipColdConferenceTransferConfigOutputTypeSerializer)
)]
[Serializable]
public readonly record struct SipColdConferenceTransferConfigOutputType : IStringEnum
{
    public static readonly SipColdConferenceTransferConfigOutputType SipColdConferenceTransfer =
        new(Values.SipColdConferenceTransfer);

    public SipColdConferenceTransferConfigOutputType(string value)
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
    public static SipColdConferenceTransferConfigOutputType FromCustom(string value)
    {
        return new SipColdConferenceTransferConfigOutputType(value);
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

    public static bool operator ==(
        SipColdConferenceTransferConfigOutputType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        SipColdConferenceTransferConfigOutputType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(SipColdConferenceTransferConfigOutputType value) =>
        value.Value;

    public static explicit operator SipColdConferenceTransferConfigOutputType(string value) =>
        new(value);

    internal class SipColdConferenceTransferConfigOutputTypeSerializer
        : JsonConverter<SipColdConferenceTransferConfigOutputType>
    {
        public override SipColdConferenceTransferConfigOutputType Read(
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
            return new SipColdConferenceTransferConfigOutputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SipColdConferenceTransferConfigOutputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SipColdConferenceTransferConfigOutputType ReadAsPropertyName(
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
            return new SipColdConferenceTransferConfigOutputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SipColdConferenceTransferConfigOutputType value,
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
        public const string SipColdConferenceTransfer = "sip_cold_conference_transfer";
    }
}
