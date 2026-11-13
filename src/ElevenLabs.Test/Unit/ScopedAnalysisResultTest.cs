using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ScopedAnalysisResult</c>.
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
public class ScopedAnalysisResultTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"scope\":\"conversation\",\"source_agent_id\":\"source_agent_id\",\"source_branch_id\":\"source_branch_id\",\"evaluation_criteria_results\":{\"key\":{\"criteria_id\":\"criteria_id\",\"result\":\"success\",\"rationale\":\"rationale\",\"scoring_mode\":\"binary\",\"score\":2,\"max_score\":2}},\"data_collection_results\":{\"key\":{\"data_collection_id\":\"data_collection_id\",\"name\":\"name\",\"value\":{},\"json_schema\":{\"type\":\"boolean\",\"description\":\"description\",\"enum\":[\"enum\"],\"is_system_provided\":false,\"dynamic_variable\":\"dynamic_variable\",\"allowed_values\":{\"dynamic_variable\":\"dynamic_variable\"},\"allowed_values_dynamic_variable\":\"allowed_values_dynamic_variable\",\"constant_value\":\"magna\",\"is_omitted\":true},\"rationale\":\"rationale\"}},\"successful\":\"success\",\"success_score\":1.68}";

        var instance = TestJson.Deserialize<global::ElevenLabs.ScopedAnalysisResult>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ScopedAnalysisResult did not round-trip."
        );
    }
}
