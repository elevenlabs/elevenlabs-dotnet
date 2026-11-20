using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using ElevenLabs.Agents;
using ElevenLabs.AgentTools;
using ElevenLabs.AgentWorkflows;
using ElevenLabs.Core;

namespace ElevenLabs.AgentBuilder;

// Inside the namespace, so it wins over the generated ElevenLabs.Tool model.
using Tool = ElevenLabs.AgentTools.Tool;

/// <summary>Options for <c>Agents.PushAsync()</c>.</summary>
public sealed class AgentPushOptions
{
    /// <summary>
    /// The agent to update. Without it (and without a project that knows the agent), push creates a new agent, so
    /// keep the returned <see cref="AgentPushResult.AgentId"/>. Not allowed with <see cref="Project"/>, which records
    /// the id itself.
    /// </summary>
    public string? AgentId { get; set; }

    /// <summary>
    /// An agents-as-code project in the CLI's layout. Its <c>agents.json</c> and <c>tools.json</c> say which agent and
    /// tools on the server this definition is; push records new ids there and writes the configs it sent.
    /// </summary>
    public AgentProject? Project { get; set; }

    /// <summary>Update this branch of the agent instead of its main branch.</summary>
    public string? BranchId { get; set; }

    /// <summary>Describes the new version, for agents with versioning.</summary>
    public string? VersionDescription { get; set; }
}

/// <summary>Options for <c>Agents.PullAsync()</c>.</summary>
public sealed class AgentPullOptions
{
    /// <summary>Writes the agent and its tools into this project, and records their ids.</summary>
    public AgentProject? Project { get; set; }

    /// <summary>Pull this branch instead of the main one.</summary>
    public string? BranchId { get; set; }
}

/// <summary>The steps of <c>Agents.PushAsync()</c> and <c>Agents.PullAsync()</c>, over the generated agents and tools clients.</summary>
internal static class AgentPush
{
    public static async Task<AgentPushResult> PushAsync(
        IAgentsClient agents,
        IToolsClient toolsClient,
        Agent agent,
        AgentPushOptions options,
        RequestOptions? requestOptions,
        CancellationToken cancellationToken
    )
    {
        if (agent == null)
        {
            throw new ArgumentNullException(nameof(agent));
        }
        var project = options.Project;
        var branchId = options.BranchId;
        if (project != null && options.AgentId != null)
        {
            throw new ArgumentException(
                "Pass AgentId or Project to Agents.PushAsync(), not both: the project records the agent's id",
                nameof(options)
            );
        }
        agent.Validate();
        project?.CheckBranch(agent, branchId);

        var tools = agent.Tools();
        var agentId = project != null ? project.GetAgentId(agent) : options.AgentId;
        var results = new Dictionary<string, ToolPushResult>();
        var ids = new Dictionary<string, string>();
        string? pushedId = null;
        AgentPushAction? action = null;
        var step = "Couldn't read the agent's tools";
        try
        {
            // The tools the agent already uses. With a project they're matched by recorded id; without one, by name
            // among the tools this agent uses, so a same-named tool another agent uses is never touched.
            var inUse =
                agentId == null ? new List<ToolResponseModel>()
                : branchId != null
                    ? await ToolsOnBranchAsync(agents, toolsClient, agentId, branchId, requestOptions, cancellationToken)
                        .ConfigureAwait(false)
                : await ListToolsUsedByAsync(toolsClient, agentId, requestOptions, cancellationToken).ConfigureAwait(false);
            var usedByName = new Dictionary<string, ToolResponseModel>();
            foreach (var remote in inUse)
            {
                usedByName[ToolName(remote)] = remote;
            }

            foreach (var tool in tools)
            {
                var knownId =
                    project != null ? project.GetToolId(tool)
                    : usedByName.TryGetValue(tool.Name, out var used) ? used.Id
                    : null;
                ToolResponseModel? remote = null;
                if (knownId != null)
                {
                    step = $"Couldn't read tool \"{tool.Name}\" ({knownId})";
                    remote =
                        inUse.FirstOrDefault(t => t.Id == knownId)
                        ?? await toolsClient
                            .GetAsync(knownId, new GetToolsRequest(), requestOptions, cancellationToken)
                            .ConfigureAwait(false);
                }
                var config = project?.UnchangedRaw(tool) ?? tool.ToJson();
                var body = WithBody(requestOptions, new JsonObject { ["tool_config"] = config.DeepClone() });
                if (remote != null && SameTool(remote, tool, config))
                {
                    ids[tool.Name] = remote.Id;
                    results[tool.Name] = new ToolPushResult(remote.Id, ToolPushAction.Unchanged);
                    // The server already matches, but the project may hold an older definition: bring it up to date.
                    project?.RecordTool(tool, remote.Id, config);
                    continue;
                }
                var typed = TypedToolRequest(tool, config);
                if (remote != null)
                {
                    step = $"Couldn't update tool \"{tool.Name}\" ({remote.Id})";
                    await toolsClient
                        .UpdateAsync(remote.Id, new UpdateToolsRequest { Body = typed }, body, cancellationToken)
                        .ConfigureAwait(false);
                    ids[tool.Name] = remote.Id;
                    results[tool.Name] = new ToolPushResult(remote.Id, ToolPushAction.Updated);
                }
                else
                {
                    step = $"Couldn't create tool \"{tool.Name}\"";
                    var created = await toolsClient
                        .CreateAsync(new CreateToolsRequest { Body = typed }, body, cancellationToken)
                        .ConfigureAwait(false);
                    ids[tool.Name] = created.Id;
                    results[tool.Name] = new ToolPushResult(created.Id, ToolPushAction.Created);
                }
                project?.RecordTool(tool, ids[tool.Name], config);
            }

            // The typed body goes through the generated client; the API-format config, sent as additional body
            // properties, fills in fields the generated model doesn't know, so settings this SDK doesn't model reach
            // the API too.
            var agentConfig = agent.ToJson(ids);

            // Every id the new config still uses, wherever it is: the agent's tool_ids and the workflow's nodes.
            var kept = new HashSet<string>(AgentWire.ToolIdsIn(agentConfig));
            foreach (var remote in inUse)
            {
                var name = ToolName(remote);
                if (!kept.Contains(remote.Id) && !results.ContainsKey(name))
                {
                    results[name] = new ToolPushResult(remote.Id, ToolPushAction.Detached);
                }
            }

            string? versionId = null;
            if (agentId == null)
            {
                step = $"Couldn't create agent \"{agent.Name}\"";
                var created = await agents
                    .CreateAsync(
                        new CreateAgentsRequest
                        {
                            Body = JsonUtils.Deserialize<BodyCreateAgentV1ConvaiAgentsCreatePost>(agentConfig.ToJsonString()),
                        },
                        WithBody(requestOptions, agentConfig),
                        cancellationToken
                    )
                    .ConfigureAwait(false);
                pushedId = created.AgentId;
                action = AgentPushAction.Created;
            }
            else
            {
                step = $"Couldn't update agent \"{agent.Name}\" ({agentId})";
                var update = (JsonObject)agentConfig.DeepClone();
                if (options.VersionDescription != null)
                {
                    update["version_description"] = options.VersionDescription;
                }
                var updated = await agents
                    .UpdateAsync(
                        agentId,
                        new UpdateAgentsRequest
                        {
                            BranchId = branchId,
                            Body = JsonUtils.Deserialize<UpdateAgentRequest>(update.ToJsonString()),
                        },
                        WithBody(requestOptions, update),
                        cancellationToken
                    )
                    .ConfigureAwait(false);
                versionId = updated.VersionId;
                pushedId = agentId;
                action = AgentPushAction.Updated;
            }
            project?.RecordAgent(agent, pushedId, agentConfig, branchId, versionId);
        }
        catch (Exception ex)
        {
            SaveQuietly(project);
            if (ex is OperationCanceledException && cancellationToken.IsCancellationRequested)
            {
                throw;
            }
            throw new AgentPushException(step, new AgentPushPartialResult(pushedId, action, results), ex);
        }
        if (project?.OpenedFromDirectory == true)
        {
            project.Save();
        }
        return new AgentPushResult(pushedId!, action!.Value, results);
    }

