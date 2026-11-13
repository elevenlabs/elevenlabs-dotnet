using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(TransferToNumberResultErrorModelResultType.TransferToNumberResultErrorModelResultTypeSerializer)
)]
[Serializable]
public readonly record struct TransferToNumberResultErrorModelResultType : IStringEnum
{
    public static readonly TransferToNumberResultErrorModelResultType TransferToNumberError = new(
        Values.TransferToNumberError
    );

    public TransferToNumberResultErrorModelResultType(string value)
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
    public static TransferToNumberResultErrorModelResultType FromCustom(string value)
    {
        return new TransferToNumberResultErrorModelResultType(value);
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
        TransferToNumberResultErrorModelResultType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        TransferToNumberResultErrorModelResultType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(TransferToNumberResultErrorModelResultType value) =>
        value.Value;

    public static explicit operator TransferToNumberResultErrorModelResultType(string value) =>
        new(value);

    internal class TransferToNumberResultErrorModelResultTypeSerializer
        : JsonConverter<TransferToNumberResultErrorModelResultType>
    {
        public override TransferToNumberResultErrorModelResultType Read(
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
            return new TransferToNumberResultErrorModelResultType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TransferToNumberResultErrorModelResultType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TransferToNumberResultErrorModelResultType ReadAsPropertyName(
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
            return new TransferToNumberResultErrorModelResultType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TransferToNumberResultErrorModelResultType value,
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
        public const string TransferToNumberError = "transfer_to_number_error";
    }
}
