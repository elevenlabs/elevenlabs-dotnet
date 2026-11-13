using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Token field to extract from the token endpoint response.</summary>
[JsonConverter(
    typeof(CreateOAuth2JwtRequestTokenResponseField.CreateOAuth2JwtRequestTokenResponseFieldSerializer)
)]
[Serializable]
public readonly record struct CreateOAuth2JwtRequestTokenResponseField : IStringEnum
{
    public static readonly CreateOAuth2JwtRequestTokenResponseField AccessToken = new(
        Values.AccessToken
    );

    public static readonly CreateOAuth2JwtRequestTokenResponseField IdToken = new(Values.IdToken);

    public CreateOAuth2JwtRequestTokenResponseField(string value)
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
    public static CreateOAuth2JwtRequestTokenResponseField FromCustom(string value)
    {
        return new CreateOAuth2JwtRequestTokenResponseField(value);
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
        CreateOAuth2JwtRequestTokenResponseField value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateOAuth2JwtRequestTokenResponseField value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CreateOAuth2JwtRequestTokenResponseField value) =>
        value.Value;

    public static explicit operator CreateOAuth2JwtRequestTokenResponseField(string value) =>
        new(value);

    internal class CreateOAuth2JwtRequestTokenResponseFieldSerializer
        : JsonConverter<CreateOAuth2JwtRequestTokenResponseField>
    {
        public override CreateOAuth2JwtRequestTokenResponseField Read(
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
            return new CreateOAuth2JwtRequestTokenResponseField(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateOAuth2JwtRequestTokenResponseField value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateOAuth2JwtRequestTokenResponseField ReadAsPropertyName(
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
            return new CreateOAuth2JwtRequestTokenResponseField(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateOAuth2JwtRequestTokenResponseField value,
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
