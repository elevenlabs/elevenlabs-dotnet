using ElevenLabs;
using ElevenLabs.Agents;
using ElevenLabs.Agents.Conversations;
using ElevenLabs.Agents.Dashboard;
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

namespace ElevenLabs.Agents.KnowledgeBase;

[Serializable]
public record BodyUpdateDocumentV1ConvaiKnowledgeBaseDocumentationIdPatch : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>A custom, human-readable name for the document.</value>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <value>Updated content for the document. Only supported for text documents, URL documents with auto-sync disabled, and file documents that are not synced from an external source.</value>
    [JsonPropertyName("content")]
    public string? Content { get; set; }

    /// <value>Whether the document or folder is refreshed automatically. Only applicable to URL documents, folders, and externally-synced files. Leave unset to keep the current value.</value>
    [JsonPropertyName("enable_auto_sync")]
    public bool? EnableAutoSync { get; set; }

    /// <value>Whether to automatically remove the document once its source is no longer available. Only applicable when auto-sync is enabled. Leave unset to keep the current value.</value>
    [JsonPropertyName("auto_remove")]
    public bool? AutoRemove { get; set; }

    /// <value>Minimum frequency (in days) at which the document is refreshed. The actual interval may be shorter, never longer. Only applicable when auto-sync is enabled. Leave unset to keep the current value.</value>
    [JsonPropertyName("minimum_frequency_days")]
    public int? MinimumFrequencyDays { get; set; }

    /// <value>Folders only. When true, items already in the folder are only tightened to stay at least as strict as the folder, and keep any setting that is stricter than the folder's. When false, they are set to exactly the folder's auto-sync settings. Ignored for externally synced folders, whose contents always follow the folder's schedule.</value>
    [JsonPropertyName("tighten_only")]
    public bool? TightenOnly { get; set; }

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
    public virtual bool Equals(BodyUpdateDocumentV1ConvaiKnowledgeBaseDocumentationIdPatch? other)
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
            && ValueEquality.AreEqual(Name, other.Name)
            && ValueEquality.AreEqual(Content, other.Content)
            && ValueEquality.AreEqual(EnableAutoSync, other.EnableAutoSync)
            && ValueEquality.AreEqual(AutoRemove, other.AutoRemove)
            && ValueEquality.AreEqual(MinimumFrequencyDays, other.MinimumFrequencyDays)
            && ValueEquality.AreEqual(TightenOnly, other.TightenOnly)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Name);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Content);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EnableAutoSync);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AutoRemove);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MinimumFrequencyDays);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TightenOnly);
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
