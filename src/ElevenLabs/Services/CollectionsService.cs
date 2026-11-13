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
/// Service class providing access to API endpoints for CollectionsService.
/// Inherits HTTP client management, JSON serialization, and streaming capabilities from the base service.
/// Each method corresponds to an API operation and handles request building, execution, and response parsing.
/// </summary>
internal class CollectionsService : BaseService
{
    private RequestConfig? _listAsyncConfig;
    private RequestConfig? _createAsyncConfig;
    private RequestConfig? _getAsyncConfig;
    private RequestConfig? _updateAsyncConfig;
    private RequestConfig? _deleteAsyncConfig;
    private RequestConfig? _addVoiceAsyncConfig;
    private RequestConfig? _removeVoiceAsyncConfig;

    internal CollectionsService(global::ElevenLabs.Http.Client httpClient)
        : base(httpClient) { }

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public CollectionsService SetListAsyncConfig(RequestConfig config)
    {
        _listAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CreateAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public CollectionsService SetCreateAsyncConfig(RequestConfig config)
    {
        _createAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public CollectionsService SetGetAsyncConfig(RequestConfig config)
    {
        _getAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>UpdateAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public CollectionsService SetUpdateAsyncConfig(RequestConfig config)
    {
        _updateAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>DeleteAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public CollectionsService SetDeleteAsyncConfig(RequestConfig config)
    {
        _deleteAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>AddVoiceAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public CollectionsService SetAddVoiceAsyncConfig(RequestConfig config)
    {
        _addVoiceAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>RemoveVoiceAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public CollectionsService SetRemoveVoiceAsyncConfig(RequestConfig config)
    {
        _removeVoiceAsyncConfig = config;
        return this;
    }

    /// <summary>Returns all the voice collections the user has access to, sorted by title.</summary>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.GetUserVoiceCollectionsResponseModel> ListAsync(
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        var resolvedConfig = GetResolvedConfig(_listAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Get, "v1/voices/collections")
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
        global::ElevenLabs.GetUserVoiceCollectionsResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.GetUserVoiceCollectionsResponseModel>(
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

    /// <summary>Creates a new voice collection. The caller becomes its admin.</summary>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.UserVoiceCollectionResponseModel> CreateAsync(
        global::ElevenLabs.Voices.BodyCreateVoiceCollectionV1VoicesCollectionsPost input,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));

        var resolvedConfig = GetResolvedConfig(_createAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Post, "v1/voices/collections")
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
        global::ElevenLabs.UserVoiceCollectionResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.UserVoiceCollectionResponseModel>(
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

    /// <summary>Returns a voice collection the user has access to.</summary>
    /// <param name="collectionId">Collection ID.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.UserVoiceCollectionResponseModel> GetAsync(
        string collectionId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (collectionId is null)
            throw new ArgumentNullException(nameof(collectionId));

        var resolvedConfig = GetResolvedConfig(_getAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Get, "v1/voices/collections/{collection_id}")
            .SetPathParameter("collection_id", collectionId)
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
        global::ElevenLabs.UserVoiceCollectionResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.UserVoiceCollectionResponseModel>(
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

    /// <summary>Updates the title and icon of a voice collection. Fields that are omitted are left unchanged. Requires editor access to the collection.</summary>
    /// <param name="collectionId">Collection ID.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.UserVoiceCollectionResponseModel> UpdateAsync(
        global::ElevenLabs.Voices.BodyUpdateVoiceCollectionV1VoicesCollectionsCollectionIdPatch input,
        string collectionId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));
        if (collectionId is null)
            throw new ArgumentNullException(nameof(collectionId));

        var resolvedConfig = GetResolvedConfig(_updateAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            new HttpMethod("PATCH"),
            "v1/voices/collections/{collection_id}"
        )
            .SetPathParameter("collection_id", collectionId)
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
        global::ElevenLabs.UserVoiceCollectionResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.UserVoiceCollectionResponseModel>(
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

    /// <summary>Deletes a voice collection. The voices in it are not deleted. Requires admin access to the collection.</summary>
    /// <param name="collectionId">Collection ID.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.DeleteUserVoiceCollectionResponseModel> DeleteAsync(
        string collectionId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (collectionId is null)
            throw new ArgumentNullException(nameof(collectionId));

        var resolvedConfig = GetResolvedConfig(_deleteAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Delete, "v1/voices/collections/{collection_id}")
            .SetPathParameter("collection_id", collectionId)
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
        global::ElevenLabs.DeleteUserVoiceCollectionResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.DeleteUserVoiceCollectionResponseModel>(
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

    /// <summary>Adds a voice to a voice collection. Adding a voice that is already in the collection succeeds without changes. Requires editor access to the collection.</summary>
    /// <param name="collectionId">Collection ID.</param>
    /// <param name="voiceId">Voice ID to be used, you can use https://api.elevenlabs.io/v1/voices to list all the available voices.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.AddVoiceToUserVoiceCollectionResponseModel> AddVoiceAsync(
        string collectionId,
        string voiceId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (collectionId is null)
            throw new ArgumentNullException(nameof(collectionId));
        if (voiceId is null)
            throw new ArgumentNullException(nameof(voiceId));

        var resolvedConfig = GetResolvedConfig(_addVoiceAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Post,
            "v1/voices/collections/{collection_id}/voice/{voice_id}"
        )
            .SetPathParameter("collection_id", collectionId)
            .SetPathParameter("voice_id", voiceId)
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
        global::ElevenLabs.AddVoiceToUserVoiceCollectionResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.AddVoiceToUserVoiceCollectionResponseModel>(
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

    /// <summary>Removes a voice from a voice collection. The voice itself is not deleted. Requires editor access to the collection.</summary>
    /// <param name="collectionId">Collection ID.</param>
    /// <param name="voiceId">Voice ID to be used, you can use https://api.elevenlabs.io/v1/voices to list all the available voices.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.RemoveVoiceFromUserVoiceCollectionResponseModel> RemoveVoiceAsync(
        string collectionId,
        string voiceId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (collectionId is null)
            throw new ArgumentNullException(nameof(collectionId));
        if (voiceId is null)
            throw new ArgumentNullException(nameof(voiceId));

        var resolvedConfig = GetResolvedConfig(_removeVoiceAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Delete,
            "v1/voices/collections/{collection_id}/voice/{voice_id}"
        )
            .SetPathParameter("collection_id", collectionId)
            .SetPathParameter("voice_id", voiceId)
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
        global::ElevenLabs.RemoveVoiceFromUserVoiceCollectionResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.RemoveVoiceFromUserVoiceCollectionResponseModel>(
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
