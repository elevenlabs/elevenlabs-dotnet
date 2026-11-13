using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(MusicFinetuneFailureReason.MusicFinetuneFailureReasonSerializer))]
[Serializable]
public readonly record struct MusicFinetuneFailureReason : IStringEnum
{
    public static readonly MusicFinetuneFailureReason AudioProcessingFailed = new(
        Values.AudioProcessingFailed
    );

    public static readonly MusicFinetuneFailureReason CopyrightViolation = new(
        Values.CopyrightViolation
    );

    public static readonly MusicFinetuneFailureReason TrainingFailed = new(Values.TrainingFailed);

    public MusicFinetuneFailureReason(string value)
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
    public static MusicFinetuneFailureReason FromCustom(string value)
    {
        return new MusicFinetuneFailureReason(value);
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

    public static bool operator ==(MusicFinetuneFailureReason value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(MusicFinetuneFailureReason value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MusicFinetuneFailureReason value) => value.Value;

    public static explicit operator MusicFinetuneFailureReason(string value) => new(value);

    internal class MusicFinetuneFailureReasonSerializer : JsonConverter<MusicFinetuneFailureReason>
    {
        public override MusicFinetuneFailureReason Read(
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
            return new MusicFinetuneFailureReason(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            MusicFinetuneFailureReason value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override MusicFinetuneFailureReason ReadAsPropertyName(
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
            return new MusicFinetuneFailureReason(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            MusicFinetuneFailureReason value,
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
        public const string AudioProcessingFailed = "audio_processing_failed";

        public const string CopyrightViolation = "copyright_violation";

        public const string TrainingFailed = "training_failed";
    }
}
