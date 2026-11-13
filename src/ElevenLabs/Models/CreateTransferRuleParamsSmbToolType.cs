using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(CreateTransferRuleParamsSmbToolType.CreateTransferRuleParamsSmbToolTypeSerializer)
)]
[Serializable]
public readonly record struct CreateTransferRuleParamsSmbToolType : IStringEnum
{
    public static readonly CreateTransferRuleParamsSmbToolType CreateTransferRule = new(
        Values.CreateTransferRule
    );

    public CreateTransferRuleParamsSmbToolType(string value)
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
    public static CreateTransferRuleParamsSmbToolType FromCustom(string value)
    {
        return new CreateTransferRuleParamsSmbToolType(value);
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

    public static bool operator ==(CreateTransferRuleParamsSmbToolType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateTransferRuleParamsSmbToolType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateTransferRuleParamsSmbToolType value) =>
        value.Value;

    public static explicit operator CreateTransferRuleParamsSmbToolType(string value) => new(value);

    internal class CreateTransferRuleParamsSmbToolTypeSerializer
        : JsonConverter<CreateTransferRuleParamsSmbToolType>
    {
        public override CreateTransferRuleParamsSmbToolType Read(
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
            return new CreateTransferRuleParamsSmbToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateTransferRuleParamsSmbToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateTransferRuleParamsSmbToolType ReadAsPropertyName(
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
            return new CreateTransferRuleParamsSmbToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateTransferRuleParamsSmbToolType value,
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
        public const string CreateTransferRule = "create_transfer_rule";
    }
}
