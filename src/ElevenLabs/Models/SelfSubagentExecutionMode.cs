using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Whether to wait for the reply, or keep going and get it later in the conversation.</summary>
[JsonConverter(typeof(SelfSubagentExecutionMode.SelfSubagentExecutionModeSerializer))]
[Serializable]
public readonly record struct SelfSubagentExecutionMode : IStringEnum
{
    public static readonly SelfSubagentExecutionMode Immediate = new(Values.Immediate);

    public static readonly SelfSubagentExecutionMode Async = new(Values.Async);

    public SelfSubagentExecutionMode(string value)
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
    public static SelfSubagentExecutionMode FromCustom(string value)
    {
        return new SelfSubagentExecutionMode(value);
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

    public static bool operator ==(SelfSubagentExecutionMode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SelfSubagentExecutionMode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SelfSubagentExecutionMode value) => value.Value;

    public static explicit operator SelfSubagentExecutionMode(string value) => new(value);

    internal class SelfSubagentExecutionModeSerializer : JsonConverter<SelfSubagentExecutionMode>
    {
        public override SelfSubagentExecutionMode Read(
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
            return new SelfSubagentExecutionMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SelfSubagentExecutionMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SelfSubagentExecutionMode ReadAsPropertyName(
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
            return new SelfSubagentExecutionMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SelfSubagentExecutionMode value,
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
