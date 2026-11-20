using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(SipColdConferenceTransferConfigInputType.SipColdConferenceTransferConfigInputTypeSerializer)
)]
[Serializable]
public readonly record struct SipColdConferenceTransferConfigInputType : IStringEnum
{
    public static readonly SipColdConferenceTransferConfigInputType SipColdConferenceTransfer = new(
        Values.SipColdConferenceTransfer
    );

    public SipColdConferenceTransferConfigInputType(string value)
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
    public static SipColdConferenceTransferConfigInputType FromCustom(string value)
    {
        return new SipColdConferenceTransferConfigInputType(value);
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
        SipColdConferenceTransferConfigInputType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        SipColdConferenceTransferConfigInputType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(SipColdConferenceTransferConfigInputType value) =>
        value.Value;

    public static explicit operator SipColdConferenceTransferConfigInputType(string value) =>
        new(value);

    internal class SipColdConferenceTransferConfigInputTypeSerializer
        : JsonConverter<SipColdConferenceTransferConfigInputType>
    {
        public override SipColdConferenceTransferConfigInputType Read(
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
            return new SipColdConferenceTransferConfigInputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SipColdConferenceTransferConfigInputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SipColdConferenceTransferConfigInputType ReadAsPropertyName(
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
            return new SipColdConferenceTransferConfigInputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SipColdConferenceTransferConfigInputType value,
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
