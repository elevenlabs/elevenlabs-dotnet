using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The model to use for the generation.</summary>
[JsonConverter(typeof(GptImage25SunburstRequestModelId.GptImage25SunburstRequestModelIdSerializer))]
[Serializable]
public readonly record struct GptImage25SunburstRequestModelId : IStringEnum
{
    public static readonly GptImage25SunburstRequestModelId GptImage25Sunburst = new(
        Values.GptImage25Sunburst
    );

    public GptImage25SunburstRequestModelId(string value)
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
    public static GptImage25SunburstRequestModelId FromCustom(string value)
    {
        return new GptImage25SunburstRequestModelId(value);
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

    public static bool operator ==(GptImage25SunburstRequestModelId value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GptImage25SunburstRequestModelId value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GptImage25SunburstRequestModelId value) => value.Value;

    public static explicit operator GptImage25SunburstRequestModelId(string value) => new(value);

    internal class GptImage25SunburstRequestModelIdSerializer
        : JsonConverter<GptImage25SunburstRequestModelId>
    {
        public override GptImage25SunburstRequestModelId Read(
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
            return new GptImage25SunburstRequestModelId(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GptImage25SunburstRequestModelId value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GptImage25SunburstRequestModelId ReadAsPropertyName(
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
            return new GptImage25SunburstRequestModelId(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GptImage25SunburstRequestModelId value,
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
        public const string GptImage25Sunburst = "gpt-image-2.5-sunburst";
    }
}
