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
public record OrderResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("order_id")]
    public required string OrderId { get; set; }

    /// <value>The display name of the order.</value>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("state")]
    public required OrderState State { get; set; }

    /// <value>The list of items in this order with their quotes.</value>
    [JsonPropertyName("items")]
    public IEnumerable<OrderItemInfo> Items { get; set; } = new List<OrderItemInfo>();

    /// <value>The total price for all items in USD. Excluded from response until quotes are available.</value>
    [JsonPropertyName("total_amount_usd")]
    public double? TotalAmountUsd { get; set; }

    /// <value>Whether this is a sandbox order that auto-progresses without producer intervention.</value>
    [JsonPropertyName("sandbox")]
    public bool? Sandbox { get; set; }

    /// <value>The timestamp when the order was created.</value>
    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

    /// <value>The timestamp when the order was submitted, if applicable.</value>
    [JsonPropertyName("submitted_at")]
    public DateTime? SubmittedAt { get; set; }

    /// <value>The timestamp when payment was received, if applicable.</value>
    [JsonPropertyName("paid_at")]
    public DateTime? PaidAt { get; set; }

    /// <value>The timestamp when the order was accepted for production, if applicable.</value>
    [JsonPropertyName("accepted_at")]
    public DateTime? AcceptedAt { get; set; }

    /// <value>The timestamp when the order was completed, if applicable.</value>
    [JsonPropertyName("completed_at")]
    public DateTime? CompletedAt { get; set; }

    /// <value>The reason the order was cancelled, if applicable.</value>
    [JsonPropertyName("cancel_reason")]
    public string? CancelReason { get; set; }

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
    public virtual bool Equals(OrderResponse? other)
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
            && ValueEquality.AreEqual(OrderId, other.OrderId)
            && ValueEquality.AreEqual(Name, other.Name)
            && ValueEquality.AreEqual(State, other.State)
            && ValueEquality.AreEqual(Items, other.Items)
            && ValueEquality.AreEqual(TotalAmountUsd, other.TotalAmountUsd)
            && ValueEquality.AreEqual(Sandbox, other.Sandbox)
            && ValueEquality.AreEqual(CreatedAt, other.CreatedAt)
            && ValueEquality.AreEqual(SubmittedAt, other.SubmittedAt)
            && ValueEquality.AreEqual(PaidAt, other.PaidAt)
            && ValueEquality.AreEqual(AcceptedAt, other.AcceptedAt)
            && ValueEquality.AreEqual(CompletedAt, other.CompletedAt)
            && ValueEquality.AreEqual(CancelReason, other.CancelReason)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(OrderId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Name);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(State);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Items);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TotalAmountUsd);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Sandbox);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CreatedAt);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SubmittedAt);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PaidAt);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AcceptedAt);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CompletedAt);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CancelReason);
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
