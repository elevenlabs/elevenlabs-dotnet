using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AgentTestEntityType.AgentTestEntityTypeSerializer))]
[Serializable]
public readonly record struct AgentTestEntityType : IStringEnum
{
    public static readonly AgentTestEntityType Test = new(Values.Test);

    public static readonly AgentTestEntityType Folder = new(Values.Folder);

    public AgentTestEntityType(string value)
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
    public static AgentTestEntityType FromCustom(string value)
    {
        return new AgentTestEntityType(value);
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

    public static bool operator ==(AgentTestEntityType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AgentTestEntityType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AgentTestEntityType value) => value.Value;

    public static explicit operator AgentTestEntityType(string value) => new(value);

    internal class AgentTestEntityTypeSerializer : JsonConverter<AgentTestEntityType>
    {
        public override AgentTestEntityType Read(
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
            return new AgentTestEntityType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentTestEntityType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AgentTestEntityType ReadAsPropertyName(
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
            return new AgentTestEntityType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentTestEntityType value,
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
        public const string Test = "test";

        public const string Folder = "folder";
    }
}
