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
public record DubbingLanguageResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>Unique identifier of the language target.</value>
    [JsonPropertyName("language_id")]
    public required string LanguageId { get; set; }

    /// <value>Identifier of the parent dubbing project.</value>
    [JsonPropertyName("project_id")]
    public required string ProjectId { get; set; }

    /// <value>BCP-47 language tag this target is dubbed into.</value>
    [JsonPropertyName("target_language")]
    public required string TargetLanguage { get; set; }

    /// <value>Lifecycle status: `queued` (waiting on the project to be ready, or on a worker), `processing` while it is being dubbed, `completed` once its output is available, `stale` when the transcript changed after the output was produced, or `failed`.</value>
    [JsonPropertyName("status")]
    public required DubbingLanguageResponseStatus Status { get; set; }

    /// <value>Dubbing model this target is dubbed with, inherited from the project and not selectable per language.</value>
    [JsonPropertyName("model_id")]
    public string? ModelId { get; set; }

    /// <value>Voice settings applied to every speaker in this language, or null if the defaults apply.</value>
    [JsonPropertyName("voice_settings")]
    public DubbingLanguageResponseVoiceSettings? VoiceSettings { get; set; }

    /// <value>Signed output URLs; null until the target has produced an output (present once `completed`, and kept while `stale` — compare `output_revision` against `revision` to tell whether the output is up to date).</value>
    [JsonPropertyName("outputs")]
    public DubbingLanguageOutputs? Outputs { get; set; }

    /// <value>Monotonic counter incremented whenever this target's transcript changes (a source edit affecting it, or an edit to its translation).</value>
    [JsonPropertyName("revision")]
    public required int Revision { get; set; }

    /// <value>The `revision` the current dubbed output was generated from; equal to `revision` when up to date, and lower when `stale`. This is null until a generation has completed.</value>
    [JsonPropertyName("output_revision")]
    public int? OutputRevision { get; set; }

    /// <value>Why this language failed; null unless `status` is `failed`, and also null for the few languages that failed before failure reporting was introduced. A code of `project_failed` means the parent project failed, so read the project for the underlying cause.</value>
    [JsonPropertyName("error")]
    public DubbingErrorResponse? Error { get; set; }

    /// <value>Non-fatal conditions raised while dubbing this language, empty when there are none. Reflects the latest generation. Conditions raised while preparing the source are reported on the project instead.</value>
    [JsonPropertyName("warnings")]
    public IEnumerable<VoicesNotPermittedWarning>? Warnings { get; set; }

    /// <value>When the language target was created.</value>
    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

    /// <value>When the language target was last updated.</value>
    [JsonPropertyName("updated_at")]
    public required DateTime UpdatedAt { get; set; }

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
    public virtual bool Equals(DubbingLanguageResponse? other)
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
            && ValueEquality.AreEqual(LanguageId, other.LanguageId)
            && ValueEquality.AreEqual(ProjectId, other.ProjectId)
            && ValueEquality.AreEqual(TargetLanguage, other.TargetLanguage)
            && ValueEquality.AreEqual(Status, other.Status)
            && ValueEquality.AreEqual(ModelId, other.ModelId)
            && ValueEquality.AreEqual(VoiceSettings, other.VoiceSettings)
            && ValueEquality.AreEqual(Outputs, other.Outputs)
            && ValueEquality.AreEqual(Revision, other.Revision)
            && ValueEquality.AreEqual(OutputRevision, other.OutputRevision)
            && ValueEquality.AreEqual(Error, other.Error)
            && ValueEquality.AreEqual(Warnings, other.Warnings)
            && ValueEquality.AreEqual(CreatedAt, other.CreatedAt)
            && ValueEquality.AreEqual(UpdatedAt, other.UpdatedAt)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(LanguageId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ProjectId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TargetLanguage);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Status);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ModelId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VoiceSettings);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Outputs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Revision);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(OutputRevision);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Error);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Warnings);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CreatedAt);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(UpdatedAt);
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
