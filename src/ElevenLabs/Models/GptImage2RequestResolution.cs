using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The resolution of the output image.</summary>
[JsonConverter(typeof(GptImage2RequestResolution.GptImage2RequestResolutionSerializer))]
[Serializable]
public readonly record struct GptImage2RequestResolution : IStringEnum
{
    public static readonly GptImage2RequestResolution OneK = new(Values.OneK);

    public static readonly GptImage2RequestResolution TwoK = new(Values.TwoK);

    public static readonly GptImage2RequestResolution FourK = new(Values.FourK);

    public GptImage2RequestResolution(string value)
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
    public static GptImage2RequestResolution FromCustom(string value)
    {
        return new GptImage2RequestResolution(value);
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

    public static bool operator ==(GptImage2RequestResolution value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GptImage2RequestResolution value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GptImage2RequestResolution value) => value.Value;

    public static explicit operator GptImage2RequestResolution(string value) => new(value);

    internal class GptImage2RequestResolutionSerializer : JsonConverter<GptImage2RequestResolution>
    {
        public override GptImage2RequestResolution Read(
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
            return new GptImage2RequestResolution(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GptImage2RequestResolution value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GptImage2RequestResolution ReadAsPropertyName(
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
            return new GptImage2RequestResolution(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GptImage2RequestResolution value,
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
