using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The model to use for the generation.</summary>
[JsonConverter(typeof(GptImage15RequestModelId.GptImage15RequestModelIdSerializer))]
[Serializable]
public readonly record struct GptImage15RequestModelId : IStringEnum
{
    public static readonly GptImage15RequestModelId GptImage15 = new(Values.GptImage15);

    public GptImage15RequestModelId(string value)
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
    public static GptImage15RequestModelId FromCustom(string value)
    {
        return new GptImage15RequestModelId(value);
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

    public static bool operator ==(GptImage15RequestModelId value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GptImage15RequestModelId value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GptImage15RequestModelId value) => value.Value;

    public static explicit operator GptImage15RequestModelId(string value) => new(value);

    internal class GptImage15RequestModelIdSerializer : JsonConverter<GptImage15RequestModelId>
    {
        public override GptImage15RequestModelId Read(
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
            return new GptImage15RequestModelId(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GptImage15RequestModelId value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GptImage15RequestModelId ReadAsPropertyName(
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
            return new GptImage15RequestModelId(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GptImage15RequestModelId value,
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
        public const string GptImage15 = "gpt-image-1.5";
    }
}
