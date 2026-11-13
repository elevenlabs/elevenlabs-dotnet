using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(PermissionType.PermissionTypeSerializer))]
[Serializable]
public readonly record struct PermissionType : IStringEnum
{
    public static readonly PermissionType TextToSpeech = new(Values.TextToSpeech);

    public static readonly PermissionType SpeechToSpeech = new(Values.SpeechToSpeech);

    public static readonly PermissionType SpeechToText = new(Values.SpeechToText);

    public static readonly PermissionType ModelsRead = new(Values.ModelsRead);

    public static readonly PermissionType ModelsWrite = new(Values.ModelsWrite);

    public static readonly PermissionType VoicesRead = new(Values.VoicesRead);

    public static readonly PermissionType VoicesWrite = new(Values.VoicesWrite);

    public static readonly PermissionType VoiceCollectionsRead = new(Values.VoiceCollectionsRead);

    public static readonly PermissionType VoiceCollectionsWrite = new(Values.VoiceCollectionsWrite);

    public static readonly PermissionType SpeechHistoryRead = new(Values.SpeechHistoryRead);

    public static readonly PermissionType SpeechHistoryWrite = new(Values.SpeechHistoryWrite);

    public static readonly PermissionType SoundGeneration = new(Values.SoundGeneration);

    public static readonly PermissionType AudioIsolation = new(Values.AudioIsolation);

    public static readonly PermissionType VoiceGeneration = new(Values.VoiceGeneration);

    public static readonly PermissionType DubbingRead = new(Values.DubbingRead);

    public static readonly PermissionType DubbingWrite = new(Values.DubbingWrite);

    public static readonly PermissionType PronunciationDictionariesRead = new(
        Values.PronunciationDictionariesRead
    );

    public static readonly PermissionType PronunciationDictionariesWrite = new(
        Values.PronunciationDictionariesWrite
    );

    public static readonly PermissionType UserRead = new(Values.UserRead);

    public static readonly PermissionType UserWrite = new(Values.UserWrite);

    public static readonly PermissionType ProjectsRead = new(Values.ProjectsRead);

    public static readonly PermissionType ProjectsWrite = new(Values.ProjectsWrite);

    public static readonly PermissionType AudioNativeRead = new(Values.AudioNativeRead);

    public static readonly PermissionType AudioNativeWrite = new(Values.AudioNativeWrite);

    public static readonly PermissionType WorkspaceRead = new(Values.WorkspaceRead);

    public static readonly PermissionType WorkspaceWrite = new(Values.WorkspaceWrite);

    public static readonly PermissionType ForcedAlignment = new(Values.ForcedAlignment);

    public static readonly PermissionType ConvaiRead = new(Values.ConvaiRead);

    public static readonly PermissionType ConvaiWrite = new(Values.ConvaiWrite);

    public static readonly PermissionType AgentsArchitect = new(Values.AgentsArchitect);

    public static readonly PermissionType MusicGeneration = new(Values.MusicGeneration);

    public static readonly PermissionType ImageVideoGeneration = new(Values.ImageVideoGeneration);

    public static readonly PermissionType Flows = new(Values.Flows);

    public static readonly PermissionType Templates = new(Values.Templates);

    public static readonly PermissionType AddVoiceFromVoiceLibrary = new(
        Values.AddVoiceFromVoiceLibrary
    );

    public static readonly PermissionType CreateInstantVoiceClone = new(
        Values.CreateInstantVoiceClone
    );

    public static readonly PermissionType CreateProfessionalVoiceClone = new(
        Values.CreateProfessionalVoiceClone
    );

    public static readonly PermissionType PublishVoiceToVoiceLibrary = new(
        Values.PublishVoiceToVoiceLibrary
    );

    public static readonly PermissionType ShareVoiceExternally = new(Values.ShareVoiceExternally);

    public static readonly PermissionType CreateUserApiKey = new(Values.CreateUserApiKey);

    public static readonly PermissionType WorkspaceAnalyticsFullRead = new(
        Values.WorkspaceAnalyticsFullRead
    );

    public static readonly PermissionType WebhooksWrite = new(Values.WebhooksWrite);

    public static readonly PermissionType ServiceAccountWrite = new(Values.ServiceAccountWrite);

    public static readonly PermissionType GroupMembersManage = new(Values.GroupMembersManage);

    public static readonly PermissionType WorkspaceMembersRead = new(Values.WorkspaceMembersRead);

    public static readonly PermissionType WorkspaceMembersInvite = new(
        Values.WorkspaceMembersInvite
    );

    public static readonly PermissionType WorkspaceMembersRemove = new(
        Values.WorkspaceMembersRemove
    );

    public static readonly PermissionType TermsOfServiceAccept = new(Values.TermsOfServiceAccept);

    public static readonly PermissionType AuditLogRead = new(Values.AuditLogRead);

    public static readonly PermissionType ConversationPrivacyManage = new(
        Values.ConversationPrivacyManage
    );

    public static readonly PermissionType CopyResourcesCrossWorkspace = new(
        Values.CopyResourcesCrossWorkspace
    );

    public static readonly PermissionType SynthidDetector = new(Values.SynthidDetector);

    public PermissionType(string value)
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
    public static PermissionType FromCustom(string value)
    {
        return new PermissionType(value);
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

    public static bool operator ==(PermissionType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PermissionType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PermissionType value) => value.Value;

    public static explicit operator PermissionType(string value) => new(value);

    internal class PermissionTypeSerializer : JsonConverter<PermissionType>
    {
        public override PermissionType Read(
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
            return new PermissionType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PermissionType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PermissionType ReadAsPropertyName(
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
            return new PermissionType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PermissionType value,
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

        public const string ModelsRead = "models_read";

        public const string ModelsWrite = "models_write";

        public const string VoicesRead = "voices_read";

        public const string VoicesWrite = "voices_write";

        public const string VoiceCollectionsRead = "voice_collections_read";

        public const string VoiceCollectionsWrite = "voice_collections_write";

        public const string SpeechHistoryRead = "speech_history_read";

        public const string SpeechHistoryWrite = "speech_history_write";

        public const string SoundGeneration = "sound_generation";

        public const string AudioIsolation = "audio_isolation";

        public const string VoiceGeneration = "voice_generation";

        public const string DubbingRead = "dubbing_read";

        public const string DubbingWrite = "dubbing_write";

        public const string PronunciationDictionariesRead = "pronunciation_dictionaries_read";

        public const string PronunciationDictionariesWrite = "pronunciation_dictionaries_write";

        public const string UserRead = "user_read";

        public const string UserWrite = "user_write";

        public const string ProjectsRead = "projects_read";

        public const string ProjectsWrite = "projects_write";

        public const string AudioNativeRead = "audio_native_read";

        public const string AudioNativeWrite = "audio_native_write";

        public const string WorkspaceRead = "workspace_read";

        public const string WorkspaceWrite = "workspace_write";

        public const string ForcedAlignment = "forced_alignment";

        public const string ConvaiRead = "convai_read";

        public const string ConvaiWrite = "convai_write";

        public const string AgentsArchitect = "agents_architect";

        public const string MusicGeneration = "music_generation";

        public const string ImageVideoGeneration = "image_video_generation";

        public const string Flows = "flows";

        public const string Templates = "templates";

        public const string AddVoiceFromVoiceLibrary = "add_voice_from_voice_library";

        public const string CreateInstantVoiceClone = "create_instant_voice_clone";

        public const string CreateProfessionalVoiceClone = "create_professional_voice_clone";

        public const string PublishVoiceToVoiceLibrary = "publish_voice_to_voice_library";

        public const string ShareVoiceExternally = "share_voice_externally";

        public const string CreateUserApiKey = "create_user_api_key";

        public const string WorkspaceAnalyticsFullRead = "workspace_analytics_full_read";

        public const string WebhooksWrite = "webhooks_write";

        public const string ServiceAccountWrite = "service_account_write";

        public const string GroupMembersManage = "group_members_manage";

        public const string WorkspaceMembersRead = "workspace_members_read";

        public const string WorkspaceMembersInvite = "workspace_members_invite";

        public const string WorkspaceMembersRemove = "workspace_members_remove";

        public const string TermsOfServiceAccept = "terms_of_service_accept";

        public const string AuditLogRead = "audit_log_read";

        public const string ConversationPrivacyManage = "conversation_privacy_manage";

        public const string CopyResourcesCrossWorkspace = "copy_resources_cross_workspace";

        public const string SynthidDetector = "synthid_detector";
    }
}
