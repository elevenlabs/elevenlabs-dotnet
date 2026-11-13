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
using OneOf;

namespace ElevenLabs;

[Serializable]
public record Subscription : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>The tier of the user's subscription.</value>
    [JsonPropertyName("tier")]
    public required string Tier { get; set; }

    /// <value>The number of characters used by the user.</value>
    [JsonPropertyName("character_count")]
    public required int CharacterCount { get; set; }

    /// <value>The maximum number of characters allowed in the current billing period.</value>
    [JsonPropertyName("character_limit")]
    public required int CharacterLimit { get; set; }

    /// <value>Deprecated: use `max_credit_limit_extension`. Maximum number of characters that the character limit can be exceeded by. Managed by the workspace admin.</value>
    [JsonPropertyName("max_character_limit_extension")]
    public int? MaxCharacterLimitExtension { get; set; }

    /// <value>Maximum number of credits that the credit limit can be exceeded by. Managed by the workspace admin. `"unlimited"` means no cap, `0` means usage-based billing is disabled.</value>
    [JsonPropertyName("max_credit_limit_extension")]
    public required OneOf<int, MaxCreditLimitExtension22> MaxCreditLimitExtension { get; set; }

    /// <value>Whether the workspace is entitled to enter overages (usage-based billing).</value>
    [JsonPropertyName("can_extend_character_limit")]
    public required bool CanExtendCharacterLimit { get; set; }

    /// <value>Deprecated: use `max_credit_limit_extension != 0`. Whether the user is allowed to extend their character limit.</value>
    [JsonPropertyName("allowed_to_extend_character_limit")]
    public required bool AllowedToExtendCharacterLimit { get; set; }

    /// <value>The Unix timestamp of the next character count reset.</value>
    [JsonPropertyName("next_character_count_reset_unix")]
    public int? NextCharacterCountResetUnix { get; set; }

    /// <value>The number of voice slots used by the user.</value>
    [JsonPropertyName("voice_slots_used")]
    public required int VoiceSlotsUsed { get; set; }

    /// <value>The number of professional voice slots used. For consolidated billing this is the group-wide count across all workspaces in the group; see professional_voice_slots_used_in_workspace for the current workspace only.</value>
    [JsonPropertyName("professional_voice_slots_used")]
    public required int ProfessionalVoiceSlotsUsed { get; set; }

    /// <value>The number of professional voice slots used in the current workspace. For consolidated billing, professional_voice_slots_used counts across all workspaces in the group, while this counts only the current workspace.</value>
    [JsonPropertyName("professional_voice_slots_used_in_workspace")]
    public required int ProfessionalVoiceSlotsUsedInWorkspace { get; set; }

    /// <value>The maximum number of voice slots allowed for the user.</value>
    [JsonPropertyName("voice_limit")]
    public required int VoiceLimit { get; set; }

    /// <value>The maximum number of voice add/edits allowed for the user.</value>
    [JsonPropertyName("max_voice_add_edits")]
    public int? MaxVoiceAddEdits { get; set; }

    /// <value>The number of voice add/edits used by the user.</value>
    [JsonPropertyName("voice_add_edit_counter")]
    public required int VoiceAddEditCounter { get; set; }

    /// <value>The maximum number of professional voices allowed for the user.</value>
    [JsonPropertyName("professional_voice_limit")]
    public required int ProfessionalVoiceLimit { get; set; }

    /// <value>Whether the user can extend their voice limit.</value>
    [JsonPropertyName("can_extend_voice_limit")]
    public required bool CanExtendVoiceLimit { get; set; }

    /// <value>Whether the user can use instant voice cloning.</value>
    [JsonPropertyName("can_use_instant_voice_cloning")]
    public required bool CanUseInstantVoiceCloning { get; set; }

    /// <value>Whether the user can use professional voice cloning.</value>
    [JsonPropertyName("can_use_professional_voice_cloning")]
    public required bool CanUseProfessionalVoiceCloning { get; set; }

    /// <value>The currency of the user's subscription.</value>
    [JsonPropertyName("currency")]
    public Currency? Currency { get; set; }

    /// <value>Currency/amount pair.</value>
    [JsonPropertyName("current_overage")]
    public required Price CurrentOverage { get; set; }

    [JsonPropertyName("status")]
    public required SubscriptionStatusType Status { get; set; }

    /// <value>The billing period of the user's subscription.</value>
    [JsonPropertyName("billing_period")]
    public BillingPeriod? BillingPeriod { get; set; }

    /// <value>The character refresh period of the user's subscription.</value>
    [JsonPropertyName("character_refresh_period")]
    public CharacterRefreshPeriod? CharacterRefreshPeriod { get; set; }

    /// <value>The next invoice for the user.</value>
    [JsonPropertyName("next_invoice")]
    public InvoiceResponse? NextInvoice { get; set; }

    /// <value>The open invoices for the user.</value>
    [JsonPropertyName("open_invoices")]
    public IEnumerable<InvoiceResponse> OpenInvoices { get; set; } = new List<InvoiceResponse>();

    /// <value>Whether the user has open invoices.</value>
    [JsonPropertyName("has_open_invoices")]
    public required bool HasOpenInvoices { get; set; }

    /// <value>Whether cancelling the subscription now ends it immediately, because an unpaid invoice is being collected, rather than at the end of the billing period.</value>
    [JsonPropertyName("cancels_immediately")]
    public bool? CancelsImmediately { get; set; }

    /// <value>The pending change for the user.</value>
    [JsonPropertyName("pending_change")]
    public PendingChange? PendingChange { get; set; }

    /// <value>True if any workspace owned by this user's auth account has redeemed the starter first-month discount coupon.</value>
    [JsonPropertyName("has_used_starter_coupon_on_account")]
    public bool? HasUsedStarterCouponOnAccount { get; set; }

    /// <value>True if any workspace owned by this user's auth account has redeemed the creator first-month discount coupon.</value>
    [JsonPropertyName("has_used_creator_coupon_on_account")]
    public bool? HasUsedCreatorCouponOnAccount { get; set; }

    /// <value>True if this user's auth account qualifies for the Starter first-month promo, using the same check as checkout. The starter_discount feature flag still decides whether the promo is offered.</value>
    [JsonPropertyName("is_eligible_for_starter_promo")]
    public bool? IsEligibleForStarterPromo { get; set; }

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
    public virtual bool Equals(Subscription? other)
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
            && ValueEquality.AreEqual(Tier, other.Tier)
            && ValueEquality.AreEqual(CharacterCount, other.CharacterCount)
            && ValueEquality.AreEqual(CharacterLimit, other.CharacterLimit)
            && ValueEquality.AreEqual(MaxCharacterLimitExtension, other.MaxCharacterLimitExtension)
            && ValueEquality.AreEqual(MaxCreditLimitExtension, other.MaxCreditLimitExtension)
            && ValueEquality.AreEqual(CanExtendCharacterLimit, other.CanExtendCharacterLimit)
            && ValueEquality.AreEqual(
                AllowedToExtendCharacterLimit,
                other.AllowedToExtendCharacterLimit
            )
            && ValueEquality.AreEqual(
                NextCharacterCountResetUnix,
                other.NextCharacterCountResetUnix
            )
            && ValueEquality.AreEqual(VoiceSlotsUsed, other.VoiceSlotsUsed)
            && ValueEquality.AreEqual(ProfessionalVoiceSlotsUsed, other.ProfessionalVoiceSlotsUsed)
            && ValueEquality.AreEqual(
                ProfessionalVoiceSlotsUsedInWorkspace,
                other.ProfessionalVoiceSlotsUsedInWorkspace
            )
            && ValueEquality.AreEqual(VoiceLimit, other.VoiceLimit)
            && ValueEquality.AreEqual(MaxVoiceAddEdits, other.MaxVoiceAddEdits)
            && ValueEquality.AreEqual(VoiceAddEditCounter, other.VoiceAddEditCounter)
            && ValueEquality.AreEqual(ProfessionalVoiceLimit, other.ProfessionalVoiceLimit)
            && ValueEquality.AreEqual(CanExtendVoiceLimit, other.CanExtendVoiceLimit)
            && ValueEquality.AreEqual(CanUseInstantVoiceCloning, other.CanUseInstantVoiceCloning)
            && ValueEquality.AreEqual(
                CanUseProfessionalVoiceCloning,
                other.CanUseProfessionalVoiceCloning
            )
            && ValueEquality.AreEqual(Currency, other.Currency)
            && ValueEquality.AreEqual(CurrentOverage, other.CurrentOverage)
            && ValueEquality.AreEqual(Status, other.Status)
            && ValueEquality.AreEqual(BillingPeriod, other.BillingPeriod)
            && ValueEquality.AreEqual(CharacterRefreshPeriod, other.CharacterRefreshPeriod)
            && ValueEquality.AreEqual(NextInvoice, other.NextInvoice)
            && ValueEquality.AreEqual(OpenInvoices, other.OpenInvoices)
            && ValueEquality.AreEqual(HasOpenInvoices, other.HasOpenInvoices)
            && ValueEquality.AreEqual(CancelsImmediately, other.CancelsImmediately)
            && ValueEquality.AreEqual(PendingChange, other.PendingChange)
            && ValueEquality.AreEqual(
                HasUsedStarterCouponOnAccount,
                other.HasUsedStarterCouponOnAccount
            )
            && ValueEquality.AreEqual(
                HasUsedCreatorCouponOnAccount,
                other.HasUsedCreatorCouponOnAccount
            )
            && ValueEquality.AreEqual(IsEligibleForStarterPromo, other.IsEligibleForStarterPromo)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Tier);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CharacterCount);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CharacterLimit);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MaxCharacterLimitExtension);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MaxCreditLimitExtension);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CanExtendCharacterLimit);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AllowedToExtendCharacterLimit);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(NextCharacterCountResetUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VoiceSlotsUsed);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ProfessionalVoiceSlotsUsed);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ProfessionalVoiceSlotsUsedInWorkspace);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VoiceLimit);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MaxVoiceAddEdits);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(VoiceAddEditCounter);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ProfessionalVoiceLimit);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CanExtendVoiceLimit);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CanUseInstantVoiceCloning);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CanUseProfessionalVoiceCloning);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Currency);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CurrentOverage);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Status);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BillingPeriod);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CharacterRefreshPeriod);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(NextInvoice);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(OpenInvoices);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(HasOpenInvoices);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CancelsImmediately);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PendingChange);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(HasUsedStarterCouponOnAccount);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(HasUsedCreatorCouponOnAccount);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(IsEligibleForStarterPromo);
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
