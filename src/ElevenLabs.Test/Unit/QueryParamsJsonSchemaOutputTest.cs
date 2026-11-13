using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.QueryParamsJsonSchemaOutput</c>.
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
public class QueryParamsJsonSchemaOutputTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"properties\":{\"key\":{\"type\":\"boolean\",\"description\":\"description\",\"enum\":[\"enum\"],\"is_system_provided\":false,\"dynamic_variable\":\"dynamic_variable\",\"allowed_values\":{\"dynamic_variable\":\"dynamic_variable\"},\"allowed_values_dynamic_variable\":\"allowed_values_dynamic_variable\",\"constant_value\":\"magna\",\"is_omitted\":true}},\"required\":[\"required\"]}";

        var instance = TestJson.Deserialize<global::ElevenLabs.QueryParamsJsonSchemaOutput>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.QueryParamsJsonSchemaOutput did not round-trip."
        );
    }
}
