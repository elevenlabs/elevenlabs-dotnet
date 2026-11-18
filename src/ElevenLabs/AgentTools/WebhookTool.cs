using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;

namespace ElevenLabs.AgentTools;

/// <summary>A tool the server runs by calling an HTTP endpoint. Every method returns the tool, so a tool is written as one chain.</summary>
/// <example>
/// <code>
/// var getOrder = Tool.Webhook("get_order", "Look up an order by the number the caller gives")
///     .Get("https://api.example.com/orders/{order_id}")
///     .PathParam("order_id", Schema.String().Describe("The order number, e.g. A-1042"))
///     .Header("Authorization", Header.Secret("sec_orders_api"))
///     .Assign("order_status", "order.status");
/// </code>
/// </example>
public sealed class WebhookTool : Tool
{
    private static readonly HashSet<string> Allowed = WithCommonOptions(
        "DynamicVariablePlaceholders",
        "ExecutionMode",
        "ContentType",
        "ResponseFilter",
        "FollowRedirects",
        "FollowRedirectsAllowedDomains"
    );

    // As the API does: env var templates aren't placeholders.
    private static readonly Regex EnvVarTemplate = new(@"\{\{system__env_[a-z][a-z0-9_]*\}\}");
    private static readonly Regex Placeholder = new(@"\{([^{}]+)\}");

    /// <summary>The <c>api_schema</c> fields not kept below: url, method, auth, content type and so on.</summary>
    private readonly JsonObject _api;
    private readonly List<KeyValuePair<string, Schema>> _pathParams = new();
    private ObjectSchema? _query;
    private Schema? _body;
    private Schema? _response;
    private readonly List<KeyValuePair<string, JsonNode>> _headers = new();

    internal WebhookTool(JsonObject config, JsonObject api)
        : base(config) => _api = api;

    public override ToolKind Kind => ToolKind.Webhook;

    /// <summary>The request body schema, for editing and setting again with <see cref="Body"/>.</summary>
    public Schema? BodySchema => _body;

    /// <summary>The response body schema, for editing and setting again with <see cref="Response"/>.</summary>
    public Schema? ResponseSchema => _response;

    internal static WebhookTool Load(JsonObject config, JsonObject apiSchema)
    {
        var pathParams = Take(apiSchema, "path_params_schema") as JsonObject;
        var query = Take(apiSchema, "query_params_schema") as JsonObject;
        var body = Take(apiSchema, "request_body_schema") as JsonObject;
        var response = Take(apiSchema, "response_body_schema") as JsonObject;
        var headers = Take(apiSchema, "request_headers") as JsonObject;
        var tool = new WebhookTool(config, apiSchema);
        foreach (var param in pathParams ?? new JsonObject())
        {
            tool._pathParams.Add(
                new KeyValuePair<string, Schema>(param.Key, Schema.FromWire(param.Value as JsonObject ?? new JsonObject()))
            );
        }
        if (query != null)
        {
            tool._query = (ObjectSchema)Schema.FromWire(query, false, SchemaKind.Object);
        }
        if (body != null)
        {
            tool._body = Schema.FromWire(body, false, SchemaKind.Object);
        }
        if (response != null)
        {
            tool._response = Schema.FromWire(response, false, SchemaKind.Object);
        }
        foreach (var header in headers ?? new JsonObject())
        {
            if (header.Value != null)
            {
                tool._headers.Add(new KeyValuePair<string, JsonNode>(header.Key, header.Value.DeepClone()));
            }
        }
        return tool;
    }

    /// <summary>Sends a <c>GET</c> to <paramref name="url"/>. <c>{name}</c> placeholders in the URL are filled from path params.</summary>
    public WebhookTool Get(string url) => Request("GET", url);

    /// <summary>Sends a <c>POST</c> to <paramref name="url"/>.</summary>
    public WebhookTool Post(string url) => Request("POST", url);

