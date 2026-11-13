using ElevenLabs.Agents;
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
using ElevenLabs.Voices.Pvc;
using ElevenLabs.Voices.Pvc.Verification;
using ElevenLabs.Workspace;
using ElevenLabs.Workspace.Analytics;
using ElevenLabs.Workspace.Groups;
using global::System.Threading;
using OneOf;

namespace ElevenLabs;

/// <summary>
/// Fern-shape interface for AgentsClient. Mirrors the public surface of <c>AgentsClient</c>
/// (methods and child clients) so callers can depend on the abstraction (mockability). FSM-144.
/// </summary>
public partial interface IAgentsClient
{
    public IConversationsClient Conversations { get; }
    public ElevenLabs.Agents.ISettingsClient Settings { get; }
    public IDashboardClient Dashboard { get; }
    public ITwilioClient Twilio { get; }
    public IExotelClient Exotel { get; }
    public IWhatsappClient Whatsapp { get; }
    public ElevenLabs.Agents.ISummariesClient Summaries { get; }
    public IKnowledgeBaseClient KnowledgeBase { get; }
    public IWidgetClient Widget { get; }
    public ILinkClient Link { get; }
    public IHoldAudioClient HoldAudio { get; }
    public ILlmUsageClient LlmUsage { get; }
    public ITestsClient Tests { get; }
    public IUsersClient Users { get; }
    public ITriageTicketsClient TriageTickets { get; }
    public IPhoneNumbersClient PhoneNumbers { get; }
    public ILlmClient Llm { get; }
    public ElevenLabs.Agents.IAnalyticsClient Analytics { get; }
    public ElevenLabs.Agents.IToolsClient Tools { get; }
    public IMcpServersClient McpServers { get; }
    public IAnalysisItemsClient AnalysisItems { get; }
    public ISecretsClient Secrets { get; }
    public IBatchCallsClient BatchCalls { get; }
    public ISipTrunkClient SipTrunk { get; }
    public IWhatsappAccountsClient WhatsappAccounts { get; }
    public IBranchesClient Branches { get; }
    public IVersionsClient Versions { get; }
    public IDeploymentsClient Deployments { get; }
    public ElevenLabs.Agents.IDraftsClient Drafts { get; }
    public IProceduresClient Procedures { get; }
    public IMergeProposalsClient MergeProposals { get; }
    public IOutboundCampaignsClient OutboundCampaigns { get; }
    public IRealtimeClient Realtime { get; }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    IAgentsClient SetConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>CreateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IAgentsClient SetCreateAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IAgentsClient SetGetAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>UpdateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IAgentsClient SetUpdateAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>DeleteAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IAgentsClient SetDeleteAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IAgentsClient SetListAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>DuplicateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IAgentsClient SetDuplicateAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>RunTestsAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IAgentsClient SetRunTestsAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>RagIndexOverviewAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IAgentsClient SetRagIndexOverviewAsyncConfig(global::ElevenLabs.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>GetDocumentRagIndexesAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IAgentsClient SetGetDocumentRagIndexesAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    );

    /// <summary>
    /// Sets method-level configuration for <c>DeleteDocumentRagIndexAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IAgentsClient SetDeleteDocumentRagIndexAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    );

    /// <summary>Create an agent from a config object</summary>
    WithRawResponseTask<CreateAgentResponseModel> CreateAsync(
        CreateAgentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Retrieve config for an agent</summary>
    WithRawResponseTask<GetAgentResponseModel> GetAsync(
        string agentId,
        GetAgentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Patches an Agent settings</summary>
    WithRawResponseTask<GetAgentResponseModel> UpdateAsync(
        string agentId,
        UpdateAgentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Delete an agent</summary>
    WithRawResponseTask DeleteAsync(
        string agentId,
        DeleteAgentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Returns a list of your agents and their metadata.</summary>
    WithRawResponseTask<GetAgentsPageResponseModel> ListAsync(
        ListAgentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Create a new agent by duplicating an existing one. The new agent gets a copy of every unarchived branch of the source agent, each with the same name and description and starting from the latest version on that branch. The live traffic split is copied onto the new branches, with any share held by a branch that was not copied moved to main. Version history, drafts, archived branches, past traffic splits and experiments are not copied.</summary>
    WithRawResponseTask<CreateAgentResponseModel> DuplicateAsync(
        string agentId,
        DuplicateAgentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Run selected tests on the agent with provided configuration. If the agent configuration is provided, it will be used to override default agent configuration.</summary>
    WithRawResponseTask<GetTestSuiteInvocationResponseModel> RunTestsAsync(
        string agentId,
        RunTestsAgentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Provides total size and other information of RAG indexes used by knowledgebase documents</summary>
    WithRawResponseTask<RagIndexOverviewResponseModel> RagIndexOverviewAsync(
        RagIndexOverviewAgentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Provides information about all RAG indexes of the specified knowledgebase document.</summary>
    WithRawResponseTask<RagDocumentIndexesResponseModel> GetDocumentRagIndexesAsync(
        string documentationId,
        GetDocumentRagIndexesAgentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Delete RAG index for the knowledgebase document.</summary>
    WithRawResponseTask<RagDocumentIndexResponseModel> DeleteDocumentRagIndexAsync(
        string documentationId,
        string ragIndexId,
        DeleteDocumentRagIndexAgentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

public partial class AgentsClient : IAgentsClient { }
