using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Nodes;
using ElevenLabs.AgentWorkflows;
using ElevenLabs.Core;
using NUnit.Framework;

namespace ElevenLabs.Tests;

// Inside the namespace, so these win over the generated ElevenLabs.Tool / ObjectSchema / ArraySchema models.
using ElevenLabs.AgentTools;

/// <summary>
/// Hand-written coverage for the tool builder beyond the shared fixtures, ported from elevenlabs-js
/// <c>tests/custom/agents/tools/tools.test.ts</c>, plus <c>Build()</c> returning the generated request model.
/// </summary>
[TestFixture]
public class ToolBuilderTest
{
    private static WebhookTool GetOrder() =>
        Tool.Webhook("get_order", "Look up an order")
            .Get("https://api.example.com/orders/{order_id}")
            .PathParam("order_id", Schema.String().Describe("The order number"));

    private static List<ToolIssue> IssuesOf(Action build)
    {
        try
        {
            build();
        }
        catch (ToolValidationException ex)
        {
            return ex.Issues.ToList();
        }
        throw new AssertionException("expected a ToolValidationException");
    }

    private static List<string> CodesOf(Action build) => IssuesOf(build).Select(issue => issue.Code).ToList();

    private static string[] Pair(ToolIssue issue) => new[] { issue.Code, issue.Path ?? "" };

    private static JsonNode? Api(Tool tool, string key) => tool.ToJson()["api_schema"]?[key];

    private static void AssertJson(JsonNode? actual, string expected) =>
        Assert.That(
            JsonNode.DeepEquals(actual, JsonNode.Parse(expected)),
            Is.True,
            $"Expected {expected}\nbut was {actual?.ToJsonString()}"
        );

    // Schema

    [Test]
    public void SchemaIsSharedAndEditingOneToolsCopyLeavesOthersAlone()
    {
        var orderId = Schema.String().Describe("The order number");
        var lookup = Tool.Webhook("lookup", "Look up").Get("https://api.example.com/{id}").PathParam("id", orderId);
        var cancel = Tool.Webhook("cancel", "Cancel")
            .Post("https://api.example.com/cancel")
            .Body(Schema.Object().Property("id", orderId));

        var body = (ObjectSchema)cancel.BodySchema!;
        cancel.Body(body.Property("id", orderId.Optional()));

        AssertJson(Api(lookup, "path_params_schema"), """{"id":{"description":"The order number","type":"string"}}""");
        AssertJson(
            Api(cancel, "request_body_schema"),
            """{"properties":{"id":{"description":"The order number","type":"string"}},"type":"object"}"""
        );
    }

    [Test]
    public void LoadsPropertiesNotInRequiredAsOptional()
    {
        var schema = Schema.FromJson(
            """{"properties":{"a":{"type":"string"},"b":{"type":"string"}},"required":["a"],"type":"object"}"""
        );
        Assert.That(schema.Kind, Is.EqualTo(SchemaKind.Object));
        var obj = (ObjectSchema)schema;
        Assert.That(obj.PropertySchema("a")!.IsOptional, Is.False);
        Assert.That(obj.PropertySchema("b")!.IsOptional, Is.True);
    }

    [Test]
    public void SchemaMethodsReturnTheirSubtypeAndNeverMutate()
    {
        var plain = Schema.String();
        LiteralSchema described = plain.Describe("A").Choices("x", "y").Optional();
        ObjectSchema obj = Schema.Object().Describe("A container").Property("a", described).RequireAnyOf("a");
        ArraySchema arr = Schema.Array(described).FromVariable("list");

        Assert.That(plain.ToJson().ToJsonString(), Is.EqualTo("""{"type":"string"}"""));
        Assert.That(described.IsOptional, Is.True);
        Assert.That(obj.PropertyNames, Is.EqualTo(new[] { "a" }));
        Assert.That(arr.Items!.Kind, Is.EqualTo(SchemaKind.String));
        Assert.That(arr.Kind, Is.EqualTo(SchemaKind.Array));
    }

    [Test]
    public void ConstantTakesAnyJsonValue()
    {
        var tool = Tool.Client("t", "T")
            .Param("count", Schema.Integer().Constant(10))
            .Param("ratio", Schema.Number().Constant(1.5))
            .Param("flag", Schema.Bool().Constant(true))
            .Param("label", Schema.String().Constant("fixed"))
            .Param("shape", Schema.Object().Constant(new JsonObject { ["a"] = 1 }))
            .Param("tags", Schema.Array(Schema.String().Describe("A tag")).Constant(new JsonArray("x", "y")));
        AssertJson(
            tool.ToJson()["parameters"]!["properties"],
            """
            {
              "count": {"constant_value": 10, "type": "integer"},
              "flag": {"constant_value": true, "type": "boolean"},
              "label": {"constant_value": "fixed", "type": "string"},
              "ratio": {"constant_value": 1.5, "type": "number"},
              "shape": {"constant_value": {"a": 1}, "type": "object"},
              "tags": {"constant_value": ["x", "y"], "items": {"description": "A tag", "type": "string"}, "type": "array"}
            }
            """
        );
        Assert.That(
            CodesOf(() => Tool.Client("t", "T").Param("n", Schema.Integer().Constant("1")).Build()),
            Is.EqualTo(new[] { "constant_type_mismatch" })
        );
    }

