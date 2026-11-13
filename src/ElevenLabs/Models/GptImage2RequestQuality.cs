using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The quality of the output image.</summary>
[JsonConverter(typeof(GptImage2RequestQuality.GptImage2RequestQualitySerializer))]
[Serializable]
public readonly record struct GptImage2RequestQuality : IStringEnum
{
    public static readonly GptImage2RequestQuality Low = new(Values.Low);

    public static readonly GptImage2RequestQuality Medium = new(Values.Medium);

    public static readonly GptImage2RequestQuality High = new(Values.High);

    public GptImage2RequestQuality(string value)
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
    public static GptImage2RequestQuality FromCustom(string value)
    {
        return new GptImage2RequestQuality(value);
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

    public static bool operator ==(GptImage2RequestQuality value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GptImage2RequestQuality value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GptImage2RequestQuality value) => value.Value;

    public static explicit operator GptImage2RequestQuality(string value) => new(value);

    internal class GptImage2RequestQualitySerializer : JsonConverter<GptImage2RequestQuality>
    {
        public override GptImage2RequestQuality Read(
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
            return new GptImage2RequestQuality(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GptImage2RequestQuality value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GptImage2RequestQuality ReadAsPropertyName(
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
            return new GptImage2RequestQuality(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GptImage2RequestQuality value,
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
        public const string Low = "low";

        public const string Medium = "medium";

        public const string High = "high";
    }
}
