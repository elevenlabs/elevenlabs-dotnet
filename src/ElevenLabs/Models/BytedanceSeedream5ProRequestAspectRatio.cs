using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The aspect ratio of the output image. With `auto`, the model picks an aspect ratio based on the inputs.</summary>
[JsonConverter(
    typeof(BytedanceSeedream5ProRequestAspectRatio.BytedanceSeedream5ProRequestAspectRatioSerializer)
)]
[Serializable]
public readonly record struct BytedanceSeedream5ProRequestAspectRatio : IStringEnum
{
    public static readonly BytedanceSeedream5ProRequestAspectRatio Auto = new(Values.Auto);

    public static readonly BytedanceSeedream5ProRequestAspectRatio One1 = new(Values.One1);

    public static readonly BytedanceSeedream5ProRequestAspectRatio Three4 = new(Values.Three4);

    public static readonly BytedanceSeedream5ProRequestAspectRatio Sixteen9 = new(Values.Sixteen9);

    public static readonly BytedanceSeedream5ProRequestAspectRatio Four3 = new(Values.Four3);

    public static readonly BytedanceSeedream5ProRequestAspectRatio Nine16 = new(Values.Nine16);

    public BytedanceSeedream5ProRequestAspectRatio(string value)
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
    public static BytedanceSeedream5ProRequestAspectRatio FromCustom(string value)
    {
        return new BytedanceSeedream5ProRequestAspectRatio(value);
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

    public static bool operator ==(BytedanceSeedream5ProRequestAspectRatio value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BytedanceSeedream5ProRequestAspectRatio value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BytedanceSeedream5ProRequestAspectRatio value) =>
        value.Value;

    public static explicit operator BytedanceSeedream5ProRequestAspectRatio(string value) =>
        new(value);

    internal class BytedanceSeedream5ProRequestAspectRatioSerializer
        : JsonConverter<BytedanceSeedream5ProRequestAspectRatio>
    {
        public override BytedanceSeedream5ProRequestAspectRatio Read(
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
            return new BytedanceSeedream5ProRequestAspectRatio(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BytedanceSeedream5ProRequestAspectRatio value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BytedanceSeedream5ProRequestAspectRatio ReadAsPropertyName(
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
            return new BytedanceSeedream5ProRequestAspectRatio(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BytedanceSeedream5ProRequestAspectRatio value,
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
