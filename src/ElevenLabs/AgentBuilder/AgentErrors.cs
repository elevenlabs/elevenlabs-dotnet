using System;
using System.Collections.Generic;
using System.Linq;

namespace ElevenLabs.AgentBuilder;

/// <summary>Severity of an <see cref="AgentIssue"/>. Errors stop <c>Validate()</c> and <c>ToJson()</c>; warnings are passed to their callback.</summary>
public enum AgentSeverity
{
    Error,
    Warning,
}

/// <summary>
/// A problem found in an agent. The <see cref="Code"/> is one of the stable codes in the cross-SDK spec, for example
/// <c>"duplicate_tool_name"</c> or <c>"option_conflict"</c>.
/// </summary>
public sealed class AgentIssue
{
    public AgentIssue(string code, AgentSeverity severity, string message, string? path = null)
    {
        Code = code;
        Severity = severity;
        Message = message;
        Path = path;
    }

    public string Code { get; }
    public AgentSeverity Severity { get; }
    public string Message { get; }

    /// <summary>Where the problem is, e.g. <c>"tools.get_order"</c> or <c>"workflow"</c>.</summary>
    public string? Path { get; }

    public override string ToString() => $"{Severity}: {Code} ({Message})";
}

/// <summary>Thrown by <see cref="Agent.Validate"/>, <see cref="Agent.ToJson"/> and <see cref="Agent.Build"/> when the agent is invalid. Lists every problem found.</summary>
public sealed class AgentValidationException : Exception
{
    public AgentValidationException(string name, IReadOnlyList<AgentIssue> issues)
        : base($"Invalid agent \"{name}\":\n" + string.Join("\n", issues.Select(issue => "  - " + issue.Message)))
    {
        Issues = issues;
    }

    public IReadOnlyList<AgentIssue> Issues { get; }
}

/// <summary>What <c>Agents.PushAsync()</c> did to the agent.</summary>
public enum AgentPushAction
{
    Created,
    Updated,
}

/// <summary>
/// What <c>Agents.PushAsync()</c> did to one tool. <see cref="Detached"/>: the agent used it before and no longer
/// does; it isn't deleted.
/// </summary>
public enum ToolPushAction
{
    Created,
    Updated,
    Unchanged,
    Detached,
}

/// <summary>One tool <c>Agents.PushAsync()</c> touched: its id and what was done to it.</summary>
public sealed record ToolPushResult(string Id, ToolPushAction Action);

/// <summary>What <c>Agents.PushAsync()</c> did.</summary>
public sealed class AgentPushResult
{
    internal AgentPushResult(string agentId, AgentPushAction action, IReadOnlyDictionary<string, ToolPushResult> tools)
    {
        AgentId = agentId;
        Action = action;
        Tools = tools;
    }

    public string AgentId { get; }

    /// <summary>What happened to the agent: created, or updated in place.</summary>
    public AgentPushAction Action { get; }

    /// <summary>Each tool push touched, by name, in the order it got to them.</summary>
    public IReadOnlyDictionary<string, ToolPushResult> Tools { get; }
}

/// <summary>What <c>Agents.PushAsync()</c> wrote before it failed. <see cref="AgentId"/> and <see cref="Action"/> are set only if the agent was written.</summary>
public sealed class AgentPushPartialResult
{
    internal AgentPushPartialResult(string? agentId, AgentPushAction? action, IReadOnlyDictionary<string, ToolPushResult> tools)
    {
        AgentId = agentId;
        Action = action;
        Tools = tools;
    }

    public string? AgentId { get; }
    public AgentPushAction? Action { get; }
    public IReadOnlyDictionary<string, ToolPushResult> Tools { get; }
}

/// <summary>
/// Thrown by <c>Agents.PushAsync()</c> when an API call fails after it started. <see cref="Result"/> lists what was
/// written before the failure, so nothing created goes unreported; with a project, those ids are saved to it too.
/// The API error is the <see cref="Exception.InnerException"/>.
/// </summary>
public sealed class AgentPushException : Exception
{
    public AgentPushException(string message, AgentPushPartialResult result, Exception cause)
        : base($"{message}: {cause.Message}", cause)
    {
        Result = result;
    }

    public AgentPushPartialResult Result { get; }
}

/// <summary>Thrown when a project's files can't be read or written: a missing or malformed file, a path outside the project, or a format the SDK can't read yet.</summary>
public sealed class AgentProjectException : Exception
{
    public AgentProjectException(string message)
        : base(message) { }
}
