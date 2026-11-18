using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using ElevenLabs.AgentWorkflows;

namespace ElevenLabs.AgentTools;

internal static class ToolValidation
{
    public static ToolIssue Error(string code, string? path, string message) =>
        new(code, ToolSeverity.Error, message, path);

    /// <summary>
    /// Checks a schema and everything under it. <paramref name="path"/> names it in messages, e.g. <c>"body.reason"</c>.
    /// <paramref name="isProperty"/>: the schema is a property (or a param), so <c>Omit()</c> needs it to be optional.
    /// </summary>
    public static void CheckSchema(Schema schema, string path, bool isProperty, List<ToolIssue> issues)
    {
        var s = schema.State;
        // The API reads "" as unset, so an empty description or variable name isn't a value source.
        var described = !string.IsNullOrEmpty(s.Description);
        var sources = new[]
        {
            described,
            !string.IsNullOrEmpty(s.DynamicVariable),
            s.HasConstant,
            s.SystemProvided,
            s.Omitted,
        }.Count(set => set);
        if (sources > 1)
        {
            issues.Add(
                Error(
                    "conflicting_value_source",
                    path,
                    $"\"{path}\" sets more than one of Describe(), FromVariable(), Constant(), SystemProvided() and Omit()"
                )
            );
        }
        if (s.Omitted && isProperty && !s.Optional)
        {
            issues.Add(Error("omitted_required", path, $"\"{path}\" uses Omit(), so it must be Optional()"));
        }
        if (s.Choices != null && s.Kind != SchemaKind.String)
        {
            issues.Add(Error("invalid_choices", path, $"\"{path}\" uses Choices(), which only applies to strings"));
        }
        if (s.AllowedFrom != null && !described)
        {
            issues.Add(
                Error(
                    "allowed_values_needs_description",
                    path,
                    $"\"{path}\" uses AllowedFrom(), which needs Describe() so the LLM provides the value"
                )
            );
        }
        if (s.HasConstant && !MatchesKind(s.Kind, s.ConstantValue, IsNullable(s.LiteralType)))
        {
            issues.Add(
                Error(
                    "constant_type_mismatch",
                    path,
                    $"\"{path}\" has a constant that isn't a {Schema.KindName(s.Kind)}"
                )
            );
        }
        else if (s.HasConstant && ToolWire.IsEmptyString(s.ConstantValue))
        {
            issues.Add(
                Error(
                    "constant_type_mismatch",
                    path,
                    $"\"{path}\" can't have \"\" as a constant: the API reads it as unset"
                )
            );
        }
        // The API rejects a literal with no value source wherever it appears, response schemas included.
        if (sources == 0 && Schema.IsLiteral(s.Kind))
        {
            issues.Add(
                Error(
                    "missing_value_source",
                    path,
                    $"\"{path}\" needs one of Describe(), FromVariable(), Constant(), SystemProvided() or Omit()"
                )
            );
        }

        if (s.Kind == SchemaKind.Object)
        {
            var names = s.Properties.Select(prop => prop.Key).ToList();
            foreach (var group in s.AnyOf.Concat(s.AllOf))
            {
                foreach (var name in group.Where(n => !names.Contains(n)))
                {
                    issues.Add(
                        Error(
                            "unknown_required_property",
                            path,
                            $"\"{path}\" requires \"{name}\" in RequireAnyOf()/RequireAllOf(), but has no such property"
                        )
                    );
                }
            }
            foreach (var prop in s.Properties)
            {
                CheckSchema(prop.Value, $"{path}.{prop.Key}", true, issues);
            }
        }
        if (s.Kind == SchemaKind.Array)
        {
            if (s.Items == null)
            {
                issues.Add(Error("missing_array_items", path, $"Array \"{path}\" has no items schema"));
            }
            else
            {
                CheckSchema(s.Items, $"{path}[]", false, issues);
            }
        }
    }

    /// <summary>Whether a loaded literal's <c>type</c> is a list that includes <c>"null"</c>, e.g. <c>["integer", "null"]</c>.</summary>
    private static bool IsNullable(JsonNode? type) =>
        type is JsonArray list && list.Any(item => ToolWire.Str(item) == "null");

    private static bool MatchesKind(SchemaKind kind, JsonNode? value, bool nullable)
    {
        if (value == null)
        {
            return nullable;
        }
        var valueKind = value.GetValueKind();
        switch (kind)
        {
            case SchemaKind.String:
                return valueKind == JsonValueKind.String;
            case SchemaKind.Integer:
                if (valueKind != JsonValueKind.Number)
                {
                    return false;
                }
                var number = Wire.AsDouble(value);
                return !double.IsInfinity(number) && Math.Floor(number) == number;
            case SchemaKind.Number:
                return valueKind == JsonValueKind.Number;
            case SchemaKind.Boolean:
                return valueKind == JsonValueKind.True || valueKind == JsonValueKind.False;
            case SchemaKind.Object:
                return valueKind == JsonValueKind.Object;
            default:
                return valueKind == JsonValueKind.Array;
        }
    }
}
