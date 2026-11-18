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

    /// <summary>The params schema. An object unless a loaded config declared another type, which <c>Build()</c> reports.</summary>
    private Schema? _parameters;

    internal ClientTool(JsonObject config, Schema? parameters)
        : base(config) => _parameters = parameters;

    public override ToolKind Kind => ToolKind.Client;

    /// <summary>
    /// The params, as an object schema, for reading. <c>null</c> if the tool has none, or if a loaded config declared
    /// a params schema that isn't an object.
    /// </summary>
    public ObjectSchema? ParametersSchema => _parameters as ObjectSchema;

    /// <summary>
    /// Sets the param <paramref name="name"/>. Required unless the schema is <c>Optional()</c>. Any schema kind. A
    /// loaded params schema that isn't an object is left as loaded, and <c>Build()</c> reports it.
    /// </summary>
    public ClientTool Param(string name, Schema schema)
    {
        if (_parameters == null || _parameters is ObjectSchema)
        {
            _parameters = ((ObjectSchema?)_parameters ?? Schema.Object()).Property(name, schema);
        }
        return this;
    }

    /// <summary>Removes the param <paramref name="name"/>. Removing the last one leaves <c>parameters</c> out.</summary>
    public ClientTool RemoveParam(string name)
    {
        if (_parameters is ObjectSchema parameters && parameters.PropertySchema(name) != null)
        {
            var remaining = parameters.Without(name);
            _parameters = remaining.PropertyNames.Count == 0 ? null : remaining;
        }
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
        if (_parameters != null && !(_parameters is ObjectSchema))
        {
            issues.Add(ToolValidation.Error("body_not_object", "params", "The params schema must be an object"));
        }
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
