using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AgentDefinitionSource.AgentDefinitionSourceSerializer))]
[Serializable]
public readonly record struct AgentDefinitionSource : IStringEnum
{
    public static readonly AgentDefinitionSource Cli = new(Values.Cli);

    public static readonly AgentDefinitionSource Ui = new(Values.Ui);

    public static readonly AgentDefinitionSource Api = new(Values.Api);

    public static readonly AgentDefinitionSource Template = new(Values.Template);

    public static readonly AgentDefinitionSource Architect = new(Values.Architect);

    public static readonly AgentDefinitionSource Mcp = new(Values.Mcp);

    public static readonly AgentDefinitionSource Unknown = new(Values.Unknown);

    public AgentDefinitionSource(string value)
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
    public static AgentDefinitionSource FromCustom(string value)
    {
        return new AgentDefinitionSource(value);
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

    public static bool operator ==(AgentDefinitionSource value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AgentDefinitionSource value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AgentDefinitionSource value) => value.Value;

    public static explicit operator AgentDefinitionSource(string value) => new(value);

    internal class AgentDefinitionSourceSerializer : JsonConverter<AgentDefinitionSource>
    {
        public override AgentDefinitionSource Read(
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
            return new AgentDefinitionSource(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentDefinitionSource value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AgentDefinitionSource ReadAsPropertyName(
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
            return new AgentDefinitionSource(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentDefinitionSource value,
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
        public const string Cli = "cli";

        public const string Ui = "ui";

        public const string Api = "api";

        public const string Template = "template";

        public const string Architect = "architect";

        public const string Mcp = "mcp";

        public const string Unknown = "unknown";
    }
}
