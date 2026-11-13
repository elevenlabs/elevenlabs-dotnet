using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The aspect ratio of the output image. With `auto`, the model picks an aspect ratio based on the inputs.</summary>
[JsonConverter(
    typeof(BytedanceSeedream5LiteRequestAspectRatio.BytedanceSeedream5LiteRequestAspectRatioSerializer)
)]
[Serializable]
public readonly record struct BytedanceSeedream5LiteRequestAspectRatio : IStringEnum
{
    public static readonly BytedanceSeedream5LiteRequestAspectRatio Auto = new(Values.Auto);

    public static readonly BytedanceSeedream5LiteRequestAspectRatio One1 = new(Values.One1);

    public static readonly BytedanceSeedream5LiteRequestAspectRatio Three4 = new(Values.Three4);

    public static readonly BytedanceSeedream5LiteRequestAspectRatio Sixteen9 = new(Values.Sixteen9);

    public static readonly BytedanceSeedream5LiteRequestAspectRatio Four3 = new(Values.Four3);

    public static readonly BytedanceSeedream5LiteRequestAspectRatio Nine16 = new(Values.Nine16);

    public BytedanceSeedream5LiteRequestAspectRatio(string value)
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
    public static BytedanceSeedream5LiteRequestAspectRatio FromCustom(string value)
    {
        return new BytedanceSeedream5LiteRequestAspectRatio(value);
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

    public static bool operator ==(
        BytedanceSeedream5LiteRequestAspectRatio value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BytedanceSeedream5LiteRequestAspectRatio value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(BytedanceSeedream5LiteRequestAspectRatio value) =>
        value.Value;

    public static explicit operator BytedanceSeedream5LiteRequestAspectRatio(string value) =>
        new(value);

    internal class BytedanceSeedream5LiteRequestAspectRatioSerializer
        : JsonConverter<BytedanceSeedream5LiteRequestAspectRatio>
    {
        public override BytedanceSeedream5LiteRequestAspectRatio Read(
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
            return new BytedanceSeedream5LiteRequestAspectRatio(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BytedanceSeedream5LiteRequestAspectRatio value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BytedanceSeedream5LiteRequestAspectRatio ReadAsPropertyName(
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
            return new BytedanceSeedream5LiteRequestAspectRatio(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BytedanceSeedream5LiteRequestAspectRatio value,
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

        public const string Three4 = "3:4";

        public const string Sixteen9 = "16:9";

        public const string Four3 = "4:3";

        public const string Nine16 = "9:16";
    }
}
