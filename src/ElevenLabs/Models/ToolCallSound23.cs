using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Agents.McpServers;

[JsonConverter(typeof(ToolCallSound23.ToolCallSound23Serializer))]
[Serializable]
public readonly record struct ToolCallSound23 : IStringEnum
{
    public static readonly ToolCallSound23 Off = new(Values.Off);

    public ToolCallSound23(string value)
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
    public static ToolCallSound23 FromCustom(string value)
    {
        return new ToolCallSound23(value);
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

    public static bool operator ==(ToolCallSound23 value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ToolCallSound23 value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ToolCallSound23 value) => value.Value;

    public static explicit operator ToolCallSound23(string value) => new(value);

    internal class ToolCallSound23Serializer : JsonConverter<ToolCallSound23>
    {
        public override ToolCallSound23 Read(
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
            return new ToolCallSound23(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ToolCallSound23 value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ToolCallSound23 ReadAsPropertyName(
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
            return new ToolCallSound23(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ToolCallSound23 value,
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
        public const string Off = "off";
    }
}
