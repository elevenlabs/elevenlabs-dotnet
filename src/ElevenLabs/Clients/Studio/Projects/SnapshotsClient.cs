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
/// Fern-shape client for SnapshotsClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>ISnapshotsClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class SnapshotsClient
{
    private readonly SnapshotsService _service;

    internal SnapshotsClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new SnapshotsService(httpClient);
    }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public ISnapshotsClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ISnapshotsClient SetListAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetListAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ISnapshotsClient SetGetAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetGetAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>StreamAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ISnapshotsClient SetStreamAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetStreamAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>StreamArchiveAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ISnapshotsClient SetStreamArchiveAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetStreamArchiveAsyncConfig(config);
        return this;
    }

    /// <summary>Retrieves a list of snapshots for a Studio project.</summary>
    public WithRawResponseTask<ProjectSnapshotsResponse> ListAsync(
        string projectId,
        ListSnapshotsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<ProjectSnapshotsResponse>(
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

    /// <summary>Returns the project snapshot.</summary>
    public WithRawResponseTask<ProjectSnapshotExtendedResponseModel> GetAsync(
        string projectId,
        string projectSnapshotId,
        GetSnapshotsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<ProjectSnapshotExtendedResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetAsync(
                        projectId,
                        projectSnapshotId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Stream the audio from a Studio project snapshot.</summary>
    public WithRawResponseTask<global::System.IO.Stream> StreamAsync(
        string projectId,
        string projectSnapshotId,
        StreamSnapshotsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<global::System.IO.Stream>(
            WithRawResponseAdapter.WrapStream(
                options,
                () =>
                    _service.StreamAsync(
                        request.Body,
                        projectId,
                        projectSnapshotId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Returns a compressed archive of the Studio project's audio.</summary>
    public WithRawResponseTask<global::System.IO.Stream> StreamArchiveAsync(
        string projectId,
        string projectSnapshotId,
        StreamArchiveSnapshotsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<global::System.IO.Stream>(
            WithRawResponseAdapter.WrapStream(
                options,
                () =>
                    _service.StreamArchiveAsync(
                        projectId,
                        projectSnapshotId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
