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

/// <summary>
/// A template run and its outputs. Every output exists from the moment the
/// run is created and reports its own `status`; the run's `status` rolls them
/// up, and the run is finished once it is `completed` or `failed`.
/// </summary>
[Serializable]
public record TemplateRunResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>The unique identifier of the run.</value>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <value>The template this run executed, so a webhook consumer running several templates can tell their runs apart without keeping a run-to-template map.</value>
    [JsonPropertyName("template_id")]
    public required string TemplateId { get; set; }

    /// <value>The template version this run executed. Resolved when the run is created, so a run started with `latest` records the concrete version it ran.</value>
    [JsonPropertyName("version_id")]
    public required string VersionId { get; set; }

    /// <value>
    /// Where a run, or one of its outputs, is in its lifecycle. The run's is rolled
    /// up from its outputs' (``aggregate_output_statuses``). A class rather than a
    /// ``Literal`` so it publishes as one named enum instead of being inlined into
    /// every kind.
    /// </value>
    [JsonPropertyName("status")]
    public required TemplateRunStatus Status { get; set; }

    /// <value>The run's outputs, keyed by output port id. Each is a `TemplateOutput` discriminated on `type`, the `type` of its port's `content_schema`.</value>
    [JsonPropertyName("outputs")]
    public Dictionary<string, TemplateOutput> Outputs { get; set; } =
        new Dictionary<string, TemplateOutput>();

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
    public virtual bool Equals(TemplateRunResponse? other)
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
            && ValueEquality.AreEqual(TemplateId, other.TemplateId)
            && ValueEquality.AreEqual(VersionId, other.VersionId)
            && ValueEquality.AreEqual(Status, other.Status)
            && ValueEquality.AreEqual(Outputs, other.Outputs)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Id);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TemplateId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VersionId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Status);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Outputs);
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
