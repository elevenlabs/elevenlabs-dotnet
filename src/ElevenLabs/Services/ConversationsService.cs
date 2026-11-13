using System.Net.Http.Json;
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
using ElevenLabs.Config;
using ElevenLabs.Dubbing;
using ElevenLabs.Dubbing.Project;
using ElevenLabs.Dubbing.Project.Language;
using ElevenLabs.EnvironmentVariables;
using ElevenLabs.Flows;
using ElevenLabs.Flows.Templates;
using ElevenLabs.History;
using ElevenLabs.Http;
using ElevenLabs.Http.Exceptions;
using ElevenLabs.Http.Extensions;
using ElevenLabs.Http.Handlers;
using ElevenLabs.Http.Serialization;
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

namespace ElevenLabs.Services;

/// <summary>
/// Service class providing access to API endpoints for ConversationsService.
/// Inherits HTTP client management, JSON serialization, and streaming capabilities from the base service.
/// Each method corresponds to an API operation and handles request building, execution, and response parsing.
/// </summary>
internal class ConversationsService : BaseService
{
    private RequestConfig? _getSignedUrlAsyncConfig;
    private RequestConfig? _getWebrtcTokenAsyncConfig;
    private RequestConfig? _listAsyncConfig;
    private RequestConfig? _resolveAsyncConfig;
    private RequestConfig? _getAsyncConfig;
    private RequestConfig? _deleteAsyncConfig;
    private RequestConfig? _getSummaryAsyncConfig;
    private RequestConfig? _getSipMessagesAsyncConfig;

    internal ConversationsService(global::ElevenLabs.Http.Client httpClient)
        : base(httpClient) { }

