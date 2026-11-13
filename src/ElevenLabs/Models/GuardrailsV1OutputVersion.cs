using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(GuardrailsV1OutputVersion.GuardrailsV1OutputVersionSerializer))]
[Serializable]
public readonly record struct GuardrailsV1OutputVersion : IStringEnum
{
    public static readonly GuardrailsV1OutputVersion One = new(Values.One);

    public GuardrailsV1OutputVersion(string value)
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
    public static GuardrailsV1OutputVersion FromCustom(string value)
    {
        return new GuardrailsV1OutputVersion(value);
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

    public static bool operator ==(GuardrailsV1OutputVersion value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GuardrailsV1OutputVersion value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GuardrailsV1OutputVersion value) => value.Value;

    public static explicit operator GuardrailsV1OutputVersion(string value) => new(value);

    internal class GuardrailsV1OutputVersionSerializer : JsonConverter<GuardrailsV1OutputVersion>
    {
        public override GuardrailsV1OutputVersion Read(
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
            return new GuardrailsV1OutputVersion(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GuardrailsV1OutputVersion value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GuardrailsV1OutputVersion ReadAsPropertyName(
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
            return new GuardrailsV1OutputVersion(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GuardrailsV1OutputVersion value,
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
        public const string One = "1";
    }
}
