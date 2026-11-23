using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Tool call status derived from execution flags.</summary>
[JsonConverter(
    typeof(AgentToolResponseFullPayloadAgentToolResponseFullPayloadStatus.AgentToolResponseFullPayloadAgentToolResponseFullPayloadStatusSerializer)
)]
[Serializable]
public readonly record struct AgentToolResponseFullPayloadAgentToolResponseFullPayloadStatus
    : IStringEnum
{
    public static readonly AgentToolResponseFullPayloadAgentToolResponseFullPayloadStatus Success =
        new(Values.Success);

    public static readonly AgentToolResponseFullPayloadAgentToolResponseFullPayloadStatus Error =
        new(Values.Error);

    public static readonly AgentToolResponseFullPayloadAgentToolResponseFullPayloadStatus Blocked =
        new(Values.Blocked);

    public static readonly AgentToolResponseFullPayloadAgentToolResponseFullPayloadStatus Skipped =
        new(Values.Skipped);

    public AgentToolResponseFullPayloadAgentToolResponseFullPayloadStatus(string value)
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
    public static AgentToolResponseFullPayloadAgentToolResponseFullPayloadStatus FromCustom(
        string value
    )
    {
        return new AgentToolResponseFullPayloadAgentToolResponseFullPayloadStatus(value);
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
        AgentToolResponseFullPayloadAgentToolResponseFullPayloadStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        AgentToolResponseFullPayloadAgentToolResponseFullPayloadStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        AgentToolResponseFullPayloadAgentToolResponseFullPayloadStatus value
    ) => value.Value;

    public static explicit operator AgentToolResponseFullPayloadAgentToolResponseFullPayloadStatus(
        string value
    ) => new(value);

    internal class AgentToolResponseFullPayloadAgentToolResponseFullPayloadStatusSerializer
        : JsonConverter<AgentToolResponseFullPayloadAgentToolResponseFullPayloadStatus>
    {
        public override AgentToolResponseFullPayloadAgentToolResponseFullPayloadStatus Read(
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
            return new AgentToolResponseFullPayloadAgentToolResponseFullPayloadStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentToolResponseFullPayloadAgentToolResponseFullPayloadStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AgentToolResponseFullPayloadAgentToolResponseFullPayloadStatus ReadAsPropertyName(
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
            return new AgentToolResponseFullPayloadAgentToolResponseFullPayloadStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentToolResponseFullPayloadAgentToolResponseFullPayloadStatus value,
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
