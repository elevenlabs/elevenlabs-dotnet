using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace ElevenLabs.AgentTools;

/// <summary>A tool that sends an event to the user's client.</summary>
public sealed class ClientTool : Tool
{
    private static readonly HashSet<string> Allowed = WithCommonOptions(
        "DynamicVariablePlaceholders",
        "ExecutionMode",
        "ExpectsResponse"
    );

    private ObjectSchema? _parameters;

    internal ClientTool(JsonObject config, ObjectSchema? parameters)
        : base(config) => _parameters = parameters;

    public override ToolKind Kind => ToolKind.Client;

    /// <summary>The params, as an object schema, for reading. <c>null</c> if the tool has none.</summary>
    public ObjectSchema? ParametersSchema => _parameters;

    /// <summary>Sets the param <paramref name="name"/>. Required unless the schema is <c>Optional()</c>. Any schema kind.</summary>
    public ClientTool Param(string name, Schema schema)
    {
        _parameters = (_parameters ?? Schema.Object()).Property(name, schema);
        return this;
    }

    /// <summary>Removes the param <paramref name="name"/>.</summary>
    public ClientTool RemoveParam(string name)
    {
        _parameters = _parameters?.Without(name);
        return this;
    }

    /// <summary>Merges options for client tools. An option that doesn't apply is reported by <c>Build()</c>.</summary>
    public ClientTool Options(ClientToolOptions options)
    {
        ApplyOptions(options);
        return this;
    }

    private protected override ICollection<string> AllowedOptions => Allowed;

    private protected override List<ToolIssue> Validate()
    {
        var issues = new List<ToolIssue>();
        if (_parameters != null)
        {
            // Checks the params object's own RequireAnyOf()/RequireAllOf() and every param under it.
            ToolValidation.CheckSchema(_parameters, "params", false, issues);
        }
        var timeout = Config["response_timeout_secs"];
        if (ToolWire.IsNumber(timeout))
        {
            var secs = AgentWorkflows.Wire.AsDouble(timeout!);
            if (secs != -1 && (secs < 1 || secs > 120))
            {
                issues.Add(
                    ToolValidation.Error(
                        "invalid_option",
                        "ResponseTimeoutSecs",
                        "A client tool's ResponseTimeoutSecs must be 1–120, or -1"
                    )
                );
            }
            if (secs == -1 && !ToolWire.IsTrue(Config["expects_response"]))
            {
                issues.Add(
                    ToolValidation.Error(
                        "invalid_option",
                        "ResponseTimeoutSecs",
                        "ResponseTimeoutSecs = -1 needs ExpectsResponse = true"
                    )
                );
            }
        }
        return issues;
    }

    private protected override JsonObject ToModel()
    {
        var model = CopyConfig();
        model["type"] = "client";
        if (_parameters != null)
        {
            model["parameters"] = _parameters.ToWire();
        }
        return model;
    }
}