    /// <summary>
    /// Sets method-level configuration for <c>GetSignedUrlAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public ConversationsService SetGetSignedUrlAsyncConfig(RequestConfig config)
    {
        _getSignedUrlAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetWebrtcTokenAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public ConversationsService SetGetWebrtcTokenAsyncConfig(RequestConfig config)
    {
        _getWebrtcTokenAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public ConversationsService SetListAsyncConfig(RequestConfig config)
    {
        _listAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ResolveAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public ConversationsService SetResolveAsyncConfig(RequestConfig config)
    {
        _resolveAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public ConversationsService SetGetAsyncConfig(RequestConfig config)
    {
        _getAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>DeleteAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public ConversationsService SetDeleteAsyncConfig(RequestConfig config)
    {
        _deleteAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetSummaryAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public ConversationsService SetGetSummaryAsyncConfig(RequestConfig config)
    {
        _getSummaryAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetSipMessagesAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public ConversationsService SetGetSipMessagesAsyncConfig(RequestConfig config)
    {
        _getSipMessagesAsyncConfig = config;
        return this;
    }

    /// <summary>Get a signed url to start a conversation with an agent with an agent that requires authorization</summary>
    /// <param name="agentId">Agent id (agent_…) or speech engine external id (seng_), resolved to the same underlying resource.</param>
    /// <param name="includeConversationId">Whether to include a conversation_id with the response. If included, the conversation_signature cannot be used again.</param>
    /// <param name="branchId">The ID of the branch to use</param>
    /// <param name="versionId">The ID of the version to use</param>
    /// <param name="environment">The environment to use for resolving environment variables (e.g. 'production', 'staging'). Defaults to 'production'.</param>
    /// <param name="debugEventsRequest">Whether to enable debug events. Only available for users with editor access to the agent.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.ConversationSignedUrlResponseModel> GetSignedUrlAsync(
        string agentId,
        bool? includeConversationId = false,
        string? branchId = null,
        string? versionId = null,
        string? environment = null,
        bool? debugEventsRequest = false,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (agentId is null)
            throw new ArgumentNullException(nameof(agentId));

        var resolvedConfig = GetResolvedConfig(_getSignedUrlAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Get, "v1/convai/conversation/get-signed-url")
            .SetOptionalQueryParameter("agent_id", agentId)
            .SetOptionalQueryParameter("include_conversation_id", includeConversationId)
            .SetOptionalQueryParameter("branch_id", branchId)
            .SetOptionalQueryParameter("version_id", versionId)
            .SetOptionalQueryParameter("environment", environment)
            .SetOptionalQueryParameter("debug_events_request", debugEventsRequest)
            .SetOptionalHeader("xi-api-key", xiApiKey)
            .Build();

        var response = await ExecuteAsync(request, resolvedConfig, cancellationToken)
            .ConfigureAwait(false);

        // Standard deserialization
        // Read the body first so a decode failure can report the bytes that caused it.
        var responseBody = await response
            .Content
#if NET5_0_OR_GREATER
            .ReadAsStringAsync(cancellationToken)
#else
        .ReadAsStringAsync()
#endif
            .ConfigureAwait(false);
        global::ElevenLabs.ConversationSignedUrlResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.ConversationSignedUrlResponseModel>(
                    responseBody,
                    _jsonSerializerOptions
                )!;
        }
        catch (global::System.Text.Json.JsonException exception)
        {
            throw new ElevenLabs.ElevenLabsClientApiException(
                "Failed to deserialize response",
                (int)response.StatusCode,
                responseBody,
                exception,
                rawResponse: ElevenLabs.Core.RawResponseFactory.FromHttpResponseMessage(response)
            );
        }

        return result;
    }

    /// <summary>Get a WebRTC session token for real-time communication.</summary>
    /// <param name="agentId">Agent id (agent_…) or speech engine external id (seng_), resolved to the same underlying resource.</param>
    /// <param name="participantName">Optional custom participant name. If not provided, user ID will be used</param>
    /// <param name="branchId">The ID of the branch to use</param>
    /// <param name="versionId">The ID of the version to use</param>
    /// <param name="environment">The environment to use for resolving environment variables (e.g. 'production', 'staging'). Defaults to 'production'.</param>
    /// <param name="debugEventsRequest">Whether to enable debug events. Only available for users with editor access to the agent.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.TokenResponseModel> GetWebrtcTokenAsync(
        string agentId,
        string? participantName = null,
        string? branchId = null,
        string? versionId = null,
        string? environment = null,
        bool? debugEventsRequest = false,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (agentId is null)
            throw new ArgumentNullException(nameof(agentId));

        var resolvedConfig = GetResolvedConfig(_getWebrtcTokenAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Get, "v1/convai/conversation/token")
            .SetOptionalQueryParameter("agent_id", agentId)
            .SetOptionalQueryParameter("participant_name", participantName)
            .SetOptionalQueryParameter("branch_id", branchId)
            .SetOptionalQueryParameter("version_id", versionId)
            .SetOptionalQueryParameter("environment", environment)
            .SetOptionalQueryParameter("debug_events_request", debugEventsRequest)
            .SetOptionalHeader("xi-api-key", xiApiKey)
            .Build();

        var response = await ExecuteAsync(request, resolvedConfig, cancellationToken)
            .ConfigureAwait(false);

        // Standard deserialization
        // Read the body first so a decode failure can report the bytes that caused it.
        var responseBody = await response
            .Content
#if NET5_0_OR_GREATER
            .ReadAsStringAsync(cancellationToken)
#else
        .ReadAsStringAsync()
#endif
            .ConfigureAwait(false);
        global::ElevenLabs.TokenResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.TokenResponseModel>(
                    responseBody,
                    _jsonSerializerOptions
                )!;
        }
        catch (global::System.Text.Json.JsonException exception)
        {
            throw new ElevenLabs.ElevenLabsClientApiException(
                "Failed to deserialize response",
                (int)response.StatusCode,
                responseBody,
                exception,
                rawResponse: ElevenLabs.Core.RawResponseFactory.FromHttpResponseMessage(response)
            );
        }

        return result;
    }

    /// <summary>Get all conversations of agents that user owns. With option to restrict to a specific agent.</summary>
    /// <param name="cursor">Used for fetching next page. Cursor is returned in the response.</param>
    /// <param name="agentId">Agent id (agent_…) or speech engine external id (seng_), resolved to the same underlying resource.</param>
    /// <param name="visitedAgentIds">Filter conversations where any of these agents participated. Can not exceed 50 values.</param>
    /// <param name="visitedAgentBranchIds">Filter conversations where any of these agent branches participated. Can not exceed 50 values.</param>
    /// <param name="triggeredProcedureIds">Filter conversations where any of these procedures were triggered. Can not exceed 50 values.</param>
    /// <param name="callSuccessful">The result of the success evaluation</param>
    /// <param name="callStartBeforeUnix">Unix timestamp (in seconds) to filter conversations up to this start date.</param>
    /// <param name="callStartAfterUnix">Unix timestamp (in seconds) to filter conversations after to this start date.</param>
    /// <param name="callDurationMinSecs">Minimum call duration in seconds.</param>
    /// <param name="callDurationMaxSecs">Maximum call duration in seconds.</param>
    /// <param name="ratingMax">Maximum overall rating (1-5).</param>
    /// <param name="ratingMin">Minimum overall rating (1-5).</param>
    /// <param name="hasFeedbackComment">Filter conversations with user feedback comments.</param>
    /// <param name="userId">Filter conversations by the user ID who initiated them.</param>
    /// <param name="evaluationParams">Evaluation filters. Repeat param. Format: criteria_id:result where result is one of success|failure|unknown. Example: eval=value_framing:success</param>
    /// <param name="dataCollectionParams">Data collection filters. Repeat param. Format: id:op:value where op is one of eq|neq|gt|gte|lt|lte|in. For in, pipe-delimit values. An empty value matches conversations where the field was not collected (id:eq:), and neq with an empty value matches where it was (id:neq:). eq is exact equality. gt|gte|lt|lte require a numeric value.</param>
    /// <param name="dynamicVariableParams">Dynamic variable filters. Repeat param. Format: name:op:value where op is one of eq|neq|gt|gte|lt|lte|in. For in, pipe-delimit values. An empty value matches conversations where the variable was not set (name:eq:), and neq with an empty value matches where it was (name:neq:). eq is exact equality. gt|gte|lt|lte require a numeric value. Names containing ':' cannot be expressed.</param>
    /// <param name="dataCollectionFilter">A single data collection filter, for callers that can only send one scalar value per query param. Same format as data_collection_params (id:op:value); combined with it when both are given.</param>
    /// <param name="dynamicVariableFilter">A single dynamic variable filter, for callers that can only send one scalar value per query param. Same format as dynamic_variable_params (name:op:value); combined with it when both are given.</param>
    /// <param name="dataCollectionIds">Data collection field IDs to include in each conversation summary. Repeat param. When omitted, data_collection_results is not returned.</param>
    /// <param name="evaluationCriteriaIds">Evaluation criteria IDs to include in each conversation summary. Repeat param. When omitted, evaluation_criteria_results is not returned.</param>
    /// <param name="toolNames">Filter conversations by tool names used during the call.</param>
    /// <param name="toolNamesSuccessful">Filter conversations by tool names that had successful calls.</param>
    /// <param name="toolNamesErrored">Filter conversations by tool names that had errored calls.</param>
    /// <param name="toolIds">Filter conversations by IDs of tools used during the call. Use '__system_&lt;tool_name&gt;' for system tools. Unlike tool_names, distinguishes between tools that share a name.</param>
    /// <param name="toolIdsSuccessful">Filter conversations by IDs of tools that had successful calls.</param>
    /// <param name="toolIdsErrored">Filter conversations by IDs of tools that had errored calls.</param>
    /// <param name="includeInvalidToolCalls">Also match tool calls that never ran.</param>
    /// <param name="mainLanguages">Filter conversations by detected main language (language code).</param>
    /// <param name="phoneNumberIds">Filter conversations by agent phone number IDs.</param>
    /// <param name="whatsappPhoneNumberIds">Filter conversations by agent WhatsApp number IDs.</param>
    /// <param name="pageSize">How many conversations to return at maximum. Can not exceed 100, defaults to 30.</param>
    /// <param name="summaryMode">Whether to include transcript summaries in the response.</param>
    /// <param name="search">Full-text or fuzzy search over transcript messages</param>
    /// <param name="conversationProductType">Restrict results to a single conversation product surface.</param>
    /// <param name="branchId">Filter conversations by branch ID.</param>
    /// <param name="versionId">Filter conversations by version ID.</param>
    /// <param name="parentConversationId">Filter conversations by parent conversation ID for subagent conversations.</param>
    /// <param name="topicIds">Filter conversations by topic IDs assigned during topic discovery.</param>
    /// <param name="excludeStatuses">Exclude conversations with the given statuses. Useful for hiding in-progress / processing conversations from list views.</param>
    /// <param name="tagIds">Filter conversations by conversation tag IDs assigned via the conversation-tags endpoints.</param>
    /// <param name="workflowNodeEnteredId">Filter conversations to only those that entered the given node.</param>
    /// <param name="terminationReasons">Filter conversations by their stored termination_reason (metadata.termination_reason). Repeat param to match any of several.</param>
    /// <param name="guardrailTypes">Filter to conversations where a guardrail of any of these types triggered (metadata.triggered_guardrails.guardrail_type). Repeat param to match any of several.</param>
    /// <param name="customGuardrailNames">Filter to conversations where a custom guardrail with any of these names triggered (metadata.triggered_guardrails.guardrail_name). Only custom guardrails carry a name. Repeat param to match any of several.</param>
    /// <param name="sortDirection">The direction to sort conversations by call start time. Defaults to descending (newest first).</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.GetConversationsPageResponseModel> ListAsync(
        string? cursor = null,
        string? agentId = null,
        List<string>? visitedAgentIds = null,
        List<string>? visitedAgentBranchIds = null,
        List<string>? triggeredProcedureIds = null,
        global::ElevenLabs.EvaluationResultFilter? callSuccessful = null,
        long? callStartBeforeUnix = null,
        long? callStartAfterUnix = null,
        long? callDurationMinSecs = null,
        long? callDurationMaxSecs = null,
        long? ratingMax = null,
        long? ratingMin = null,
        bool? hasFeedbackComment = null,
        string? userId = null,
        List<string>? evaluationParams = null,
        List<string>? dataCollectionParams = null,
        List<string>? dynamicVariableParams = null,
        string? dataCollectionFilter = null,
        string? dynamicVariableFilter = null,
        List<string>? dataCollectionIds = null,
        List<string>? evaluationCriteriaIds = null,
        List<string>? toolNames = null,
        List<string>? toolNamesSuccessful = null,
        List<string>? toolNamesErrored = null,
        List<string>? toolIds = null,
        List<string>? toolIdsSuccessful = null,
        List<string>? toolIdsErrored = null,
        bool? includeInvalidToolCalls = false,
        List<string>? mainLanguages = null,
        List<string>? phoneNumberIds = null,
        List<string>? whatsappPhoneNumberIds = null,
        long? pageSize = 30,
        global::ElevenLabs.Agents.ListConversationsRequestSummaryMode? summaryMode = null,
        string? search = null,
        global::ElevenLabs.ConversationInitiationSource1? conversationInitiationSource = null,
        bool? textOnly = null,
        global::ElevenLabs.ConversationProduct? conversationProductType = null,
        string? branchId = null,
        string? versionId = null,
        string? parentConversationId = null,
        List<string>? topicIds = null,
        List<global::ElevenLabs.Agents.ListConversationsRequestExcludeStatusesItem>? excludeStatuses =
            null,
        List<string>? tagIds = null,
        string? workflowNodeEnteredId = null,
        List<string>? terminationReasons = null,
        List<global::ElevenLabs.Agents.GuardrailType>? guardrailTypes = null,
        List<string>? customGuardrailNames = null,
        global::ElevenLabs.SortDirection1? sortDirection = null,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        var resolvedConfig = GetResolvedConfig(_listAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Get, "v1/convai/conversations")
            .SetOptionalQueryParameter("cursor", cursor)
            .SetOptionalQueryParameter("agent_id", agentId)
            .SetOptionalQueryParameter("visited_agent_ids", visitedAgentIds)
            .SetOptionalQueryParameter("visited_agent_branch_ids", visitedAgentBranchIds)
            .SetOptionalQueryParameter("triggered_procedure_ids", triggeredProcedureIds)
            .SetOptionalQueryParameter("call_successful", callSuccessful?.Value)
            .SetOptionalQueryParameter("call_start_before_unix", callStartBeforeUnix)
            .SetOptionalQueryParameter("call_start_after_unix", callStartAfterUnix)
            .SetOptionalQueryParameter("call_duration_min_secs", callDurationMinSecs)
            .SetOptionalQueryParameter("call_duration_max_secs", callDurationMaxSecs)
            .SetOptionalQueryParameter("rating_max", ratingMax)
            .SetOptionalQueryParameter("rating_min", ratingMin)
            .SetOptionalQueryParameter("has_feedback_comment", hasFeedbackComment)
            .SetOptionalQueryParameter("user_id", userId)
            .SetOptionalQueryParameter("evaluation_params", evaluationParams)
            .SetOptionalQueryParameter("data_collection_params", dataCollectionParams)
            .SetOptionalQueryParameter("dynamic_variable_params", dynamicVariableParams)
            .SetOptionalQueryParameter("data_collection_filter", dataCollectionFilter)
            .SetOptionalQueryParameter("dynamic_variable_filter", dynamicVariableFilter)
            .SetOptionalQueryParameter("data_collection_ids", dataCollectionIds)
            .SetOptionalQueryParameter("evaluation_criteria_ids", evaluationCriteriaIds)
            .SetOptionalQueryParameter("tool_names", toolNames)
            .SetOptionalQueryParameter("tool_names_successful", toolNamesSuccessful)
            .SetOptionalQueryParameter("tool_names_errored", toolNamesErrored)
            .SetOptionalQueryParameter("tool_ids", toolIds)
            .SetOptionalQueryParameter("tool_ids_successful", toolIdsSuccessful)
            .SetOptionalQueryParameter("tool_ids_errored", toolIdsErrored)
            .SetOptionalQueryParameter("include_invalid_tool_calls", includeInvalidToolCalls)
            .SetOptionalQueryParameter("main_languages", mainLanguages)
            .SetOptionalQueryParameter("phone_number_ids", phoneNumberIds)
            .SetOptionalQueryParameter("whatsapp_phone_number_ids", whatsappPhoneNumberIds)
            .SetOptionalQueryParameter("page_size", pageSize)
            .SetOptionalQueryParameter("summary_mode", summaryMode?.Value)
            .SetOptionalQueryParameter("search", search)
            .SetOptionalQueryParameter(
                "conversation_initiation_source",
                conversationInitiationSource?.Value
            )
            .SetOptionalQueryParameter("text_only", textOnly)
            .SetOptionalQueryParameter("conversation_product_type", conversationProductType?.Value)
            .SetOptionalQueryParameter("branch_id", branchId)
            .SetOptionalQueryParameter("version_id", versionId)
            .SetOptionalQueryParameter("parent_conversation_id", parentConversationId)
            .SetOptionalQueryParameter("topic_ids", topicIds)
            .SetOptionalQueryParameter("exclude_statuses", excludeStatuses)
            .SetOptionalQueryParameter("tag_ids", tagIds)
            .SetOptionalQueryParameter("workflow_node_entered_id", workflowNodeEnteredId)
            .SetOptionalQueryParameter("termination_reasons", terminationReasons)
            .SetOptionalQueryParameter("guardrail_types", guardrailTypes)
            .SetOptionalQueryParameter("custom_guardrail_names", customGuardrailNames)
            .SetOptionalQueryParameter("sort_direction", sortDirection?.Value)
            .SetOptionalHeader("xi-api-key", xiApiKey)
            .Build();

        var response = await ExecuteAsync(request, resolvedConfig, cancellationToken)
            .ConfigureAwait(false);

        // Standard deserialization
        // Read the body first so a decode failure can report the bytes that caused it.
        var responseBody = await response
            .Content
#if NET5_0_OR_GREATER
            .ReadAsStringAsync(cancellationToken)
#else
        .ReadAsStringAsync()
#endif
            .ConfigureAwait(false);
        global::ElevenLabs.GetConversationsPageResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.GetConversationsPageResponseModel>(
                    responseBody,
                    _jsonSerializerOptions
                )!;
        }
        catch (global::System.Text.Json.JsonException exception)
        {
            throw new ElevenLabs.ElevenLabsClientApiException(
                "Failed to deserialize response",
                (int)response.StatusCode,
                responseBody,
                exception,
                rawResponse: ElevenLabs.Core.RawResponseFactory.FromHttpResponseMessage(response)
            );
        }

        return result;
    }

    /// <summary>Resolve a conversation URL (a Slack message URL or a Zendesk ticket URL) to the deterministic conversation ID for the given agent, then confirm the conversation exists.</summary>
    /// <param name="agentId">Agent id (agent_…) or speech engine external id (seng_), resolved to the same underlying resource.</param>
    /// <param name="reference">A Slack message URL or a Zendesk ticket URL.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.GetConversationResponseModel> ResolveAsync(
        string agentId,
        string reference,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (agentId is null)
            throw new ArgumentNullException(nameof(agentId));
        if (reference is null)
            throw new ArgumentNullException(nameof(reference));

        var resolvedConfig = GetResolvedConfig(_resolveAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Get, "v1/convai/conversations/resolve")
            .SetOptionalQueryParameter("agent_id", agentId)
            .SetOptionalQueryParameter("reference", reference)
            .SetOptionalHeader("xi-api-key", xiApiKey)
            .Build();

        var response = await ExecuteAsync(request, resolvedConfig, cancellationToken)
            .ConfigureAwait(false);

        // Standard deserialization
        // Read the body first so a decode failure can report the bytes that caused it.
        var responseBody = await response
            .Content
#if NET5_0_OR_GREATER
            .ReadAsStringAsync(cancellationToken)
#else
        .ReadAsStringAsync()
#endif
            .ConfigureAwait(false);
        global::ElevenLabs.GetConversationResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.GetConversationResponseModel>(
                    responseBody,
                    _jsonSerializerOptions
                )!;
        }
        catch (global::System.Text.Json.JsonException exception)
        {
            throw new ElevenLabs.ElevenLabsClientApiException(
                "Failed to deserialize response",
                (int)response.StatusCode,
                responseBody,
                exception,
                rawResponse: ElevenLabs.Core.RawResponseFactory.FromHttpResponseMessage(response)
            );
        }

