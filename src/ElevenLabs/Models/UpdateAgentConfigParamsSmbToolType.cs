using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(UpdateAgentConfigParamsSmbToolType.UpdateAgentConfigParamsSmbToolTypeSerializer)
)]
[Serializable]
public readonly record struct UpdateAgentConfigParamsSmbToolType : IStringEnum
{
    public static readonly UpdateAgentConfigParamsSmbToolType UpdateAgentConfig = new(
        Values.UpdateAgentConfig
    );

    public UpdateAgentConfigParamsSmbToolType(string value)
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
    public static UpdateAgentConfigParamsSmbToolType FromCustom(string value)
    {
        return new UpdateAgentConfigParamsSmbToolType(value);
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

    public static bool operator ==(UpdateAgentConfigParamsSmbToolType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UpdateAgentConfigParamsSmbToolType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UpdateAgentConfigParamsSmbToolType value) => value.Value;

    public static explicit operator UpdateAgentConfigParamsSmbToolType(string value) => new(value);

    internal class UpdateAgentConfigParamsSmbToolTypeSerializer
        : JsonConverter<UpdateAgentConfigParamsSmbToolType>
    {
        public override UpdateAgentConfigParamsSmbToolType Read(
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
            return new UpdateAgentConfigParamsSmbToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateAgentConfigParamsSmbToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdateAgentConfigParamsSmbToolType ReadAsPropertyName(
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
            return new UpdateAgentConfigParamsSmbToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateAgentConfigParamsSmbToolType value,
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
        public const string UpdateAgentConfig = "update_agent_config";
    }
}
