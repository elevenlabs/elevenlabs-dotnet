using ElevenLabs;
using ElevenLabs.Agents;
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

namespace ElevenLabs.Agents.Conversations;

[Serializable]
public record TextSearchMessagesRequest
{
    [JsonIgnore]
    public required string TextQuery { get; set; }

    [JsonIgnore]
    public string? AgentId { get; set; }

    [JsonIgnore]
    public IEnumerable<string> VisitedAgentIds { get; set; } = new List<string>();

    [JsonIgnore]
    public IEnumerable<string> VisitedAgentBranchIds { get; set; } = new List<string>();

    [JsonIgnore]
    public IEnumerable<string> TriggeredProcedureIds { get; set; } = new List<string>();

    [JsonIgnore]
    public EvaluationResultFilter? CallSuccessful { get; set; }

    [JsonIgnore]
    public int? CallStartBeforeUnix { get; set; }

    [JsonIgnore]
    public int? CallStartAfterUnix { get; set; }

    [JsonIgnore]
    public int? CallDurationMinSecs { get; set; }

    [JsonIgnore]
    public int? CallDurationMaxSecs { get; set; }

    [JsonIgnore]
    public int? RatingMax { get; set; }

    [JsonIgnore]
    public int? RatingMin { get; set; }

    [JsonIgnore]
    public bool? HasFeedbackComment { get; set; }

    [JsonIgnore]
    public string? UserId { get; set; }

    [JsonIgnore]
    public IEnumerable<string> EvaluationParams { get; set; } = new List<string>();

    [JsonIgnore]
    public IEnumerable<string> DataCollectionParams { get; set; } = new List<string>();

    [JsonIgnore]
    public IEnumerable<string> DynamicVariableParams { get; set; } = new List<string>();

    [JsonIgnore]
    public IEnumerable<string> ToolNames { get; set; } = new List<string>();

    [JsonIgnore]
    public IEnumerable<string> ToolNamesSuccessful { get; set; } = new List<string>();

    [JsonIgnore]
    public IEnumerable<string> ToolNamesErrored { get; set; } = new List<string>();

    [JsonIgnore]
    public IEnumerable<string> ToolIds { get; set; } = new List<string>();

    [JsonIgnore]
    public IEnumerable<string> ToolIdsSuccessful { get; set; } = new List<string>();

    [JsonIgnore]
    public IEnumerable<string> ToolIdsErrored { get; set; } = new List<string>();

    [JsonIgnore]
    public bool? IncludeInvalidToolCalls { get; set; }

    [JsonIgnore]
    public IEnumerable<string> MainLanguages { get; set; } = new List<string>();

    [JsonIgnore]
    public IEnumerable<string> PhoneNumberIds { get; set; } = new List<string>();

    [JsonIgnore]
    public IEnumerable<string> WhatsappPhoneNumberIds { get; set; } = new List<string>();

    [JsonIgnore]
    public IEnumerable<TextSearchMessagesRequestExcludeStatusesItem> ExcludeStatuses { get; set; } =
        new List<TextSearchMessagesRequestExcludeStatusesItem>();

    [JsonIgnore]
    public IEnumerable<string> TerminationReasons { get; set; } = new List<string>();

    [JsonIgnore]
    public int? PageSize { get; set; }

    [JsonIgnore]
    public TextSearchMessagesRequestSummaryMode? SummaryMode { get; set; }

    [JsonIgnore]
    public ConversationInitiationSource1? ConversationInitiationSource { get; set; }

    [JsonIgnore]
    public bool? TextOnly { get; set; }

    [JsonIgnore]
    public ConversationProduct? ConversationProductType { get; set; }

    [JsonIgnore]
    public string? BranchId { get; set; }

    [JsonIgnore]
    public string? VersionId { get; set; }

    [JsonIgnore]
    public IEnumerable<string> TopicIds { get; set; } = new List<string>();

    [JsonIgnore]
    public MessageSearchSortBy? SortBy { get; set; }

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
public record SearchMessagesRequest
{
    [JsonIgnore]
    public required string TextQuery { get; set; }

    [JsonIgnore]
    public string? AgentId { get; set; }

    [JsonIgnore]
    public string? BranchId { get; set; }

    [JsonIgnore]
    public int? PageSize { get; set; }

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
