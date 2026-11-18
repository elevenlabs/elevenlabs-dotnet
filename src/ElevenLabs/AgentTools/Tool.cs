using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using ElevenLabs.AgentWorkflows;
using ElevenLabs.Core;

namespace ElevenLabs.AgentTools;

/// <summary>The kind of a <see cref="Tool"/>.</summary>
public enum ToolKind
{
    /// <summary>The server calls an HTTP endpoint.</summary>
    Webhook,

    /// <summary>The agent sends an event to the user's client.</summary>
    Client,

    /// <summary>A built-in tool the agent runs itself.</summary>
    System,

    /// <summary>A loaded tool of a type this SDK has no constructor for, such as <c>mcp</c>. It round-trips but can't be edited.</summary>
    Other,
}

/// <summary>
/// An agent tool, written as code. Create one with <see cref="Webhook"/>, <see cref="Client"/> or a
/// <see cref="SystemTool"/> constructor, or load one with <see cref="FromJson(string)"/> / <see cref="FromResponse"/>.
/// <see cref="Build"/> returns the request model <c>Agents.Tools.CreateAsync()</c> / <c>UpdateAsync()</c> accept;
/// <see cref="ToJsonString"/> the canonical file format the CLI keeps in <c>tool_configs/*.json</c>.
/// </summary>
/// <remarks>
/// The generated <c>ElevenLabs.Tool</c>, <c>ElevenLabs.ObjectSchema</c> and <c>ElevenLabs.ArraySchema</c> models share
/// these names. In a file that imports both <c>ElevenLabs</c> and <c>ElevenLabs.AgentTools</c>, add
/// <c>using Tool = ElevenLabs.AgentTools.Tool;</c>.
/// </remarks>
public abstract class Tool
{
    private static readonly HashSet<string> CommonOptionNames = new()
    {
        "Name",
        "Description",
        "ResponseTimeoutSecs",
        "InterruptionMode",
        "PreToolSpeech",
        "ToolCallSound",
        "ToolCallSoundBehavior",
        "ToolErrorHandlingMode",
    };

    /// <summary>The tool config in wire format, except the parts subclasses keep in their own fields, and <c>type</c>.</summary>
    private protected readonly JsonObject Config;

    /// <summary>Problems found while building, reported by <c>Build()</c>.</summary>
    private protected readonly List<ToolIssue> Issues = new();

    private protected Tool(JsonObject config) => Config = config;

    /// <summary><see cref="ToolKind.Webhook"/>, <see cref="ToolKind.Client"/>, <see cref="ToolKind.System"/> or <see cref="ToolKind.Other"/>.</summary>
    public abstract ToolKind Kind { get; }

    /// <summary>The tool's name, as the LLM sees it.</summary>
    public string Name => ToolWire.Str(Config["name"]) ?? "";

    /// <summary>A tool the server runs by calling an HTTP endpoint. Set the method and URL with <c>Get()</c>, <c>Post()</c>...</summary>
    public static WebhookTool Webhook(string name, string description) =>
        new(new JsonObject { ["name"] = name, ["description"] = description }, new JsonObject());

    /// <summary>A tool that sends an event to the user's client.</summary>
    public static ClientTool Client(string name, string description) =>
        new(new JsonObject { ["name"] = name, ["description"] = description }, null);

    /// <summary>
    /// Loads a tool stored in API format (snake_case), for example from <see cref="ToJsonString"/> or a CLI
    /// <c>tool_configs/*.json</c> file: a tool config, or a request or response with a <c>tool_config</c> key.
    /// </summary>
    public static Tool FromJson(string json) =>
        FromJson(JsonNode.Parse(json) ?? throw new ArgumentException("The tool JSON is null", nameof(json)));

