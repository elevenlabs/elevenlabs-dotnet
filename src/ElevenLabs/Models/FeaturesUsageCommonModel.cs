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
public record FeaturesUsageCommonModel : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("language_detection")]
    public FeatureStatusCommonModel? LanguageDetection { get; set; }

    [JsonPropertyName("transfer_to_agent")]
    public FeatureStatusCommonModel? TransferToAgent { get; set; }

    [JsonPropertyName("transfer_to_number")]
    public FeatureStatusCommonModel? TransferToNumber { get; set; }

    [JsonPropertyName("multivoice")]
    public FeatureStatusCommonModel? Multivoice { get; set; }

    [JsonPropertyName("dtmf_tones")]
    public FeatureStatusCommonModel? DtmfTones { get; set; }

    [JsonPropertyName("external_mcp_servers")]
    public FeatureStatusCommonModel? ExternalMcpServers { get; set; }

    [JsonPropertyName("pii_zrm_workspace")]
    public bool? PiiZrmWorkspace { get; set; }

    [JsonPropertyName("pii_zrm_agent")]
    public bool? PiiZrmAgent { get; set; }

    [JsonPropertyName("tool_dynamic_variable_updates")]
    public FeatureStatusCommonModel? ToolDynamicVariableUpdates { get; set; }

    [JsonPropertyName("is_livekit")]
    public bool? IsLivekit { get; set; }

    [JsonPropertyName("voicemail_detection")]
    public FeatureStatusCommonModel? VoicemailDetection { get; set; }

    [JsonPropertyName("dtmf_input")]
    public FeatureStatusCommonModel? DtmfInput { get; set; }

    [JsonPropertyName("workflow")]
    public WorkflowFeaturesUsageCommonModel? Workflow { get; set; }

    [JsonPropertyName("agent_testing")]
    public TestsFeatureUsageCommonModel? AgentTesting { get; set; }

    [JsonPropertyName("versioning")]
    public FeatureStatusCommonModel? Versioning { get; set; }

    [JsonPropertyName("file_input")]
    public FeatureStatusCommonModel? FileInput { get; set; }

    [JsonPropertyName("freeform_procedure")]
    public FeatureStatusCommonModel? FreeformProcedure { get; set; }

    [JsonPropertyName("structured_procedure")]
    public FeatureStatusCommonModel? StructuredProcedure { get; set; }

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
    public virtual bool Equals(FeaturesUsageCommonModel? other)
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
            && ValueEquality.AreEqual(LanguageDetection, other.LanguageDetection)
            && ValueEquality.AreEqual(TransferToAgent, other.TransferToAgent)
            && ValueEquality.AreEqual(TransferToNumber, other.TransferToNumber)
            && ValueEquality.AreEqual(Multivoice, other.Multivoice)
            && ValueEquality.AreEqual(DtmfTones, other.DtmfTones)
            && ValueEquality.AreEqual(ExternalMcpServers, other.ExternalMcpServers)
            && ValueEquality.AreEqual(PiiZrmWorkspace, other.PiiZrmWorkspace)
            && ValueEquality.AreEqual(PiiZrmAgent, other.PiiZrmAgent)
            && ValueEquality.AreEqual(ToolDynamicVariableUpdates, other.ToolDynamicVariableUpdates)
            && ValueEquality.AreEqual(IsLivekit, other.IsLivekit)
            && ValueEquality.AreEqual(VoicemailDetection, other.VoicemailDetection)
            && ValueEquality.AreEqual(DtmfInput, other.DtmfInput)
            && ValueEquality.AreEqual(Workflow, other.Workflow)
            && ValueEquality.AreEqual(AgentTesting, other.AgentTesting)
            && ValueEquality.AreEqual(Versioning, other.Versioning)
            && ValueEquality.AreEqual(FileInput, other.FileInput)
            && ValueEquality.AreEqual(FreeformProcedure, other.FreeformProcedure)
            && ValueEquality.AreEqual(StructuredProcedure, other.StructuredProcedure)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(LanguageDetection);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TransferToAgent);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TransferToNumber);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Multivoice);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DtmfTones);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ExternalMcpServers);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PiiZrmWorkspace);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PiiZrmAgent);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ToolDynamicVariableUpdates);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsLivekit);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VoicemailDetection);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DtmfInput);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Workflow);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AgentTesting);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Versioning);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FileInput);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FreeformProcedure);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(StructuredProcedure);
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