        return result;
    }

    /// <summary>Get the details of a particular conversation</summary>
    /// <param name="conversationId">The id of the conversation you're taking the action on.</param>
    /// <param name="format">Response format. Defaults to 'json'. Set to 'opentelemetry' for an OTLP-compatible trace payload using the same structure as the post-call webhook.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.GetConversationResponseModel> GetAsync(
        string conversationId,
        global::ElevenLabs.Agents.GetConversationsRequestFormat? format = null,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (conversationId is null)
            throw new ArgumentNullException(nameof(conversationId));

        var resolvedConfig = GetResolvedConfig(_getAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Get,
            "v1/convai/conversations/{conversation_id}"
        )
            .SetPathParameter("conversation_id", conversationId)
            .SetOptionalQueryParameter("format", format?.Value)
            .SetOptionalHeader("xi-api-key", xiApiKey)
            .Build();

        var response = await ExecuteAsync(request, resolvedConfig, cancellationToken)
            .ConfigureAwait(false);

        // Standard deserialization
        // Read the body first so a decode failure can report the bytes that caused it.
        var responseBody = await response
            .Content
#if NET5_0_OR_GREATER
            .ReadAsStringAsync(cancellationToken)
#else
        .ReadAsStringAsync()
#endif
            .ConfigureAwait(false);
        global::ElevenLabs.GetConversationResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.GetConversationResponseModel>(
                    responseBody,
                    _jsonSerializerOptions
                )!;
        }
        catch (global::System.Text.Json.JsonException exception)
        {
            throw new ElevenLabs.ElevenLabsClientApiException(
                "Failed to deserialize response",
                (int)response.StatusCode,
                responseBody,
                exception,
                rawResponse: ElevenLabs.Core.RawResponseFactory.FromHttpResponseMessage(response)
            );
        }

        return result;
    }

    /// <summary>Delete a particular conversation</summary>
    /// <param name="conversationId">The id of the conversation you're taking the action on.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<object> DeleteAsync(
        string conversationId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (conversationId is null)
            throw new ArgumentNullException(nameof(conversationId));

        var resolvedConfig = GetResolvedConfig(_deleteAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Delete,
            "v1/convai/conversations/{conversation_id}"
        )
            .SetPathParameter("conversation_id", conversationId)
            .SetOptionalHeader("xi-api-key", xiApiKey)
            .Build();

        var response = await ExecuteAsync(request, resolvedConfig, cancellationToken)
            .ConfigureAwait(false);

        // Standard deserialization
        // Read the body first so a decode failure can report the bytes that caused it.
        var responseBody = await response
            .Content
