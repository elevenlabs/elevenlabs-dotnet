using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(TelephonyProvider.TelephonyProviderSerializer))]
[Serializable]
public readonly record struct TelephonyProvider : IStringEnum
{
    public static readonly TelephonyProvider Twilio = new(Values.Twilio);

    public static readonly TelephonyProvider SipTrunk = new(Values.SipTrunk);

    public static readonly TelephonyProvider Exotel = new(Values.Exotel);

    public TelephonyProvider(string value)
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
    public static TelephonyProvider FromCustom(string value)
    {
        return new TelephonyProvider(value);
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

    public static bool operator ==(TelephonyProvider value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TelephonyProvider value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TelephonyProvider value) => value.Value;

    public static explicit operator TelephonyProvider(string value) => new(value);

    internal class TelephonyProviderSerializer : JsonConverter<TelephonyProvider>
    {
        public override TelephonyProvider Read(
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
            return new TelephonyProvider(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TelephonyProvider value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TelephonyProvider ReadAsPropertyName(
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
            return new TelephonyProvider(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TelephonyProvider value,
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

        public const string Exotel = "exotel";
    }
}
