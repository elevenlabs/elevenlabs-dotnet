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
public record ListDubbingRequest
{
    [JsonIgnore]
    public string? Cursor { get; set; }

    [JsonIgnore]
    public int? PageSize { get; set; }

    [JsonIgnore]
    public ListDubbingRequestDubbingStatus? DubbingStatus { get; set; }

    [JsonIgnore]
    public IEnumerable<ListDubbingRequestDubbingStatusesItem> DubbingStatuses { get; set; } =
        new List<ListDubbingRequestDubbingStatusesItem>();

    [JsonIgnore]
    public IEnumerable<ListDubbingRequestDubbingModelsItem> DubbingModels { get; set; } =
        new List<ListDubbingRequestDubbingModelsItem>();

    [JsonIgnore]
    public IEnumerable<string> TargetLanguageCodes { get; set; } = new List<string>();

    [JsonIgnore]
    public IEnumerable<ListDubbingRequestCreationSourcesItem> CreationSources { get; set; } =
        new List<ListDubbingRequestCreationSourcesItem>();

    [JsonIgnore]
    public ListDubbingRequestFilterByCreator? FilterByCreator { get; set; }

    [JsonIgnore]
    public ListDubbingRequestOrderBy? OrderBy { get; set; }

    [JsonIgnore]
    public ListDubbingRequestOrderDirection? OrderDirection { get; set; }

    [JsonIgnore]
    public string? XiApiKey { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record CreateDubbingRequest
{
    [JsonIgnore]
    public string? XiApiKey { get; set; }

    [JsonIgnore]
    public required global::ElevenLabs.DubRequest Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record GetDubbingRequest
{
    [JsonIgnore]
    public string? XiApiKey { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record DeleteDubbingRequest
{
    [JsonIgnore]
    public string? XiApiKey { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
