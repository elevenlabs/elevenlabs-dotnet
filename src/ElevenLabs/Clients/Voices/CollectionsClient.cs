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
using ElevenLabs.Studio.Projects;
using ElevenLabs.Studio.Projects.Chapters;
using ElevenLabs.Tokens;
using ElevenLabs.Voices.Pvc;
using ElevenLabs.Voices.Pvc.Verification;
using ElevenLabs.Workspace;
using ElevenLabs.Workspace.Analytics;
using ElevenLabs.Workspace.Groups;
using global::System.Linq;
using global::System.Threading;
using OneOf;

namespace ElevenLabs.Voices;

/// <summary>
/// Fern-shape client for CollectionsClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>ICollectionsClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class CollectionsClient
{
    private readonly CollectionsService _service;

    internal CollectionsClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new CollectionsService(httpClient);
    }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public ICollectionsClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ICollectionsClient SetListAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetListAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CreateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ICollectionsClient SetCreateAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetCreateAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ICollectionsClient SetGetAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetGetAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>UpdateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ICollectionsClient SetUpdateAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetUpdateAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>DeleteAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ICollectionsClient SetDeleteAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetDeleteAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>AddVoiceAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ICollectionsClient SetAddVoiceAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetAddVoiceAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>RemoveVoiceAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public ICollectionsClient SetRemoveVoiceAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetRemoveVoiceAsyncConfig(config);
        return this;
    }

    /// <summary>Returns all the voice collections the user has access to, sorted by title.</summary>
    public WithRawResponseTask<GetUserVoiceCollectionsResponseModel> ListAsync(
        ListCollectionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<GetUserVoiceCollectionsResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () => _service.ListAsync(request.XiApiKey, cancellationToken: cancellationToken)
            )
        );

    /// <summary>Creates a new voice collection. The caller becomes its admin.</summary>
    public WithRawResponseTask<UserVoiceCollectionResponseModel> CreateAsync(
        CreateCollectionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<UserVoiceCollectionResponseModel>(
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

    /// <summary>Returns a voice collection the user has access to.</summary>
    public WithRawResponseTask<UserVoiceCollectionResponseModel> GetAsync(
        string collectionId,
        GetCollectionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<UserVoiceCollectionResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetAsync(
                        collectionId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Updates the title and icon of a voice collection. Fields that are omitted are left unchanged. Requires editor access to the collection.</summary>
    public WithRawResponseTask<UserVoiceCollectionResponseModel> UpdateAsync(
        string collectionId,
        UpdateCollectionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<UserVoiceCollectionResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.UpdateAsync(
                        request.Body,
                        collectionId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Deletes a voice collection. The voices in it are not deleted. Requires admin access to the collection.</summary>
    public WithRawResponseTask<DeleteUserVoiceCollectionResponseModel> DeleteAsync(
        string collectionId,
        DeleteCollectionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<DeleteUserVoiceCollectionResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.DeleteAsync(
                        collectionId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Adds a voice to a voice collection. Adding a voice that is already in the collection succeeds without changes. Requires editor access to the collection.</summary>
    public WithRawResponseTask<AddVoiceToUserVoiceCollectionResponseModel> AddVoiceAsync(
        string collectionId,
        string voiceId,
        AddVoiceCollectionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<AddVoiceToUserVoiceCollectionResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.AddVoiceAsync(
                        collectionId,
                        voiceId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Removes a voice from a voice collection. The voice itself is not deleted. Requires editor access to the collection.</summary>
    public WithRawResponseTask<RemoveVoiceFromUserVoiceCollectionResponseModel> RemoveVoiceAsync(
        string collectionId,
        string voiceId,
        RemoveVoiceCollectionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<RemoveVoiceFromUserVoiceCollectionResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.RemoveVoiceAsync(
                        collectionId,
                        voiceId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
