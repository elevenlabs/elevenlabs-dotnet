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
/// Fern-shape client for WhatsappClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>IWhatsappClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class WhatsappClient
{
    private readonly WhatsappService _service;

    internal WhatsappClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new WhatsappService(httpClient);
    }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public IWhatsappClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>OutboundCallAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IWhatsappClient SetOutboundCallAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetOutboundCallAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>OutboundMessageAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IWhatsappClient SetOutboundMessageAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetOutboundMessageAsyncConfig(config);
        return this;
    }

    /// <summary>Make an outbound call via WhatsApp</summary>
    public WithRawResponseTask<WhatsAppOutboundCallResponse> OutboundCallAsync(
        OutboundCallWhatsappRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<WhatsAppOutboundCallResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.OutboundCallAsync(
                        request.Body,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Send an outbound message via WhatsApp</summary>
    public WithRawResponseTask<WhatsAppOutboundMessageResponse> OutboundMessageAsync(
        OutboundMessageWhatsappRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<WhatsAppOutboundMessageResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.OutboundMessageAsync(
                        request.Body,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
