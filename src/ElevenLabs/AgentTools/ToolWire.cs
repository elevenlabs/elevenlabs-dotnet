using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace ElevenLabs.AgentTools;

/// <summary>
/// Helpers for the tool builder's wire representation. Like the workflow builder, it keeps its state in API wire
/// format (snake_case keys) as <see cref="JsonNode"/> trees; canonical output goes through the workflow builder's
/// <c>Wire</c> writer.
/// </summary>
internal static class ToolWire
{
    // Values whose contents are arbitrary user JSON: nulls inside them are data, not API defaults.
    private static readonly HashSet<string> OpaqueKeys = new() { "constant_value", "dynamic_variable_placeholders" };

    /// <summary>
    /// A detached deep copy with every <c>null</c>-valued property removed, since the API sends <c>null</c> for some
    /// unset fields and the spec reads them as absent. Arrays keep their elements, and the contents of a constant or
    /// a placeholder map are copied unchanged.
    /// </summary>
    public static JsonObject WithoutNulls(JsonObject obj)
    {
        var result = new JsonObject();
        foreach (var field in obj)
        {
            if (field.Value == null)
            {
                continue;
            }
            result[field.Key] = OpaqueKeys.Contains(field.Key) ? field.Value.DeepClone() : StripNulls(field.Value);
        }
        return result;
    }

    private static JsonNode StripNulls(JsonNode node)
    {
        switch (node)
        {
            case JsonObject obj:
                return WithoutNulls(obj);
            case JsonArray arr:
            {
                var list = new JsonArray();
                foreach (var item in arr)
                {
                    list.Add(item == null ? null : StripNulls(item));
                }
                return list;
            }
            default:
                return node.DeepClone();
        }
    }

    /// <summary>The string value of <paramref name="node"/>, or <c>null</c> if it isn't a JSON string.</summary>
    public static string? Str(JsonNode? node) =>
        node is JsonValue value && value.GetValueKind() == JsonValueKind.String ? value.GetValue<string>() : null;

    /// <summary>The string elements of a JSON array (others written as JSON), or <c>null</c> if it isn't an array.</summary>
    public static List<string>? StrList(JsonNode? node) =>
        node is JsonArray arr ? arr.Select(item => Str(item) ?? item?.ToJsonString() ?? "null").ToList() : null;

    public static JsonArray ToArray(IEnumerable<string> values)
    {
        var arr = new JsonArray();
        foreach (var value in values)
        {
            arr.Add(value);
        }
        return arr;
    }

    public static bool IsTrue(JsonNode? node) => node is JsonValue value && value.GetValueKind() == JsonValueKind.True;

    public static bool IsNumber(JsonNode? node) =>
        node is JsonValue value && value.GetValueKind() == JsonValueKind.Number;

    public static bool IsEmptyString(JsonNode? node) => Str(node) == "";
}
