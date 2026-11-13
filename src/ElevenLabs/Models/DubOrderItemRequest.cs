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
public record DubOrderItemRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>The type of order item.</value>
    [JsonPropertyName("kind")]
    public DubOrderItemRequestKind? Kind { get; set; }

    [JsonPropertyName("media_id")]
    public required string MediaId { get; set; }

    /// <value>The language code of the source media (e.g. 'en', 'es').</value>
    [JsonPropertyName("source_language")]
    public required string SourceLanguage { get; set; }

    /// <value>List of target language codes to dub the media into.</value>
    [JsonPropertyName("destination_languages")]
    public IEnumerable<string> DestinationLanguages { get; set; } = new List<string>();

    /// <value>Whether to generate captions for the dubbed outputs.</value>
    [JsonPropertyName("include_captions")]
    public required bool IncludeCaptions { get; set; }

    /// <value>Whether to generate captions for the source language.</value>
    [JsonPropertyName("include_source_captions")]
    public required bool IncludeSourceCaptions { get; set; }

    /// <value>Optional free-text instructions for the dubbing team.</value>
    [JsonPropertyName("instructions")]
    public string? Instructions { get; set; }

    /// <value>Whether captions should use SDH format, which includes descriptions for deaf and hard-of-hearing viewers.</value>
    [JsonPropertyName("captions_sdh")]
    public bool? CaptionsSdh { get; set; }

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
    public virtual bool Equals(DubOrderItemRequest? other)
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
            && ValueEquality.AreEqual(Kind, other.Kind)
            && ValueEquality.AreEqual(MediaId, other.MediaId)
            && ValueEquality.AreEqual(SourceLanguage, other.SourceLanguage)
            && ValueEquality.AreEqual(DestinationLanguages, other.DestinationLanguages)
            && ValueEquality.AreEqual(IncludeCaptions, other.IncludeCaptions)
            && ValueEquality.AreEqual(IncludeSourceCaptions, other.IncludeSourceCaptions)
            && ValueEquality.AreEqual(Instructions, other.Instructions)
            && ValueEquality.AreEqual(CaptionsSdh, other.CaptionsSdh)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Kind);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MediaId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SourceLanguage);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DestinationLanguages);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IncludeCaptions);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IncludeSourceCaptions);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Instructions);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CaptionsSdh);
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
