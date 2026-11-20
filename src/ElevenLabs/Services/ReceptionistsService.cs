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
/// Service class providing access to API endpoints for ReceptionistsService.
/// Inherits HTTP client management, JSON serialization, and streaming capabilities from the base service.
/// Each method corresponds to an API operation and handles request building, execution, and response parsing.
/// </summary>
internal class ReceptionistsService : BaseService
{
    private RequestConfig? _listAsyncConfig;
    private RequestConfig? _updateAsyncConfig;
    private RequestConfig? _activateAsyncConfig;

    internal ReceptionistsService(global::ElevenLabs.Http.Client httpClient)
        : base(httpClient) { }

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public ReceptionistsService SetListAsyncConfig(RequestConfig config)
    {
        _listAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>UpdateAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public ReceptionistsService SetUpdateAsyncConfig(RequestConfig config)
    {
        _updateAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ActivateAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public ReceptionistsService SetActivateAsyncConfig(RequestConfig config)
    {
        _activateAsyncConfig = config;
        return this;
    }

    /// <summary>List every customer-facing receptionist for the workspace.</summary>
    /// <param name="xiWorkspaceId">The customer workspace a reseller's API key acts on.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<
        List<global::ElevenLabs.ReceptionCustomerFacingAgentResponse>
    > ListAsync(
        string xiWorkspaceId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (xiWorkspaceId is null)
            throw new ArgumentNullException(nameof(xiWorkspaceId));

        var resolvedConfig = GetResolvedConfig(_listAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Get, "v1/reception/customer-facing-agents")
            .SetHeader("xi-workspace-id", xiWorkspaceId)
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
        List<global::ElevenLabs.ReceptionCustomerFacingAgentResponse> result;
        try
        {
            result = global::System.Text.Json.JsonSerializer.Deserialize<
                List<global::ElevenLabs.ReceptionCustomerFacingAgentResponse>
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

    /// <summary>Update a receptionist's display name, config and/or widget appearance.</summary>
    /// <param name="agentId">ID of the receptionist. List them with `GET /v1/reception/customer-facing-agents`.</param>
    /// <param name="xiWorkspaceId">The customer workspace a reseller's API key acts on.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.ReceptionCustomerFacingAgentResponse> UpdateAsync(
        global::ElevenLabs.Reception.ReceptionUpdateCustomerFacingAgentRequest input,
        string agentId,
        string xiWorkspaceId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));
        if (agentId is null)
            throw new ArgumentNullException(nameof(agentId));
        if (xiWorkspaceId is null)
            throw new ArgumentNullException(nameof(xiWorkspaceId));

        var resolvedConfig = GetResolvedConfig(_updateAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            new HttpMethod("PATCH"),
            "v1/reception/customer-facing-agents/{agent_id}"
        )
            .SetPathParameter("agent_id", agentId)
            .SetHeader("xi-workspace-id", xiWorkspaceId)
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
        global::ElevenLabs.ReceptionCustomerFacingAgentResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.ReceptionCustomerFacingAgentResponse>(
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

    /// <summary>Re-activate a deactivated receptionist. Fails with `quota_exceeded` when the plan has no free receptionist slot.</summary>
    /// <param name="agentId">ID of the receptionist. List them with `GET /v1/reception/customer-facing-agents`.</param>
    /// <param name="xiWorkspaceId">The customer workspace a reseller's API key acts on.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.ReceptionCustomerFacingAgentResponse> ActivateAsync(
        string agentId,
        string xiWorkspaceId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (agentId is null)
            throw new ArgumentNullException(nameof(agentId));
        if (xiWorkspaceId is null)
            throw new ArgumentNullException(nameof(xiWorkspaceId));

        var resolvedConfig = GetResolvedConfig(_activateAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Post,
            "v1/reception/customer-facing-agents/{agent_id}/activate"
        )
            .SetPathParameter("agent_id", agentId)
            .SetHeader("xi-workspace-id", xiWorkspaceId)
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
        global::ElevenLabs.ReceptionCustomerFacingAgentResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.ReceptionCustomerFacingAgentResponse>(
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
