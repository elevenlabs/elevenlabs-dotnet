using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(SmbAgentType.SmbAgentTypeSerializer))]
[Serializable]
public readonly record struct SmbAgentType : IStringEnum
{
    public static readonly SmbAgentType CustomerFacing = new(Values.CustomerFacing);

    public static readonly SmbAgentType Assistant = new(Values.Assistant);

    public SmbAgentType(string value)
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
    public static SmbAgentType FromCustom(string value)
    {
        return new SmbAgentType(value);
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

    public static bool operator ==(SmbAgentType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SmbAgentType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SmbAgentType value) => value.Value;

    public static explicit operator SmbAgentType(string value) => new(value);

    internal class SmbAgentTypeSerializer : JsonConverter<SmbAgentType>
    {
        public override SmbAgentType Read(
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
            return new SmbAgentType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SmbAgentType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SmbAgentType ReadAsPropertyName(
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
            return new SmbAgentType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SmbAgentType value,
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
