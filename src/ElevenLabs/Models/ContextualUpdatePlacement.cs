using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Where the LLM view renders a contextual update.</summary>
[JsonConverter(typeof(ContextualUpdatePlacement.ContextualUpdatePlacementSerializer))]
[Serializable]
public readonly record struct ContextualUpdatePlacement : IStringEnum
{
    public static readonly ContextualUpdatePlacement InPlace = new(Values.InPlace);

    public static readonly ContextualUpdatePlacement End = new(Values.End);

    public ContextualUpdatePlacement(string value)
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
    public static ContextualUpdatePlacement FromCustom(string value)
    {
        return new ContextualUpdatePlacement(value);
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

    public static bool operator ==(ContextualUpdatePlacement value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ContextualUpdatePlacement value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ContextualUpdatePlacement value) => value.Value;

    public static explicit operator ContextualUpdatePlacement(string value) => new(value);

    internal class ContextualUpdatePlacementSerializer : JsonConverter<ContextualUpdatePlacement>
    {
        public override ContextualUpdatePlacement Read(
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
            return new ContextualUpdatePlacement(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ContextualUpdatePlacement value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ContextualUpdatePlacement ReadAsPropertyName(
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
            return new ContextualUpdatePlacement(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ContextualUpdatePlacement value,
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
        public const string InPlace = "in_place";

        public const string End = "end";
    }
}