    /// <summary>Loads a tool from parsed API-format JSON: a tool config, or a request or response with a <c>tool_config</c> key.</summary>
    public static Tool FromJson(JsonNode json)
    {
        var parsed = json as JsonObject ?? throw new ArgumentException("A tool must be a JSON object", nameof(json));
        var raw = parsed["tool_config"] as JsonObject ?? parsed;
        var type = ToolWire.Str(raw["type"]);
        if (type != "webhook" && type != "client" && type != "system")
        {
            return new OtherTool((JsonObject)raw.DeepClone());
        }
        var config = ToolWire.WithoutNulls(raw);
        config.Remove("type");
        if (type == "webhook")
        {
            var api = Take(config, "api_schema") as JsonObject;
            return WebhookTool.Load(config, api ?? new JsonObject());
        }
        if (type == "client")
        {
            var parameters = Take(config, "parameters") as JsonObject;
            return new ClientTool(
                config,
                parameters == null ? null : (ObjectSchema)Schema.FromWire(parameters, false, SchemaKind.Object)
            );
        }
        var systemParams = Take(config, "params") as JsonObject ?? new JsonObject();
        var systemToolType = ToolWire.Str(Take(systemParams, "system_tool_type")) ?? "";
        return new SystemTool(systemToolType, config, systemParams);
    }

    /// <summary>Loads the result of <c>Agents.Tools.GetAsync()</c>.</summary>
    public static Tool FromResponse(ToolResponseModel response) =>
        FromJson(JsonUtils.SerializeToNode(response.ToolConfig) ?? new JsonObject());

    /// <summary>Merges options for this kind of tool. An option that doesn't apply is reported by <c>Build()</c>.</summary>
    public Tool Options(CommonToolOptions options)
    {
        ApplyOptions(options);
        return this;
    }

    /// <summary>This tool as a <see cref="WebhookTool"/>, or <c>null</c> if it's another kind.</summary>
    public WebhookTool? AsWebhook() => this as WebhookTool;

    /// <summary>This tool as a <see cref="ClientTool"/>, or <c>null</c> if it's another kind.</summary>
    public ClientTool? AsClient() => this as ClientTool;

    /// <summary>This tool as a <see cref="SystemTool"/>, or <c>null</c> if it's another kind.</summary>
    public SystemTool? AsSystem() => this as SystemTool;

    /// <summary>
    /// Validates the tool and returns it in the shape <c>Agents.Tools.CreateAsync()</c> and <c>UpdateAsync()</c>
    /// accept. <paramref name="onWarning"/> is called once per warning.
    /// </summary>
    /// <exception cref="ToolValidationException">Listing every problem, if the tool is invalid.</exception>
    public ToolRequestModel Build(Action<ToolIssue>? onWarning = null) =>
        new() { ToolConfig = BuildConfig(onWarning) };

    /// <summary>
    /// Validates the tool and returns only its config. For a system tool, <see cref="SystemTool.BuildConfig"/> returns
    /// its entry for the agent's <c>prompt.built_in_tools</c>. Create webhook and client tools with
    /// <c>Agents.Tools.CreateAsync()</c> and attach them by id in <c>prompt.tool_ids</c>: the inline
    /// <c>prompt.tools</c> field is deprecated, and replaces <c>built_in_tools</c> with the system tools it contains.
    /// </summary>
    /// <exception cref="ToolValidationException">Listing every problem, if the tool is invalid.</exception>
    public ToolRequestModelToolConfig BuildConfig(Action<ToolIssue>? onWarning = null) =>
        ToConfigModel(ToWireObject(onWarning));

    /// <summary>
    /// The tool config in API format (snake_case keys, sorted at every level), the shape of a CLI
    /// <c>tool_configs/*.json</c> file. Validates like <see cref="Build"/>.
    /// </summary>
    public JsonObject ToJson() => (JsonObject)Wire.Canonicalize(ToWireObject(null))!;

    /// <summary><see cref="ToJson"/> as a string with 2-space indentation and a trailing newline: the canonical file format.</summary>
    public string ToJsonString() => Wire.ToCanonicalString(ToWireObject(null));

    /// <summary>The kind as the spec and messages spell it.</summary>
    private protected string KindName =>
        Kind switch
        {
            ToolKind.Webhook => "webhook",
            ToolKind.Client => "client",
            ToolKind.System => "system",
            _ => "other",
        };

    /// <summary>The option names (C# property names) this kind accepts.</summary>
    private protected abstract ICollection<string> AllowedOptions { get; }

