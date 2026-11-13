using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ProcedureRefResponseModel</c>.
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
public class ProcedureRefResponseModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"procedure_id\":\"procedure_id\",\"version_id\":\"version_id\",\"name\":\"name\",\"type\":\"free_form\",\"trigger\":\"trigger\",\"referenced_tool_ids\":[\"referenced_tool_ids\"],\"referenced_kb_ids\":[\"referenced_kb_ids\"],\"referenced_procedure_ids\":[\"referenced_procedure_ids\"],\"referenced_dynamic_variables\":[\"referenced_dynamic_variables\"],\"folder_parent_id\":\"folder_parent_id\"}";

        var instance = TestJson.Deserialize<global::ElevenLabs.ProcedureRefResponseModel>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ProcedureRefResponseModel did not round-trip."
        );
    }
}
