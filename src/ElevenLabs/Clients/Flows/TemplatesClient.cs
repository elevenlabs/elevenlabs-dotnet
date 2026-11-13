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
/// Fern-shape client for TemplatesClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>ITemplatesClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class TemplatesClient
{
    private readonly TemplatesService _service;

    internal TemplatesClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new TemplatesService(httpClient);
        Runs = new RunsClient(httpClient);
    }

    public IRunsClient Runs { get; }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public ITemplatesClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ITemplatesClient SetListAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetListAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ITemplatesClient SetGetAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetGetAsyncConfig(config);
        return this;
    }

    /// <summary>List the published flows templates in your workspace, together with each runnable version's inputs and outputs. Use the ids here as `template_id` / `version_id` on `POST /v1/flows/templates/{template_id}/runs`. Versions built on models that are not available to you through the API are left out, so `versions` is empty when none of a template's published versions is runnable through this API. Templates shared with you by link, or published to Explore from another workspace, are not listed but can still be fetched and run by `template_id`.</summary>
    public WithRawResponseTask<TemplateListResponse> ListAsync(
        ListTemplatesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<TemplateListResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.ListAsync(
                        request.Cursor,
                        request.PageSize,
                        request.VersionsPerTemplate,
                        request.Search,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Retrieve one flows template, together with each runnable version's inputs and outputs. `versions` is empty when no published version is runnable through this API. Works for any template you can open, including templates shared with you by link or published to Explore from another workspace, which `GET /v1/flows/templates` does not list.</summary>
    public WithRawResponseTask<TemplateSummary> GetAsync(
        string templateId,
        GetTemplatesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<TemplateSummary>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetAsync(
                        templateId,
                        request.VersionsPerTemplate,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
