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

namespace ElevenLabs.PronunciationDictionaries;

/// <summary>
/// Fern-shape client for RulesClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>IRulesClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class RulesClient
{
    private readonly RulesService _service;

    internal RulesClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new RulesService(httpClient);
    }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public IRulesClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>SetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IRulesClient SetSetAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetSetAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>AddAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IRulesClient SetAddAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetAddAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>RemoveAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IRulesClient SetRemoveAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetRemoveAsyncConfig(config);
        return this;
    }

    /// <summary>Replaces all existing rules on the pronunciation dictionary with the provided ones.</summary>
    public WithRawResponseTask<PronunciationDictionaryRulesResponseModel> SetAsync(
        string pronunciationDictionaryId,
        SetRulesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<PronunciationDictionaryRulesResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.SetAsync(
                        request.Body,
                        pronunciationDictionaryId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Add rules to the pronunciation dictionary. If a rule with the same string_to_replace already exists, it will be replaced.</summary>
    public WithRawResponseTask<PronunciationDictionaryRulesResponseModel> AddAsync(
        string pronunciationDictionaryId,
        AddRulesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<PronunciationDictionaryRulesResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.AddAsync(
                        request.Body,
                        pronunciationDictionaryId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Remove rules from the pronunciation dictionary</summary>
    public WithRawResponseTask<PronunciationDictionaryRulesResponseModel> RemoveAsync(
        string pronunciationDictionaryId,
        RemoveRulesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<PronunciationDictionaryRulesResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.RemoveAsync(
                        request.Body,
                        pronunciationDictionaryId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
