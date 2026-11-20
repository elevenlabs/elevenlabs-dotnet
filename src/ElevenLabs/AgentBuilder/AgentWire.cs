using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Nodes;
using ElevenLabs.AgentWorkflows;

namespace ElevenLabs.AgentBuilder;

/// <summary>Helpers for agent configs in API format (snake_case JSON), held as <see cref="JsonNode"/> trees.</summary>
internal static class AgentWire
{
    public static readonly string[] ToolIdsPath = { "conversation_config", "agent", "prompt", "tool_ids" };
    public static readonly string[] BuiltInToolsPath = { "conversation_config", "agent", "prompt", "built_in_tools" };

    /// <summary>The value at <paramref name="path"/>, or <c>null</c> if any step is missing.</summary>
    public static JsonNode? GetPath(JsonNode? target, IEnumerable<string> path)
    {
        var current = target;
        foreach (var key in path)
        {
            if (current is not JsonObject obj)
            {
                return null;
            }
            current = obj[key];
        }
        return current;
    }

    /// <summary>Whether the value at <paramref name="path"/> is set, to anything but <c>null</c>.</summary>
    public static bool HasPath(JsonNode? target, IEnumerable<string> path) => GetPath(target, path) != null;

    /// <summary>Sets the value at <paramref name="path"/>, creating objects along the way. <c>null</c> removes the key.</summary>
    public static void SetPath(JsonObject target, IReadOnlyList<string> path, JsonNode? value)
    {
        var current = target;
        for (var i = 0; i < path.Count - 1; i++)
        {
            if (current[path[i]] is not JsonObject next)
            {
                if (value == null)
                {
                    return;
                }
                next = new JsonObject();
                current[path[i]] = next;
            }
            current = next;
        }
        var last = path[path.Count - 1];
        if (value == null)
        {
            current.Remove(last);
        }
        else
        {
            current[last] = value.Parent == null ? value : value.DeepClone();
        }
    }

    /// <summary>Merges <paramref name="source"/> into <paramref name="target"/>: objects merge key by key, anything else (arrays included) replaces.</summary>
    public static JsonObject DeepMerge(JsonObject target, JsonObject source)
    {
        foreach (var field in source)
        {
            if (field.Value is JsonObject value && target[field.Key] is JsonObject existing)
            {
                DeepMerge(existing, value);
            }
            else
            {
                target[field.Key] = field.Value?.DeepClone();
            }
        }
        return target;
    }

    /// <summary>
    /// Whether every value in <paramref name="local"/> is in <paramref name="remote"/> at the same place. Extra keys
    /// in <paramref name="remote"/> (server defaults) are fine, and so is a local <c>null</c> property.
    /// </summary>
    public static bool IsSubset(JsonNode? local, JsonNode? remote)
    {
        switch (local)
        {
            case JsonArray localArr:
                return remote is JsonArray remoteArr
                    && localArr.Count == remoteArr.Count
                    && localArr.Select((item, i) => IsSubset(item, remoteArr[i])).All(same => same);
            case JsonObject localObj:
                return remote is JsonObject remoteObj
                    && localObj.All(field => field.Value == null || IsSubset(field.Value, remoteObj[field.Key]));
            case null:
                return remote == null;
            default:
                return remote is JsonValue && ScalarEquals((JsonValue)local, (JsonValue)remote);
        }
    }

    private static bool ScalarEquals(JsonValue a, JsonValue b)
    {
        var kind = a.GetValueKind();
        if (kind != b.GetValueKind())
        {
            return false;
        }
        return kind == JsonValueKind.Number ? Wire.AsDouble(a) == Wire.AsDouble(b) : a.ToJsonString() == b.ToJsonString();
    }

    /// <summary>The tool ids an API-format workflow's nodes use: tool nodes' tools and subagents' extra tools.</summary>
    public static List<string> RawWorkflowToolIds(JsonObject? workflow)
    {
        var ids = new List<string>();
        if (workflow?["nodes"] is not JsonObject nodes)
        {
            return ids;
        }
        foreach (var node in nodes)
        {
            if (node.Value is not JsonObject model)
            {
                continue;
            }
            if (model["tools"] is JsonArray tools)
            {
                foreach (var tool in tools)
                {
                    if (tool is JsonObject locator && Str(locator["tool_id"]) is string id)
                    {
                        ids.Add(id);
                    }
                }
            }
            if (model["additional_tool_ids"] is JsonArray extra)
            {
                ids.AddRange(extra.Select(Str).OfType<string>());
            }
        }
        return ids;
    }

    /// <summary>Replaces the tool ids in an API-format workflow's tool nodes and subagents, in place.</summary>
    public static JsonObject MapRawWorkflowToolIds(JsonObject workflow, Func<string, string> map)
    {
        if (workflow["nodes"] is not JsonObject nodes)
        {
            return workflow;
        }
        foreach (var node in nodes)
        {
            if (node.Value is not JsonObject model)
            {
                continue;
            }
            if (model["tools"] is JsonArray tools)
            {
                foreach (var tool in tools)
                {
                    if (tool is JsonObject locator && Str(locator["tool_id"]) is string id)
                    {
                        locator["tool_id"] = map(id);
                    }
                }
            }
            if (model["additional_tool_ids"] is JsonArray extra)
            {
                for (var i = 0; i < extra.Count; i++)
                {
                    if (Str(extra[i]) is string id)
                    {
                        extra[i] = map(id);
                    }
                }
            }
        }
        return workflow;
    }

    /// <summary>Every tool id an agent config uses, in its <c>tool_ids</c> and its workflow's nodes, once each, in order.</summary>
    public static List<string> ToolIdsIn(JsonObject config)
    {
        var ids = new List<string>();
        if (GetPath(config, ToolIdsPath) is JsonArray promptIds)
        {
            ids.AddRange(promptIds.Select(Str).OfType<string>());
        }
        ids.AddRange(RawWorkflowToolIds(config["workflow"] as JsonObject));
        return ids.Distinct().ToList();
    }

    public static string? Str(JsonNode? node) =>
        node is JsonValue value && value.GetValueKind() == JsonValueKind.String ? value.GetValue<string>() : null;

    public static List<string> StrList(JsonNode? node) =>
        node is JsonArray arr ? arr.Select(Str).OfType<string>().ToList() : new List<string>();
}

/// <summary>Compares by reference, for keying on builder objects. <c>ReferenceEqualityComparer</c> isn't in netstandard2.0.</summary>
internal sealed class ReferenceComparer<T> : IEqualityComparer<T>
    where T : class
{
    public static readonly ReferenceComparer<T> Instance = new();

    public bool Equals(T? x, T? y) => ReferenceEquals(x, y);

    public int GetHashCode(T obj) => RuntimeHelpers.GetHashCode(obj);
}
