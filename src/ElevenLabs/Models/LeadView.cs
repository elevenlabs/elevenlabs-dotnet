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
public record LeadView : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("lead_id")]
    public required string LeadId { get; set; }

    /// <value>The `id` given to this recipient when the campaign was created.</value>
    [JsonPropertyName("recipient_id")]
    public string? RecipientId { get; set; }

    /// <value>The number the lead's next call dials. It changes when the lead moves on to another listed number or the contact asks to be called on a different one.</value>
    [JsonPropertyName("phone_number")]
    public required string PhoneNumber { get; set; }

    /// <value>The lead's listed numbers, in calling order.</value>
    [JsonPropertyName("phone_numbers")]
    public IEnumerable<string>? PhoneNumbers { get; set; }

    /// <value>The position in `phone_numbers` of the number being called.</value>
    [JsonPropertyName("phone_numbers_index")]
    public required int PhoneNumbersIndex { get; set; }

    /// <value>The contact's identity: the `user_id` submitted in `conversation_initiation_client_data`, else the lead's phone number.</value>
    [JsonPropertyName("user_id")]
    public required string UserId { get; set; }

    /// <value>Calls placed, counted against the policy's `max_total_calls`.</value>
    [JsonPropertyName("attempt_count")]
    public required int AttemptCount { get; set; }

    /// <value>Failed calls to the current number; resets on a new number.</value>
    [JsonPropertyName("failure_count")]
    public required int FailureCount { get; set; }

    /// <value>Callbacks the contact asked for.</value>
    [JsonPropertyName("callback_count")]
    public required int CallbackCount { get; set; }

    /// <value>Times the contact asked to be called on another number.</value>
    [JsonPropertyName("redirect_count")]
    public required int RedirectCount { get; set; }

    /// <value>Set when the contact asked not to be called, the lead was removed, or the campaign stopped. The lead isn't called again.</value>
    [JsonPropertyName("do_not_call")]
    public required bool DoNotCall { get; set; }

    /// <value>Why the lead won't be called again; unset while it may be.</value>
    [JsonPropertyName("terminal_disposition")]
    public TerminalDisposition? TerminalDisposition { get; set; }

    /// <value>When the lead joined the campaign; unset on older leads.</value>
    [JsonPropertyName("created_at_unix")]
    public int? CreatedAtUnix { get; set; }

    [JsonPropertyName("updated_at_unix")]
    public required int UpdatedAtUnix { get; set; }

    /// <value>The dynamic variables submitted for the lead, with secrets redacted.</value>
    [JsonPropertyName("dynamic_variables")]
    public Dictionary<string, object?> DynamicVariables { get; set; } =
        new Dictionary<string, object?>();

    [JsonPropertyName("overrides")]
    public required FlattenedConfigOverrides Overrides { get; set; }

    /// <value>The lead's latest message delivery; set on message campaigns.</value>
    [JsonPropertyName("delivery")]
    public LeadDeliveryView? Delivery { get; set; }

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
    public virtual bool Equals(LeadView? other)
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
            && ValueEquality.AreEqual(LeadId, other.LeadId)
            && ValueEquality.AreEqual(RecipientId, other.RecipientId)
            && ValueEquality.AreEqual(PhoneNumber, other.PhoneNumber)
            && ValueEquality.AreEqual(PhoneNumbers, other.PhoneNumbers)
            && ValueEquality.AreEqual(PhoneNumbersIndex, other.PhoneNumbersIndex)
            && ValueEquality.AreEqual(UserId, other.UserId)
            && ValueEquality.AreEqual(AttemptCount, other.AttemptCount)
            && ValueEquality.AreEqual(FailureCount, other.FailureCount)
            && ValueEquality.AreEqual(CallbackCount, other.CallbackCount)
            && ValueEquality.AreEqual(RedirectCount, other.RedirectCount)
            && ValueEquality.AreEqual(DoNotCall, other.DoNotCall)
            && ValueEquality.AreEqual(TerminalDisposition, other.TerminalDisposition)
            && ValueEquality.AreEqual(CreatedAtUnix, other.CreatedAtUnix)
            && ValueEquality.AreEqual(UpdatedAtUnix, other.UpdatedAtUnix)
            && ValueEquality.AreEqual(DynamicVariables, other.DynamicVariables)
            && ValueEquality.AreEqual(Overrides, other.Overrides)
            && ValueEquality.AreEqual(Delivery, other.Delivery)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(LeadId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RecipientId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PhoneNumber);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PhoneNumbers);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PhoneNumbersIndex);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(UserId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AttemptCount);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FailureCount);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CallbackCount);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RedirectCount);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DoNotCall);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TerminalDisposition);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CreatedAtUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(UpdatedAtUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DynamicVariables);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Overrides);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Delivery);
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
