using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Phone provider</summary>
[JsonConverter(
    typeof(GetPhoneNumberTwilioResponseModelProvider.GetPhoneNumberTwilioResponseModelProviderSerializer)
)]
[Serializable]
public readonly record struct GetPhoneNumberTwilioResponseModelProvider : IStringEnum
{
    public static readonly GetPhoneNumberTwilioResponseModelProvider Twilio = new(Values.Twilio);

    public GetPhoneNumberTwilioResponseModelProvider(string value)
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
    public static GetPhoneNumberTwilioResponseModelProvider FromCustom(string value)
    {
        return new GetPhoneNumberTwilioResponseModelProvider(value);
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
        GetPhoneNumberTwilioResponseModelProvider value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        GetPhoneNumberTwilioResponseModelProvider value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(GetPhoneNumberTwilioResponseModelProvider value) =>
        value.Value;

    public static explicit operator GetPhoneNumberTwilioResponseModelProvider(string value) =>
        new(value);

    internal class GetPhoneNumberTwilioResponseModelProviderSerializer
        : JsonConverter<GetPhoneNumberTwilioResponseModelProvider>
    {
        public override GetPhoneNumberTwilioResponseModelProvider Read(
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
            return new GetPhoneNumberTwilioResponseModelProvider(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetPhoneNumberTwilioResponseModelProvider value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetPhoneNumberTwilioResponseModelProvider ReadAsPropertyName(
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
            return new GetPhoneNumberTwilioResponseModelProvider(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetPhoneNumberTwilioResponseModelProvider value,
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
    }
}
