using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(TwilioWarmConferenceTransferConfigOutputType.TwilioWarmConferenceTransferConfigOutputTypeSerializer)
)]
[Serializable]
public readonly record struct TwilioWarmConferenceTransferConfigOutputType : IStringEnum
{
    public static readonly TwilioWarmConferenceTransferConfigOutputType TwilioWarmConferenceTransfer =
        new(Values.TwilioWarmConferenceTransfer);

    public TwilioWarmConferenceTransferConfigOutputType(string value)
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
    public static TwilioWarmConferenceTransferConfigOutputType FromCustom(string value)
    {
        return new TwilioWarmConferenceTransferConfigOutputType(value);
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
        TwilioWarmConferenceTransferConfigOutputType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        TwilioWarmConferenceTransferConfigOutputType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(TwilioWarmConferenceTransferConfigOutputType value) =>
        value.Value;

    public static explicit operator TwilioWarmConferenceTransferConfigOutputType(string value) =>
        new(value);

    internal class TwilioWarmConferenceTransferConfigOutputTypeSerializer
        : JsonConverter<TwilioWarmConferenceTransferConfigOutputType>
    {
        public override TwilioWarmConferenceTransferConfigOutputType Read(
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
            return new TwilioWarmConferenceTransferConfigOutputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TwilioWarmConferenceTransferConfigOutputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TwilioWarmConferenceTransferConfigOutputType ReadAsPropertyName(
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
            return new TwilioWarmConferenceTransferConfigOutputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TwilioWarmConferenceTransferConfigOutputType value,
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
        public const string TwilioWarmConferenceTransfer = "twilio_warm_conference_transfer";
    }
}
