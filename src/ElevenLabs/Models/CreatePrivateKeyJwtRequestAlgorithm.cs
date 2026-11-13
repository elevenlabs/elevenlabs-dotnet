using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>JWT signing algorithm</summary>
[JsonConverter(
    typeof(CreatePrivateKeyJwtRequestAlgorithm.CreatePrivateKeyJwtRequestAlgorithmSerializer)
)]
[Serializable]
public readonly record struct CreatePrivateKeyJwtRequestAlgorithm : IStringEnum
{
    public static readonly CreatePrivateKeyJwtRequestAlgorithm Hs256 = new(Values.Hs256);

    public static readonly CreatePrivateKeyJwtRequestAlgorithm Hs384 = new(Values.Hs384);

    public static readonly CreatePrivateKeyJwtRequestAlgorithm Hs512 = new(Values.Hs512);

    public static readonly CreatePrivateKeyJwtRequestAlgorithm Rs256 = new(Values.Rs256);

    public static readonly CreatePrivateKeyJwtRequestAlgorithm Rs384 = new(Values.Rs384);

    public static readonly CreatePrivateKeyJwtRequestAlgorithm Rs512 = new(Values.Rs512);

    public static readonly CreatePrivateKeyJwtRequestAlgorithm Ps256 = new(Values.Ps256);

    public static readonly CreatePrivateKeyJwtRequestAlgorithm Ps384 = new(Values.Ps384);

    public static readonly CreatePrivateKeyJwtRequestAlgorithm Ps512 = new(Values.Ps512);

    public CreatePrivateKeyJwtRequestAlgorithm(string value)
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
    public static CreatePrivateKeyJwtRequestAlgorithm FromCustom(string value)
    {
        return new CreatePrivateKeyJwtRequestAlgorithm(value);
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

    public static bool operator ==(CreatePrivateKeyJwtRequestAlgorithm value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreatePrivateKeyJwtRequestAlgorithm value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreatePrivateKeyJwtRequestAlgorithm value) =>
        value.Value;

    public static explicit operator CreatePrivateKeyJwtRequestAlgorithm(string value) => new(value);

    internal class CreatePrivateKeyJwtRequestAlgorithmSerializer
        : JsonConverter<CreatePrivateKeyJwtRequestAlgorithm>
    {
        public override CreatePrivateKeyJwtRequestAlgorithm Read(
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
            return new CreatePrivateKeyJwtRequestAlgorithm(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreatePrivateKeyJwtRequestAlgorithm value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreatePrivateKeyJwtRequestAlgorithm ReadAsPropertyName(
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
            return new CreatePrivateKeyJwtRequestAlgorithm(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreatePrivateKeyJwtRequestAlgorithm value,
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
