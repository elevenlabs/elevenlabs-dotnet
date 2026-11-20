using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(SipColdReferTransferConfigOutputType.SipColdReferTransferConfigOutputTypeSerializer)
)]
[Serializable]
public readonly record struct SipColdReferTransferConfigOutputType : IStringEnum
{
    public static readonly SipColdReferTransferConfigOutputType SipColdReferTransfer = new(
        Values.SipColdReferTransfer
    );

    public SipColdReferTransferConfigOutputType(string value)
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
    public static SipColdReferTransferConfigOutputType FromCustom(string value)
    {
        return new SipColdReferTransferConfigOutputType(value);
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

    public static bool operator ==(SipColdReferTransferConfigOutputType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SipColdReferTransferConfigOutputType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SipColdReferTransferConfigOutputType value) =>
        value.Value;

    public static explicit operator SipColdReferTransferConfigOutputType(string value) =>
        new(value);

    internal class SipColdReferTransferConfigOutputTypeSerializer
        : JsonConverter<SipColdReferTransferConfigOutputType>
    {
        public override SipColdReferTransferConfigOutputType Read(
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
            return new SipColdReferTransferConfigOutputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SipColdReferTransferConfigOutputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SipColdReferTransferConfigOutputType ReadAsPropertyName(
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
            return new SipColdReferTransferConfigOutputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SipColdReferTransferConfigOutputType value,
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
        public const string SipColdReferTransfer = "sip_cold_refer_transfer";
    }
}
