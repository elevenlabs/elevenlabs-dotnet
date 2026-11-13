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
public record RagConfigOutput : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    [JsonPropertyName("embedding_model")]
    public EmbeddingModelEnum? EmbeddingModel { get; set; }

    /// <value>Maximum vector distance of retrieved chunks.</value>
    [JsonPropertyName("max_vector_distance")]
    public double? MaxVectorDistance { get; set; }

    /// <value>Maximum total length of document chunks retrieved from RAG.</value>
    [JsonPropertyName("max_documents_length")]
    public int? MaxDocumentsLength { get; set; }

    /// <value>Maximum number of RAG document chunks to initially retrieve from the vector store. These are then further filtered by vector distance and total length.</value>
    [JsonPropertyName("max_retrieved_rag_chunks_count")]
    public int? MaxRetrievedRagChunksCount { get; set; }

    /// <value>Number of candidates evaluated in ANN vector search. Higher number means better results, but higher latency. Minimum recommended value is 100. If disabled, the default value is used.</value>
    [JsonPropertyName("num_candidates")]
    public int? NumCandidates { get; set; }

    /// <value>Custom prompt for rewriting user queries before RAG retrieval. The conversation history will be automatically appended at the end. If not set, the default prompt will be used.</value>
    [JsonPropertyName("query_rewrite_prompt_override")]
    public string? QueryRewritePromptOverride { get; set; }

    /// <value>When set, the agent uses the knowledge_base tool instead of the legacy knowledge_base_rag tool. None means the agent is not opted in.</value>
    [JsonPropertyName("knowledge_base_tool_info")]
    public KnowledgeBaseToolInfo? KnowledgeBaseToolInfo { get; set; }

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
    public virtual bool Equals(RagConfigOutput? other)
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
            && ValueEquality.AreEqual(Enabled, other.Enabled)
            && ValueEquality.AreEqual(EmbeddingModel, other.EmbeddingModel)
            && ValueEquality.AreEqual(MaxVectorDistance, other.MaxVectorDistance)
            && ValueEquality.AreEqual(MaxDocumentsLength, other.MaxDocumentsLength)
            && ValueEquality.AreEqual(MaxRetrievedRagChunksCount, other.MaxRetrievedRagChunksCount)
            && ValueEquality.AreEqual(NumCandidates, other.NumCandidates)
            && ValueEquality.AreEqual(QueryRewritePromptOverride, other.QueryRewritePromptOverride)
            && ValueEquality.AreEqual(KnowledgeBaseToolInfo, other.KnowledgeBaseToolInfo)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Enabled);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EmbeddingModel);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MaxVectorDistance);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MaxDocumentsLength);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MaxRetrievedRagChunksCount);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(NumCandidates);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(QueryRewritePromptOverride);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(KnowledgeBaseToolInfo);
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
