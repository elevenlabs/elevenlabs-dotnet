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
using ElevenLabs.CustomerSupport;
using ElevenLabs.CustomerSupport.Requesters;
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

/// <summary>One charge to the reseller's card, paying for one workspace's invoice.</summary>
[Serializable]
public record ResellerInvoiceSummary : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("invoice_id")]
    public required string InvoiceId { get; set; }

    /// <value>The workspace this charge paid for.</value>
    [JsonPropertyName("workspace_id")]
    public string? WorkspaceId { get; set; }

    [JsonPropertyName("workspace_name")]
    public required string WorkspaceName { get; set; }

    /// <value>`open` while the card is still being retried; `void` once retries ran out and the workspace's plan was ended.</value>
    [JsonPropertyName("status")]
    public required ResellerInvoiceStatus Status { get; set; }

    /// <value>Invoice total, in the currency's minor unit.</value>
    [JsonPropertyName("amount_cents")]
    public required int AmountCents { get; set; }

    [JsonPropertyName("currency")]
    public required string Currency { get; set; }

    [JsonPropertyName("created_unix")]
    public required int CreatedUnix { get; set; }

    [JsonPropertyName("paid_unix")]
    public int? PaidUnix { get; set; }

    /// <value>Stripe's hosted payment page, only while open.</value>
    [JsonPropertyName("pay_url")]
    public string? PayUrl { get; set; }

    [JsonPropertyName("pdf_url")]
    public string? PdfUrl { get; set; }

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
    public virtual bool Equals(ResellerInvoiceSummary? other)
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
            && ValueEquality.AreEqual(InvoiceId, other.InvoiceId)
            && ValueEquality.AreEqual(WorkspaceId, other.WorkspaceId)
            && ValueEquality.AreEqual(WorkspaceName, other.WorkspaceName)
            && ValueEquality.AreEqual(Status, other.Status)
            && ValueEquality.AreEqual(AmountCents, other.AmountCents)
            && ValueEquality.AreEqual(Currency, other.Currency)
            && ValueEquality.AreEqual(CreatedUnix, other.CreatedUnix)
            && ValueEquality.AreEqual(PaidUnix, other.PaidUnix)
            && ValueEquality.AreEqual(PayUrl, other.PayUrl)
            && ValueEquality.AreEqual(PdfUrl, other.PdfUrl)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(InvoiceId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(WorkspaceId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(WorkspaceName);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Status);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AmountCents);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Currency);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CreatedUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PaidUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PayUrl);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PdfUrl);
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
