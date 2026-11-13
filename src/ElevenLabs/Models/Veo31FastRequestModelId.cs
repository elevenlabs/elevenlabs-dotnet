using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The model to use for the generation.</summary>
[JsonConverter(typeof(Veo31FastRequestModelId.Veo31FastRequestModelIdSerializer))]
[Serializable]
public readonly record struct Veo31FastRequestModelId : IStringEnum
{
    public static readonly Veo31FastRequestModelId Veo31FastGenerate001 = new(
        Values.Veo31FastGenerate001
    );

    public Veo31FastRequestModelId(string value)
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
    public static Veo31FastRequestModelId FromCustom(string value)
    {
        return new Veo31FastRequestModelId(value);
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

    public static bool operator ==(Veo31FastRequestModelId value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(Veo31FastRequestModelId value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(Veo31FastRequestModelId value) => value.Value;

    public static explicit operator Veo31FastRequestModelId(string value) => new(value);

    internal class Veo31FastRequestModelIdSerializer : JsonConverter<Veo31FastRequestModelId>
    {
        public override Veo31FastRequestModelId Read(
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
            return new Veo31FastRequestModelId(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            Veo31FastRequestModelId value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override Veo31FastRequestModelId ReadAsPropertyName(
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
            return new Veo31FastRequestModelId(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            Veo31FastRequestModelId value,
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
        public const string Veo31FastGenerate001 = "veo-3.1-fast-generate-001";
    }
}
