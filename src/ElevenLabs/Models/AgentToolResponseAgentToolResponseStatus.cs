using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Tool call status derived from execution flags.</summary>
[JsonConverter(
    typeof(AgentToolResponseAgentToolResponseStatus.AgentToolResponseAgentToolResponseStatusSerializer)
)]
[Serializable]
public readonly record struct AgentToolResponseAgentToolResponseStatus : IStringEnum
{
    public static readonly AgentToolResponseAgentToolResponseStatus Success = new(Values.Success);

    public static readonly AgentToolResponseAgentToolResponseStatus Error = new(Values.Error);

    public static readonly AgentToolResponseAgentToolResponseStatus Blocked = new(Values.Blocked);

    public static readonly AgentToolResponseAgentToolResponseStatus Skipped = new(Values.Skipped);

    public AgentToolResponseAgentToolResponseStatus(string value)
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
    public static AgentToolResponseAgentToolResponseStatus FromCustom(string value)
    {
        return new AgentToolResponseAgentToolResponseStatus(value);
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

    public static bool operator ==(
        AgentToolResponseAgentToolResponseStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        AgentToolResponseAgentToolResponseStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(AgentToolResponseAgentToolResponseStatus value) =>
        value.Value;

    public static explicit operator AgentToolResponseAgentToolResponseStatus(string value) =>
        new(value);

    internal class AgentToolResponseAgentToolResponseStatusSerializer
        : JsonConverter<AgentToolResponseAgentToolResponseStatus>
    {
        public override AgentToolResponseAgentToolResponseStatus Read(
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
            return new AgentToolResponseAgentToolResponseStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentToolResponseAgentToolResponseStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AgentToolResponseAgentToolResponseStatus ReadAsPropertyName(
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
            return new AgentToolResponseAgentToolResponseStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentToolResponseAgentToolResponseStatus value,
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
        public const string Success = "success";

        public const string Error = "error";

        public const string Blocked = "blocked";

        public const string Skipped = "skipped";
    }
}
