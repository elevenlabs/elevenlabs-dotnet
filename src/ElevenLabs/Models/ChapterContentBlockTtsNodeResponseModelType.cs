using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ChapterContentBlockTtsNodeResponseModelType.ChapterContentBlockTtsNodeResponseModelTypeSerializer)
)]
[Serializable]
public readonly record struct ChapterContentBlockTtsNodeResponseModelType : IStringEnum
{
    public static readonly ChapterContentBlockTtsNodeResponseModelType TtsNode = new(
        Values.TtsNode
    );

    public ChapterContentBlockTtsNodeResponseModelType(string value)
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
    public static ChapterContentBlockTtsNodeResponseModelType FromCustom(string value)
    {
        return new ChapterContentBlockTtsNodeResponseModelType(value);
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

    public static bool operator ==(
        ChapterContentBlockTtsNodeResponseModelType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ChapterContentBlockTtsNodeResponseModelType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ChapterContentBlockTtsNodeResponseModelType value) =>
        value.Value;

    public static explicit operator ChapterContentBlockTtsNodeResponseModelType(string value) =>
        new(value);

    internal class ChapterContentBlockTtsNodeResponseModelTypeSerializer
        : JsonConverter<ChapterContentBlockTtsNodeResponseModelType>
    {
        public override ChapterContentBlockTtsNodeResponseModelType Read(
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
            return new ChapterContentBlockTtsNodeResponseModelType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ChapterContentBlockTtsNodeResponseModelType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ChapterContentBlockTtsNodeResponseModelType ReadAsPropertyName(
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
            return new ChapterContentBlockTtsNodeResponseModelType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ChapterContentBlockTtsNodeResponseModelType value,
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
        public const string TtsNode = "tts_node";
    }
}
