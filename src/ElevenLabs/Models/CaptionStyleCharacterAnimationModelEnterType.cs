using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(CaptionStyleCharacterAnimationModelEnterType.CaptionStyleCharacterAnimationModelEnterTypeSerializer)
)]
[Serializable]
public readonly record struct CaptionStyleCharacterAnimationModelEnterType : IStringEnum
{
    public static readonly CaptionStyleCharacterAnimationModelEnterType None = new(Values.None);

    public static readonly CaptionStyleCharacterAnimationModelEnterType Fade = new(Values.Fade);

    public static readonly CaptionStyleCharacterAnimationModelEnterType Typewriter = new(
        Values.Typewriter
    );

    public CaptionStyleCharacterAnimationModelEnterType(string value)
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
    public static CaptionStyleCharacterAnimationModelEnterType FromCustom(string value)
    {
        return new CaptionStyleCharacterAnimationModelEnterType(value);
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
        CaptionStyleCharacterAnimationModelEnterType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CaptionStyleCharacterAnimationModelEnterType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CaptionStyleCharacterAnimationModelEnterType value) =>
        value.Value;

    public static explicit operator CaptionStyleCharacterAnimationModelEnterType(string value) =>
        new(value);

    internal class CaptionStyleCharacterAnimationModelEnterTypeSerializer
        : JsonConverter<CaptionStyleCharacterAnimationModelEnterType>
    {
        public override CaptionStyleCharacterAnimationModelEnterType Read(
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
            return new CaptionStyleCharacterAnimationModelEnterType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CaptionStyleCharacterAnimationModelEnterType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CaptionStyleCharacterAnimationModelEnterType ReadAsPropertyName(
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
            return new CaptionStyleCharacterAnimationModelEnterType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CaptionStyleCharacterAnimationModelEnterType value,
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

        public const string Typewriter = "typewriter";
    }
}
