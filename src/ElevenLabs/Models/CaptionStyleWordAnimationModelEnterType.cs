using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(CaptionStyleWordAnimationModelEnterType.CaptionStyleWordAnimationModelEnterTypeSerializer)
)]
[Serializable]
public readonly record struct CaptionStyleWordAnimationModelEnterType : IStringEnum
{
    public static readonly CaptionStyleWordAnimationModelEnterType None = new(Values.None);

    public static readonly CaptionStyleWordAnimationModelEnterType Fade = new(Values.Fade);

    public static readonly CaptionStyleWordAnimationModelEnterType Scale = new(Values.Scale);

    public static readonly CaptionStyleWordAnimationModelEnterType Pop = new(Values.Pop);

    public static readonly CaptionStyleWordAnimationModelEnterType SlideUp = new(Values.SlideUp);

    public static readonly CaptionStyleWordAnimationModelEnterType SlideDown = new(
        Values.SlideDown
    );

    public static readonly CaptionStyleWordAnimationModelEnterType Slam = new(Values.Slam);

    public static readonly CaptionStyleWordAnimationModelEnterType ScaleDown = new(
        Values.ScaleDown
    );

    public static readonly CaptionStyleWordAnimationModelEnterType SlideIn = new(Values.SlideIn);

    public CaptionStyleWordAnimationModelEnterType(string value)
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
    public static CaptionStyleWordAnimationModelEnterType FromCustom(string value)
    {
        return new CaptionStyleWordAnimationModelEnterType(value);
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

    public static bool operator ==(CaptionStyleWordAnimationModelEnterType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CaptionStyleWordAnimationModelEnterType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CaptionStyleWordAnimationModelEnterType value) =>
        value.Value;

    public static explicit operator CaptionStyleWordAnimationModelEnterType(string value) =>
        new(value);

    internal class CaptionStyleWordAnimationModelEnterTypeSerializer
        : JsonConverter<CaptionStyleWordAnimationModelEnterType>
    {
        public override CaptionStyleWordAnimationModelEnterType Read(
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
            return new CaptionStyleWordAnimationModelEnterType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CaptionStyleWordAnimationModelEnterType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CaptionStyleWordAnimationModelEnterType ReadAsPropertyName(
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
            return new CaptionStyleWordAnimationModelEnterType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CaptionStyleWordAnimationModelEnterType value,
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
