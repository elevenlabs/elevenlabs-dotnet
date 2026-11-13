using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>How the JWT is used at the token endpoint. 'authorization_grant' sends it as a jwt-bearer grant. 'client_authentication' sends it as a client_assertion on a client_credentials request, with the subject as client_id and scopes in the request body.</summary>
[JsonConverter(typeof(OAuth2JwtResponseJwtUsage.OAuth2JwtResponseJwtUsageSerializer))]
[Serializable]
public readonly record struct OAuth2JwtResponseJwtUsage : IStringEnum
{
    public static readonly OAuth2JwtResponseJwtUsage AuthorizationGrant = new(
        Values.AuthorizationGrant
    );

    public static readonly OAuth2JwtResponseJwtUsage ClientAuthentication = new(
        Values.ClientAuthentication
    );

    public OAuth2JwtResponseJwtUsage(string value)
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
    public static OAuth2JwtResponseJwtUsage FromCustom(string value)
    {
        return new OAuth2JwtResponseJwtUsage(value);
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

    public static bool operator ==(OAuth2JwtResponseJwtUsage value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OAuth2JwtResponseJwtUsage value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OAuth2JwtResponseJwtUsage value) => value.Value;

    public static explicit operator OAuth2JwtResponseJwtUsage(string value) => new(value);

    internal class OAuth2JwtResponseJwtUsageSerializer : JsonConverter<OAuth2JwtResponseJwtUsage>
    {
        public override OAuth2JwtResponseJwtUsage Read(
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
            return new OAuth2JwtResponseJwtUsage(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            OAuth2JwtResponseJwtUsage value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override OAuth2JwtResponseJwtUsage ReadAsPropertyName(
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
            return new OAuth2JwtResponseJwtUsage(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            OAuth2JwtResponseJwtUsage value,
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
        public const string AuthorizationGrant = "authorization_grant";

        public const string ClientAuthentication = "client_authentication";
    }
}
