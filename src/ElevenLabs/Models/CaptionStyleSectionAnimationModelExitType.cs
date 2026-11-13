using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(CaptionStyleSectionAnimationModelExitType.CaptionStyleSectionAnimationModelExitTypeSerializer)
)]
[Serializable]
public readonly record struct CaptionStyleSectionAnimationModelExitType : IStringEnum
{
    public static readonly CaptionStyleSectionAnimationModelExitType None = new(Values.None);

    public static readonly CaptionStyleSectionAnimationModelExitType Fade = new(Values.Fade);

    public static readonly CaptionStyleSectionAnimationModelExitType Scale = new(Values.Scale);

    public static readonly CaptionStyleSectionAnimationModelExitType Pop = new(Values.Pop);

    public static readonly CaptionStyleSectionAnimationModelExitType SlideUp = new(Values.SlideUp);

    public static readonly CaptionStyleSectionAnimationModelExitType SlideDown = new(
        Values.SlideDown
    );

    public static readonly CaptionStyleSectionAnimationModelExitType Slam = new(Values.Slam);

    public static readonly CaptionStyleSectionAnimationModelExitType ScaleDown = new(
        Values.ScaleDown
    );

    public static readonly CaptionStyleSectionAnimationModelExitType SlideIn = new(Values.SlideIn);

    public CaptionStyleSectionAnimationModelExitType(string value)
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
    public static CaptionStyleSectionAnimationModelExitType FromCustom(string value)
    {
        return new CaptionStyleSectionAnimationModelExitType(value);
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
        CaptionStyleSectionAnimationModelExitType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CaptionStyleSectionAnimationModelExitType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CaptionStyleSectionAnimationModelExitType value) =>
        value.Value;

    public static explicit operator CaptionStyleSectionAnimationModelExitType(string value) =>
        new(value);

    internal class CaptionStyleSectionAnimationModelExitTypeSerializer
        : JsonConverter<CaptionStyleSectionAnimationModelExitType>
    {
        public override CaptionStyleSectionAnimationModelExitType Read(
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
            return new CaptionStyleSectionAnimationModelExitType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CaptionStyleSectionAnimationModelExitType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CaptionStyleSectionAnimationModelExitType ReadAsPropertyName(
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
            return new CaptionStyleSectionAnimationModelExitType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CaptionStyleSectionAnimationModelExitType value,
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

        public const string Scale = "scale";

        public const string Pop = "pop";

        public const string SlideUp = "slide_up";

        public const string SlideDown = "slide_down";

        public const string Slam = "slam";

        public const string ScaleDown = "scale_down";

        public const string SlideIn = "slide_in";
    }
}