    public static async Task<Agent> PullAsync(
        IAgentsClient agents,
        IToolsClient toolsClient,
        string agentId,
        AgentPullOptions options,
        RequestOptions? requestOptions,
        CancellationToken cancellationToken
    )
    {
        if (agentId == null)
        {
            throw new ArgumentNullException(nameof(agentId));
        }
        var project = options.Project;
        var branchId = options.BranchId;
        project?.CheckBranchById(agentId, branchId);
        var response = await agents
            .GetAsync(agentId, new GetAgentsRequest { BranchId = branchId }, requestOptions, cancellationToken)
            .ConfigureAwait(false);
        var live = JsonUtils.SerializeToNode(response) as JsonObject ?? new JsonObject();
        // The CLI's pulled-config shape: these keys only, so ids and server metadata stay out of the file.
        var config = new JsonObject
        {
            ["name"] = live["name"]?.DeepClone(),
            ["conversation_config"] = live["conversation_config"]?.DeepClone() ?? new JsonObject(),
            ["platform_settings"] = live["platform_settings"]?.DeepClone() ?? new JsonObject(),
            ["tags"] = live["tags"]?.DeepClone() ?? new JsonArray(),
        };
        if (live["workflow"] is JsonObject workflow)
        {
            config["workflow"] = workflow.DeepClone();
        }

        var toolsById = new Dictionary<string, Tool>();
        var toolOrder = new List<string>();
        var toolConfigs = new Dictionary<string, JsonObject>();
        foreach (var id in AgentWire.ToolIdsIn(config))
        {
            var remote = await toolsClient
                .GetAsync(id, new GetToolsRequest(), requestOptions, cancellationToken)
                .ConfigureAwait(false);
            var wire = JsonUtils.SerializeToNode(remote.ToolConfig) as JsonObject ?? new JsonObject();
            var tool = Tool.FromJson(wire);
            // tools.json lists webhook and client tools; others (MCP...) stay attached by id.
            if (tool.Kind is ToolKind.Webhook or ToolKind.Client)
            {
                toolsById[id] = tool;
                toolOrder.Add(id);
                toolConfigs[id] = (JsonObject)Wire.Canonicalize(wire)!;
            }
        }

        var agent = Agent.FromJson(config, toolsById);
        if (project != null)
        {
            foreach (var id in toolOrder)
            {
                project.RecordTool(toolsById[id], id, toolConfigs[id], matchById: true);
            }
            project.RecordAgent(agent, agentId, config, branchId, response.VersionId, matchById: true);
            if (project.OpenedFromDirectory)
            {
                project.Save();
            }
        }
        return agent;
    }

