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
/// Fern-shape client for FoldersClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>IFoldersClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class FoldersClient
{
    private readonly FoldersService _service;

    internal FoldersClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new FoldersService(httpClient);
    }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public IFoldersClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CreateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IFoldersClient SetCreateAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetCreateAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IFoldersClient SetGetAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetGetAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>UpdateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IFoldersClient SetUpdateAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetUpdateAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>DeleteAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IFoldersClient SetDeleteAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetDeleteAsyncConfig(config);
        return this;
    }

    /// <summary>Creates a folder for organizing agent tests.</summary>
    public WithRawResponseTask<CreateAgentTestFolderResponseModel> CreateAsync(
        CreateFoldersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<CreateAgentTestFolderResponseModel>(
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

    /// <summary>Gets an agent test folder by ID, including its folder path.</summary>
    public WithRawResponseTask<GetAgentTestFolderResponseModel> GetAsync(
        string folderId,
        GetFoldersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<GetAgentTestFolderResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetAsync(
                        folderId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Updates an agent test folder. Currently only supports updating the folder name.</summary>
    public WithRawResponseTask<GetAgentTestFolderResponseModel> UpdateAsync(
        string folderId,
        UpdateFoldersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<GetAgentTestFolderResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.UpdateAsync(
                        request.Body,
                        folderId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Deletes an agent test folder by ID. Use force=true to delete a non-empty folder and all its contents.</summary>
    public WithRawResponseTask DeleteAsync(
        string folderId,
        DeleteFoldersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask(
            WithRawResponseAdapter.WrapVoid(
                options,
                () =>
                    _service.DeleteAsync(
                        folderId,
                        request.Force,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
