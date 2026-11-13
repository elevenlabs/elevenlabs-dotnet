using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(UpdateTransferRuleParamsSmbToolType.UpdateTransferRuleParamsSmbToolTypeSerializer)
)]
[Serializable]
public readonly record struct UpdateTransferRuleParamsSmbToolType : IStringEnum
{
    public static readonly UpdateTransferRuleParamsSmbToolType UpdateTransferRule = new(
        Values.UpdateTransferRule
    );

    public UpdateTransferRuleParamsSmbToolType(string value)
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
    public static UpdateTransferRuleParamsSmbToolType FromCustom(string value)
    {
        return new UpdateTransferRuleParamsSmbToolType(value);
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

    public static bool operator ==(UpdateTransferRuleParamsSmbToolType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UpdateTransferRuleParamsSmbToolType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UpdateTransferRuleParamsSmbToolType value) =>
        value.Value;

    public static explicit operator UpdateTransferRuleParamsSmbToolType(string value) => new(value);

    internal class UpdateTransferRuleParamsSmbToolTypeSerializer
        : JsonConverter<UpdateTransferRuleParamsSmbToolType>
    {
        public override UpdateTransferRuleParamsSmbToolType Read(
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
            return new UpdateTransferRuleParamsSmbToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateTransferRuleParamsSmbToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdateTransferRuleParamsSmbToolType ReadAsPropertyName(
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
            return new UpdateTransferRuleParamsSmbToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateTransferRuleParamsSmbToolType value,
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
        public const string UpdateTransferRule = "update_transfer_rule";
    }
}
