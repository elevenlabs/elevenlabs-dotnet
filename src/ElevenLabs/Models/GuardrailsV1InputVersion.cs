using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(GuardrailsV1InputVersion.GuardrailsV1InputVersionSerializer))]
[Serializable]
public readonly record struct GuardrailsV1InputVersion : IStringEnum
{
    public static readonly GuardrailsV1InputVersion One = new(Values.One);

    public GuardrailsV1InputVersion(string value)
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
    public static GuardrailsV1InputVersion FromCustom(string value)
    {
        return new GuardrailsV1InputVersion(value);
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

    public static bool operator ==(GuardrailsV1InputVersion value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GuardrailsV1InputVersion value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GuardrailsV1InputVersion value) => value.Value;

    public static explicit operator GuardrailsV1InputVersion(string value) => new(value);

    internal class GuardrailsV1InputVersionSerializer : JsonConverter<GuardrailsV1InputVersion>
    {
        public override GuardrailsV1InputVersion Read(
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
            return new GuardrailsV1InputVersion(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GuardrailsV1InputVersion value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GuardrailsV1InputVersion ReadAsPropertyName(
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
            return new GuardrailsV1InputVersion(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GuardrailsV1InputVersion value,
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
