using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The model to use for the generation.</summary>
[JsonConverter(typeof(Gemini31FlashImageRequestModelId.Gemini31FlashImageRequestModelIdSerializer))]
[Serializable]
public readonly record struct Gemini31FlashImageRequestModelId : IStringEnum
{
    public static readonly Gemini31FlashImageRequestModelId Gemini31FlashImage = new(
        Values.Gemini31FlashImage
    );

    public Gemini31FlashImageRequestModelId(string value)
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
    public static Gemini31FlashImageRequestModelId FromCustom(string value)
    {
        return new Gemini31FlashImageRequestModelId(value);
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

    public static bool operator ==(Gemini31FlashImageRequestModelId value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(Gemini31FlashImageRequestModelId value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(Gemini31FlashImageRequestModelId value) => value.Value;

    public static explicit operator Gemini31FlashImageRequestModelId(string value) => new(value);

    internal class Gemini31FlashImageRequestModelIdSerializer
        : JsonConverter<Gemini31FlashImageRequestModelId>
    {
        public override Gemini31FlashImageRequestModelId Read(
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
            return new Gemini31FlashImageRequestModelId(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            Gemini31FlashImageRequestModelId value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override Gemini31FlashImageRequestModelId ReadAsPropertyName(
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
            return new Gemini31FlashImageRequestModelId(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            Gemini31FlashImageRequestModelId value,
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
        public const string Gemini31FlashImage = "gemini-3.1-flash-image";
    }
}
