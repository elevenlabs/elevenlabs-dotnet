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
using ElevenLabs.Core;
using ElevenLabs.Dubbing;
using ElevenLabs.Dubbing.Project;
using ElevenLabs.Dubbing.Project.Language;
using ElevenLabs.EnvironmentVariables;
using ElevenLabs.Flows.Templates;
using ElevenLabs.History;
using ElevenLabs.Music;
using ElevenLabs.Productions;
using ElevenLabs.Productions.Orders;
using ElevenLabs.PronunciationDictionaries;
using ElevenLabs.ServiceAccounts;
using ElevenLabs.Services;
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
using global::System.Linq;
using global::System.Threading;
using OneOf;

namespace ElevenLabs.Flows;

/// <summary>
/// Fern-shape client for ImageClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>IImageClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class ImageClient
{
    private readonly ImageService _service;

    internal ImageClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new ImageService(httpClient);
    }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public IImageClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IImageClient SetListAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetListAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CreateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IImageClient SetCreateAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetCreateAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IImageClient SetGetAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetGetAsyncConfig(config);
        return this;
    }

    /// <summary>List the image generations created through this API, newest first.</summary>
    public WithRawResponseTask<MediaGenerationListResponse> ListAsync(
        ListImageRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<MediaGenerationListResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.ListAsync(
                        request.Cursor,
                        request.PageSize,
                        request.Status,
                        request.ModelId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Start an image generation with the selected model.</summary>
    public WithRawResponseTask<MediaGenerationCreateResponse> CreateAsync(
        CreateImageRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<MediaGenerationCreateResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    request.Body.Match(
                        value =>
                            _service.CreateAsync(
                                value,
                                request.XiApiKey,
                                cancellationToken: cancellationToken
                            ),
                        value =>
                            _service.CreateAsync(
                                value,
                                request.XiApiKey,
                                cancellationToken: cancellationToken
                            ),
                        value =>
                            _service.CreateAsync(
                                value,
                                request.XiApiKey,
                                cancellationToken: cancellationToken
                            ),
                        value =>
                            _service.CreateAsync(
                                value,
                                request.XiApiKey,
                                cancellationToken: cancellationToken
                            ),
                        value =>
                            _service.CreateAsync(
                                value,
                                request.XiApiKey,
                                cancellationToken: cancellationToken
                            ),
                        value =>
                            _service.CreateAsync(
                                value,
                                request.XiApiKey,
                                cancellationToken: cancellationToken
                            ),
                        value =>
                            _service.CreateAsync(
                                value,
                                request.XiApiKey,
                                cancellationToken: cancellationToken
                            ),
                        value =>
                            _service.CreateAsync(
                                value,
                                request.XiApiKey,
                                cancellationToken: cancellationToken
                            ),
                        value =>
                            _service.CreateAsync(
                                value,
                                request.XiApiKey,
                                cancellationToken: cancellationToken
                            ),
                        value =>
                            _service.CreateAsync(
                                value,
                                request.XiApiKey,
                                cancellationToken: cancellationToken
                            ),
                        value =>
                            _service.CreateAsync(
                                value,
                                request.XiApiKey,
                                cancellationToken: cancellationToken
                            ),
                        (discriminant, _) =>
                            throw new global::System.ArgumentException(
                                $"Unknown discriminant '{discriminant}'"
                            )
                    )
            )
        );

    /// <summary>Retrieve the status of an image generation, and retrieve its output URL once completed.</summary>
    public WithRawResponseTask<MediaGenerationResponse> GetAsync(
        string generationId,
        GetImageRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<MediaGenerationResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetAsync(
                        generationId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
