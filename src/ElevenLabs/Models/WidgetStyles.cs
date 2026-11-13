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
public record WidgetStyles : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>The base background color.</value>
    [JsonPropertyName("base")]
    public string? Base { get; set; }

    /// <value>The color of the base background when hovered.</value>
    [JsonPropertyName("base_hover")]
    public string? BaseHover { get; set; }

    /// <value>The color of the base background when active (clicked).</value>
    [JsonPropertyName("base_active")]
    public string? BaseActive { get; set; }

    /// <value>The color of the border against the base background.</value>
    [JsonPropertyName("base_border")]
    public string? BaseBorder { get; set; }

    /// <value>The color of subtle text against the base background.</value>
    [JsonPropertyName("base_subtle")]
    public string? BaseSubtle { get; set; }

    /// <value>The color of primary text against the base background.</value>
    [JsonPropertyName("base_primary")]
    public string? BasePrimary { get; set; }

    /// <value>The color of error text against the base background.</value>
    [JsonPropertyName("base_error")]
    public string? BaseError { get; set; }

    /// <value>The accent background color.</value>
    [JsonPropertyName("accent")]
    public string? Accent { get; set; }

    /// <value>The color of the accent background when hovered.</value>
    [JsonPropertyName("accent_hover")]
    public string? AccentHover { get; set; }

    /// <value>The color of the accent background when active (clicked).</value>
    [JsonPropertyName("accent_active")]
    public string? AccentActive { get; set; }

    /// <value>The color of the border against the accent background.</value>
    [JsonPropertyName("accent_border")]
    public string? AccentBorder { get; set; }

    /// <value>The color of subtle text against the accent background.</value>
    [JsonPropertyName("accent_subtle")]
    public string? AccentSubtle { get; set; }

    /// <value>The color of primary text against the accent background.</value>
    [JsonPropertyName("accent_primary")]
    public string? AccentPrimary { get; set; }

    /// <value>The padding around the edges of the viewport.</value>
    [JsonPropertyName("overlay_padding")]
    public double? OverlayPadding { get; set; }

    /// <value>The radius of the buttons.</value>
    [JsonPropertyName("button_radius")]
    public double? ButtonRadius { get; set; }

    /// <value>The radius of the input fields.</value>
    [JsonPropertyName("input_radius")]
    public double? InputRadius { get; set; }

    /// <value>The radius of the chat bubbles.</value>
    [JsonPropertyName("bubble_radius")]
    public double? BubbleRadius { get; set; }

    /// <value>The default radius of sheets.</value>
    [JsonPropertyName("sheet_radius")]
    public double? SheetRadius { get; set; }

    /// <value>The radius of the sheet in compact mode.</value>
    [JsonPropertyName("compact_sheet_radius")]
    public double? CompactSheetRadius { get; set; }

    /// <value>The radius of the dropdown sheet.</value>
    [JsonPropertyName("dropdown_sheet_radius")]
    public double? DropdownSheetRadius { get; set; }

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
    public virtual bool Equals(WidgetStyles? other)
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
            && ValueEquality.AreEqual(Base, other.Base)
            && ValueEquality.AreEqual(BaseHover, other.BaseHover)
            && ValueEquality.AreEqual(BaseActive, other.BaseActive)
            && ValueEquality.AreEqual(BaseBorder, other.BaseBorder)
            && ValueEquality.AreEqual(BaseSubtle, other.BaseSubtle)
            && ValueEquality.AreEqual(BasePrimary, other.BasePrimary)
            && ValueEquality.AreEqual(BaseError, other.BaseError)
            && ValueEquality.AreEqual(Accent, other.Accent)
            && ValueEquality.AreEqual(AccentHover, other.AccentHover)
            && ValueEquality.AreEqual(AccentActive, other.AccentActive)
            && ValueEquality.AreEqual(AccentBorder, other.AccentBorder)
            && ValueEquality.AreEqual(AccentSubtle, other.AccentSubtle)
            && ValueEquality.AreEqual(AccentPrimary, other.AccentPrimary)
            && ValueEquality.AreEqual(OverlayPadding, other.OverlayPadding)
            && ValueEquality.AreEqual(ButtonRadius, other.ButtonRadius)
            && ValueEquality.AreEqual(InputRadius, other.InputRadius)
            && ValueEquality.AreEqual(BubbleRadius, other.BubbleRadius)
            && ValueEquality.AreEqual(SheetRadius, other.SheetRadius)
            && ValueEquality.AreEqual(CompactSheetRadius, other.CompactSheetRadius)
            && ValueEquality.AreEqual(DropdownSheetRadius, other.DropdownSheetRadius)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Base);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BaseHover);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BaseActive);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BaseBorder);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BaseSubtle);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BasePrimary);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BaseError);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Accent);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AccentHover);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AccentActive);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AccentBorder);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AccentSubtle);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AccentPrimary);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(OverlayPadding);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ButtonRadius);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(InputRadius);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(BubbleRadius);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SheetRadius);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CompactSheetRadius);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DropdownSheetRadius);
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
