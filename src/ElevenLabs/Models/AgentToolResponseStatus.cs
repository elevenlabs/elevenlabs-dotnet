using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AgentToolResponseStatus.AgentToolResponseStatusSerializer))]
[Serializable]
public readonly record struct AgentToolResponseStatus : IStringEnum
{
    public static readonly AgentToolResponseStatus Success = new(Values.Success);

    public static readonly AgentToolResponseStatus Error = new(Values.Error);

    public static readonly AgentToolResponseStatus Blocked = new(Values.Blocked);

    public static readonly AgentToolResponseStatus Skipped = new(Values.Skipped);

    public AgentToolResponseStatus(string value)
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
    public static AgentToolResponseStatus FromCustom(string value)
    {
        return new AgentToolResponseStatus(value);
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

    public static bool operator ==(AgentToolResponseStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AgentToolResponseStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AgentToolResponseStatus value) => value.Value;

    public static explicit operator AgentToolResponseStatus(string value) => new(value);

    internal class AgentToolResponseStatusSerializer : JsonConverter<AgentToolResponseStatus>
    {
        public override AgentToolResponseStatus Read(
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
            return new AgentToolResponseStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentToolResponseStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AgentToolResponseStatus ReadAsPropertyName(
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
            return new AgentToolResponseStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentToolResponseStatus value,
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
