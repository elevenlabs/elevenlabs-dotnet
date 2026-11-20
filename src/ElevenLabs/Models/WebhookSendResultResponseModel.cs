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
using ElevenLabs.Reception;
using ElevenLabs.Reception.Products;
using ElevenLabs.Reception.Receptionists;
using ElevenLabs.Reception.Team;
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
public record WebhookSendResultResponseModel : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>The delivery ID, also sent in the ElevenLabs-Webhook-Delivery-Id header.</value>
    [JsonPropertyName("delivery_id")]
    public required string DeliveryId { get; set; }

    [JsonPropertyName("outcome")]
    public required WebhookOutcome Outcome { get; set; }

    /// <value>The HTTP status your endpoint returned, if it answered.</value>
    [JsonPropertyName("response_code")]
    public int? ResponseCode { get; set; }

    /// <value>How long your endpoint took to answer, in milliseconds.</value>
    [JsonPropertyName("latency_ms")]
    public int? LatencyMs { get; set; }

    /// <value>The Content-Type your endpoint answered with, if it answered.</value>
    [JsonPropertyName("response_content_type")]
    public string? ResponseContentType { get; set; }

    /// <value>The size of your endpoint's response body in bytes, if it answered. The body itself is never stored or returned.</value>
    [JsonPropertyName("response_body_bytes")]
    public int? ResponseBodyBytes { get; set; }

    /// <value>Where a failure came from: recipient, configuration, external_transport or timeout.</value>
    [JsonPropertyName("failure_origin")]
    public string? FailureOrigin { get; set; }

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
    public virtual bool Equals(WebhookSendResultResponseModel? other)
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
            && ValueEquality.AreEqual(DeliveryId, other.DeliveryId)
            && ValueEquality.AreEqual(Outcome, other.Outcome)
            && ValueEquality.AreEqual(ResponseCode, other.ResponseCode)
            && ValueEquality.AreEqual(LatencyMs, other.LatencyMs)
            && ValueEquality.AreEqual(ResponseContentType, other.ResponseContentType)
            && ValueEquality.AreEqual(ResponseBodyBytes, other.ResponseBodyBytes)
            && ValueEquality.AreEqual(FailureOrigin, other.FailureOrigin)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DeliveryId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Outcome);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ResponseCode);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(LatencyMs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ResponseContentType);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ResponseBodyBytes);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FailureOrigin);
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
