using ElevenLabs;
using ElevenLabs.Agents;
using ElevenLabs.Agents.Conversations;
using ElevenLabs.Agents.Dashboard;
using ElevenLabs.Agents.KnowledgeBase;
using ElevenLabs.Agents.McpServers;
using ElevenLabs.Agents.OutboundCampaigns;
using ElevenLabs.Agents.Procedures;
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

namespace ElevenLabs.Agents.Tests;

/// <summary>
/// Fern-shape client for InvocationsClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>IInvocationsClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class InvocationsClient
{
    private readonly InvocationsService _service;

    internal InvocationsClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new InvocationsService(httpClient);
    }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public IInvocationsClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IInvocationsClient SetListAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetListAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IInvocationsClient SetGetAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetGetAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>UpdateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IInvocationsClient SetUpdateAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetUpdateAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CancelAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IInvocationsClient SetCancelAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetCancelAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ResubmitAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IInvocationsClient SetResubmitAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetResubmitAsyncConfig(config);
        return this;
    }

    /// <summary>Lists all test invocations with pagination support and optional search filtering.</summary>
    public WithRawResponseTask<GetTestInvocationsPageResponseModel> ListAsync(
        ListInvocationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<GetTestInvocationsPageResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.ListAsync(
                        request.AgentId,
                        request.BranchId,
                        request.CreatedByUserId,
                        request.TestId,
                        request.StartTime,
                        request.EndTime,
                        request.VersionId,
                        request.PageSize,
                        request.Search,
                        request.Cursor,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Gets a test invocation by ID.</summary>
    public WithRawResponseTask<GetTestSuiteInvocationResponseModel> GetAsync(
        string testInvocationId,
        GetInvocationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<GetTestSuiteInvocationResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetAsync(
                        testInvocationId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Updates the user-provided name of a test invocation.</summary>
    public WithRawResponseTask<GetTestSuiteInvocationResponseModel> UpdateAsync(
        string testInvocationId,
        UpdateInvocationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<GetTestSuiteInvocationResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.UpdateAsync(
                        request.Body,
                        testInvocationId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Cancels all pending runs in a test invocation.</summary>
    public WithRawResponseTask CancelAsync(
        string testInvocationId,
        CancelInvocationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask(
            WithRawResponseAdapter.WrapVoid(
                options,
                () =>
                    _service.CancelAsync(
                        testInvocationId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Resubmits specific test runs from a test invocation.</summary>
    public WithRawResponseTask<object> ResubmitAsync(
        string testInvocationId,
        ResubmitInvocationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<object>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.ResubmitAsync(
                        request.Body,
                        testInvocationId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
