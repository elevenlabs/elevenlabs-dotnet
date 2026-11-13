using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(CreateOAuth2JwtRequestAuthType.CreateOAuth2JwtRequestAuthTypeSerializer))]
[Serializable]
public readonly record struct CreateOAuth2JwtRequestAuthType : IStringEnum
{
    public static readonly CreateOAuth2JwtRequestAuthType Oauth2Jwt = new(Values.Oauth2Jwt);

    public CreateOAuth2JwtRequestAuthType(string value)
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
    public static CreateOAuth2JwtRequestAuthType FromCustom(string value)
    {
        return new CreateOAuth2JwtRequestAuthType(value);
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

    public static bool operator ==(CreateOAuth2JwtRequestAuthType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateOAuth2JwtRequestAuthType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateOAuth2JwtRequestAuthType value) => value.Value;

    public static explicit operator CreateOAuth2JwtRequestAuthType(string value) => new(value);

    internal class CreateOAuth2JwtRequestAuthTypeSerializer
        : JsonConverter<CreateOAuth2JwtRequestAuthType>
    {
        public override CreateOAuth2JwtRequestAuthType Read(
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
            return new CreateOAuth2JwtRequestAuthType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateOAuth2JwtRequestAuthType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateOAuth2JwtRequestAuthType ReadAsPropertyName(
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
            return new CreateOAuth2JwtRequestAuthType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateOAuth2JwtRequestAuthType value,
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
        public const string Oauth2Jwt = "oauth2_jwt";
    }
}
