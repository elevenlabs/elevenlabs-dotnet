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
using OneOf;

namespace ElevenLabs.Dubbing;

[Serializable]
public record BodyCreateDubbingProjectV1DubbingProjectPost : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>The source media file to dub: an audio or video file of at most 3 GiB. Provide this or `source_url`, not both.</value>
    [JsonPropertyName("file")]
    public FileParameter? File { get; set; }

    /// <value>Public HTTP(S) URL the source media is fetched from server-side, subject to the same size and format limits as an upload. Provide this or `file`, not both.</value>
    [JsonPropertyName("source_url")]
    public string? SourceUrl { get; set; }

    /// <value>Optional free-form string (at most 500 characters) to identify the project on your end. Stored and echoed back verbatim; it does not affect the dub.</value>
    [JsonPropertyName("reference")]
    public string? Reference { get; set; }

    /// <value>BCP-47 language tag of the source media; must be a language the transcription model supports. Any region or script subtag is ignored, since transcription is per-language. Omit to auto-detect.</value>
    [JsonPropertyName("source_language")]
    public string? SourceLanguage { get; set; }

    /// <value>Dubbing model (`dubbing_v1` or `dubbing_v2`) every language target of this project is dubbed with. Defaults to `dubbing_v2`. Fixed at create time — the source is prepared for this model, so neither the project nor an individual target can change it later.</value>
    [JsonPropertyName("model_id")]
    public OneOf<ModelId1, string>? ModelId { get; set; }

    /// <value>Key terms to bias transcription and translation toward (for example, product or brand names). At most 1,000 terms; each term at most 50 characters and 5 words; the characters `&lt;&gt;{}[]\` are not allowed. Terms are trimmed and deduplicated. Repeat the field once per term, or pass a single JSON array.</value>
    [JsonPropertyName("keyterms")]
    public IEnumerable<string>? Keyterms { get; set; }

    /// <value>IDs of workspace webhooks to notify as this project progresses — the alternative to polling, and what we recommend. Each receives a `dubbing_project_ready` or `dubbing_project_failed` event for the project, and a `dubbing_language_completed` or `dubbing_language_failed` event for every language under it; `dubbing_language_completed` carries the output download URLs. At most 3 IDs, each already configured in your workspace — see [Webhooks](https://elevenlabs.io/docs/eleven-api/resources/webhooks) for how to create one and verify its signature. Repeat the field once per ID, or pass a single JSON array or comma-separated string. Delivery is best-effort and can repeat, so we recommend handling events idempotently.</value>
    [JsonPropertyName("webhook_ids")]
    public IEnumerable<string>? WebhookIds { get; set; }

    /// <value>Optional shortcut: also create a language target in this BCP-47 language, queued to start once the project is ready — equivalent to creating the project and then creating one language target. Must be one of the [languages the dubbing model supports](https://elevenlabs.io/docs/help-center/product/dubbing/which-languages-are-supported-in-dubbing), and a region-qualified tag must be one of the supported dialects. This is the first language target, so it consumes the project's minimum charge rather than adding to it. Its ID is returned in `language_ids`.</value>
    [JsonPropertyName("target_language")]
    public string? TargetLanguage { get; set; }

    /// <value>Enterprise only. Optional JSON transcript to use instead of transcribing the source: a `{"segments": [...]}` document, at most 20,000 segments and 4 MiB. See [Bring your own transcript](https://elevenlabs.io/docs/eleven-api/guides/how-to/dubbing/bring-your-own-transcript) for the segment fields and their constraints. `source_language` is required whenever a transcript is provided. If any segment carries a `translation`, `target_language` is required and every segment must carry one; those translations seed the target created via `target_language`, which then skips machine translation.</value>
    [JsonPropertyName("transcript")]
    public FileParameter? Transcript { get; set; }

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
    public virtual bool Equals(BodyCreateDubbingProjectV1DubbingProjectPost? other)
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
            && ValueEquality.AreEqual(File, other.File)
            && ValueEquality.AreEqual(SourceUrl, other.SourceUrl)
            && ValueEquality.AreEqual(Reference, other.Reference)
            && ValueEquality.AreEqual(SourceLanguage, other.SourceLanguage)
            && ValueEquality.AreEqual(ModelId, other.ModelId)
            && ValueEquality.AreEqual(Keyterms, other.Keyterms)
            && ValueEquality.AreEqual(WebhookIds, other.WebhookIds)
            && ValueEquality.AreEqual(TargetLanguage, other.TargetLanguage)
            && ValueEquality.AreEqual(Transcript, other.Transcript)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(File);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SourceUrl);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Reference);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SourceLanguage);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ModelId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Keyterms);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(WebhookIds);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TargetLanguage);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Transcript);
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
