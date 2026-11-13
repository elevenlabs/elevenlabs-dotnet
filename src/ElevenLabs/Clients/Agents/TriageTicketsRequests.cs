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
public record ListTriageTicketsRequest
{
    [JsonIgnore]
    public int? PageSize { get; set; }

    [JsonIgnore]
    public string? ConversationId { get; set; }

    [JsonIgnore]
    public AgentConversationTicketStatus? Status { get; set; }

    [JsonIgnore]
    public IEnumerable<AgentConversationTicketSource> Sources { get; set; } =
        new List<AgentConversationTicketSource>();

    [JsonIgnore]
    public IEnumerable<AgentConversationTicketPriority> Priorities { get; set; } =
        new List<AgentConversationTicketPriority>();

    [JsonIgnore]
    public AgentConversationTicketSortBy? SortBy { get; set; }

    [JsonIgnore]
    public string? OwnerUserId { get; set; }

    [JsonIgnore]
    public string? AssigneeUserId { get; set; }

    [JsonIgnore]
    public AgentConversationTicketIssueType? IssueType { get; set; }

    [JsonIgnore]
    public string? Label { get; set; }

    [JsonIgnore]
    public string? MergedIntoTicketId { get; set; }

    [JsonIgnore]
    public string? Search { get; set; }

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
public record CreateManualTriageTicketsRequest
{
    [JsonIgnore]
    public string? XiApiKey { get; set; }

    [JsonIgnore]
    public required global::ElevenLabs.Agents.CreateManualTicketRequestModel Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record ListForWorkspaceTriageTicketsRequest
{
    [JsonIgnore]
    public int? PageSize { get; set; }

    [JsonIgnore]
    public string? AgentId { get; set; }

    [JsonIgnore]
    public AgentConversationTicketStatus? Status { get; set; }

    [JsonIgnore]
    public IEnumerable<AgentConversationTicketSource> Sources { get; set; } =
        new List<AgentConversationTicketSource>();

    [JsonIgnore]
    public IEnumerable<AgentConversationTicketPriority> Priorities { get; set; } =
        new List<AgentConversationTicketPriority>();

    [JsonIgnore]
    public AgentConversationTicketSortBy? SortBy { get; set; }

    [JsonIgnore]
    public string? OwnerUserId { get; set; }

    [JsonIgnore]
    public string? AssigneeUserId { get; set; }

    [JsonIgnore]
    public AgentConversationTicketIssueType? IssueType { get; set; }

    [JsonIgnore]
    public string? Label { get; set; }

    [JsonIgnore]
    public string? MergedIntoTicketId { get; set; }

    [JsonIgnore]
    public string? Search { get; set; }

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
public record CreateTriageTicketsRequest
{
    [JsonIgnore]
    public string? XiApiKey { get; set; }

    [JsonIgnore]
    public required global::ElevenLabs.Agents.CreateAgentConversationTicketRequestModel Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record ListAssignableUsersTriageTicketsRequest
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
public record GetTriageTicketsRequest
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
public record UpdateTriageTicketsRequest
{
    [JsonIgnore]
    public string? XiApiKey { get; set; }

    [JsonIgnore]
    public required global::ElevenLabs.Agents.PatchAgentConversationTicketRequestModel Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record DeleteTriageTicketsRequest
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
public record AddCommentTriageTicketsRequest
{
    [JsonIgnore]
    public string? XiApiKey { get; set; }

    [JsonIgnore]
    public required global::ElevenLabs.Agents.AddTicketCommentRequestModel Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record MergeTriageTicketsRequest
{
    [JsonIgnore]
    public string? XiApiKey { get; set; }

    [JsonIgnore]
    public required global::ElevenLabs.Agents.MergeAgentConversationTicketsRequestModel Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record AddTurnCommentTriageTicketsRequest
{
    [JsonIgnore]
    public string? XiApiKey { get; set; }

    [JsonIgnore]
    public required global::ElevenLabs.Agents.AddTurnCommentRequestModel Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
