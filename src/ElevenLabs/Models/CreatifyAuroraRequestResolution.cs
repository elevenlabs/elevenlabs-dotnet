using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The resolution of the output video.</summary>
[JsonConverter(typeof(CreatifyAuroraRequestResolution.CreatifyAuroraRequestResolutionSerializer))]
[Serializable]
public readonly record struct CreatifyAuroraRequestResolution : IStringEnum
{
    public static readonly CreatifyAuroraRequestResolution FourHundredEightyP = new(
        Values.FourHundredEightyP
    );

    public static readonly CreatifyAuroraRequestResolution SevenHundredTwentyP = new(
        Values.SevenHundredTwentyP
    );

    public CreatifyAuroraRequestResolution(string value)
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
    public static CreatifyAuroraRequestResolution FromCustom(string value)
    {
        return new CreatifyAuroraRequestResolution(value);
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

    public static bool operator ==(CreatifyAuroraRequestResolution value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreatifyAuroraRequestResolution value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreatifyAuroraRequestResolution value) => value.Value;

    public static explicit operator CreatifyAuroraRequestResolution(string value) => new(value);

    internal class CreatifyAuroraRequestResolutionSerializer
        : JsonConverter<CreatifyAuroraRequestResolution>
    {
        public override CreatifyAuroraRequestResolution Read(
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
            return new CreatifyAuroraRequestResolution(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreatifyAuroraRequestResolution value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreatifyAuroraRequestResolution ReadAsPropertyName(
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
            return new CreatifyAuroraRequestResolution(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreatifyAuroraRequestResolution value,
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