    // WebhookTool

    [Test]
    public void BuildReturnsGeneratedRequestModel()
    {
        var request = GetOrder()
            .Header("Authorization", Header.Secret("sec_1"))
            .Options(new WebhookToolOptions { ResponseTimeoutSecs = 10 })
            .Build();

        Assert.That(request.ToolConfig.IsWebhook, Is.True);
        var config = request.ToolConfig.AsWebhook();
        Assert.That(config.Name, Is.EqualTo("get_order"));
        Assert.That(config.Description, Is.EqualTo("Look up an order"));
        Assert.That(config.ResponseTimeoutSecs, Is.EqualTo(10));
        Assert.That(config.ApiSchema.Url, Is.EqualTo("https://api.example.com/orders/{order_id}"));
        Assert.That(config.ApiSchema.PathParamsSchema!.Keys, Is.EqualTo(new[] { "order_id" }));
        Assert.That(config.ApiSchema.PathParamsSchema["order_id"].Description, Is.EqualTo("The order number"));
        Assert.That(config.ApiSchema.RequestHeaders!.Keys, Is.EqualTo(new[] { "Authorization" }));

        // The model serializes back to the same wire JSON.
        AssertJson(Wire.Canonicalize(JsonUtils.SerializeToNode(request.ToolConfig)), GetOrderJson());
    }

    private static string GetOrderJson() =>
        GetOrder()
            .Header("Authorization", Header.Secret("sec_1"))
            .Options(new WebhookToolOptions { ResponseTimeoutSecs = 10 })
            .ToJson()
            .ToJsonString();

    [Test]
    public void ReplacesAParamWithTheSameNameInPlace()
    {
        var tool = Tool.Webhook("search", "Search")
            .Get("https://api.example.com/search")
            .QueryParam("q", Schema.String().Describe("Query"))
            .QueryParam("limit", Schema.Integer().Constant(10))
            .QueryParam("q", Schema.String().Describe("Search terms"));
        AssertJson(
            Api(tool, "query_params_schema"),
            """
            {
              "properties": {
                "limit": {"constant_value": 10, "type": "integer"},
                "q": {"description": "Search terms", "type": "string"}
              },
              "required": ["q", "limit"]
            }
            """
        );
    }

    [Test]
    public void RemovesParamsHeadersAndAssignments()
    {
        var tool = GetOrder()
            .QueryParam("q", Schema.String().Describe("Query"))
            .Header("X-A", Header.Value("1"))
            .Assign("a", "a")
            .Assign("b", "b")
            .RemoveQueryParam("q")
            .RemoveHeader("X-A")
            .RemoveAssignment("a")
            .RemoveHeader("missing")
            .RemovePathParam("missing");
        var json = tool.ToJson();
        Assert.That(json["api_schema"]!["query_params_schema"], Is.Null);
        Assert.That(json["api_schema"]!["request_headers"], Is.Null);
        AssertJson(json["assignments"], """[{"dynamic_variable":"b","source":"response","value_path":"b"}]""");
    }

    [Test]
    public void RemovingAMissingAssignmentDoesNothing()
    {
        Assert.That(GetOrder().RemoveAssignment("a").ToJson().ContainsKey("assignments"), Is.False);
    }

    [Test]
    public void ExposesTheBodySchemaForEditing()
    {
        var tool = Tool.Webhook("refund", "Refund")
            .Post("https://api.example.com/refunds")
            .Body(Schema.Object().Property("a", Schema.String().Describe("A")));
        var body = (ObjectSchema)tool.BodySchema!;
        tool.Body(body.Without("a").Property("b", Schema.String().Describe("B")));
        AssertJson(
            Api(tool, "request_body_schema"),
            """{"properties":{"b":{"description":"B","type":"string"}},"required":["b"],"type":"object"}"""
        );
    }

    [Test]
    public void ReportsEveryProblemAtOnceWithPaths()
    {
        var issues = IssuesOf(() =>
            Tool.Webhook("broken", "Broken")
                .Get("https://api.example.com/{a}")
                .PathParam("b", Schema.String().Describe("B").FromVariable("b"))
                .Build()
        );
        Assert.That(
            issues.Select(Pair),
            Is.EqualTo(
                new[]
                {
                    new[] { "missing_path_param", "pathParams.a" },
                    new[] { "unknown_path_param", "pathParams.b" },
                    new[] { "conflicting_value_source", "pathParams.b" },
                }
            )
        );
    }

