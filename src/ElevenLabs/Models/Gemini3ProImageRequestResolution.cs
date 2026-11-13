using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The resolution of the output image.</summary>
[JsonConverter(typeof(Gemini3ProImageRequestResolution.Gemini3ProImageRequestResolutionSerializer))]
[Serializable]
public readonly record struct Gemini3ProImageRequestResolution : IStringEnum
{
    public static readonly Gemini3ProImageRequestResolution OneK = new(Values.OneK);

    public static readonly Gemini3ProImageRequestResolution TwoK = new(Values.TwoK);

    public static readonly Gemini3ProImageRequestResolution FourK = new(Values.FourK);

    public Gemini3ProImageRequestResolution(string value)
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
    public static Gemini3ProImageRequestResolution FromCustom(string value)
    {
        return new Gemini3ProImageRequestResolution(value);
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

    public static bool operator ==(Gemini3ProImageRequestResolution value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(Gemini3ProImageRequestResolution value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(Gemini3ProImageRequestResolution value) => value.Value;

    public static explicit operator Gemini3ProImageRequestResolution(string value) => new(value);

    internal class Gemini3ProImageRequestResolutionSerializer
        : JsonConverter<Gemini3ProImageRequestResolution>
    {
        public override Gemini3ProImageRequestResolution Read(
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
            return new Gemini3ProImageRequestResolution(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            Gemini3ProImageRequestResolution value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override Gemini3ProImageRequestResolution ReadAsPropertyName(
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
            return new Gemini3ProImageRequestResolution(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            Gemini3ProImageRequestResolution value,
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

        public const string TwoK = "2K";

        public const string FourK = "4K";
    }
}
