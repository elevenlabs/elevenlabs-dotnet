using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace ElevenLabs.AgentWorkflows;

/// <summary>
/// Helpers for the wire representation. The builder keeps its state in API wire format (snake_case keys, as the
/// REST API and the CLI's <c>agent_configs/*.json</c> use them), stored as <see cref="JsonNode"/> trees.
/// </summary>
internal static class Wire
{
    private static readonly JsonSerializerOptions CanonicalOptions = new()
    {
        WriteIndented = true,
        // Match JavaScript's JSON.stringify / Python's ensure_ascii=False: leave "+", "/", non-ASCII and the
        // like unescaped, so phone numbers and SIP URIs come out byte-for-byte as the other SDKs emit them.
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
    };

    /// <summary>A detached deep copy, or <c>null</c>.</summary>
    public static JsonNode? Clone(JsonNode? node) => node?.DeepClone();

    /// <summary>
    /// Sorts object keys at every level (ordinal), returning a fresh, detached tree. Arrays keep their order.
    /// This is what makes the JSON match every other SDK's byte for byte.
    /// </summary>
    public static JsonNode? Canonicalize(JsonNode? node)
    {
        switch (node)
        {
            case JsonObject obj:
            {
                var result = new JsonObject();
                foreach (var key in obj.Select(kv => kv.Key).OrderBy(k => k, System.StringComparer.Ordinal))
                {
                    result[key] = Canonicalize(obj[key]);
                }
                return result;
            }
            case JsonArray arr:
            {
                var list = new JsonArray();
                foreach (var item in arr)
                {
                    list.Add(Canonicalize(item));
                }
                return list;
            }
            default:
                return node?.DeepClone();
        }
    }

    /// <summary>The canonical file format: sorted keys, 2-space indentation, trailing newline.</summary>
    public static string ToCanonicalString(JsonObject obj)
    {
        var canonical = Canonicalize(obj)!;
        return canonical.ToJsonString(CanonicalOptions) + "\n";
    }

    /// <summary>Reads a numeric node as a double, whatever the backing CLR type.</summary>
    public static double AsDouble(JsonNode node)
    {
        if (node is JsonValue value)
        {
            if (value.TryGetValue<double>(out var d))
            {
                return d;
            }
            if (value.TryGetValue<long>(out var l))
            {
                return l;
            }
            if (value.TryGetValue<int>(out var i))
            {
                return i;
            }
        }
        return node.GetValue<double>();
    }
}