    [Test]
    public void NamesTheToolAndListsTheProblemsInTheMessage()
    {
        var ex = Assert.Throws<ToolValidationException>(() => Tool.Webhook("broken", "Broken").Build());
        Assert.That(
            ex!.Message,
            Is.EqualTo("Invalid tool \"broken\":\n  - Set the method and URL with Get(), Post(), Put(), Patch() or Delete()")
        );
    }

    [Test]
    public void NeedsAValueSourceOnEveryLiteral()
    {
        var issues = IssuesOf(() =>
            Tool.Webhook("save", "Save")
                .Post("https://api.example.com/save")
                .QueryParam("q", Schema.String())
                .Body(
                    Schema
                        .Object()
                        .Property("profile", Schema.Object().FromVariable("profile").Property("name", Schema.String()))
                )
                .Response(Schema.Object().Property("status", Schema.String()))
                .Build()
        );
        Assert.That(
            issues.Select(Pair),
            Is.EqualTo(
                new[]
                {
                    new[] { "missing_value_source", "query.q" },
                    new[] { "missing_value_source", "body.profile.name" },
                    new[] { "missing_value_source", "response.status" },
                }
            )
        );
    }

    [Test]
    public void RequiresABodyOnPostPutPatchAllowsOneOnDeleteAndForbidsOneOnGet()
    {
        var body = Schema.Object().Property("note", Schema.String().Describe("A note"));
        const string url = "https://api.example.com/notes";
        var methods = new Func<WebhookTool, string, WebhookTool>[]
        {
            (t, u) => t.Post(u),
            (t, u) => t.Put(u),
            (t, u) => t.Patch(u),
        };
        foreach (var method in methods)
        {
            Assert.That(CodesOf(() => method(Tool.Webhook("t", "T"), url).Build()), Is.EqualTo(new[] { "missing_body" }));
            Assert.DoesNotThrow(() => method(Tool.Webhook("t", "T"), url).Body(body).Build());
        }
        Assert.DoesNotThrow(() => Tool.Webhook("t", "T").Delete(url).Build());
        Assert.DoesNotThrow(() => Tool.Webhook("t", "T").Delete(url).Body(body).Build());
        Assert.That(
            CodesOf(() => Tool.Webhook("t", "T").Get(url).Body(body).Build()),
            Is.EqualTo(new[] { "body_not_allowed" })
        );
        Assert.DoesNotThrow(() =>
            Tool.Webhook("t", "T").Get(url).Options(new WebhookToolOptions { ContentType = "application/json" }).Build()
        );
    }

    [Test]
    public void NeedsParamNamesUniqueAcrossPathQueryAndBody()
    {
        var issues = IssuesOf(() =>
            Tool.Webhook("t", "T")
                .Post("https://api.example.com/orders")
                .QueryParam("id", Schema.String().Describe("Id"))
                .Body(Schema.Object().Property("id", Schema.String().Describe("Id")))
                .Build()
        );
        Assert.That(issues.Select(Pair), Is.EqualTo(new[] { new[] { "duplicate_param", "body.id" } }));
    }

    [Test]
    public void AcceptsWebhookResponseTimeoutsFrom5To300Seconds()
    {
        Action Timeout(int secs) => () => GetOrder().Options(new WebhookToolOptions { ResponseTimeoutSecs = secs }).Build();
        Assert.DoesNotThrow(() => Timeout(5)());
        Assert.DoesNotThrow(() => Timeout(300)());
        Assert.That(CodesOf(Timeout(4)), Is.EqualTo(new[] { "invalid_option" }));
        Assert.That(CodesOf(Timeout(301)), Is.EqualTo(new[] { "invalid_option" }));
    }

    [Test]
    public void FollowsRedirectsOnlyToAnAllowedListOfDomains()
    {
        Action Redirects(IReadOnlyList<string>? domains) =>
            () =>
                GetOrder()
                    .Options(new WebhookToolOptions { FollowRedirects = true, FollowRedirectsAllowedDomains = domains })
                    .Build();
        Assert.DoesNotThrow(() => Redirects(new[] { "example.com" })());
        Assert.That(CodesOf(Redirects(null)), Is.EqualTo(new[] { "invalid_option" }));
    }

    [Test]
    public void RecordsAnOptionOfAnotherKindAsInvalid()
    {
        var issues = IssuesOf(() => GetOrder().Options(new ClientToolOptions { ExpectsResponse = true }).Build());
        Assert.That(issues.Select(Pair), Is.EqualTo(new[] { new[] { "invalid_option", "ExpectsResponse" } }));
    }

