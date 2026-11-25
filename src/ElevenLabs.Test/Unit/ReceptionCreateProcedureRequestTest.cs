using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.Reception.Receptionists.ReceptionCreateProcedureRequest</c>.
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
public class ReceptionCreateProcedureRequestTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"name\":\"aute non inci\",\"trigger\":\"ut et\",\"body\":\"1. Ask for the caller's name and order number.\\n2. Look up the order and read back its status.\"}";

        var instance =
            TestJson.Deserialize<global::ElevenLabs.Reception.Receptionists.ReceptionCreateProcedureRequest>(
                wire
            );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.Reception.Receptionists.ReceptionCreateProcedureRequest did not round-trip."
        );
    }
}
