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

/// <summary>The template a business-initiated conversation opened with, and how far it got.</summary>
[Serializable]
public record WhatsAppOpeningMessage : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("template_name")]
    public required string TemplateName { get; set; }

    [JsonPropertyName("wamid")]
    public string? Wamid { get; set; }

    [JsonPropertyName("sent_at_unix")]
    public required int SentAtUnix { get; set; }

    [JsonPropertyName("delivered_at_unix")]
    public int? DeliveredAtUnix { get; set; }

    [JsonPropertyName("read_at_unix")]
    public int? ReadAtUnix { get; set; }

    [JsonPropertyName("replied_at_unix")]
    public int? RepliedAtUnix { get; set; }

    [JsonPropertyName("failed_at_unix")]
    public int? FailedAtUnix { get; set; }

    [JsonPropertyName("error_code")]
    public string? ErrorCode { get; set; }

    [JsonPropertyName("pricing_category")]
    public string? PricingCategory { get; set; }

    [JsonPropertyName("billable")]
    public bool? Billable { get; set; }

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
    public virtual bool Equals(WhatsAppOpeningMessage? other)
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
            && ValueEquality.AreEqual(TemplateName, other.TemplateName)
            && ValueEquality.AreEqual(Wamid, other.Wamid)
            && ValueEquality.AreEqual(SentAtUnix, other.SentAtUnix)
            && ValueEquality.AreEqual(DeliveredAtUnix, other.DeliveredAtUnix)
            && ValueEquality.AreEqual(ReadAtUnix, other.ReadAtUnix)
            && ValueEquality.AreEqual(RepliedAtUnix, other.RepliedAtUnix)
            && ValueEquality.AreEqual(FailedAtUnix, other.FailedAtUnix)
            && ValueEquality.AreEqual(ErrorCode, other.ErrorCode)
            && ValueEquality.AreEqual(PricingCategory, other.PricingCategory)
            && ValueEquality.AreEqual(Billable, other.Billable)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(TemplateName);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Wamid);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SentAtUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DeliveredAtUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ReadAtUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(RepliedAtUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FailedAtUnix);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ErrorCode);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PricingCategory);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Billable);
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