    [Test]
    public void SwitchesALoadedParamsValueSourceByReplacingThePropertyInPlace()
    {
        var loaded = Tool.FromJson(
                Tool.Webhook("refund", "Refund")
                    .Post("https://api.example.com/refunds")
                    .Body(
                        Schema
                            .Object()
                            .Property("order_id", Schema.String().Describe("The order number"))
                            .Property("reason", Schema.String().Describe("Why"))
                    )
                    .ToJson()
            )
            .AsWebhook()!;
        var body = (ObjectSchema)loaded.BodySchema!;
        loaded.Body(body.Property("order_id", Schema.String().FromVariable("order_id")));
        AssertJson(
            Api(loaded, "request_body_schema"),
            """
            {
              "properties": {
                "order_id": {"dynamic_variable": "order_id", "type": "string"},
                "reason": {"description": "Why", "type": "string"}
              },
              "required": ["order_id", "reason"],
              "type": "object"
            }
            """
        );
    }

    // Value sources

    [Test]
    public void TreatsAnEmptyDescriptionOrVariableNameAsNoSource()
    {
        Action Param(Schema schema) => () => Tool.Client("t", "T").Param("x", schema).Build();
        Assert.That(CodesOf(Param(Schema.String().Describe(""))), Is.EqualTo(new[] { "missing_value_source" }));
        Assert.That(CodesOf(Param(Schema.String().FromVariable(""))), Is.EqualTo(new[] { "missing_value_source" }));
        Assert.That(
            CodesOf(Param(Schema.String().Describe("").AllowedFrom("fares"))),
            Is.EqualTo(new[] { "allowed_values_needs_description", "missing_value_source" })
        );
    }

    [Test]
    public void AcceptsAConstantOfANullableLiteralTypeAndWritesTheTypeBack()
    {
        foreach (var (type, value) in new[] { ("integer", "42"), ("number", "1.5"), ("boolean", "true") })
        {
            var raw =
                "{\"description\":\"T\",\"name\":\"t\",\"parameters\":{\"properties\":{\"x\":{\"constant_value\":"
                + value
                + ",\"type\":[\""
                + type
                + "\",\"null\"]}},\"required\":[\"x\"],\"type\":\"object\"},\"type\":\"client\"}";
            var tool = Tool.FromJson(raw);
            Assert.DoesNotThrow(() => tool.Build());
            AssertJson(tool.ToJson(), raw);
        }
    }

    [Test]
    public void StillRejectsAConstantOfTheWrongTypeForANullableLiteral()
    {
        var raw =
            """{"name":"t","description":"T","type":"client","parameters":{"type":"object","properties":{"x":{"type":["integer","null"],"constant_value":"a"}}}}""";
        Assert.That(CodesOf(() => Tool.FromJson(raw).Build()), Is.EqualTo(new[] { "constant_type_mismatch" }));
    }

    [Test]
    public void ReadsLoadedNullsAsAbsent()
    {
        var tool = Tool.FromJson(
            """
            {
              "name": "t", "description": "T", "type": "client", "execution_mode": null,
              "parameters": {"type": "object", "properties": {"x": {"type": "string", "description": "X", "constant_value": null, "dynamic_variable": null}}, "required": ["x"]}
            }
            """
        );
        AssertJson(
            tool.ToJson(),
            """{"description":"T","name":"t","parameters":{"properties":{"x":{"description":"X","type":"string"}},"required":["x"],"type":"object"},"type":"client"}"""
        );
    }

    // ClientTool

    [Test]
    public void LoadsEmptyParamsWithNoTypeAsAnObjectAndCanAddToThem()
    {
        var tool = Tool.FromJson("""{"name":"t","description":"T","type":"client","parameters":{}}""").AsClient()!;
        Assert.That(tool.ParametersSchema!.Kind, Is.EqualTo(SchemaKind.Object));
        Assert.DoesNotThrow(() => tool.Param("x", Schema.String().Describe("X")).Build());
    }

    [Test]
    public void ChecksRequireAnyOfOnTheParamsObjectAgainstTheParamsItStillHas()
    {
        var tool = Tool.FromJson(
                """
                {
                  "name": "t", "description": "T", "type": "client",
                  "parameters": {
                    "type": "object",
                    "properties": {"a": {"type": "string", "description": "A"}, "b": {"type": "string", "description": "B"}},
                    "required_constraints": {"any_of": [{"required": ["a", "b"]}]}
                  }
                }
                """
            )
            .AsClient()!;
        Assert.DoesNotThrow(() => tool.Build());
        tool.RemoveParam("b");
        Assert.That(
            IssuesOf(() => tool.Build()).Select(Pair),
            Is.EqualTo(new[] { new[] { "unknown_required_property", "params" } })
        );
    }

    [Test]
    public void RemovesClientParams()
    {
        var tool = Tool.Client("show", "Show something")
            .Param("a", Schema.String().Describe("A"))
            .Param("b", Schema.String().Describe("B"))
            .RemoveParam("a");
        Assert.That(tool.ParametersSchema!.PropertyNames, Is.EqualTo(new[] { "b" }));
    }

    [Test]
    public void LeavesParametersOutWhenThereAreNone()
    {
        Assert.That(
            Tool.Client("ping", "Ping the client").ToJsonString(),
            Is.EqualTo("{\n  \"description\": \"Ping the client\",\n  \"name\": \"ping\",\n  \"type\": \"client\"\n}\n")
        );
    }

