using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(GenerationReferenceType.GenerationReferenceTypeSerializer))]
[Serializable]
public readonly record struct GenerationReferenceType : IStringEnum
{
    public static readonly GenerationReferenceType Generation = new(Values.Generation);

    public GenerationReferenceType(string value)
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
    public static GenerationReferenceType FromCustom(string value)
    {
        return new GenerationReferenceType(value);
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

    public static bool operator ==(GenerationReferenceType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GenerationReferenceType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GenerationReferenceType value) => value.Value;

    public static explicit operator GenerationReferenceType(string value) => new(value);

    internal class GenerationReferenceTypeSerializer : JsonConverter<GenerationReferenceType>
    {
        public override GenerationReferenceType Read(
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
            return new GenerationReferenceType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GenerationReferenceType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GenerationReferenceType ReadAsPropertyName(
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
            return new GenerationReferenceType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GenerationReferenceType value,
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
        public const string Generation = "generation";
    }
}
