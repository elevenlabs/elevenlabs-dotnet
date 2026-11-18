using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using ElevenLabs.Core;
using OneOf;

namespace ElevenLabs.AgentTools;

/// <summary>
/// Turns a finished wire-format tool config into the generated <see cref="ToolRequestModelToolConfig"/> without
/// changing any value. The generated literal schema holds its constant as <c>OneOf&lt;string, int, double, bool&gt;</c>,
/// which can't carry <c>null</c> (a nullable literal's constant) or a number a double can't represent exactly (such as
/// 9007199254740993). Those constants are carried in the model's extension data instead, which the SDK serializes
/// as written, so the request sends exactly what <c>ToJson()</c> shows.
/// </summary>
internal static class ToolModelConversion
{
    private const string SentinelPrefix = "\u0001elevenlabs-agent-tools-constant-";

    private static readonly FieldInfo? LiteralExtensionData = typeof(LiteralJsonSchemaProperty)
        .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
        .FirstOrDefault(field => field.GetCustomAttribute<JsonExtensionDataAttribute>() != null);

    public static ToolRequestModelToolConfig Convert(JsonObject wire, string toolName)
    {
        var copy = (JsonObject)wire.DeepClone();
        var raw = new List<JsonElement>();
        foreach (var schema in SchemaRoots(copy))
        {
            ReplaceInexactConstants(schema, raw);
        }
        var model = JsonUtils.Deserialize<ToolRequestModelToolConfig>(copy.ToJsonString());
        if (raw.Count == 0)
        {
            return model;
        }
        var restored = new HashSet<int>();
        Visit(model, raw, restored);
        if (restored.Count != raw.Count)
        {
            throw new ToolValidationException(
                toolName,
                new[]
                {
                    ToolValidation.Error(
                        "constant_type_mismatch",
                        null,
                        "A constant can't be carried exactly by the generated request model; use ToJson() for this tool"
                    ),
                }
            );
        }
        return model;
    }

    /// <summary>The top-level schemas of a webhook or client tool config.</summary>
    private static IEnumerable<JsonObject> SchemaRoots(JsonObject config)
    {
        if (config["parameters"] is JsonObject parameters)
        {
            yield return parameters;
        }
        if (config["api_schema"] is JsonObject api)
        {
            if (api["path_params_schema"] is JsonObject pathParams)
            {
                foreach (var param in pathParams)
                {
                    if (param.Value is JsonObject schema)
                    {
                        yield return schema;
                    }
                }
            }
            foreach (var key in new[] { "query_params_schema", "request_body_schema", "response_body_schema" })
            {
                if (api[key] is JsonObject schema)
                {
                    yield return schema;
                }
            }
        }
    }

    /// <summary>Swaps each literal constant the generated model can't hold exactly for a sentinel string, recording it.</summary>
    private static void ReplaceInexactConstants(JsonObject schema, List<JsonElement> raw)
    {
        var type = ToolWire.Str(schema["type"]);
        var isContainer =
            type == "object"
            || type == "array"
            || (schema["type"] == null && (schema.ContainsKey("properties") || schema.ContainsKey("items")));
        if (!isContainer && schema.TryGetPropertyValue("constant_value", out var constant) && !RoundTrips(constant))
        {
            raw.Add(ToElement(constant));
            schema["constant_value"] = SentinelPrefix + (raw.Count - 1);
        }
        if (schema["properties"] is JsonObject properties)
        {
            foreach (var property in properties)
            {
                if (property.Value is JsonObject child)
                {
                    ReplaceInexactConstants(child, raw);
                }
            }
        }
        if (schema["items"] is JsonObject items)
        {
            ReplaceInexactConstants(items, raw);
        }
    }

    /// <summary>Whether the generated literal constant type holds <paramref name="value"/> without changing it.</summary>
    private static bool RoundTrips(JsonNode? value)
    {
        if (value == null)
        {
            return false;
        }
        var kind = value.GetValueKind();
        if (kind != JsonValueKind.Number)
        {
            return kind == JsonValueKind.String || kind == JsonValueKind.True || kind == JsonValueKind.False;
        }
        try
        {
            var typed = JsonUtils.Deserialize<OneOf<string, int, double, bool>>(value.ToJsonString());
            return JsonNode.DeepEquals(JsonUtils.SerializeToNode(typed), value);
        }
        catch (JsonException)
        {
            return false;
        }
    }

    private static JsonElement ToElement(JsonNode? value)
    {
        using var document = JsonDocument.Parse(value?.ToJsonString() ?? "null");
        return document.RootElement.Clone();
    }

    /// <summary>Walks the generated model and puts each recorded constant back in its literal's extension data.</summary>
    private static void Visit(object? node, List<JsonElement> raw, HashSet<int> restored)
    {
        switch (node)
        {
            case null:
            case string:
            case JsonElement:
            case JsonNode:
            case ReadOnlyAdditionalProperties:
                return;
            case LiteralJsonSchemaProperty literal:
                Restore(literal, raw, restored);
                return;
            case IOneOf oneOf:
                Visit(oneOf.Value, raw, restored);
                return;
            case IDictionary dictionary:
                foreach (var value in dictionary.Values)
                {
                    Visit(value, raw, restored);
                }
                return;
            case IEnumerable list:
                foreach (var item in list)
                {
                    Visit(item, raw, restored);
                }
                return;
        }
        var type = node.GetType();
        if (type.IsPrimitive || type.IsEnum || type.Namespace == null || !type.Namespace.StartsWith("ElevenLabs"))
        {
            return;
        }
        foreach (var property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            if (property.GetIndexParameters().Length == 0 && property.PropertyType != typeof(bool))
            {
                Visit(property.GetValue(node), raw, restored);
            }
        }
    }

    private static void Restore(LiteralJsonSchemaProperty literal, List<JsonElement> raw, HashSet<int> restored)
    {
        if (
            literal.ConstantValue is not { } constant
            || !constant.IsT0
            || !constant.AsT0.StartsWith(SentinelPrefix, StringComparison.Ordinal)
            || !int.TryParse(constant.AsT0.Substring(SentinelPrefix.Length), out var index)
            || LiteralExtensionData?.GetValue(literal) is not IDictionary<string, JsonElement> extensionData
        )
        {
            return;
        }
        literal.ConstantValue = null;
        extensionData["constant_value"] = raw[index];
        restored.Add(index);
    }
}
