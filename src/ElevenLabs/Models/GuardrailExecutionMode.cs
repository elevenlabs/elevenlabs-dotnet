using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(GuardrailExecutionMode.GuardrailExecutionModeSerializer))]
[Serializable]
public readonly record struct GuardrailExecutionMode : IStringEnum
{
    public static readonly GuardrailExecutionMode Streaming = new(Values.Streaming);

    public static readonly GuardrailExecutionMode Blocking = new(Values.Blocking);

    public GuardrailExecutionMode(string value)
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
    public static GuardrailExecutionMode FromCustom(string value)
    {
        return new GuardrailExecutionMode(value);
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

    public static bool operator ==(GuardrailExecutionMode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GuardrailExecutionMode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GuardrailExecutionMode value) => value.Value;

    public static explicit operator GuardrailExecutionMode(string value) => new(value);

    internal class GuardrailExecutionModeSerializer : JsonConverter<GuardrailExecutionMode>
    {
        public override GuardrailExecutionMode Read(
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
            return new GuardrailExecutionMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GuardrailExecutionMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GuardrailExecutionMode ReadAsPropertyName(
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
            return new GuardrailExecutionMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GuardrailExecutionMode value,
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
        public const string Streaming = "streaming";

        public const string Blocking = "blocking";
    }
}
