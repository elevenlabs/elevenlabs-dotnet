using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(SipTransferInputType.SipTransferInputTypeSerializer))]
[Serializable]
public readonly record struct SipTransferInputType : IStringEnum
{
    public static readonly SipTransferInputType SipTrunk = new(Values.SipTrunk);

    public SipTransferInputType(string value)
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
    public static SipTransferInputType FromCustom(string value)
    {
        return new SipTransferInputType(value);
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

    public static bool operator ==(SipTransferInputType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SipTransferInputType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SipTransferInputType value) => value.Value;

    public static explicit operator SipTransferInputType(string value) => new(value);

    internal class SipTransferInputTypeSerializer : JsonConverter<SipTransferInputType>
    {
        public override SipTransferInputType Read(
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
            return new SipTransferInputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SipTransferInputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SipTransferInputType ReadAsPropertyName(
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
            return new SipTransferInputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SipTransferInputType value,
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
        public const string SipTrunk = "sip_trunk";
    }
}
