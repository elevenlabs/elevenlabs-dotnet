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
public record AgentKnowledgeBaseRagDocumentResponseModel : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>ID of the knowledge base document.</value>
    [JsonPropertyName("document_id")]
    public required string DocumentId { get; set; }

    /// <value>Name of the knowledge base document.</value>
    [JsonPropertyName("document_name")]
    public required string DocumentName { get; set; }

    /// <value>Tracked source URL for URL documents, or null for other document types.</value>
    [JsonPropertyName("source_url")]
    public string? SourceUrl { get; set; }

    /// <value>Content the agent would read, cut to the maximum documents length. Empty when the document has no extractable content.</value>
    [JsonPropertyName("content")]
    public required string Content { get; set; }

    /// <value>Whether the content was cut to the maximum documents length.</value>
    [JsonPropertyName("truncated")]
    public required bool Truncated { get; set; }

    /// <value>
    /// Canonical representation of a knowledge base document's stored content.
    ///
    /// HTML is the legacy default; documents created before this field existed are
    /// interpreted as HTML.
    /// </value>
    [JsonPropertyName("content_format")]
    public required ContentFormat ContentFormat { get; set; }

    [JsonPropertyName("document_type")]
    public required KnowledgeBaseDocumentType DocumentType { get; set; }

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
    public virtual bool Equals(AgentKnowledgeBaseRagDocumentResponseModel? other)
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
            && ValueEquality.AreEqual(DocumentId, other.DocumentId)
            && ValueEquality.AreEqual(DocumentName, other.DocumentName)
            && ValueEquality.AreEqual(SourceUrl, other.SourceUrl)
            && ValueEquality.AreEqual(Content, other.Content)
            && ValueEquality.AreEqual(Truncated, other.Truncated)
            && ValueEquality.AreEqual(ContentFormat, other.ContentFormat)
            && ValueEquality.AreEqual(DocumentType, other.DocumentType)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DocumentId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DocumentName);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SourceUrl);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Content);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Truncated);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ContentFormat);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DocumentType);
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
