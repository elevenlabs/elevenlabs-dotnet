using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(TwilioColdBlindTransferConfigOutputType.TwilioColdBlindTransferConfigOutputTypeSerializer)
)]
[Serializable]
public readonly record struct TwilioColdBlindTransferConfigOutputType : IStringEnum
{
    public static readonly TwilioColdBlindTransferConfigOutputType TwilioColdBlindTransfer = new(
        Values.TwilioColdBlindTransfer
    );

    public TwilioColdBlindTransferConfigOutputType(string value)
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
    public static TwilioColdBlindTransferConfigOutputType FromCustom(string value)
    {
        return new TwilioColdBlindTransferConfigOutputType(value);
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

    public static bool operator ==(TwilioColdBlindTransferConfigOutputType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TwilioColdBlindTransferConfigOutputType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TwilioColdBlindTransferConfigOutputType value) =>
        value.Value;

    public static explicit operator TwilioColdBlindTransferConfigOutputType(string value) =>
        new(value);

    internal class TwilioColdBlindTransferConfigOutputTypeSerializer
        : JsonConverter<TwilioColdBlindTransferConfigOutputType>
    {
        public override TwilioColdBlindTransferConfigOutputType Read(
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
            return new TwilioColdBlindTransferConfigOutputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TwilioColdBlindTransferConfigOutputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TwilioColdBlindTransferConfigOutputType ReadAsPropertyName(
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
            return new TwilioColdBlindTransferConfigOutputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TwilioColdBlindTransferConfigOutputType value,
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
