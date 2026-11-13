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

namespace ElevenLabs;

/// <summary>
/// Fern-shape client for PronunciationDictionariesClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>IPronunciationDictionariesClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class PronunciationDictionariesClient
{
    private readonly PronunciationDictionariesService _service;

    internal PronunciationDictionariesClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new PronunciationDictionariesService(httpClient);
        Rules = new RulesClient(httpClient);
    }

    public IRulesClient Rules { get; }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public IPronunciationDictionariesClient SetConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CreateFromFileAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IPronunciationDictionariesClient SetCreateFromFileAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetCreateFromFileAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CreateFromRulesAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IPronunciationDictionariesClient SetCreateFromRulesAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetCreateFromRulesAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IPronunciationDictionariesClient SetGetAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetGetAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>UpdateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IPronunciationDictionariesClient SetUpdateAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetUpdateAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>DownloadAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IPronunciationDictionariesClient SetDownloadAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetDownloadAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IPronunciationDictionariesClient SetListAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetListAsyncConfig(config);
        return this;
    }

    /// <summary>Creates a new pronunciation dictionary from a lexicon .PLS file</summary>
    public WithRawResponseTask<AddPronunciationDictionaryResponseModel> CreateFromFileAsync(
        CreateFromFilePronunciationDictionariesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<AddPronunciationDictionaryResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.CreateFromFileAsync(
                        request.Body,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Creates a new pronunciation dictionary from provided rules.</summary>
    public WithRawResponseTask<AddPronunciationDictionaryResponseModel> CreateFromRulesAsync(
        CreateFromRulesPronunciationDictionariesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<AddPronunciationDictionaryResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.CreateFromRulesAsync(
                        request.Body,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Get metadata for a pronunciation dictionary</summary>
    public WithRawResponseTask<GetPronunciationDictionaryWithRulesResponseModel> GetAsync(
        string pronunciationDictionaryId,
        GetPronunciationDictionariesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<GetPronunciationDictionaryWithRulesResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetAsync(
                        pronunciationDictionaryId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Partially update the pronunciation dictionary without changing the version</summary>
    public WithRawResponseTask<GetPronunciationDictionaryMetadataResponse> UpdateAsync(
        string pronunciationDictionaryId,
        UpdatePronunciationDictionariesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<GetPronunciationDictionaryMetadataResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.UpdateAsync(
                        request.Body,
                        pronunciationDictionaryId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Get a PLS file with a pronunciation dictionary version rules</summary>
    public WithRawResponseTask<string> DownloadAsync(
        string dictionaryId,
        string versionId,
        DownloadPronunciationDictionariesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<string>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.DownloadAsync(
                        dictionaryId,
                        versionId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Get a list of the pronunciation dictionaries you have access to and their metadata</summary>
    public WithRawResponseTask<GetPronunciationDictionariesMetadataResponseModel> ListAsync(
        ListPronunciationDictionariesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<GetPronunciationDictionariesMetadataResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.ListAsync(
                        request.Cursor,
                        request.PageSize,
                        request.Sort,
                        request.SortDirection,
                        request.IncludeArchived,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
