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
public record InvoiceResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>The amount due in cents.</value>
    [JsonPropertyName("amount_due_cents")]
    public required int AmountDueCents { get; set; }

    /// <value>The subtotal amount in cents before tax (exclusive of tax and discounts).</value>
    [JsonPropertyName("subtotal_cents")]
    public int? SubtotalCents { get; set; }

    /// <value>The tax amount in cents.</value>
    [JsonPropertyName("tax_cents")]
    public int? TaxCents { get; set; }

    /// <value>Deprecated. Use [discounts] instead. The discount applied to the invoice. E.g. [20.0f] for 20% off.</value>
    [JsonPropertyName("discount_percent_off")]
    public double? DiscountPercentOff { get; set; }

    /// <value>Deprecated. Use [discounts] instead. The discount applied to the invoice. E.g. [20.0f] for 20 cents off.</value>
    [JsonPropertyName("discount_amount_off")]
    public double? DiscountAmountOff { get; set; }

    /// <value>The discounts applied to the invoice.</value>
    [JsonPropertyName("discounts")]
    public IEnumerable<DiscountResponseModel> Discounts { get; set; } =
        new List<DiscountResponseModel>();

    /// <value>The Unix timestamp of the next payment attempt. -1 when there is no next payment attempt.</value>
    [JsonPropertyName("next_payment_attempt_unix")]
    public required int NextPaymentAttemptUnix { get; set; }

    /// <value>Deprecated. Use [payment_intent_statusses] instead. The status of this invoice's first payment intent. None when there is no payment intent.</value>
    [JsonPropertyName("payment_intent_status")]
    public InvoiceResponsePaymentIntentStatus? PaymentIntentStatus { get; set; }

    /// <value>The statuses of this invoice's payment intents. Empty list when there are no payment intents.</value>
    [JsonPropertyName("payment_intent_statusses")]
    public IEnumerable<InvoiceResponsePaymentIntentStatussesItem> PaymentIntentStatusses { get; set; } =
        new List<InvoiceResponsePaymentIntentStatussesItem>();

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
    public virtual bool Equals(InvoiceResponse? other)
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
            && ValueEquality.AreEqual(AmountDueCents, other.AmountDueCents)
            && ValueEquality.AreEqual(SubtotalCents, other.SubtotalCents)
            && ValueEquality.AreEqual(TaxCents, other.TaxCents)
            && ValueEquality.AreEqual(DiscountPercentOff, other.DiscountPercentOff)
            && ValueEquality.AreEqual(DiscountAmountOff, other.DiscountAmountOff)
            && ValueEquality.AreEqual(Discounts, other.Discounts)
            && ValueEquality.AreEqual(NextPaymentAttemptUnix, other.NextPaymentAttemptUnix)
            && ValueEquality.AreEqual(PaymentIntentStatus, other.PaymentIntentStatus)
            && ValueEquality.AreEqual(PaymentIntentStatusses, other.PaymentIntentStatusses)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AmountDueCents);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SubtotalCents);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TaxCents);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DiscountPercentOff);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DiscountAmountOff);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Discounts);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(NextPaymentAttemptUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PaymentIntentStatus);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PaymentIntentStatusses);
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
