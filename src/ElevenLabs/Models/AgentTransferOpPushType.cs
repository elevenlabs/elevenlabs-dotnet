using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AgentTransferOpPushType.AgentTransferOpPushTypeSerializer))]
[Serializable]
public readonly record struct AgentTransferOpPushType : IStringEnum
{
    public static readonly AgentTransferOpPushType Push = new(Values.Push);

    public AgentTransferOpPushType(string value)
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
    public static AgentTransferOpPushType FromCustom(string value)
    {
        return new AgentTransferOpPushType(value);
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

    public static bool operator ==(AgentTransferOpPushType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AgentTransferOpPushType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AgentTransferOpPushType value) => value.Value;

    public static explicit operator AgentTransferOpPushType(string value) => new(value);

    internal class AgentTransferOpPushTypeSerializer : JsonConverter<AgentTransferOpPushType>
    {
        public override AgentTransferOpPushType Read(
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
            return new AgentTransferOpPushType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentTransferOpPushType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AgentTransferOpPushType ReadAsPropertyName(
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
            return new AgentTransferOpPushType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentTransferOpPushType value,
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
        public const string Push = "push";
    }
}
