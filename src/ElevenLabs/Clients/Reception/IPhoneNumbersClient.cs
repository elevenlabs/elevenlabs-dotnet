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
using ElevenLabs.CustomerSupport;
using ElevenLabs.CustomerSupport.Requesters;
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
using ElevenLabs.Reception.Products;
using ElevenLabs.Reception.Receptionists;
using ElevenLabs.Reception.Team;
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

namespace ElevenLabs.Reception;

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
    /// Sets method-level configuration for <c>UpdateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IPhoneNumbersClient SetUpdateAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>DeleteAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IPhoneNumbersClient SetDeleteAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>List the workspace's phone numbers and the receptionist each one rings. A number with no `customer_facing_agent_id` is held by the workspace but not attached to a receptionist yet.</summary>
    WithRawResponseTask<IEnumerable<ReceptionPhoneAssignment>> ListAsync(
        ListPhoneNumbersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Give a receptionist a phone number. A number the workspace already holds but has not attached is used first. Otherwise, in the US and Canada, a number with one of the requested `area_codes` is taken from the pool or bought, falling back to any number in the business's country. In countries that require paperwork, the number is issued right away but takes public calls only once the workspace's own registration is approved (see `accepts_public_calls`). Counts toward the plan's phone number limit, and free plans can take only a few new numbers a day. Returns 404 when no number is available and 403 `telephony_managed_by_reseller` when the reseller supplies the workspace's numbers from its own Twilio account or SIP trunk and none is free.</summary>
    WithRawResponseTask<ReceptionPhoneAssignment> CreateAsync(
        CreatePhoneNumbersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Move a phone number to a different receptionist in the same workspace, which answers its calls from then on. Returns 409 `phone_number_not_attached` for a number no receptionist answers yet (attach it with `POST /v1/reception/phone-numbers/assignments`).</summary>
    WithRawResponseTask<ReceptionPhoneAssignment> UpdateAsync(
        string phoneAssignmentId,
        UpdatePhoneNumbersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Remove a phone number from the workspace. A pool number goes back to the pool it came from. A number the business brought from its own Twilio account, or one issued in a country that requires paperwork, is released at Twilio and cannot be recovered. Returns 403 `telephony_managed_by_reseller` when the reseller supplies the workspace's numbers from its own Twilio account or SIP trunk.</summary>
    WithRawResponseTask DeleteAsync(
        string phoneAssignmentId,
        DeletePhoneNumbersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

public partial class PhoneNumbersClient : IPhoneNumbersClient { }
