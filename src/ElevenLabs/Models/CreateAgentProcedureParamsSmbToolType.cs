using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(CreateAgentProcedureParamsSmbToolType.CreateAgentProcedureParamsSmbToolTypeSerializer)
)]
[Serializable]
public readonly record struct CreateAgentProcedureParamsSmbToolType : IStringEnum
{
    public static readonly CreateAgentProcedureParamsSmbToolType CreateAgentProcedure = new(
        Values.CreateAgentProcedure
    );

    public CreateAgentProcedureParamsSmbToolType(string value)
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
    public static CreateAgentProcedureParamsSmbToolType FromCustom(string value)
    {
        return new CreateAgentProcedureParamsSmbToolType(value);
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

    public static bool operator ==(CreateAgentProcedureParamsSmbToolType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateAgentProcedureParamsSmbToolType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateAgentProcedureParamsSmbToolType value) =>
        value.Value;

    public static explicit operator CreateAgentProcedureParamsSmbToolType(string value) =>
        new(value);

    internal class CreateAgentProcedureParamsSmbToolTypeSerializer
        : JsonConverter<CreateAgentProcedureParamsSmbToolType>
    {
        public override CreateAgentProcedureParamsSmbToolType Read(
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
            return new CreateAgentProcedureParamsSmbToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateAgentProcedureParamsSmbToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateAgentProcedureParamsSmbToolType ReadAsPropertyName(
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
            return new CreateAgentProcedureParamsSmbToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateAgentProcedureParamsSmbToolType value,
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
        public const string CreateAgentProcedure = "create_agent_procedure";
    }
}
