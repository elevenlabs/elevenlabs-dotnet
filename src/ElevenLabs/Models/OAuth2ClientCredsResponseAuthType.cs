using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(OAuth2ClientCredsResponseAuthType.OAuth2ClientCredsResponseAuthTypeSerializer)
)]
[Serializable]
public readonly record struct OAuth2ClientCredsResponseAuthType : IStringEnum
{
    public static readonly OAuth2ClientCredsResponseAuthType Oauth2ClientCredentials = new(
        Values.Oauth2ClientCredentials
    );

    public OAuth2ClientCredsResponseAuthType(string value)
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
    public static OAuth2ClientCredsResponseAuthType FromCustom(string value)
    {
        return new OAuth2ClientCredsResponseAuthType(value);
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

    public static bool operator ==(OAuth2ClientCredsResponseAuthType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OAuth2ClientCredsResponseAuthType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OAuth2ClientCredsResponseAuthType value) => value.Value;

    public static explicit operator OAuth2ClientCredsResponseAuthType(string value) => new(value);

    internal class OAuth2ClientCredsResponseAuthTypeSerializer
        : JsonConverter<OAuth2ClientCredsResponseAuthType>
    {
        public override OAuth2ClientCredsResponseAuthType Read(
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
            return new OAuth2ClientCredsResponseAuthType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            OAuth2ClientCredsResponseAuthType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override OAuth2ClientCredsResponseAuthType ReadAsPropertyName(
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
            return new OAuth2ClientCredsResponseAuthType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            OAuth2ClientCredsResponseAuthType value,
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
        public const string Oauth2ClientCredentials = "oauth2_client_credentials";
    }
}
