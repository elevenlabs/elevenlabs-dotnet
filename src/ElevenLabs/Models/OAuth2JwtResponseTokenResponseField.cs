using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Token field to extract from the token endpoint response.</summary>
[JsonConverter(
    typeof(OAuth2JwtResponseTokenResponseField.OAuth2JwtResponseTokenResponseFieldSerializer)
)]
[Serializable]
public readonly record struct OAuth2JwtResponseTokenResponseField : IStringEnum
{
    public static readonly OAuth2JwtResponseTokenResponseField AccessToken = new(
        Values.AccessToken
    );

    public static readonly OAuth2JwtResponseTokenResponseField IdToken = new(Values.IdToken);

    public OAuth2JwtResponseTokenResponseField(string value)
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
    public static OAuth2JwtResponseTokenResponseField FromCustom(string value)
    {
        return new OAuth2JwtResponseTokenResponseField(value);
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

    public static bool operator ==(OAuth2JwtResponseTokenResponseField value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OAuth2JwtResponseTokenResponseField value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OAuth2JwtResponseTokenResponseField value) =>
        value.Value;

    public static explicit operator OAuth2JwtResponseTokenResponseField(string value) => new(value);

    internal class OAuth2JwtResponseTokenResponseFieldSerializer
        : JsonConverter<OAuth2JwtResponseTokenResponseField>
    {
        public override OAuth2JwtResponseTokenResponseField Read(
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
            return new OAuth2JwtResponseTokenResponseField(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            OAuth2JwtResponseTokenResponseField value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override OAuth2JwtResponseTokenResponseField ReadAsPropertyName(
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
            return new OAuth2JwtResponseTokenResponseField(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            OAuth2JwtResponseTokenResponseField value,
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
        public const string AccessToken = "access_token";

        public const string IdToken = "id_token";
    }
}
