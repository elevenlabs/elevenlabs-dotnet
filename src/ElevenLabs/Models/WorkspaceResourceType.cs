using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Workspace;

/// <summary>Resource types that can be shared in the workspace. The name always need to match the collection names</summary>
[JsonConverter(typeof(WorkspaceResourceType.WorkspaceResourceTypeSerializer))]
[Serializable]
public readonly record struct WorkspaceResourceType : IStringEnum
{
    public static readonly WorkspaceResourceType Voice = new(Values.Voice);

    public static readonly WorkspaceResourceType VoiceCollection = new(Values.VoiceCollection);

    public static readonly WorkspaceResourceType PronunciationDictionary = new(
        Values.PronunciationDictionary
    );

    public static readonly WorkspaceResourceType Dubbing = new(Values.Dubbing);

    public static readonly WorkspaceResourceType DubbingProject = new(Values.DubbingProject);

    public static readonly WorkspaceResourceType Project = new(Values.Project);

    public static readonly WorkspaceResourceType ConvaiAgents = new(Values.ConvaiAgents);

    public static readonly WorkspaceResourceType ConvaiKnowledgeBaseDocuments = new(
        Values.ConvaiKnowledgeBaseDocuments
    );

    public static readonly WorkspaceResourceType ConvaiTools = new(Values.ConvaiTools);

    public static readonly WorkspaceResourceType ConvaiSettings = new(Values.ConvaiSettings);

    public static readonly WorkspaceResourceType ConvaiSecrets = new(Values.ConvaiSecrets);

    public static readonly WorkspaceResourceType WorkspaceAuthConnections = new(
        Values.WorkspaceAuthConnections
    );

    public static readonly WorkspaceResourceType ConvaiPhoneNumbers = new(
        Values.ConvaiPhoneNumbers
    );

    public static readonly WorkspaceResourceType ConvaiMcpServers = new(Values.ConvaiMcpServers);

    public static readonly WorkspaceResourceType ConvaiApiIntegrationConnections = new(
        Values.ConvaiApiIntegrationConnections
    );

    public static readonly WorkspaceResourceType ConvaiApiIntegrationTriggerConnections = new(
        Values.ConvaiApiIntegrationTriggerConnections
    );

    public static readonly WorkspaceResourceType ConvaiBatchCalls = new(Values.ConvaiBatchCalls);

    public static readonly WorkspaceResourceType ConvaiAgentResponseTests = new(
        Values.ConvaiAgentResponseTests
    );

    public static readonly WorkspaceResourceType ConvaiTestSuiteInvocations = new(
        Values.ConvaiTestSuiteInvocations
    );

    public static readonly WorkspaceResourceType ConvaiCrawlJobs = new(Values.ConvaiCrawlJobs);

    public static readonly WorkspaceResourceType ConvaiCrawlTasks = new(Values.ConvaiCrawlTasks);

    public static readonly WorkspaceResourceType ConvaiKbExternalSyncJobs = new(
        Values.ConvaiKbExternalSyncJobs
    );

    public static readonly WorkspaceResourceType ConvaiWhatsappAccounts = new(
        Values.ConvaiWhatsappAccounts
    );

    public static readonly WorkspaceResourceType ConvaiAgentVersions = new(
        Values.ConvaiAgentVersions
    );

    public static readonly WorkspaceResourceType ConvaiAgentBranches = new(
        Values.ConvaiAgentBranches
    );

    public static readonly WorkspaceResourceType ConvaiAgentVersionsDeployments = new(
        Values.ConvaiAgentVersionsDeployments
    );

    public static readonly WorkspaceResourceType ConvaiAgentExperiments = new(
        Values.ConvaiAgentExperiments
    );

    public static readonly WorkspaceResourceType ConvaiMemoryEntries = new(
        Values.ConvaiMemoryEntries
    );

    public static readonly WorkspaceResourceType ConvaiTemplates = new(Values.ConvaiTemplates);

    public static readonly WorkspaceResourceType Dashboard = new(Values.Dashboard);

    public static readonly WorkspaceResourceType DashboardConfiguration = new(
        Values.DashboardConfiguration
    );

    public static readonly WorkspaceResourceType ConvaiAgentDrafts = new(Values.ConvaiAgentDrafts);

    public static readonly WorkspaceResourceType ResourceLocators = new(Values.ResourceLocators);

    public static readonly WorkspaceResourceType Assets = new(Values.Assets);

    public static readonly WorkspaceResourceType ContentGenerations = new(
        Values.ContentGenerations
    );

    public static readonly WorkspaceResourceType ContentTemplates = new(Values.ContentTemplates);

    public static readonly WorkspaceResourceType ContentSkills = new(Values.ContentSkills);

    public static readonly WorkspaceResourceType Songs = new(Values.Songs);

    public static readonly WorkspaceResourceType TranscriptionTasks = new(
        Values.TranscriptionTasks
    );

    public static readonly WorkspaceResourceType Avatars = new(Values.Avatars);

    public static readonly WorkspaceResourceType AvatarVideoGenerations = new(
        Values.AvatarVideoGenerations
    );

    public static readonly WorkspaceResourceType ResourceCollection = new(
        Values.ResourceCollection
    );

    public static readonly WorkspaceResourceType StudioProjects = new(Values.StudioProjects);

    public static readonly WorkspaceResourceType ConvaiAnalysisItems = new(
        Values.ConvaiAnalysisItems
    );

    public WorkspaceResourceType(string value)
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
    public static WorkspaceResourceType FromCustom(string value)
    {
        return new WorkspaceResourceType(value);
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

    public static bool operator ==(WorkspaceResourceType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(WorkspaceResourceType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(WorkspaceResourceType value) => value.Value;

    public static explicit operator WorkspaceResourceType(string value) => new(value);

    internal class WorkspaceResourceTypeSerializer : JsonConverter<WorkspaceResourceType>
    {
        public override WorkspaceResourceType Read(
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
            return new WorkspaceResourceType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WorkspaceResourceType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WorkspaceResourceType ReadAsPropertyName(
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
            return new WorkspaceResourceType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WorkspaceResourceType value,
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
        public const string Voice = "voice";

        public const string VoiceCollection = "voice_collection";

        public const string PronunciationDictionary = "pronunciation_dictionary";

        public const string Dubbing = "dubbing";

        public const string DubbingProject = "dubbing_project";

        public const string Project = "project";

        public const string ConvaiAgents = "convai_agents";

        public const string ConvaiKnowledgeBaseDocuments = "convai_knowledge_base_documents";

        public const string ConvaiTools = "convai_tools";

        public const string ConvaiSettings = "convai_settings";

        public const string ConvaiSecrets = "convai_secrets";

        public const string WorkspaceAuthConnections = "workspace_auth_connections";

        public const string ConvaiPhoneNumbers = "convai_phone_numbers";

        public const string ConvaiMcpServers = "convai_mcp_servers";

        public const string ConvaiApiIntegrationConnections = "convai_api_integration_connections";

        public const string ConvaiApiIntegrationTriggerConnections =
            "convai_api_integration_trigger_connections";

        public const string ConvaiBatchCalls = "convai_batch_calls";

        public const string ConvaiAgentResponseTests = "convai_agent_response_tests";

        public const string ConvaiTestSuiteInvocations = "convai_test_suite_invocations";

        public const string ConvaiCrawlJobs = "convai_crawl_jobs";

        public const string ConvaiCrawlTasks = "convai_crawl_tasks";

        public const string ConvaiKbExternalSyncJobs = "convai_kb_external_sync_jobs";

        public const string ConvaiWhatsappAccounts = "convai_whatsapp_accounts";

        public const string ConvaiAgentVersions = "convai_agent_versions";

        public const string ConvaiAgentBranches = "convai_agent_branches";

        public const string ConvaiAgentVersionsDeployments = "convai_agent_versions_deployments";

        public const string ConvaiAgentExperiments = "convai_agent_experiments";

        public const string ConvaiMemoryEntries = "convai_memory_entries";

        public const string ConvaiTemplates = "convai_templates";

        public const string Dashboard = "dashboard";

        public const string DashboardConfiguration = "dashboard_configuration";

        public const string ConvaiAgentDrafts = "convai_agent_drafts";

        public const string ResourceLocators = "resource_locators";

        public const string Assets = "assets";

        public const string ContentGenerations = "content_generations";

        public const string ContentTemplates = "content_templates";

        public const string ContentSkills = "content_skills";

        public const string Songs = "songs";

        public const string TranscriptionTasks = "transcription_tasks";

        public const string Avatars = "avatars";

        public const string AvatarVideoGenerations = "avatar_video_generations";

        public const string ResourceCollection = "resource_collection";

        public const string StudioProjects = "studio_projects";

        public const string ConvaiAnalysisItems = "convai_analysis_items";
    }
}
