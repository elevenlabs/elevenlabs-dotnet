using ElevenLabs;
using ElevenLabs.Agents;
using ElevenLabs.Agents.Conversations;
using ElevenLabs.Agents.Dashboard;
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

namespace ElevenLabs.Agents.KnowledgeBase;

[Serializable]
public record CreateFromUrlDocumentsRequest
{
    [JsonIgnore]
    public string? XiApiKey { get; set; }

    [JsonIgnore]
    public required global::ElevenLabs.Agents.KnowledgeBase.BodyCreateUrlDocumentV1ConvaiKnowledgeBaseUrlPost Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record CreateFromFileDocumentsRequest
{
    [JsonIgnore]
    public string? XiApiKey { get; set; }

    [JsonIgnore]
    public required global::ElevenLabs.Agents.KnowledgeBase.BodyCreateFileDocumentV1ConvaiKnowledgeBaseFilePost Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record CreateFromTextDocumentsRequest
{
    [JsonIgnore]
    public string? XiApiKey { get; set; }

    [JsonIgnore]
    public required global::ElevenLabs.Agents.KnowledgeBase.BodyCreateTextDocumentV1ConvaiKnowledgeBaseTextPost Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record CreateFolderDocumentsRequest
{
    [JsonIgnore]
    public string? XiApiKey { get; set; }

    [JsonIgnore]
    public required global::ElevenLabs.Agents.KnowledgeBase.BodyCreateFolderV1ConvaiKnowledgeBaseFolderPost Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record GetDocumentsRequest
{
    [JsonIgnore]
    public string? AgentId { get; set; }

    [JsonIgnore]
    public string? XiApiKey { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record UpdateDocumentsRequest
{
    [JsonIgnore]
    public string? XiApiKey { get; set; }

    [JsonIgnore]
    public required global::ElevenLabs.Agents.KnowledgeBase.BodyUpdateDocumentV1ConvaiKnowledgeBaseDocumentationIdPatch Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record DeleteDocumentsRequest
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
public record GetAgentsDocumentsRequest
{
    [JsonIgnore]
    public KnowledgeBaseDependentType? DependentType { get; set; }

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

[Serializable]
public record GetBulkAgentsDocumentsRequest
{
    [JsonIgnore]
    public KnowledgeBaseDependentType? DependentType { get; set; }

    [JsonIgnore]
    public int? PageSize { get; set; }

    [JsonIgnore]
    public string? Cursor { get; set; }

    [JsonIgnore]
    public string? XiApiKey { get; set; }

    [JsonIgnore]
    public required global::ElevenLabs.Agents.KnowledgeBase.BodyGetDependentAgentsForMultipleDocumentsV1ConvaiKnowledgeBaseDependentAgentsPost Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record GetContentDocumentsRequest
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
public record GetSourceFileUrlDocumentsRequest
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
public record MoveDocumentsRequest
{
    [JsonIgnore]
    public string? XiApiKey { get; set; }

    [JsonIgnore]
    public required global::ElevenLabs.Agents.KnowledgeBase.BodyMoveEntityToFolderV1ConvaiKnowledgeBaseDocumentIdMovePost Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record BulkMoveDocumentsRequest
{
    [JsonIgnore]
    public string? XiApiKey { get; set; }

    [JsonIgnore]
    public required global::ElevenLabs.Agents.KnowledgeBase.BodyBulkMoveEntitiesToFolderV1ConvaiKnowledgeBaseBulkMovePost Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record BulkDeleteDocumentsRequest
{
    [JsonIgnore]
    public string? XiApiKey { get; set; }

    [JsonIgnore]
    public required global::ElevenLabs.Agents.KnowledgeBase.BodyBulkDeleteKnowledgeBaseDocumentsV1ConvaiKnowledgeBaseBulkDeletePost Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
