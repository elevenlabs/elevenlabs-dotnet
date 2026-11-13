using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The state of the chapter.</summary>
[JsonConverter(typeof(ChapterState.ChapterStateSerializer))]
[Serializable]
public readonly record struct ChapterState : IStringEnum
{
    public static readonly ChapterState Default = new(Values.Default);

    public static readonly ChapterState Converting = new(Values.Converting);

    public ChapterState(string value)
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
    public static ChapterState FromCustom(string value)
    {
        return new ChapterState(value);
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

    public static bool operator ==(ChapterState value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ChapterState value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ChapterState value) => value.Value;

    public static explicit operator ChapterState(string value) => new(value);

    internal class ChapterStateSerializer : JsonConverter<ChapterState>
    {
        public override ChapterState Read(
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
            return new ChapterState(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ChapterState value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ChapterState ReadAsPropertyName(
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
            return new ChapterState(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ChapterState value,
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
        public const string Default = "default";

        public const string Converting = "converting";
    }
}
