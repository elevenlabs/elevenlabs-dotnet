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
/// Fern-shape client for PhoneNumbersClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>IPhoneNumbersClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class PhoneNumbersClient
{
    private readonly PhoneNumbersService _service;

    internal PhoneNumbersClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new PhoneNumbersService(httpClient);
    }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public IPhoneNumbersClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IPhoneNumbersClient SetListAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetListAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CreateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IPhoneNumbersClient SetCreateAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetCreateAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IPhoneNumbersClient SetGetAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetGetAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>UpdateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IPhoneNumbersClient SetUpdateAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetUpdateAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>DeleteAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IPhoneNumbersClient SetDeleteAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetDeleteAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ListV2Async</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IPhoneNumbersClient SetListV2AsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetListV2AsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetSipMessagesAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IPhoneNumbersClient SetGetSipMessagesAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetGetSipMessagesAsyncConfig(config);
        return this;
    }

    /// <summary>Retrieve all Phone Numbers</summary>
    public WithRawResponseTask<IEnumerable<ListPhoneNumbersResponseItem>> ListAsync(
        ListPhoneNumbersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<IEnumerable<ListPhoneNumbersResponseItem>>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.ListAsync(
                        request.Provider,
                        request.AgentId,
                        request.BranchId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Import Phone Number from provider configuration (Twilio, Exotel, or SIP trunk)</summary>
    public WithRawResponseTask<CreatePhoneNumberResponseModel> CreateAsync(
        CreatePhoneNumbersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<CreatePhoneNumberResponseModel>(
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
                            )
                    )
            )
        );

    /// <summary>Retrieve Phone Number details by ID</summary>
    public WithRawResponseTask<ResponseGetPhoneNumberV1ConvaiPhoneNumbersPhoneNumberIdGet> GetAsync(
        string phoneNumberId,
        GetPhoneNumbersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<ResponseGetPhoneNumberV1ConvaiPhoneNumbersPhoneNumberIdGet>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetAsync(
                        phoneNumberId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Update assigned agent of a phone number</summary>
    public WithRawResponseTask<ResponseUpdatePhoneNumberV1ConvaiPhoneNumbersPhoneNumberIdPatch> UpdateAsync(
        string phoneNumberId,
        UpdatePhoneNumbersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<ResponseUpdatePhoneNumberV1ConvaiPhoneNumbersPhoneNumberIdPatch>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.UpdateAsync(
                        request.Body,
                        phoneNumberId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Delete Phone Number by ID</summary>
    public WithRawResponseTask<object> DeleteAsync(
        string phoneNumberId,
        DeletePhoneNumbersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<object>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.DeleteAsync(
                        phoneNumberId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Retrieve a page of Phone Numbers</summary>
    public WithRawResponseTask<GetPhoneNumbersPageResponseModel> ListV2Async(
        ListV2PhoneNumbersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<GetPhoneNumbersPageResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.ListV2Async(
                        request.PageSize,
                        request.Search,
                        request.Label,
                        request.PhoneNumber,
                        request.Provider,
                        request.SupportsOutbound,
                        request.AgentId,
                        request.BranchId,
                        request.SortBy,
                        request.SortDirection,
                        request.Cursor,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Get SIP messages for a phone number</summary>
    public WithRawResponseTask<GetSipLogMessagesResponse> GetSipMessagesAsync(
        string phoneNumberId,
        GetSipMessagesPhoneNumbersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<GetSipLogMessagesResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetSipMessagesAsync(
                        phoneNumberId,
                        request.PageSize,
                        request.Cursor,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