#if NET5_0_OR_GREATER
            .ReadAsStringAsync(cancellationToken)
#else
        .ReadAsStringAsync()
#endif
            .ConfigureAwait(false);
        object result;
        try
        {
            result = global::System.Text.Json.JsonSerializer.Deserialize<object>(
                responseBody,
                _jsonSerializerOptions
            )!;
        }
        catch (global::System.Text.Json.JsonException exception)
        {
            throw new ElevenLabs.ElevenLabsClientApiException(
                "Failed to deserialize response",
                (int)response.StatusCode,
                responseBody,
                exception,
                rawResponse: ElevenLabs.Core.RawResponseFactory.FromHttpResponseMessage(response)
            );
        }

        return result;
    }

    /// <summary>Get a lightweight summary of a conversation: its title, the generated transcript summary, whether the call was successful, and — only when the conversation is short — the plain chat messages. Tool calls, tool results, and contextual updates are omitted so the response stays small. Use this instead of the full conversation endpoint when you only need the gist (e.g. an agent reading many conversations); use GET /v1/convai/conversations/{conversation_id} when you need the full transcript with tool calls and contextual updates.</summary>
    /// <param name="conversationId">The id of the conversation you're taking the action on.</param>
    /// <param name="maxMessages">Maximum number of chat message turns to include inline. When the conversation has more than this, the messages are omitted and messages_omitted is set.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.GetConversationSummaryResponseModel> GetSummaryAsync(
        string conversationId,
        long? maxMessages = 40,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (conversationId is null)
            throw new ArgumentNullException(nameof(conversationId));

        var resolvedConfig = GetResolvedConfig(_getSummaryAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Get,
            "v1/convai/conversations/{conversation_id}/summary"
        )
            .SetPathParameter("conversation_id", conversationId)
            .SetOptionalQueryParameter("max_messages", maxMessages)
            .SetOptionalHeader("xi-api-key", xiApiKey)
            .Build();

        var response = await ExecuteAsync(request, resolvedConfig, cancellationToken)
            .ConfigureAwait(false);

        // Standard deserialization
        // Read the body first so a decode failure can report the bytes that caused it.
        var responseBody = await response
            .Content
