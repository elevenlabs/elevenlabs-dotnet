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
public record GetVoicesRequest
{
    [JsonIgnore]
    public bool? WithSettings { get; set; }

    [JsonIgnore]
    public string? XiApiKey { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record DeleteVoicesRequest
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
public record UpdateVoicesRequest
{
    [JsonIgnore]
    public string? XiApiKey { get; set; }

    [JsonIgnore]
    public required global::ElevenLabs.EditVoiceRequest Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record SearchVoicesRequest
{
    [JsonIgnore]
    public string? NextPageToken { get; set; }

    [JsonIgnore]
    public int? PageSize { get; set; }

    [JsonIgnore]
    public string? Search { get; set; }

    [JsonIgnore]
    public string? Sort { get; set; }

    [JsonIgnore]
    public string? SortDirection { get; set; }

    [JsonIgnore]
    public string? VoiceType { get; set; }

    [JsonIgnore]
    public string? Category { get; set; }

    [JsonIgnore]
    public string? FineTuningState { get; set; }

    [JsonIgnore]
    public string? CollectionId { get; set; }

    [JsonIgnore]
    public string? Gender { get; set; }

    [JsonIgnore]
    public string? Age { get; set; }

    [JsonIgnore]
    public IEnumerable<string> Language { get; set; } = new List<string>();

    [JsonIgnore]
    public string? Accent { get; set; }

    [JsonIgnore]
    public IEnumerable<string> UseCases { get; set; } = new List<string>();

    [JsonIgnore]
    public int? MinNoticePeriodDays { get; set; }

    [JsonIgnore]
    public bool? IncludeCustomRates { get; set; }

    [JsonIgnore]
    public bool? IncludeLiveModerated { get; set; }

    [JsonIgnore]
    public bool? HighQuality { get; set; }

    [JsonIgnore]
    public bool? IncludeTotalCount { get; set; }

    [JsonIgnore]
    public IEnumerable<string> VoiceIds { get; set; } = new List<string>();

    [JsonIgnore]
    public string? XiApiKey { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record ReplicateToIsolatedEnvironmentVoicesRequest
{
    [JsonIgnore]
    public string? XiApiKey { get; set; }

    [JsonIgnore]
    public required global::ElevenLabs.ReplicateVoiceToIsolatedEnvironmentRequestModel Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record ShareVoicesRequest
{
    [JsonIgnore]
    public string? XiApiKey { get; set; }

    [JsonIgnore]
    public required global::ElevenLabs.BodyAddSharedVoiceV1VoicesAddPublicUserIdVoiceIdPost Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record FindSimilarVoicesVoicesRequest
{
    [JsonIgnore]
    public string? XiApiKey { get; set; }

    [JsonIgnore]
    public required global::ElevenLabs.ListSimilarVoicesRequest Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record GetSharedVoicesRequest
{
    [JsonIgnore]
    public int? PageSize { get; set; }

    [JsonIgnore]
    public GetSharedVoicesRequestCategory? Category { get; set; }

    [JsonIgnore]
    public string? Gender { get; set; }

    [JsonIgnore]
    public string? Age { get; set; }

    [JsonIgnore]
    public string? Accent { get; set; }

    [JsonIgnore]
    public string? Language { get; set; }

    [JsonIgnore]
    public string? Locale { get; set; }

    [JsonIgnore]
    public string? Search { get; set; }

    [JsonIgnore]
    public IEnumerable<string> UseCases { get; set; } = new List<string>();

    [JsonIgnore]
    public IEnumerable<string> Descriptives { get; set; } = new List<string>();

    [JsonIgnore]
    public bool? Featured { get; set; }

    [JsonIgnore]
    public int? MinNoticePeriodDays { get; set; }

    [JsonIgnore]
    public bool? IncludeCustomRates { get; set; }

    [JsonIgnore]
    public bool? IncludeLiveModerated { get; set; }

    [JsonIgnore]
    public bool? ReaderAppEnabled { get; set; }

    [JsonIgnore]
    public string? OwnerId { get; set; }

    [JsonIgnore]
    public GetSharedVoicesRequestSort? Sort { get; set; }

    [JsonIgnore]
    public int? Page { get; set; }

    [JsonIgnore]
    public string? XiApiKey { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
