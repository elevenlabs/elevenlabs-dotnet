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

/// <summary>A `video` output, downloaded from `content_url` once completed.</summary>
[Serializable]
public record TemplateVideoOutput : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>The id of the generation behind this output. Pass it as a `generation` reference to use the output as an input elsewhere.</value>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <value>
    /// Where a run, or one of its outputs, is in its lifecycle. The run's is rolled
    /// up from its outputs' (``aggregate_output_statuses``). A class rather than a
    /// ``Literal`` so it publishes as one named enum instead of being inlined into
    /// every kind.
    /// </value>
    [JsonPropertyName("status")]
    public required TemplateRunStatus Status { get; set; }

    /// <value>The category of failure. Present only when `status` is `failed`.</value>
    [JsonPropertyName("failure_reason")]
    public TemplateVideoOutputFailureReason? FailureReason { get; set; }

    /// <value>A human-readable description of the failure. Present only when `status` is `failed`. Failed generations are not charged.</value>
    [JsonPropertyName("error_message")]
    public string? ErrorMessage { get; set; }

    /// <value>A signed URL to download the generated media from. Present only when `status` is `completed`. It expires about an hour after this response is returned; fetch the run again for a fresh URL.</value>
    [JsonPropertyName("content_url")]
    public string? ContentUrl { get; set; }

    /// <value>The MIME type of the generated media. Present only when `status` is `completed`.</value>
    [JsonPropertyName("content_mime_type")]
    public string? ContentMimeType { get; set; }

    /// <value>The kind of output: the `type` of the port's `content_schema`.</value>
    [JsonPropertyName("type")]
    public required TemplateVideoOutputType Type { get; set; }

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
    public virtual bool Equals(TemplateVideoOutput? other)
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
            && ValueEquality.AreEqual(Status, other.Status)
            && ValueEquality.AreEqual(FailureReason, other.FailureReason)
            && ValueEquality.AreEqual(ErrorMessage, other.ErrorMessage)
            && ValueEquality.AreEqual(ContentUrl, other.ContentUrl)
            && ValueEquality.AreEqual(ContentMimeType, other.ContentMimeType)
            && ValueEquality.AreEqual(Type, other.Type)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Id);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Status);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FailureReason);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ErrorMessage);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ContentUrl);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ContentMimeType);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Type);
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