#if NET5_0_OR_GREATER
            .ReadAsStringAsync(cancellationToken)
#else
        .ReadAsStringAsync()
#endif
            .ConfigureAwait(false);
        global::ElevenLabs.GetConversationSummaryResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.GetConversationSummaryResponseModel>(
                    responseBody,
                    _jsonSerializerOptions
                )!;
        }
        catch (global::System.Text.Json.JsonException exception)
        {
            throw new ElevenLabs.ElevenLabsClientApiException(
                "Failed to deserialize response",
                (int)response.StatusCode,
                responseBody,
                exception,
                rawResponse: ElevenLabs.Core.RawResponseFactory.FromHttpResponseMessage(response)
            );
        }

        return result;
    }

    /// <summary>Get SIP messages associated with a conversation's phone call</summary>
    /// <param name="conversationId">The id of the conversation you're taking the action on.</param>
    /// <param name="cursor">Used for fetching next page. Cursor is returned in the response.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.GetSipLogMessagesResponse> GetSipMessagesAsync(
        string conversationId,
        long? pageSize = 20,
        string? cursor = null,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (conversationId is null)
            throw new ArgumentNullException(nameof(conversationId));

        var resolvedConfig = GetResolvedConfig(_getSipMessagesAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Get,
            "v1/convai/conversations/{conversation_id}/sip-messages"
        )
            .SetPathParameter("conversation_id", conversationId)
            .SetOptionalQueryParameter("page_size", pageSize)
            .SetOptionalQueryParameter("cursor", cursor)
            .SetOptionalHeader("xi-api-key", xiApiKey)
            .Build();

        var response = await ExecuteAsync(request, resolvedConfig, cancellationToken)
            .ConfigureAwait(false);

        // Standard deserialization
        // Read the body first so a decode failure can report the bytes that caused it.
        var responseBody = await response
            .Content
#if NET5_0_OR_GREATER
            .ReadAsStringAsync(cancellationToken)
#else
        .ReadAsStringAsync()
#endif
            .ConfigureAwait(false);
        global::ElevenLabs.GetSipLogMessagesResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.GetSipLogMessagesResponse>(
                    responseBody,
                    _jsonSerializerOptions
                )!;
        }
        catch (global::System.Text.Json.JsonException exception)
        {
            throw new ElevenLabs.ElevenLabsClientApiException(
                "Failed to deserialize response",
                (int)response.StatusCode,
                responseBody,
                exception,
                rawResponse: ElevenLabs.Core.RawResponseFactory.FromHttpResponseMessage(response)
            );
        }

        return result;
    }
}
