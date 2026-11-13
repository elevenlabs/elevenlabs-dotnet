using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(WebhookEventType.WebhookEventTypeSerializer))]
[Serializable]
public readonly record struct WebhookEventType : IStringEnum
{
    public static readonly WebhookEventType Transcript = new(Values.Transcript);

    public static readonly WebhookEventType Audio = new(Values.Audio);

    public static readonly WebhookEventType CallInitiationFailure = new(
        Values.CallInitiationFailure
    );

    public static readonly WebhookEventType AnsweringMachineDetection = new(
        Values.AnsweringMachineDetection
    );

    public static readonly WebhookEventType UnredactedTranscript = new(Values.UnredactedTranscript);

    public static readonly WebhookEventType UnredactedAudio = new(Values.UnredactedAudio);

    public WebhookEventType(string value)
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
    public static WebhookEventType FromCustom(string value)
    {
        return new WebhookEventType(value);
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

    public static bool operator ==(WebhookEventType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(WebhookEventType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(WebhookEventType value) => value.Value;

    public static explicit operator WebhookEventType(string value) => new(value);

    internal class WebhookEventTypeSerializer : JsonConverter<WebhookEventType>
    {
        public override WebhookEventType Read(
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
            return new WebhookEventType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WebhookEventType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WebhookEventType ReadAsPropertyName(
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
            return new WebhookEventType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WebhookEventType value,
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
        public const string Transcript = "transcript";

        public const string Audio = "audio";

        public const string CallInitiationFailure = "call_initiation_failure";

        public const string AnsweringMachineDetection = "answering_machine_detection";

        public const string UnredactedTranscript = "unredacted_transcript";

        public const string UnredactedAudio = "unredacted_audio";
    }
}
