using System.Text.Json.Nodes;
using ElevenLabs.AgentBuilder;
using NUnit.Framework;

namespace ElevenLabs.Tests;

// Inside the namespace, so these win over the generated ElevenLabs.Tool model.
using ElevenLabs.AgentTools;
using Tool = ElevenLabs.AgentTools.Tool;

/// <summary>
/// <see cref="AgentProject"/> in the CLI's layout, including the shared <c>cli-graph</c> fixture checks. Ported from
/// elevenlabs-js <c>tests/custom/agents/project/project.test.ts</c>.
/// </summary>
[TestFixture]
public class AgentProjectTest
{
    [Test]
    public void LoadsACliProjectWithToolsByIdAgentsWithToolObjectsAndUnknownIdsKept()
    {
        // Fixture check: the same agents, tools, ids and attached ids.
        var project = AgentProject.FromFiles(CliProjectFixture.Files());
        Assert.That(project.Agents.Select(a => a.Name), Is.EqualTo(new[] { "Support", "Billing" }));
        Assert.That(project.Tools.Select(t => t.Name), Is.EqualTo(new[] { "lookup_order", "issue_refund" }));

        var support = project.GetAgent("Support");
        Assert.That(support.Tools().Select(t => t.Name), Is.EqualTo(new[] { "lookup_order" }));
        Assert.That(support.ToolIds, Is.EqualTo(new[] { "tool_from_dashboard" }));
        Assert.That(project.GetAgentId(support), Is.EqualTo("agent_support"));
        Assert.That(project.GetToolId(support.Tools()[0]), Is.EqualTo("tool_lookup"));

        var billing = project.GetAgent("Billing");
        Assert.That(billing.Tools().Select(t => t.Name), Is.EqualTo(new[] { "issue_refund" }));
        Assert.That(billing.ToolIds, Is.Empty);
        Assert.That(project.GetAgentId(billing), Is.EqualTo("agent_billing"));
        Assert.That(project.GetToolId(project.Tools[1]), Is.EqualTo("tool_refund"));
    }

    [Test]
    public void GivesBackEveryFileUnchangedWhenNothingWasPushedOrPulled()
    {
        // Fixture check: every file byte-identical, branch configs included.
        var files = CliProjectFixture.Files();
        var project = AgentProject.FromFiles(files);
        Assert.That(project.ToFiles(), Is.EquivalentTo(files));
        Assert.That(project.ChangedFiles, Is.Empty);
    }

    [Test]
    public void OpensTheFixtureFromDiskAndGivesBackTheSameFiles()
    {
        var files = CliProjectFixture.Files();
        var dir = CliProjectFixture.WriteTree(files);
        var project = AgentProject.Open(dir);
        Assert.That(project.ToFiles(), Is.EquivalentTo(files));
        Assert.That(project.Save(), Is.Empty);
        Assert.That(CliProjectFixture.ReadTree(dir), Is.EquivalentTo(files));
    }

    [Test]
    public void ReportsMissingMalformedAndNotYetSupportedFilesClearly()
    {
        static Dictionary<string, string> Index(string config) =>
            new() { ["agents.json"] = new JsonObject { ["agents"] = new JsonArray(new JsonObject { ["config"] = config }) }.ToJsonString() };

        Assert.That(
            () => AgentProject.FromFiles(Index("agent_configs/a.yaml")),
            Throws.TypeOf<AgentProjectException>().With.Message.Contains("only JSON config files are supported yet")
        );
        Assert.That(
            () => AgentProject.FromFiles(Index("agent_configs/a.toml")),
            Throws.TypeOf<AgentProjectException>().With.Message.Contains("YAML and TOML")
        );
        Assert.That(
            () => AgentProject.FromFiles(Index("agent_configs/a.json")),
            Throws.TypeOf<AgentProjectException>().With.Message.Contains("points at agent_configs/a.json, which doesn't exist")
        );
        Assert.That(
            () => AgentProject.FromFiles(new Dictionary<string, string> { ["agents.json"] = "{" }),
            Throws.TypeOf<AgentProjectException>()
        );
        Assert.That(
            () => AgentProject.FromFiles(new Dictionary<string, string>()).GetAgent("Nope"),
            Throws.TypeOf<AgentProjectException>().With.Message.Contains("No agent named \"Nope\"")
        );
    }

