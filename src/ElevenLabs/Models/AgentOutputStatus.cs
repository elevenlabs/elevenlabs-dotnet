using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AgentOutputStatus.AgentOutputStatusSerializer))]
[Serializable]
public readonly record struct AgentOutputStatus : IStringEnum
{
    public static readonly AgentOutputStatus InProgress = new(Values.InProgress);

    public static readonly AgentOutputStatus Completed = new(Values.Completed);

    public static readonly AgentOutputStatus RequiresAction = new(Values.RequiresAction);

    public static readonly AgentOutputStatus Failed = new(Values.Failed);

    public static readonly AgentOutputStatus TimedOut = new(Values.TimedOut);

    public AgentOutputStatus(string value)
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
    public static AgentOutputStatus FromCustom(string value)
    {
        return new AgentOutputStatus(value);
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

    public static bool operator ==(AgentOutputStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AgentOutputStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AgentOutputStatus value) => value.Value;

    public static explicit operator AgentOutputStatus(string value) => new(value);

    internal class AgentOutputStatusSerializer : JsonConverter<AgentOutputStatus>
    {
        public override AgentOutputStatus Read(
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
            return new AgentOutputStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentOutputStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AgentOutputStatus ReadAsPropertyName(
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
            return new AgentOutputStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentOutputStatus value,
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
        public const string InProgress = "in_progress";

        public const string Completed = "completed";

        public const string RequiresAction = "requires_action";

        public const string Failed = "failed";

        public const string TimedOut = "timed_out";
    }
}
