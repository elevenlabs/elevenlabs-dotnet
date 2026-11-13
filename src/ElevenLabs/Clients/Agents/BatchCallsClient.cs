using ElevenLabs;
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

namespace ElevenLabs.Agents;

/// <summary>
/// Fern-shape client for BatchCallsClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>IBatchCallsClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class BatchCallsClient
{
    private readonly BatchCallsService _service;

    internal BatchCallsClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new BatchCallsService(httpClient);
    }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public IBatchCallsClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CreateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IBatchCallsClient SetCreateAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetCreateAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IBatchCallsClient SetListAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetListAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IBatchCallsClient SetGetAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetGetAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>DeleteAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IBatchCallsClient SetDeleteAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetDeleteAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CancelAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IBatchCallsClient SetCancelAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetCancelAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>RetryAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IBatchCallsClient SetRetryAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetRetryAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ExportAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IBatchCallsClient SetExportAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetExportAsyncConfig(config);
        return this;
    }

    /// <summary>Submit a batch call request to schedule calls for multiple recipients.</summary>
    public WithRawResponseTask<BatchCallResponse> CreateAsync(
        CreateBatchCallsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<BatchCallResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.CreateAsync(
                        request.Body,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Get all batch calls for the current workspace.</summary>
    public WithRawResponseTask<WorkspaceBatchCallsResponse> ListAsync(
        ListBatchCallsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<WorkspaceBatchCallsResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.ListAsync(
                        request.Limit,
                        request.LastDoc,
                        request.AgentId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Get detailed information about a batch call including all recipients.</summary>
    public WithRawResponseTask<BatchCallDetailedResponse> GetAsync(
        string batchId,
        GetBatchCallsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<BatchCallDetailedResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetAsync(
                        batchId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Permanently delete a batch call and all recipient records. Conversations remain in history.</summary>
    public WithRawResponseTask DeleteAsync(
        string batchId,
        DeleteBatchCallsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask(
            WithRawResponseAdapter.WrapVoid(
                options,
                () =>
                    _service.DeleteAsync(
                        batchId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Cancel a running batch call and set all recipients to cancelled status.</summary>
    public WithRawResponseTask<BatchCallResponse> CancelAsync(
        string batchId,
        CancelBatchCallsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<BatchCallResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.CancelAsync(
                        batchId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Retry a batch call, calling failed and no-response recipients again.</summary>
    public WithRawResponseTask<BatchCallResponse> RetryAsync(
        string batchId,
        RetryBatchCallsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<BatchCallResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.RetryAsync(
                        batchId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Download all recipients and conversation results for a batch call as CSV, including calls that are still in progress.</summary>
    public WithRawResponseTask<string> ExportAsync(
        string batchId,
        ExportBatchCallsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<string>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.ExportAsync(
                        batchId,
                        request.Limit,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
