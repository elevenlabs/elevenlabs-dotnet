using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>How calls to the number reach ElevenLabs: through Twilio or a SIP trunk.</summary>
[JsonConverter(typeof(ReceptionPhoneProvider.ReceptionPhoneProviderSerializer))]
[Serializable]
public readonly record struct ReceptionPhoneProvider : IStringEnum
{
    public static readonly ReceptionPhoneProvider Twilio = new(Values.Twilio);

    public static readonly ReceptionPhoneProvider SipTrunk = new(Values.SipTrunk);

    public ReceptionPhoneProvider(string value)
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
    public static ReceptionPhoneProvider FromCustom(string value)
    {
        return new ReceptionPhoneProvider(value);
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

    public static bool operator ==(ReceptionPhoneProvider value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ReceptionPhoneProvider value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ReceptionPhoneProvider value) => value.Value;

    public static explicit operator ReceptionPhoneProvider(string value) => new(value);

    internal class ReceptionPhoneProviderSerializer : JsonConverter<ReceptionPhoneProvider>
    {
        public override ReceptionPhoneProvider Read(
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
            return new ReceptionPhoneProvider(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReceptionPhoneProvider value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ReceptionPhoneProvider ReadAsPropertyName(
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
            return new ReceptionPhoneProvider(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReceptionPhoneProvider value,
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
        public const string Twilio = "twilio";

        public const string SipTrunk = "sip_trunk";
    }
}
