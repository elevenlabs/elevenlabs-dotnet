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
using ElevenLabs.Reception;
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
using global::System.Threading;
using OneOf;

namespace ElevenLabs.Agents;

/// <summary>
/// Fern-shape interface for ConversationsClient. Mirrors the public surface of <c>ConversationsClient</c>
/// (methods and child clients) so callers can depend on the abstraction (mockability). FSM-144.
/// </summary>
public partial interface IConversationsClient
{
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
    IConversationsClient SetConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>GetSignedUrlAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IConversationsClient SetGetSignedUrlAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>GetWebrtcTokenAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IConversationsClient SetGetWebrtcTokenAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    );

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IConversationsClient SetListAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>CreateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IConversationsClient SetCreateAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>ResolveAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IConversationsClient SetResolveAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IConversationsClient SetGetAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>DeleteAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IConversationsClient SetDeleteAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>GetSummaryAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IConversationsClient SetGetSummaryAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>GetSipMessagesAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IConversationsClient SetGetSipMessagesAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    );

    /// <summary>
    /// Sets method-level configuration for <c>SendMessageAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IConversationsClient SetSendMessageAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>GetTurnAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IConversationsClient SetGetTurnAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>SendMessageStreamAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IConversationsClient SetSendMessageStreamAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    );

    /// <summary>
    /// Sets method-level configuration for <c>StreamTurnEventsAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IConversationsClient SetStreamTurnEventsAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    );

    /// <summary>Get a signed url to start a conversation with an agent with an agent that requires authorization</summary>
    WithRawResponseTask<ConversationSignedUrlResponseModel> GetSignedUrlAsync(
        GetSignedUrlConversationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Get a WebRTC session token for real-time communication.</summary>
    WithRawResponseTask<TokenResponseModel> GetWebrtcTokenAsync(
        GetWebrtcTokenConversationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Get all conversations of agents that user owns. With option to restrict to a specific agent.</summary>
    WithRawResponseTask<GetConversationsPageResponseModel> ListAsync(
        ListConversationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Create a text conversation with an agent. This does not run the agent, and the agent sends no first message. This endpoint is in alpha and may change.</summary>
    WithRawResponseTask<CreateAgentConversationResponse> CreateAsync(
        CreateConversationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Resolve a conversation URL (a Slack message URL or a Zendesk ticket URL) to the deterministic conversation ID for the given agent, then confirm the conversation exists.</summary>
    WithRawResponseTask<GetConversationResponseModel> ResolveAsync(
        ResolveConversationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Get the details of a particular conversation</summary>
    WithRawResponseTask<GetConversationResponseModel> GetAsync(
        string conversationId,
        GetConversationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Delete a particular conversation</summary>
    WithRawResponseTask<object> DeleteAsync(
        string conversationId,
        DeleteConversationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Get a lightweight summary of a conversation: its title, the generated transcript summary, whether the call was successful, and — only when the conversation is short — the plain chat messages. Tool calls, tool results, and contextual updates are omitted so the response stays small. Use this instead of the full conversation endpoint when you only need the gist (e.g. an agent reading many conversations); use GET /v1/convai/conversations/{conversation_id} when you need the full transcript with tool calls and contextual updates.</summary>
    WithRawResponseTask<GetConversationSummaryResponseModel> GetSummaryAsync(
        string conversationId,
        GetSummaryConversationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Get SIP messages associated with a conversation's phone call</summary>
    WithRawResponseTask<GetSipLogMessagesResponse> GetSipMessagesAsync(
        string conversationId,
        GetSipMessagesConversationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Send input to a conversation, and wait until the agent finishes or waits on client tool results. With `background` set to true, the endpoint returns 202 when the server admits the turn. Then stream the turn's events with `Last-Event-ID` set to the `stream_cursor`. This endpoint is in alpha and may change.</summary>
    WithRawResponseTask<ConversationTurn> SendMessageAsync(
        string conversationId,
        SendMessageConversationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Get the status and output of a turn. The status comes from the stored transcript, so a turn that failed after the agent started can show as completed. Only the `stream_ended` event has the real outcome. This endpoint is in alpha and may change.</summary>
    WithRawResponseTask<ConversationTurn> GetTurnAsync(
        string conversationId,
        string turnId,
        GetTurnConversationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Send input to a conversation, and stream the events of the request as server-sent events. The last event is `stream_ended`, which has the outcome of the turn. This endpoint is in alpha and may change.</summary>
    global::ElevenLabs.WithRawResponseStream<StreamEnvelope> SendMessageStreamAsync(
        string conversationId,
        SendMessageStreamConversationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Stream the events of a turn as server-sent events. Send `Last-Event-ID` to resume after an event. The server keeps events for about an hour. This endpoint is in alpha and may change.</summary>
    global::ElevenLabs.WithRawResponseStream<StreamEnvelope> StreamTurnEventsAsync(
        string conversationId,
        string turnId,
        StreamTurnEventsConversationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

public partial class ConversationsClient : IConversationsClient { }
