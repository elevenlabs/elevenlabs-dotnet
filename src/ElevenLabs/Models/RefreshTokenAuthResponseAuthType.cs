using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(RefreshTokenAuthResponseAuthType.RefreshTokenAuthResponseAuthTypeSerializer))]
[Serializable]
public readonly record struct RefreshTokenAuthResponseAuthType : IStringEnum
{
    public static readonly RefreshTokenAuthResponseAuthType RefreshTokenAuth = new(
        Values.RefreshTokenAuth
    );

    public RefreshTokenAuthResponseAuthType(string value)
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
    public static RefreshTokenAuthResponseAuthType FromCustom(string value)
    {
        return new RefreshTokenAuthResponseAuthType(value);
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

    public static bool operator ==(RefreshTokenAuthResponseAuthType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(RefreshTokenAuthResponseAuthType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(RefreshTokenAuthResponseAuthType value) => value.Value;

    public static explicit operator RefreshTokenAuthResponseAuthType(string value) => new(value);

    internal class RefreshTokenAuthResponseAuthTypeSerializer
        : JsonConverter<RefreshTokenAuthResponseAuthType>
    {
        public override RefreshTokenAuthResponseAuthType Read(
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
            return new RefreshTokenAuthResponseAuthType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RefreshTokenAuthResponseAuthType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RefreshTokenAuthResponseAuthType ReadAsPropertyName(
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
            return new RefreshTokenAuthResponseAuthType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RefreshTokenAuthResponseAuthType value,
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
        public const string RefreshTokenAuth = "refresh_token_auth";
    }
}
