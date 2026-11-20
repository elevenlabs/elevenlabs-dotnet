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
using ElevenLabs.Reception.Products;
using ElevenLabs.Reception.Receptionists;
using ElevenLabs.Reception.Team;
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

namespace ElevenLabs.Reception;

/// <summary>
/// Fern-shape client for HolidaysClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>IHolidaysClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class HolidaysClient
{
    private readonly HolidaysService _service;

    internal HolidaysClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new HolidaysService(httpClient);
    }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public IHolidaysClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IHolidaysClient SetListAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetListAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CreateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IHolidaysClient SetCreateAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetCreateAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IHolidaysClient SetGetAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetGetAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>UpdateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IHolidaysClient SetUpdateAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetUpdateAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>DeleteAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IHolidaysClient SetDeleteAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetDeleteAsyncConfig(config);
        return this;
    }

    /// <summary>Get all holidays/time-off entries for the current workspace with optional filters</summary>
    public WithRawResponseTask<IEnumerable<HolidayResponseModel>> ListAsync(
        ListHolidaysRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<IEnumerable<HolidayResponseModel>>(
            WithRawResponseAdapter.WrapEnumerable(
                options,
                () =>
                    _service.ListAsync(
                        request.XiWorkspaceId,
                        request.StartUnix,
                        request.EndUnix,
                        request.TimeOffType,
                        request.ResourceId,
                        request.LocationId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Create a new holiday</summary>
    public WithRawResponseTask<HolidayResponseModel> CreateAsync(
        CreateHolidaysRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<HolidayResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.CreateAsync(
                        request.Body,
                        request.XiWorkspaceId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Get a specific holiday by ID</summary>
    public WithRawResponseTask<HolidayResponseModel> GetAsync(
        string holidayId,
        GetHolidaysRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<HolidayResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetAsync(
                        holidayId,
                        request.XiWorkspaceId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Update an existing holiday. Only the fields sent are changed.</summary>
    public WithRawResponseTask<HolidayResponseModel> UpdateAsync(
        string holidayId,
        UpdateHolidaysRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<HolidayResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.UpdateAsync(
                        request.Body,
                        holidayId,
                        request.XiWorkspaceId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Delete a holiday</summary>
    public WithRawResponseTask<Dictionary<string, string>> DeleteAsync(
        string holidayId,
        DeleteHolidaysRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<Dictionary<string, string>>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.DeleteAsync(
                        holidayId,
                        request.XiWorkspaceId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
