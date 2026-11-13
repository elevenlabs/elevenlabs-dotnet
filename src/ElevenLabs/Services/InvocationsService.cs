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
/// Service class providing access to API endpoints for InvocationsService.
/// Inherits HTTP client management, JSON serialization, and streaming capabilities from the base service.
/// Each method corresponds to an API operation and handles request building, execution, and response parsing.
/// </summary>
internal class InvocationsService : BaseService
{
    private RequestConfig? _listAsyncConfig;
    private RequestConfig? _getAsyncConfig;
    private RequestConfig? _updateAsyncConfig;
    private RequestConfig? _cancelAsyncConfig;
    private RequestConfig? _resubmitAsyncConfig;

    internal InvocationsService(global::ElevenLabs.Http.Client httpClient)
        : base(httpClient) { }

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public InvocationsService SetListAsyncConfig(RequestConfig config)
    {
        _listAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public InvocationsService SetGetAsyncConfig(RequestConfig config)
    {
        _getAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>UpdateAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public InvocationsService SetUpdateAsyncConfig(RequestConfig config)
    {
        _updateAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CancelAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public InvocationsService SetCancelAsyncConfig(RequestConfig config)
    {
        _cancelAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ResubmitAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public InvocationsService SetResubmitAsyncConfig(RequestConfig config)
    {
        _resubmitAsyncConfig = config;
        return this;
    }

    /// <summary>Lists all test invocations with pagination support and optional search filtering.</summary>
    /// <param name="agentId">Filter by agent ID</param>
    /// <param name="branchId">Filter by branch ID</param>
    /// <param name="createdByUserId">Filter by test run creator user ID</param>
    /// <param name="testId">Filter to invocations that include a run of this test id</param>
    /// <param name="startTime">Inclusive lower bound on created_at, in unix seconds</param>
    /// <param name="endTime">Inclusive upper bound on created_at, in unix seconds</param>
    /// <param name="versionId">Filter by the agent version the tests ran against</param>
    /// <param name="pageSize">How many Tests to return at maximum. Can not exceed 100, defaults to 30.</param>
    /// <param name="search">Search query to filter tests and folders by name.</param>
    /// <param name="cursor">Used for fetching next page. Cursor is returned in the response.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.GetTestInvocationsPageResponseModel> ListAsync(
        string? agentId = null,
        string? branchId = null,
        string? createdByUserId = null,
        string? testId = null,
        long? startTime = null,
        long? endTime = null,
        string? versionId = null,
        long? pageSize = 30,
        string? search = null,
        string? cursor = null,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        var resolvedConfig = GetResolvedConfig(_listAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Get, "v1/convai/test-invocations")
            .SetOptionalQueryParameter("agent_id", agentId)
            .SetOptionalQueryParameter("branch_id", branchId)
            .SetOptionalQueryParameter("created_by_user_id", createdByUserId)
            .SetOptionalQueryParameter("test_id", testId)
            .SetOptionalQueryParameter("start_time", startTime)
            .SetOptionalQueryParameter("end_time", endTime)
            .SetOptionalQueryParameter("version_id", versionId)
            .SetOptionalQueryParameter("page_size", pageSize)
            .SetOptionalQueryParameter("search", search)
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
        global::ElevenLabs.GetTestInvocationsPageResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.GetTestInvocationsPageResponseModel>(
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

    /// <summary>Gets a test invocation by ID.</summary>
    /// <param name="testInvocationId">The id of a test invocation. This is returned when tests are run.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.GetTestSuiteInvocationResponseModel> GetAsync(
        string testInvocationId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (testInvocationId is null)
            throw new ArgumentNullException(nameof(testInvocationId));

        var resolvedConfig = GetResolvedConfig(_getAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Get,
            "v1/convai/test-invocations/{test_invocation_id}"
        )
            .SetPathParameter("test_invocation_id", testInvocationId)
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
        global::ElevenLabs.GetTestSuiteInvocationResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.GetTestSuiteInvocationResponseModel>(
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

    /// <summary>Updates the user-provided name of a test invocation.</summary>
    /// <param name="testInvocationId">The id of a test invocation. This is returned when tests are run.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.GetTestSuiteInvocationResponseModel> UpdateAsync(
        global::ElevenLabs.Agents.Tests.UpdateTestSuiteInvocationRequestModel input,
        string testInvocationId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));
        if (testInvocationId is null)
            throw new ArgumentNullException(nameof(testInvocationId));

        var resolvedConfig = GetResolvedConfig(_updateAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            new HttpMethod("PATCH"),
            "v1/convai/test-invocations/{test_invocation_id}"
        )
            .SetPathParameter("test_invocation_id", testInvocationId)
            .SetOptionalHeader("xi-api-key", xiApiKey)
            .SetContentAsJson(input, _jsonSerializerOptions)
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
        global::ElevenLabs.GetTestSuiteInvocationResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.GetTestSuiteInvocationResponseModel>(
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

    /// <summary>Cancels all pending runs in a test invocation.</summary>
    /// <param name="testInvocationId">The id of a test invocation. This is returned when tests are run.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task CancelAsync(
        string testInvocationId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (testInvocationId is null)
            throw new ArgumentNullException(nameof(testInvocationId));

        var resolvedConfig = GetResolvedConfig(_cancelAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Post,
            "v1/convai/test-invocations/{test_invocation_id}/cancel"
        )
            .SetPathParameter("test_invocation_id", testInvocationId)
            .SetOptionalHeader("xi-api-key", xiApiKey)
            .Build();

        var response = await ExecuteAsync(request, resolvedConfig, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>Resubmits specific test runs from a test invocation.</summary>
    /// <param name="testInvocationId">The id of a test invocation. This is returned when tests are run.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<object> ResubmitAsync(
        global::ElevenLabs.Agents.Tests.ResubmitTestsRequestModel input,
        string testInvocationId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));
        if (testInvocationId is null)
            throw new ArgumentNullException(nameof(testInvocationId));

        var resolvedConfig = GetResolvedConfig(_resubmitAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Post,
            "v1/convai/test-invocations/{test_invocation_id}/resubmit"
        )
            .SetPathParameter("test_invocation_id", testInvocationId)
            .SetOptionalHeader("xi-api-key", xiApiKey)
            .SetContentAsJson(input, _jsonSerializerOptions)
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
}
