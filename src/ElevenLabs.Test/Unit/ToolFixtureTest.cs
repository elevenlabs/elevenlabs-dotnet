using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Nodes;
using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// The shared cross-SDK tool fixtures (copied from elevenlabs-js <c>docs/agents-as-code/fixtures/tools</c> and
/// embedded so they can't drift). Each file is run through the .NET builder; its <c>toJSON()</c> output must match
/// <c>expected</c> byte-for-byte, or <c>build()</c> must raise exactly the listed error codes.
/// </summary>
[TestFixture]
public class ToolFixtureTest
{
    // Byte-identical to JSON.stringify(expected, null, 2) in the reference SDK: 2-space indent, "+"/non-ASCII
    // left unescaped, keys already sorted in the fixture file.
    private static readonly JsonSerializerOptions ExpectedOptions = new()
    {
        WriteIndented = true,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
    };

    private static List<string> ResourceNames() =>
        Assembly
            .GetExecutingAssembly()
            .GetManifestResourceNames()
            .Where(name => name.Contains(".ToolFixtures.") && name.EndsWith(".json"))
            .OrderBy(name => name, System.StringComparer.Ordinal)
            .ToList();

    public static IEnumerable Fixtures()
    {
        var assembly = Assembly.GetExecutingAssembly();
        foreach (var name in ResourceNames())
        {
            using var stream = assembly.GetManifestResourceStream(name)!;
            using var reader = new StreamReader(stream);
            var json = reader.ReadToEnd();
            // Last two dot-separated segments are the file name, e.g. "01-docs-example.json".
            var segments = name.Split('.');
            var shortName = $"{segments[segments.Length - 2]}.{segments[segments.Length - 1]}";
            yield return new TestCaseData(json).SetName($"ToolFixture_{shortName}");
        }
    }

    [Test]
    public void EmbedsEveryFixture()
    {
        Assert.That(ResourceNames(), Has.Count.EqualTo(23));
    }

    [TestCaseSource(nameof(Fixtures))]
    public void MatchesExpected(string fixtureJson)
    {
        var fixture = (JsonObject)JsonNode.Parse(fixtureJson)!;
        var result = ToolFixtureRunner.Run(fixture);

        if (fixture["errors"] is JsonArray expectedErrors)
        {
            var expected = expectedErrors.Select(n => n!.GetValue<string>()).OrderBy(c => c, System.StringComparer.Ordinal).ToList();
            var actual = (result.Errors ?? new List<string>()).OrderBy(c => c, System.StringComparer.Ordinal).ToList();
            Assert.That(actual, Is.EqualTo(expected));
            return;
        }

        Assert.That(result.Errors, Is.Null, "build() reported errors for a fixture expecting output");
        var expectedString = ((JsonObject)fixture["expected"]!).ToJsonString(ExpectedOptions) + "\n";
        Assert.That(result.Json, Is.EqualTo(expectedString));
    }
}
