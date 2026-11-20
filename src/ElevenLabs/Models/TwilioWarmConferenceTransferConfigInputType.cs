using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(TwilioWarmConferenceTransferConfigInputType.TwilioWarmConferenceTransferConfigInputTypeSerializer)
)]
[Serializable]
public readonly record struct TwilioWarmConferenceTransferConfigInputType : IStringEnum
{
    public static readonly TwilioWarmConferenceTransferConfigInputType TwilioWarmConferenceTransfer =
        new(Values.TwilioWarmConferenceTransfer);

    public TwilioWarmConferenceTransferConfigInputType(string value)
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
    public static TwilioWarmConferenceTransferConfigInputType FromCustom(string value)
    {
        return new TwilioWarmConferenceTransferConfigInputType(value);
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
        TwilioWarmConferenceTransferConfigInputType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        TwilioWarmConferenceTransferConfigInputType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(TwilioWarmConferenceTransferConfigInputType value) =>
        value.Value;

    public static explicit operator TwilioWarmConferenceTransferConfigInputType(string value) =>
        new(value);

    internal class TwilioWarmConferenceTransferConfigInputTypeSerializer
        : JsonConverter<TwilioWarmConferenceTransferConfigInputType>
    {
        public override TwilioWarmConferenceTransferConfigInputType Read(
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
            return new TwilioWarmConferenceTransferConfigInputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TwilioWarmConferenceTransferConfigInputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TwilioWarmConferenceTransferConfigInputType ReadAsPropertyName(
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
            return new TwilioWarmConferenceTransferConfigInputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TwilioWarmConferenceTransferConfigInputType value,
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