    [Test]
    public void AcceptsClientResponseTimeoutsFrom1To120OrMinus1WithExpectsResponse()
    {
        Action Timeout(ClientToolOptions options) => () => Tool.Client("wait", "Wait").Options(options).Build();
        Assert.DoesNotThrow(() => Timeout(new ClientToolOptions { ResponseTimeoutSecs = 1 })());
        Assert.DoesNotThrow(() => Timeout(new ClientToolOptions { ResponseTimeoutSecs = 120 })());
        Assert.DoesNotThrow(() => Timeout(new ClientToolOptions { ResponseTimeoutSecs = -1, ExpectsResponse = true })());
        foreach (var secs in new[] { 0, 121, -1 })
        {
            Assert.That(
                CodesOf(Timeout(new ClientToolOptions { ResponseTimeoutSecs = secs })),
                Is.EqualTo(new[] { "invalid_option" })
            );
        }
    }

    [Test]
    public void ClientBuildReturnsGeneratedRequestModel()
    {
        var config = Tool.Client("show_store_map", "Show a map")
            .Param("store_id", Schema.String().Describe("The store to show"))
            .Options(new ClientToolOptions { ExpectsResponse = false })
            .Build()
            .ToolConfig.AsClient();
        Assert.That(config.Name, Is.EqualTo("show_store_map"));
        Assert.That(config.ExpectsResponse, Is.False);
        Assert.That(config.Parameters!.Required, Is.EqualTo(new[] { "store_id" }));
    }

    // SystemTool

    [Test]
    public void BuildsAnEntryForPromptBuiltInTools()
    {
        var builtIn = new BuiltInToolsInput { EndCall = SystemTool.EndCall().BuildConfig() };
        Assert.That(builtIn.EndCall!.Name, Is.EqualTo("end_call"));
        Assert.That(builtIn.EndCall.Params.IsEndCall, Is.True);
        AssertJson(
            JsonUtils.SerializeToNode(builtIn)!["end_call"],
            """{"name":"end_call","params":{"system_tool_type":"end_call"},"type":"system"}"""
        );
    }

    [Test]
    public void RejectsTransferOnAToolThatDoesntTransfer()
    {
        Assert.That(
            CodesOf(() => SystemTool.EndCall().Transfer("Caller asks", Destination.Phone("+15551234567")).Build()),
            Is.EqualTo(new[] { "invalid_option" })
        );
    }

    [Test]
    public void TransfersToASipUriOnlyWithASipRefer()
    {
        foreach (var sip in new[] { Destination.Sip("sip:sales@pbx.example.com"), Destination.SipVariable("partner_sip") })
        {
            Assert.DoesNotThrow(() =>
                SystemTool.TransferToNumber()
                    .Transfer("Caller wants sales", sip, new SystemTransferOptions { TransferType = "sip_refer" })
                    .Build()
            );
            Assert.That(
                CodesOf(() => SystemTool.TransferToNumber().Transfer("Caller wants sales", sip).Build()),
                Is.EqualTo(new[] { "invalid_destination", "no_transfers" })
            );
        }
    }

    [Test]
    public void RejectsOptionsOfTheOtherTransferKind()
    {
        var issues = IssuesOf(() =>
            SystemTool.TransferToAgent()
                .Transfer(
                    "Caller wants sales",
                    Destination.Agent("agent_sales"),
                    new SystemTransferOptions { TransferType = "conference" }
                )
                .Build()
        );
        Assert.That(issues.Select(Pair), Is.EqualTo(new[] { new[] { "invalid_option", "TransferType" } }));
    }

    [Test]
    public void SystemToolOptionsSetNameAndDescription()
    {
        var config = SystemTool.TransferToAgent()
            .Transfer("Caller wants sales", Destination.Agent("agent_sales", "intro"))
            .Options(new CommonToolOptions { Name = "handoff", Description = "Hand off" })
            .BuildConfig();
        Assert.That(config.Name, Is.EqualTo("handoff"));
        Assert.That(config.Description, Is.EqualTo("Hand off"));
        Assert.That(config.Params.IsTransferToAgent, Is.True);
    }

    // Loading

    [Test]
    public void LoadsEmptyWebhookBodyAndResponseSchemasWithNoTypeAsObjects()
    {
        var tool = Tool.FromJson(
                """{"name":"t","description":"T","type":"webhook","api_schema":{"url":"https://api.example.com/t","method":"POST","request_body_schema":{},"response_body_schema":{}}}"""
            )
            .AsWebhook()!;
        Assert.That(tool.BodySchema!.Kind, Is.EqualTo(SchemaKind.Object));
        Assert.That(tool.ResponseSchema!.Kind, Is.EqualTo(SchemaKind.Object));
    }

