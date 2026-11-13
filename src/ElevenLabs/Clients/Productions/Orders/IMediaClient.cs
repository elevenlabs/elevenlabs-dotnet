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

namespace ElevenLabs.Productions.Orders;

/// <summary>
/// Fern-shape interface for MediaClient. Mirrors the public surface of <c>MediaClient</c>
/// (methods and child clients) so callers can depend on the abstraction (mockability). FSM-144.
/// </summary>
public partial interface IMediaClient
{
    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    IMediaClient SetConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>RegisterAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IMediaClient SetRegisterAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IMediaClient SetGetAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>Registers a media file with an order, either by uploading it directly or by providing a URL to fetch it from. Exactly one of `media` or `media_url` must be provided. The registered media can then be referenced when adding order items.</summary>
    WithRawResponseTask<RegisterMediaResponse> RegisterAsync(
        string orderId,
        RegisterMediaRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Retrieves metadata and a time-limited download URL for a previously uploaded media file.</summary>
    WithRawResponseTask<OrderMediaResponse> GetAsync(
        string orderId,
        string mediaId,
        GetMediaRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

public partial class MediaClient : IMediaClient { }
