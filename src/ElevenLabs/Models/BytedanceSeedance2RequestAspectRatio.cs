using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The aspect ratio of the output video. With `auto`, the model picks an aspect ratio based on the inputs.</summary>
[JsonConverter(
    typeof(BytedanceSeedance2RequestAspectRatio.BytedanceSeedance2RequestAspectRatioSerializer)
)]
[Serializable]
public readonly record struct BytedanceSeedance2RequestAspectRatio : IStringEnum
{
    public static readonly BytedanceSeedance2RequestAspectRatio Auto = new(Values.Auto);

    public static readonly BytedanceSeedance2RequestAspectRatio TwentyOne9 = new(Values.TwentyOne9);

    public static readonly BytedanceSeedance2RequestAspectRatio Sixteen9 = new(Values.Sixteen9);

    public static readonly BytedanceSeedance2RequestAspectRatio Four3 = new(Values.Four3);

    public static readonly BytedanceSeedance2RequestAspectRatio One1 = new(Values.One1);

    public static readonly BytedanceSeedance2RequestAspectRatio Three4 = new(Values.Three4);

    public static readonly BytedanceSeedance2RequestAspectRatio Nine16 = new(Values.Nine16);

    public BytedanceSeedance2RequestAspectRatio(string value)
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
    public static BytedanceSeedance2RequestAspectRatio FromCustom(string value)
    {
        return new BytedanceSeedance2RequestAspectRatio(value);
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

    public static bool operator ==(BytedanceSeedance2RequestAspectRatio value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BytedanceSeedance2RequestAspectRatio value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BytedanceSeedance2RequestAspectRatio value) =>
        value.Value;

    public static explicit operator BytedanceSeedance2RequestAspectRatio(string value) =>
        new(value);

    internal class BytedanceSeedance2RequestAspectRatioSerializer
        : JsonConverter<BytedanceSeedance2RequestAspectRatio>
    {
        public override BytedanceSeedance2RequestAspectRatio Read(
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
            return new BytedanceSeedance2RequestAspectRatio(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BytedanceSeedance2RequestAspectRatio value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BytedanceSeedance2RequestAspectRatio ReadAsPropertyName(
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
            return new BytedanceSeedance2RequestAspectRatio(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BytedanceSeedance2RequestAspectRatio value,
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

        public const string TwentyOne9 = "21:9";

        public const string Sixteen9 = "16:9";

        public const string Four3 = "4:3";

        public const string One1 = "1:1";

        public const string Three4 = "3:4";

        public const string Nine16 = "9:16";
    }
}
