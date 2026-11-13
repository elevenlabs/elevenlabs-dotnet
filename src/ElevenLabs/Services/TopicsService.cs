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
/// Service class providing access to API endpoints for TopicsService.
/// Inherits HTTP client management, JSON serialization, and streaming capabilities from the base service.
/// Each method corresponds to an API operation and handles request building, execution, and response parsing.
/// </summary>
internal class TopicsService : BaseService
{
    private RequestConfig? _getAsyncConfig;

    internal TopicsService(global::ElevenLabs.Http.Client httpClient)
        : base(httpClient) { }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public TopicsService SetGetAsyncConfig(RequestConfig config)
    {
        _getAsyncConfig = config;
        return this;
    }

    /// <summary>Returns the latest topic discovery run results for a given agent.</summary>
    /// <param name="agentId">ID of the agent</param>
    /// <param name="pageSize">Number of top-level topic groups to return.</param>
    /// <param name="sortBy">Column to rank topics by. Use conversations for volume, sentiment with sort_direction=asc for the most negative topics, and frustration with sort_direction=desc for the most frustrated ones. Topics with no score are always ranked last.</param>
    /// <param name="sortDirection">Direction to sort topics.</param>
    /// <param name="fromUnixSecs">Start of the window to view topics for. When set with to_unix_secs, the completed daily topic-discovery runs in the range are aggregated together, so the window scopes the metrics as well as the topic set. Floored to the start of its UTC day because runs cover whole UTC days; aggregated_run_count reports how many runs were summed. Omit both bounds to get the single latest run.</param>
    /// <param name="toUnixSecs">End of the window to view topics for.</param>
    /// <param name="includeEvaluationCriteria">Include the per-criteria evaluation breakdown on each topic's metrics. Pass false to drop it: it dominates the payload and the weighted success_rate is returned either way.</param>
    /// <param name="cursor">Used for fetching next page. Cursor is returned in the response.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.GetAgentTopicsResponseModel> GetAsync(
        string agentId,
        long? pageSize = null,
        global::ElevenLabs.Agents.Conversations.TopicSortBy? sortBy = null,
        global::ElevenLabs.SortDirection1? sortDirection = null,
        long? fromUnixSecs = null,
        long? toUnixSecs = null,
        bool? includeEvaluationCriteria = true,
        string? cursor = null,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (agentId is null)
            throw new ArgumentNullException(nameof(agentId));

        var resolvedConfig = GetResolvedConfig(_getAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Get, "v1/convai/agents/{agent_id}/topics")
            .SetPathParameter("agent_id", agentId)
            .SetOptionalQueryParameter("page_size", pageSize)
            .SetOptionalQueryParameter("sort_by", sortBy?.Value)
            .SetOptionalQueryParameter("sort_direction", sortDirection?.Value)
            .SetOptionalQueryParameter("from_unix_secs", fromUnixSecs)
            .SetOptionalQueryParameter("to_unix_secs", toUnixSecs)
            .SetOptionalQueryParameter("include_evaluation_criteria", includeEvaluationCriteria)
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
        global::ElevenLabs.GetAgentTopicsResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.GetAgentTopicsResponseModel>(
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
