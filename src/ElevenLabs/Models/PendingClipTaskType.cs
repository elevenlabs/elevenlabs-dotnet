using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(PendingClipTaskType.PendingClipTaskTypeSerializer))]
[Serializable]
public readonly record struct PendingClipTaskType : IStringEnum
{
    public static readonly PendingClipTaskType Preprocessing = new(Values.Preprocessing);

    public static readonly PendingClipTaskType SpeechImport = new(Values.SpeechImport);

    public static readonly PendingClipTaskType Dubbing = new(Values.Dubbing);

    public static readonly PendingClipTaskType VideoToMusic = new(Values.VideoToMusic);

    public static readonly PendingClipTaskType MediaGeneration = new(Values.MediaGeneration);

    public PendingClipTaskType(string value)
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
    public static PendingClipTaskType FromCustom(string value)
    {
        return new PendingClipTaskType(value);
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

    public static bool operator ==(PendingClipTaskType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PendingClipTaskType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PendingClipTaskType value) => value.Value;

    public static explicit operator PendingClipTaskType(string value) => new(value);

    internal class PendingClipTaskTypeSerializer : JsonConverter<PendingClipTaskType>
    {
        public override PendingClipTaskType Read(
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
            return new PendingClipTaskType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PendingClipTaskType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PendingClipTaskType ReadAsPropertyName(
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
            return new PendingClipTaskType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PendingClipTaskType value,
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
        public const string Preprocessing = "preprocessing";

        public const string SpeechImport = "speech_import";

        public const string Dubbing = "dubbing";

        public const string VideoToMusic = "video_to_music";

        public const string MediaGeneration = "media_generation";
    }
}
