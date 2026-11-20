using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(WebhookTypes.WebhookTypesSerializer))]
[Serializable]
public readonly record struct WebhookTypes : IStringEnum
{
    public static readonly WebhookTypes ProjectConversionStatus = new(
        Values.ProjectConversionStatus
    );

    public static readonly WebhookTypes ChapterConversionStatus = new(
        Values.ChapterConversionStatus
    );

    public static readonly WebhookTypes PostCallTranscription = new(Values.PostCallTranscription);

    public static readonly WebhookTypes PostCallTranscriptionOtel = new(
        Values.PostCallTranscriptionOtel
    );

    public static readonly WebhookTypes PostCallAudio = new(Values.PostCallAudio);

    public static readonly WebhookTypes PostCallUnredactedTranscription = new(
        Values.PostCallUnredactedTranscription
    );

    public static readonly WebhookTypes PostCallUnredactedTranscriptionOtel = new(
        Values.PostCallUnredactedTranscriptionOtel
    );

    public static readonly WebhookTypes PostCallUnredactedAudio = new(
        Values.PostCallUnredactedAudio
    );

    public static readonly WebhookTypes PostCallAnalysis = new(Values.PostCallAnalysis);

    public static readonly WebhookTypes CallInitiationFailure = new(Values.CallInitiationFailure);

    public static readonly WebhookTypes ConversationInitiationClientData = new(
        Values.ConversationInitiationClientData
    );

    public static readonly WebhookTypes AnsweringMachineDetection = new(
        Values.AnsweringMachineDetection
    );

    public static readonly WebhookTypes VoiceRemovalNotice = new(Values.VoiceRemovalNotice);

    public static readonly WebhookTypes VoiceRemovalNoticeWithdrawn = new(
        Values.VoiceRemovalNoticeWithdrawn
    );

    public static readonly WebhookTypes VoiceRemoved = new(Values.VoiceRemoved);

    public static readonly WebhookTypes SpeechToTextTranscription = new(
        Values.SpeechToTextTranscription
    );

    public static readonly WebhookTypes WebhookError = new(Values.WebhookError);

    public static readonly WebhookTypes SpeechToTextBatch = new(Values.SpeechToTextBatch);

    public static readonly WebhookTypes AgentQaEvaluationCompleted = new(
        Values.AgentQaEvaluationCompleted
    );

    public static readonly WebhookTypes ConvaiAlertingNotification = new(
        Values.ConvaiAlertingNotification
    );

    public static readonly WebhookTypes FlowsGeneration = new(Values.FlowsGeneration);

    public static readonly WebhookTypes FlowsTemplateRun = new(Values.FlowsTemplateRun);

    public static readonly WebhookTypes DubbingProjectReady = new(Values.DubbingProjectReady);

    public static readonly WebhookTypes DubbingProjectFailed = new(Values.DubbingProjectFailed);

    public static readonly WebhookTypes DubbingLanguageCompleted = new(
        Values.DubbingLanguageCompleted
    );

    public static readonly WebhookTypes DubbingLanguageFailed = new(Values.DubbingLanguageFailed);

    public static readonly WebhookTypes SupportTicketMessageAdded = new(
        Values.SupportTicketMessageAdded
    );

    public WebhookTypes(string value)
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
    public static WebhookTypes FromCustom(string value)
    {
        return new WebhookTypes(value);
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

    public static bool operator ==(WebhookTypes value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(WebhookTypes value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(WebhookTypes value) => value.Value;

    public static explicit operator WebhookTypes(string value) => new(value);

    internal class WebhookTypesSerializer : JsonConverter<WebhookTypes>
    {
        public override WebhookTypes Read(
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
            return new WebhookTypes(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WebhookTypes value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WebhookTypes ReadAsPropertyName(
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
            return new WebhookTypes(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WebhookTypes value,
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
        public const string ProjectConversionStatus = "project_conversion_status";

        public const string ChapterConversionStatus = "chapter_conversion_status";

        public const string PostCallTranscription = "post_call_transcription";

        public const string PostCallTranscriptionOtel = "post_call_transcription_otel";

        public const string PostCallAudio = "post_call_audio";

        public const string PostCallUnredactedTranscription = "post_call_unredacted_transcription";

        public const string PostCallUnredactedTranscriptionOtel =
            "post_call_unredacted_transcription_otel";

        public const string PostCallUnredactedAudio = "post_call_unredacted_audio";

        public const string PostCallAnalysis = "post_call_analysis";

        public const string CallInitiationFailure = "call_initiation_failure";

        public const string ConversationInitiationClientData =
            "conversation_initiation_client_data";

        public const string AnsweringMachineDetection = "answering_machine_detection";

        public const string VoiceRemovalNotice = "voice_removal_notice";

        public const string VoiceRemovalNoticeWithdrawn = "voice_removal_notice_withdrawn";

        public const string VoiceRemoved = "voice_removed";

        public const string SpeechToTextTranscription = "speech_to_text_transcription";

        public const string WebhookError = "webhook_error";

        public const string SpeechToTextBatch = "speech_to_text_batch";

        public const string AgentQaEvaluationCompleted = "agent_qa_evaluation_completed";

        public const string ConvaiAlertingNotification = "convai_alerting_notification";

        public const string FlowsGeneration = "flows_generation";

        public const string FlowsTemplateRun = "flows_template_run";

        public const string DubbingProjectReady = "dubbing_project_ready";

        public const string DubbingProjectFailed = "dubbing_project_failed";

        public const string DubbingLanguageCompleted = "dubbing_language_completed";

        public const string DubbingLanguageFailed = "dubbing_language_failed";

        public const string SupportTicketMessageAdded = "support_ticket_message_added";
    }
}
