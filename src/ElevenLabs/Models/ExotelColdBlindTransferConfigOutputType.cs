using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ExotelColdBlindTransferConfigOutputType.ExotelColdBlindTransferConfigOutputTypeSerializer)
)]
[Serializable]
public readonly record struct ExotelColdBlindTransferConfigOutputType : IStringEnum
{
    public static readonly ExotelColdBlindTransferConfigOutputType ExotelColdBlindTransfer = new(
        Values.ExotelColdBlindTransfer
    );

    public ExotelColdBlindTransferConfigOutputType(string value)
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
    public static ExotelColdBlindTransferConfigOutputType FromCustom(string value)
    {
        return new ExotelColdBlindTransferConfigOutputType(value);
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

    public static bool operator ==(ExotelColdBlindTransferConfigOutputType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ExotelColdBlindTransferConfigOutputType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ExotelColdBlindTransferConfigOutputType value) =>
        value.Value;

    public static explicit operator ExotelColdBlindTransferConfigOutputType(string value) =>
        new(value);

    internal class ExotelColdBlindTransferConfigOutputTypeSerializer
        : JsonConverter<ExotelColdBlindTransferConfigOutputType>
    {
        public override ExotelColdBlindTransferConfigOutputType Read(
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
            return new ExotelColdBlindTransferConfigOutputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ExotelColdBlindTransferConfigOutputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ExotelColdBlindTransferConfigOutputType ReadAsPropertyName(
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
            return new ExotelColdBlindTransferConfigOutputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ExotelColdBlindTransferConfigOutputType value,
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
        public const string ExotelColdBlindTransfer = "exotel_cold_blind_transfer";
    }
}
