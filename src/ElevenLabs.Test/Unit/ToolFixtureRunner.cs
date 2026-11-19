using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Nodes;
using ElevenLabs.AgentWorkflows;

namespace ElevenLabs.Tests;

// Inside the namespace, so these win over the generated ElevenLabs.Tool / ObjectSchema / ArraySchema models.
using ElevenLabs.AgentTools;

/// <summary>
/// Interprets the language-neutral fixtures in <c>docs/agents-as-code/fixtures/tools</c> through the .NET builder.
/// See <c>tool-spec.md</c>, "Fixtures". Mirrors the reference runner (elevenlabs-js
/// <c>tests/custom/agents/tools/fixtureRunner.ts</c>).
/// </summary>
internal static class ToolFixtureRunner
{
    public sealed class FixtureResult
    {
        public string? Json { get; set; }
        public List<string>? Errors { get; set; }
    }

    private static readonly JsonSerializerOptions SchemaOptions = new()
    {
        WriteIndented = true,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
    };

    public static FixtureResult Run(JsonObject fixture)
    {
        if (fixture["schema"] is JsonArray schemaOps)
        {
            return new FixtureResult { Json = BuildSchema(schemaOps).ToJson().ToJsonString(SchemaOptions) + "\n" };
        }

        var spec = fixture["tool"] as JsonObject;
        Tool tool;
        if (fixture["from"] is JsonNode from)
        {
            tool = Tool.FromJson(from);
        }
        else if (spec?["webhook"] is JsonArray webhook)
        {
            tool = Tool.Webhook(Str(webhook[0]), Str(webhook[1]));
        }
        else if (spec?["client"] is JsonArray client)
        {
            tool = Tool.Client(Str(client[0]), Str(client[1]));
        }
        else
        {
            tool = CreateSystem(Str(spec!["system"]), spec["systemOptions"] as JsonObject);
        }

        foreach (var opNode in fixture["ops"] as JsonArray ?? new JsonArray())
        {
            var op = (JsonObject)opNode!;
            CallTool(tool, Str(op["op"]), op["args"] as JsonArray ?? new JsonArray());
        }

        try
        {
            return new FixtureResult { Json = tool.ToJsonString() };
        }
        catch (ToolValidationException ex)
        {
            return new FixtureResult { Errors = ex.Issues.Select(issue => issue.Code).ToList() };
        }
    }

    private static SystemTool CreateSystem(string type, JsonObject? options) =>
        type switch
        {
            "end_call" => SystemTool.EndCall(),
            "skip_turn" => SystemTool.SkipTurn(Populate<SkipTurnOptions>(options)),
            "language_detection" => SystemTool.LanguageDetection(Populate<LanguageDetectionOptions>(options)),
            "play_keypad_touch_tone" => SystemTool.PlayKeypadTouchTone(Populate<PlayKeypadTouchToneOptions>(options)),
            "voicemail_detection" => SystemTool.VoicemailDetection(Populate<VoicemailDetectionOptions>(options)),
            "knowledge_base" => SystemTool.KnowledgeBase(Populate<KnowledgeBaseToolOptions>(options)),
            "transfer_to_number" => SystemTool.TransferToNumber(Populate<TransferToNumberOptions>(options)),
            "transfer_to_agent" => SystemTool.TransferToAgent(),
            _ => throw new InvalidOperationException($"Unknown system tool \"{type}\""),
        };

