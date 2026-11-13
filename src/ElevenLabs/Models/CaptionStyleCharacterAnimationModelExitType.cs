using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(CaptionStyleCharacterAnimationModelExitType.CaptionStyleCharacterAnimationModelExitTypeSerializer)
)]
[Serializable]
public readonly record struct CaptionStyleCharacterAnimationModelExitType : IStringEnum
{
    public static readonly CaptionStyleCharacterAnimationModelExitType None = new(Values.None);

    public static readonly CaptionStyleCharacterAnimationModelExitType Fade = new(Values.Fade);

    public CaptionStyleCharacterAnimationModelExitType(string value)
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
    public static CaptionStyleCharacterAnimationModelExitType FromCustom(string value)
    {
        return new CaptionStyleCharacterAnimationModelExitType(value);
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
        CaptionStyleCharacterAnimationModelExitType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CaptionStyleCharacterAnimationModelExitType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CaptionStyleCharacterAnimationModelExitType value) =>
        value.Value;

    public static explicit operator CaptionStyleCharacterAnimationModelExitType(string value) =>
        new(value);

    internal class CaptionStyleCharacterAnimationModelExitTypeSerializer
        : JsonConverter<CaptionStyleCharacterAnimationModelExitType>
    {
        public override CaptionStyleCharacterAnimationModelExitType Read(
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
            return new CaptionStyleCharacterAnimationModelExitType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CaptionStyleCharacterAnimationModelExitType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CaptionStyleCharacterAnimationModelExitType ReadAsPropertyName(
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
            return new CaptionStyleCharacterAnimationModelExitType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CaptionStyleCharacterAnimationModelExitType value,
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
        public const string None = "none";

        public const string Fade = "fade";
    }
}
