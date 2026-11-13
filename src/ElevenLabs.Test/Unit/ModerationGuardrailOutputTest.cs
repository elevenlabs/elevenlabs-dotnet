using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ModerationGuardrailOutput</c>.
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
public class ModerationGuardrailOutputTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"execution_mode\":\"streaming\",\"config\":{\"sexual\":{\"is_enabled\":true,\"threshold\":0.3},\"violence\":{\"is_enabled\":true,\"threshold\":0.3},\"violence_graphic\":{\"is_enabled\":true,\"threshold\":0.3},\"harassment\":{\"is_enabled\":true,\"threshold\":0.3},\"harassment_threatening\":{\"is_enabled\":true,\"threshold\":0.3},\"hate\":{\"is_enabled\":true,\"threshold\":0.3},\"hate_threatening\":{\"is_enabled\":true,\"threshold\":0.3},\"self_harm_instructions\":{\"is_enabled\":true,\"threshold\":0.3},\"self_harm\":{\"is_enabled\":true,\"threshold\":0.3},\"self_harm_intent\":{\"is_enabled\":true,\"threshold\":0.3},\"sexual_minors\":{\"is_enabled\":true,\"threshold\":0.3}}}";

        var instance = TestJson.Deserialize<global::ElevenLabs.ModerationGuardrailOutput>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ModerationGuardrailOutput did not round-trip."
        );
    }
}
