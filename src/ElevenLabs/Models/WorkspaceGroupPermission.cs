using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(WorkspaceGroupPermission.WorkspaceGroupPermissionSerializer))]
[Serializable]
public readonly record struct WorkspaceGroupPermission : IStringEnum
{
    public static readonly WorkspaceGroupPermission TextToSpeech = new(Values.TextToSpeech);

    public static readonly WorkspaceGroupPermission SpeechToSpeech = new(Values.SpeechToSpeech);

    public static readonly WorkspaceGroupPermission SpeechToText = new(Values.SpeechToText);

    public static readonly WorkspaceGroupPermission VoiceLab = new(Values.VoiceLab);

    public static readonly WorkspaceGroupPermission SoundEffects = new(Values.SoundEffects);

    public static readonly WorkspaceGroupPermission Projects = new(Values.Projects);

    public static readonly WorkspaceGroupPermission VoiceoverStudio = new(Values.VoiceoverStudio);

    public static readonly WorkspaceGroupPermission Dubbing = new(Values.Dubbing);

    public static readonly WorkspaceGroupPermission AudioNative = new(Values.AudioNative);

    public static readonly WorkspaceGroupPermission ConversationalAi = new(Values.ConversationalAi);

    public static readonly WorkspaceGroupPermission ConversationalAiRead = new(
        Values.ConversationalAiRead
    );

    public static readonly WorkspaceGroupPermission Architect = new(Values.Architect);

    public static readonly WorkspaceGroupPermission VoiceIsolator = new(Values.VoiceIsolator);

    public static readonly WorkspaceGroupPermission AiSpeechClassifier = new(
        Values.AiSpeechClassifier
    );

    public static readonly WorkspaceGroupPermission SynthidDetector = new(Values.SynthidDetector);

    public static readonly WorkspaceGroupPermission AddVoiceFromVoiceLibrary = new(
        Values.AddVoiceFromVoiceLibrary
    );

    public static readonly WorkspaceGroupPermission CreateInstantVoiceClone = new(
        Values.CreateInstantVoiceClone
    );

    public static readonly WorkspaceGroupPermission CreateProfessionalVoiceClone = new(
        Values.CreateProfessionalVoiceClone
    );

    public static readonly WorkspaceGroupPermission CreateUserApiKey = new(Values.CreateUserApiKey);

    public static readonly WorkspaceGroupPermission PublishStudioProject = new(
        Values.PublishStudioProject
    );

    public static readonly WorkspaceGroupPermission Music = new(Values.Music);

    public static readonly WorkspaceGroupPermission ImageVideoGeneration = new(
        Values.ImageVideoGeneration
    );

    public static readonly WorkspaceGroupPermission Flows = new(Values.Flows);

    public static readonly WorkspaceGroupPermission Templates = new(Values.Templates);

    public static readonly WorkspaceGroupPermission ShareVoiceExternally = new(
        Values.ShareVoiceExternally
    );

    public static readonly WorkspaceGroupPermission PublishVoiceToVoiceLibrary = new(
        Values.PublishVoiceToVoiceLibrary
    );

    public static readonly WorkspaceGroupPermission ViewFiatBalance = new(Values.ViewFiatBalance);

    public static readonly WorkspaceGroupPermission WorkspaceAnalyticsFullRead = new(
        Values.WorkspaceAnalyticsFullRead
    );

    public static readonly WorkspaceGroupPermission ServiceAccountsManage = new(
        Values.ServiceAccountsManage
    );

    public static readonly WorkspaceGroupPermission WebhooksManage = new(Values.WebhooksManage);

    public static readonly WorkspaceGroupPermission GroupMembersManage = new(
        Values.GroupMembersManage
    );

    public static readonly WorkspaceGroupPermission WorkspaceMembersInvite = new(
        Values.WorkspaceMembersInvite
    );

    public static readonly WorkspaceGroupPermission WorkspaceMembersRemove = new(
        Values.WorkspaceMembersRemove
    );

    public static readonly WorkspaceGroupPermission TermsOfServiceAccept = new(
        Values.TermsOfServiceAccept
    );

    public static readonly WorkspaceGroupPermission AuditLogRead = new(Values.AuditLogRead);

    public static readonly WorkspaceGroupPermission ConversationPrivacyManage = new(
        Values.ConversationPrivacyManage
    );

    public static readonly WorkspaceGroupPermission AllResourcesAccess = new(
        Values.AllResourcesAccess
    );

    public static readonly WorkspaceGroupPermission CopyResourcesCrossWorkspace = new(
        Values.CopyResourcesCrossWorkspace
    );

    public static readonly WorkspaceGroupPermission VoiceDesign = new(Values.VoiceDesign);

    public WorkspaceGroupPermission(string value)
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
    public static WorkspaceGroupPermission FromCustom(string value)
    {
        return new WorkspaceGroupPermission(value);
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

    public static bool operator ==(WorkspaceGroupPermission value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(WorkspaceGroupPermission value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(WorkspaceGroupPermission value) => value.Value;

    public static explicit operator WorkspaceGroupPermission(string value) => new(value);

    internal class WorkspaceGroupPermissionSerializer : JsonConverter<WorkspaceGroupPermission>
    {
        public override WorkspaceGroupPermission Read(
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
            return new WorkspaceGroupPermission(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WorkspaceGroupPermission value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WorkspaceGroupPermission ReadAsPropertyName(
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
            return new WorkspaceGroupPermission(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WorkspaceGroupPermission value,
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
        public const string TextToSpeech = "text_to_speech";

        public const string SpeechToSpeech = "speech_to_speech";

        public const string SpeechToText = "speech_to_text";

        public const string VoiceLab = "voice_lab";

        public const string SoundEffects = "sound_effects";

        public const string Projects = "projects";

        public const string VoiceoverStudio = "voiceover_studio";

        public const string Dubbing = "dubbing";

        public const string AudioNative = "audio_native";

        public const string ConversationalAi = "conversational_ai";

        public const string ConversationalAiRead = "conversational_ai_read";

        public const string Architect = "architect";

        public const string VoiceIsolator = "voice_isolator";

        public const string AiSpeechClassifier = "ai_speech_classifier";

        public const string SynthidDetector = "synthid_detector";

        public const string AddVoiceFromVoiceLibrary = "add_voice_from_voice_library";

        public const string CreateInstantVoiceClone = "create_instant_voice_clone";

        public const string CreateProfessionalVoiceClone = "create_professional_voice_clone";

        public const string CreateUserApiKey = "create_user_api_key";

        public const string PublishStudioProject = "publish_studio_project";

        public const string Music = "music";

        public const string ImageVideoGeneration = "image_video_generation";

        public const string Flows = "flows";

        public const string Templates = "templates";

        public const string ShareVoiceExternally = "share_voice_externally";

        public const string PublishVoiceToVoiceLibrary = "publish_voice_to_voice_library";

        public const string ViewFiatBalance = "view_fiat_balance";

        public const string WorkspaceAnalyticsFullRead = "workspace_analytics_full_read";

        public const string ServiceAccountsManage = "service_accounts_manage";

        public const string WebhooksManage = "webhooks_manage";

        public const string GroupMembersManage = "group_members_manage";

        public const string WorkspaceMembersInvite = "workspace_members_invite";

        public const string WorkspaceMembersRemove = "workspace_members_remove";

        public const string TermsOfServiceAccept = "terms_of_service_accept";

        public const string AuditLogRead = "audit_log_read";

        public const string ConversationPrivacyManage = "conversation_privacy_manage";

        public const string AllResourcesAccess = "all_resources_access";

        public const string CopyResourcesCrossWorkspace = "copy_resources_cross_workspace";

        public const string VoiceDesign = "voice_design";
    }
}
