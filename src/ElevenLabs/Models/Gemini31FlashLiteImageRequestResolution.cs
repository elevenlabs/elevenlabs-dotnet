using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The resolution of the output image.</summary>
[JsonConverter(
    typeof(Gemini31FlashLiteImageRequestResolution.Gemini31FlashLiteImageRequestResolutionSerializer)
)]
[Serializable]
public readonly record struct Gemini31FlashLiteImageRequestResolution : IStringEnum
{
    public static readonly Gemini31FlashLiteImageRequestResolution OneK = new(Values.OneK);

    public Gemini31FlashLiteImageRequestResolution(string value)
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
    public static Gemini31FlashLiteImageRequestResolution FromCustom(string value)
    {
        return new Gemini31FlashLiteImageRequestResolution(value);
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

    public static bool operator ==(Gemini31FlashLiteImageRequestResolution value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(Gemini31FlashLiteImageRequestResolution value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(Gemini31FlashLiteImageRequestResolution value) =>
        value.Value;

    public static explicit operator Gemini31FlashLiteImageRequestResolution(string value) =>
        new(value);

    internal class Gemini31FlashLiteImageRequestResolutionSerializer
        : JsonConverter<Gemini31FlashLiteImageRequestResolution>
    {
        public override Gemini31FlashLiteImageRequestResolution Read(
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
            return new Gemini31FlashLiteImageRequestResolution(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            Gemini31FlashLiteImageRequestResolution value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override Gemini31FlashLiteImageRequestResolution ReadAsPropertyName(
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
            return new Gemini31FlashLiteImageRequestResolution(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            Gemini31FlashLiteImageRequestResolution value,
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
        public const string OneK = "1K";
    }
}
