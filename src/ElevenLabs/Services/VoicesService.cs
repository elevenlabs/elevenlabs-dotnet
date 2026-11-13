using System.Net.Http.Headers;
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
/// Service class providing access to API endpoints for VoicesService.
/// Inherits HTTP client management, JSON serialization, and streaming capabilities from the base service.
/// Each method corresponds to an API operation and handles request building, execution, and response parsing.
/// </summary>
internal class VoicesService : BaseService
{
    private RequestConfig? _getAsyncConfig;
    private RequestConfig? _deleteAsyncConfig;
    private RequestConfig? _updateAsyncConfig;
    private RequestConfig? _searchAsyncConfig;
    private RequestConfig? _replicateToIsolatedEnvironmentAsyncConfig;
    private RequestConfig? _shareAsyncConfig;
    private RequestConfig? _findSimilarVoicesAsyncConfig;
    private RequestConfig? _getSharedAsyncConfig;

    internal VoicesService(global::ElevenLabs.Http.Client httpClient)
        : base(httpClient) { }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public VoicesService SetGetAsyncConfig(RequestConfig config)
    {
        _getAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>DeleteAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public VoicesService SetDeleteAsyncConfig(RequestConfig config)
    {
        _deleteAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>UpdateAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public VoicesService SetUpdateAsyncConfig(RequestConfig config)
    {
        _updateAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>SearchAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public VoicesService SetSearchAsyncConfig(RequestConfig config)
    {
        _searchAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ReplicateToIsolatedEnvironmentAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public VoicesService SetReplicateToIsolatedEnvironmentAsyncConfig(RequestConfig config)
    {
        _replicateToIsolatedEnvironmentAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ShareAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public VoicesService SetShareAsyncConfig(RequestConfig config)
    {
        _shareAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>FindSimilarVoicesAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public VoicesService SetFindSimilarVoicesAsyncConfig(RequestConfig config)
    {
        _findSimilarVoicesAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetSharedAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public VoicesService SetGetSharedAsyncConfig(RequestConfig config)
    {
        _getSharedAsyncConfig = config;
        return this;
    }

    /// <summary>Returns metadata about a specific voice.</summary>
    /// <param name="voiceId">ID of the voice to be used. You can use the [Get voices](/docs/api-reference/voices/search) endpoint list all the available voices.</param>
    /// <param name="withSettings">This parameter is now deprecated. It is ignored and will be removed in a future version.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.Voice> GetAsync(
        string voiceId,
        bool? withSettings = true,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (voiceId is null)
            throw new ArgumentNullException(nameof(voiceId));

        var resolvedConfig = GetResolvedConfig(_getAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Get, "v1/voices/{voice_id}")
            .SetPathParameter("voice_id", voiceId)
            .SetOptionalQueryParameter("with_settings", withSettings)
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
        global::ElevenLabs.Voice result;
        try
        {
            result = global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.Voice>(
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

    /// <summary>Deletes a voice by its ID.</summary>
    /// <param name="voiceId">ID of the voice to be used. You can use the [Get voices](/docs/api-reference/voices/search) endpoint list all the available voices.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.DeleteVoiceResponseModel> DeleteAsync(
        string voiceId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (voiceId is null)
            throw new ArgumentNullException(nameof(voiceId));

        var resolvedConfig = GetResolvedConfig(_deleteAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Delete, "v1/voices/{voice_id}")
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
        global::ElevenLabs.DeleteVoiceResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.DeleteVoiceResponseModel>(
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

    /// <summary>Edit a voice created by you.</summary>
    /// <param name="voiceId">ID of the voice to be used. You can use the [Get voices](/docs/api-reference/voices/search) endpoint list all the available voices.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.EditVoiceResponseModel> UpdateAsync(
        global::ElevenLabs.EditVoiceRequest input,
        string voiceId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));
        if (voiceId is null)
            throw new ArgumentNullException(nameof(voiceId));

        var resolvedConfig = GetResolvedConfig(_updateAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Post, "v1/voices/{voice_id}/edit")
            .SetPathParameter("voice_id", voiceId)
            .SetOptionalHeader("xi-api-key", xiApiKey)
            .SetContentAsMultipartFormData(input, _jsonSerializerOptions)
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
        global::ElevenLabs.EditVoiceResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.EditVoiceResponseModel>(
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

    /// <summary>Gets a list of all available voices for a user with search, filtering and pagination.</summary>
    /// <param name="nextPageToken">The next page token to use for pagination. Returned from the previous request. Use this in combination with the has_more flag for reliable pagination.</param>
    /// <param name="pageSize">How many voices to return at maximum. Can not exceed 100, defaults to 10. Page 0 may include more voices due to default voices being included.</param>
    /// <param name="search">Search term to filter voices by. Searches in name, description, labels, category.</param>
    /// <param name="sort">Which field to sort by, one of 'created_at_unix' or 'name'. 'created_at_unix' may not be available for older voices.</param>
    /// <param name="sortDirection">Which direction to sort the voices in. 'asc' or 'desc'.</param>
    /// <param name="voiceType">Type of the voice to filter by. One of 'personal', 'community', 'default', 'workspace', 'non-default', 'non-community', 'saved'. 'non-default' is equal to all but 'default'. 'non-community' is equal to 'personal' and 'workspace' combined (excludes library copies). 'saved' is equal to non-default, but includes default voices if they have been added to a collection.</param>
    /// <param name="category">Category of the voice to filter by. One of 'premade', 'cloned', 'generated', 'professional'</param>
    /// <param name="fineTuningState">State of the voice's fine tuning to filter by. Applicable only to professional voices clones. One of 'draft', 'not_verified', 'not_started', 'queued', 'fine_tuning', 'fine_tuned', 'failed', 'delayed'</param>
    /// <param name="collectionId">Collection ID to filter voices by.</param>
    /// <param name="gender">Gender used for filtering, based on the voice's 'gender' label.</param>
    /// <param name="age">Age used for filtering, based on the voice's 'age' label.</param>
    /// <param name="language">Languages used for filtering, based on the voice's 'language' label. Voices matching any of the given languages are returned.</param>
    /// <param name="accent">Accent used for filtering, based on the voice's 'accent' label.</param>
    /// <param name="useCases">Use cases used for filtering, based on the voice's 'use_case' label. Voices matching any of the given use cases are returned.</param>
    /// <param name="minNoticePeriodDays">Filter to voices whose sharing notice period is at least the given number of days.</param>
    /// <param name="includeCustomRates">Whether to include voices that have a custom sharing rate. Defaults to including them.</param>
    /// <param name="includeLiveModerated">Whether to include voices that have live moderation enabled. Defaults to including them.</param>
    /// <param name="highQuality">When true, only return studio-quality voices (those whose category is 'high_quality').</param>
    /// <param name="includeTotalCount">Whether to include the total count of voices found in the response. NOTE: The total_count value is a live snapshot and may change between requests as users create, modify, or delete voices. For pagination, rely on the has_more flag instead. Only enable this when you actually need the total count (e.g., for display purposes), as it incurs a performance cost.</param>
    /// <param name="voiceIds">Voice IDs to lookup by. Maximum 100 voice IDs.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.GetVoicesV2Response> SearchAsync(
        string? nextPageToken = null,
        long? pageSize = 10,
        string? search = null,
        string? sort = null,
        string? sortDirection = null,
        string? voiceType = null,
        string? category = null,
        string? fineTuningState = null,
        string? collectionId = null,
        string? gender = null,
        string? age = null,
        List<string>? language = null,
        string? accent = null,
        List<string>? useCases = null,
        long? minNoticePeriodDays = null,
        bool? includeCustomRates = null,
        bool? includeLiveModerated = null,
        bool? highQuality = null,
        bool? includeTotalCount = true,
        List<string>? voiceIds = null,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        var resolvedConfig = GetResolvedConfig(_searchAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Get, "v2/voices")
            .SetOptionalQueryParameter("next_page_token", nextPageToken)
            .SetOptionalQueryParameter("page_size", pageSize)
            .SetOptionalQueryParameter("search", search)
            .SetOptionalQueryParameter("sort", sort)
            .SetOptionalQueryParameter("sort_direction", sortDirection)
            .SetOptionalQueryParameter("voice_type", voiceType)
            .SetOptionalQueryParameter("category", category)
            .SetOptionalQueryParameter("fine_tuning_state", fineTuningState)
            .SetOptionalQueryParameter("collection_id", collectionId)
            .SetOptionalQueryParameter("gender", gender)
            .SetOptionalQueryParameter("age", age)
            .SetOptionalQueryParameter("language", language)
            .SetOptionalQueryParameter("accent", accent)
            .SetOptionalQueryParameter("use_cases", useCases)
            .SetOptionalQueryParameter("min_notice_period_days", minNoticePeriodDays)
            .SetOptionalQueryParameter("include_custom_rates", includeCustomRates)
            .SetOptionalQueryParameter("include_live_moderated", includeLiveModerated)
            .SetOptionalQueryParameter("high_quality", highQuality)
            .SetOptionalQueryParameter("include_total_count", includeTotalCount)
            .SetOptionalQueryParameter("voice_ids", voiceIds)
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
        global::ElevenLabs.GetVoicesV2Response result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.GetVoicesV2Response>(
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

    /// <summary>Replicates an Instant Voice Clone or Voice Design voice to a workspace in a different data residency. The target workspace must belong to the same consolidated billing group. The user must have VOICES_WRITE in the source workspace, and be an admin on the source voice. Human users (i.e. not service accounts) must also have VOICES_WRITE in the target workspace. This endpoint is available on the central environment only.</summary>
    /// <param name="voiceId">Voice ID to be used, you can use https://api.elevenlabs.io/v1/voices to list all the available voices.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.ReplicateVoiceToIsolatedEnvironmentResponseModel> ReplicateToIsolatedEnvironmentAsync(
        global::ElevenLabs.ReplicateVoiceToIsolatedEnvironmentRequestModel input,
        string voiceId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));
        if (voiceId is null)
            throw new ArgumentNullException(nameof(voiceId));

        var resolvedConfig = GetResolvedConfig(
            _replicateToIsolatedEnvironmentAsyncConfig,
            requestConfig
        );

        var request = new RequestBuilder(
            HttpMethod.Post,
            "v1/voices/{voice_id}/replicate-to-isolated-environment"
        )
            .SetPathParameter("voice_id", voiceId)
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
        global::ElevenLabs.ReplicateVoiceToIsolatedEnvironmentResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.ReplicateVoiceToIsolatedEnvironmentResponseModel>(
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

    /// <summary>Add a shared voice to your collection of Voices</summary>
    /// <param name="publicUserId">Public user ID used to publicly identify ElevenLabs users.</param>
    /// <param name="voiceId">ID of the voice to be used. You can use the [Get voices](/docs/api-reference/voices/search) endpoint list all the available voices.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.AddVoiceResponseModel> ShareAsync(
        global::ElevenLabs.BodyAddSharedVoiceV1VoicesAddPublicUserIdVoiceIdPost input,
        string publicUserId,
        string voiceId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));
        if (publicUserId is null)
            throw new ArgumentNullException(nameof(publicUserId));
        if (voiceId is null)
            throw new ArgumentNullException(nameof(voiceId));

        var resolvedConfig = GetResolvedConfig(_shareAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Post,
            "v1/voices/add/{public_user_id}/{voice_id}"
        )
            .SetPathParameter("public_user_id", publicUserId)
            .SetPathParameter("voice_id", voiceId)
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
        global::ElevenLabs.AddVoiceResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.AddVoiceResponseModel>(
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

    /// <summary>Returns a list of shared voices similar to the provided audio sample. If neither similarity_threshold nor top_k is provided, we will apply default values.</summary>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.GetLibraryVoicesResponse> FindSimilarVoicesAsync(
        global::ElevenLabs.ListSimilarVoicesRequest input,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));

        var resolvedConfig = GetResolvedConfig(_findSimilarVoicesAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Post, "v1/similar-voices")
            .SetOptionalHeader("xi-api-key", xiApiKey)
            .SetContentAsMultipartFormData(input, _jsonSerializerOptions)
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
        global::ElevenLabs.GetLibraryVoicesResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.GetLibraryVoicesResponse>(
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

    /// <summary>Retrieves a list of shared voices.</summary>
    /// <param name="pageSize">How many shared voices to return at maximum. Can not exceed 100, defaults to 30.</param>
    /// <param name="category">Voice category used for filtering</param>
    /// <param name="gender">Gender used for filtering</param>
    /// <param name="age">Age used for filtering</param>
    /// <param name="accent">Accent used for filtering</param>
    /// <param name="language">Language used for filtering</param>
    /// <param name="locale">Locale used for filtering</param>
    /// <param name="search">Search term used for filtering</param>
    /// <param name="useCases">Use-case used for filtering</param>
    /// <param name="descriptives">Search term used for filtering</param>
    /// <param name="featured">Filter featured voices</param>
    /// <param name="minNoticePeriodDays">Filter voices with a minimum notice period of the given number of days.</param>
    /// <param name="includeCustomRates">Include/exclude voices with custom rates</param>
    /// <param name="includeLiveModerated">Include/exclude voices that are live moderated</param>
    /// <param name="readerAppEnabled">Filter voices that are enabled for the reader app</param>
    /// <param name="ownerId">Filter voices by public owner ID</param>
    /// <param name="sort">Sort criteria. Must be one of: created_date, usage_character_count_1y, trending, cloned_by_count.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.GetLibraryVoicesResponse> GetSharedAsync(
        long? pageSize = 30,
        global::ElevenLabs.GetSharedVoicesRequestCategory? category = null,
        string? gender = null,
        string? age = null,
        string? accent = null,
        string? language = null,
        string? locale = null,
        string? search = null,
        List<string>? useCases = null,
        List<string>? descriptives = null,
        bool? featured = false,
        long? minNoticePeriodDays = null,
        bool? includeCustomRates = null,
        bool? includeLiveModerated = null,
        bool? readerAppEnabled = false,
        string? ownerId = null,
        global::ElevenLabs.GetSharedVoicesRequestSort? sort = null,
        long? page = 0,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        var resolvedConfig = GetResolvedConfig(_getSharedAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Get, "v1/shared-voices")
            .SetOptionalQueryParameter("page_size", pageSize)
            .SetOptionalQueryParameter("category", category?.Value)
            .SetOptionalQueryParameter("gender", gender)
            .SetOptionalQueryParameter("age", age)
            .SetOptionalQueryParameter("accent", accent)
            .SetOptionalQueryParameter("language", language)
            .SetOptionalQueryParameter("locale", locale)
            .SetOptionalQueryParameter("search", search)
            .SetOptionalQueryParameter("use_cases", useCases)
            .SetOptionalQueryParameter("descriptives", descriptives)
            .SetOptionalQueryParameter("featured", featured)
            .SetOptionalQueryParameter("min_notice_period_days", minNoticePeriodDays)
            .SetOptionalQueryParameter("include_custom_rates", includeCustomRates)
            .SetOptionalQueryParameter("include_live_moderated", includeLiveModerated)
            .SetOptionalQueryParameter("reader_app_enabled", readerAppEnabled)
            .SetOptionalQueryParameter("owner_id", ownerId)
            .SetOptionalQueryParameter("sort", sort?.Value)
            .SetOptionalQueryParameter("page", page)
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
        global::ElevenLabs.GetLibraryVoicesResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.GetLibraryVoicesResponse>(
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
