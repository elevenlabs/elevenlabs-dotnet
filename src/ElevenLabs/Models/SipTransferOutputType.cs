using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(SipTransferOutputType.SipTransferOutputTypeSerializer))]
[Serializable]
public readonly record struct SipTransferOutputType : IStringEnum
{
    public static readonly SipTransferOutputType SipTrunk = new(Values.SipTrunk);

    public SipTransferOutputType(string value)
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
    public static SipTransferOutputType FromCustom(string value)
    {
        return new SipTransferOutputType(value);
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

    public static bool operator ==(SipTransferOutputType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SipTransferOutputType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SipTransferOutputType value) => value.Value;

    public static explicit operator SipTransferOutputType(string value) => new(value);

    internal class SipTransferOutputTypeSerializer : JsonConverter<SipTransferOutputType>
    {
        public override SipTransferOutputType Read(
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
            return new SipTransferOutputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SipTransferOutputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SipTransferOutputType ReadAsPropertyName(
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
            return new SipTransferOutputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SipTransferOutputType value,
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
