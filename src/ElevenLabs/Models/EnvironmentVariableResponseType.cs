using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(EnvironmentVariableResponseType.EnvironmentVariableResponseTypeSerializer))]
[Serializable]
public readonly record struct EnvironmentVariableResponseType : IStringEnum
{
    public static readonly EnvironmentVariableResponseType String = new(Values.String);

    public static readonly EnvironmentVariableResponseType Secret = new(Values.Secret);

    public static readonly EnvironmentVariableResponseType AuthConnection = new(
        Values.AuthConnection
    );

    public EnvironmentVariableResponseType(string value)
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
    public static EnvironmentVariableResponseType FromCustom(string value)
    {
        return new EnvironmentVariableResponseType(value);
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

    public static bool operator ==(EnvironmentVariableResponseType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(EnvironmentVariableResponseType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(EnvironmentVariableResponseType value) => value.Value;

    public static explicit operator EnvironmentVariableResponseType(string value) => new(value);

    internal class EnvironmentVariableResponseTypeSerializer
        : JsonConverter<EnvironmentVariableResponseType>
    {
        public override EnvironmentVariableResponseType Read(
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
            return new EnvironmentVariableResponseType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EnvironmentVariableResponseType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EnvironmentVariableResponseType ReadAsPropertyName(
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
            return new EnvironmentVariableResponseType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EnvironmentVariableResponseType value,
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
        public const string String = "string";

        public const string Secret = "secret";

        public const string AuthConnection = "auth_connection";
    }
}
