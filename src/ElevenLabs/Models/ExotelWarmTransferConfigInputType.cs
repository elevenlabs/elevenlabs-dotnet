using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ExotelWarmTransferConfigInputType.ExotelWarmTransferConfigInputTypeSerializer)
)]
[Serializable]
public readonly record struct ExotelWarmTransferConfigInputType : IStringEnum
{
    public static readonly ExotelWarmTransferConfigInputType ExotelWarmTransfer = new(
        Values.ExotelWarmTransfer
    );

    public ExotelWarmTransferConfigInputType(string value)
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
    public static ExotelWarmTransferConfigInputType FromCustom(string value)
    {
        return new ExotelWarmTransferConfigInputType(value);
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

    public static bool operator ==(ExotelWarmTransferConfigInputType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ExotelWarmTransferConfigInputType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ExotelWarmTransferConfigInputType value) => value.Value;

    public static explicit operator ExotelWarmTransferConfigInputType(string value) => new(value);

    internal class ExotelWarmTransferConfigInputTypeSerializer
        : JsonConverter<ExotelWarmTransferConfigInputType>
    {
        public override ExotelWarmTransferConfigInputType Read(
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
            return new ExotelWarmTransferConfigInputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ExotelWarmTransferConfigInputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ExotelWarmTransferConfigInputType ReadAsPropertyName(
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
            return new ExotelWarmTransferConfigInputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ExotelWarmTransferConfigInputType value,
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
        public const string ExotelWarmTransfer = "exotel_warm_transfer";
    }
}