    /// <summary>Sends a <c>PUT</c> to <paramref name="url"/>.</summary>
    public WebhookTool Put(string url) => Request("PUT", url);

    /// <summary>Sends a <c>PATCH</c> to <paramref name="url"/>.</summary>
    public WebhookTool Patch(string url) => Request("PATCH", url);

    /// <summary>Sends a <c>DELETE</c> to <paramref name="url"/>.</summary>
    public WebhookTool Delete(string url) => Request("DELETE", url);

    /// <summary>Sets the path param <paramref name="name"/>, filling the <c>{name}</c> placeholder in the URL. Literal schemas only.</summary>
    public WebhookTool PathParam(string name, Schema schema)
    {
        SetEntry(_pathParams, name, schema);
        return this;
    }

    /// <summary>Sets the query param <paramref name="name"/>. Required unless the schema is <c>Optional()</c>. Literal schemas only.</summary>
    public WebhookTool QueryParam(string name, Schema schema)
    {
        _query = (_query ?? Schema.Object()).Property(name, schema);
        return this;
    }

    /// <summary>Sets the request body schema. Must be an object.</summary>
    public WebhookTool Body(Schema schema)
    {
        _body = schema;
        return this;
    }

    /// <summary>Sets the response body schema. Must be an object.</summary>
    public WebhookTool Response(Schema schema)
    {
        _response = schema;
        return this;
    }

    /// <summary>Sets the request header <paramref name="name"/>.</summary>
    public WebhookTool Header(string name, Header value)
    {
        SetEntry(_headers, name, value.ToWire());
        return this;
    }

    /// <summary>Authenticates requests with an auth connection.</summary>
    public WebhookTool Auth(AuthConnection connection)
    {
        _api["auth_connection"] = connection.ToWire();
        return this;
    }

    /// <summary>
    /// Stores the value at <paramref name="valuePath"/> in the response (dot notation, e.g. <c>"order.status"</c>) in
    /// the dynamic variable <paramref name="variable"/>.
    /// </summary>
    public WebhookTool Assign(string variable, string valuePath, AssignOptions? options = null)
    {
        var assignment = new JsonObject
        {
            ["source"] = "response",
            ["dynamic_variable"] = variable,
            ["value_path"] = valuePath,
        };
        if (options?.Sanitize != null)
        {
            assignment["sanitize"] = options.Sanitize.Value;
        }
        if (options?.PreserveNativeType != null)
        {
            assignment["preserve_native_type"] = options.PreserveNativeType.Value;
        }
        var assignments = Config["assignments"] as JsonArray ?? new JsonArray();
        assignments.Add(assignment);
        Config["assignments"] = assignments;
        return this;
    }

    /// <summary>Removes the path param <paramref name="name"/>.</summary>
    public WebhookTool RemovePathParam(string name)
    {
        _pathParams.RemoveAll(param => param.Key == name);
        return this;
    }

    /// <summary>Removes the query param <paramref name="name"/>.</summary>
    public WebhookTool RemoveQueryParam(string name)
    {
        _query = _query?.Without(name);
        return this;
    }

    /// <summary>Removes the request header <paramref name="name"/>.</summary>
    public WebhookTool RemoveHeader(string name)
    {
        _headers.RemoveAll(header => header.Key == name);
        return this;
    }

    /// <summary>Removes every assignment to <paramref name="variable"/>.</summary>
    public WebhookTool RemoveAssignment(string variable)
    {
        if (Config["assignments"] is JsonArray assignments)
        {
            var kept = new JsonArray();
            foreach (var assignment in assignments)
            {
                if (ToolWire.Str(assignment?["dynamic_variable"]) != variable)
                {
                    kept.Add(assignment?.DeepClone());
                }
            }
            Config["assignments"] = kept;
        }
        return this;
    }

    /// <summary>Merges options for webhook tools. An option that doesn't apply is reported by <c>Build()</c>.</summary>
    public WebhookTool Options(WebhookToolOptions options)
    {
        ApplyOptions(options);
        return this;
    }

