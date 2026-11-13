using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>
/// Single status field shared by every auth type's stored credential.
///
/// OAuth values (``REFRESH_FAILED``, ``REVOKED``) are written by the OAuth
/// token-manager refresh path. ``CREDENTIAL_INVALID`` is written by the
/// tool execution path when an upstream response matches a credential's
/// ``failure_signatures`` entry (Bearer, Basic auth, etc.).
/// </summary>
[JsonConverter(typeof(AuthConnectionStatus.AuthConnectionStatusSerializer))]
[Serializable]
public readonly record struct AuthConnectionStatus : IStringEnum
{
    public static readonly AuthConnectionStatus Active = new(Values.Active);

    public static readonly AuthConnectionStatus RefreshFailed = new(Values.RefreshFailed);

    public static readonly AuthConnectionStatus Revoked = new(Values.Revoked);

    public static readonly AuthConnectionStatus CredentialInvalid = new(Values.CredentialInvalid);

    public AuthConnectionStatus(string value)
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
    public static AuthConnectionStatus FromCustom(string value)
    {
        return new AuthConnectionStatus(value);
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

    public static bool operator ==(AuthConnectionStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AuthConnectionStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AuthConnectionStatus value) => value.Value;

    public static explicit operator AuthConnectionStatus(string value) => new(value);

    internal class AuthConnectionStatusSerializer : JsonConverter<AuthConnectionStatus>
    {
        public override AuthConnectionStatus Read(
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
            return new AuthConnectionStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AuthConnectionStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AuthConnectionStatus ReadAsPropertyName(
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
            return new AuthConnectionStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AuthConnectionStatus value,
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
        public const string Active = "active";

        public const string RefreshFailed = "refresh_failed";

        public const string Revoked = "revoked";

        public const string CredentialInvalid = "credential_invalid";
    }
}
