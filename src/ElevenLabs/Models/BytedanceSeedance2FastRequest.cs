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

/// <summary>
/// Request body for the ByteDance Seedance 2.0 Fast video model.
///
/// ByteDance models are disabled by default and require explicit approval
/// before use. Contact support to request access.
/// </summary>
[Serializable]
public record BytedanceSeedance2FastRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>Include to send the generation's result to the workspace's configured flows webhooks once it completes or fails. The webhook payload matches the terminal response of the corresponding GET endpoint.</value>
    [JsonPropertyName("webhook")]
    public WebhookTarget? Webhook { get; set; }

    /// <value>A text description of the video to generate.</value>
    [JsonPropertyName("prompt")]
    public required string Prompt { get; set; }

    /// <value>The aspect ratio of the output video. With `auto`, the model picks an aspect ratio based on the inputs.</value>
    [JsonPropertyName("aspect_ratio")]
    public BytedanceSeedance2FastRequestAspectRatio? AspectRatio { get; set; }

    /// <value>The duration of the output video in seconds.</value>
    [JsonPropertyName("duration_secs")]
    public int? DurationSecs { get; set; }

    /// <value>A seed for reproducible generation: the same seed and inputs give similar output across generations. Omit for random.</value>
    [JsonPropertyName("seed")]
    public int? Seed { get; set; }

    /// <value>Whether to generate audio with the video.</value>
    [JsonPropertyName("generate_audio")]
    public bool? GenerateAudio { get; set; }

    /// <value>The image to use as the video's first frame.</value>
    [JsonPropertyName("start_frame")]
    public ImageReference? StartFrame { get; set; }

    /// <value>The image to use as the video's last frame.</value>
    [JsonPropertyName("end_frame")]
    public ImageReference? EndFrame { get; set; }

    /// <value>Up to 9 reference images to draw subjects from. Cannot be combined with `start_frame`/`end_frame`.</value>
    [JsonPropertyName("images")]
    public IEnumerable<ImageReference>? Images { get; set; }

    /// <value>Up to 3 reference videos to draw subjects or motion from. Cannot be combined with `start_frame`/`end_frame`.</value>
    [JsonPropertyName("videos")]
    public IEnumerable<VideoReference>? Videos { get; set; }

    /// <value>Up to 3 reference audios, e.g. for lipsync. Requires at least one of `images` or `videos`, and cannot be combined with `start_frame`/`end_frame`.</value>
    [JsonPropertyName("audios")]
    public IEnumerable<AudioReference>? Audios { get; set; }

    /// <value>The model to use for the generation.</value>
    [JsonPropertyName("model_id")]
    public required BytedanceSeedance2FastRequestModelId ModelId { get; set; }

    /// <value>The resolution of the output video.</value>
    [JsonPropertyName("resolution")]
    public BytedanceSeedance2FastRequestResolution? Resolution { get; set; }

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
    public virtual bool Equals(BytedanceSeedance2FastRequest? other)
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
            && ValueEquality.AreEqual(Prompt, other.Prompt)
            && ValueEquality.AreEqual(AspectRatio, other.AspectRatio)
            && ValueEquality.AreEqual(DurationSecs, other.DurationSecs)
            && ValueEquality.AreEqual(Seed, other.Seed)
            && ValueEquality.AreEqual(GenerateAudio, other.GenerateAudio)
            && ValueEquality.AreEqual(StartFrame, other.StartFrame)
            && ValueEquality.AreEqual(EndFrame, other.EndFrame)
            && ValueEquality.AreEqual(Images, other.Images)
            && ValueEquality.AreEqual(Videos, other.Videos)
            && ValueEquality.AreEqual(Audios, other.Audios)
            && ValueEquality.AreEqual(ModelId, other.ModelId)
            && ValueEquality.AreEqual(Resolution, other.Resolution)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Webhook);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Prompt);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AspectRatio);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DurationSecs);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Seed);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(GenerateAudio);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(StartFrame);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EndFrame);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Images);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Videos);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Audios);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ModelId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Resolution);
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
