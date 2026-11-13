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

/// <summary>Request body for the OpenAI GPT Image 1.5 model.</summary>
[Serializable]
public record GptImage15Request : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>Include to send the generation's result to the workspace's configured flows webhooks once it completes or fails. The webhook payload matches the terminal response of the corresponding GET endpoint.</value>
    [JsonPropertyName("webhook")]
    public WebhookTarget? Webhook { get; set; }

    /// <value>A text description of the image to generate.</value>
    [JsonPropertyName("prompt")]
    public required string Prompt { get; set; }

    /// <value>Up to 5 reference images to edit or draw from.</value>
    [JsonPropertyName("images")]
    public IEnumerable<ImageReference>? Images { get; set; }

    /// <value>An image whose fully transparent areas mark where the first reference image may be edited; requires `images`.</value>
    [JsonPropertyName("mask")]
    public ImageReference? Mask { get; set; }

    /// <value>The quality of the output image.</value>
    [JsonPropertyName("quality")]
    public GptImage15RequestQuality? Quality { get; set; }

    /// <value>The background of the output image. With `auto`, the model picks the background that suits the image.</value>
    [JsonPropertyName("background")]
    public GptImage15RequestBackground? Background { get; set; }

    /// <value>The aspect ratio of the output image.</value>
    [JsonPropertyName("aspect_ratio")]
    public GptImage15RequestAspectRatio? AspectRatio { get; set; }

    /// <value>The model to use for the generation.</value>
    [JsonPropertyName("model_id")]
    public required GptImage15RequestModelId ModelId { get; set; }

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
    public virtual bool Equals(GptImage15Request? other)
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
            && ValueEquality.AreEqual(Images, other.Images)
            && ValueEquality.AreEqual(Mask, other.Mask)
            && ValueEquality.AreEqual(Quality, other.Quality)
            && ValueEquality.AreEqual(Background, other.Background)
            && ValueEquality.AreEqual(AspectRatio, other.AspectRatio)
            && ValueEquality.AreEqual(ModelId, other.ModelId)
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
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Images);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Mask);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Quality);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Background);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(AspectRatio);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ModelId);
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
