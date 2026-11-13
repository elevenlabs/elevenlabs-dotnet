using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AudioAnalysisStatus.AudioAnalysisStatusSerializer))]
[Serializable]
public readonly record struct AudioAnalysisStatus : IStringEnum
{
    public static readonly AudioAnalysisStatus Processing = new(Values.Processing);

    public static readonly AudioAnalysisStatus Completed = new(Values.Completed);

    public static readonly AudioAnalysisStatus Failed = new(Values.Failed);

    public AudioAnalysisStatus(string value)
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
    public static AudioAnalysisStatus FromCustom(string value)
    {
        return new AudioAnalysisStatus(value);
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

    public static bool operator ==(AudioAnalysisStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AudioAnalysisStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AudioAnalysisStatus value) => value.Value;

    public static explicit operator AudioAnalysisStatus(string value) => new(value);

    internal class AudioAnalysisStatusSerializer : JsonConverter<AudioAnalysisStatus>
    {
        public override AudioAnalysisStatus Read(
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
            return new AudioAnalysisStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AudioAnalysisStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AudioAnalysisStatus ReadAsPropertyName(
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
            return new AudioAnalysisStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AudioAnalysisStatus value,
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
        public const string Processing = "processing";

        public const string Completed = "completed";

        public const string Failed = "failed";
    }
}
