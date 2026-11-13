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
/// Fern-shape client for AgentsClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>IAgentsClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class AgentsClient
{
    private readonly AgentsService _service;

    internal AgentsClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new AgentsService(httpClient);
        Conversations = new ConversationsClient(httpClient);
        Settings = new ElevenLabs.Agents.SettingsClient(httpClient);
        Dashboard = new DashboardClient(httpClient);
        Twilio = new TwilioClient(httpClient);
        Exotel = new ExotelClient(httpClient);
        Whatsapp = new WhatsappClient(httpClient);
        Summaries = new ElevenLabs.Agents.SummariesClient(httpClient);
        KnowledgeBase = new KnowledgeBaseClient(httpClient);
        Widget = new WidgetClient(httpClient);
        Link = new LinkClient(httpClient);
        HoldAudio = new HoldAudioClient(httpClient);
        LlmUsage = new LlmUsageClient(httpClient);
        Tests = new TestsClient(httpClient);
        Users = new UsersClient(httpClient);
        TriageTickets = new TriageTicketsClient(httpClient);
        PhoneNumbers = new PhoneNumbersClient(httpClient);
        Llm = new LlmClient(httpClient);
        Analytics = new ElevenLabs.Agents.AnalyticsClient(httpClient);
        Tools = new ElevenLabs.Agents.ToolsClient(httpClient);
        McpServers = new McpServersClient(httpClient);
        AnalysisItems = new AnalysisItemsClient(httpClient);
        Secrets = new SecretsClient(httpClient);
        BatchCalls = new BatchCallsClient(httpClient);
        SipTrunk = new SipTrunkClient(httpClient);
        WhatsappAccounts = new WhatsappAccountsClient(httpClient);
        Branches = new BranchesClient(httpClient);
        Versions = new VersionsClient(httpClient);
        Deployments = new DeploymentsClient(httpClient);
        Drafts = new ElevenLabs.Agents.DraftsClient(httpClient);
        Procedures = new ProceduresClient(httpClient);
        MergeProposals = new MergeProposalsClient(httpClient);
        OutboundCampaigns = new OutboundCampaignsClient(httpClient);
        Realtime = new RealtimeClient(httpClient);
    }

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
    public IAgentsClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CreateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IAgentsClient SetCreateAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetCreateAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IAgentsClient SetGetAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetGetAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>UpdateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IAgentsClient SetUpdateAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetUpdateAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>DeleteAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IAgentsClient SetDeleteAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetDeleteAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IAgentsClient SetListAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetListAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>DuplicateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IAgentsClient SetDuplicateAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetDuplicateAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>RunTestsAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IAgentsClient SetRunTestsAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetRunTestsAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>RagIndexOverviewAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IAgentsClient SetRagIndexOverviewAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetRagIndexOverviewAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetDocumentRagIndexesAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IAgentsClient SetGetDocumentRagIndexesAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetGetDocumentRagIndexesAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>DeleteDocumentRagIndexAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IAgentsClient SetDeleteDocumentRagIndexAsyncConfig(
        global::ElevenLabs.Config.RequestConfig config
    )
    {
        _service.SetDeleteDocumentRagIndexAsyncConfig(config);
        return this;
    }

    /// <summary>Create an agent from a config object</summary>
    public WithRawResponseTask<CreateAgentResponseModel> CreateAsync(
        CreateAgentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<CreateAgentResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.CreateAsync(
                        request.Body,
                        request.EnableVersioning,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Retrieve config for an agent</summary>
    public WithRawResponseTask<GetAgentResponseModel> GetAsync(
        string agentId,
        GetAgentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<GetAgentResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetAsync(
                        agentId,
                        request.VersionId,
                        request.BranchId,
                        request.IncludeProcedureGeneratedWorkflowElements,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Patches an Agent settings</summary>
    public WithRawResponseTask<GetAgentResponseModel> UpdateAsync(
        string agentId,
        UpdateAgentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<GetAgentResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.UpdateAsync(
                        request.Body,
                        agentId,
                        request.EnableVersioningIfNotEnabled,
                        request.BranchId,
                        request.IncludeProcedureGeneratedWorkflowElements,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Delete an agent</summary>
    public WithRawResponseTask DeleteAsync(
        string agentId,
        DeleteAgentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask(
            WithRawResponseAdapter.WrapVoid(
                options,
                () =>
                    _service.DeleteAsync(
                        agentId,
                        request.Force,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Returns a list of your agents and their metadata.</summary>
    public WithRawResponseTask<GetAgentsPageResponseModel> ListAsync(
        ListAgentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<GetAgentsPageResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.ListAsync(
                        request.PageSize,
                        request.Search,
                        request.Archived,
                        request.ShowOnlyOwnedAgents,
                        request.CreatedByUserId,
                        request.Tags?.ToList(),
                        request.SortDirection,
                        request.SortBy,
                        request.Cursor,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Create a new agent by duplicating an existing one. The new agent gets a copy of every unarchived branch of the source agent, each with the same name and description and starting from the latest version on that branch. The live traffic split is copied onto the new branches, with any share held by a branch that was not copied moved to main. Version history, drafts, archived branches, past traffic splits and experiments are not copied.</summary>
    public WithRawResponseTask<CreateAgentResponseModel> DuplicateAsync(
        string agentId,
        DuplicateAgentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<CreateAgentResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.DuplicateAsync(
                        request.Body,
                        agentId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Run selected tests on the agent with provided configuration. If the agent configuration is provided, it will be used to override default agent configuration.</summary>
    public WithRawResponseTask<GetTestSuiteInvocationResponseModel> RunTestsAsync(
        string agentId,
        RunTestsAgentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<GetTestSuiteInvocationResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.RunTestsAsync(
                        request.Body,
                        agentId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Provides total size and other information of RAG indexes used by knowledgebase documents</summary>
    public WithRawResponseTask<RagIndexOverviewResponseModel> RagIndexOverviewAsync(
        RagIndexOverviewAgentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<RagIndexOverviewResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.RagIndexOverviewAsync(
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Provides information about all RAG indexes of the specified knowledgebase document.</summary>
    public WithRawResponseTask<RagDocumentIndexesResponseModel> GetDocumentRagIndexesAsync(
        string documentationId,
        GetDocumentRagIndexesAgentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<RagDocumentIndexesResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetDocumentRagIndexesAsync(
                        documentationId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Delete RAG index for the knowledgebase document.</summary>
    public WithRawResponseTask<RagDocumentIndexResponseModel> DeleteDocumentRagIndexAsync(
        string documentationId,
        string ragIndexId,
        DeleteDocumentRagIndexAgentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<RagDocumentIndexResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.DeleteDocumentRagIndexAsync(
                        documentationId,
                        ragIndexId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
