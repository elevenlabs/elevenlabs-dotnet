using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>JWT signing algorithm</summary>
[JsonConverter(typeof(OAuth2JwtResponseAlgorithm.OAuth2JwtResponseAlgorithmSerializer))]
[Serializable]
public readonly record struct OAuth2JwtResponseAlgorithm : IStringEnum
{
    public static readonly OAuth2JwtResponseAlgorithm Hs256 = new(Values.Hs256);

    public static readonly OAuth2JwtResponseAlgorithm Hs384 = new(Values.Hs384);

    public static readonly OAuth2JwtResponseAlgorithm Hs512 = new(Values.Hs512);

    public static readonly OAuth2JwtResponseAlgorithm Rs256 = new(Values.Rs256);

    public static readonly OAuth2JwtResponseAlgorithm Rs384 = new(Values.Rs384);

    public static readonly OAuth2JwtResponseAlgorithm Rs512 = new(Values.Rs512);

    public static readonly OAuth2JwtResponseAlgorithm Ps256 = new(Values.Ps256);

    public static readonly OAuth2JwtResponseAlgorithm Ps384 = new(Values.Ps384);

    public static readonly OAuth2JwtResponseAlgorithm Ps512 = new(Values.Ps512);

    public OAuth2JwtResponseAlgorithm(string value)
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
    public static OAuth2JwtResponseAlgorithm FromCustom(string value)
    {
        return new OAuth2JwtResponseAlgorithm(value);
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

    public static bool operator ==(OAuth2JwtResponseAlgorithm value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OAuth2JwtResponseAlgorithm value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OAuth2JwtResponseAlgorithm value) => value.Value;

    public static explicit operator OAuth2JwtResponseAlgorithm(string value) => new(value);

    internal class OAuth2JwtResponseAlgorithmSerializer : JsonConverter<OAuth2JwtResponseAlgorithm>
    {
        public override OAuth2JwtResponseAlgorithm Read(
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
            return new OAuth2JwtResponseAlgorithm(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            OAuth2JwtResponseAlgorithm value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override OAuth2JwtResponseAlgorithm ReadAsPropertyName(
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
            return new OAuth2JwtResponseAlgorithm(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            OAuth2JwtResponseAlgorithm value,
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
        public const string Hs256 = "HS256";

        public const string Hs384 = "HS384";

        public const string Hs512 = "HS512";

        public const string Rs256 = "RS256";

        public const string Rs384 = "RS384";

        public const string Rs512 = "RS512";

        public const string Ps256 = "PS256";

        public const string Ps384 = "PS384";

        public const string Ps512 = "PS512";
    }
}
