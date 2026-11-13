using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The background of the output image. With `auto`, the model picks the background that suits the image.</summary>
[JsonConverter(typeof(GptImage15RequestBackground.GptImage15RequestBackgroundSerializer))]
[Serializable]
public readonly record struct GptImage15RequestBackground : IStringEnum
{
    public static readonly GptImage15RequestBackground Transparent = new(Values.Transparent);

    public static readonly GptImage15RequestBackground Opaque = new(Values.Opaque);

    public static readonly GptImage15RequestBackground Auto = new(Values.Auto);

    public GptImage15RequestBackground(string value)
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
    public static GptImage15RequestBackground FromCustom(string value)
    {
        return new GptImage15RequestBackground(value);
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

    public static bool operator ==(GptImage15RequestBackground value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GptImage15RequestBackground value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GptImage15RequestBackground value) => value.Value;

    public static explicit operator GptImage15RequestBackground(string value) => new(value);

    internal class GptImage15RequestBackgroundSerializer
        : JsonConverter<GptImage15RequestBackground>
    {
        public override GptImage15RequestBackground Read(
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
            return new GptImage15RequestBackground(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GptImage15RequestBackground value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GptImage15RequestBackground ReadAsPropertyName(
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
            return new GptImage15RequestBackground(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GptImage15RequestBackground value,
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