    [Test]
    public void LoadsARequestOrResponseWrapperWithAToolConfigKey()
    {
        var config = GetOrder().ToJson();
        AssertJson(Tool.FromJson(new JsonObject { ["tool_config"] = config.DeepClone() }).ToJson(), config.ToJsonString());
        AssertJson(Tool.FromJson(config.ToJsonString()).ToJson(), config.ToJsonString());
        Assert.That(Tool.FromJson(GetOrder().ToJsonString()).ToJsonString(), Is.EqualTo(GetOrder().ToJsonString()));
    }

    [Test]
    public void LoadsTheResultOfToolsGet()
    {
        var response = JsonUtils.Deserialize<ToolResponseModel>(
            new JsonObject
            {
                ["id"] = "tool_1",
                ["tool_config"] = GetOrder().ToJson(),
                ["access_info"] = new JsonObject
                {
                    ["is_creator"] = true,
                    ["creator_name"] = "Creator",
                    ["creator_email"] = "creator@example.com",
                    ["role"] = "admin",
                },
                ["usage_stats"] = new JsonObject { ["avg_latency_secs"] = 0.5 },
            }.ToJsonString()
        );
        var tool = Tool.FromResponse(response);
        Assert.That(tool.Kind, Is.EqualTo(ToolKind.Webhook));
        Assert.That(tool.ToJsonString(), Is.EqualTo(GetOrder().ToJsonString()));
    }

    [Test]
    public void KeepsAToolOfAnUnknownTypeAndWarnsWhenItsBuilt()
    {
        var tool = Tool.FromJson("""{"name":"search","type":"mcp","mcp_server_id":"mcp_1"}""");
        Assert.That(tool.Kind, Is.EqualTo(ToolKind.Other));
        Assert.That(tool.AsWebhook(), Is.Null);
        Assert.That(tool.AsClient(), Is.Null);
        Assert.That(tool.AsSystem(), Is.Null);
        var warnings = new List<ToolIssue>();
        var request = tool.Build(warnings.Add);
        Assert.That(warnings.Select(w => w.Code), Is.EqualTo(new[] { "unknown_tool_type" }));
        Assert.That(request.ToolConfig.Type, Is.EqualTo("mcp"));
        AssertJson(tool.ToJson(), """{"mcp_server_id":"mcp_1","name":"search","type":"mcp"}""");
    }

    [Test]
    public void KeepsALoadedSystemToolTypeTheBuilderHasNoConstructorFor()
    {
        const string raw =
            """{"name":"start_procedure","params":{"procedures":{"refund":{"procedure_id":"proc_1"}},"system_tool_type":"start_procedure"},"type":"system"}""";
        var tool = Tool.FromJson(raw);
        Assert.That(tool.AsSystem()!.SystemToolType, Is.EqualTo("start_procedure"));
        AssertJson(tool.ToJson(), raw);
    }

    [Test]
    public void BuildDeserializesEveryFixtureIntoTheGeneratedModel()
    {
        var built = 0;
        foreach (TestCaseData data in ToolFixtureTest.Fixtures())
        {
            var fixture = (JsonObject)JsonNode.Parse((string)data.Arguments[0]!)!;
            if (fixture["expected"] == null || fixture["schema"] != null)
            {
                continue;
            }
            // Re-load the expected output: Build() must accept it and serialize back to the same JSON.
            var tool = Tool.FromJson(fixture["expected"]!);
            var request = tool.Build();
            AssertJson(Wire.Canonicalize(JsonUtils.SerializeToNode(request.ToolConfig)), tool.ToJson().ToJsonString());
            built++;
        }
        Assert.That(built, Is.EqualTo(13));
    }

    // Review fixes on #9. Each test is a regression test for one item.

    private static void AssertRoundTrip(string raw)
    {
        var tool = Tool.FromJson(raw);
        AssertJson(tool.ToJson(), raw);
        AssertBuildMatchesJson(tool);
    }

    /// <summary>The request Build() returns serializes to exactly what ToJson() shows.</summary>
    private static void AssertBuildMatchesJson(Tool tool) =>
        AssertJson(Wire.Canonicalize(JsonUtils.SerializeToNode(tool.Build().ToolConfig)), tool.ToJson().ToJsonString());

    private static string WebhookWith(string apiFields, string topFields = "") =>
        "{\"name\":\"t\",\"description\":\"T\",\"type\":\"webhook\"" + topFields
        + ",\"api_schema\":{\"method\":\"GET\",\"url\":\"https://api.example.com/t\"" + apiFields + "}}";

    [Test]
    public void RemovingTheLastAssignmentLeavesTheFieldOut()
    {
        var json = GetOrder().Assign("a", "a").RemoveAssignment("a").ToJson();
        Assert.That(json.ContainsKey("assignments"), Is.False);
    }

