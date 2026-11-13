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
/// Service class providing access to API endpoints for SnapshotsService.
/// Inherits HTTP client management, JSON serialization, and streaming capabilities from the base service.
/// Each method corresponds to an API operation and handles request building, execution, and response parsing.
/// </summary>
internal class SnapshotsService : BaseService
{
    private RequestConfig? _listAsyncConfig;
    private RequestConfig? _getAsyncConfig;
    private RequestConfig? _streamAsyncConfig;
    private RequestConfig? _streamArchiveAsyncConfig;
    private RequestConfig? _listAsync1Config;
    private RequestConfig? _getAsync1Config;
    private RequestConfig? _streamAsync1Config;

    internal SnapshotsService(global::ElevenLabs.Http.Client httpClient)
        : base(httpClient) { }

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public SnapshotsService SetListAsyncConfig(RequestConfig config)
    {
        _listAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public SnapshotsService SetGetAsyncConfig(RequestConfig config)
    {
        _getAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>StreamAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public SnapshotsService SetStreamAsyncConfig(RequestConfig config)
    {
        _streamAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>StreamArchiveAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public SnapshotsService SetStreamArchiveAsyncConfig(RequestConfig config)
    {
        _streamArchiveAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync1</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public SnapshotsService SetListAsync1Config(RequestConfig config)
    {
        _listAsync1Config = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync1</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public SnapshotsService SetGetAsync1Config(RequestConfig config)
    {
        _getAsync1Config = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>StreamAsync1</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public SnapshotsService SetStreamAsync1Config(RequestConfig config)
    {
        _streamAsync1Config = config;
        return this;
    }

    /// <summary>Retrieves a list of snapshots for a Studio project.</summary>
    /// <param name="projectId">The ID of the Studio project.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.ProjectSnapshotsResponse> ListAsync(
        string projectId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (projectId is null)
            throw new ArgumentNullException(nameof(projectId));

        var resolvedConfig = GetResolvedConfig(_listAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Get,
            "v1/studio/projects/{project_id}/snapshots"
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
        global::ElevenLabs.ProjectSnapshotsResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.ProjectSnapshotsResponse>(
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

    /// <summary>Returns the project snapshot.</summary>
    /// <param name="projectId">The ID of the Studio project.</param>
    /// <param name="projectSnapshotId">The ID of the Studio project snapshot.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.ProjectSnapshotExtendedResponseModel> GetAsync(
        string projectId,
        string projectSnapshotId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (projectId is null)
            throw new ArgumentNullException(nameof(projectId));
        if (projectSnapshotId is null)
            throw new ArgumentNullException(nameof(projectSnapshotId));

        var resolvedConfig = GetResolvedConfig(_getAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Get,
            "v1/studio/projects/{project_id}/snapshots/{project_snapshot_id}"
        )
            .SetPathParameter("project_id", projectId)
            .SetPathParameter("project_snapshot_id", projectSnapshotId)
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
        global::ElevenLabs.ProjectSnapshotExtendedResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.ProjectSnapshotExtendedResponseModel>(
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

    /// <summary>Stream the audio from a Studio project snapshot.</summary>
    /// <param name="projectId">The ID of the project to be used. You can use the [List projects](/docs/api-reference/studio/get-projects) endpoint to list all the available projects.</param>
    /// <param name="projectSnapshotId">The ID of the Studio project snapshot.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::System.IO.Stream> StreamAsync(
        global::ElevenLabs.Studio.Projects.BodyStreamStudioProjectAudioV1StudioProjectsProjectIdSnapshotsProjectSnapshotIdStreamPost input,
        string projectId,
        string projectSnapshotId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));
        if (projectId is null)
            throw new ArgumentNullException(nameof(projectId));
        if (projectSnapshotId is null)
            throw new ArgumentNullException(nameof(projectSnapshotId));

        var resolvedConfig = GetResolvedConfig(_streamAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Post,
            "v1/studio/projects/{project_id}/snapshots/{project_snapshot_id}/stream"
        )
            .SetPathParameter("project_id", projectId)
            .SetPathParameter("project_snapshot_id", projectSnapshotId)
            .SetOptionalHeader("xi-api-key", xiApiKey)
            .SetContentAsJson(input, _jsonSerializerOptions)
            .Build();

        var response = await ExecuteDownloadAsync(request, resolvedConfig, cancellationToken)
            .ConfigureAwait(false);

        // Open the response body as a live stream
        global::System.IO.Stream result = await global::ElevenLabs
            .Core.ResponseBodyStream.OpenAsync(response, cancellationToken)
            .ConfigureAwait(false);

        return result;
    }

    /// <summary>Returns a compressed archive of the Studio project's audio.</summary>
    /// <param name="projectId">The ID of the project to be used. You can use the [List projects](/docs/api-reference/studio/get-projects) endpoint to list all the available projects.</param>
    /// <param name="projectSnapshotId">The ID of the Studio project snapshot.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::System.IO.Stream> StreamArchiveAsync(
        string projectId,
        string projectSnapshotId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (projectId is null)
            throw new ArgumentNullException(nameof(projectId));
        if (projectSnapshotId is null)
            throw new ArgumentNullException(nameof(projectSnapshotId));

        var resolvedConfig = GetResolvedConfig(_streamArchiveAsyncConfig, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Post,
            "v1/studio/projects/{project_id}/snapshots/{project_snapshot_id}/archive"
        )
            .SetPathParameter("project_id", projectId)
            .SetPathParameter("project_snapshot_id", projectSnapshotId)
            .SetOptionalHeader("xi-api-key", xiApiKey)
            .Build();

        var response = await ExecuteDownloadAsync(request, resolvedConfig, cancellationToken)
            .ConfigureAwait(false);

        // Open the response body as a live stream
        global::System.IO.Stream result = await global::ElevenLabs
            .Core.ResponseBodyStream.OpenAsync(response, cancellationToken)
            .ConfigureAwait(false);

        return result;
    }

    /// <summary>Gets information about all the snapshots of a chapter. Each snapshot can be downloaded as audio. Whenever a chapter is converted a snapshot will automatically be created.</summary>
    /// <param name="projectId">The ID of the project to be used. You can use the [List projects](/docs/api-reference/studio/get-projects) endpoint to list all the available projects.</param>
    /// <param name="chapterId">The ID of the chapter to be used. You can use the [List project chapters](/docs/api-reference/studio/get-chapters) endpoint to list all the available chapters.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.ChapterSnapshotsResponse> ListAsync1(
        string projectId,
        string chapterId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (projectId is null)
            throw new ArgumentNullException(nameof(projectId));
        if (chapterId is null)
            throw new ArgumentNullException(nameof(chapterId));

        var resolvedConfig = GetResolvedConfig(_listAsync1Config, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Get,
            "v1/studio/projects/{project_id}/chapters/{chapter_id}/snapshots"
        )
            .SetPathParameter("project_id", projectId)
            .SetPathParameter("chapter_id", chapterId)
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
        global::ElevenLabs.ChapterSnapshotsResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.ChapterSnapshotsResponse>(
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

    /// <summary>Returns the chapter snapshot.</summary>
    /// <param name="projectId">The ID of the Studio project.</param>
    /// <param name="chapterId">The ID of the chapter.</param>
    /// <param name="chapterSnapshotId">The ID of the chapter snapshot.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::ElevenLabs.ChapterSnapshotExtendedResponseModel> GetAsync1(
        string projectId,
        string chapterId,
        string chapterSnapshotId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (projectId is null)
            throw new ArgumentNullException(nameof(projectId));
        if (chapterId is null)
            throw new ArgumentNullException(nameof(chapterId));
        if (chapterSnapshotId is null)
            throw new ArgumentNullException(nameof(chapterSnapshotId));

        var resolvedConfig = GetResolvedConfig(_getAsync1Config, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Get,
            "v1/studio/projects/{project_id}/chapters/{chapter_id}/snapshots/{chapter_snapshot_id}"
        )
            .SetPathParameter("project_id", projectId)
            .SetPathParameter("chapter_id", chapterId)
            .SetPathParameter("chapter_snapshot_id", chapterSnapshotId)
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
        global::ElevenLabs.ChapterSnapshotExtendedResponseModel result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::ElevenLabs.ChapterSnapshotExtendedResponseModel>(
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

    /// <summary>Stream the audio from a chapter snapshot. Use `GET /v1/studio/projects/{project_id}/chapters/{chapter_id}/snapshots` to return the snapshots of a chapter.</summary>
    /// <param name="projectId">The ID of the project to be used. You can use the [List projects](/docs/api-reference/studio/get-projects) endpoint to list all the available projects.</param>
    /// <param name="chapterId">The ID of the chapter to be used. You can use the [List project chapters](/docs/api-reference/studio/get-chapters) endpoint to list all the available chapters.</param>
    /// <param name="chapterSnapshotId">The ID of the chapter snapshot to be used. You can use the [List project chapter snapshots](/docs/api-reference/studio/get-snapshots) endpoint to list all the available snapshots.</param>
    /// <param name="xiApiKey">Your API key. This is required by most endpoints to access our API programmatically. You can view your xi-api-key using the 'Profile' tab on the website.</param>
    public async global::System.Threading.Tasks.Task<global::System.IO.Stream> StreamAsync1(
        global::ElevenLabs.Studio.Projects.Chapters.BodyStreamChapterAudioV1StudioProjectsProjectIdChaptersChapterIdSnapshotsChapterSnapshotIdStreamPost input,
        string projectId,
        string chapterId,
        string chapterSnapshotId,
        string? xiApiKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));
        if (projectId is null)
            throw new ArgumentNullException(nameof(projectId));
        if (chapterId is null)
            throw new ArgumentNullException(nameof(chapterId));
        if (chapterSnapshotId is null)
            throw new ArgumentNullException(nameof(chapterSnapshotId));

        var resolvedConfig = GetResolvedConfig(_streamAsync1Config, requestConfig);

        var request = new RequestBuilder(
            HttpMethod.Post,
            "v1/studio/projects/{project_id}/chapters/{chapter_id}/snapshots/{chapter_snapshot_id}/stream"
        )
            .SetPathParameter("project_id", projectId)
            .SetPathParameter("chapter_id", chapterId)
            .SetPathParameter("chapter_snapshot_id", chapterSnapshotId)
            .SetOptionalHeader("xi-api-key", xiApiKey)
            .SetContentAsJson(input, _jsonSerializerOptions)
            .Build();

        var response = await ExecuteDownloadAsync(request, resolvedConfig, cancellationToken)
            .ConfigureAwait(false);

        // Open the response body as a live stream
        global::System.IO.Stream result = await global::ElevenLabs
            .Core.ResponseBodyStream.OpenAsync(response, cancellationToken)
            .ConfigureAwait(false);

        return result;
    }
}