    private protected override ICollection<string> AllowedOptions => Allowed;

    private protected override void SetOption(string name, JsonNode value)
    {
        if (name == "ContentType" || name == "ResponseFilter")
        {
            _api[SnakeCase(name)] = value;
        }
        else
        {
            base.SetOption(name, value);
        }
    }

    private protected override List<ToolIssue> Validate()
    {
        var issues = new List<ToolIssue>();
        var url = ToolWire.Str(_api["url"]);
        if (url == null)
        {
            issues.Add(
                ToolValidation.Error(
                    "missing_url",
                    null,
                    "Set the method and URL with Get(), Post(), Put(), Patch() or Delete()"
                )
            );
        }
        // As the API does: env var templates aren't placeholders, and the auth connection fills auth_resolved_params.
        var placeholders = Placeholder
            .Matches(EnvVarTemplate.Replace(url ?? "", "env"))
            .Cast<Match>()
            .Select(match => match.Groups[1].Value)
            .ToList();
        var authResolved = ToolWire.StrList(_api["auth_resolved_params"]) ?? new List<string>();
        var pathNames = _pathParams.Select(param => param.Key).ToList();
        foreach (var name in placeholders.Where(p => !pathNames.Contains(p) && !authResolved.Contains(p)))
        {
            issues.Add(
                ToolValidation.Error(
                    "missing_path_param",
                    $"pathParams.{name}",
                    $"The URL has {{{name}}} but no PathParam(\"{name}\")"
                )
            );
        }
        foreach (var param in _pathParams)
        {
            var name = param.Key;
            var path = $"pathParams.{name}";
            if (url != null && !placeholders.Contains(name))
            {
                issues.Add(
                    ToolValidation.Error("unknown_path_param", path, $"PathParam(\"{name}\") has no {{{name}}} in the URL")
                );
            }
            else if (authResolved.Contains(name))
            {
                issues.Add(
                    ToolValidation.Error(
                        "unknown_path_param",
                        path,
                        $"{{{name}}} is filled by the auth connection, not a PathParam"
                    )
                );
            }
            if (!Schema.IsLiteral(param.Value.Kind))
            {
                issues.Add(
                    ToolValidation.Error(
                        "param_not_literal",
                        path,
                        $"Path param \"{name}\" must be a string, integer, number or bool"
                    )
                );
            }
            ToolValidation.CheckSchema(param.Value, path, true, issues);
        }
        if (_query != null)
        {
            foreach (var name in _query.PropertyNames)
            {
                var schema = _query.PropertySchema(name)!;
                var path = $"query.{name}";
                if (!Schema.IsLiteral(schema.Kind))
                {
                    issues.Add(
                        ToolValidation.Error(
                            "param_not_literal",
                            path,
                            $"Query param \"{name}\" must be a string, integer, number or bool"
                        )
                    );
                }
                ToolValidation.CheckSchema(schema, path, true, issues);
            }
        }
        CheckBody("body", _body, issues);
        CheckBody("response", _response, issues);
        var method = ToolWire.Str(_api["method"]);
        if (method == "GET" && _body != null)
        {
            issues.Add(ToolValidation.Error("body_not_allowed", "body", "A GET request can't have a body"));
        }
        if ((method == "POST" || method == "PUT" || method == "PATCH") && _body == null)
        {
            issues.Add(ToolValidation.Error("missing_body", "body", $"A {method} request needs a body"));
        }

        var where = new Dictionary<string, string>();
        void CheckUnique(string location, IEnumerable<string> names)
        {
            foreach (var name in names)
            {
                if (where.TryGetValue(name, out var first))
                {
                    issues.Add(
                        ToolValidation.Error(
                            "duplicate_param",
                            $"{location}.{name}",
                            $"\"{name}\" is in both {first} and {location}; param names must be unique across path, query and body"
                        )
                    );
                }
                else
                {
                    where[name] = location;
                }
            }
        }
        CheckUnique("pathParams", pathNames);
        CheckUnique("query", _query?.PropertyNames ?? new List<string>());
        CheckUnique("body", (_body as ObjectSchema)?.PropertyNames ?? new List<string>());

        var seen = new Dictionary<string, string>();
        foreach (var header in _headers)
        {
            var lower = header.Key.ToLowerInvariant();
            if (seen.TryGetValue(lower, out var other))
            {
                issues.Add(
                    ToolValidation.Error(
                        "duplicate_header",
                        $"headers.{header.Key}",
                        $"Headers \"{other}\" and \"{header.Key}\" differ only in case"
                    )
                );
            }
            seen[lower] = header.Key;
        }

        var timeout = Config["response_timeout_secs"];
        if (ToolWire.IsNumber(timeout))
        {
            var secs = AgentWorkflows.Wire.AsDouble(timeout!);
            if (secs < 5 || secs > 300)
            {
                issues.Add(
                    ToolValidation.Error(
                        "invalid_option",
                        "ResponseTimeoutSecs",
                        "A webhook tool's ResponseTimeoutSecs must be 5–300"
                    )
                );
            }
        }
        var domains = Config["follow_redirects_allowed_domains"] as JsonArray;
        if (ToolWire.IsTrue(Config["follow_redirects"]) && (domains == null || domains.Count == 0))
        {
            issues.Add(
                ToolValidation.Error(
                    "invalid_option",
                    "FollowRedirects",
                    "FollowRedirects needs FollowRedirectsAllowedDomains"
                )
            );
        }
        return issues;
    }

