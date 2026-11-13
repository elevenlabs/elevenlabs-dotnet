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

namespace ElevenLabs.Agents;

/// <summary>
/// Fern-shape interface for PhoneNumbersClient. Mirrors the public surface of <c>PhoneNumbersClient</c>
/// (methods and child clients) so callers can depend on the abstraction (mockability). FSM-144.
/// </summary>
public partial interface IPhoneNumbersClient
{
    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    IPhoneNumbersClient SetConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IPhoneNumbersClient SetListAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>CreateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IPhoneNumbersClient SetCreateAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IPhoneNumbersClient SetGetAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>UpdateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IPhoneNumbersClient SetUpdateAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>DeleteAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IPhoneNumbersClient SetDeleteAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>ListV2Async</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IPhoneNumbersClient SetListV2AsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>GetSipMessagesAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IPhoneNumbersClient SetGetSipMessagesAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    );

    /// <summary>Retrieve all Phone Numbers</summary>
    WithRawResponseTask<IEnumerable<ListPhoneNumbersResponseItem>> ListAsync(
        ListPhoneNumbersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Import Phone Number from provider configuration (Twilio, Exotel, or SIP trunk)</summary>
    WithRawResponseTask<CreatePhoneNumberResponseModel> CreateAsync(
        CreatePhoneNumbersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Retrieve Phone Number details by ID</summary>
    WithRawResponseTask<ResponseGetPhoneNumberV1ConvaiPhoneNumbersPhoneNumberIdGet> GetAsync(
        string phoneNumberId,
        GetPhoneNumbersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Update assigned agent of a phone number</summary>
    WithRawResponseTask<ResponseUpdatePhoneNumberV1ConvaiPhoneNumbersPhoneNumberIdPatch> UpdateAsync(
        string phoneNumberId,
        UpdatePhoneNumbersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Delete Phone Number by ID</summary>
    WithRawResponseTask<object> DeleteAsync(
        string phoneNumberId,
        DeletePhoneNumbersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Retrieve a page of Phone Numbers</summary>
    WithRawResponseTask<GetPhoneNumbersPageResponseModel> ListV2Async(
        ListV2PhoneNumbersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Get SIP messages for a phone number</summary>
    WithRawResponseTask<GetSipLogMessagesResponse> GetSipMessagesAsync(
        string phoneNumberId,
        GetSipMessagesPhoneNumbersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

public partial class PhoneNumbersClient : IPhoneNumbersClient { }
