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
public record ConvertTextToSpeechRequest
{
    [JsonIgnore]
    public bool? EnableLogging { get; set; }

    [JsonIgnore]
    public int? OptimizeStreamingLatency { get; set; }

    [JsonIgnore]
    public ConvertTextToSpeechRequestOutputFormat? OutputFormat { get; set; }

    [JsonIgnore]
    public string? XiApiKey { get; set; }

    [JsonIgnore]
    public required global::ElevenLabs.BodyTextToSpeechFull Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record ConvertWithTimestampsTextToSpeechRequest
{
    [JsonIgnore]
    public bool? EnableLogging { get; set; }

    [JsonIgnore]
    public int? OptimizeStreamingLatency { get; set; }

    [JsonIgnore]
    public ConvertWithTimestampsTextToSpeechRequestOutputFormat? OutputFormat { get; set; }

    [JsonIgnore]
    public string? XiApiKey { get; set; }

    [JsonIgnore]
    public required global::ElevenLabs.BodyTextToSpeechFullWithTimestamps Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record StreamTextToSpeechRequest
{
    [JsonIgnore]
    public bool? EnableLogging { get; set; }

    [JsonIgnore]
    public int? OptimizeStreamingLatency { get; set; }

    [JsonIgnore]
    public StreamTextToSpeechRequestOutputFormat? OutputFormat { get; set; }

    [JsonIgnore]
    public string? XiApiKey { get; set; }

    [JsonIgnore]
    public required global::ElevenLabs.BodyTextToSpeechStream Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record StreamTextToSpeechWithTimestampsRequest
{
    [JsonIgnore]
    public bool? EnableLogging { get; set; }

    [JsonIgnore]
    public int? OptimizeStreamingLatency { get; set; }

    [JsonIgnore]
    public StreamWithTimestampsTextToSpeechRequestOutputFormat? OutputFormat { get; set; }

    [JsonIgnore]
    public string? XiApiKey { get; set; }

    [JsonIgnore]
    public required global::ElevenLabs.BodyTextToSpeechStreamWithTimestamps Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
