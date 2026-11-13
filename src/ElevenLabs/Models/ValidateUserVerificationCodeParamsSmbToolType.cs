using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ValidateUserVerificationCodeParamsSmbToolType.ValidateUserVerificationCodeParamsSmbToolTypeSerializer)
)]
[Serializable]
public readonly record struct ValidateUserVerificationCodeParamsSmbToolType : IStringEnum
{
    public static readonly ValidateUserVerificationCodeParamsSmbToolType ValidateUserVerificationCode =
        new(Values.ValidateUserVerificationCode);

    public ValidateUserVerificationCodeParamsSmbToolType(string value)
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
    public static ValidateUserVerificationCodeParamsSmbToolType FromCustom(string value)
    {
        return new ValidateUserVerificationCodeParamsSmbToolType(value);
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
        ValidateUserVerificationCodeParamsSmbToolType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ValidateUserVerificationCodeParamsSmbToolType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ValidateUserVerificationCodeParamsSmbToolType value) =>
        value.Value;

    public static explicit operator ValidateUserVerificationCodeParamsSmbToolType(string value) =>
        new(value);

    internal class ValidateUserVerificationCodeParamsSmbToolTypeSerializer
        : JsonConverter<ValidateUserVerificationCodeParamsSmbToolType>
    {
        public override ValidateUserVerificationCodeParamsSmbToolType Read(
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
            return new ValidateUserVerificationCodeParamsSmbToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ValidateUserVerificationCodeParamsSmbToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ValidateUserVerificationCodeParamsSmbToolType ReadAsPropertyName(
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
            return new ValidateUserVerificationCodeParamsSmbToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ValidateUserVerificationCodeParamsSmbToolType value,
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
        public const string ValidateUserVerificationCode = "validate_user_verification_code";
    }
}
