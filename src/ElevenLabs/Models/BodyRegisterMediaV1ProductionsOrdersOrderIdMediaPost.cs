using ElevenLabs;
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

namespace ElevenLabs.Productions.Orders;

[Serializable]
public record BodyRegisterMediaV1ProductionsOrdersOrderIdMediaPost : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>The language code of the media content (e.g. 'en', 'es-ES'). Must be a supported source language for some order item kind.</value>
    [JsonPropertyName("declared_language")]
    public required string DeclaredLanguage { get; set; }

    /// <value>The media file to upload. Mutually exclusive with media_url.</value>
    [JsonPropertyName("media")]
    public FileParameter? Media { get; set; }

    /// <value>A URL to fetch the media file from. Mutually exclusive with media.</value>
    [JsonPropertyName("media_url")]
    public string? MediaUrl { get; set; }

    /// <value>The filename for URL-sourced media (e.g. 'example.mp4'). Required when using media_url.</value>
    [JsonPropertyName("media_url_filename")]
    public string? MediaUrlFilename { get; set; }

    /// <value>The MIME type for URL-sourced media (e.g. 'video/mp4'). Required when using media_url.</value>
    [JsonPropertyName("media_url_content_type")]
    public string? MediaUrlContentType { get; set; }

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
    public virtual bool Equals(BodyRegisterMediaV1ProductionsOrdersOrderIdMediaPost? other)
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
            && ValueEquality.AreEqual(DeclaredLanguage, other.DeclaredLanguage)
            && ValueEquality.AreEqual(Media, other.Media)
            && ValueEquality.AreEqual(MediaUrl, other.MediaUrl)
            && ValueEquality.AreEqual(MediaUrlFilename, other.MediaUrlFilename)
            && ValueEquality.AreEqual(MediaUrlContentType, other.MediaUrlContentType)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DeclaredLanguage);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Media);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MediaUrl);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MediaUrlFilename);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MediaUrlContentType);
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
