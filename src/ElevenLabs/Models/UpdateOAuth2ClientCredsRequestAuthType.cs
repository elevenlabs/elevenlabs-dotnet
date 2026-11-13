using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(UpdateOAuth2ClientCredsRequestAuthType.UpdateOAuth2ClientCredsRequestAuthTypeSerializer)
)]
[Serializable]
public readonly record struct UpdateOAuth2ClientCredsRequestAuthType : IStringEnum
{
    public static readonly UpdateOAuth2ClientCredsRequestAuthType Oauth2ClientCredentials = new(
        Values.Oauth2ClientCredentials
    );

    public UpdateOAuth2ClientCredsRequestAuthType(string value)
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
    public static UpdateOAuth2ClientCredsRequestAuthType FromCustom(string value)
    {
        return new UpdateOAuth2ClientCredsRequestAuthType(value);
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

    public static bool operator ==(UpdateOAuth2ClientCredsRequestAuthType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UpdateOAuth2ClientCredsRequestAuthType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UpdateOAuth2ClientCredsRequestAuthType value) =>
        value.Value;

    public static explicit operator UpdateOAuth2ClientCredsRequestAuthType(string value) =>
        new(value);

    internal class UpdateOAuth2ClientCredsRequestAuthTypeSerializer
        : JsonConverter<UpdateOAuth2ClientCredsRequestAuthType>
    {
        public override UpdateOAuth2ClientCredsRequestAuthType Read(
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
            return new UpdateOAuth2ClientCredsRequestAuthType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateOAuth2ClientCredsRequestAuthType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdateOAuth2ClientCredsRequestAuthType ReadAsPropertyName(
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
            return new UpdateOAuth2ClientCredsRequestAuthType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateOAuth2ClientCredsRequestAuthType value,
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
