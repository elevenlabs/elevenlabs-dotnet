using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ToolExecutionMode.ToolExecutionModeSerializer))]
[Serializable]
public readonly record struct ToolExecutionMode : IStringEnum
{
    public static readonly ToolExecutionMode Immediate = new(Values.Immediate);

    public static readonly ToolExecutionMode PostToolSpeech = new(Values.PostToolSpeech);

    public static readonly ToolExecutionMode Async = new(Values.Async);

    public ToolExecutionMode(string value)
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
    public static ToolExecutionMode FromCustom(string value)
    {
        return new ToolExecutionMode(value);
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

    public static bool operator ==(ToolExecutionMode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ToolExecutionMode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ToolExecutionMode value) => value.Value;

    public static explicit operator ToolExecutionMode(string value) => new(value);

    internal class ToolExecutionModeSerializer : JsonConverter<ToolExecutionMode>
    {
        public override ToolExecutionMode Read(
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
            return new ToolExecutionMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ToolExecutionMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ToolExecutionMode ReadAsPropertyName(
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
            return new ToolExecutionMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ToolExecutionMode value,
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

        public const string PostToolSpeech = "post_tool_speech";

        public const string Async = "async";
    }
}
