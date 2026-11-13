using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The quality of the output image.</summary>
[JsonConverter(typeof(GptImage25SunburstRequestQuality.GptImage25SunburstRequestQualitySerializer))]
[Serializable]
public readonly record struct GptImage25SunburstRequestQuality : IStringEnum
{
    public static readonly GptImage25SunburstRequestQuality Low = new(Values.Low);

    public static readonly GptImage25SunburstRequestQuality Medium = new(Values.Medium);

    public static readonly GptImage25SunburstRequestQuality High = new(Values.High);

    public static readonly GptImage25SunburstRequestQuality Xhigh = new(Values.Xhigh);

    public static readonly GptImage25SunburstRequestQuality Max = new(Values.Max);

    public GptImage25SunburstRequestQuality(string value)
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
    public static GptImage25SunburstRequestQuality FromCustom(string value)
    {
        return new GptImage25SunburstRequestQuality(value);
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

    public static bool operator ==(GptImage25SunburstRequestQuality value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GptImage25SunburstRequestQuality value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GptImage25SunburstRequestQuality value) => value.Value;

    public static explicit operator GptImage25SunburstRequestQuality(string value) => new(value);

    internal class GptImage25SunburstRequestQualitySerializer
        : JsonConverter<GptImage25SunburstRequestQuality>
    {
        public override GptImage25SunburstRequestQuality Read(
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
            return new GptImage25SunburstRequestQuality(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GptImage25SunburstRequestQuality value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GptImage25SunburstRequestQuality ReadAsPropertyName(
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
            return new GptImage25SunburstRequestQuality(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GptImage25SunburstRequestQuality value,
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

        public const string Xhigh = "xhigh";

        public const string Max = "max";
    }
}
