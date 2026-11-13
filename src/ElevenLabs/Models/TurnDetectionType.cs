using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(TurnDetectionType.TurnDetectionTypeSerializer))]
[Serializable]
public readonly record struct TurnDetectionType : IStringEnum
{
    public static readonly TurnDetectionType SemanticVad = new(Values.SemanticVad);

    public static readonly TurnDetectionType ServerVad = new(Values.ServerVad);

    public TurnDetectionType(string value)
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
    public static TurnDetectionType FromCustom(string value)
    {
        return new TurnDetectionType(value);
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

    public static bool operator ==(TurnDetectionType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TurnDetectionType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TurnDetectionType value) => value.Value;

    public static explicit operator TurnDetectionType(string value) => new(value);

    internal class TurnDetectionTypeSerializer : JsonConverter<TurnDetectionType>
    {
        public override TurnDetectionType Read(
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
            return new TurnDetectionType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TurnDetectionType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TurnDetectionType ReadAsPropertyName(
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
            return new TurnDetectionType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TurnDetectionType value,
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
        public const string SemanticVad = "semantic_vad";

        public const string ServerVad = "server_vad";
    }
}
