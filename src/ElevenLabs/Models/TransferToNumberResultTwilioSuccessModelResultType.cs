using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(TransferToNumberResultTwilioSuccessModelResultType.TransferToNumberResultTwilioSuccessModelResultTypeSerializer)
)]
[Serializable]
public readonly record struct TransferToNumberResultTwilioSuccessModelResultType : IStringEnum
{
    public static readonly TransferToNumberResultTwilioSuccessModelResultType TransferToNumberTwilioSuccess =
        new(Values.TransferToNumberTwilioSuccess);

    public TransferToNumberResultTwilioSuccessModelResultType(string value)
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
    public static TransferToNumberResultTwilioSuccessModelResultType FromCustom(string value)
    {
        return new TransferToNumberResultTwilioSuccessModelResultType(value);
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
        TransferToNumberResultTwilioSuccessModelResultType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        TransferToNumberResultTwilioSuccessModelResultType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        TransferToNumberResultTwilioSuccessModelResultType value
    ) => value.Value;

    public static explicit operator TransferToNumberResultTwilioSuccessModelResultType(
        string value
    ) => new(value);

    internal class TransferToNumberResultTwilioSuccessModelResultTypeSerializer
        : JsonConverter<TransferToNumberResultTwilioSuccessModelResultType>
    {
        public override TransferToNumberResultTwilioSuccessModelResultType Read(
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
            return new TransferToNumberResultTwilioSuccessModelResultType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TransferToNumberResultTwilioSuccessModelResultType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TransferToNumberResultTwilioSuccessModelResultType ReadAsPropertyName(
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
            return new TransferToNumberResultTwilioSuccessModelResultType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TransferToNumberResultTwilioSuccessModelResultType value,
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
        public const string TransferToNumberTwilioSuccess = "transfer_to_number_twilio_success";
    }
}