    [Test]
    public void NamesNewFilesLikeTheCli()
    {
        Assert.That(ProjectFormat.SanitizeFilename("  Support line / EU "), Is.EqualTo("Support-line-EU"));
        Assert.That(ProjectFormat.SanitizeFilename(".hidden"), Is.EqualTo("_hidden"));
        Assert.That(ProjectFormat.SanitizeFilename("..."), Is.EqualTo("unnamed"));
        Assert.That(ProjectFormat.SanitizeFilename("   "), Is.EqualTo("unnamed"));
        Assert.That(ProjectFormat.SanitizeFilename("a:b*c?d\"e<f>g|h\\i"), Is.EqualTo("a-b-c-d-e-f-g-h-i"));
        Assert.That(ProjectFormat.SanitizeFilename(new string('x', 120)), Has.Length.EqualTo(100));
        Assert.That(ProjectFormat.SanitizeFilename(string.Concat(Enumerable.Repeat("😀", 101))), Is.EqualTo(string.Concat(Enumerable.Repeat("😀", 100))));
        Assert.That(
            ProjectFormat.UniquePath("agent_configs", "A", new HashSet<string> { "agent_configs/A.json", "agent_configs/A-1.json" }),
            Is.EqualTo("agent_configs/A-2.json")
        );
    }

    [Test]
    public void FormatsFilesLikeTheCli()
    {
        var value = JsonNode.Parse("""{"b":[1,{"y":1e-7,"x":"+1 555/ü"}],"a":{},"c":[]}""");
        Assert.That(
            ProjectFormat.FormatIndex(value),
            Is.EqualTo("{\n    \"b\": [\n        1,\n        {\n            \"y\": 1e-7,\n            \"x\": \"+1 555/ü\"\n        }\n    ],\n    \"a\": {},\n    \"c\": []\n}")
        );
        Assert.That(
            ProjectFormat.FormatConfig(value),
            Is.EqualTo("{\n    \"a\": {},\n    \"b\": [\n        1,\n        {\n            \"x\": \"+1 555/ü\",\n            \"y\": 1e-7\n        }\n    ],\n    \"c\": []\n}")
        );
    }

    [Test]
    public async Task OpensAnEmptyDirectoryAndPushWritesTheCliLayoutOwnerOnly()
    {
        var dir = CliProjectFixture.TempDir();
        Directory.CreateDirectory(Path.Combine(dir, "agent_configs"));
        File.WriteAllText(Path.Combine(dir, "agent_configs", "A.json"), "not ours"); // a file the project doesn't list
        var project = AgentProject.Open(dir);
        var server = new FakeAgentServer();
        var agent = new Agent("A", new AgentOptions { Prompt = "p", Tools = new Tool[] { Tool.Client("ping", "Ping the app") } });

        await server.Client().Agents.PushAsync(agent, new AgentPushOptions { Project = project });

        var files = CliProjectFixture.ReadTree(dir);
        Assert.That(
            files.Keys.OrderBy(k => k, StringComparer.Ordinal),
            Is.EqualTo(new[] { "agent_configs/A-1.json", "agent_configs/A.json", "agents.json", "tool_configs/ping.json", "tools.json" })
        );
        Assert.That(files["agent_configs/A.json"], Is.EqualTo("not ours"));
        Assert.That(
            files["tool_configs/ping.json"],
            Is.EqualTo("{\n    \"description\": \"Ping the app\",\n    \"name\": \"ping\",\n    \"type\": \"client\"\n}")
        );
        if (!OperatingSystem.IsWindows())
        {
            foreach (var path in new[] { "agents.json", "tools.json", "agent_configs/A-1.json", "tool_configs/ping.json" })
            {
                Assert.That(File.GetUnixFileMode(Path.Combine(dir, path)), Is.EqualTo(UnixFileMode.UserRead | UnixFileMode.UserWrite), path);
            }
        }

        var reopened = AgentProject.Open(dir);
        Assert.That(reopened.GetAgentId(reopened.GetAgent("A")), Is.EqualTo(project.GetAgentId(agent)));
    }

