using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The resolution of the output video.</summary>
[JsonConverter(typeof(Veo31RequestResolution.Veo31RequestResolutionSerializer))]
[Serializable]
public readonly record struct Veo31RequestResolution : IStringEnum
{
    public static readonly Veo31RequestResolution SevenHundredTwentyP = new(
        Values.SevenHundredTwentyP
    );

    public static readonly Veo31RequestResolution OneThousandEightyP = new(
        Values.OneThousandEightyP
    );

    public static readonly Veo31RequestResolution FourK = new(Values.FourK);

    public Veo31RequestResolution(string value)
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
    public static Veo31RequestResolution FromCustom(string value)
    {
        return new Veo31RequestResolution(value);
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

    public static bool operator ==(Veo31RequestResolution value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(Veo31RequestResolution value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(Veo31RequestResolution value) => value.Value;

    public static explicit operator Veo31RequestResolution(string value) => new(value);

    internal class Veo31RequestResolutionSerializer : JsonConverter<Veo31RequestResolution>
    {
        public override Veo31RequestResolution Read(
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
            return new Veo31RequestResolution(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            Veo31RequestResolution value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override Veo31RequestResolution ReadAsPropertyName(
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
            return new Veo31RequestResolution(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            Veo31RequestResolution value,
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
