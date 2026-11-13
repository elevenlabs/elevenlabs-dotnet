using ElevenLabs;
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

namespace ElevenLabs.Agents;

[Serializable]
public record ListToolsRequest
{
    [JsonIgnore]
    public string? Search { get; set; }

    [JsonIgnore]
    public int? PageSize { get; set; }

    [JsonIgnore]
    public bool? ShowOnlyOwnedDocuments { get; set; }

    [JsonIgnore]
    public string? CreatedByUserId { get; set; }

    [JsonIgnore]
    public IEnumerable<ToolTypeFilter> Types { get; set; } = new List<ToolTypeFilter>();

    [JsonIgnore]
    public SortDirection1? SortDirection { get; set; }

    [JsonIgnore]
    public ToolSortBy? SortBy { get; set; }

    [JsonIgnore]
    public string? UsedByAgentId { get; set; }

    [JsonIgnore]
    public string? Cursor { get; set; }

    [JsonIgnore]
    public string? XiApiKey { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record CreateToolsRequest
{
    [JsonIgnore]
    public string? XiApiKey { get; set; }

    [JsonIgnore]
    public required global::ElevenLabs.ToolRequestModel Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record GetToolsRequest
{
    [JsonIgnore]
    public string? Environment { get; set; }

    [JsonIgnore]
    public string? XiApiKey { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record UpdateToolsRequest
{
    [JsonIgnore]
    public string? XiApiKey { get; set; }

    [JsonIgnore]
    public required global::ElevenLabs.ToolRequestModel Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record DeleteToolsRequest
{
    [JsonIgnore]
    public bool? Force { get; set; }

    [JsonIgnore]
    public string? XiApiKey { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record GetDependentAgentsToolsRequest
{
    [JsonIgnore]
    public string? Cursor { get; set; }

    [JsonIgnore]
    public int? PageSize { get; set; }

    [JsonIgnore]
    public string? XiApiKey { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
