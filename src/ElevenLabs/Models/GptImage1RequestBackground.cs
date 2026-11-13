using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The background of the output image. With `auto`, the model picks the background that suits the image.</summary>
[JsonConverter(typeof(GptImage1RequestBackground.GptImage1RequestBackgroundSerializer))]
[Serializable]
public readonly record struct GptImage1RequestBackground : IStringEnum
{
    public static readonly GptImage1RequestBackground Transparent = new(Values.Transparent);

    public static readonly GptImage1RequestBackground Opaque = new(Values.Opaque);

    public static readonly GptImage1RequestBackground Auto = new(Values.Auto);

    public GptImage1RequestBackground(string value)
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
    public static GptImage1RequestBackground FromCustom(string value)
    {
        return new GptImage1RequestBackground(value);
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

    public static bool operator ==(GptImage1RequestBackground value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GptImage1RequestBackground value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GptImage1RequestBackground value) => value.Value;

    public static explicit operator GptImage1RequestBackground(string value) => new(value);

    internal class GptImage1RequestBackgroundSerializer : JsonConverter<GptImage1RequestBackground>
    {
        public override GptImage1RequestBackground Read(
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
            return new GptImage1RequestBackground(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GptImage1RequestBackground value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GptImage1RequestBackground ReadAsPropertyName(
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
            return new GptImage1RequestBackground(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GptImage1RequestBackground value,
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
        public const string Transparent = "transparent";

        public const string Opaque = "opaque";

        public const string Auto = "auto";
    }
}
