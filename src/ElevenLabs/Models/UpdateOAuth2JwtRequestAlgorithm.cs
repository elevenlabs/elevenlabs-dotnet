using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(UpdateOAuth2JwtRequestAlgorithm.UpdateOAuth2JwtRequestAlgorithmSerializer))]
[Serializable]
public readonly record struct UpdateOAuth2JwtRequestAlgorithm : IStringEnum
{
    public static readonly UpdateOAuth2JwtRequestAlgorithm Hs256 = new(Values.Hs256);

    public static readonly UpdateOAuth2JwtRequestAlgorithm Hs384 = new(Values.Hs384);

    public static readonly UpdateOAuth2JwtRequestAlgorithm Hs512 = new(Values.Hs512);

    public static readonly UpdateOAuth2JwtRequestAlgorithm Rs256 = new(Values.Rs256);

    public static readonly UpdateOAuth2JwtRequestAlgorithm Rs384 = new(Values.Rs384);

    public static readonly UpdateOAuth2JwtRequestAlgorithm Rs512 = new(Values.Rs512);

    public static readonly UpdateOAuth2JwtRequestAlgorithm Ps256 = new(Values.Ps256);

    public static readonly UpdateOAuth2JwtRequestAlgorithm Ps384 = new(Values.Ps384);

    public static readonly UpdateOAuth2JwtRequestAlgorithm Ps512 = new(Values.Ps512);

    public UpdateOAuth2JwtRequestAlgorithm(string value)
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
    public static UpdateOAuth2JwtRequestAlgorithm FromCustom(string value)
    {
        return new UpdateOAuth2JwtRequestAlgorithm(value);
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

    public static bool operator ==(UpdateOAuth2JwtRequestAlgorithm value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UpdateOAuth2JwtRequestAlgorithm value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UpdateOAuth2JwtRequestAlgorithm value) => value.Value;

    public static explicit operator UpdateOAuth2JwtRequestAlgorithm(string value) => new(value);

    internal class UpdateOAuth2JwtRequestAlgorithmSerializer
        : JsonConverter<UpdateOAuth2JwtRequestAlgorithm>
    {
        public override UpdateOAuth2JwtRequestAlgorithm Read(
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
            return new UpdateOAuth2JwtRequestAlgorithm(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateOAuth2JwtRequestAlgorithm value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdateOAuth2JwtRequestAlgorithm ReadAsPropertyName(
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
            return new UpdateOAuth2JwtRequestAlgorithm(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateOAuth2JwtRequestAlgorithm value,
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
