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
public record ConversationInitiationClientDataConfigOutput : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("conversation_config_override")]
    public ConversationConfigClientOverrideConfigOutput? ConversationConfigOverride { get; set; }

    /// <value>Whether to include custom LLM extra body</value>
    [JsonPropertyName("custom_llm_extra_body")]
    public bool? CustomLlmExtraBody { get; set; }

    /// <value>Whether to enable conversation initiation client data from webhooks</value>
    [JsonPropertyName("enable_conversation_initiation_client_data_from_webhook")]
    public bool? EnableConversationInitiationClientDataFromWebhook { get; set; }

    /// <value>Whether clients may pass starting_workflow_node_id in initiation client data; if false, sending it fails conversation start.</value>
    [JsonPropertyName("enable_starting_workflow_node_id_from_client")]
    public bool? EnableStartingWorkflowNodeIdFromClient { get; set; }

    /// <value>Whether clients may pass procedure_ids and start_procedure_ids in initiation client data. procedure_ids selects which of the agent's procedures are available. start_procedure_ids starts free-form procedures when the conversation starts. If false, sending either field fails conversation start.</value>
    [JsonPropertyName("enable_procedure_ids_from_client")]
    public bool? EnableProcedureIdsFromClient { get; set; }

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
    public virtual bool Equals(ConversationInitiationClientDataConfigOutput? other)
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
            && ValueEquality.AreEqual(ConversationConfigOverride, other.ConversationConfigOverride)
            && ValueEquality.AreEqual(CustomLlmExtraBody, other.CustomLlmExtraBody)
            && ValueEquality.AreEqual(
                EnableConversationInitiationClientDataFromWebhook,
                other.EnableConversationInitiationClientDataFromWebhook
            )
            && ValueEquality.AreEqual(
                EnableStartingWorkflowNodeIdFromClient,
                other.EnableStartingWorkflowNodeIdFromClient
            )
            && ValueEquality.AreEqual(
                EnableProcedureIdsFromClient,
                other.EnableProcedureIdsFromClient
            )
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ConversationConfigOverride);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CustomLlmExtraBody);
            hash =
                (hash * 31)
                + ValueEquality.GetHashCodeOf(EnableConversationInitiationClientDataFromWebhook);
            hash =
                (hash * 31) + ValueEquality.GetHashCodeOf(EnableStartingWorkflowNodeIdFromClient);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EnableProcedureIdsFromClient);
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
