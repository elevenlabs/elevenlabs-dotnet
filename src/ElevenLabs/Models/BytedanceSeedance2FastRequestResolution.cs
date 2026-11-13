using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The resolution of the output video.</summary>
[JsonConverter(
    typeof(BytedanceSeedance2FastRequestResolution.BytedanceSeedance2FastRequestResolutionSerializer)
)]
[Serializable]
public readonly record struct BytedanceSeedance2FastRequestResolution : IStringEnum
{
    public static readonly BytedanceSeedance2FastRequestResolution FourHundredEightyP = new(
        Values.FourHundredEightyP
    );

    public static readonly BytedanceSeedance2FastRequestResolution SevenHundredTwentyP = new(
        Values.SevenHundredTwentyP
    );

    public BytedanceSeedance2FastRequestResolution(string value)
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
    public static BytedanceSeedance2FastRequestResolution FromCustom(string value)
    {
        return new BytedanceSeedance2FastRequestResolution(value);
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

    public static bool operator ==(BytedanceSeedance2FastRequestResolution value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BytedanceSeedance2FastRequestResolution value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BytedanceSeedance2FastRequestResolution value) =>
        value.Value;

    public static explicit operator BytedanceSeedance2FastRequestResolution(string value) =>
        new(value);

    internal class BytedanceSeedance2FastRequestResolutionSerializer
        : JsonConverter<BytedanceSeedance2FastRequestResolution>
    {
        public override BytedanceSeedance2FastRequestResolution Read(
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
            return new BytedanceSeedance2FastRequestResolution(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BytedanceSeedance2FastRequestResolution value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BytedanceSeedance2FastRequestResolution ReadAsPropertyName(
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
            return new BytedanceSeedance2FastRequestResolution(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BytedanceSeedance2FastRequestResolution value,
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
    }
}
