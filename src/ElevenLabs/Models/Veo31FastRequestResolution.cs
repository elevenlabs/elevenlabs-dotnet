using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The resolution of the output video.</summary>
[JsonConverter(typeof(Veo31FastRequestResolution.Veo31FastRequestResolutionSerializer))]
[Serializable]
public readonly record struct Veo31FastRequestResolution : IStringEnum
{
    public static readonly Veo31FastRequestResolution SevenHundredTwentyP = new(
        Values.SevenHundredTwentyP
    );

    public static readonly Veo31FastRequestResolution OneThousandEightyP = new(
        Values.OneThousandEightyP
    );

    public static readonly Veo31FastRequestResolution FourK = new(Values.FourK);

    public Veo31FastRequestResolution(string value)
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
    public static Veo31FastRequestResolution FromCustom(string value)
    {
        return new Veo31FastRequestResolution(value);
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

    public static bool operator ==(Veo31FastRequestResolution value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(Veo31FastRequestResolution value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(Veo31FastRequestResolution value) => value.Value;

    public static explicit operator Veo31FastRequestResolution(string value) => new(value);

    internal class Veo31FastRequestResolutionSerializer : JsonConverter<Veo31FastRequestResolution>
    {
        public override Veo31FastRequestResolution Read(
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
            return new Veo31FastRequestResolution(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            Veo31FastRequestResolution value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override Veo31FastRequestResolution ReadAsPropertyName(
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
            return new Veo31FastRequestResolution(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            Veo31FastRequestResolution value,
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
        public const string SevenHundredTwentyP = "720p";

        public const string OneThousandEightyP = "1080p";

        public const string FourK = "4K";
    }
}
