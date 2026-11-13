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
using global::System.Threading;
using OneOf;

namespace ElevenLabs;

/// <summary>
/// Fern-shape interface for PronunciationDictionariesClient. Mirrors the public surface of <c>PronunciationDictionariesClient</c>
/// (methods and child clients) so callers can depend on the abstraction (mockability). FSM-144.
/// </summary>
public partial interface IPronunciationDictionariesClient
{
    public IRulesClient Rules { get; }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    IPronunciationDictionariesClient SetConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>CreateFromFileAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IPronunciationDictionariesClient SetCreateFromFileAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    );

    /// <summary>
    /// Sets method-level configuration for <c>CreateFromRulesAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IPronunciationDictionariesClient SetCreateFromRulesAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    );

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IPronunciationDictionariesClient SetGetAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    );

    /// <summary>
    /// Sets method-level configuration for <c>UpdateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IPronunciationDictionariesClient SetUpdateAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    );

    /// <summary>
    /// Sets method-level configuration for <c>DownloadAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IPronunciationDictionariesClient SetDownloadAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    );

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IPronunciationDictionariesClient SetListAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    );

    /// <summary>Creates a new pronunciation dictionary from a lexicon .PLS file</summary>
    WithRawResponseTask<AddPronunciationDictionaryResponseModel> CreateFromFileAsync(
        CreateFromFilePronunciationDictionariesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Creates a new pronunciation dictionary from provided rules.</summary>
    WithRawResponseTask<AddPronunciationDictionaryResponseModel> CreateFromRulesAsync(
        CreateFromRulesPronunciationDictionariesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Get metadata for a pronunciation dictionary</summary>
    WithRawResponseTask<GetPronunciationDictionaryWithRulesResponseModel> GetAsync(
        string pronunciationDictionaryId,
        GetPronunciationDictionariesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Partially update the pronunciation dictionary without changing the version</summary>
    WithRawResponseTask<GetPronunciationDictionaryMetadataResponse> UpdateAsync(
        string pronunciationDictionaryId,
        UpdatePronunciationDictionariesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Get a PLS file with a pronunciation dictionary version rules</summary>
    WithRawResponseTask<string> DownloadAsync(
        string dictionaryId,
        string versionId,
        DownloadPronunciationDictionariesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Get a list of the pronunciation dictionaries you have access to and their metadata</summary>
    WithRawResponseTask<GetPronunciationDictionariesMetadataResponseModel> ListAsync(
        ListPronunciationDictionariesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

public partial class PronunciationDictionariesClient : IPronunciationDictionariesClient { }
