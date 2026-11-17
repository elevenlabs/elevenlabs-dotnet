using System;
using System.Collections.Generic;
using System.Reflection;

namespace ElevenLabs.AgentWorkflows;

/// <summary>
/// Whether this SDK version's generated request model has a member for a node type. Read from the generated
/// discriminated union rather than listed here, so a regeneration that adds a node type is picked up without a
/// change to the builder.
/// </summary>
internal static class NodeTypes
{
    // The discriminant of each union member. The generated union exposes one public constructor per member,
    // taking a nested wrapper struct and setting the union's `Type` to that member's discriminant. Invoking
    // each with a default struct yields the discriminant without needing the member's required fields. A
    // deserialize-probe can't be used: unknown tags fall through to the converter's `object` branch (so they
    // look known), while known tags need fields the probe omits (so they look unknown).
    private static readonly HashSet<string> Known = BuildKnown();

    public static bool ModelKnows(string? nodeType) => nodeType != null && Known.Contains(nodeType);

    private static HashSet<string> BuildKnown()
    {
        var known = new HashSet<string>(StringComparer.Ordinal);
        var union = typeof(global::ElevenLabs.AgentWorkflowRequestModelNodes);
        foreach (var ctor in union.GetConstructors(BindingFlags.Public | BindingFlags.Instance))
        {
            var parameters = ctor.GetParameters();
            if (parameters.Length != 1)
            {
                continue;
            }
            var wrapper = parameters[0].ParameterType;
            if (wrapper.DeclaringType != union || !wrapper.IsValueType)
            {
                continue;
            }
            var instance =
                ctor.Invoke(new[] { Activator.CreateInstance(wrapper) })
                as global::ElevenLabs.AgentWorkflowRequestModelNodes;
            if (instance?.Type != null)
            {
                known.Add(instance.Type);
            }
        }
        return known;
    }
}
