using System.Linq;
using ElevenLabs;
using ElevenLabs.AgentWorkflows;
using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Hand-written coverage for the public builder surface beyond the shared fixtures: chaining with
/// <c>Up()</c>, <c>Build()</c> returning the generated request model, loading from a model, and the string sugar.
/// </summary>
[TestFixture]
public class WorkflowBuilderTest
{
    [Test]
    public void BuildReturnsGeneratedRequestModel()
    {
        var wf = new Workflow();
        wf.Converse("support_agent", "Help the user").When("Resolved").End();

        var model = wf.Build();

        Assert.That(model.Nodes, Is.Not.Null);
        Assert.That(model.Nodes!.Keys, Does.Contain("support_agent"));
        Assert.That(model.Nodes.Keys, Does.Contain("end"));
        Assert.That(model.Edges, Is.Not.Null);
        Assert.That(model.Edges!.Keys, Does.Contain("start_node__support_agent"));
    }

    [Test]
    public void ChainsWithUp()
    {
        var wf = new Workflow();
        wf.Converse("triage", "Find out what the caller needs")
            .When("Caller wants a human")
            .Transfer("human", Destination.Phone("+15551234567"))
            .Up()
            .When("Caller is done")
            .End();

        Assert.That(wf.NodeIds, Is.EquivalentTo(new[] { "start_node", "triage", "human", "end" }));
        var json = wf.ToJsonString();
        Assert.That(json, Does.Contain("triage__human"));
        Assert.That(json, Does.Contain("triage__end"));
        // The phone number must survive serialization unescaped.
        Assert.That(json, Does.Contain("+15551234567"));
    }

    [Test]
    public void StringAndExprConditionsAreSugar()
    {
        var wf = new Workflow();
        var triage = wf.Converse("triage", "Triage");
        triage.When("plain string").End();
        triage.When(Expr.Variable("tier").Eq("gold")).End(new EndOptions { Id = "vip_end" });

        var json = wf.ToJsonString();
        Assert.That(json, Does.Contain("\"type\": \"llm\""));
        Assert.That(json, Does.Contain("\"type\": \"expression\""));
        Assert.That(json, Does.Contain("dynamic_variable"));
    }

    [Test]
    public void RoundTripsThroughFromJson()
    {
        var wf = new Workflow();
        wf.Converse("a", "A").When("done").End();
        var once = wf.ToJsonString();

        var reloaded = Workflow.FromJson(once);
        Assert.That(reloaded.ToJsonString(), Is.EqualTo(once));
    }

    [Test]
    public void ChainingNeverThrowsErrorsSurfaceAtBuild()
    {
        var wf = new Workflow();
        wf.Converse("a", "A");
        wf.Node("does_not_exist").Update(new NodeUpdate { Label = "x" });

        var ex = Assert.Throws<WorkflowValidationException>(() => wf.ToJsonString());
        Assert.That(ex!.Issues.Select(i => i.Code), Does.Contain("unknown_node"));
    }
}
