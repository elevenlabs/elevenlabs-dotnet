using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The aspect ratio of the output video.</summary>
[JsonConverter(typeof(Veo31RequestAspectRatio.Veo31RequestAspectRatioSerializer))]
[Serializable]
public readonly record struct Veo31RequestAspectRatio : IStringEnum
{
    public static readonly Veo31RequestAspectRatio Sixteen9 = new(Values.Sixteen9);

    public static readonly Veo31RequestAspectRatio Nine16 = new(Values.Nine16);

    public Veo31RequestAspectRatio(string value)
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
    public static Veo31RequestAspectRatio FromCustom(string value)
    {
        return new Veo31RequestAspectRatio(value);
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

    public static bool operator ==(Veo31RequestAspectRatio value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(Veo31RequestAspectRatio value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(Veo31RequestAspectRatio value) => value.Value;

    public static explicit operator Veo31RequestAspectRatio(string value) => new(value);

    internal class Veo31RequestAspectRatioSerializer : JsonConverter<Veo31RequestAspectRatio>
    {
        public override Veo31RequestAspectRatio Read(
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
            return new Veo31RequestAspectRatio(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            Veo31RequestAspectRatio value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override Veo31RequestAspectRatio ReadAsPropertyName(
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
            return new Veo31RequestAspectRatio(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            Veo31RequestAspectRatio value,
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
