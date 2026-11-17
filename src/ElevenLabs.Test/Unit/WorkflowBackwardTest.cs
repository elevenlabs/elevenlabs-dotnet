using System.Linq;
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
    public void AsDoubleHandlesEveryNumericBacking()
    {
        // Layout reads position coords through AsDouble; a float- or decimal-backed JsonValue must not throw.
        Assert.That(Wire.AsDouble(System.Text.Json.Nodes.JsonValue.Create(1.5f)), Is.EqualTo(1.5).Within(1e-6));
        Assert.That(Wire.AsDouble(System.Text.Json.Nodes.JsonValue.Create(0m)), Is.EqualTo(0.0));
        Assert.That(Wire.AsDouble(System.Text.Json.Nodes.JsonValue.Create(42)), Is.EqualTo(42.0));
        Assert.That(Wire.AsDouble(System.Text.Json.Nodes.JsonValue.Create(3.14)), Is.EqualTo(3.14).Within(1e-9));
    }
}
