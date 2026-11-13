using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(TransferToAgentToolResultSuccessModelOutputResultType.TransferToAgentToolResultSuccessModelOutputResultTypeSerializer)
)]
[Serializable]
public readonly record struct TransferToAgentToolResultSuccessModelOutputResultType : IStringEnum
{
    public static readonly TransferToAgentToolResultSuccessModelOutputResultType TransferToAgentSuccess =
        new(Values.TransferToAgentSuccess);

    public TransferToAgentToolResultSuccessModelOutputResultType(string value)
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
    public static TransferToAgentToolResultSuccessModelOutputResultType FromCustom(string value)
    {
        return new TransferToAgentToolResultSuccessModelOutputResultType(value);
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
        TransferToAgentToolResultSuccessModelOutputResultType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        TransferToAgentToolResultSuccessModelOutputResultType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        TransferToAgentToolResultSuccessModelOutputResultType value
    ) => value.Value;

    public static explicit operator TransferToAgentToolResultSuccessModelOutputResultType(
        string value
    ) => new(value);

    internal class TransferToAgentToolResultSuccessModelOutputResultTypeSerializer
        : JsonConverter<TransferToAgentToolResultSuccessModelOutputResultType>
    {
        public override TransferToAgentToolResultSuccessModelOutputResultType Read(
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
            return new TransferToAgentToolResultSuccessModelOutputResultType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TransferToAgentToolResultSuccessModelOutputResultType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TransferToAgentToolResultSuccessModelOutputResultType ReadAsPropertyName(
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
            return new TransferToAgentToolResultSuccessModelOutputResultType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TransferToAgentToolResultSuccessModelOutputResultType value,
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
        public const string TransferToAgentSuccess = "transfer_to_agent_success";
    }
}
