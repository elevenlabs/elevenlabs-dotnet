using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(TransferToAgentToolConfigOutputSystemToolType.TransferToAgentToolConfigOutputSystemToolTypeSerializer)
)]
[Serializable]
public readonly record struct TransferToAgentToolConfigOutputSystemToolType : IStringEnum
{
    public static readonly TransferToAgentToolConfigOutputSystemToolType TransferToAgent = new(
        Values.TransferToAgent
    );

    public TransferToAgentToolConfigOutputSystemToolType(string value)
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
    public static TransferToAgentToolConfigOutputSystemToolType FromCustom(string value)
    {
        return new TransferToAgentToolConfigOutputSystemToolType(value);
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
        TransferToAgentToolConfigOutputSystemToolType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        TransferToAgentToolConfigOutputSystemToolType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(TransferToAgentToolConfigOutputSystemToolType value) =>
        value.Value;

    public static explicit operator TransferToAgentToolConfigOutputSystemToolType(string value) =>
        new(value);

    internal class TransferToAgentToolConfigOutputSystemToolTypeSerializer
        : JsonConverter<TransferToAgentToolConfigOutputSystemToolType>
    {
        public override TransferToAgentToolConfigOutputSystemToolType Read(
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
            return new TransferToAgentToolConfigOutputSystemToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TransferToAgentToolConfigOutputSystemToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TransferToAgentToolConfigOutputSystemToolType ReadAsPropertyName(
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
            return new TransferToAgentToolConfigOutputSystemToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TransferToAgentToolConfigOutputSystemToolType value,
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
        public const string TransferToAgent = "transfer_to_agent";
    }
}
