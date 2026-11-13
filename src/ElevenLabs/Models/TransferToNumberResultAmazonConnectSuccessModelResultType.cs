using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(TransferToNumberResultAmazonConnectSuccessModelResultType.TransferToNumberResultAmazonConnectSuccessModelResultTypeSerializer)
)]
[Serializable]
public readonly record struct TransferToNumberResultAmazonConnectSuccessModelResultType
    : IStringEnum
{
    public static readonly TransferToNumberResultAmazonConnectSuccessModelResultType TransferToNumberAmazonConnectSuccess =
        new(Values.TransferToNumberAmazonConnectSuccess);

    public TransferToNumberResultAmazonConnectSuccessModelResultType(string value)
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
    public static TransferToNumberResultAmazonConnectSuccessModelResultType FromCustom(string value)
    {
        return new TransferToNumberResultAmazonConnectSuccessModelResultType(value);
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
        TransferToNumberResultAmazonConnectSuccessModelResultType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        TransferToNumberResultAmazonConnectSuccessModelResultType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        TransferToNumberResultAmazonConnectSuccessModelResultType value
    ) => value.Value;

    public static explicit operator TransferToNumberResultAmazonConnectSuccessModelResultType(
        string value
    ) => new(value);

    internal class TransferToNumberResultAmazonConnectSuccessModelResultTypeSerializer
        : JsonConverter<TransferToNumberResultAmazonConnectSuccessModelResultType>
    {
        public override TransferToNumberResultAmazonConnectSuccessModelResultType Read(
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
            return new TransferToNumberResultAmazonConnectSuccessModelResultType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TransferToNumberResultAmazonConnectSuccessModelResultType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TransferToNumberResultAmazonConnectSuccessModelResultType ReadAsPropertyName(
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
            return new TransferToNumberResultAmazonConnectSuccessModelResultType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TransferToNumberResultAmazonConnectSuccessModelResultType value,
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
        public const string TransferToNumberAmazonConnectSuccess =
            "transfer_to_number_amazon_connect_success";
    }
}
