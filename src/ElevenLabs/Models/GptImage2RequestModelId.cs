using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The model to use for the generation.</summary>
[JsonConverter(typeof(GptImage2RequestModelId.GptImage2RequestModelIdSerializer))]
[Serializable]
public readonly record struct GptImage2RequestModelId : IStringEnum
{
    public static readonly GptImage2RequestModelId GptImage2 = new(Values.GptImage2);

    public GptImage2RequestModelId(string value)
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
    public static GptImage2RequestModelId FromCustom(string value)
    {
        return new GptImage2RequestModelId(value);
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

    public static bool operator ==(GptImage2RequestModelId value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GptImage2RequestModelId value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GptImage2RequestModelId value) => value.Value;

    public static explicit operator GptImage2RequestModelId(string value) => new(value);

    internal class GptImage2RequestModelIdSerializer : JsonConverter<GptImage2RequestModelId>
    {
        public override GptImage2RequestModelId Read(
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
            return new GptImage2RequestModelId(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GptImage2RequestModelId value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GptImage2RequestModelId ReadAsPropertyName(
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
            return new GptImage2RequestModelId(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GptImage2RequestModelId value,
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
        public const string GptImage2 = "gpt-image-2";
    }
}
