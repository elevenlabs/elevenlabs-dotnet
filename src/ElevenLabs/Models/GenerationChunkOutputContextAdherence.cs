using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>How much the model adheres to the context of its surrounding chunks. Low adherence means the model can deviate from the context and be more creative. High adherence means the model will be more consistent with the context.</summary>
[JsonConverter(
    typeof(GenerationChunkOutputContextAdherence.GenerationChunkOutputContextAdherenceSerializer)
)]
[Serializable]
public readonly record struct GenerationChunkOutputContextAdherence : IStringEnum
{
    public static readonly GenerationChunkOutputContextAdherence Low = new(Values.Low);

    public static readonly GenerationChunkOutputContextAdherence Medium = new(Values.Medium);

    public static readonly GenerationChunkOutputContextAdherence High = new(Values.High);

    public GenerationChunkOutputContextAdherence(string value)
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
    public static GenerationChunkOutputContextAdherence FromCustom(string value)
    {
        return new GenerationChunkOutputContextAdherence(value);
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

    public static bool operator ==(GenerationChunkOutputContextAdherence value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GenerationChunkOutputContextAdherence value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GenerationChunkOutputContextAdherence value) =>
        value.Value;

    public static explicit operator GenerationChunkOutputContextAdherence(string value) =>
        new(value);

    internal class GenerationChunkOutputContextAdherenceSerializer
        : JsonConverter<GenerationChunkOutputContextAdherence>
    {
        public override GenerationChunkOutputContextAdherence Read(
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
            return new GenerationChunkOutputContextAdherence(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GenerationChunkOutputContextAdherence value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GenerationChunkOutputContextAdherence ReadAsPropertyName(
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
            return new GenerationChunkOutputContextAdherence(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GenerationChunkOutputContextAdherence value,
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
        public const string Low = "low";

        public const string Medium = "medium";

        public const string High = "high";
    }
}