    private static void CallTool(Tool tool, string op, JsonArray args)
    {
        WebhookTool W() => tool.AsWebhook() ?? throw new InvalidOperationException($"\"{op}\" needs a webhook tool");
        ClientTool C() => tool.AsClient() ?? throw new InvalidOperationException($"\"{op}\" needs a client tool");
        SystemTool S() => tool.AsSystem() ?? throw new InvalidOperationException($"\"{op}\" needs a system tool");

        switch (op)
        {
            case "get":
                W().Get(Str(args[0]));
                break;
            case "post":
                W().Post(Str(args[0]));
                break;
            case "put":
                W().Put(Str(args[0]));
                break;
            case "patch":
                W().Patch(Str(args[0]));
                break;
            case "delete":
                W().Delete(Str(args[0]));
                break;
            case "pathParam":
                W().PathParam(Str(args[0]), SchemaArg(args[1]!));
                break;
            case "queryParam":
                W().QueryParam(Str(args[0]), SchemaArg(args[1]!));
                break;
            case "body":
                W().Body(SchemaArg(args[0]!));
                break;
            case "response":
                W().Response(SchemaArg(args[0]!));
                break;
            case "header":
                W().Header(Str(args[0]), ParseHeader((JsonObject)args[1]!));
                break;
            case "auth":
            {
                var raw = (JsonObject)args[0]!;
                W().Auth(raw.ContainsKey("id") ? AuthConnection.Id(Str(raw["id"])) : AuthConnection.EnvVar(Str(raw["envVar"])));
                break;
            }
            case "assign":
                W().Assign(Str(args[0]), Str(args[1]), Populate<AssignOptions>(Arg(args, 2) as JsonObject));
                break;
            case "removePathParam":
                W().RemovePathParam(Str(args[0]));
                break;
            case "removeQueryParam":
                W().RemoveQueryParam(Str(args[0]));
                break;
            case "removeHeader":
                W().RemoveHeader(Str(args[0]));
                break;
            case "removeAssignment":
                W().RemoveAssignment(Str(args[0]));
                break;
            case "param":
                C().Param(Str(args[0]), SchemaArg(args[1]!));
                break;
            case "removeParam":
                C().RemoveParam(Str(args[0]));
                break;
            case "transfer":
                S().Transfer(
                    Str(args[0]),
                    ParseDestination((JsonObject)args[1]!),
                    Populate<SystemTransferOptions>(Arg(args, 2) as JsonObject)
                );
                break;
            case "options":
                ApplyOptions(tool, (JsonObject)args[0]!);
                break;
            default:
                throw new InvalidOperationException($"Unknown fixture op \"{op}\"");
        }
    }

    /// <summary>
    /// The fixture's options are one untyped object; .NET options are typed per kind. Keys of the tool's own options
    /// class go in one call; any others (which <c>Build()</c> must reject) in a second call with the class that has them.
    /// </summary>
    private static void ApplyOptions(Tool tool, JsonObject raw)
    {
        var own = tool.Kind switch
        {
            ToolKind.Webhook => typeof(WebhookToolOptions),
            ToolKind.Client => typeof(ClientToolOptions),
            _ => typeof(CommonToolOptions),
        };
        var groups = new Dictionary<Type, JsonObject>();
        foreach (var field in raw)
        {
            var type = new[] { own, typeof(WebhookToolOptions), typeof(ClientToolOptions) }.First(t =>
                t.GetProperty(Pascal(field.Key)) != null
            );
            if (!groups.TryGetValue(type, out var group))
            {
                group = new JsonObject();
                groups[type] = group;
            }
            group[field.Key] = field.Value?.DeepClone();
        }
        foreach (var group in groups)
        {
            tool.Options((CommonToolOptions)Populate(group.Key, group.Value));
        }
    }

    // A schema argument is wire-format JSON, or {"build": [ops]} for one built with Schema methods (e.g. Optional()).
    private static Schema SchemaArg(JsonNode raw) =>
        raw is JsonObject obj && obj["build"] is JsonArray ops ? BuildSchema(ops) : Schema.FromJson(raw);