    private protected override JsonObject ToModel()
    {
        var api = new JsonObject();
        foreach (var field in _api)
        {
            api[field.Key] = field.Value?.DeepClone();
        }
        if (_pathParams.Count > 0)
        {
            var pathParams = new JsonObject();
            foreach (var param in _pathParams)
            {
                pathParams[param.Key] = param.Value.ToWire();
            }
            api["path_params_schema"] = pathParams;
        }
        // The API's query params schema has only properties and required.
        var query = _query?.ToWire();
        if (query?["properties"] is JsonNode properties)
        {
            var queryOut = new JsonObject { ["properties"] = properties.DeepClone() };
            if (query["required"] is JsonNode required)
            {
                queryOut["required"] = required.DeepClone();
            }
            api["query_params_schema"] = queryOut;
        }
        if (_body != null)
        {
            api["request_body_schema"] = _body.ToWire();
        }
        if (_response != null)
        {
            api["response_body_schema"] = _response.ToWire();
        }
        if (_headers.Count > 0)
        {
            var headers = new JsonObject();
            foreach (var header in _headers)
            {
                headers[header.Key] = header.Value.DeepClone();
            }
            api["request_headers"] = headers;
        }
        var model = CopyConfig();
        model["type"] = "webhook";
        model["api_schema"] = api;
        return model;
    }

    private static void CheckBody(string label, Schema? schema, List<ToolIssue> issues)
    {
        if (schema == null)
        {
            return;
        }
        if (schema.Kind != SchemaKind.Object)
        {
            issues.Add(ToolValidation.Error("body_not_object", label, $"The {label} schema must be an object"));
        }
        ToolValidation.CheckSchema(schema, label, false, issues);
    }

    /// <summary>Sets <paramref name="name"/>, replacing an existing entry in place.</summary>
    private static void SetEntry<T>(List<KeyValuePair<string, T>> entries, string name, T value)
    {
        var index = entries.FindIndex(entry => entry.Key == name);
        var item = new KeyValuePair<string, T>(name, value);
        if (index == -1)
        {
            entries.Add(item);
        }
        else
        {
            entries[index] = item;
        }
    }

    private WebhookTool Request(string method, string url)
    {
        _api["method"] = method;
        _api["url"] = url;
        return this;
    }
}
