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
/// Service class providing access to API endpoints for UsersService.
/// Inherits HTTP client management, JSON serialization, and streaming capabilities from the base service.
/// Each method corresponds to an API operation and handles request building, execution, and response parsing.
/// </summary>
internal class UsersService : BaseService
{
    private RequestConfig? _listAsyncConfig;

    internal UsersService(global::ElevenLabs.Http.Client httpClient)
        : base(httpClient) { }

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public UsersService SetListAsyncConfig(RequestConfig config)
    {
        _listAsyncConfig = config;
        return this;
    }

    /// <summary>Get distinct users from conversations with pagination.</summary>
    /// <param name="agentId">Agent id (agent_…) or speech engine external id (seng_), resolved to the same underlying resource.</param>
    /// <param name="branchId">Filter conversations by branch ID.</param>
    /// <param name="callStartBeforeUnix">Unix timestamp (in seconds) to filter conversations up to this start date.</param>
    /// <param name="callStartAfterUnix">Unix timestamp (in seconds) to filter conversations after to this start date.</param>
    /// <param name="search">Search/filter by user ID (exact match).</param>
    /// <param name="pageSize">How many users to return at maximum. Defaults to 30.</param>
    /// <param name="sortBy">The field to sort the results by. Defaults to last_contact_unix_secs.</param>
    /// <param name="sortDirection">The direction to sort the results</param>
    /// <param name="cursor">Used for fetching next page. Cursor is returned in the response.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.GetConversationUsersPageResponseModel> ListAsync(
        string? agentId = null,
        string? branchId = null,
        long? callStartBeforeUnix = null,
        long? callStartAfterUnix = null,
        string? search = null,
        long? pageSize = 30,
        global::ElevenLabs.Agents.UsersSortBy? sortBy = null,
        global::ElevenLabs.SortDirection1? sortDirection = null,
        string? cursor = null,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        var resolvedConfig = GetResolvedConfig(_listAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Get, "v1/convai/users")
            .SetOptionalQueryParameter("agent_id", agentId)
            .SetOptionalQueryParameter("branch_id", branchId)
            .SetOptionalQueryParameter("call_start_before_unix", callStartBeforeUnix)
            .SetOptionalQueryParameter("call_start_after_unix", callStartAfterUnix)
            .SetOptionalQueryParameter("search", search)
            .SetOptionalQueryParameter("page_size", pageSize)
            .SetOptionalQueryParameter("sort_by", sortBy?.Value)
            .SetOptionalQueryParameter("sort_direction", sortDirection?.Value)
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
        global::ElevenLabs.GetConversationUsersPageResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.GetConversationUsersPageResponseModel>(
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