    private static Schema BuildSchema(JsonArray ops)
    {
        var first = (JsonObject)ops[0]!;
        var firstArgs = first["args"] as JsonArray ?? new JsonArray();
        Schema schema = Str(first["op"]) switch
        {
            "string" => Schema.String(),
            "integer" => Schema.Integer(),
            "number" => Schema.Number(),
            "bool" => Schema.Bool(),
            "object" => Schema.Object(),
            "array" => Schema.Array(SchemaArg(firstArgs[0]!)),
            "fromJSON" => Schema.FromJson(firstArgs[0]!),
            var other => throw new InvalidOperationException($"Unknown schema constructor \"{other}\""),
        };
        foreach (var opNode in ops.Skip(1))
        {
            var op = (JsonObject)opNode!;
            var args = op["args"] as JsonArray ?? new JsonArray();
            schema = Str(op["op"]) switch
            {
                "describe" => schema.Describe(Str(args[0])),
                "fromVariable" => schema.FromVariable(Str(args[0])),
                "constant" => schema.Constant(args[0]?.DeepClone()),
                "omit" => schema.Omit(),
                "optional" => schema.Optional(),
                "systemProvided" => ((LiteralSchema)schema).SystemProvided(),
                "choices" => ((LiteralSchema)schema).Choices(StrList(args[0])),
                "allowedFrom" => ((LiteralSchema)schema).AllowedFrom(Str(args[0])),
                "property" => ((ObjectSchema)schema).Property(Str(args[0]), SchemaArg(args[1]!)),
                "without" => ((ObjectSchema)schema).Without(Str(args[0])),
                "requireAnyOf" => ((ObjectSchema)schema).RequireAnyOf(StrList(args[0])),
                "requireAllOf" => ((ObjectSchema)schema).RequireAllOf(StrList(args[0])),
                var other => throw new InvalidOperationException($"Unknown schema op \"{other}\""),
            };
        }
        return schema;
    }

    private static Header ParseHeader(JsonObject raw)
    {
        if (raw.ContainsKey("value"))
        {
            return Header.Value(Str(raw["value"]));
        }
        if (raw.ContainsKey("secret"))
        {
            return Header.Secret(Str(raw["secret"]));
        }
        if (raw.ContainsKey("variable"))
        {
            return Header.Variable(Str(raw["variable"]));
        }
        return Header.EnvVar(Str(raw["envVar"]));
    }

    private static Destination ParseDestination(JsonObject raw)
    {
        if (raw.ContainsKey("phone"))
        {
            return Destination.Phone(Str(raw["phone"]));
        }
        if (raw.ContainsKey("phoneVariable"))
        {
            return Destination.PhoneVariable(Str(raw["phoneVariable"]));
        }
        if (raw.ContainsKey("sip"))
        {
            return Destination.Sip(Str(raw["sip"]));
        }
        if (raw.ContainsKey("sipVariable"))
        {
            return Destination.SipVariable(Str(raw["sipVariable"]));
        }
        return Destination.Agent(Str(raw["agent"]), raw["nodeId"]?.GetValue<string>());
    }

    private static T Populate<T>(JsonObject? raw)
        where T : new() => raw == null ? new T() : (T)Populate(typeof(T), raw);

    /// <summary>Sets each camelCase fixture key on the matching PascalCase property of a new <paramref name="type"/>.</summary>
    private static object Populate(Type type, JsonObject raw)
    {
        var target = Activator.CreateInstance(type)!;
        foreach (var field in raw)
        {
            var property =
                type.GetProperty(Pascal(field.Key))
                ?? throw new InvalidOperationException($"{type.Name} has no option \"{field.Key}\"");
            property.SetValue(target, Convert(field.Value, property.PropertyType));
        }
        return target;
    }

    private static object? Convert(JsonNode? node, Type type)
    {
        if (node == null)
        {
            return null;
        }
        var underlying = Nullable.GetUnderlyingType(type) ?? type;
        if (underlying == typeof(string))
        {
            return node.GetValue<string>();
        }
        if (underlying == typeof(int))
        {
            return node.GetValue<int>();
        }
        if (underlying == typeof(double))
        {
            return node.GetValue<double>();
        }
        if (underlying == typeof(bool))
        {
            return node.GetValue<bool>();
        }
        if (typeof(JsonNode).IsAssignableFrom(underlying))
        {
            return node.DeepClone();
        }
        if (underlying == typeof(IReadOnlyList<string>))
        {
            return StrList(node);
        }
        throw new InvalidOperationException($"Can't convert a fixture value to {type.Name}");
    }

    private static string Pascal(string key) => char.ToUpperInvariant(key[0]) + key.Substring(1);

    private static JsonNode? Arg(JsonArray args, int index) => index < args.Count ? args[index] : null;

    private static string Str(JsonNode? node) => node!.GetValue<string>();

    private static List<string> StrList(JsonNode? node) => ((JsonArray)node!).Select(item => Str(item)).ToList();
}
