using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(TransferToNumberResultExotelSuccessModelResultType.TransferToNumberResultExotelSuccessModelResultTypeSerializer)
)]
[Serializable]
public readonly record struct TransferToNumberResultExotelSuccessModelResultType : IStringEnum
{
    public static readonly TransferToNumberResultExotelSuccessModelResultType TransferToNumberExotelSuccess =
        new(Values.TransferToNumberExotelSuccess);

    public TransferToNumberResultExotelSuccessModelResultType(string value)
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
    public static TransferToNumberResultExotelSuccessModelResultType FromCustom(string value)
    {
        return new TransferToNumberResultExotelSuccessModelResultType(value);
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
        TransferToNumberResultExotelSuccessModelResultType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        TransferToNumberResultExotelSuccessModelResultType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        TransferToNumberResultExotelSuccessModelResultType value
    ) => value.Value;

    public static explicit operator TransferToNumberResultExotelSuccessModelResultType(
        string value
    ) => new(value);

    internal class TransferToNumberResultExotelSuccessModelResultTypeSerializer
        : JsonConverter<TransferToNumberResultExotelSuccessModelResultType>
    {
        public override TransferToNumberResultExotelSuccessModelResultType Read(
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
            return new TransferToNumberResultExotelSuccessModelResultType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TransferToNumberResultExotelSuccessModelResultType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TransferToNumberResultExotelSuccessModelResultType ReadAsPropertyName(
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
            return new TransferToNumberResultExotelSuccessModelResultType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TransferToNumberResultExotelSuccessModelResultType value,
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
        public const string TransferToNumberExotelSuccess = "transfer_to_number_exotel_success";
    }
}
