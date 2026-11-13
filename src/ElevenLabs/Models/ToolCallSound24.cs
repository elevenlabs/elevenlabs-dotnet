using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Agents.McpServers;

[JsonConverter(typeof(ToolCallSound24.ToolCallSound24Serializer))]
[Serializable]
public readonly record struct ToolCallSound24 : IStringEnum
{
    public static readonly ToolCallSound24 Off = new(Values.Off);

    public ToolCallSound24(string value)
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
    public static ToolCallSound24 FromCustom(string value)
    {
        return new ToolCallSound24(value);
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

    public static bool operator ==(ToolCallSound24 value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ToolCallSound24 value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ToolCallSound24 value) => value.Value;

    public static explicit operator ToolCallSound24(string value) => new(value);

    internal class ToolCallSound24Serializer : JsonConverter<ToolCallSound24>
    {
        public override ToolCallSound24 Read(
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
            return new ToolCallSound24(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ToolCallSound24 value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ToolCallSound24 ReadAsPropertyName(
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
            return new ToolCallSound24(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ToolCallSound24 value,
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
