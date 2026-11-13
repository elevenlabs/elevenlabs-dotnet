using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The model to use for the generation.</summary>
[JsonConverter(typeof(Veo31RequestModelId.Veo31RequestModelIdSerializer))]
[Serializable]
public readonly record struct Veo31RequestModelId : IStringEnum
{
    public static readonly Veo31RequestModelId Veo31Generate001 = new(Values.Veo31Generate001);

    public Veo31RequestModelId(string value)
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
    public static Veo31RequestModelId FromCustom(string value)
    {
        return new Veo31RequestModelId(value);
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

    public static bool operator ==(Veo31RequestModelId value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(Veo31RequestModelId value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(Veo31RequestModelId value) => value.Value;

    public static explicit operator Veo31RequestModelId(string value) => new(value);

    internal class Veo31RequestModelIdSerializer : JsonConverter<Veo31RequestModelId>
    {
        public override Veo31RequestModelId Read(
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
            return new Veo31RequestModelId(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            Veo31RequestModelId value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override Veo31RequestModelId ReadAsPropertyName(
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
            return new Veo31RequestModelId(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            Veo31RequestModelId value,
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
        public const string Veo31Generate001 = "veo-3.1-generate-001";
    }
}
