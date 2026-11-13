using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AgentFailureResponseExampleType.AgentFailureResponseExampleTypeSerializer))]
[Serializable]
public readonly record struct AgentFailureResponseExampleType : IStringEnum
{
    public static readonly AgentFailureResponseExampleType Failure = new(Values.Failure);

    public AgentFailureResponseExampleType(string value)
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
    public static AgentFailureResponseExampleType FromCustom(string value)
    {
        return new AgentFailureResponseExampleType(value);
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

    public static bool operator ==(AgentFailureResponseExampleType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AgentFailureResponseExampleType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AgentFailureResponseExampleType value) => value.Value;

    public static explicit operator AgentFailureResponseExampleType(string value) => new(value);

    internal class AgentFailureResponseExampleTypeSerializer
        : JsonConverter<AgentFailureResponseExampleType>
    {
        public override AgentFailureResponseExampleType Read(
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
            return new AgentFailureResponseExampleType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentFailureResponseExampleType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AgentFailureResponseExampleType ReadAsPropertyName(
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
            return new AgentFailureResponseExampleType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentFailureResponseExampleType value,
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
        public const string Failure = "failure";
    }
}
