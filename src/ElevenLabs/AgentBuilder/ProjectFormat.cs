using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using ElevenLabs.AgentWorkflows;

namespace ElevenLabs.AgentBuilder;

/// <summary>The ElevenLabs CLI's project file format and file naming.</summary>
internal static class ProjectFormat
{
    private static readonly JsonSerializerOptions ScalarOptions = new()
    {
        // As JavaScript's JSON.stringify writes strings: "+", "/", non-ASCII and the like unescaped.
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
    };

    /// <summary>The CLI's file format: 4-space indent, no trailing newline (serde_json's pretty printer, <c>JSON.stringify(v, null, 4)</c>).</summary>
    public static string FormatIndex(JsonNode? value)
    {
        var builder = new StringBuilder();
        Write(builder, value, 0);
        return builder.ToString();
    }

    /// <summary>Config files: like <see cref="FormatIndex"/>, with keys sorted at every level, as the CLI writes them.</summary>
    public static string FormatConfig(JsonNode? value) => FormatIndex(Wire.Canonicalize(value));

    private static void Write(StringBuilder builder, JsonNode? node, int depth)
    {
        switch (node)
        {
            case null:
                builder.Append("null");
                return;
            case JsonObject obj:
                if (obj.Count == 0)
                {
                    builder.Append("{}");
                    return;
                }
                builder.Append('{');
                var firstField = true;
                foreach (var field in obj)
                {
                    builder.Append(firstField ? "\n" : ",\n");
                    firstField = false;
                    Indent(builder, depth + 1);
                    builder.Append(JsonValue.Create(field.Key)!.ToJsonString(ScalarOptions)).Append(": ");
                    Write(builder, field.Value, depth + 1);
                }
                builder.Append('\n');
                Indent(builder, depth);
                builder.Append('}');
                return;
            case JsonArray arr:
                if (arr.Count == 0)
                {
                    builder.Append("[]");
                    return;
                }
                builder.Append('[');
                for (var i = 0; i < arr.Count; i++)
                {
                    builder.Append(i == 0 ? "\n" : ",\n");
                    Indent(builder, depth + 1);
                    Write(builder, arr[i], depth + 1);
                }
                builder.Append('\n');
                Indent(builder, depth);
                builder.Append(']');
                return;
            default:
                var value = (JsonValue)node;
                builder.Append(
                    value.GetValueKind() == JsonValueKind.Number
                        ? JsonNumber.ToJavaScript(value.ToJsonString())
                        : value.ToJsonString(ScalarOptions)
                );
                return;
        }
    }

    private static void Indent(StringBuilder builder, int depth) => builder.Append(' ', depth * 4);

    // JavaScript's \s and String.prototype.trim(): WhiteSpace and LineTerminator. Differs from char.IsWhiteSpace
    // on U+0085 (not whitespace here) and U+FEFF (whitespace here).
    private static bool IsWhiteSpace(string point) => point.Length == 1 && IsJsWhiteSpace(point[0]);

    private static bool IsJsWhiteSpace(char c) =>
        c == '\t' || c == '\n' || c == '\v' || c == '\f' || c == '\r' || c == ' '
        || (int)c is 0x00A0 or 0x1680 or 0x2028 or 0x2029 or 0x202F or 0x205F or 0x3000 or 0xFEFF
        || ((int)c >= 0x2000 && (int)c <= 0x200A);

    /// <summary>The CLI's <c>sanitize_filename</c>: a filesystem-safe file stem for an agent or tool name.</summary>
    public static string SanitizeFilename(string name)
    {
        var points = CodePoints(name);
        var start = 0;
        var end = points.Count;
        while (start < end && IsWhiteSpace(points[start]))
        {
            start++;
        }
        while (end > start && IsWhiteSpace(points[end - 1]))
        {
            end--;
        }
        if (start == end)
        {
            return "unnamed";
        }
        var trimmed = points.Skip(start).Take(end - start).ToList();
        var sanitized = string.Concat(
            trimmed.Select(point => IsWhiteSpace(point) || (point.Length == 1 && "/\\:*?\"<>|".IndexOf(point[0]) >= 0) ? "-" : point)
        );
        while (sanitized.Contains("--"))
        {
            sanitized = sanitized.Replace("--", "-");
        }
        var stripped = Regex.Replace(sanitized, "^[.-]+|[.-]+$", "");
        if (stripped.Length == 0)
        {
            return "unnamed";
        }
        var result = trimmed[0] == "." ? "_" + stripped : stripped;
        return string.Concat(CodePoints(result).Take(100));
    }

    /// <summary>The CLI's <c>generate_unique_filename</c>: <c>&lt;dir&gt;/&lt;name&gt;.json</c>, then <c>-1</c>, <c>-2</c>... while the path is taken.</summary>
    public static string UniquePath(string dir, string name, ISet<string> taken)
    {
        var stem = SanitizeFilename(name);
        var candidate = $"{dir}/{stem}.json";
        for (var n = 1; taken.Contains(candidate); n++)
        {
            candidate = $"{dir}/{stem}-{n.ToString(CultureInfo.InvariantCulture)}.json";
        }
        return candidate;
    }

    /// <summary>A project-relative path in one canonical spelling: forward slashes, no <c>./</c> or empty segments.</summary>
    public static string NormalizePath(string path) =>
        string.Join("/", path.Replace('\\', '/').Split('/').Where(part => part.Length > 0 && part != "."));

    /// <summary>The code points of a string, each as a string. A lone surrogate counts as one, as JavaScript's string iterator does.</summary>
    private static List<string> CodePoints(string text)
    {
        var points = new List<string>();
        for (var i = 0; i < text.Length; i++)
        {
            var pair = char.IsHighSurrogate(text[i]) && i + 1 < text.Length && char.IsLowSurrogate(text[i + 1]);
            points.Add(text.Substring(i, pair ? 2 : 1));
            if (pair)
            {
                i++;
            }
        }
        return points;
    }
}
