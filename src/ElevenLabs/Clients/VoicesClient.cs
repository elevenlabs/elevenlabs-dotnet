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
using ElevenLabs.Studio.Projects;
using ElevenLabs.Studio.Projects.Chapters;
using ElevenLabs.Tokens;
using ElevenLabs.Voices;
using ElevenLabs.Voices;
using ElevenLabs.Voices.Pvc;
using ElevenLabs.Voices.Pvc.Verification;
using ElevenLabs.Workspace;
using ElevenLabs.Workspace.Analytics;
using ElevenLabs.Workspace.Groups;
using global::System.Linq;
using global::System.Threading;
using OneOf;

namespace ElevenLabs;

/// <summary>
/// Fern-shape client for VoicesClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>IVoicesClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class VoicesClient
{
    private readonly VoicesService _service;

    internal VoicesClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new VoicesService(httpClient);
        Pvc = new PvcClient(httpClient);
        Samples = new ElevenLabs.Voices.SamplesClient(httpClient);
        Collections = new CollectionsClient(httpClient);
        Settings = new ElevenLabs.Voices.SettingsClient(httpClient);
        Accents = new AccentsClient(httpClient);
        Ivc = new IvcClient(httpClient);
    }

    public IPvcClient Pvc { get; }
    public ElevenLabs.Voices.ISamplesClient Samples { get; }
    public ICollectionsClient Collections { get; }
    public ElevenLabs.Voices.ISettingsClient Settings { get; }
    public IAccentsClient Accents { get; }
    public IIvcClient Ivc { get; }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public IVoicesClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IVoicesClient SetGetAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetGetAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>DeleteAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IVoicesClient SetDeleteAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetDeleteAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>UpdateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IVoicesClient SetUpdateAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetUpdateAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>SearchAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IVoicesClient SetSearchAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetSearchAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ReplicateToIsolatedEnvironmentAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IVoicesClient SetReplicateToIsolatedEnvironmentAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetReplicateToIsolatedEnvironmentAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ShareAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IVoicesClient SetShareAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetShareAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>FindSimilarVoicesAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IVoicesClient SetFindSimilarVoicesAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetFindSimilarVoicesAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetSharedAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IVoicesClient SetGetSharedAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetGetSharedAsyncConfig(config);
        return this;
    }

    /// <summary>Returns metadata about a specific voice.</summary>
    public WithRawResponseTask<Voice> GetAsync(
        string voiceId,
        GetVoicesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<Voice>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetAsync(
                        voiceId,
                        request.WithSettings,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Deletes a voice by its ID.</summary>
    public WithRawResponseTask<DeleteVoiceResponseModel> DeleteAsync(
        string voiceId,
        DeleteVoicesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<DeleteVoiceResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.DeleteAsync(
                        voiceId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Edit a voice created by you.</summary>
    public WithRawResponseTask<EditVoiceResponseModel> UpdateAsync(
        string voiceId,
        UpdateVoicesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<EditVoiceResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.UpdateAsync(
                        request.Body,
                        voiceId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Gets a list of all available voices for a user with search, filtering and pagination.</summary>
    public WithRawResponseTask<GetVoicesV2Response> SearchAsync(
        SearchVoicesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<GetVoicesV2Response>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.SearchAsync(
                        request.NextPageToken,
                        request.PageSize,
                        request.Search,
                        request.Sort,
                        request.SortDirection,
                        request.VoiceType,
                        request.Category,
                        request.FineTuningState,
                        request.CollectionId,
                        request.Gender,
                        request.Age,
                        request.Language?.ToList(),
                        request.Accent,
                        request.UseCases?.ToList(),
                        request.MinNoticePeriodDays,
                        request.IncludeCustomRates,
                        request.IncludeLiveModerated,
                        request.HighQuality,
                        request.IncludeTotalCount,
                        request.VoiceIds?.ToList(),
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Replicates an Instant Voice Clone or Voice Design voice to a workspace in a different data residency. The target workspace must belong to the same consolidated billing group. The user must have VOICES_WRITE in the source workspace, and be an admin on the source voice. Human users (i.e. not service accounts) must also have VOICES_WRITE in the target workspace. This endpoint is available on the central environment only.</summary>
    public WithRawResponseTask<ReplicateVoiceToIsolatedEnvironmentResponseModel> ReplicateToIsolatedEnvironmentAsync(
        string voiceId,
        ReplicateToIsolatedEnvironmentVoicesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<ReplicateVoiceToIsolatedEnvironmentResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.ReplicateToIsolatedEnvironmentAsync(
                        request.Body,
                        voiceId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Add a shared voice to your collection of Voices</summary>
    public WithRawResponseTask<AddVoiceResponseModel> ShareAsync(
        string publicUserId,
        string voiceId,
        ShareVoicesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<AddVoiceResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.ShareAsync(
                        request.Body,
                        publicUserId,
                        voiceId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Returns a list of shared voices similar to the provided audio sample. If neither similarity_threshold nor top_k is provided, we will apply default values.</summary>
    public WithRawResponseTask<GetLibraryVoicesResponse> FindSimilarVoicesAsync(
        FindSimilarVoicesVoicesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<GetLibraryVoicesResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.FindSimilarVoicesAsync(
                        request.Body,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Retrieves a list of shared voices.</summary>
    public WithRawResponseTask<GetLibraryVoicesResponse> GetSharedAsync(
        GetSharedVoicesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<GetLibraryVoicesResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetSharedAsync(
                        request.PageSize,
                        request.Category,
                        request.Gender,
                        request.Age,
                        request.Accent,
                        request.Language,
                        request.Locale,
                        request.Search,
                        request.UseCases?.ToList(),
                        request.Descriptives?.ToList(),
                        request.Featured,
                        request.MinNoticePeriodDays,
                        request.IncludeCustomRates,
                        request.IncludeLiveModerated,
                        request.ReaderAppEnabled,
                        request.OwnerId,
                        request.Sort,
                        request.Page,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
