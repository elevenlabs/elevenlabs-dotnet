using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The aspect ratio of the output image. With `auto`, the model picks an aspect ratio based on the inputs.</summary>
[JsonConverter(
    typeof(Gemini31FlashImageRequestAspectRatio.Gemini31FlashImageRequestAspectRatioSerializer)
)]
[Serializable]
public readonly record struct Gemini31FlashImageRequestAspectRatio : IStringEnum
{
    public static readonly Gemini31FlashImageRequestAspectRatio Auto = new(Values.Auto);

    public static readonly Gemini31FlashImageRequestAspectRatio One1 = new(Values.One1);

    public static readonly Gemini31FlashImageRequestAspectRatio Two3 = new(Values.Two3);

    public static readonly Gemini31FlashImageRequestAspectRatio Three2 = new(Values.Three2);

    public static readonly Gemini31FlashImageRequestAspectRatio Three4 = new(Values.Three4);

    public static readonly Gemini31FlashImageRequestAspectRatio Four3 = new(Values.Four3);

    public static readonly Gemini31FlashImageRequestAspectRatio Four5 = new(Values.Four5);

    public static readonly Gemini31FlashImageRequestAspectRatio Five4 = new(Values.Five4);

    public static readonly Gemini31FlashImageRequestAspectRatio Nine16 = new(Values.Nine16);

    public static readonly Gemini31FlashImageRequestAspectRatio Sixteen9 = new(Values.Sixteen9);

    public static readonly Gemini31FlashImageRequestAspectRatio TwentyOne9 = new(Values.TwentyOne9);

    public static readonly Gemini31FlashImageRequestAspectRatio One4 = new(Values.One4);

    public static readonly Gemini31FlashImageRequestAspectRatio Four1 = new(Values.Four1);

    public static readonly Gemini31FlashImageRequestAspectRatio One8 = new(Values.One8);

    public static readonly Gemini31FlashImageRequestAspectRatio Eight1 = new(Values.Eight1);

    public Gemini31FlashImageRequestAspectRatio(string value)
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
    public static Gemini31FlashImageRequestAspectRatio FromCustom(string value)
    {
        return new Gemini31FlashImageRequestAspectRatio(value);
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

    public static bool operator ==(Gemini31FlashImageRequestAspectRatio value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(Gemini31FlashImageRequestAspectRatio value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(Gemini31FlashImageRequestAspectRatio value) =>
        value.Value;

    public static explicit operator Gemini31FlashImageRequestAspectRatio(string value) =>
        new(value);

    internal class Gemini31FlashImageRequestAspectRatioSerializer
        : JsonConverter<Gemini31FlashImageRequestAspectRatio>
    {
        public override Gemini31FlashImageRequestAspectRatio Read(
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
            return new Gemini31FlashImageRequestAspectRatio(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            Gemini31FlashImageRequestAspectRatio value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override Gemini31FlashImageRequestAspectRatio ReadAsPropertyName(
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
            return new Gemini31FlashImageRequestAspectRatio(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            Gemini31FlashImageRequestAspectRatio value,
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

        public const string Two3 = "2:3";

        public const string Three2 = "3:2";

        public const string Three4 = "3:4";

        public const string Four3 = "4:3";

        public const string Four5 = "4:5";

        public const string Five4 = "5:4";

        public const string Nine16 = "9:16";

        public const string Sixteen9 = "16:9";

        public const string TwentyOne9 = "21:9";

        public const string One4 = "1:4";

        public const string Four1 = "4:1";

        public const string One8 = "1:8";

        public const string Eight1 = "8:1";
    }
}
