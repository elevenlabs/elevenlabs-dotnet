using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The state of the chapter.</summary>
[JsonConverter(
    typeof(ChapterWithContentResponseModelState.ChapterWithContentResponseModelStateSerializer)
)]
[Serializable]
public readonly record struct ChapterWithContentResponseModelState : IStringEnum
{
    public static readonly ChapterWithContentResponseModelState Default = new(Values.Default);

    public static readonly ChapterWithContentResponseModelState Converting = new(Values.Converting);

    public ChapterWithContentResponseModelState(string value)
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
    public static ChapterWithContentResponseModelState FromCustom(string value)
    {
        return new ChapterWithContentResponseModelState(value);
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

    public static bool operator ==(ChapterWithContentResponseModelState value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ChapterWithContentResponseModelState value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ChapterWithContentResponseModelState value) =>
        value.Value;

    public static explicit operator ChapterWithContentResponseModelState(string value) =>
        new(value);

    internal class ChapterWithContentResponseModelStateSerializer
        : JsonConverter<ChapterWithContentResponseModelState>
    {
        public override ChapterWithContentResponseModelState Read(
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
            return new ChapterWithContentResponseModelState(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ChapterWithContentResponseModelState value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ChapterWithContentResponseModelState ReadAsPropertyName(
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
            return new ChapterWithContentResponseModelState(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ChapterWithContentResponseModelState value,
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
