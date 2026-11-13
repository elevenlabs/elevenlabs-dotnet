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
using global::System.Text.Json.Serialization;
using OneOf;

namespace ElevenLabs;

[Serializable]
public record ConvertTextToDialogueRequest
{
    [JsonIgnore]
    public ConvertTextToDialogueRequestOutputFormat? OutputFormat { get; set; }

    [JsonIgnore]
    public bool? EnableLogging { get; set; }

    [JsonIgnore]
    public string? XiApiKey { get; set; }

    [JsonIgnore]
    public required global::ElevenLabs.BodyTextToDialogueMultiVoiceV1TextToDialoguePost Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record StreamTextToDialogueRequest
{
    [JsonIgnore]
    public AllowedOutputFormats? OutputFormat { get; set; }

    [JsonIgnore]
    public bool? EnableLogging { get; set; }

    [JsonIgnore]
    public string? XiApiKey { get; set; }

    [JsonIgnore]
    public required global::ElevenLabs.BodyTextToDialogueMultiVoiceStreamingV1TextToDialogueStreamPost Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record ConvertWithTimestampsTextToDialogueRequest
{
    [JsonIgnore]
    public ConvertWithTimestampsTextToDialogueRequestOutputFormat? OutputFormat { get; set; }

    [JsonIgnore]
    public bool? EnableLogging { get; set; }

    [JsonIgnore]
    public string? XiApiKey { get; set; }

    [JsonIgnore]
    public required global::ElevenLabs.BodyTextToDialogueFullWithTimestamps Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record StreamWithTimestampsTextToDialogueRequest
{
    [JsonIgnore]
    public AllowedOutputFormats? OutputFormat { get; set; }

    [JsonIgnore]
    public bool? EnableLogging { get; set; }

    [JsonIgnore]
    public string? XiApiKey { get; set; }

    [JsonIgnore]
    public required global::ElevenLabs.BodyTextToDialogueStreamWithTimestamps Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
