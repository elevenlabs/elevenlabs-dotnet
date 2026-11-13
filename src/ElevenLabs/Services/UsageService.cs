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
/// Service class providing access to API endpoints for UsageService.
/// Inherits HTTP client management, JSON serialization, and streaming capabilities from the base service.
/// Each method corresponds to an API operation and handles request building, execution, and response parsing.
/// </summary>
internal class UsageService : BaseService
{
    private RequestConfig? _getUsageByProductOverTimeAsyncConfig;
    private RequestConfig? _getUsageAsyncConfig;

    internal UsageService(global::ElevenLabs.Http.Client httpClient)
        : base(httpClient) { }

    /// <summary>
    /// Sets method-level configuration for <c>GetUsageByProductOverTimeAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public UsageService SetGetUsageByProductOverTimeAsyncConfig(RequestConfig config)
    {
        _getUsageByProductOverTimeAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetUsageAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public UsageService SetGetUsageAsyncConfig(RequestConfig config)
    {
        _getUsageAsyncConfig = config;
        return this;
    }

    /// <summary>Returns credit usage broken down by product type over time, for workspaces billed in credits. The response is a tabular structure with columns, column_types, column_units, and rows. Some id columns also get a display-name column, such as user_label or voice_name, appended after the existing columns. For workspaces billed by cost, ranges that reach the date the workspace moved to cost billing return an error; use /v1/workspace/analytics/usage instead.</summary>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.WorkspaceAnalyticsQueryResponseModel> GetUsageByProductOverTimeAsync(
        global::ElevenLabs.Workspace.BodyGetWorkspaceUsageV1WorkspaceAnalyticsQueryUsageByProductOverTimePost input,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));

        var resolvedConfig = GetResolvedConfig(
            _getUsageByProductOverTimeAsyncConfig,
            requestConfig
        );

        var request = new RequestBuilder(
            HttpMethod.Post,
            "v1/workspace/analytics/query/usage-by-product-over-time"
        )
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
        global::ElevenLabs.WorkspaceAnalyticsQueryResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.WorkspaceAnalyticsQueryResponseModel>(
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

    /// <summary>Returns the cost of the workspace's usage over time, for workspaces billed by cost. Usage is bucketed by UTC day. The response is a tabular structure with columns, column_types, column_units, and rows, with one row per group and bucket. `total_cost` is the cost in the workspace's currency and `total_charge_count` the billed quantity. Usage can be grouped or filtered by at most two of `user_id`, `hashed_xi_api_key`, `region`, `reporting_workspace_id`, `billing_group_id`, `product_type`, `surface` and `actor`, and grouping by two of them requires an `eq` or `in` filter on one. `model`, `request_source`, `fiat_charge_type` and `fiat_currency` can always be added. Some id columns also get a display-name column, such as user_label, appended after the existing columns. Workspaces billed in credits should use /v1/workspace/analytics/query/usage-by-product-over-time.</summary>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.WorkspaceAnalyticsQueryResponseModel> GetUsageAsync(
        global::ElevenLabs.Workspace.BodyGetWorkspaceCostUsageV1WorkspaceAnalyticsUsagePost input,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));

        var resolvedConfig = GetResolvedConfig(_getUsageAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Post, "v1/workspace/analytics/usage")
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
        global::ElevenLabs.WorkspaceAnalyticsQueryResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.WorkspaceAnalyticsQueryResponseModel>(
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
