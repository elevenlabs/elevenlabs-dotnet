using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization.Metadata;
using ElevenLabs.AgentTools;
using ElevenLabs.Core;

namespace ElevenLabs.AgentBuilder;

// Inside the namespace, so it wins over the generated ElevenLabs.Tool model.
using Tool = ElevenLabs.AgentTools.Tool;

/// <summary>
/// The view of a tool that push compares: its fields the generated request model knows, through the tool builder.
/// </summary>
/// <remarks>
/// This SDK's <c>Tool.FromJson</c> keeps fields the generated model doesn't know, so they round-trip, where the JS
/// reference's <c>Tool.fromJSON</c> drops them. Push's "has this tool changed" checks are specified over the JS view:
/// modeled fields are compared through the builder, and unmodeled ones by <c>isSubset</c> on the config sent. So both
/// sides are compared here with unknown fields stripped first, the way the generated JS serializer strips them.
/// </remarks>
internal static class ToolComparison
{
    private static readonly Lazy<JsonSerializerOptions> StripOptions = new(() =>
        new JsonSerializerOptions(JsonOptions.JsonSerializerOptions)
        {
            TypeInfoResolver = new DefaultJsonTypeInfoResolver
            {
                Modifiers =
                {
                    JsonOptions.NullableOptionalModifier,
                    JsonOptions.JsonAccessAndIgnoreModifier,
                    JsonOptions.HandleExtensionDataFields,
                    RemoveExtensionData,
                },
            },
        }
    );

    /// <summary>The tool's modeled definition as canonical JSON, or <c>null</c> if it doesn't build.</summary>
    public static string? ModeledJson(Tool tool)
    {
        try
        {
            return Modeled(tool.ToJson());
        }
        catch (Exception)
        {
            return null;
        }
    }

    /// <summary>A wire-format tool config's modeled definition, as canonical JSON.</summary>
    public static string Modeled(JsonObject wire)
    {
        var type = AgentWire.Str(wire["type"]);
        if (type is "webhook" or "client" or "system")
        {
            try
            {
                var model = JsonSerializer.Deserialize<ToolRequestModelToolConfig>(wire.ToJsonString(), StripOptions.Value);
                if (JsonUtils.SerializeToNode(model) is JsonObject stripped)
                {
                    return Tool.FromJson(stripped).ToJsonString();
                }
            }
            catch (Exception)
            {
                // Compared as loaded instead.
            }
        }
        return Tool.FromJson(wire).ToJsonString();
    }

    private static void RemoveExtensionData(JsonTypeInfo typeInfo)
    {
        if (typeInfo.Kind != JsonTypeInfoKind.Object)
        {
            return;
        }
        foreach (var property in typeInfo.Properties.Where(property => property.IsExtensionData).ToList())
        {
            typeInfo.Properties.Remove(property);
        }
    }
}
