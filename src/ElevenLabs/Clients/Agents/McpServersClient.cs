using ElevenLabs;
using ElevenLabs.Agents.Conversations;
using ElevenLabs.Agents.Dashboard;
using ElevenLabs.Agents.KnowledgeBase;
using ElevenLabs.Agents.McpServers;
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
/// Fern-shape client for McpServersClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>IMcpServersClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class McpServersClient
{
    private readonly McpServersService _service;

    internal McpServersClient(global::ElevenLabs.Http.Client httpClient)
    {
        _service = new McpServersService(httpClient);
        Tools = new ElevenLabs.Agents.McpServers.ToolsClient(httpClient);
        ToolApprovals = new ToolApprovalsClient(httpClient);
        ToolConfigs = new ToolConfigsClient(httpClient);
    }

    public ElevenLabs.Agents.McpServers.IToolsClient Tools { get; }
    public IToolApprovalsClient ToolApprovals { get; }
    public IToolConfigsClient ToolConfigs { get; }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public IMcpServersClient SetConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ListAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IMcpServersClient SetListAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetListAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CreateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IMcpServersClient SetCreateAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetCreateAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IMcpServersClient SetGetAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetGetAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>UpdateAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IMcpServersClient SetUpdateAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetUpdateAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>DeleteAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IMcpServersClient SetDeleteAsyncConfig(global::ElevenLabs.Config.RequestConfig config)
    {
        _service.SetDeleteAsyncConfig(config);
        return this;
    }

    /// <summary>Retrieve all MCP server configurations available in the workspace.</summary>
    public WithRawResponseTask<McpServersResponseModel> ListAsync(
        ListMcpServersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<McpServersResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () => _service.ListAsync(request.XiApiKey, cancellationToken: cancellationToken)
            )
        );

    /// <summary>Create a new MCP server configuration in the workspace.</summary>
    public WithRawResponseTask<McpServerResponseModel> CreateAsync(
        CreateMcpServersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<McpServerResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.CreateAsync(
                        request.Body,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Retrieve a specific MCP server configuration from the workspace.</summary>
    public WithRawResponseTask<McpServerResponseModel> GetAsync(
        string mcpServerId,
        GetMcpServersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<McpServerResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetAsync(
                        mcpServerId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Update the configuration settings for an MCP server.</summary>
    public WithRawResponseTask<McpServerResponseModel> UpdateAsync(
        string mcpServerId,
        UpdateMcpServersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<McpServerResponseModel>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.UpdateAsync(
                        request.Body,
                        mcpServerId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Delete a specific MCP server configuration from the workspace.</summary>
    public WithRawResponseTask<object> DeleteAsync(
        string mcpServerId,
        DeleteMcpServersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<object>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.DeleteAsync(
                        mcpServerId,
                        request.XiApiKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
