using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The model to use for the generation.</summary>
[JsonConverter(typeof(GptImage1RequestModelId.GptImage1RequestModelIdSerializer))]
[Serializable]
public readonly record struct GptImage1RequestModelId : IStringEnum
{
    public static readonly GptImage1RequestModelId GptImage1 = new(Values.GptImage1);

    public GptImage1RequestModelId(string value)
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
    public static GptImage1RequestModelId FromCustom(string value)
    {
        return new GptImage1RequestModelId(value);
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

    public static bool operator ==(GptImage1RequestModelId value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GptImage1RequestModelId value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GptImage1RequestModelId value) => value.Value;

    public static explicit operator GptImage1RequestModelId(string value) => new(value);

    internal class GptImage1RequestModelIdSerializer : JsonConverter<GptImage1RequestModelId>
    {
        public override GptImage1RequestModelId Read(
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
            return new GptImage1RequestModelId(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GptImage1RequestModelId value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GptImage1RequestModelId ReadAsPropertyName(
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
            return new GptImage1RequestModelId(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GptImage1RequestModelId value,
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
        public const string GptImage1 = "gpt-image-1";
    }
}
