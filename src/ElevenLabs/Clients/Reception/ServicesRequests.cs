using ElevenLabs;
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
using ElevenLabs.Reception.Products;
using ElevenLabs.Reception.Receptionists;
using ElevenLabs.Reception.Team;
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

namespace ElevenLabs.Reception;

[Serializable]
public record ListServicesRequest
{
    [JsonIgnore]
    public required string XiWorkspaceId { get; set; }

    [JsonIgnore]
    public string? StaffId { get; set; }

    [JsonIgnore]
    public string? AssetId { get; set; }

    [JsonIgnore]
    public bool? IsActive { get; set; }

    [JsonIgnore]
    public ReceptionServiceKind? Kind { get; set; }

    [JsonIgnore]
    public string? XiApiKey { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record CreateServicesRequest
{
    [JsonIgnore]
    public required string XiWorkspaceId { get; set; }

    [JsonIgnore]
    public string? XiApiKey { get; set; }

    [JsonIgnore]
    public required global::ElevenLabs.Reception.ReceptionCreateServiceRequest Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record GetServicesRequest
{
    [JsonIgnore]
    public required string XiWorkspaceId { get; set; }

    [JsonIgnore]
    public string? XiApiKey { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record UpdateServicesRequest
{
    [JsonIgnore]
    public required string XiWorkspaceId { get; set; }

    [JsonIgnore]
    public string? XiApiKey { get; set; }

    [JsonIgnore]
    public required global::ElevenLabs.Reception.ReceptionUpdateServiceRequestPatch Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record DeleteServicesRequest
{
    [JsonIgnore]
    public required string XiWorkspaceId { get; set; }

    [JsonIgnore]
    public string? XiApiKey { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record ConfirmUpdateServicesRequest
{
    [JsonIgnore]
    public required string XiWorkspaceId { get; set; }

    [JsonIgnore]
    public bool? Reprice { get; set; }

    [JsonIgnore]
    public string? XiApiKey { get; set; }

    [JsonIgnore]
    public required global::ElevenLabs.Reception.ReceptionConfirmServiceUpdateRequest Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
