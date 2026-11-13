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

namespace ElevenLabs.Flows.Templates;

/// <summary>
/// Fern-shape client for RunsClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>IRunsClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class RunsClient
{
    private readonly RunsService _service;

    internal RunsClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new RunsService(httpClient);
    }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public IRunsClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IRunsClient SetListAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetListAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CreateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IRunsClient SetCreateAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetCreateAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IRunsClient SetGetAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetGetAsyncConfig(config);
        return this;
    }

    /// <summary>List this template's runs created through this API, newest first.</summary>
    public WithRawResponseTask<TemplateRunListResponse> ListAsync(
        string templateId,
        ListRunsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<TemplateRunListResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.ListAsync(
                        templateId,
                        request.Cursor,
                        request.PageSize,
                        request.VersionId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Start a run of a flows template. Pass `version_id` to pin a snapshot, or omit it / pass `latest` to run the latest published version. Set input values under `inputs`, keyed by input port id. The response is the run in its initial state, with every output already listed under its port id in `outputs`. Include `webhook` to receive a `flows_template_run` event carrying the finished run once its `status` is `completed` or `failed`; this is the recommended way to wait. Without one, fetch `GET /v1/flows/templates/{template_id}/runs/{run_id}` at a modest interval until the `status` is terminal.</summary>
    public WithRawResponseTask<TemplateRunResponse> CreateAsync(
        string templateId,
        CreateRunsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<TemplateRunResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.CreateAsync(
                        request.Body,
                        templateId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Retrieve a template run: its `status`, rolled up from its outputs, and each output's own status and download URL once completed.</summary>
    public WithRawResponseTask<TemplateRunResponse> GetAsync(
        string templateId,
        string runId,
        GetRunsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<TemplateRunResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetAsync(
                        templateId,
                        runId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
