using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The model to use for the generation.</summary>
[JsonConverter(typeof(Gemini3ProImageRequestModelId.Gemini3ProImageRequestModelIdSerializer))]
[Serializable]
public readonly record struct Gemini3ProImageRequestModelId : IStringEnum
{
    public static readonly Gemini3ProImageRequestModelId Gemini3ProImage = new(
        Values.Gemini3ProImage
    );

    public Gemini3ProImageRequestModelId(string value)
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
    public static Gemini3ProImageRequestModelId FromCustom(string value)
    {
        return new Gemini3ProImageRequestModelId(value);
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

    public static bool operator ==(Gemini3ProImageRequestModelId value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(Gemini3ProImageRequestModelId value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(Gemini3ProImageRequestModelId value) => value.Value;

    public static explicit operator Gemini3ProImageRequestModelId(string value) => new(value);

    internal class Gemini3ProImageRequestModelIdSerializer
        : JsonConverter<Gemini3ProImageRequestModelId>
    {
        public override Gemini3ProImageRequestModelId Read(
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
            return new Gemini3ProImageRequestModelId(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            Gemini3ProImageRequestModelId value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override Gemini3ProImageRequestModelId ReadAsPropertyName(
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
            return new Gemini3ProImageRequestModelId(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            Gemini3ProImageRequestModelId value,
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
        public const string Gemini3ProImage = "gemini-3-pro-image";
    }
}
