using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(DeleteAgentRuleParamsSmbToolType.DeleteAgentRuleParamsSmbToolTypeSerializer))]
[Serializable]
public readonly record struct DeleteAgentRuleParamsSmbToolType : IStringEnum
{
    public static readonly DeleteAgentRuleParamsSmbToolType DeleteAgentRule = new(
        Values.DeleteAgentRule
    );

    public DeleteAgentRuleParamsSmbToolType(string value)
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
    public static DeleteAgentRuleParamsSmbToolType FromCustom(string value)
    {
        return new DeleteAgentRuleParamsSmbToolType(value);
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

    public static bool operator ==(DeleteAgentRuleParamsSmbToolType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DeleteAgentRuleParamsSmbToolType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DeleteAgentRuleParamsSmbToolType value) => value.Value;

    public static explicit operator DeleteAgentRuleParamsSmbToolType(string value) => new(value);

    internal class DeleteAgentRuleParamsSmbToolTypeSerializer
        : JsonConverter<DeleteAgentRuleParamsSmbToolType>
    {
        public override DeleteAgentRuleParamsSmbToolType Read(
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
            return new DeleteAgentRuleParamsSmbToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DeleteAgentRuleParamsSmbToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DeleteAgentRuleParamsSmbToolType ReadAsPropertyName(
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
            return new DeleteAgentRuleParamsSmbToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DeleteAgentRuleParamsSmbToolType value,
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
        public const string DeleteAgentRule = "delete_agent_rule";
    }
}
