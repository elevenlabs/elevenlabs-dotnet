using ElevenLabs;
using ElevenLabs.Agents.Conversations;
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

namespace ElevenLabs.Agents;

/// <summary>
/// Fern-shape client for ConversationsClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>IConversationsClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class ConversationsClient
{
    private readonly ConversationsService _service;

    internal ConversationsClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new ConversationsService(httpClient);
        Audio = new ElevenLabs.Agents.Conversations.AudioClient(httpClient);
        Files = new FilesClient(httpClient);
        Feedback = new FeedbackClient(httpClient);
        Messages = new MessagesClient(httpClient);
        Tags = new TagsClient(httpClient);
        Topics = new TopicsClient(httpClient);
        Analysis = new AnalysisClient(httpClient);
    }

    public ElevenLabs.Agents.Conversations.IAudioClient Audio { get; }
    public IFilesClient Files { get; }
    public IFeedbackClient Feedback { get; }
    public IMessagesClient Messages { get; }
    public ITagsClient Tags { get; }
    public ITopicsClient Topics { get; }
    public IAnalysisClient Analysis { get; }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public IConversationsClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetSignedUrlAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IConversationsClient SetGetSignedUrlAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetGetSignedUrlAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetWebrtcTokenAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IConversationsClient SetGetWebrtcTokenAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetGetWebrtcTokenAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IConversationsClient SetListAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetListAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ResolveAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IConversationsClient SetResolveAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetResolveAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IConversationsClient SetGetAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetGetAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>DeleteAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IConversationsClient SetDeleteAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetDeleteAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetSummaryAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IConversationsClient SetGetSummaryAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetGetSummaryAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetSipMessagesAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IConversationsClient SetGetSipMessagesAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetGetSipMessagesAsyncConfig(config);
        return this;
    }

    /// <summary>Get a signed url to start a conversation with an agent with an agent that requires authorization</summary>
    public WithRawResponseTask<ConversationSignedUrlResponseModel> GetSignedUrlAsync(
        GetSignedUrlConversationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<ConversationSignedUrlResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetSignedUrlAsync(
                        request.AgentId,
                        request.IncludeConversationId,
                        request.BranchId,
                        request.VersionId,
                        request.Environment,
                        request.DebugEventsRequest,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Get a WebRTC session token for real-time communication.</summary>
    public WithRawResponseTask<TokenResponseModel> GetWebrtcTokenAsync(
        GetWebrtcTokenConversationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<TokenResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetWebrtcTokenAsync(
                        request.AgentId,
                        request.ParticipantName,
                        request.BranchId,
                        request.VersionId,
                        request.Environment,
                        request.DebugEventsRequest,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Get all conversations of agents that user owns. With option to restrict to a specific agent.</summary>
    public WithRawResponseTask<GetConversationsPageResponseModel> ListAsync(
        ListConversationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<GetConversationsPageResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.ListAsync(
                        request.Cursor,
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
                        request.DataCollectionFilter,
                        request.DynamicVariableFilter,
                        request.DataCollectionIds?.ToList(),
                        request.EvaluationCriteriaIds?.ToList(),
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
                        request.PageSize,
                        request.SummaryMode,
                        request.Search,
                        request.ConversationInitiationSource,
                        request.TextOnly,
                        request.ConversationProductType,
                        request.BranchId,
                        request.VersionId,
                        request.ParentConversationId,
                        request.TopicIds?.ToList(),
                        request.ExcludeStatuses?.ToList(),
                        request.TagIds?.ToList(),
                        request.WorkflowNodeEnteredId,
                        request.TerminationReasons?.ToList(),
                        request.GuardrailTypes?.ToList(),
                        request.CustomGuardrailNames?.ToList(),
                        request.SortDirection,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Resolve a conversation URL (a Slack message URL or a Zendesk ticket URL) to the deterministic conversation ID for the given agent, then confirm the conversation exists.</summary>
    public WithRawResponseTask<GetConversationResponseModel> ResolveAsync(
        ResolveConversationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<GetConversationResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.ResolveAsync(
                        request.AgentId,
                        request.Reference,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Get the details of a particular conversation</summary>
    public WithRawResponseTask<GetConversationResponseModel> GetAsync(
        string conversationId,
        GetConversationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<GetConversationResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetAsync(
                        conversationId,
                        request.Format,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Delete a particular conversation</summary>
    public WithRawResponseTask<object> DeleteAsync(
        string conversationId,
        DeleteConversationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<object>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.DeleteAsync(
                        conversationId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Get a lightweight summary of a conversation: its title, the generated transcript summary, whether the call was successful, and — only when the conversation is short — the plain chat messages. Tool calls, tool results, and contextual updates are omitted so the response stays small. Use this instead of the full conversation endpoint when you only need the gist (e.g. an agent reading many conversations); use GET /v1/convai/conversations/{conversation_id} when you need the full transcript with tool calls and contextual updates.</summary>
    public WithRawResponseTask<GetConversationSummaryResponseModel> GetSummaryAsync(
        string conversationId,
        GetSummaryConversationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<GetConversationSummaryResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetSummaryAsync(
                        conversationId,
                        request.MaxMessages,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Get SIP messages associated with a conversation's phone call</summary>
    public WithRawResponseTask<GetSipLogMessagesResponse> GetSipMessagesAsync(
        string conversationId,
        GetSipMessagesConversationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<GetSipLogMessagesResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetSipMessagesAsync(
                        conversationId,
                        request.PageSize,
                        request.Cursor,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
