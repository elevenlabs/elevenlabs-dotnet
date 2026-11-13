using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(UpdateOAuth2JwtRequestJwtUsage.UpdateOAuth2JwtRequestJwtUsageSerializer))]
[Serializable]
public readonly record struct UpdateOAuth2JwtRequestJwtUsage : IStringEnum
{
    public static readonly UpdateOAuth2JwtRequestJwtUsage AuthorizationGrant = new(
        Values.AuthorizationGrant
    );

    public static readonly UpdateOAuth2JwtRequestJwtUsage ClientAuthentication = new(
        Values.ClientAuthentication
    );

    public UpdateOAuth2JwtRequestJwtUsage(string value)
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
    public static UpdateOAuth2JwtRequestJwtUsage FromCustom(string value)
    {
        return new UpdateOAuth2JwtRequestJwtUsage(value);
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

    public static bool operator ==(UpdateOAuth2JwtRequestJwtUsage value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UpdateOAuth2JwtRequestJwtUsage value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UpdateOAuth2JwtRequestJwtUsage value) => value.Value;

    public static explicit operator UpdateOAuth2JwtRequestJwtUsage(string value) => new(value);

    internal class UpdateOAuth2JwtRequestJwtUsageSerializer
        : JsonConverter<UpdateOAuth2JwtRequestJwtUsage>
    {
        public override UpdateOAuth2JwtRequestJwtUsage Read(
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
            return new UpdateOAuth2JwtRequestJwtUsage(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateOAuth2JwtRequestJwtUsage value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdateOAuth2JwtRequestJwtUsage ReadAsPropertyName(
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
            return new UpdateOAuth2JwtRequestJwtUsage(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateOAuth2JwtRequestJwtUsage value,
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
