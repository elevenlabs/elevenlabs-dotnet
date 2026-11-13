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
public record AgentKnowledgeBaseRagQueryRequestModel : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("strategy")]
    public SearchStrategy? Strategy { get; set; }

    /// <value>Query to search the knowledge base for. Required for the semantic and keyword strategies.</value>
    [JsonPropertyName("query")]
    public string? Query { get; set; }

    /// <value>IDs or names of knowledge base documents or folders. Semantic and keyword search only search these entries; cat reads the single document given; ls lists the single folder given, or the top level of the knowledge base when omitted.</value>
    [JsonPropertyName("documents")]
    public IEnumerable<string>? Documents { get; set; }

    /// <value>When true (the default), retrieval uses the agent's own RAG settings, reproducing exactly what the agent would retrieve. Set to false to retrieve with neutral default RAG settings instead (the agent's embedding model is always kept, since it determines which vector index exists). Useful for auditing the knowledge base independently of how a particular agent is tuned.</value>
    [JsonPropertyName("use_agent_defaults")]
    public bool? UseAgentDefaults { get; set; }

    /// <value>Optional maximum total character length of document chunks returned. Overrides the selected RAG settings for this query only.</value>
    [JsonPropertyName("max_documents_length")]
    public int? MaxDocumentsLength { get; set; }

    /// <value>Optional maximum number of document chunks retrieved. Overrides the selected RAG settings for this query only.</value>
    [JsonPropertyName("max_retrieved_rag_chunks_count")]
    public int? MaxRetrievedRagChunksCount { get; set; }

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
    public virtual bool Equals(AgentKnowledgeBaseRagQueryRequestModel? other)
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
            && ValueEquality.AreEqual(Strategy, other.Strategy)
            && ValueEquality.AreEqual(Query, other.Query)
            && ValueEquality.AreEqual(Documents, other.Documents)
            && ValueEquality.AreEqual(UseAgentDefaults, other.UseAgentDefaults)
            && ValueEquality.AreEqual(MaxDocumentsLength, other.MaxDocumentsLength)
            && ValueEquality.AreEqual(MaxRetrievedRagChunksCount, other.MaxRetrievedRagChunksCount)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Strategy);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Query);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Documents);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(UseAgentDefaults);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MaxDocumentsLength);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MaxRetrievedRagChunksCount);
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
