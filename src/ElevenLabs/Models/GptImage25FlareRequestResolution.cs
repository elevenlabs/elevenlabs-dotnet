using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The resolution of the output image.</summary>
[JsonConverter(typeof(GptImage25FlareRequestResolution.GptImage25FlareRequestResolutionSerializer))]
[Serializable]
public readonly record struct GptImage25FlareRequestResolution : IStringEnum
{
    public static readonly GptImage25FlareRequestResolution OneK = new(Values.OneK);

    public static readonly GptImage25FlareRequestResolution TwoK = new(Values.TwoK);

    public static readonly GptImage25FlareRequestResolution FourK = new(Values.FourK);

    public GptImage25FlareRequestResolution(string value)
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
    public static GptImage25FlareRequestResolution FromCustom(string value)
    {
        return new GptImage25FlareRequestResolution(value);
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

    public static bool operator ==(GptImage25FlareRequestResolution value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GptImage25FlareRequestResolution value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GptImage25FlareRequestResolution value) => value.Value;

    public static explicit operator GptImage25FlareRequestResolution(string value) => new(value);

    internal class GptImage25FlareRequestResolutionSerializer
        : JsonConverter<GptImage25FlareRequestResolution>
    {
        public override GptImage25FlareRequestResolution Read(
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
            return new GptImage25FlareRequestResolution(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GptImage25FlareRequestResolution value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GptImage25FlareRequestResolution ReadAsPropertyName(
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
            return new GptImage25FlareRequestResolution(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GptImage25FlareRequestResolution value,
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
