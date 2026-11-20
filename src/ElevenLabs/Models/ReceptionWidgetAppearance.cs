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

/// <summary>How the website widget looks. A null label follows the receptionist's language.</summary>
[Serializable]
public record ReceptionWidgetAppearance : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>First color of the widget's orb gradient, as a hex color.</value>
    [JsonPropertyName("orb_color_1")]
    public required string OrbColor1 { get; set; }

    /// <value>Second color of the widget's orb gradient, as a hex color.</value>
    [JsonPropertyName("orb_color_2")]
    public required string OrbColor2 { get; set; }

    /// <value>Widget size, from the smallest ('tiny') to the largest ('full').</value>
    [JsonPropertyName("variant")]
    public required ReceptionWidgetAppearanceVariant Variant { get; set; }

    /// <value>Where on the page the widget sits.</value>
    [JsonPropertyName("placement")]
    public required ReceptionWidgetAppearancePlacement Placement { get; set; }

    /// <value>Whether visitors can close the widget.</value>
    [JsonPropertyName("dismissible")]
    public required bool Dismissible { get; set; }

    /// <value>Text shown on the widget; null uses the default for the receptionist's language.</value>
    [JsonPropertyName("main_label")]
    public string? MainLabel { get; set; }

    /// <value>Text on the button that starts a call; null uses the default for the receptionist's language.</value>
    [JsonPropertyName("start_call")]
    public string? StartCall { get; set; }

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
    public virtual bool Equals(ReceptionWidgetAppearance? other)
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
            && ValueEquality.AreEqual(OrbColor1, other.OrbColor1)
            && ValueEquality.AreEqual(OrbColor2, other.OrbColor2)
            && ValueEquality.AreEqual(Variant, other.Variant)
            && ValueEquality.AreEqual(Placement, other.Placement)
            && ValueEquality.AreEqual(Dismissible, other.Dismissible)
            && ValueEquality.AreEqual(MainLabel, other.MainLabel)
            && ValueEquality.AreEqual(StartCall, other.StartCall)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(OrbColor1);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(OrbColor2);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Variant);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Placement);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Dismissible);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(MainLabel);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(StartCall);
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
