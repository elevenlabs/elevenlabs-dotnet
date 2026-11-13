using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The aspect ratio of the output image.</summary>
[JsonConverter(typeof(GptImage1RequestAspectRatio.GptImage1RequestAspectRatioSerializer))]
[Serializable]
public readonly record struct GptImage1RequestAspectRatio : IStringEnum
{
    public static readonly GptImage1RequestAspectRatio One1 = new(Values.One1);

    public static readonly GptImage1RequestAspectRatio Three2 = new(Values.Three2);

    public static readonly GptImage1RequestAspectRatio Two3 = new(Values.Two3);

    public GptImage1RequestAspectRatio(string value)
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
    public static GptImage1RequestAspectRatio FromCustom(string value)
    {
        return new GptImage1RequestAspectRatio(value);
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

    public static bool operator ==(GptImage1RequestAspectRatio value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GptImage1RequestAspectRatio value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GptImage1RequestAspectRatio value) => value.Value;

    public static explicit operator GptImage1RequestAspectRatio(string value) => new(value);

    internal class GptImage1RequestAspectRatioSerializer
        : JsonConverter<GptImage1RequestAspectRatio>
    {
        public override GptImage1RequestAspectRatio Read(
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
            return new GptImage1RequestAspectRatio(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GptImage1RequestAspectRatio value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GptImage1RequestAspectRatio ReadAsPropertyName(
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
            return new GptImage1RequestAspectRatio(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GptImage1RequestAspectRatio value,
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
        public const string One1 = "1:1";

        public const string Three2 = "3:2";

        public const string Two3 = "2:3";
    }
}
