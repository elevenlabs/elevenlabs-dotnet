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
public record WorkspaceWebhookResponseModel : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>The display name for this webhook.</value>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <value>The unique ID for this webhook.</value>
    [JsonPropertyName("webhook_id")]
    public required string WebhookId { get; set; }

    /// <value>The HTTPS callback URL that is called when this webhook is triggered in the platform.</value>
    [JsonPropertyName("webhook_url")]
    public required string WebhookUrl { get; set; }

    /// <value>Whether the webhook has been manually disabled by a user.</value>
    [JsonPropertyName("is_disabled")]
    public required bool IsDisabled { get; set; }

    /// <value>Whether the webhook has been automatically disabled due to repeated consecutive failures over a long period of time.</value>
    [JsonPropertyName("is_auto_disabled")]
    public required bool IsAutoDisabled { get; set; }

    /// <value>Original creation time of the webhook.</value>
    [JsonPropertyName("created_at_unix")]
    public required int CreatedAtUnix { get; set; }

    [JsonPropertyName("auth_type")]
    public required WebhookAuthMethodType AuthType { get; set; }

    /// <value>The list of products that are currently configured to trigger this webhook.</value>
    [JsonPropertyName("usage")]
    public IEnumerable<WorkspaceWebhookUsageResponseModel>? Usage { get; set; }

    /// <value>The workspace-level events this webhook is currently subscribed to. Only populated when usages are requested.</value>
    [JsonPropertyName("events")]
    public IEnumerable<WorkspaceWebhookEventType>? Events { get; set; }

    /// <value>The most recent error code returned from the callback URL.</value>
    [JsonPropertyName("most_recent_failure_error_code")]
    public int? MostRecentFailureErrorCode { get; set; }

    /// <value>The most recent time the webhook failed, failures are any non-200 codes returned by the callback URL.</value>
    [JsonPropertyName("most_recent_failure_timestamp")]
    public int? MostRecentFailureTimestamp { get; set; }

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
    public virtual bool Equals(WorkspaceWebhookResponseModel? other)
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
            && ValueEquality.AreEqual(WebhookId, other.WebhookId)
            && ValueEquality.AreEqual(WebhookUrl, other.WebhookUrl)
            && ValueEquality.AreEqual(IsDisabled, other.IsDisabled)
            && ValueEquality.AreEqual(IsAutoDisabled, other.IsAutoDisabled)
            && ValueEquality.AreEqual(CreatedAtUnix, other.CreatedAtUnix)
            && ValueEquality.AreEqual(AuthType, other.AuthType)
            && ValueEquality.AreEqual(Usage, other.Usage)
            && ValueEquality.AreEqual(Events, other.Events)
            && ValueEquality.AreEqual(MostRecentFailureErrorCode, other.MostRecentFailureErrorCode)
            && ValueEquality.AreEqual(MostRecentFailureTimestamp, other.MostRecentFailureTimestamp)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Name);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(WebhookId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(WebhookUrl);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsDisabled);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsAutoDisabled);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CreatedAtUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AuthType);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Usage);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Events);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MostRecentFailureErrorCode);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MostRecentFailureTimestamp);
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
