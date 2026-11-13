using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(CreateAuthConnectionEnvironmentVariableRequestType.CreateAuthConnectionEnvironmentVariableRequestTypeSerializer)
)]
[Serializable]
public readonly record struct CreateAuthConnectionEnvironmentVariableRequestType : IStringEnum
{
    public static readonly CreateAuthConnectionEnvironmentVariableRequestType AuthConnection = new(
        Values.AuthConnection
    );

    public CreateAuthConnectionEnvironmentVariableRequestType(string value)
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
    public static CreateAuthConnectionEnvironmentVariableRequestType FromCustom(string value)
    {
        return new CreateAuthConnectionEnvironmentVariableRequestType(value);
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

    public static bool operator ==(
        CreateAuthConnectionEnvironmentVariableRequestType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateAuthConnectionEnvironmentVariableRequestType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreateAuthConnectionEnvironmentVariableRequestType value
    ) => value.Value;

    public static explicit operator CreateAuthConnectionEnvironmentVariableRequestType(
        string value
    ) => new(value);

    internal class CreateAuthConnectionEnvironmentVariableRequestTypeSerializer
        : JsonConverter<CreateAuthConnectionEnvironmentVariableRequestType>
    {
        public override CreateAuthConnectionEnvironmentVariableRequestType Read(
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
            return new CreateAuthConnectionEnvironmentVariableRequestType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateAuthConnectionEnvironmentVariableRequestType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateAuthConnectionEnvironmentVariableRequestType ReadAsPropertyName(
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
            return new CreateAuthConnectionEnvironmentVariableRequestType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateAuthConnectionEnvironmentVariableRequestType value,
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
        public const string AuthConnection = "auth_connection";
    }
}
