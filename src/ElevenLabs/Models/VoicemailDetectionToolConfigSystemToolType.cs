using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(VoicemailDetectionToolConfigSystemToolType.VoicemailDetectionToolConfigSystemToolTypeSerializer)
)]
[Serializable]
public readonly record struct VoicemailDetectionToolConfigSystemToolType : IStringEnum
{
    public static readonly VoicemailDetectionToolConfigSystemToolType VoicemailDetection = new(
        Values.VoicemailDetection
    );

    public VoicemailDetectionToolConfigSystemToolType(string value)
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
    public static VoicemailDetectionToolConfigSystemToolType FromCustom(string value)
    {
        return new VoicemailDetectionToolConfigSystemToolType(value);
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
        VoicemailDetectionToolConfigSystemToolType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        VoicemailDetectionToolConfigSystemToolType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(VoicemailDetectionToolConfigSystemToolType value) =>
        value.Value;

    public static explicit operator VoicemailDetectionToolConfigSystemToolType(string value) =>
        new(value);

    internal class VoicemailDetectionToolConfigSystemToolTypeSerializer
        : JsonConverter<VoicemailDetectionToolConfigSystemToolType>
    {
        public override VoicemailDetectionToolConfigSystemToolType Read(
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
            return new VoicemailDetectionToolConfigSystemToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            VoicemailDetectionToolConfigSystemToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override VoicemailDetectionToolConfigSystemToolType ReadAsPropertyName(
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
            return new VoicemailDetectionToolConfigSystemToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            VoicemailDetectionToolConfigSystemToolType value,
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
        public const string VoicemailDetection = "voicemail_detection";
    }
}
