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
using global::System.Threading;
using OneOf;

namespace ElevenLabs;

/// <summary>
/// Fern-shape interface for VoicesClient. Mirrors the public surface of <c>VoicesClient</c>
/// (methods and child clients) so callers can depend on the abstraction (mockability). FSM-144.
/// </summary>
public partial interface IVoicesClient
{
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
    IVoicesClient SetConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IVoicesClient SetGetAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>DeleteAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IVoicesClient SetDeleteAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>UpdateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IVoicesClient SetUpdateAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>SearchAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IVoicesClient SetSearchAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>ReplicateToIsolatedEnvironmentAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IVoicesClient SetReplicateToIsolatedEnvironmentAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    );

    /// <summary>
    /// Sets method-level configuration for <c>ShareAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IVoicesClient SetShareAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>FindSimilarVoicesAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IVoicesClient SetFindSimilarVoicesAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>GetSharedAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IVoicesClient SetGetSharedAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>Returns metadata about a specific voice.</summary>
    WithRawResponseTask<Voice> GetAsync(
        string voiceId,
        GetVoicesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Deletes a voice by its ID.</summary>
    WithRawResponseTask<DeleteVoiceResponseModel> DeleteAsync(
        string voiceId,
        DeleteVoicesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Edit a voice created by you.</summary>
    WithRawResponseTask<EditVoiceResponseModel> UpdateAsync(
        string voiceId,
        UpdateVoicesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Gets a list of all available voices for a user with search, filtering and pagination.</summary>
    WithRawResponseTask<GetVoicesV2Response> SearchAsync(
        SearchVoicesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Replicates an Instant Voice Clone or Voice Design voice to a workspace in a different data residency. The target workspace must belong to the same consolidated billing group. The user must have VOICES_WRITE in the source workspace, and be an admin on the source voice. Human users (i.e. not service accounts) must also have VOICES_WRITE in the target workspace. This endpoint is available on the central environment only.</summary>
    WithRawResponseTask<ReplicateVoiceToIsolatedEnvironmentResponseModel> ReplicateToIsolatedEnvironmentAsync(
        string voiceId,
        ReplicateToIsolatedEnvironmentVoicesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Add a shared voice to your collection of Voices</summary>
    WithRawResponseTask<AddVoiceResponseModel> ShareAsync(
        string publicUserId,
        string voiceId,
        ShareVoicesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Returns a list of shared voices similar to the provided audio sample. If neither similarity_threshold nor top_k is provided, we will apply default values.</summary>
    WithRawResponseTask<GetLibraryVoicesResponse> FindSimilarVoicesAsync(
        FindSimilarVoicesVoicesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Retrieves a list of shared voices.</summary>
    WithRawResponseTask<GetLibraryVoicesResponse> GetSharedAsync(
        GetSharedVoicesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

public partial class VoicesClient : IVoicesClient { }