    [Test]
    public void LoadedEmptyAssignmentsRoundTripAndRemovingAMissingOneChangesNothing()
    {
        var empty = WebhookWith("", ",\"assignments\":[]");
        AssertRoundTrip(empty);
        AssertJson(Tool.FromJson(empty).AsWebhook()!.RemoveAssignment("missing").ToJson(), empty);

        var one = WebhookWith("", ",\"assignments\":[{\"dynamic_variable\":\"a\",\"source\":\"response\",\"value_path\":\"a\"}]");
        AssertJson(Tool.FromJson(one).AsWebhook()!.RemoveAssignment("missing").ToJson(), one);
    }

    [Test]
    public void RemovingTheLastClientParamLeavesParametersOut()
    {
        var tool = Tool.Client("t", "T").Param("a", Schema.String().Describe("A")).RemoveParam("a");
        Assert.That(tool.ToJson().ContainsKey("parameters"), Is.False);
        Assert.That(tool.ParametersSchema, Is.Null);

        var loaded = Tool.FromJson(
                """{"name":"t","description":"T","type":"client","parameters":{"type":"object","description":"P","properties":{"a":{"type":"string","description":"A"}},"required":["a"]}}"""
            )
            .AsClient()!;
        Assert.That(loaded.RemoveParam("a").ToJson().ContainsKey("parameters"), Is.False);
    }

    [Test]
    public void LoadedEmptyParametersRoundTripAndRemovingAMissingParamChangesNothing()
    {
        const string raw = """{"name":"t","description":"T","type":"client","parameters":{"type":"object"}}""";
        AssertRoundTrip(raw);
        AssertJson(Tool.FromJson(raw).AsClient()!.RemoveParam("missing").ToJson(), raw);
    }

    [Test]
    public void AnEmptyUrlCountsAsMissing()
    {
        Assert.That(CodesOf(() => Tool.Webhook("t", "T").Get("").Build()), Is.EqualTo(new[] { "missing_url" }));
        Assert.That(
            CodesOf(() => Tool.FromJson("""{"name":"t","description":"T","type":"webhook","api_schema":{"method":"GET","url":""}}""").Build()),
            Is.EqualTo(new[] { "missing_url" })
        );
    }

    [Test]
    public void KeepsALoadedBodyOrResponseOfAnotherTypeAndReportsIt()
    {
        var body = Tool.FromJson(
            """{"name":"t","description":"T","type":"webhook","api_schema":{"method":"POST","url":"https://api.example.com/t","request_body_schema":{"type":"string","description":"X"},"response_body_schema":{"type":"array","items":{"type":"string","description":"A tag"}}}}"""
        );
        var webhook = body.AsWebhook()!;
        Assert.That(webhook.BodySchema!.Kind, Is.EqualTo(SchemaKind.String));
        Assert.That(webhook.ResponseSchema!.Kind, Is.EqualTo(SchemaKind.Array));
        Assert.That(
            IssuesOf(() => body.Build()).Select(Pair),
            Is.EqualTo(new[] { new[] { "body_not_object", "body" }, new[] { "body_not_object", "response" } })
        );
    }

    [Test]
    public void KeepsLoadedClientParametersOfAnotherTypeAndReportsThem()
    {
        var tool = Tool.FromJson(
            """{"name":"t","description":"T","type":"client","parameters":{"type":"string","description":"X"}}"""
        );
        Assert.That(tool.AsClient()!.ParametersSchema, Is.Null);
        tool.AsClient()!.Param("a", Schema.String().Describe("A"));
        Assert.That(IssuesOf(() => tool.Build()).Select(Pair), Is.EqualTo(new[] { new[] { "body_not_object", "params" } }));
    }

    [Test]
    public void KeepsALoadedQuerySchemaOfAnotherTypeAndReportsIt()
    {
        var tool = Tool.FromJson(WebhookWith(",\"query_params_schema\":{\"type\":\"string\",\"description\":\"X\"}"));
        Assert.That(IssuesOf(() => tool.Build()).Select(Pair), Is.EqualTo(new[] { new[] { "body_not_object", "query" } }));
    }

    [Test]
    public void InfersAndWritesObjectForUntypedBodyResponseAndParameters()
    {
        var webhook = Tool.FromJson(
            """{"name":"t","description":"T","type":"webhook","api_schema":{"method":"POST","url":"https://api.example.com/t","request_body_schema":{},"response_body_schema":{"properties":{"a":{"type":"string","description":"A"}}}}}"""
        );
        AssertJson(Api(webhook, "request_body_schema"), """{"type":"object"}""");
        AssertJson(Api(webhook, "response_body_schema"), """{"properties":{"a":{"description":"A","type":"string"}},"type":"object"}""");
        var client = Tool.FromJson("""{"name":"t","description":"T","type":"client","parameters":{}}""");
        AssertJson(client.ToJson()["parameters"], """{"type":"object"}""");
        AssertBuildMatchesJson(webhook);
    }

