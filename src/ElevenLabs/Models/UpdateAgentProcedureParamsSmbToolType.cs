using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(UpdateAgentProcedureParamsSmbToolType.UpdateAgentProcedureParamsSmbToolTypeSerializer)
)]
[Serializable]
public readonly record struct UpdateAgentProcedureParamsSmbToolType : IStringEnum
{
    public static readonly UpdateAgentProcedureParamsSmbToolType UpdateAgentProcedure = new(
        Values.UpdateAgentProcedure
    );

    public UpdateAgentProcedureParamsSmbToolType(string value)
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
    public static UpdateAgentProcedureParamsSmbToolType FromCustom(string value)
    {
        return new UpdateAgentProcedureParamsSmbToolType(value);
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

    public static bool operator ==(UpdateAgentProcedureParamsSmbToolType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UpdateAgentProcedureParamsSmbToolType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UpdateAgentProcedureParamsSmbToolType value) =>
        value.Value;

    public static explicit operator UpdateAgentProcedureParamsSmbToolType(string value) =>
        new(value);

    internal class UpdateAgentProcedureParamsSmbToolTypeSerializer
        : JsonConverter<UpdateAgentProcedureParamsSmbToolType>
    {
        public override UpdateAgentProcedureParamsSmbToolType Read(
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
            return new UpdateAgentProcedureParamsSmbToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateAgentProcedureParamsSmbToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdateAgentProcedureParamsSmbToolType ReadAsPropertyName(
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
            return new UpdateAgentProcedureParamsSmbToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateAgentProcedureParamsSmbToolType value,
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
        public const string UpdateAgentProcedure = "update_agent_procedure";
    }
}
