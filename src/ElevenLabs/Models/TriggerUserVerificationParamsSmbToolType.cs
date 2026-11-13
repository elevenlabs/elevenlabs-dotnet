using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(TriggerUserVerificationParamsSmbToolType.TriggerUserVerificationParamsSmbToolTypeSerializer)
)]
[Serializable]
public readonly record struct TriggerUserVerificationParamsSmbToolType : IStringEnum
{
    public static readonly TriggerUserVerificationParamsSmbToolType TriggerUserVerification = new(
        Values.TriggerUserVerification
    );

    public TriggerUserVerificationParamsSmbToolType(string value)
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
    public static TriggerUserVerificationParamsSmbToolType FromCustom(string value)
    {
        return new TriggerUserVerificationParamsSmbToolType(value);
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
        TriggerUserVerificationParamsSmbToolType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        TriggerUserVerificationParamsSmbToolType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(TriggerUserVerificationParamsSmbToolType value) =>
        value.Value;

    public static explicit operator TriggerUserVerificationParamsSmbToolType(string value) =>
        new(value);

    internal class TriggerUserVerificationParamsSmbToolTypeSerializer
        : JsonConverter<TriggerUserVerificationParamsSmbToolType>
    {
        public override TriggerUserVerificationParamsSmbToolType Read(
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
            return new TriggerUserVerificationParamsSmbToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TriggerUserVerificationParamsSmbToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TriggerUserVerificationParamsSmbToolType ReadAsPropertyName(
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
            return new TriggerUserVerificationParamsSmbToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TriggerUserVerificationParamsSmbToolType value,
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
        public const string TriggerUserVerification = "trigger_user_verification";
    }
}
