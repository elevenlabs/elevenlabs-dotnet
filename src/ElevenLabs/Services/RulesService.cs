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
/// Service class providing access to API endpoints for RulesService.
/// Inherits HTTP client management, JSON serialization, and streaming capabilities from the base service.
/// Each method corresponds to an API operation and handles request building, execution, and response parsing.
/// </summary>
internal class RulesService : BaseService
{
    private RequestConfig? _setAsyncConfig;
    private RequestConfig? _addAsyncConfig;
    private RequestConfig? _removeAsyncConfig;
    private RequestConfig? _createAsyncConfig;
    private RequestConfig? _updateAsyncConfig;
    private RequestConfig? _deleteAsyncConfig;

    internal RulesService(global::ElevenLabs.Http.Client httpClient)
        : base(httpClient) { }

    /// <summary>
    /// Sets method-level configuration for <c>SetAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public RulesService SetSetAsyncConfig(RequestConfig config)
    {
        _setAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>AddAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public RulesService SetAddAsyncConfig(RequestConfig config)
    {
        _addAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>RemoveAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public RulesService SetRemoveAsyncConfig(RequestConfig config)
    {
        _removeAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CreateAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public RulesService SetCreateAsyncConfig(RequestConfig config)
    {
        _createAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>UpdateAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public RulesService SetUpdateAsyncConfig(RequestConfig config)
    {
        _updateAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>DeleteAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public RulesService SetDeleteAsyncConfig(RequestConfig config)
    {
        _deleteAsyncConfig = config;
        return this;
    }

    /// <summary>Replaces all existing rules on the pronunciation dictionary with the provided ones.</summary>
    /// <param name="pronunciationDictionaryId">The id of the pronunciation dictionary</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.PronunciationDictionaryRulesResponseModel> SetAsync(
        global::ElevenLabs.PronunciationDictionaries.BodySetRulesOnThePronunciationDictionaryV1PronunciationDictionariesPronunciationDictionaryIdSetRules input,
        string pronunciationDictionaryId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));
        if (pronunciationDictionaryId is null)
            throw new ArgumentNullException(nameof(pronunciationDictionaryId));

        var resolvedConfig = GetResolvedConfig(_setAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Post,
            "v1/pronunciation-dictionaries/{pronunciation_dictionary_id}/set-rules"
        )
            .SetPathParameter("pronunciation_dictionary_id", pronunciationDictionaryId)
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
        global::ElevenLabs.PronunciationDictionaryRulesResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.PronunciationDictionaryRulesResponseModel>(
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

    /// <summary>Add rules to the pronunciation dictionary. If a rule with the same string_to_replace already exists, it will be replaced.</summary>
    /// <param name="pronunciationDictionaryId">The id of the pronunciation dictionary</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.PronunciationDictionaryRulesResponseModel> AddAsync(
        global::ElevenLabs.PronunciationDictionaries.PronunciationDictionary input,
        string pronunciationDictionaryId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));
        if (pronunciationDictionaryId is null)
            throw new ArgumentNullException(nameof(pronunciationDictionaryId));

        var resolvedConfig = GetResolvedConfig(_addAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Post,
            "v1/pronunciation-dictionaries/{pronunciation_dictionary_id}/add-rules"
        )
            .SetPathParameter("pronunciation_dictionary_id", pronunciationDictionaryId)
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
        global::ElevenLabs.PronunciationDictionaryRulesResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.PronunciationDictionaryRulesResponseModel>(
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

    /// <summary>Remove rules from the pronunciation dictionary</summary>
    /// <param name="pronunciationDictionaryId">The id of the pronunciation dictionary</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.PronunciationDictionaryRulesResponseModel> RemoveAsync(
        global::ElevenLabs.PronunciationDictionaries.RemovePronunciationDictionaryRulesRequest input,
        string pronunciationDictionaryId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));
        if (pronunciationDictionaryId is null)
            throw new ArgumentNullException(nameof(pronunciationDictionaryId));

        var resolvedConfig = GetResolvedConfig(_removeAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Post,
            "v1/pronunciation-dictionaries/{pronunciation_dictionary_id}/remove-rules"
        )
            .SetPathParameter("pronunciation_dictionary_id", pronunciationDictionaryId)
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
        global::ElevenLabs.PronunciationDictionaryRulesResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.PronunciationDictionaryRulesResponseModel>(
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

    /// <summary>Add a behavioral rule to the named receptionist.</summary>
    /// <param name="agentId">ID of the receptionist. List them with `GET /v1/reception/customer-facing-agents`.</param>
    /// <param name="xiWorkspaceId">The customer workspace a reseller's API key acts on.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.AgentRule> CreateAsync(
        global::ElevenLabs.Reception.Receptionists.ReceptionCreateAgentRuleRequest input,
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

        var resolvedConfig = GetResolvedConfig(_createAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Post,
            "v1/reception/customer-facing-agents/{agent_id}/rules"
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
        global::ElevenLabs.AgentRule result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.AgentRule>(
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

    /// <summary>Replace an existing rule on the named receptionist. Send every field: an omitted `priority` resets to `strict`.</summary>
    /// <param name="agentId">ID of the receptionist. List them with `GET /v1/reception/customer-facing-agents`.</param>
    /// <param name="ruleId">ID of the rule. Returned when you add one, and listed in the receptionist's `config.agent_rules`.</param>
    /// <param name="xiWorkspaceId">The customer workspace a reseller's API key acts on.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.AgentRule> UpdateAsync(
        global::ElevenLabs.Reception.Receptionists.ReceptionUpdateAgentRuleRequest input,
        string agentId,
        string ruleId,
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
        if (ruleId is null)
            throw new ArgumentNullException(nameof(ruleId));
        if (xiWorkspaceId is null)
            throw new ArgumentNullException(nameof(xiWorkspaceId));

        var resolvedConfig = GetResolvedConfig(_updateAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Put,
            "v1/reception/customer-facing-agents/{agent_id}/rules/{rule_id}"
        )
            .SetPathParameter("agent_id", agentId)
            .SetPathParameter("rule_id", ruleId)
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
        global::ElevenLabs.AgentRule result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.AgentRule>(
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

    /// <summary>Delete a rule from the named receptionist.</summary>
    /// <param name="agentId">ID of the receptionist. List them with `GET /v1/reception/customer-facing-agents`.</param>
    /// <param name="ruleId">ID of the rule. Returned when you add one, and listed in the receptionist's `config.agent_rules`.</param>
    /// <param name="xiWorkspaceId">The customer workspace a reseller's API key acts on.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<Dictionary<string, string>> DeleteAsync(
        string agentId,
        string ruleId,
        string xiWorkspaceId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (agentId is null)
            throw new ArgumentNullException(nameof(agentId));
        if (ruleId is null)
            throw new ArgumentNullException(nameof(ruleId));
        if (xiWorkspaceId is null)
            throw new ArgumentNullException(nameof(xiWorkspaceId));

        var resolvedConfig = GetResolvedConfig(_deleteAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Delete,
            "v1/reception/customer-facing-agents/{agent_id}/rules/{rule_id}"
        )
            .SetPathParameter("agent_id", agentId)
            .SetPathParameter("rule_id", ruleId)
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
