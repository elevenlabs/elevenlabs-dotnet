using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The aspect ratio of the output image. With `auto`, the model picks an aspect ratio based on the inputs.</summary>
[JsonConverter(
    typeof(GptImage25SunburstRequestAspectRatio.GptImage25SunburstRequestAspectRatioSerializer)
)]
[Serializable]
public readonly record struct GptImage25SunburstRequestAspectRatio : IStringEnum
{
    public static readonly GptImage25SunburstRequestAspectRatio Auto = new(Values.Auto);

    public static readonly GptImage25SunburstRequestAspectRatio One1 = new(Values.One1);

    public static readonly GptImage25SunburstRequestAspectRatio Four5 = new(Values.Four5);

    public static readonly GptImage25SunburstRequestAspectRatio Five4 = new(Values.Five4);

    public static readonly GptImage25SunburstRequestAspectRatio Three4 = new(Values.Three4);

    public static readonly GptImage25SunburstRequestAspectRatio Four3 = new(Values.Four3);

    public static readonly GptImage25SunburstRequestAspectRatio Two3 = new(Values.Two3);

    public static readonly GptImage25SunburstRequestAspectRatio Three2 = new(Values.Three2);

    public static readonly GptImage25SunburstRequestAspectRatio One2 = new(Values.One2);

    public static readonly GptImage25SunburstRequestAspectRatio Two1 = new(Values.Two1);

    public static readonly GptImage25SunburstRequestAspectRatio Nine16 = new(Values.Nine16);

    public static readonly GptImage25SunburstRequestAspectRatio Sixteen9 = new(Values.Sixteen9);

    public static readonly GptImage25SunburstRequestAspectRatio TwentyOne9 = new(Values.TwentyOne9);

    public static readonly GptImage25SunburstRequestAspectRatio One3 = new(Values.One3);

    public static readonly GptImage25SunburstRequestAspectRatio Three1 = new(Values.Three1);

    public GptImage25SunburstRequestAspectRatio(string value)
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
    public static GptImage25SunburstRequestAspectRatio FromCustom(string value)
    {
        return new GptImage25SunburstRequestAspectRatio(value);
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

    public static bool operator ==(GptImage25SunburstRequestAspectRatio value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GptImage25SunburstRequestAspectRatio value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GptImage25SunburstRequestAspectRatio value) =>
        value.Value;

    public static explicit operator GptImage25SunburstRequestAspectRatio(string value) =>
        new(value);

    internal class GptImage25SunburstRequestAspectRatioSerializer
        : JsonConverter<GptImage25SunburstRequestAspectRatio>
    {
        public override GptImage25SunburstRequestAspectRatio Read(
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
            return new GptImage25SunburstRequestAspectRatio(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GptImage25SunburstRequestAspectRatio value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GptImage25SunburstRequestAspectRatio ReadAsPropertyName(
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
            return new GptImage25SunburstRequestAspectRatio(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GptImage25SunburstRequestAspectRatio value,
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
        public const string Auto = "auto";

        public const string One1 = "1:1";

        public const string Four5 = "4:5";

        public const string Five4 = "5:4";

        public const string Three4 = "3:4";

        public const string Four3 = "4:3";

        public const string Two3 = "2:3";

        public const string Three2 = "3:2";

        public const string One2 = "1:2";

        public const string Two1 = "2:1";

        public const string Nine16 = "9:16";

        public const string Sixteen9 = "16:9";

        public const string TwentyOne9 = "21:9";

        public const string One3 = "1:3";

        public const string Three1 = "3:1";
    }
}
