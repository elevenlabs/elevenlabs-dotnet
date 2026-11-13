using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AgentDeploymentSource.AgentDeploymentSourceSerializer))]
[Serializable]
public readonly record struct AgentDeploymentSource : IStringEnum
{
    public static readonly AgentDeploymentSource Manual = new(Values.Manual);

    public static readonly AgentDeploymentSource BranchMerge = new(Values.BranchMerge);

    public static readonly AgentDeploymentSource Duplicate = new(Values.Duplicate);

    public AgentDeploymentSource(string value)
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
    public static AgentDeploymentSource FromCustom(string value)
    {
        return new AgentDeploymentSource(value);
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

    public static bool operator ==(AgentDeploymentSource value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AgentDeploymentSource value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AgentDeploymentSource value) => value.Value;

    public static explicit operator AgentDeploymentSource(string value) => new(value);

    internal class AgentDeploymentSourceSerializer : JsonConverter<AgentDeploymentSource>
    {
        public override AgentDeploymentSource Read(
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
            return new AgentDeploymentSource(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentDeploymentSource value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AgentDeploymentSource ReadAsPropertyName(
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
            return new AgentDeploymentSource(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentDeploymentSource value,
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
        public const string Manual = "manual";

        public const string BranchMerge = "branch_merge";

        public const string Duplicate = "duplicate";
    }
}
