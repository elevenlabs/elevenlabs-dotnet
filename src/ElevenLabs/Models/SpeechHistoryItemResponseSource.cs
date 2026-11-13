using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(SpeechHistoryItemResponseSource.SpeechHistoryItemResponseSourceSerializer))]
[Serializable]
public readonly record struct SpeechHistoryItemResponseSource : IStringEnum
{
    public static readonly SpeechHistoryItemResponseSource Tts = new(Values.Tts);

    public static readonly SpeechHistoryItemResponseSource Sts = new(Values.Sts);

    public static readonly SpeechHistoryItemResponseSource Projects = new(Values.Projects);

    public static readonly SpeechHistoryItemResponseSource Pd = new(Values.Pd);

    public static readonly SpeechHistoryItemResponseSource An = new(Values.An);

    public static readonly SpeechHistoryItemResponseSource Dubbing = new(Values.Dubbing);

    public static readonly SpeechHistoryItemResponseSource PlayApi = new(Values.PlayApi);

    public static readonly SpeechHistoryItemResponseSource ConvAi = new(Values.ConvAi);

    public static readonly SpeechHistoryItemResponseSource VoiceGeneration = new(
        Values.VoiceGeneration
    );

    public static readonly SpeechHistoryItemResponseSource InVpc = new(Values.InVpc);

    public static readonly SpeechHistoryItemResponseSource Flows = new(Values.Flows);

    public static readonly SpeechHistoryItemResponseSource VoicePreview = new(Values.VoicePreview);

    public SpeechHistoryItemResponseSource(string value)
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
    public static SpeechHistoryItemResponseSource FromCustom(string value)
    {
        return new SpeechHistoryItemResponseSource(value);
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

    public static bool operator ==(SpeechHistoryItemResponseSource value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SpeechHistoryItemResponseSource value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SpeechHistoryItemResponseSource value) => value.Value;

    public static explicit operator SpeechHistoryItemResponseSource(string value) => new(value);

    internal class SpeechHistoryItemResponseSourceSerializer
        : JsonConverter<SpeechHistoryItemResponseSource>
    {
        public override SpeechHistoryItemResponseSource Read(
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
            return new SpeechHistoryItemResponseSource(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SpeechHistoryItemResponseSource value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SpeechHistoryItemResponseSource ReadAsPropertyName(
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
            return new SpeechHistoryItemResponseSource(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SpeechHistoryItemResponseSource value,
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
        public const string Tts = "TTS";

        public const string Sts = "STS";

        public const string Projects = "Projects";

        public const string Pd = "PD";

        public const string An = "AN";

        public const string Dubbing = "Dubbing";

        public const string PlayApi = "PlayAPI";

        public const string ConvAi = "ConvAI";

        public const string VoiceGeneration = "VoiceGeneration";

        public const string InVpc = "InVPC";

        public const string Flows = "Flows";

        public const string VoicePreview = "VoicePreview";
    }
}
