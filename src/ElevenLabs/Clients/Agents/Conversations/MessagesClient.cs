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
using ElevenLabs.Services;
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
using global::System.Linq;
using global::System.Threading;
using OneOf;

namespace ElevenLabs.Agents.Conversations;

/// <summary>
/// Fern-shape client for MessagesClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>IMessagesClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class MessagesClient
{
    private readonly MessagesService _service;

    internal MessagesClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new MessagesService(httpClient);
    }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public IMessagesClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>TextSearchAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IMessagesClient SetTextSearchAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetTextSearchAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>SearchAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IMessagesClient SetSearchAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetSearchAsyncConfig(config);
        return this;
    }

    /// <summary>Search through conversation transcript messages by full-text and fuzzy search</summary>
    public WithRawResponseTask<MessagesSearchResponse> TextSearchAsync(
        TextSearchMessagesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<MessagesSearchResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.TextSearchAsync(
                        request.TextQuery,
                        request.AgentId,
                        request.VisitedAgentIds?.ToList(),
                        request.VisitedAgentBranchIds?.ToList(),
                        request.TriggeredProcedureIds?.ToList(),
                        request.CallSuccessful,
                        request.CallStartBeforeUnix,
                        request.CallStartAfterUnix,
                        request.CallDurationMinSecs,
                        request.CallDurationMaxSecs,
                        request.RatingMax,
                        request.RatingMin,
                        request.HasFeedbackComment,
                        request.UserId,
                        request.EvaluationParams?.ToList(),
                        request.DataCollectionParams?.ToList(),
                        request.DynamicVariableParams?.ToList(),
                        request.ToolNames?.ToList(),
                        request.ToolNamesSuccessful?.ToList(),
                        request.ToolNamesErrored?.ToList(),
                        request.ToolIds?.ToList(),
                        request.ToolIdsSuccessful?.ToList(),
                        request.ToolIdsErrored?.ToList(),
                        request.IncludeInvalidToolCalls,
                        request.MainLanguages?.ToList(),
                        request.PhoneNumberIds?.ToList(),
                        request.WhatsappPhoneNumberIds?.ToList(),
                        request.ExcludeStatuses?.ToList(),
                        request.TerminationReasons?.ToList(),
                        request.PageSize,
                        request.SummaryMode,
                        request.ConversationInitiationSource,
                        request.TextOnly,
                        request.ConversationProductType,
                        request.BranchId,
                        request.VersionId,
                        request.TopicIds?.ToList(),
                        request.SortBy,
                        request.Cursor,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Search conversation transcripts by semantic similarity to surface relevant messages based on meaning and intent, rather than exact keyword matches</summary>
    public WithRawResponseTask<MessagesSearchResponse> SearchAsync(
        SearchMessagesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<MessagesSearchResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.SearchAsync(
                        request.TextQuery,
                        request.AgentId,
                        request.BranchId,
                        request.PageSize,
                        request.Cursor,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
