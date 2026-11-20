using global::System.Threading;
using global::System.Threading.Tasks;
using ElevenLabs.AgentBuilder;

namespace ElevenLabs;

// Hand-written (listed in .fernignore). Adds PushAsync and PullAsync to the generated, partial AgentsClient and its
// interface, so agents as code is reachable as client.Agents.PushAsync(agent), matching agents.push in the JS and
// Python SDKs. The steps live in AgentPush (AgentBuilder/AgentPush.cs) and run over the generated Agents and
// Agents.Tools methods, so per-call RequestOptions, retries and error types are the generated client's own.

public partial interface IAgentsClient
{
    /// <summary>
    /// Creates or updates an agent and every webhook and client tool it uses, in one call.
    /// </summary>
    /// <remarks>
    /// <list type="number">
    /// <item>Validates the agent, so an invalid one writes nothing.</item>
    /// <item>
    /// Creates each tool that's new and updates each one that changed. Which tools already exist comes from the
    /// project's <c>tools.json</c>, or, without a project, from the tools the agent (<c>AgentId</c>) already uses, by
    /// name: on its main branch, or on <c>BranchId</c> when given. Tools other agents use are never touched.
    /// </item>
    /// <item>Creates the agent, or updates it, with the tools' ids filled in.</item>
    /// </list>
    /// Settings the SDK doesn't model, kept from a loaded config, are sent too. Tools the agent stops using are
    /// reported as <see cref="ToolPushAction.Detached"/>, not deleted. With a project opened from a directory, the
    /// project is saved, also when a request fails partway.
    /// </remarks>
    /// <param name="agent">The agent to push.</param>
    /// <param name="pushOptions">The agent id or project, and the branch and version description.</param>
    /// <param name="options">
    /// Applied to every request push makes, except <see cref="RequestOptions.AdditionalBodyProperties"/>, which push
    /// sets itself to send the full config.
    /// </param>
    /// <param name="cancellationToken">Cancels the push. A project opened from a directory is still saved.</param>
    /// <exception cref="AgentValidationException">The agent is invalid. Thrown before any request.</exception>
    /// <exception cref="AgentPushException">A request failed. Its <c>Result</c> lists what was already written.</exception>
    /// <exception cref="AgentProjectException">The project can't place the agent (an unknown branch, or two entries with its name).</exception>
    Task<AgentPushResult> PushAsync(
        Agent agent,
        AgentPushOptions? pushOptions = null,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Loads an existing agent as an <see cref="Agent"/>, with its webhook and client tools as <c>Tool</c> objects.
    /// With a project, also writes the agent and its tools there, in the CLI's layout, and records their ids.
    /// </summary>
    /// <param name="agentId">The agent to pull.</param>
    /// <param name="pullOptions">The project to write into, and the branch to pull.</param>
    /// <param name="options">Applied to every request pull makes.</param>
    /// <param name="cancellationToken">Cancels the pull.</param>
    Task<Agent> PullAsync(
        string agentId,
        AgentPullOptions? pullOptions = null,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

public partial class AgentsClient
{
    /// <inheritdoc />
    public Task<AgentPushResult> PushAsync(
        Agent agent,
        AgentPushOptions? pushOptions = null,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) => AgentPush.PushAsync(this, Tools, agent, pushOptions ?? new AgentPushOptions(), options, cancellationToken);

    /// <inheritdoc />
    public Task<Agent> PullAsync(
        string agentId,
        AgentPullOptions? pullOptions = null,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) => AgentPush.PullAsync(this, Tools, agentId, pullOptions ?? new AgentPullOptions(), options, cancellationToken);
}
