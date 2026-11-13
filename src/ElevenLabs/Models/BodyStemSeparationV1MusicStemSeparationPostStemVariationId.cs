using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The id of the stem variation to use.</summary>
[JsonConverter(
    typeof(BodyStemSeparationV1MusicStemSeparationPostStemVariationId.BodyStemSeparationV1MusicStemSeparationPostStemVariationIdSerializer)
)]
[Serializable]
public readonly record struct BodyStemSeparationV1MusicStemSeparationPostStemVariationId
    : IStringEnum
{
    public static readonly BodyStemSeparationV1MusicStemSeparationPostStemVariationId TwoStemsV1 =
        new(Values.TwoStemsV1);

    public static readonly BodyStemSeparationV1MusicStemSeparationPostStemVariationId SixStemsV1 =
        new(Values.SixStemsV1);

    public BodyStemSeparationV1MusicStemSeparationPostStemVariationId(string value)
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
    public static BodyStemSeparationV1MusicStemSeparationPostStemVariationId FromCustom(
        string value
    )
    {
        return new BodyStemSeparationV1MusicStemSeparationPostStemVariationId(value);
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
        BodyStemSeparationV1MusicStemSeparationPostStemVariationId value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BodyStemSeparationV1MusicStemSeparationPostStemVariationId value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        BodyStemSeparationV1MusicStemSeparationPostStemVariationId value
    ) => value.Value;

    public static explicit operator BodyStemSeparationV1MusicStemSeparationPostStemVariationId(
        string value
    ) => new(value);

    internal class BodyStemSeparationV1MusicStemSeparationPostStemVariationIdSerializer
        : JsonConverter<BodyStemSeparationV1MusicStemSeparationPostStemVariationId>
    {
        public override BodyStemSeparationV1MusicStemSeparationPostStemVariationId Read(
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
            return new BodyStemSeparationV1MusicStemSeparationPostStemVariationId(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BodyStemSeparationV1MusicStemSeparationPostStemVariationId value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BodyStemSeparationV1MusicStemSeparationPostStemVariationId ReadAsPropertyName(
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
            return new BodyStemSeparationV1MusicStemSeparationPostStemVariationId(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BodyStemSeparationV1MusicStemSeparationPostStemVariationId value,
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
        public const string TwoStemsV1 = "two_stems_v1";

        public const string SixStemsV1 = "six_stems_v1";
    }
}
