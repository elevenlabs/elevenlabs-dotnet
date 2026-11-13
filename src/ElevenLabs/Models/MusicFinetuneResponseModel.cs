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
public record MusicFinetuneResponseModel : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>Unique identifier of the finetune.</value>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <value>Name of the finetune.</value>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <value>Tags associated with the finetune.</value>
    [JsonPropertyName("tags")]
    public IEnumerable<string> Tags { get; set; } = new List<string>();

    /// <value>Primary musical genre of the finetune.</value>
    [JsonPropertyName("primary_genre")]
    public string? PrimaryGenre { get; set; }

    /// <value>The base music model the finetune was trained on.</value>
    [JsonPropertyName("model_id")]
    public required string ModelId { get; set; }

    /// <value>When the finetune was created (UTC).</value>
    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

    [JsonPropertyName("visibility")]
    public required FinetuneVisibility Visibility { get; set; }

    [JsonPropertyName("created_by")]
    public required FinetuneCreatedBy CreatedBy { get; set; }

    [JsonPropertyName("status")]
    public required MusicFinetuneStatus Status { get; set; }

    /// <value>Training progress from 0.0 to 1.0.</value>
    [JsonPropertyName("training_progress")]
    public required double TrainingProgress { get; set; }

    /// <value>Reason the finetune failed or was blocked, if applicable.</value>
    [JsonPropertyName("failure_reason")]
    public MusicFinetuneFailureReason? FailureReason { get; set; }

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
    public virtual bool Equals(MusicFinetuneResponseModel? other)
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
            && ValueEquality.AreEqual(Id, other.Id)
            && ValueEquality.AreEqual(Name, other.Name)
            && ValueEquality.AreEqual(Tags, other.Tags)
            && ValueEquality.AreEqual(PrimaryGenre, other.PrimaryGenre)
            && ValueEquality.AreEqual(ModelId, other.ModelId)
            && ValueEquality.AreEqual(CreatedAt, other.CreatedAt)
            && ValueEquality.AreEqual(Visibility, other.Visibility)
            && ValueEquality.AreEqual(CreatedBy, other.CreatedBy)
            && ValueEquality.AreEqual(Status, other.Status)
            && ValueEquality.AreEqual(TrainingProgress, other.TrainingProgress)
            && ValueEquality.AreEqual(FailureReason, other.FailureReason)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Id);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Name);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Tags);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PrimaryGenre);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ModelId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CreatedAt);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Visibility);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CreatedBy);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Status);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TrainingProgress);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FailureReason);
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
