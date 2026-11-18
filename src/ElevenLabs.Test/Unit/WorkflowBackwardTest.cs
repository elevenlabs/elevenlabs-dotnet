using System.Linq;
using System.Text.Json.Nodes;
using ElevenLabs.AgentWorkflows;
using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Backward-condition validation (a second transition target → source stored on the same edge), and the
/// node-type probe that reads the generated union's discriminants.
/// </summary>
[TestFixture]
public class WorkflowBackwardTest
{
    private static string[] BuildErrorCodes(Workflow wf)
    {
        try
        {
            wf.Build();
            Assert.Fail("expected Build to throw");
            return System.Array.Empty<string>();
        }
        catch (WorkflowValidationException e)
        {
            return e.Issues.Select(i => i.Code).ToArray();
        }
    }

    [Test]
    public void BackwardConditionIntoStartIsRejected()
    {
        var wf = new Workflow();
        // start --"Begin"--> greet, with a backward greet --"Restart"--> start.
        wf.When("Begin", Condition.Llm("Restart")).Converse("greet", "Hello");
        Assert.That(BuildErrorCodes(wf), Does.Contain("edge_into_start"));
    }

    [Test]
    public void BackwardConditionOutOfEndIsRejected()
    {
        var wf = new Workflow();
        // triage --"Done"--> end, with a backward end --"Resume"--> triage.
        wf.Converse("triage", "Triage").When("Done", Condition.Llm("Resume")).End();
        Assert.That(BuildErrorCodes(wf), Does.Contain("end_has_outgoing_edges"));
    }

    [Test]
    public void BackwardLoopBetweenConverseNodesIsAllowed()
    {
        var wf = new Workflow();
        wf.Converse("a", "A").When("To B", Condition.Llm("Back to A")).Converse("b", "B").End();
        Assert.DoesNotThrow(() => wf.Build());
    }

    [Test]
    public void ModelKnowsKnownNodeTypesThatRequireFields()
    {
        // These are real union members whose models require fields; the probe must still report them known.
        Assert.That(NodeTypes.ModelKnows("override_agent"), Is.True);
        Assert.That(NodeTypes.ModelKnows("phone_number"), Is.True);
        Assert.That(NodeTypes.ModelKnows("tool"), Is.True);
    }

    [Test]
    public void ModelDoesNotKnowUnknownNodeType()
    {
        Assert.That(NodeTypes.ModelKnows("not_a_real_node_type"), Is.False);
        Assert.That(NodeTypes.ModelKnows(null), Is.False);
    }

    [Test]
    public void InsertBetweenBidirectionalEdgeIsRejected()
    {
        var wf = new Workflow();
        wf.Converse("a", "A").When("to b", Condition.Llm("back to a")).Converse("b", "B"); // a <-> b
        var result = wf.InsertBetween("a", "b", br => br.Converse("mid", "M"));
        Assert.That(result, Is.Null, "inserting into a bidirectional edge must be rejected");
        Assert.That(BuildErrorCodes(wf), Does.Contain("cannot_insert_bidirectional"));
    }

    [Test]
    public void PositionAcceptedForUnmappedNodeTypes()
    {
        // `say`/`update_state` are valid generated node types with no dedicated option map; `position`
        // is shared by every node kind, so updating it must not record invalid_option.
        var wire = new JsonObject
        {
            ["nodes"] = new JsonObject
            {
                ["start_node"] = new JsonObject { ["type"] = "start" },
                ["announce"] = new JsonObject { ["type"] = "say", ["text"] = "hello" },
            },
            ["edges"] = new JsonObject
            {
                ["start_node__announce"] = new JsonObject
                {
                    ["source"] = "start_node",
                    ["target"] = "announce",
                    ["forward_condition"] = Condition.Llm("go").ToWire(),
                },
            },
        };
        var wf = Workflow.FromJson(wire);
        wf.Node("announce").Update(new NodeUpdate { Position = new JsonObject { ["x"] = 10, ["y"] = 20 } });
        // ToJson validates (it would throw invalid_option before the fix) without deserializing the
        // say node into its typed model, which isolates the position-acceptance behaviour.
        Assert.DoesNotThrow(() => wf.ToJson());
    }

    [Test]
    public void LoadedBackwardOnlyEdgeHasNoForwardTransition()
    {
        // An edge stored as x → start_node carrying ONLY a backward condition is the reverse transition
        // start_node → x; there is no forward x → start_node, so x's outgoing edge_order must not list it.
        var wire = new JsonObject
        {
            ["nodes"] = new JsonObject
            {
                ["start_node"] = new JsonObject { ["type"] = "start" },
                ["hub"] = new JsonObject
                {
                    ["type"] = "override_agent",
                    ["label"] = "hub",
                    ["additional_prompt"] = "H",
                },
                ["x"] = new JsonObject
                {
                    ["type"] = "override_agent",
                    ["label"] = "x",
                    ["additional_prompt"] = "X",
                },
                ["end"] = new JsonObject { ["type"] = "end" },
            },
            ["edges"] = new JsonObject
            {
                ["e1"] = new JsonObject
                {
                    ["source"] = "start_node",
                    ["target"] = "hub",
                    ["forward_condition"] = Condition.Llm("go").ToWire(),
                },
                ["e2"] = new JsonObject
                {
                    ["source"] = "hub",
                    ["target"] = "x",
                    ["forward_condition"] = Condition.Llm("go").ToWire(),
                },
                ["e3"] = new JsonObject
                {
                    ["source"] = "hub",
                    ["target"] = "end",
                    ["forward_condition"] = Condition.Llm("go").ToWire(),
                },
                ["e4"] = new JsonObject
                {
                    ["source"] = "x",
                    ["target"] = "start_node",
                    ["backward_condition"] = Condition.Llm("restart").ToWire(),
                },
            },
        };
        var outJson = Workflow.FromJson(wire).ToJson();
        var xOrder = (JsonArray)outJson["nodes"]!["x"]!["edge_order"]!;
        Assert.That(
            xOrder.Select(n => (string)n!),
            Does.Not.Contain("e4"),
            "x has no forward transition via e4, so it must not be in x's edge_order"
        );
    }

    [Test]
    public void AsDoubleHandlesEveryNumericBacking()
    {
        // Layout reads position coords through AsDouble; a float- or decimal-backed JsonValue must not throw.
        Assert.That(Wire.AsDouble(System.Text.Json.Nodes.JsonValue.Create(1.5f)), Is.EqualTo(1.5).Within(1e-6));
        Assert.That(Wire.AsDouble(System.Text.Json.Nodes.JsonValue.Create(0m)), Is.EqualTo(0.0));
        Assert.That(Wire.AsDouble(System.Text.Json.Nodes.JsonValue.Create(42)), Is.EqualTo(42.0));
        Assert.That(Wire.AsDouble(System.Text.Json.Nodes.JsonValue.Create(3.14)), Is.EqualTo(3.14).Within(1e-9));
    }
}
