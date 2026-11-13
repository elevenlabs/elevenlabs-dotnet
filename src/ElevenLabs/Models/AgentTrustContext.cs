using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>
/// The trust context in which the agent operates.
///
/// UNKNOWN: not yet classified (existing agents created before this feature).
/// LOW: serves untrusted external participants (e.g. customer support, sales) —
///      outputs should be vetted and tool access scoped.
/// HIGH: serves the owner (e.g. personal assistant) — full tool access is appropriate.
/// </summary>
[JsonConverter(typeof(AgentTrustContext.AgentTrustContextSerializer))]
[Serializable]
public readonly record struct AgentTrustContext : IStringEnum
{
    public static readonly AgentTrustContext Unknown = new(Values.Unknown);

    public static readonly AgentTrustContext Low = new(Values.Low);

    public static readonly AgentTrustContext High = new(Values.High);

    public AgentTrustContext(string value)
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
    public static AgentTrustContext FromCustom(string value)
    {
        return new AgentTrustContext(value);
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

    public static bool operator ==(AgentTrustContext value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AgentTrustContext value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AgentTrustContext value) => value.Value;

    public static explicit operator AgentTrustContext(string value) => new(value);

    internal class AgentTrustContextSerializer : JsonConverter<AgentTrustContext>
    {
        public override AgentTrustContext Read(
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
            return new AgentTrustContext(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentTrustContext value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AgentTrustContext ReadAsPropertyName(
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
            return new AgentTrustContext(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentTrustContext value,
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
        public const string Unknown = "unknown";

        public const string Low = "low";

        public const string High = "high";
    }
}
