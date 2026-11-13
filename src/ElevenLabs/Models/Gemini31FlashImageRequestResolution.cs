using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The resolution of the output image.</summary>
[JsonConverter(
    typeof(Gemini31FlashImageRequestResolution.Gemini31FlashImageRequestResolutionSerializer)
)]
[Serializable]
public readonly record struct Gemini31FlashImageRequestResolution : IStringEnum
{
    public static readonly Gemini31FlashImageRequestResolution FiveHundredTwelve = new(
        Values.FiveHundredTwelve
    );

    public static readonly Gemini31FlashImageRequestResolution OneK = new(Values.OneK);

    public static readonly Gemini31FlashImageRequestResolution TwoK = new(Values.TwoK);

    public static readonly Gemini31FlashImageRequestResolution FourK = new(Values.FourK);

    public Gemini31FlashImageRequestResolution(string value)
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
    public static Gemini31FlashImageRequestResolution FromCustom(string value)
    {
        return new Gemini31FlashImageRequestResolution(value);
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

    public static bool operator ==(Gemini31FlashImageRequestResolution value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(Gemini31FlashImageRequestResolution value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(Gemini31FlashImageRequestResolution value) =>
        value.Value;

    public static explicit operator Gemini31FlashImageRequestResolution(string value) => new(value);

    internal class Gemini31FlashImageRequestResolutionSerializer
        : JsonConverter<Gemini31FlashImageRequestResolution>
    {
        public override Gemini31FlashImageRequestResolution Read(
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
            return new Gemini31FlashImageRequestResolution(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            Gemini31FlashImageRequestResolution value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override Gemini31FlashImageRequestResolution ReadAsPropertyName(
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
            return new Gemini31FlashImageRequestResolution(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            Gemini31FlashImageRequestResolution value,
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
        public const string FiveHundredTwelve = "512";

        public const string OneK = "1K";

        public const string TwoK = "2K";

        public const string FourK = "4K";
    }
}
