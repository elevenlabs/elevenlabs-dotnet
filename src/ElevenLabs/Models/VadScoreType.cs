using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(VadScoreType.VadScoreTypeSerializer))]
[Serializable]
public readonly record struct VadScoreType : IStringEnum
{
    public static readonly VadScoreType VadScore = new(Values.VadScore);

    public VadScoreType(string value)
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
    public static VadScoreType FromCustom(string value)
    {
        return new VadScoreType(value);
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

    public static bool operator ==(VadScoreType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(VadScoreType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(VadScoreType value) => value.Value;

    public static explicit operator VadScoreType(string value) => new(value);

    internal class VadScoreTypeSerializer : JsonConverter<VadScoreType>
    {
        public override VadScoreType Read(
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
            return new VadScoreType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            VadScoreType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override VadScoreType ReadAsPropertyName(
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
            return new VadScoreType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            VadScoreType value,
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
        public const string VadScore = "vad_score";
    }
}
