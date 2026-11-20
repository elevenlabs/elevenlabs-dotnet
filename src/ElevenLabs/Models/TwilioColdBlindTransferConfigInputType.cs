using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(TwilioColdBlindTransferConfigInputType.TwilioColdBlindTransferConfigInputTypeSerializer)
)]
[Serializable]
public readonly record struct TwilioColdBlindTransferConfigInputType : IStringEnum
{
    public static readonly TwilioColdBlindTransferConfigInputType TwilioColdBlindTransfer = new(
        Values.TwilioColdBlindTransfer
    );

    public TwilioColdBlindTransferConfigInputType(string value)
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
    public static TwilioColdBlindTransferConfigInputType FromCustom(string value)
    {
        return new TwilioColdBlindTransferConfigInputType(value);
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

    public static bool operator ==(TwilioColdBlindTransferConfigInputType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TwilioColdBlindTransferConfigInputType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TwilioColdBlindTransferConfigInputType value) =>
        value.Value;

    public static explicit operator TwilioColdBlindTransferConfigInputType(string value) =>
        new(value);

    internal class TwilioColdBlindTransferConfigInputTypeSerializer
        : JsonConverter<TwilioColdBlindTransferConfigInputType>
    {
        public override TwilioColdBlindTransferConfigInputType Read(
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
            return new TwilioColdBlindTransferConfigInputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TwilioColdBlindTransferConfigInputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TwilioColdBlindTransferConfigInputType ReadAsPropertyName(
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
            return new TwilioColdBlindTransferConfigInputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TwilioColdBlindTransferConfigInputType value,
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
        public const string TwilioColdBlindTransfer = "twilio_cold_blind_transfer";
    }
}
