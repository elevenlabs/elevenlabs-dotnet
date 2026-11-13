using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AgentSortBy.AgentSortBySerializer))]
[Serializable]
public readonly record struct AgentSortBy : IStringEnum
{
    public static readonly AgentSortBy Name = new(Values.Name);

    public static readonly AgentSortBy CreatedAt = new(Values.CreatedAt);

    public static readonly AgentSortBy UpdatedAt = new(Values.UpdatedAt);

    public static readonly AgentSortBy CallCount7D = new(Values.CallCount7D);

    public AgentSortBy(string value)
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
    public static AgentSortBy FromCustom(string value)
    {
        return new AgentSortBy(value);
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

    public static bool operator ==(AgentSortBy value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AgentSortBy value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AgentSortBy value) => value.Value;

    public static explicit operator AgentSortBy(string value) => new(value);

    internal class AgentSortBySerializer : JsonConverter<AgentSortBy>
    {
        public override AgentSortBy Read(
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
            return new AgentSortBy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentSortBy value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AgentSortBy ReadAsPropertyName(
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
            return new AgentSortBy(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentSortBy value,
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
        public const string Name = "name";

        public const string CreatedAt = "created_at";

        public const string UpdatedAt = "updated_at";

        public const string CallCount7D = "call_count_7d";
    }
}
