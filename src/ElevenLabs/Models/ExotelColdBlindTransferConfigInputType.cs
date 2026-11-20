using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ExotelColdBlindTransferConfigInputType.ExotelColdBlindTransferConfigInputTypeSerializer)
)]
[Serializable]
public readonly record struct ExotelColdBlindTransferConfigInputType : IStringEnum
{
    public static readonly ExotelColdBlindTransferConfigInputType ExotelColdBlindTransfer = new(
        Values.ExotelColdBlindTransfer
    );

    public ExotelColdBlindTransferConfigInputType(string value)
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
    public static ExotelColdBlindTransferConfigInputType FromCustom(string value)
    {
        return new ExotelColdBlindTransferConfigInputType(value);
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

    public static bool operator ==(ExotelColdBlindTransferConfigInputType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ExotelColdBlindTransferConfigInputType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ExotelColdBlindTransferConfigInputType value) =>
        value.Value;

    public static explicit operator ExotelColdBlindTransferConfigInputType(string value) =>
        new(value);

    internal class ExotelColdBlindTransferConfigInputTypeSerializer
        : JsonConverter<ExotelColdBlindTransferConfigInputType>
    {
        public override ExotelColdBlindTransferConfigInputType Read(
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
            return new ExotelColdBlindTransferConfigInputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ExotelColdBlindTransferConfigInputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ExotelColdBlindTransferConfigInputType ReadAsPropertyName(
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
            return new ExotelColdBlindTransferConfigInputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ExotelColdBlindTransferConfigInputType value,
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
