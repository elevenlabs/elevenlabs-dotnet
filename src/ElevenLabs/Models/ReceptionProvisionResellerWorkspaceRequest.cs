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
using ElevenLabs.Productions.Orders;
using ElevenLabs.PronunciationDictionaries;
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

namespace ElevenLabs.Reception;

[Serializable]
public record ReceptionProvisionResellerWorkspaceRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("business_name")]
    public required string BusinessName { get; set; }

    /// <value>The business's vertical, used with `complete_onboarding`. Without it, onboarding picks the vertical as usual.</value>
    [JsonPropertyName("vertical")]
    public ReceptionVertical? Vertical { get; set; }

    /// <value>Bill the workspace's own customer instead of the reseller: it checks out and sees its billing itself, and the reseller earns a commission. Only for a reseller on standard billing.</value>
    [JsonPropertyName("charge_customer")]
    public bool? ChargeCustomer { get; set; }

    /// <value>Paid tier to subscribe to. Omitted leaves the workspace with no subscription.</value>
    [JsonPropertyName("subscription")]
    public ProvisionResellerWorkspaceSubscription? Subscription { get; set; }

    /// <value>A free number from the reseller's phone pool, reserved for the workspace until onboarding binds it to the receptionist.</value>
    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; set; }

    /// <value>People to invite once the workspace exists, capped by the tier's team size. Best-effort: each outcome is in `member_results`.</value>
    [JsonPropertyName("members")]
    public IEnumerable<TeamInviteRequest>? Members { get; set; }

    /// <value>Finish setup right away, as `POST /v1/reception/reseller/workspaces/{workspace_id}/complete-onboarding` does. Best-effort: `onboarding_completed_at_unix` stays null on failure, and that call can be retried.</value>
    [JsonPropertyName("complete_onboarding")]
    public bool? CompleteOnboarding { get; set; }

    /// <value>Client-generated key that makes a retry safe. The same key and body within 24 hours returns the first result without running again. While that first request is still running, a retry gets 409 `idempotency_key_in_progress`; a different body with the same key gets 400 `idempotency_key_reused`. A request that fails is not saved, so it can be retried with the same key.</value>
    [JsonPropertyName("idempotency_key")]
    public string? IdempotencyKey { get; set; }

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
    public virtual bool Equals(ReceptionProvisionResellerWorkspaceRequest? other)
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
            && ValueEquality.AreEqual(BusinessName, other.BusinessName)
            && ValueEquality.AreEqual(Vertical, other.Vertical)
            && ValueEquality.AreEqual(ChargeCustomer, other.ChargeCustomer)
            && ValueEquality.AreEqual(Subscription, other.Subscription)
            && ValueEquality.AreEqual(PhoneNumber, other.PhoneNumber)
            && ValueEquality.AreEqual(Members, other.Members)
            && ValueEquality.AreEqual(CompleteOnboarding, other.CompleteOnboarding)
            && ValueEquality.AreEqual(IdempotencyKey, other.IdempotencyKey)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BusinessName);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Vertical);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ChargeCustomer);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Subscription);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PhoneNumber);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Members);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CompleteOnboarding);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IdempotencyKey);
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
