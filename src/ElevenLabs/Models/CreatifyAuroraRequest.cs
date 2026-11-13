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

/// <summary>Request body for the Creatify Aurora lipsync video model.</summary>
[Serializable]
public record CreatifyAuroraRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>Include to send the generation's result to the workspace's configured flows webhooks once it completes or fails. The webhook payload matches the terminal response of the corresponding GET endpoint.</value>
    [JsonPropertyName("webhook")]
    public WebhookTarget? Webhook { get; set; }

    /// <value>The model to use for the generation.</value>
    [JsonPropertyName("model_id")]
    public required CreatifyAuroraRequestModelId ModelId { get; set; }

    [JsonPropertyName("image")]
    public required ImageReference Image { get; set; }

    [JsonPropertyName("audio")]
    public required AudioReference Audio { get; set; }

    /// <value>The resolution of the output video.</value>
    [JsonPropertyName("resolution")]
    public CreatifyAuroraRequestResolution? Resolution { get; set; }

    /// <value>How strongly the generation adheres to the input image. Omit to use the model's default.</value>
    [JsonPropertyName("guidance_scale")]
    public double? GuidanceScale { get; set; }

    /// <value>How strongly the lip movements adhere to the audio. Omit to use the model's default.</value>
    [JsonPropertyName("audio_guidance_scale")]
    public double? AudioGuidanceScale { get; set; }

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
    public virtual bool Equals(CreatifyAuroraRequest? other)
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
            && ValueEquality.AreEqual(Webhook, other.Webhook)
            && ValueEquality.AreEqual(ModelId, other.ModelId)
            && ValueEquality.AreEqual(Image, other.Image)
            && ValueEquality.AreEqual(Audio, other.Audio)
            && ValueEquality.AreEqual(Resolution, other.Resolution)
            && ValueEquality.AreEqual(GuidanceScale, other.GuidanceScale)
            && ValueEquality.AreEqual(AudioGuidanceScale, other.AudioGuidanceScale)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Webhook);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ModelId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Image);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Audio);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Resolution);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(GuidanceScale);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AudioGuidanceScale);
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
