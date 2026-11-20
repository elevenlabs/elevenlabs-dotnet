using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ReceptionAgentTarget.ReceptionAgentTargetSerializer))]
[Serializable]
public readonly record struct ReceptionAgentTarget : IStringEnum
{
    public static readonly ReceptionAgentTarget CustomerFacing = new(Values.CustomerFacing);

    public static readonly ReceptionAgentTarget Assistant = new(Values.Assistant);

    public ReceptionAgentTarget(string value)
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
    public static ReceptionAgentTarget FromCustom(string value)
    {
        return new ReceptionAgentTarget(value);
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

    public static bool operator ==(ReceptionAgentTarget value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ReceptionAgentTarget value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ReceptionAgentTarget value) => value.Value;

    public static explicit operator ReceptionAgentTarget(string value) => new(value);

    internal class ReceptionAgentTargetSerializer : JsonConverter<ReceptionAgentTarget>
    {
        public override ReceptionAgentTarget Read(
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
            return new ReceptionAgentTarget(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReceptionAgentTarget value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ReceptionAgentTarget ReadAsPropertyName(
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
            return new ReceptionAgentTarget(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReceptionAgentTarget value,
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
        public const string CustomerFacing = "customer_facing";

        public const string Assistant = "assistant";
    }
}