    /// <summary>
    /// The tools a branch of the agent uses. The tools API's <c>used_by_agent_id</c> covers the main branch only, so
    /// they come from the branch's config, by id.
    /// </summary>
    private static async Task<List<ToolResponseModel>> ToolsOnBranchAsync(
        IAgentsClient agents,
        IToolsClient toolsClient,
        string agentId,
        string branchId,
        RequestOptions? requestOptions,
        CancellationToken cancellationToken
    )
    {
        var branch = await agents
            .GetAsync(agentId, new GetAgentsRequest { BranchId = branchId }, requestOptions, cancellationToken)
            .ConfigureAwait(false);
        var wire = JsonUtils.SerializeToNode(branch) as JsonObject ?? new JsonObject();
        var tools = new List<ToolResponseModel>();
        foreach (var id in AgentWire.ToolIdsIn(wire))
        {
            tools.Add(
                await toolsClient.GetAsync(id, new GetToolsRequest(), requestOptions, cancellationToken).ConfigureAwait(false)
            );
        }
        return tools;
    }

    private static async Task<List<ToolResponseModel>> ListToolsUsedByAsync(
        IToolsClient toolsClient,
        string agentId,
        RequestOptions? requestOptions,
        CancellationToken cancellationToken
    )
    {
        var all = new List<ToolResponseModel>();
        string? cursor = null;
        do
        {
            var page = await toolsClient
                .ListAsync(
                    new ListToolsRequest { UsedByAgentId = agentId, PageSize = 100, Cursor = cursor },
                    requestOptions,
                    cancellationToken
                )
                .ConfigureAwait(false);
            all.AddRange(page.Tools);
            cursor = page.HasMore ? page.NextCursor : null;
        } while (cursor != null);
        return all;
    }

    private static string ToolName(ToolResponseModel remote) =>
        AgentWire.Str((JsonUtils.SerializeToNode(remote.ToolConfig) as JsonObject)?["name"]) ?? remote.Id;

    /// <summary>
    /// The typed request for a tool: <paramref name="config"/> parsed into the generated model, which keeps fields
    /// it doesn't know, or the tool's own <c>Build()</c> when the model can't carry it exactly.
    /// </summary>
    private static ToolRequestModel TypedToolRequest(Tool tool, JsonObject config)
    {
        try
        {
            return JsonUtils.Deserialize<ToolRequestModel>(new JsonObject { ["tool_config"] = config.DeepClone() }.ToJsonString());
        }
        catch (Exception)
        {
            return tool.Build();
        }
    }

    /// <summary>
    /// Whether the server already has this tool as defined. Modeled fields are compared through the builder, so both
    /// sides normalize alike; the config to send must also be contained in the server's, so a change to a field the
    /// builder doesn't model still counts.
    /// </summary>
    private static bool SameTool(ToolResponseModel remote, Tool tool, JsonObject config)
    {
        try
        {
            var wire = (JsonObject)JsonUtils.SerializeToNode(remote.ToolConfig)!;
            return ToolComparison.Modeled(wire) == ToolComparison.ModeledJson(tool) && AgentWire.IsSubset(config, wire);
        }
        catch (Exception)
        {
            return false;
        }
    }

    /// <summary>
    /// <paramref name="options"/> with <paramref name="body"/> as its additional body properties: the request body is
    /// the typed model with the API-format config merged over it, so it's exactly the config.
    /// </summary>
    private static RequestOptions WithBody(RequestOptions? options, JsonObject body) =>
        new()
        {
            BaseUrl = options?.BaseUrl,
            HttpClient = options?.HttpClient,
            AdditionalHeaders = options?.AdditionalHeaders ?? new List<KeyValuePair<string, string?>>(),
            MaxRetries = options?.MaxRetries,
            Retry = options?.Retry,
            Timeout = options?.Timeout,
            AdditionalQueryParameters =
                options?.AdditionalQueryParameters ?? Enumerable.Empty<KeyValuePair<string, string>>(),
            AdditionalBodyProperties = body,
        };

    private static void SaveQuietly(AgentProject? project)
    {
        if (project?.OpenedFromDirectory != true)
        {
            return;
        }
        try
        {
            project.Save();
        }
        catch (Exception)
        {
            // The push error is the one to report; the ids it carries are in the thrown result.
        }
    }
}
