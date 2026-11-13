using ElevenLabs.Agents;
using ElevenLabs.Agents.Conversations;
using ElevenLabs.Agents.Dashboard;
using ElevenLabs.Agents.KnowledgeBase;
using ElevenLabs.Agents.McpServers;
using ElevenLabs.Agents.OutboundCampaigns;
using ElevenLabs.Agents.Procedures;
using ElevenLabs.Agents.Tests;
using ElevenLabs.Agents.Widget;
using ElevenLabs.Core;
using ElevenLabs.Dubbing;
using ElevenLabs.Dubbing.Project;
using ElevenLabs.Dubbing.Project.Language;
using ElevenLabs.EnvironmentVariables;
using ElevenLabs.Flows;
using ElevenLabs.Flows.Templates;
using ElevenLabs.History;
using ElevenLabs.Music;
using ElevenLabs.Productions;
using ElevenLabs.Productions.Orders;
using ElevenLabs.PronunciationDictionaries;
using ElevenLabs.ServiceAccounts;
using ElevenLabs.SpeechEngine;
using ElevenLabs.Studio;
using ElevenLabs.Studio.Projects;
using ElevenLabs.Studio.Projects.Chapters;
using ElevenLabs.Tokens;
using ElevenLabs.Voices;
using ElevenLabs.Voices.Pvc;
using ElevenLabs.Voices.Pvc.Verification;
using ElevenLabs.Workspace;
using ElevenLabs.Workspace.Analytics;
using ElevenLabs.Workspace.Groups;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[Serializable]
public record GetAgentResponseModel : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>The ID of the agent</value>
    [JsonPropertyName("agent_id")]
    public required string AgentId { get; set; }

    /// <value>The name of the agent</value>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("conversation_config")]
    public required ConversationalConfig ConversationConfig { get; set; }

    [JsonPropertyName("metadata")]
    public required AgentMetadataResponseModel Metadata { get; set; }

    [JsonPropertyName("platform_settings")]
    public AgentPlatformSettingsResponseModel? PlatformSettings { get; set; }

    /// <value>The phone numbers of the agent</value>
    [JsonPropertyName("phone_numbers")]
    public IEnumerable<GetAgentResponseModelPhoneNumbersItem>? PhoneNumbers { get; set; }

    /// <value>WhatsApp accounts assigned to the agent</value>
    [JsonPropertyName("whatsapp_accounts")]
    public IEnumerable<GetWhatsAppAccountResponse>? WhatsappAccounts { get; set; }

    [JsonPropertyName("workflow")]
    public AgentWorkflowResponseModel? Workflow { get; set; }

    /// <value>The access information of the agent for the user</value>
    [JsonPropertyName("access_info")]
    public ResourceAccessInfo? AccessInfo { get; set; }

    /// <value>Agent tags used to categorize the agent</value>
    [JsonPropertyName("tags")]
    public IEnumerable<string>? Tags { get; set; }

    /// <value>The ID of the version the agent is on</value>
    [JsonPropertyName("version_id")]
    public string? VersionId { get; set; }

    /// <value>The ID of the branch the agent is on</value>
    [JsonPropertyName("branch_id")]
    public string? BranchId { get; set; }

    /// <value>The ID of the main branch for this agent</value>
    [JsonPropertyName("main_branch_id")]
    public string? MainBranchId { get; set; }

    /// <value>Procedures keyed by procedure_id.</value>
    [JsonPropertyName("procedures")]
    public Dictionary<string, ProcedureRefResponseModel>? Procedures { get; set; }

    /// <value>URL of the default hold tone played to queued callers when no custom hold audio is uploaded, so the dashboard can preview it.</value>
    [JsonPropertyName("default_hold_audio_url")]
    public string? DefaultHoldAudioUrl { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    /// <remarks>
    /// Written out rather than synthesized. A record's generated Equals compares every instance
    /// field, and `_extensionData` is a fresh Dictionary per instance compared by REFERENCE, so two
    /// identical models were never equal — silently defeating ==, Distinct(), HashSet membership,
    /// dictionary keys and test assertions for every model in the SDK. Excluding it loses nothing:
    /// it is a transient deserialization sink whose contents are copied into
    /// AdditionalProperties, which IS compared here.
    /// </remarks>
    public virtual bool Equals(GetAgentResponseModel? other)
    {
        if (other is null)
        {
            return false;
        }
        if (ReferenceEquals(this, other))
        {
            return true;
        }
        // The synthesized record Equals compares EqualityContract, so a base instance never equals a
        // derived one. Hand-writing Equals drops that unless it is restated.
        if (EqualityContract != other.EqualityContract)
        {
            return false;
        }
        // Declared properties first: the additional-properties comparison walks a dictionary and
        // allocates a string per entry, and is the least likely of the three to differ, so letting
        // the cheap scalar comparisons short-circuit ahead of it matters for Distinct/HashSet over
        // large collections. Anchored on `true` so a model with no declared properties still emits
        // a valid expression.
        return true
            && ValueEquality.AreEqual(AgentId, other.AgentId)
            && ValueEquality.AreEqual(Name, other.Name)
            && ValueEquality.AreEqual(ConversationConfig, other.ConversationConfig)
            && ValueEquality.AreEqual(Metadata, other.Metadata)
            && ValueEquality.AreEqual(PlatformSettings, other.PlatformSettings)
            && ValueEquality.AreEqual(PhoneNumbers, other.PhoneNumbers)
            && ValueEquality.AreEqual(WhatsappAccounts, other.WhatsappAccounts)
            && ValueEquality.AreEqual(Workflow, other.Workflow)
            && ValueEquality.AreEqual(AccessInfo, other.AccessInfo)
            && ValueEquality.AreEqual(Tags, other.Tags)
            && ValueEquality.AreEqual(VersionId, other.VersionId)
            && ValueEquality.AreEqual(BranchId, other.BranchId)
            && ValueEquality.AreEqual(MainBranchId, other.MainBranchId)
            && ValueEquality.AreEqual(Procedures, other.Procedures)
            && ValueEquality.AreEqual(DefaultHoldAudioUrl, other.DefaultHoldAudioUrl)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AgentId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Name);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ConversationConfig);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Metadata);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PlatformSettings);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PhoneNumbers);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(WhatsappAccounts);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Workflow);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AccessInfo);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Tags);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VersionId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BranchId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MainBranchId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Procedures);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DefaultHoldAudioUrl);
            hash = (hash * 31) + AdditionalProperties.GetHashCode();
            return hash;
        }
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
