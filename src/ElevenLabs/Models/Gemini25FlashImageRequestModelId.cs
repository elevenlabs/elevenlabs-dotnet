using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The model to use for the generation.</summary>
[JsonConverter(typeof(Gemini25FlashImageRequestModelId.Gemini25FlashImageRequestModelIdSerializer))]
[Serializable]
public readonly record struct Gemini25FlashImageRequestModelId : IStringEnum
{
    public static readonly Gemini25FlashImageRequestModelId Gemini25FlashImage = new(
        Values.Gemini25FlashImage
    );

    public Gemini25FlashImageRequestModelId(string value)
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
    public static Gemini25FlashImageRequestModelId FromCustom(string value)
    {
        return new Gemini25FlashImageRequestModelId(value);
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

    public static bool operator ==(Gemini25FlashImageRequestModelId value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(Gemini25FlashImageRequestModelId value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(Gemini25FlashImageRequestModelId value) => value.Value;

    public static explicit operator Gemini25FlashImageRequestModelId(string value) => new(value);

    internal class Gemini25FlashImageRequestModelIdSerializer
        : JsonConverter<Gemini25FlashImageRequestModelId>
    {
        public override Gemini25FlashImageRequestModelId Read(
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
            return new Gemini25FlashImageRequestModelId(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            Gemini25FlashImageRequestModelId value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override Gemini25FlashImageRequestModelId ReadAsPropertyName(
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
            return new Gemini25FlashImageRequestModelId(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            Gemini25FlashImageRequestModelId value,
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
        public const string Gemini25FlashImage = "gemini-2.5-flash-image";
    }
}
