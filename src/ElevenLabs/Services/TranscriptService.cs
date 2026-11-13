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
/// Service class providing access to API endpoints for TranscriptService.
/// Inherits HTTP client management, JSON serialization, and streaming capabilities from the base service.
/// Each method corresponds to an API operation and handles request building, execution, and response parsing.
/// </summary>
internal class TranscriptService : BaseService
{
    private RequestConfig? _getAsyncConfig;
    private RequestConfig? _updateSegmentAsyncConfig;
    private RequestConfig? _deleteSegmentAsyncConfig;
    private RequestConfig? _updateSegmentsAsyncConfig;
    private RequestConfig? _createSegmentAsyncConfig;
    private RequestConfig? _getAsync1Config;
    private RequestConfig? _updateSegmentAsync1Config;
    private RequestConfig? _updateSegmentsAsync1Config;
    private RequestConfig? _regenerateAsyncConfig;

    internal TranscriptService(global::ElevenLabs.Http.Client httpClient)
        : base(httpClient) { }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public TranscriptService SetGetAsyncConfig(RequestConfig config)
    {
        _getAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>UpdateSegmentAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public TranscriptService SetUpdateSegmentAsyncConfig(RequestConfig config)
    {
        _updateSegmentAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>DeleteSegmentAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public TranscriptService SetDeleteSegmentAsyncConfig(RequestConfig config)
    {
        _deleteSegmentAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>UpdateSegmentsAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public TranscriptService SetUpdateSegmentsAsyncConfig(RequestConfig config)
    {
        _updateSegmentsAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CreateSegmentAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public TranscriptService SetCreateSegmentAsyncConfig(RequestConfig config)
    {
        _createSegmentAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync1</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public TranscriptService SetGetAsync1Config(RequestConfig config)
    {
        _getAsync1Config = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>UpdateSegmentAsync1</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public TranscriptService SetUpdateSegmentAsync1Config(RequestConfig config)
    {
        _updateSegmentAsync1Config = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>UpdateSegmentsAsync1</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public TranscriptService SetUpdateSegmentsAsync1Config(RequestConfig config)
    {
        _updateSegmentsAsync1Config = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>RegenerateAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public TranscriptService SetRegenerateAsyncConfig(RequestConfig config)
    {
        _regenerateAsyncConfig = config;
        return this;
    }

    /// <summary>The project's source transcript, as editable segments. Available once the project is `ready`.</summary>
    /// <param name="projectId">Identifier of the dubbing project.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.DubbingSourceTranscriptResponse> GetAsync(
        string projectId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (projectId is null)
            throw new ArgumentNullException(nameof(projectId));

        var resolvedConfig = GetResolvedConfig(_getAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Get,
            "v1/dubbing/project/{project_id}/transcript"
        )
            .SetPathParameter("project_id", projectId)
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
        global::ElevenLabs.DubbingSourceTranscriptResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.DubbingSourceTranscriptResponse>(
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

    /// <summary>Enterprise only. Edit a source segment's text, speaker, or timing. Omitted fields are left unchanged. Bumps the project's `revision`, discards the affected translations in every language target, and marks any target that had already completed `stale`. No audio changes until you regenerate a target.</summary>
    /// <param name="projectId">Identifier of the dubbing project.</param>
    /// <param name="segmentId">Identifier of the segment to edit.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.DubbingSourceSegmentUpdateResponse> UpdateSegmentAsync(
        global::ElevenLabs.Dubbing.Project.DubbingSegmentUpdateRequest input,
        string projectId,
        string segmentId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));
        if (projectId is null)
            throw new ArgumentNullException(nameof(projectId));
        if (segmentId is null)
            throw new ArgumentNullException(nameof(segmentId));

        var resolvedConfig = GetResolvedConfig(_updateSegmentAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            new HttpMethod("PATCH"),
            "v1/dubbing/project/{project_id}/transcript/segment/{segment_id}"
        )
            .SetPathParameter("project_id", projectId)
            .SetPathParameter("segment_id", segmentId)
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
        global::ElevenLabs.DubbingSourceSegmentUpdateResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.DubbingSourceSegmentUpdateResponse>(
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

    /// <summary>Enterprise only. Remove a source segment from the transcript so it is no longer dubbed. Bumps the project's `revision`, discards the affected translations in every language target, and marks any target that had already completed `stale`. No audio changes until you regenerate a target.</summary>
    /// <param name="projectId">Identifier of the dubbing project.</param>
    /// <param name="segmentId">Identifier of the segment to remove.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.DubbingTranscriptRevisionResponse> DeleteSegmentAsync(
        string projectId,
        string segmentId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (projectId is null)
            throw new ArgumentNullException(nameof(projectId));
        if (segmentId is null)
            throw new ArgumentNullException(nameof(segmentId));

        var resolvedConfig = GetResolvedConfig(_deleteSegmentAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Delete,
            "v1/dubbing/project/{project_id}/transcript/segment/{segment_id}"
        )
            .SetPathParameter("project_id", projectId)
            .SetPathParameter("segment_id", segmentId)
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
        global::ElevenLabs.DubbingTranscriptRevisionResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.DubbingTranscriptRevisionResponse>(
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

    /// <summary>Enterprise only. Edit several source segments' text, speaker, or timing in one atomic request: every edit applies or none does. Bumps the project's `revision`, discards the affected translations in every language target, and marks any target that had already completed `stale`. No audio changes until you regenerate a target.</summary>
    /// <param name="projectId">Identifier of the dubbing project.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.DubbingBulkSourceSegmentUpdateResponse> UpdateSegmentsAsync(
        global::ElevenLabs.Dubbing.Project.DubbingBulkSegmentUpdateRequest input,
        string projectId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));
        if (projectId is null)
            throw new ArgumentNullException(nameof(projectId));

        var resolvedConfig = GetResolvedConfig(_updateSegmentsAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            new HttpMethod("PATCH"),
            "v1/dubbing/project/{project_id}/transcript/segments"
        )
            .SetPathParameter("project_id", projectId)
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
        global::ElevenLabs.DubbingBulkSourceSegmentUpdateResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.DubbingBulkSourceSegmentUpdateResponse>(
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

    /// <summary>Enterprise only. Add a new source segment to the transcript. Its span must lie within the source media, last between 0.1 and 25 seconds, and not overlap another segment by the same speaker. Bumps the project's `revision`, discards the affected translations in every language target, and marks any target that had already completed `stale`. No audio changes until you regenerate a target.</summary>
    /// <param name="projectId">Identifier of the dubbing project.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.DubbingSourceSegmentUpdateResponse> CreateSegmentAsync(
        global::ElevenLabs.Dubbing.Project.DubbingSegmentCreateRequest input,
        string projectId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));
        if (projectId is null)
            throw new ArgumentNullException(nameof(projectId));

        var resolvedConfig = GetResolvedConfig(_createSegmentAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Post,
            "v1/dubbing/project/{project_id}/transcript/segment"
        )
            .SetPathParameter("project_id", projectId)
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
        global::ElevenLabs.DubbingSourceSegmentUpdateResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.DubbingSourceSegmentUpdateResponse>(
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

    /// <summary>A language target's transcript: source segments with their translations. Available once the target has produced an output. Returns a conflict while the target is still on its first dub, since it has no translations to return yet.</summary>
    /// <param name="projectId">Identifier of the dubbing project.</param>
    /// <param name="languageId">Identifier of the language target.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.DubbingTargetTranscriptResponse> GetAsync1(
        string projectId,
        string languageId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (projectId is null)
            throw new ArgumentNullException(nameof(projectId));
        if (languageId is null)
            throw new ArgumentNullException(nameof(languageId));

        var resolvedConfig = GetResolvedConfig(_getAsync1Config, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Get,
            "v1/dubbing/project/{project_id}/language/{language_id}/transcript"
        )
            .SetPathParameter("project_id", projectId)
            .SetPathParameter("language_id", languageId)
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
        global::ElevenLabs.DubbingTargetTranscriptResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.DubbingTargetTranscriptResponse>(
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

    /// <summary>Enterprise only. Edit a segment's translation for a language target. Omitted fields are left unchanged; an explicit null clears the field. Bumps the target's `revision` and marks it `stale` if it had already completed. The source transcript and the project's other languages are untouched, and no audio changes until you regenerate the target.</summary>
    /// <param name="projectId">Identifier of the dubbing project.</param>
    /// <param name="languageId">Identifier of the language target.</param>
    /// <param name="segmentId">Identifier of the segment to edit.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.DubbingTargetSegmentUpdateResponse> UpdateSegmentAsync1(
        global::ElevenLabs.Dubbing.Project.Language.DubbingTargetSegmentUpdateRequest input,
        string projectId,
        string languageId,
        string segmentId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));
        if (projectId is null)
            throw new ArgumentNullException(nameof(projectId));
        if (languageId is null)
            throw new ArgumentNullException(nameof(languageId));
        if (segmentId is null)
            throw new ArgumentNullException(nameof(segmentId));

        var resolvedConfig = GetResolvedConfig(_updateSegmentAsync1Config, requestConfig);

        var request = new RequestBuilder(
            new HttpMethod("PATCH"),
            "v1/dubbing/project/{project_id}/language/{language_id}/transcript/segment/{segment_id}"
        )
            .SetPathParameter("project_id", projectId)
            .SetPathParameter("language_id", languageId)
            .SetPathParameter("segment_id", segmentId)
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
        global::ElevenLabs.DubbingTargetSegmentUpdateResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.DubbingTargetSegmentUpdateResponse>(
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

    /// <summary>Enterprise only. Edit several segments' translations for a language target in one atomic request: every edit applies or none does. Bumps the target's `revision` and marks it `stale` if it had already completed. The source transcript and the project's other languages are untouched, and no audio changes until you regenerate the target.</summary>
    /// <param name="projectId">Identifier of the dubbing project.</param>
    /// <param name="languageId">Identifier of the language target.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.DubbingBulkTargetSegmentUpdateResponse> UpdateSegmentsAsync1(
        global::ElevenLabs.Dubbing.Project.Language.DubbingBulkTargetSegmentUpdateRequest input,
        string projectId,
        string languageId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));
        if (projectId is null)
            throw new ArgumentNullException(nameof(projectId));
        if (languageId is null)
            throw new ArgumentNullException(nameof(languageId));

        var resolvedConfig = GetResolvedConfig(_updateSegmentsAsync1Config, requestConfig);

        var request = new RequestBuilder(
            new HttpMethod("PATCH"),
            "v1/dubbing/project/{project_id}/language/{language_id}/transcript/segments"
        )
            .SetPathParameter("project_id", projectId)
            .SetPathParameter("language_id", languageId)
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
        global::ElevenLabs.DubbingBulkTargetSegmentUpdateResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.DubbingBulkTargetSegmentUpdateResponse>(
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

    /// <summary>Enterprise only. Re-dub a target from its edited transcript, re-synthesizing only the edited regions (charged like a generation, less the free-regeneration allowance). Accepted asynchronously: the target returns to `processing` and sends a `dubbing_language_completed` event to the project's `webhook_ids` when the re-dub lands, carrying the new output URLs. Returns a conflict when the target has no edits to apply — nothing is dispatched and nothing is charged.</summary>
    /// <param name="projectId">Identifier of the dubbing project.</param>
    /// <param name="languageId">Identifier of the language target.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.DubbingRegenerateResponse> RegenerateAsync(
        string projectId,
        string languageId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (projectId is null)
            throw new ArgumentNullException(nameof(projectId));
        if (languageId is null)
            throw new ArgumentNullException(nameof(languageId));

        var resolvedConfig = GetResolvedConfig(_regenerateAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Post,
            "v1/dubbing/project/{project_id}/language/{language_id}/transcript/regenerate"
        )
            .SetPathParameter("project_id", projectId)
            .SetPathParameter("language_id", languageId)
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
        global::ElevenLabs.DubbingRegenerateResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.DubbingRegenerateResponse>(
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
