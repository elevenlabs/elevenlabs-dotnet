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

/// <summary>Defines asset positioning and transformation on canvas.</summary>
[Serializable]
public record CanvasPlacement : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("x_relative")]
    public double? XRelative { get; set; }

    [JsonPropertyName("y_relative")]
    public double? YRelative { get; set; }

    [JsonPropertyName("scale_x")]
    public double? ScaleX { get; set; }

    [JsonPropertyName("scale_y")]
    public double? ScaleY { get; set; }

    [JsonPropertyName("pivot_x")]
    public double? PivotX { get; set; }

    [JsonPropertyName("pivot_y")]
    public double? PivotY { get; set; }

    [JsonPropertyName("skew_x")]
    public double? SkewX { get; set; }

    [JsonPropertyName("skew_y")]
    public double? SkewY { get; set; }

    [JsonPropertyName("crop_top")]
    public double? CropTop { get; set; }

    [JsonPropertyName("crop_right")]
    public double? CropRight { get; set; }

    [JsonPropertyName("crop_bottom")]
    public double? CropBottom { get; set; }

    [JsonPropertyName("crop_left")]
    public double? CropLeft { get; set; }

    [JsonPropertyName("flip_x")]
    public bool? FlipX { get; set; }

    [JsonPropertyName("flip_y")]
    public bool? FlipY { get; set; }

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
    public virtual bool Equals(CanvasPlacement? other)
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
            && ValueEquality.AreEqual(XRelative, other.XRelative)
            && ValueEquality.AreEqual(YRelative, other.YRelative)
            && ValueEquality.AreEqual(ScaleX, other.ScaleX)
            && ValueEquality.AreEqual(ScaleY, other.ScaleY)
            && ValueEquality.AreEqual(PivotX, other.PivotX)
            && ValueEquality.AreEqual(PivotY, other.PivotY)
            && ValueEquality.AreEqual(SkewX, other.SkewX)
            && ValueEquality.AreEqual(SkewY, other.SkewY)
            && ValueEquality.AreEqual(CropTop, other.CropTop)
            && ValueEquality.AreEqual(CropRight, other.CropRight)
            && ValueEquality.AreEqual(CropBottom, other.CropBottom)
            && ValueEquality.AreEqual(CropLeft, other.CropLeft)
            && ValueEquality.AreEqual(FlipX, other.FlipX)
            && ValueEquality.AreEqual(FlipY, other.FlipY)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(XRelative);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(YRelative);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ScaleX);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ScaleY);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PivotX);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PivotY);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SkewX);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(SkewY);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CropTop);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CropRight);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CropBottom);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(CropLeft);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FlipX);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(FlipY);
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
