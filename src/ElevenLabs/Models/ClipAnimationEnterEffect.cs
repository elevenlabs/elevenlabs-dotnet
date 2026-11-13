using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ClipAnimationEnterEffect.ClipAnimationEnterEffectSerializer))]
[Serializable]
public readonly record struct ClipAnimationEnterEffect : IStringEnum
{
    public static readonly ClipAnimationEnterEffect None = new(Values.None);

    public static readonly ClipAnimationEnterEffect Fade = new(Values.Fade);

    public static readonly ClipAnimationEnterEffect Float = new(Values.Float);

    public static readonly ClipAnimationEnterEffect GentleFloat = new(Values.GentleFloat);

    public static readonly ClipAnimationEnterEffect ZoomIn = new(Values.ZoomIn);

    public static readonly ClipAnimationEnterEffect Drop = new(Values.Drop);

    public static readonly ClipAnimationEnterEffect SlideLeft = new(Values.SlideLeft);

    public static readonly ClipAnimationEnterEffect SlideRight = new(Values.SlideRight);

    public static readonly ClipAnimationEnterEffect SlideUp = new(Values.SlideUp);

    public static readonly ClipAnimationEnterEffect SlideDown = new(Values.SlideDown);

    public static readonly ClipAnimationEnterEffect Pop = new(Values.Pop);

    public static readonly ClipAnimationEnterEffect Bounce = new(Values.Bounce);

    public static readonly ClipAnimationEnterEffect Spin = new(Values.Spin);

    public static readonly ClipAnimationEnterEffect SlideBounce = new(Values.SlideBounce);

    public ClipAnimationEnterEffect(string value)
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
    public static ClipAnimationEnterEffect FromCustom(string value)
    {
        return new ClipAnimationEnterEffect(value);
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

    public static bool operator ==(ClipAnimationEnterEffect value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ClipAnimationEnterEffect value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ClipAnimationEnterEffect value) => value.Value;

    public static explicit operator ClipAnimationEnterEffect(string value) => new(value);

    internal class ClipAnimationEnterEffectSerializer : JsonConverter<ClipAnimationEnterEffect>
    {
        public override ClipAnimationEnterEffect Read(
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
            return new ClipAnimationEnterEffect(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ClipAnimationEnterEffect value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ClipAnimationEnterEffect ReadAsPropertyName(
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
            return new ClipAnimationEnterEffect(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ClipAnimationEnterEffect value,
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

        public const string Float = "float";

        public const string GentleFloat = "gentle_float";

        public const string ZoomIn = "zoom_in";

        public const string Drop = "drop";

        public const string SlideLeft = "slide_left";

        public const string SlideRight = "slide_right";

        public const string SlideUp = "slide_up";

        public const string SlideDown = "slide_down";

        public const string Pop = "pop";

        public const string Bounce = "bounce";

        public const string Spin = "spin";

        public const string SlideBounce = "slide_bounce";
    }
}
