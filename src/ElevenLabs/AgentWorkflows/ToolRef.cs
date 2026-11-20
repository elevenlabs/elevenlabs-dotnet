using System;

namespace ElevenLabs.AgentWorkflows;

// Inside the namespace, so it wins over the generated ElevenLabs.Tool model.
using Tool = ElevenLabs.AgentTools.Tool;

/// <summary>
/// A tool a workflow node uses: the id of an existing tool, or a <see cref="AgentTools.Tool"/> object whose id is
/// filled in when the workflow is built with <c>toolIds</c>, as <c>Agents.PushAsync()</c> does. Strings and
/// <c>Tool</c> objects convert to it implicitly, so a node can mix both:
/// <c>new ToolRef[] { getOrder, "tool_123" }</c>.
/// </summary>
/// <remarks>
/// Until the workflow is built, a <c>Tool</c> object stands in the node under the placeholder
/// <c>&lt;tool:NAME&gt;</c>.
/// </remarks>
public readonly struct ToolRef
{
    private ToolRef(string? id, Tool? tool)
    {
        Id = id;
        Tool = tool;
    }

    /// <summary>The tool's id, when this refers to an existing tool by id.</summary>
    public string? Id { get; }

    /// <summary>The <c>Tool</c> object, when this refers to one.</summary>
    public Tool? Tool { get; }

    /// <summary>An existing tool, by id.</summary>
    public static ToolRef ForId(string id) =>
        new(id ?? throw new ArgumentNullException(nameof(id)), null);

    /// <summary>A <c>Tool</c> object, whose id is filled in at build time.</summary>
    public static ToolRef For(Tool tool) => new(null, tool ?? throw new ArgumentNullException(nameof(tool)));

    public static implicit operator ToolRef(string id) => ForId(id);

    public static implicit operator ToolRef(Tool tool) => For(tool);

    public override string ToString() => Tool != null ? $"<tool:{Tool.Name}>" : Id ?? "";
}