    private protected void ApplyOptions(CommonToolOptions options)
    {
        foreach (var entry in OptionEntries(options))
        {
            if (!AllowedOptions.Contains(entry.Key))
            {
                Issues.Add(
                    ToolValidation.Error(
                        "invalid_option",
                        entry.Key,
                        $"Option \"{entry.Key}\" doesn't apply to {KindName} tools"
                    )
                );
            }
            else
            {
                SetOption(entry.Key, entry.Value);
            }
        }
    }

    private protected virtual void SetOption(string name, JsonNode value)
    {
        if (name == "DynamicVariablePlaceholders")
        {
            var dynamicVariables = Config["dynamic_variables"] as JsonObject ?? new JsonObject();
            dynamicVariables["dynamic_variable_placeholders"] = value;
            Config["dynamic_variables"] = dynamicVariables;
        }
        else
        {
            Config[SnakeCase(name)] = value;
        }
    }

    /// <summary>Problems that need the finished tool.</summary>
    private protected abstract List<ToolIssue> Validate();

    /// <summary>The finished tool config in wire format, with its <c>type</c>.</summary>
    private protected abstract JsonObject ToModel();

    /// <summary>The generated model for a finished wire-format config.</summary>
    private protected virtual ToolRequestModelToolConfig ToConfigModel(JsonObject wire) =>
        JsonUtils.Deserialize<ToolRequestModelToolConfig>(wire.ToJsonString());

    /// <summary>Validates, reports warnings, and returns the wire-format tool config.</summary>
    private protected JsonObject ToWireObject(Action<ToolIssue>? onWarning)
    {
        var issues = new List<ToolIssue>(Issues);
        issues.AddRange(Validate());
        var errors = issues.Where(issue => issue.Severity == ToolSeverity.Error).ToList();
        if (errors.Count > 0)
        {
            throw new ToolValidationException(Name, errors);
        }
        if (onWarning != null)
        {
            foreach (var warning in issues.Where(issue => issue.Severity == ToolSeverity.Warning))
            {
                onWarning(warning);
            }
        }
        return ToModel();
    }

    /// <summary>Copies the fields of <see cref="Config"/> into a new object.</summary>
    private protected JsonObject CopyConfig()
    {
        var result = new JsonObject();
        foreach (var field in Config)
        {
            result[field.Key] = field.Value?.DeepClone();
        }
        return result;
    }

    private protected static HashSet<string> WithCommonOptions(params string[] names)
    {
        var result = new HashSet<string>(CommonOptionNames);
        result.UnionWith(names);
        return result;
    }

    /// <summary><c>"ResponseTimeoutSecs"</c> → <c>"response_timeout_secs"</c>.</summary>
    internal static string SnakeCase(string name)
    {
        var builder = new StringBuilder();
        for (var i = 0; i < name.Length; i++)
        {
            if (char.IsUpper(name[i]) && i > 0)
            {
                builder.Append('_');
            }
            builder.Append(char.ToLowerInvariant(name[i]));
        }
        return builder.ToString();
    }

    /// <summary>Removes <paramref name="key"/> from <paramref name="obj"/> and returns its (detached) value.</summary>
    internal static JsonNode? Take(JsonObject obj, string key)
    {
        if (!obj.TryGetPropertyValue(key, out var value))
        {
            return null;
        }
        var copy = value?.DeepClone();
        obj.Remove(key);
        return copy;
    }

