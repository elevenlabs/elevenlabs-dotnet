using System;
using System.Collections.Generic;
using System.Linq;

namespace ElevenLabs.AgentTools;

/// <summary>Severity of a <see cref="ToolIssue"/>. Errors stop <c>Build()</c>; warnings are passed to its callback.</summary>
public enum ToolSeverity
{
    Error,
    Warning,
}

/// <summary>
/// A problem found in a tool. The <see cref="Code"/> is one of the stable codes in the cross-SDK spec, for example
/// <c>"missing_url"</c> or <c>"missing_value_source"</c>.
/// </summary>
public sealed class ToolIssue
{
    public ToolIssue(string code, ToolSeverity severity, string message, string? path = null)
    {
        Code = code;
        Severity = severity;
        Message = message;
        Path = path;
    }

    public string Code { get; }
    public ToolSeverity Severity { get; }
    public string Message { get; }

    /// <summary>Where the problem is, e.g. <c>"body.reason"</c> or <c>"pathParams.order_id"</c>.</summary>
    public string? Path { get; }

    public override string ToString() => $"{Severity}: {Code} ({Message})";
}

/// <summary>Thrown by a tool's <c>Build()</c>, <c>BuildConfig()</c> and <c>ToJson()</c> when the tool is invalid. Lists every problem found.</summary>
public sealed class ToolValidationException : Exception
{
    public ToolValidationException(string name, IReadOnlyList<ToolIssue> issues)
        : base($"Invalid tool \"{name}\":\n" + string.Join("\n", issues.Select(issue => "  - " + issue.Message)))
    {
        Issues = issues;
    }

    public IReadOnlyList<ToolIssue> Issues { get; }
}
