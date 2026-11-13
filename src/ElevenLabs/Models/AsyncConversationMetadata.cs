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

/// <summary>Metadata for async conversation delivery (Zendesk, Slack, etc.).</summary>
[Serializable]
public record AsyncConversationMetadata : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("delivery_status")]
    public required AsyncConversationMetadataDeliveryStatus DeliveryStatus { get; set; }

    [JsonPropertyName("delivery_timestamp")]
    public required int DeliveryTimestamp { get; set; }

    [JsonPropertyName("delivery_error")]
    public string? DeliveryError { get; set; }

    [JsonPropertyName("external_system")]
    public required string ExternalSystem { get; set; }

    [JsonPropertyName("external_id")]
    public required string ExternalId { get; set; }

    [JsonPropertyName("external_link")]
    public string? ExternalLink { get; set; }

    [JsonPropertyName("retry_count")]
    public int? RetryCount { get; set; }

    [JsonPropertyName("last_retry_timestamp")]
    public int? LastRetryTimestamp { get; set; }

    [JsonPropertyName("last_processed_external_message_id")]
    public string? LastProcessedExternalMessageId { get; set; }

    [JsonPropertyName("integration_trigger_id")]
    public string? IntegrationTriggerId { get; set; }

    [JsonPropertyName("platform_metadata")]
    public AsyncConversationMetadataPlatformMetadata? PlatformMetadata { get; set; }

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
    public virtual bool Equals(AsyncConversationMetadata? other)
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
            && ValueEquality.AreEqual(DeliveryStatus, other.DeliveryStatus)
            && ValueEquality.AreEqual(DeliveryTimestamp, other.DeliveryTimestamp)
            && ValueEquality.AreEqual(DeliveryError, other.DeliveryError)
            && ValueEquality.AreEqual(ExternalSystem, other.ExternalSystem)
            && ValueEquality.AreEqual(ExternalId, other.ExternalId)
            && ValueEquality.AreEqual(ExternalLink, other.ExternalLink)
            && ValueEquality.AreEqual(RetryCount, other.RetryCount)
            && ValueEquality.AreEqual(LastRetryTimestamp, other.LastRetryTimestamp)
            && ValueEquality.AreEqual(
                LastProcessedExternalMessageId,
                other.LastProcessedExternalMessageId
            )
            && ValueEquality.AreEqual(IntegrationTriggerId, other.IntegrationTriggerId)
            && ValueEquality.AreEqual(PlatformMetadata, other.PlatformMetadata)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DeliveryStatus);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DeliveryTimestamp);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DeliveryError);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ExternalSystem);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ExternalId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ExternalLink);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RetryCount);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(LastRetryTimestamp);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(LastProcessedExternalMessageId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IntegrationTriggerId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PlatformMetadata);
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
