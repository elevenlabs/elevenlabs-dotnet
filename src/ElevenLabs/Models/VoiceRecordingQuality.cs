using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(VoiceRecordingQuality.VoiceRecordingQualitySerializer))]
[Serializable]
public readonly record struct VoiceRecordingQuality : IStringEnum
{
    public static readonly VoiceRecordingQuality Studio = new(Values.Studio);

    public static readonly VoiceRecordingQuality Good = new(Values.Good);

    public static readonly VoiceRecordingQuality Ok = new(Values.Ok);

    public static readonly VoiceRecordingQuality Poor = new(Values.Poor);

    public static readonly VoiceRecordingQuality Bad = new(Values.Bad);

    public VoiceRecordingQuality(string value)
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
    public static VoiceRecordingQuality FromCustom(string value)
    {
        return new VoiceRecordingQuality(value);
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

    public static bool operator ==(VoiceRecordingQuality value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(VoiceRecordingQuality value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(VoiceRecordingQuality value) => value.Value;

    public static explicit operator VoiceRecordingQuality(string value) => new(value);

    internal class VoiceRecordingQualitySerializer : JsonConverter<VoiceRecordingQuality>
    {
        public override VoiceRecordingQuality Read(
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
            return new VoiceRecordingQuality(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            VoiceRecordingQuality value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override VoiceRecordingQuality ReadAsPropertyName(
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
            return new VoiceRecordingQuality(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            VoiceRecordingQuality value,
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
        public const string Studio = "studio";

        public const string Good = "good";

        public const string Ok = "ok";

        public const string Poor = "poor";

        public const string Bad = "bad";
    }
}
