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
/// Service class providing access to API endpoints for MessagesService.
/// Inherits HTTP client management, JSON serialization, and streaming capabilities from the base service.
/// Each method corresponds to an API operation and handles request building, execution, and response parsing.
/// </summary>
internal class MessagesService : BaseService
{
    private RequestConfig? _textSearchAsyncConfig;
    private RequestConfig? _searchAsyncConfig;

    internal MessagesService(global::ElevenLabs.Http.Client httpClient)
        : base(httpClient) { }

    /// <summary>
    /// Sets method-level configuration for <c>TextSearchAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public MessagesService SetTextSearchAsyncConfig(RequestConfig config)
    {
        _textSearchAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>SearchAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public MessagesService SetSearchAsyncConfig(RequestConfig config)
    {
        _searchAsyncConfig = config;
        return this;
    }

    /// <summary>Search through conversation transcript messages by full-text and fuzzy search</summary>
    /// <param name="textQuery">The search query text for full-text and fuzzy matching</param>
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
    /// <param name="excludeStatuses">Exclude conversations with the given statuses. Useful for hiding in-progress / processing conversations from list views.</param>
    /// <param name="terminationReasons">Filter conversations by their stored termination_reason (metadata.termination_reason). Repeat param to match any of several.</param>
    /// <param name="pageSize">Number of results per page. Max 50.</param>
    /// <param name="summaryMode">Whether to include transcript summaries in the response.</param>
    /// <param name="conversationProductType">Restrict results to a single conversation product surface.</param>
    /// <param name="branchId">Filter conversations by branch ID.</param>
    /// <param name="versionId">Filter conversations by version ID.</param>
    /// <param name="topicIds">Filter conversations by topic IDs assigned during topic discovery.</param>
    /// <param name="sortBy">Sort order for search results. 'search_score' sorts by search score, 'created_at' sorts by conversation start time.</param>
    /// <param name="cursor">Used for fetching next page. Cursor is returned in the response.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.MessagesSearchResponse> TextSearchAsync(
        string textQuery,
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
        List<global::ElevenLabs.Agents.Conversations.TextSearchMessagesRequestExcludeStatusesItem>? excludeStatuses =
            null,
        List<string>? terminationReasons = null,
        long? pageSize = 20,
        global::ElevenLabs.Agents.Conversations.TextSearchMessagesRequestSummaryMode? summaryMode =
            null,
        global::ElevenLabs.ConversationInitiationSource1? conversationInitiationSource = null,
        bool? textOnly = null,
        global::ElevenLabs.ConversationProduct? conversationProductType = null,
        string? branchId = null,
        string? versionId = null,
        List<string>? topicIds = null,
        global::ElevenLabs.Agents.Conversations.MessageSearchSortBy? sortBy = null,
        string? cursor = null,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (textQuery is null)
            throw new ArgumentNullException(nameof(textQuery));

        var resolvedConfig = GetResolvedConfig(_textSearchAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Get,
            "v1/convai/conversations/messages/text-search"
        )
            .SetOptionalQueryParameter("text_query", textQuery)
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
            .SetOptionalQueryParameter("exclude_statuses", excludeStatuses)
            .SetOptionalQueryParameter("termination_reasons", terminationReasons)
            .SetOptionalQueryParameter("page_size", pageSize)
            .SetOptionalQueryParameter("summary_mode", summaryMode?.Value)
            .SetOptionalQueryParameter(
                "conversation_initiation_source",
                conversationInitiationSource?.Value
            )
            .SetOptionalQueryParameter("text_only", textOnly)
            .SetOptionalQueryParameter("conversation_product_type", conversationProductType?.Value)
            .SetOptionalQueryParameter("branch_id", branchId)
            .SetOptionalQueryParameter("version_id", versionId)
            .SetOptionalQueryParameter("topic_ids", topicIds)
            .SetOptionalQueryParameter("sort_by", sortBy?.Value)
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
        global::ElevenLabs.MessagesSearchResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.MessagesSearchResponse>(
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

    /// <summary>Search conversation transcripts by semantic similarity to surface relevant messages based on meaning and intent, rather than exact keyword matches</summary>
    /// <param name="textQuery">The search query text for semantic similarity matching</param>
    /// <param name="agentId">Agent id (agent_…) or speech engine external id (seng_), resolved to the same underlying resource.</param>
    /// <param name="branchId">Filter conversations by branch ID.</param>
    /// <param name="pageSize">Number of results per page. Max 50.</param>
    /// <param name="cursor">Used for fetching next page. Cursor is returned in the response.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.MessagesSearchResponse> SearchAsync(
        string textQuery,
        string? agentId = null,
        string? branchId = null,
        long? pageSize = 20,
        string? cursor = null,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (textQuery is null)
            throw new ArgumentNullException(nameof(textQuery));

        var resolvedConfig = GetResolvedConfig(_searchAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Get,
            "v1/convai/conversations/messages/smart-search"
        )
            .SetOptionalQueryParameter("text_query", textQuery)
            .SetOptionalQueryParameter("agent_id", agentId)
            .SetOptionalQueryParameter("branch_id", branchId)
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
        global::ElevenLabs.MessagesSearchResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.MessagesSearchResponse>(
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
