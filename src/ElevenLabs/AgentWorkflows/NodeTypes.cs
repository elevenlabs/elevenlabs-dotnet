using System.Collections.Concurrent;
using ElevenLabs.Core;

namespace ElevenLabs.AgentWorkflows;

/// <summary>
/// Whether this SDK version's generated request model has a member for a node type. Probed from the generated
/// discriminated union rather than listed here, so a regeneration that adds a node type is picked up without a
/// change to the builder.
/// </summary>
internal static class NodeTypes
{
    private static readonly ConcurrentDictionary<string, bool> Cache = new();

    public static bool ModelKnows(string? nodeType)
    {
        if (nodeType == null)
        {
            return false;
        }
        return Cache.GetOrAdd(
            nodeType,
            type =>
                JsonUtils.TryDeserialize<AgentWorkflowRequestModelNodes>(
                    $"{{\"type\":\"{type}\"}}",
                    out _
                )
        );
    }
}
