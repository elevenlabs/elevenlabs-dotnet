using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ContextUsageType.ContextUsageTypeSerializer))]
[Serializable]
public readonly record struct ContextUsageType : IStringEnum
{
    public static readonly ContextUsageType ContextUsage = new(Values.ContextUsage);

    public ContextUsageType(string value)
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
    public static ContextUsageType FromCustom(string value)
    {
        return new ContextUsageType(value);
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

    public static bool operator ==(ContextUsageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ContextUsageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ContextUsageType value) => value.Value;

    public static explicit operator ContextUsageType(string value) => new(value);

    internal class ContextUsageTypeSerializer : JsonConverter<ContextUsageType>
    {
        public override ContextUsageType Read(
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
            return new ContextUsageType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ContextUsageType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ContextUsageType ReadAsPropertyName(
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
            return new ContextUsageType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ContextUsageType value,
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
        public const string ContextUsage = "context_usage";
    }
}
