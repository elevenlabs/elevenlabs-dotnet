using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Whether to wait for the reply, or keep going and get it later in the conversation.</summary>
[JsonConverter(typeof(SubAgentOutputExecutionMode.SubAgentOutputExecutionModeSerializer))]
[Serializable]
public readonly record struct SubAgentOutputExecutionMode : IStringEnum
{
    public static readonly SubAgentOutputExecutionMode Immediate = new(Values.Immediate);

    public static readonly SubAgentOutputExecutionMode Async = new(Values.Async);

    public SubAgentOutputExecutionMode(string value)
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
    public static SubAgentOutputExecutionMode FromCustom(string value)
    {
        return new SubAgentOutputExecutionMode(value);
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

    public static bool operator ==(SubAgentOutputExecutionMode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SubAgentOutputExecutionMode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SubAgentOutputExecutionMode value) => value.Value;

    public static explicit operator SubAgentOutputExecutionMode(string value) => new(value);

    internal class SubAgentOutputExecutionModeSerializer
        : JsonConverter<SubAgentOutputExecutionMode>
    {
        public override SubAgentOutputExecutionMode Read(
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
            return new SubAgentOutputExecutionMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SubAgentOutputExecutionMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SubAgentOutputExecutionMode ReadAsPropertyName(
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
            return new SubAgentOutputExecutionMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SubAgentOutputExecutionMode value,
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
        public const string Immediate = "immediate";

        public const string Async = "async";
    }
}
