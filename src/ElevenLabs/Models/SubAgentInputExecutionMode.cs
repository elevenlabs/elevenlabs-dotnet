using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Whether to wait for the reply, or keep going and get it later in the conversation.</summary>
[JsonConverter(typeof(SubAgentInputExecutionMode.SubAgentInputExecutionModeSerializer))]
[Serializable]
public readonly record struct SubAgentInputExecutionMode : IStringEnum
{
    public static readonly SubAgentInputExecutionMode Immediate = new(Values.Immediate);

    public static readonly SubAgentInputExecutionMode Async = new(Values.Async);

    public SubAgentInputExecutionMode(string value)
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
    public static SubAgentInputExecutionMode FromCustom(string value)
    {
        return new SubAgentInputExecutionMode(value);
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

    public static bool operator ==(SubAgentInputExecutionMode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SubAgentInputExecutionMode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SubAgentInputExecutionMode value) => value.Value;

    public static explicit operator SubAgentInputExecutionMode(string value) => new(value);

    internal class SubAgentInputExecutionModeSerializer : JsonConverter<SubAgentInputExecutionMode>
    {
        public override SubAgentInputExecutionMode Read(
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
            return new SubAgentInputExecutionMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SubAgentInputExecutionMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SubAgentInputExecutionMode ReadAsPropertyName(
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
            return new SubAgentInputExecutionMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SubAgentInputExecutionMode value,
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
