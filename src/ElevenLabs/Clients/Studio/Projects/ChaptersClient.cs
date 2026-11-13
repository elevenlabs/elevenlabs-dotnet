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
using ElevenLabs.Flows;
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

namespace ElevenLabs.Studio.Projects;

/// <summary>
/// Fern-shape client for ChaptersClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>IChaptersClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class ChaptersClient
{
    private readonly ChaptersService _service;

    internal ChaptersClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new ChaptersService(httpClient);
        Snapshots = new ElevenLabs.Studio.Projects.Chapters.SnapshotsClient(httpClient);
    }

    public ElevenLabs.Studio.Projects.Chapters.ISnapshotsClient Snapshots { get; }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public IChaptersClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IChaptersClient SetListAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetListAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CreateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IChaptersClient SetCreateAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetCreateAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IChaptersClient SetGetAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetGetAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>UpdateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IChaptersClient SetUpdateAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetUpdateAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>DeleteAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IChaptersClient SetDeleteAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetDeleteAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ConvertAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IChaptersClient SetConvertAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConvertAsyncConfig(config);
        return this;
    }

    /// <summary>Returns a list of a Studio project's chapters.</summary>
    public WithRawResponseTask<GetChaptersResponse> ListAsync(
        string projectId,
        ListChaptersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<GetChaptersResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.ListAsync(
                        projectId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Creates a new chapter either as blank or from a URL.</summary>
    public WithRawResponseTask<AddChapterResponseModel> CreateAsync(
        string projectId,
        CreateChaptersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<AddChapterResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.CreateAsync(
                        request.Body,
                        projectId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Returns information about a specific chapter.</summary>
    public WithRawResponseTask<ChapterWithContentResponseModel> GetAsync(
        string projectId,
        string chapterId,
        GetChaptersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<ChapterWithContentResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetAsync(
                        projectId,
                        chapterId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Updates a chapter.</summary>
    public WithRawResponseTask<EditChapterResponseModel> UpdateAsync(
        string projectId,
        string chapterId,
        UpdateChaptersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<EditChapterResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.UpdateAsync(
                        request.Body,
                        projectId,
                        chapterId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Deletes a chapter.</summary>
    public WithRawResponseTask<DeleteChapterResponseModel> DeleteAsync(
        string projectId,
        string chapterId,
        DeleteChaptersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<DeleteChapterResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.DeleteAsync(
                        projectId,
                        chapterId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Starts conversion of a specific chapter.</summary>
    public WithRawResponseTask<ConvertChapterResponseModel> ConvertAsync(
        string projectId,
        string chapterId,
        ConvertChaptersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<ConvertChapterResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.ConvertAsync(
                        projectId,
                        chapterId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
