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

namespace ElevenLabs.Services;

/// <summary>
/// Service class providing access to API endpoints for SubscriptionsService.
/// Inherits HTTP client management, JSON serialization, and streaming capabilities from the base service.
/// Each method corresponds to an API operation and handles request building, execution, and response parsing.
/// </summary>
internal class SubscriptionsService : BaseService
{
    private RequestConfig? _assignAsyncConfig;
    private RequestConfig? _changeAsyncConfig;
    private RequestConfig? _unassignAsyncConfig;
    private RequestConfig? _restoreAsyncConfig;
    private RequestConfig? _cancelPendingDowngradeAsyncConfig;

    internal SubscriptionsService(global::ElevenLabs.Http.Client httpClient)
        : base(httpClient) { }

    /// <summary>
    /// Sets method-level configuration for <c>AssignAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public SubscriptionsService SetAssignAsyncConfig(RequestConfig config)
    {
        _assignAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ChangeAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public SubscriptionsService SetChangeAsyncConfig(RequestConfig config)
    {
        _changeAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>UnassignAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public SubscriptionsService SetUnassignAsyncConfig(RequestConfig config)
    {
        _unassignAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>RestoreAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public SubscriptionsService SetRestoreAsyncConfig(RequestConfig config)
    {
        _restoreAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CancelPendingDowngradeAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public SubscriptionsService SetCancelPendingDowngradeAsyncConfig(RequestConfig config)
    {
        _cancelPendingDowngradeAsyncConfig = config;
        return this;
    }

    /// <summary>Subscribe a reseller-attributed workspace to one of the reseller's tiers</summary>
    /// <param name="workspaceId">ID of the customer workspace. Returned when you provision one; list them with `GET /v1/reception/reseller/workspaces`.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<Dictionary<string, string>> AssignAsync(
        global::ElevenLabs.Reception.AssignResellerTierRequest input,
        string workspaceId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));
        if (workspaceId is null)
            throw new ArgumentNullException(nameof(workspaceId));

        var resolvedConfig = GetResolvedConfig(_assignAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Post,
            "v1/reception/reseller/workspaces/{workspace_id}/subscription"
        )
            .SetPathParameter("workspace_id", workspaceId)
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
        Dictionary<string, string> result;
        try
        {
            result = global::System.Text.Json.JsonSerializer.Deserialize<
                Dictionary<string, string>
            >(responseBody, _jsonSerializerOptions)!;
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

    /// <summary>Move a reseller-attributed workspace between the reseller's tiers. Upgrades apply immediately; downgrades and lateral moves take effect at the end of the billing period.</summary>
    /// <param name="workspaceId">ID of the customer workspace. Returned when you provision one; list them with `GET /v1/reception/reseller/workspaces`.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<Dictionary<string, string>> ChangeAsync(
        global::ElevenLabs.Reception.ChangeResellerTierRequest input,
        string workspaceId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));
        if (workspaceId is null)
            throw new ArgumentNullException(nameof(workspaceId));

        var resolvedConfig = GetResolvedConfig(_changeAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            new HttpMethod("PATCH"),
            "v1/reception/reseller/workspaces/{workspace_id}/subscription"
        )
            .SetPathParameter("workspace_id", workspaceId)
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
        Dictionary<string, string> result;
        try
        {
            result = global::System.Text.Json.JsonSerializer.Deserialize<
                Dictionary<string, string>
            >(responseBody, _jsonSerializerOptions)!;
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

    /// <summary>End a reseller-attributed workspace's subscription at the end of the current billing period</summary>
    /// <param name="workspaceId">ID of the customer workspace. Returned when you provision one; list them with `GET /v1/reception/reseller/workspaces`.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<Dictionary<string, string>> UnassignAsync(
        string workspaceId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (workspaceId is null)
            throw new ArgumentNullException(nameof(workspaceId));

        var resolvedConfig = GetResolvedConfig(_unassignAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Delete,
            "v1/reception/reseller/workspaces/{workspace_id}/subscription"
        )
            .SetPathParameter("workspace_id", workspaceId)
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
        Dictionary<string, string> result;
        try
        {
            result = global::System.Text.Json.JsonSerializer.Deserialize<
                Dictionary<string, string>
            >(responseBody, _jsonSerializerOptions)!;
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

    /// <summary>Undo a pending unassignment so the subscription renews normally</summary>
    /// <param name="workspaceId">ID of the customer workspace. Returned when you provision one; list them with `GET /v1/reception/reseller/workspaces`.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<Dictionary<string, string>> RestoreAsync(
        string workspaceId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (workspaceId is null)
            throw new ArgumentNullException(nameof(workspaceId));

        var resolvedConfig = GetResolvedConfig(_restoreAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Post,
            "v1/reception/reseller/workspaces/{workspace_id}/subscription/restore"
        )
            .SetPathParameter("workspace_id", workspaceId)
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
        Dictionary<string, string> result;
        try
        {
            result = global::System.Text.Json.JsonSerializer.Deserialize<
                Dictionary<string, string>
            >(responseBody, _jsonSerializerOptions)!;
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

    /// <summary>Drop a scheduled downgrade, leaving the workspace on its current tier</summary>
    /// <param name="workspaceId">ID of the customer workspace. Returned when you provision one; list them with `GET /v1/reception/reseller/workspaces`.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<
        Dictionary<string, string>
    > CancelPendingDowngradeAsync(
        string workspaceId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (workspaceId is null)
            throw new ArgumentNullException(nameof(workspaceId));

        var resolvedConfig = GetResolvedConfig(_cancelPendingDowngradeAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Post,
            "v1/reception/reseller/workspaces/{workspace_id}/subscription/cancel-downgrade"
        )
            .SetPathParameter("workspace_id", workspaceId)
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
        Dictionary<string, string> result;
        try
        {
            result = global::System.Text.Json.JsonSerializer.Deserialize<
                Dictionary<string, string>
            >(responseBody, _jsonSerializerOptions)!;
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
