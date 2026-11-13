using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The aspect ratio of the output video.</summary>
[JsonConverter(typeof(Veo31FastRequestAspectRatio.Veo31FastRequestAspectRatioSerializer))]
[Serializable]
public readonly record struct Veo31FastRequestAspectRatio : IStringEnum
{
    public static readonly Veo31FastRequestAspectRatio Sixteen9 = new(Values.Sixteen9);

    public static readonly Veo31FastRequestAspectRatio Nine16 = new(Values.Nine16);

    public Veo31FastRequestAspectRatio(string value)
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
    public static Veo31FastRequestAspectRatio FromCustom(string value)
    {
        return new Veo31FastRequestAspectRatio(value);
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

    public static bool operator ==(Veo31FastRequestAspectRatio value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(Veo31FastRequestAspectRatio value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(Veo31FastRequestAspectRatio value) => value.Value;

    public static explicit operator Veo31FastRequestAspectRatio(string value) => new(value);

    internal class Veo31FastRequestAspectRatioSerializer
        : JsonConverter<Veo31FastRequestAspectRatio>
    {
        public override Veo31FastRequestAspectRatio Read(
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
            return new Veo31FastRequestAspectRatio(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            Veo31FastRequestAspectRatio value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override Veo31FastRequestAspectRatio ReadAsPropertyName(
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
            return new Veo31FastRequestAspectRatio(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            Veo31FastRequestAspectRatio value,
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
        public const string Sixteen9 = "16:9";

        public const string Nine16 = "9:16";
    }
}
