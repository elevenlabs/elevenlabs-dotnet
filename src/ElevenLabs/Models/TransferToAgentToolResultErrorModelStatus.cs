using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(TransferToAgentToolResultErrorModelStatus.TransferToAgentToolResultErrorModelStatusSerializer)
)]
[Serializable]
public readonly record struct TransferToAgentToolResultErrorModelStatus : IStringEnum
{
    public static readonly TransferToAgentToolResultErrorModelStatus Error = new(Values.Error);

    public TransferToAgentToolResultErrorModelStatus(string value)
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
    public static TransferToAgentToolResultErrorModelStatus FromCustom(string value)
    {
        return new TransferToAgentToolResultErrorModelStatus(value);
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
        TransferToAgentToolResultErrorModelStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        TransferToAgentToolResultErrorModelStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(TransferToAgentToolResultErrorModelStatus value) =>
        value.Value;

    public static explicit operator TransferToAgentToolResultErrorModelStatus(string value) =>
        new(value);

    internal class TransferToAgentToolResultErrorModelStatusSerializer
        : JsonConverter<TransferToAgentToolResultErrorModelStatus>
    {
        public override TransferToAgentToolResultErrorModelStatus Read(
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
            return new TransferToAgentToolResultErrorModelStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TransferToAgentToolResultErrorModelStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TransferToAgentToolResultErrorModelStatus ReadAsPropertyName(
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
            return new TransferToAgentToolResultErrorModelStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TransferToAgentToolResultErrorModelStatus value,
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
        public const string Error = "error";
    }
}