    [Test]
    public void RefusesConfigPathsOutsideTheProjectDirectlyOrThroughASymlink()
    {
        var outside = CliProjectFixture.TempDir();
        File.WriteAllText(Path.Combine(outside, "a.json"), "{}");

        var escaping = CliProjectFixture.TempDir();
        File.WriteAllText(Path.Combine(escaping, "agents.json"), """{"agents":[{"config":"../a.json"}]}""");
        Assert.That(() => AgentProject.Open(escaping), Throws.TypeOf<AgentProjectException>().With.Message.Contains("outside the project"));

        var linked = CliProjectFixture.TempDir();
        Directory.CreateSymbolicLink(Path.Combine(linked, "agent_configs"), outside);
        File.WriteAllText(Path.Combine(linked, "agents.json"), """{"agents":[{"config":"agent_configs/a.json"}]}""");
        Assert.That(() => AgentProject.Open(linked), Throws.TypeOf<AgentProjectException>().With.Message.Contains("through a symlink"));
    }

    [Test]
    public void AllowsASymlinkThatStaysInsideTheProject()
    {
        var dir = CliProjectFixture.TempDir();
        Directory.CreateDirectory(Path.Combine(dir, "real"));
        File.WriteAllText(Path.Combine(dir, "real", "a.json"), """{"name":"A","conversation_config":{},"platform_settings":{},"tags":[]}""");
        Directory.CreateSymbolicLink(Path.Combine(dir, "agent_configs"), Path.Combine(dir, "real"));
        File.WriteAllText(Path.Combine(dir, "agents.json"), """{"agents":[{"config":"agent_configs/a.json"}]}""");
        Assert.That(AgentProject.Open(dir).GetAgent("A").Name, Is.EqualTo("A"));
    }

    [Test]
    public void RefusesToWriteThroughASymlinkedFile()
    {
        var outside = CliProjectFixture.TempDir();
        var target = Path.Combine(outside, "victim.json");
        File.WriteAllText(target, "untouched");
        var dir = CliProjectFixture.TempDir();
        File.CreateSymbolicLink(Path.Combine(dir, "agents.json"), target);
        Assert.That(() => ProjectFiles.WriteProjectFiles(dir, new[] { new KeyValuePair<string, string>("agents.json", "{}") }), Throws.TypeOf<AgentProjectException>());
        Assert.That(File.ReadAllText(target), Is.EqualTo("untouched"));
    }

    [Test]
    public void SaveNeedsADirectory()
    {
        Assert.That(() => AgentProject.FromFiles(new Dictionary<string, string>()).Save(), Throws.TypeOf<AgentProjectException>());
    }

