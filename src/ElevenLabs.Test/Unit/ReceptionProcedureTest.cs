using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ReceptionProcedure</c>.
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
public class ReceptionProcedureTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"name\":\"aliqui\",\"trigger\":\"conse\",\"body\":\"1. Ask for the caller's name and order number.\\n2. Look up the order and read back its status.\",\"id\":\"agtprc_4801jx8k3m5n7p9q2r4s6t8v0w2y\",\"created_at_unix\":10,\"source_key\":\"source_key\"}";

        var instance = TestJson.Deserialize<global::ElevenLabs.ReceptionProcedure>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ReceptionProcedure did not round-trip."
        );
    }
}
