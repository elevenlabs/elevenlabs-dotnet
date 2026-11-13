using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.EvaluationSettingsOutput</c>.
/// </summary>
/// <remarks>
/// Asserts the wire document the model was built from comes back out of it unchanged — not merely
/// that serialization runs. Starting from JSON rather than from a constructed instance is what
/// makes one emitter cover both output modes: the legacy positional record and the fernMode
/// `required`/`init` record are constructed differently but deserialize from the same document, so
/// nothing here has to know which shape it is looking at. It is also the stronger assertion, since
/// a property whose C# name diverges from its wire name fails this and would pass a test that only
/// compared an instance to itself.
/// </remarks>
[TestFixture]
public class EvaluationSettingsOutputTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"criteria\":[{\"id\":\"id\",\"name\":\"name\",\"type\":\"prompt\",\"conversation_goal_prompt\":\"conversation_goal_prompt\",\"use_knowledge_base\":true,\"scope\":\"conversation\",\"llm\":\"gpt-4o-mini\",\"scoring_mode\":\"binary\",\"max_score\":100,\"score_instructions\":\"score_instructions\"}]}";

        var instance = TestJson.Deserialize<global::ElevenLabs.EvaluationSettingsOutput>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.EvaluationSettingsOutput did not round-trip."
        );
    }
}
