using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(TransferToAgentToolResultSuccessModelInputResultType.TransferToAgentToolResultSuccessModelInputResultTypeSerializer)
)]
[Serializable]
public readonly record struct TransferToAgentToolResultSuccessModelInputResultType : IStringEnum
{
    public static readonly TransferToAgentToolResultSuccessModelInputResultType TransferToAgentSuccess =
        new(Values.TransferToAgentSuccess);

    public TransferToAgentToolResultSuccessModelInputResultType(string value)
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
    public static TransferToAgentToolResultSuccessModelInputResultType FromCustom(string value)
    {
        return new TransferToAgentToolResultSuccessModelInputResultType(value);
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
        TransferToAgentToolResultSuccessModelInputResultType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        TransferToAgentToolResultSuccessModelInputResultType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        TransferToAgentToolResultSuccessModelInputResultType value
    ) => value.Value;

    public static explicit operator TransferToAgentToolResultSuccessModelInputResultType(
        string value
    ) => new(value);

    internal class TransferToAgentToolResultSuccessModelInputResultTypeSerializer
        : JsonConverter<TransferToAgentToolResultSuccessModelInputResultType>
    {
        public override TransferToAgentToolResultSuccessModelInputResultType Read(
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
            return new TransferToAgentToolResultSuccessModelInputResultType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TransferToAgentToolResultSuccessModelInputResultType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TransferToAgentToolResultSuccessModelInputResultType ReadAsPropertyName(
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
            return new TransferToAgentToolResultSuccessModelInputResultType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TransferToAgentToolResultSuccessModelInputResultType value,
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
