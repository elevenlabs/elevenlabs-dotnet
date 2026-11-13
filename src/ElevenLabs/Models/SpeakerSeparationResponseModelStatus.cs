using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The status of the speaker separation.</summary>
[JsonConverter(
    typeof(SpeakerSeparationResponseModelStatus.SpeakerSeparationResponseModelStatusSerializer)
)]
[Serializable]
public readonly record struct SpeakerSeparationResponseModelStatus : IStringEnum
{
    public static readonly SpeakerSeparationResponseModelStatus NotStarted = new(Values.NotStarted);

    public static readonly SpeakerSeparationResponseModelStatus Pending = new(Values.Pending);

    public static readonly SpeakerSeparationResponseModelStatus Completed = new(Values.Completed);

    public static readonly SpeakerSeparationResponseModelStatus Failed = new(Values.Failed);

    public SpeakerSeparationResponseModelStatus(string value)
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
    public static SpeakerSeparationResponseModelStatus FromCustom(string value)
    {
        return new SpeakerSeparationResponseModelStatus(value);
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

    public static bool operator ==(SpeakerSeparationResponseModelStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SpeakerSeparationResponseModelStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SpeakerSeparationResponseModelStatus value) =>
        value.Value;

    public static explicit operator SpeakerSeparationResponseModelStatus(string value) =>
        new(value);

    internal class SpeakerSeparationResponseModelStatusSerializer
        : JsonConverter<SpeakerSeparationResponseModelStatus>
    {
        public override SpeakerSeparationResponseModelStatus Read(
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
            return new SpeakerSeparationResponseModelStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SpeakerSeparationResponseModelStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SpeakerSeparationResponseModelStatus ReadAsPropertyName(
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
            return new SpeakerSeparationResponseModelStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SpeakerSeparationResponseModelStatus value,
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
        public const string NotStarted = "not_started";

        public const string Pending = "pending";

        public const string Completed = "completed";

        public const string Failed = "failed";
    }
}
