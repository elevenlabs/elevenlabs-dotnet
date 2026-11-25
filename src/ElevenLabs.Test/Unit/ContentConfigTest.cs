using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.ContentConfig</c>.
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
public class ContentConfigTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"sexual\":{\"is_enabled\":true,\"threshold\":6.5},\"violence\":{\"is_enabled\":true,\"threshold\":6.5},\"harassment\":{\"is_enabled\":true,\"threshold\":6.5},\"self_harm\":{\"is_enabled\":true,\"threshold\":6.5},\"profanity\":{\"is_enabled\":true,\"threshold\":6.5},\"religion_or_politics\":{\"is_enabled\":true,\"threshold\":6.5},\"medical_and_legal_information\":{\"is_enabled\":true,\"threshold\":6.5}}";

        var instance = TestJson.Deserialize<global::ElevenLabs.ContentConfig>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ContentConfig did not round-trip."
        );
    }
}
