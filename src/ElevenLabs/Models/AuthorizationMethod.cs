using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AuthorizationMethod.AuthorizationMethodSerializer))]
[Serializable]
public readonly record struct AuthorizationMethod : IStringEnum
{
    public static readonly AuthorizationMethod Invalid = new(Values.Invalid);

    public static readonly AuthorizationMethod Public = new(Values.Public);

    public static readonly AuthorizationMethod AuthorizationHeader = new(
        Values.AuthorizationHeader
    );

    public static readonly AuthorizationMethod SignedUrl = new(Values.SignedUrl);

    public static readonly AuthorizationMethod ShareableLink = new(Values.ShareableLink);

    public static readonly AuthorizationMethod LivekitToken = new(Values.LivekitToken);

    public static readonly AuthorizationMethod LivekitTokenWebsite = new(
        Values.LivekitTokenWebsite
    );

    public static readonly AuthorizationMethod GenesysApiKey = new(Values.GenesysApiKey);

    public static readonly AuthorizationMethod AvayaApiKey = new(Values.AvayaApiKey);

    public static readonly AuthorizationMethod AudiocodesApiKey = new(Values.AudiocodesApiKey);

    public static readonly AuthorizationMethod Whatsapp = new(Values.Whatsapp);

    public static readonly AuthorizationMethod Sms = new(Values.Sms);

    public AuthorizationMethod(string value)
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
    public static AuthorizationMethod FromCustom(string value)
    {
        return new AuthorizationMethod(value);
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

    public static bool operator ==(AuthorizationMethod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AuthorizationMethod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AuthorizationMethod value) => value.Value;

    public static explicit operator AuthorizationMethod(string value) => new(value);

    internal class AuthorizationMethodSerializer : JsonConverter<AuthorizationMethod>
    {
        public override AuthorizationMethod Read(
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
            return new AuthorizationMethod(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AuthorizationMethod value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AuthorizationMethod ReadAsPropertyName(
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
            return new AuthorizationMethod(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AuthorizationMethod value,
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
        public const string Invalid = "invalid";

        public const string Public = "public";

        public const string AuthorizationHeader = "authorization_header";

        public const string SignedUrl = "signed_url";

        public const string ShareableLink = "shareable_link";

        public const string LivekitToken = "livekit_token";

        public const string LivekitTokenWebsite = "livekit_token_website";

        public const string GenesysApiKey = "genesys_api_key";

        public const string AvayaApiKey = "avaya_api_key";

        public const string AudiocodesApiKey = "audiocodes_api_key";

        public const string Whatsapp = "whatsapp";

        public const string Sms = "sms";
    }
}
