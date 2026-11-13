using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(WorkspaceWebhookEventType.WorkspaceWebhookEventTypeSerializer))]
[Serializable]
public readonly record struct WorkspaceWebhookEventType : IStringEnum
{
    public static readonly WorkspaceWebhookEventType VoiceLibraryRemovalNotice = new(
        Values.VoiceLibraryRemovalNotice
    );

    public static readonly WorkspaceWebhookEventType SpeechToText = new(Values.SpeechToText);

    public static readonly WorkspaceWebhookEventType AgentQa = new(Values.AgentQa);

    public static readonly WorkspaceWebhookEventType Flows = new(Values.Flows);

    public WorkspaceWebhookEventType(string value)
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
    public static WorkspaceWebhookEventType FromCustom(string value)
    {
        return new WorkspaceWebhookEventType(value);
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

    public static bool operator ==(WorkspaceWebhookEventType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(WorkspaceWebhookEventType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(WorkspaceWebhookEventType value) => value.Value;

    public static explicit operator WorkspaceWebhookEventType(string value) => new(value);

    internal class WorkspaceWebhookEventTypeSerializer : JsonConverter<WorkspaceWebhookEventType>
    {
        public override WorkspaceWebhookEventType Read(
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
            return new WorkspaceWebhookEventType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WorkspaceWebhookEventType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WorkspaceWebhookEventType ReadAsPropertyName(
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
            return new WorkspaceWebhookEventType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WorkspaceWebhookEventType value,
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
        public const string VoiceLibraryRemovalNotice = "voice_library_removal_notice";

        public const string SpeechToText = "speech_to_text";

        public const string AgentQa = "agent_qa";

        public const string Flows = "flows";
    }
}
