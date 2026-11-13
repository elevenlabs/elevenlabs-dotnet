using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ListAgentProceduresParamsSmbToolType.ListAgentProceduresParamsSmbToolTypeSerializer)
)]
[Serializable]
public readonly record struct ListAgentProceduresParamsSmbToolType : IStringEnum
{
    public static readonly ListAgentProceduresParamsSmbToolType ListAgentProcedures = new(
        Values.ListAgentProcedures
    );

    public ListAgentProceduresParamsSmbToolType(string value)
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
    public static ListAgentProceduresParamsSmbToolType FromCustom(string value)
    {
        return new ListAgentProceduresParamsSmbToolType(value);
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

    public static bool operator ==(ListAgentProceduresParamsSmbToolType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListAgentProceduresParamsSmbToolType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListAgentProceduresParamsSmbToolType value) =>
        value.Value;

    public static explicit operator ListAgentProceduresParamsSmbToolType(string value) =>
        new(value);

    internal class ListAgentProceduresParamsSmbToolTypeSerializer
        : JsonConverter<ListAgentProceduresParamsSmbToolType>
    {
        public override ListAgentProceduresParamsSmbToolType Read(
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
            return new ListAgentProceduresParamsSmbToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListAgentProceduresParamsSmbToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListAgentProceduresParamsSmbToolType ReadAsPropertyName(
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
            return new ListAgentProceduresParamsSmbToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListAgentProceduresParamsSmbToolType value,
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
        public const string ListAgentProcedures = "list_agent_procedures";
    }
}
