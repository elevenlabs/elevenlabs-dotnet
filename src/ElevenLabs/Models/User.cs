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
public record User : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>The unique identifier of the user.</value>
    [JsonPropertyName("user_id")]
    public required string UserId { get; set; }

    /// <value>The unique identifier of the workspace this user's API key belongs to.</value>
    [JsonPropertyName("workspace_id")]
    public required string WorkspaceId { get; set; }

    [JsonPropertyName("subscription")]
    public required SubscriptionResponse Subscription { get; set; }

    /// <value>Whether the user is new. This field is deprecated and will be removed in the future. Use 'created_at' instead.</value>
    [JsonPropertyName("is_new_user")]
    public required bool IsNewUser { get; set; }

    /// <value>This field is deprecated and will be removed in a future major version. Instead use subscription.trust_on_invoice_creation.</value>
    [JsonPropertyName("can_use_delayed_payment_methods")]
    public required bool CanUseDelayedPaymentMethods { get; set; }

    /// <value>Whether the user's onboarding is completed.</value>
    [JsonPropertyName("is_onboarding_completed")]
    public required bool IsOnboardingCompleted { get; set; }

    /// <value>Whether the user's onboarding checklist is completed.</value>
    [JsonPropertyName("is_onboarding_checklist_completed")]
    public required bool IsOnboardingChecklistCompleted { get; set; }

    /// <value>Whether to show compliance terms (ToS, Privacy Policy, biometric consent) during onboarding. Set for users signing up from the marketing site.</value>
    [JsonPropertyName("show_compliance_terms")]
    public bool? ShowComplianceTerms { get; set; }

    /// <value>First name of the user.</value>
    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    /// <value>Whether the user's API key is hashed.</value>
    [JsonPropertyName("is_api_key_hashed")]
    public bool? IsApiKeyHashed { get; set; }

    /// <value>The preview of the user's API key.</value>
    [JsonPropertyName("xi_api_key_preview")]
    public string? XiApiKeyPreview { get; set; }

    /// <value>The referral link code of the user.</value>
    [JsonPropertyName("referral_link_code")]
    public string? ReferralLinkCode { get; set; }

    /// <value>The Partnerstack partner default link of the user.</value>
    [JsonPropertyName("partnerstack_partner_default_link")]
    public string? PartnerstackPartnerDefaultLink { get; set; }

    /// <value>The unix timestamp of the user's creation. 0 if the user was created before the unix timestamp was added.</value>
    [JsonPropertyName("created_at")]
    public required int CreatedAt { get; set; }

    /// <value>Seat types for workspace members.</value>
    [JsonPropertyName("seat_type")]
    public required SeatType SeatType { get; set; }

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
    public virtual bool Equals(User? other)
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
            && ValueEquality.AreEqual(UserId, other.UserId)
            && ValueEquality.AreEqual(WorkspaceId, other.WorkspaceId)
            && ValueEquality.AreEqual(Subscription, other.Subscription)
            && ValueEquality.AreEqual(IsNewUser, other.IsNewUser)
            && ValueEquality.AreEqual(
                CanUseDelayedPaymentMethods,
                other.CanUseDelayedPaymentMethods
            )
            && ValueEquality.AreEqual(IsOnboardingCompleted, other.IsOnboardingCompleted)
            && ValueEquality.AreEqual(
                IsOnboardingChecklistCompleted,
                other.IsOnboardingChecklistCompleted
            )
            && ValueEquality.AreEqual(ShowComplianceTerms, other.ShowComplianceTerms)
            && ValueEquality.AreEqual(FirstName, other.FirstName)
            && ValueEquality.AreEqual(IsApiKeyHashed, other.IsApiKeyHashed)
            && ValueEquality.AreEqual(XiApiKeyPreview, other.XiApiKeyPreview)
            && ValueEquality.AreEqual(ReferralLinkCode, other.ReferralLinkCode)
            && ValueEquality.AreEqual(
                PartnerstackPartnerDefaultLink,
                other.PartnerstackPartnerDefaultLink
            )
            && ValueEquality.AreEqual(CreatedAt, other.CreatedAt)
            && ValueEquality.AreEqual(SeatType, other.SeatType)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(UserId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(WorkspaceId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Subscription);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsNewUser);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CanUseDelayedPaymentMethods);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsOnboardingCompleted);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsOnboardingChecklistCompleted);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ShowComplianceTerms);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FirstName);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsApiKeyHashed);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(XiApiKeyPreview);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ReferralLinkCode);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PartnerstackPartnerDefaultLink);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CreatedAt);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SeatType);
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