    /// <summary>The options that are set, by C# property name, in wire format.</summary>
    private static List<KeyValuePair<string, JsonNode>> OptionEntries(CommonToolOptions options)
    {
        var entries = new List<KeyValuePair<string, JsonNode>>();
        Put(entries, "Name", options.Name);
        Put(entries, "Description", options.Description);
        Put(entries, "ResponseTimeoutSecs", options.ResponseTimeoutSecs);
        Put(entries, "InterruptionMode", options.InterruptionMode);
        Put(entries, "PreToolSpeech", options.PreToolSpeech);
        Put(entries, "ToolCallSound", options.ToolCallSound);
        Put(entries, "ToolCallSoundBehavior", options.ToolCallSoundBehavior);
        Put(entries, "ToolErrorHandlingMode", options.ToolErrorHandlingMode);
        if (options is WebhookToolOptions webhook)
        {
            Put(entries, "DynamicVariablePlaceholders", webhook.DynamicVariablePlaceholders);
            Put(entries, "ExecutionMode", webhook.ExecutionMode);
            Put(entries, "ContentType", webhook.ContentType);
            Put(entries, "ResponseFilter", webhook.ResponseFilter);
            Put(entries, "FollowRedirects", webhook.FollowRedirects);
            Put(entries, "FollowRedirectsAllowedDomains", webhook.FollowRedirectsAllowedDomains);
        }
        if (options is ClientToolOptions client)
        {
            Put(entries, "DynamicVariablePlaceholders", client.DynamicVariablePlaceholders);
            Put(entries, "ExecutionMode", client.ExecutionMode);
            Put(entries, "ExpectsResponse", client.ExpectsResponse);
        }
        return entries;
    }

    internal static void Put(List<KeyValuePair<string, JsonNode>> entries, string name, string? value)
    {
        if (value != null)
        {
            entries.Add(new KeyValuePair<string, JsonNode>(name, JsonValue.Create(value)!));
        }
    }

    internal static void Put(List<KeyValuePair<string, JsonNode>> entries, string name, int? value)
    {
        if (value != null)
        {
            entries.Add(new KeyValuePair<string, JsonNode>(name, JsonValue.Create(value.Value)));
        }
    }

    internal static void Put(List<KeyValuePair<string, JsonNode>> entries, string name, double? value)
    {
        if (value != null)
        {
            entries.Add(new KeyValuePair<string, JsonNode>(name, JsonValue.Create(value.Value)));
        }
    }

    internal static void Put(List<KeyValuePair<string, JsonNode>> entries, string name, bool? value)
    {
        if (value != null)
        {
            entries.Add(new KeyValuePair<string, JsonNode>(name, JsonValue.Create(value.Value)));
        }
    }

    internal static void Put(List<KeyValuePair<string, JsonNode>> entries, string name, JsonNode? value)
    {
        if (value != null)
        {
            entries.Add(new KeyValuePair<string, JsonNode>(name, value.DeepClone()));
        }
    }

    internal static void Put(List<KeyValuePair<string, JsonNode>> entries, string name, IEnumerable<string>? value)
    {
        if (value != null)
        {
            entries.Add(new KeyValuePair<string, JsonNode>(name, ToolWire.ToArray(value)));
        }
    }
}

/// <summary>A loaded tool of a type the builder has no constructor for, such as <c>mcp</c>. Kept exactly as loaded.</summary>
internal sealed class OtherTool : Tool
{
    internal OtherTool(JsonObject raw)
        : base(raw) { }

    public override ToolKind Kind => ToolKind.Other;

    private protected override ICollection<string> AllowedOptions => global::System.Array.Empty<string>();

    private protected override List<ToolIssue> Validate() =>
        new()
        {
            new ToolIssue(
                "unknown_tool_type",
                ToolSeverity.Warning,
                $"Tool \"{Name}\" has type \"{ToolWire.Str(Config["type"]) ?? Config["type"]?.ToJsonString()}\", which this SDK can't edit. "
                    + "It round-trips through ToJson(), but Build()'s output may be rejected by Agents.Tools.CreateAsync() and UpdateAsync()"
            ),
        };

    private protected override JsonObject ToModel() => CopyConfig();

    private protected override ToolRequestModelToolConfig ToConfigModel(JsonObject wire)
    {
        try
        {
            return base.ToConfigModel(wire);
        }
        catch (JsonException)
        {
            // A type the generated model knows (e.g. "mcp") but whose required fields this config lacks: keep the
            // loaded JSON as the union's value.
            var type = ToolWire.Str(wire["type"]) ?? "";
            return new ToolRequestModelToolConfig(type, JsonSerializer.Deserialize<JsonElement>(wire.ToJsonString()));
        }
    }
}