    [Test]
    public void KeepsANullConstantOfANullableLiteralThroughToJsonAndBuild()
    {
        const string raw =
            """{"description":"T","name":"t","parameters":{"properties":{"x":{"constant_value":null,"type":["integer","null"]}},"required":["x"],"type":"object"},"type":"client"}""";
        AssertRoundTrip(raw);
        var sent = JsonNode.Parse(JsonUtils.Serialize(Tool.FromJson(raw).Build()))!.ToJsonString();
        Assert.That(sent, Does.Contain("\"constant_value\":null"));
    }

    [Test]
    public void ReadsANullConstantOfANonNullableLiteralAsAbsent()
    {
        var tool = Tool.FromJson(
            """{"name":"t","description":"T","type":"client","parameters":{"type":"object","properties":{"x":{"type":"integer","constant_value":null}},"required":["x"]}}"""
        );
        Assert.That(CodesOf(() => tool.Build()), Is.EqualTo(new[] { "missing_value_source" }));
    }

    [Test]
    public void KeepsEveryLoadedQueryFieldAndOnlyDropsTheSyntheticType()
    {
        AssertRoundTrip(
            WebhookWith(
                ",\"query_params_schema\":{\"description\":\"Q\",\"properties\":{\"a\":{\"description\":\"A\",\"type\":\"string\"}},\"required\":[\"a\"],\"x-extra\":1}"
            )
        );
        // The generated QueryParamsJsonSchemaInput always has `properties`, so Build() sends `{}` for these two.
        foreach (var query in new[] { "{\"description\":\"Only extras\",\"x-extra\":1}", "{}" })
        {
            var raw = WebhookWith(",\"query_params_schema\":" + query);
            AssertJson(Tool.FromJson(raw).ToJson(), raw);
        }
        AssertRoundTrip(
            WebhookWith(",\"query_params_schema\":{\"properties\":{\"a\":{\"description\":\"A\",\"type\":\"string\"}},\"type\":\"object\"}")
        );
        var edited = Tool.FromJson(WebhookWith(",\"query_params_schema\":{\"description\":\"Q\"}"))
            .AsWebhook()!
            .QueryParam("b", Schema.String().Describe("B"));
        AssertJson(
            Api(edited, "query_params_schema"),
            """{"description":"Q","properties":{"b":{"description":"B","type":"string"}},"required":["b"]}"""
        );
    }

    [Test]
    public void KeepsAnIntegerConstantADoubleCantHoldExactlyInBuild()
    {
        var tool = Tool.Client("t", "T").Param("big", Schema.Integer().Constant(9007199254740993L));
        Assert.That(tool.ToJsonString(), Does.Contain("\"constant_value\": 9007199254740993"));
        var sent = JsonNode.Parse(JsonUtils.Serialize(tool.Build()))!.ToJsonString();
        Assert.That(sent, Does.Contain("\"constant_value\":9007199254740993"));
        AssertBuildMatchesJson(tool);

        // A constant the model holds exactly stays in the typed property.
        var small = Tool.Client("t", "T").Param("n", Schema.Integer().Constant(10)).Build().ToolConfig.AsClient();
        Assert.That(small.Parameters!.Properties!["n"].AsLiteralJsonSchemaProperty().ConstantValue!.Value.AsT1, Is.EqualTo(10));
    }

    [Test]
    public void KeepsLoadedRequiredConstraintsExtrasAndEmptyGroups()
    {
        const string raw =
            """{"description":"T","name":"t","parameters":{"properties":{"a":{"description":"A","type":"string"},"b":{"description":"B","type":"string"}},"required_constraints":{"all_of":[],"any_of":[{"required":["a"],"x-group":2}],"x-wrapper":1},"type":"object"},"type":"client"}""";
        AssertRoundTrip(raw);
        AssertRoundTrip(raw.Replace("\"all_of\":[],\"any_of\":[{\"required\":[\"a\"],\"x-group\":2}],", "\"any_of\":[],"));

        var tool = Tool.FromJson(raw).AsClient()!;
        var parameters = tool.ParametersSchema!.RequireAnyOf("b").RequireAllOf("a", "b");
        tool.RemoveParam("a").RemoveParam("b");
        AssertJson(
            parameters.ToJson()["required_constraints"],
            """{"all_of":[{"required":["a","b"]}],"any_of":[{"required":["a"],"x-group":2},{"required":["b"]}],"x-wrapper":1}"""
        );
    }

    [Test]
    public void KeepsLoadedAllowedValuesFieldsAndOverlaysTheVariable()
    {
        const string raw =
            """{"description":"T","name":"t","parameters":{"properties":{"x":{"allowed_values":{"dynamic_variable":"ids","x-version":1},"description":"X","type":"string"}},"required":["x"],"type":"object"},"type":"client"}""";
        AssertRoundTrip(raw);
        var schema = (LiteralSchema)Tool.FromJson(raw).AsClient()!.ParametersSchema!.PropertySchema("x")!;
        AssertJson(schema.AllowedFrom("other").ToJson()["allowed_values"], """{"dynamic_variable":"other","x-version":1}""");
    }
}