    [Test]
    public async Task RejectsABranchTheProjectHasNoFileForBeforeAnyRequest()
    {
        var project = AgentProject.FromFiles(CliProjectFixture.Files());
        var server = new FakeAgentServer();
        var client = server.Client();
        var push = () => client.Agents.PushAsync(project.GetAgent("Billing"), new AgentPushOptions { Project = project, BranchId = "agtbrch_x" });
        Assert.That(async () => await push(), Throws.TypeOf<AgentProjectException>().With.Message.Contains("has no config file"));
        var pull = () => client.Agents.PullAsync("agent_support", new AgentPullOptions { Project = project, BranchId = "agtbrch_x" });
        Assert.That(async () => await pull(), Throws.TypeOf<AgentProjectException>().With.Message.Contains("has no config file"));
        Assert.That(server.Calls, Is.Empty);
        await Task.CompletedTask;
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase(1)]
    public void RejectsABranchEntryWithoutAConfigFileBeforeAnyWrite(object? config)
    {
        // A branch entry with no usable config path would otherwise be written into the main branch's file.
        var files = CliProjectFixture.Files();
        var index = JsonNode.Parse(files["agents.json"])!.AsObject();
        var beta = index["agents"]![0]!["branches"]!["beta"]!.AsObject();
        beta.Remove("config");
        if (config != null)
        {
            beta["config"] = JsonValue.Create(config);
        }
        files["agents.json"] = index.ToJsonString();
        var mainBefore = files["agent_configs/support.json"];
        var project = AgentProject.FromFiles(files);
        var server = new FakeAgentServer();
        server.AddAgent("agent_support", CliProjectFixture.Json("agent_configs/support.json"));
        var client = server.Client();

        var push = () =>
            client.Agents.PushAsync(project.GetAgent("Support"), new AgentPushOptions { Project = project, BranchId = "agtbrch_beta" });
        Assert.That(async () => await push(), Throws.TypeOf<AgentProjectException>().With.Message.Contains("has no config file"));
        var pull = () => client.Agents.PullAsync("agent_support", new AgentPullOptions { Project = project, BranchId = "agtbrch_beta" });
        Assert.That(async () => await pull(), Throws.TypeOf<AgentProjectException>().With.Message.Contains("has no config file"));
        // Recording directly can't reach the main file either.
        var agent = Agent.FromJson(CliProjectFixture.Json("agent_configs/support.json"));
        Assert.That(
            () => project.RecordAgent(agent, "agent_support", agent.ToJson(), branchId: "agtbrch_beta", matchById: true),
            Throws.TypeOf<AgentProjectException>().With.Message.Contains("has no config file")
        );

        Assert.That(server.Calls, Is.Empty);
        Assert.That(project.ChangedFiles, Is.Empty);
        Assert.That(project.ToFiles()["agent_configs/support.json"], Is.EqualTo(mainBefore));
    }

    [Test]
    public void KeepsTheMainAgentWhenABranchIsRecordedAndTheToolTypeInStepWithItsConfig()
    {
        var project = AgentProject.FromFiles(CliProjectFixture.Files());
        var main = project.GetAgent("Support");
        var beta = Agent.FromJson(CliProjectFixture.Json("agent_configs/support.beta.json"));
        project.RecordAgent(beta, "agent_support", beta.ToJson(), branchId: "agtbrch_beta", matchById: true);
        Assert.That(project.GetAgent("Support"), Is.SameAs(main));
        Assert.That(project.ChangedFiles, Does.Contain("agent_configs/support.beta.json"));
        Assert.That(project.ChangedFiles, Does.Not.Contain("agent_configs/support.json"));

        var lookup = project.Tools[0];
        var client = Tool.Client("lookup_order", "Now a client tool");
        project.RecordTool(client, project.GetToolId(lookup)!, client.ToJson(), matchById: true);
        Assert.That(JsonNode.Parse(project.ToFiles()["tools.json"])!["tools"]![0]!["type"]!.GetValue<string>(), Is.EqualTo("client"));
    }

    [Test]
    public void DropsAPendingWriteOnceAFileIsBackToWhatWasLoaded()
    {
        var loaded = JsonNode.Parse("""{"name":"A","conversation_config":{},"platform_settings":{},"tags":[]}""")!.AsObject();
        var files = new Dictionary<string, string>
        {
            ["agents.json"] = ProjectFormat.FormatIndex(JsonNode.Parse("""{"agents":[{"config":"agent_configs/a.json","id":"agent_1"}]}""")),
            ["agent_configs/a.json"] = ProjectFormat.FormatConfig(loaded),
        };
        var project = AgentProject.FromFiles(files);
        var agent = project.GetAgent("A");
        var changed = (JsonObject)loaded.DeepClone();
        changed["tags"] = new JsonArray("x");
        project.RecordAgent(agent, "agent_1", changed);
        Assert.That(project.ChangedFiles, Is.EqualTo(new[] { "agent_configs/a.json" }));
        project.RecordAgent(agent, "agent_1", loaded);
        Assert.That(project.ChangedFiles, Is.Empty);
        var expected = new Dictionary<string, string>(files) { ["tools.json"] = "{\n    \"tools\": []\n}" };
        Assert.That(project.ToFiles(), Is.EquivalentTo(expected));
    }
}
