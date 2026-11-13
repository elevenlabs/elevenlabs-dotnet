using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(CreateBasicAuthRequestAuthType.CreateBasicAuthRequestAuthTypeSerializer))]
[Serializable]
public readonly record struct CreateBasicAuthRequestAuthType : IStringEnum
{
    public static readonly CreateBasicAuthRequestAuthType BasicAuth = new(Values.BasicAuth);

    public CreateBasicAuthRequestAuthType(string value)
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
    public static CreateBasicAuthRequestAuthType FromCustom(string value)
    {
        return new CreateBasicAuthRequestAuthType(value);
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

    public static bool operator ==(CreateBasicAuthRequestAuthType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateBasicAuthRequestAuthType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateBasicAuthRequestAuthType value) => value.Value;

    public static explicit operator CreateBasicAuthRequestAuthType(string value) => new(value);

    internal class CreateBasicAuthRequestAuthTypeSerializer
        : JsonConverter<CreateBasicAuthRequestAuthType>
    {
        public override CreateBasicAuthRequestAuthType Read(
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
            return new CreateBasicAuthRequestAuthType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateBasicAuthRequestAuthType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateBasicAuthRequestAuthType ReadAsPropertyName(
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
            return new CreateBasicAuthRequestAuthType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateBasicAuthRequestAuthType value,
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
        public const string BasicAuth = "basic_auth";
    }
}
