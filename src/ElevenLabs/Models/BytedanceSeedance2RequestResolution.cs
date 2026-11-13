using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The resolution of the output video.</summary>
[JsonConverter(
    typeof(BytedanceSeedance2RequestResolution.BytedanceSeedance2RequestResolutionSerializer)
)]
[Serializable]
public readonly record struct BytedanceSeedance2RequestResolution : IStringEnum
{
    public static readonly BytedanceSeedance2RequestResolution FourHundredEightyP = new(
        Values.FourHundredEightyP
    );

    public static readonly BytedanceSeedance2RequestResolution SevenHundredTwentyP = new(
        Values.SevenHundredTwentyP
    );

    public static readonly BytedanceSeedance2RequestResolution OneThousandEightyP = new(
        Values.OneThousandEightyP
    );

    public static readonly BytedanceSeedance2RequestResolution FourK = new(Values.FourK);

    public BytedanceSeedance2RequestResolution(string value)
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
    public static BytedanceSeedance2RequestResolution FromCustom(string value)
    {
        return new BytedanceSeedance2RequestResolution(value);
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

    public static bool operator ==(BytedanceSeedance2RequestResolution value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BytedanceSeedance2RequestResolution value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BytedanceSeedance2RequestResolution value) =>
        value.Value;

    public static explicit operator BytedanceSeedance2RequestResolution(string value) => new(value);

    internal class BytedanceSeedance2RequestResolutionSerializer
        : JsonConverter<BytedanceSeedance2RequestResolution>
    {
        public override BytedanceSeedance2RequestResolution Read(
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
            return new BytedanceSeedance2RequestResolution(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BytedanceSeedance2RequestResolution value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BytedanceSeedance2RequestResolution ReadAsPropertyName(
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
            return new BytedanceSeedance2RequestResolution(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BytedanceSeedance2RequestResolution value,
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
        public const string FourHundredEightyP = "480p";

        public const string SevenHundredTwentyP = "720p";

        public const string OneThousandEightyP = "1080p";

        public const string FourK = "4k";
    }
}
