using System;
using System.Collections.Generic;
using System.Linq;

namespace ElevenLabs.AgentWorkflows;

/// <summary>Severity of a <see cref="WorkflowIssue"/>. Errors stop <c>Build()</c>; warnings are passed to its callback.</summary>
public enum WorkflowSeverity
{
    Error,
    Warning,
}

/// <summary>
/// A problem found in a workflow. The <see cref="Code"/> is one of the stable codes in the cross-SDK spec, for
/// example <c>"duplicate_node_id"</c> or <c>"unreachable_node"</c>.
/// </summary>
public sealed class WorkflowIssue
{
    public WorkflowIssue(string code, WorkflowSeverity severity, string message, string? nodeId = null)
    {
        Code = code;
        Severity = severity;
        Message = message;
        NodeId = nodeId;
    }

    public string Code { get; }
    public WorkflowSeverity Severity { get; }
    public string Message { get; }
    public string? NodeId { get; }

    public override string ToString() => $"{Severity}: {Code} ({Message})";
}

/// <summary>Thrown by <see cref="Workflow.Build"/> and <see cref="Workflow.ToJson"/> when the workflow is invalid. Lists every problem found.</summary>
public sealed class WorkflowValidationException : Exception
{
    public WorkflowValidationException(IReadOnlyList<WorkflowIssue> issues)
        : base("Invalid workflow:\n" + string.Join("\n", issues.Select(issue => "  - " + issue.Message)))
    {
        Issues = issues;
    }

    public IReadOnlyList<WorkflowIssue> Issues { get; }
}
