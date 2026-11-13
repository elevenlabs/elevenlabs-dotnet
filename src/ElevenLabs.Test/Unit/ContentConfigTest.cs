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
            "{\"sexual\":{\"is_enabled\":false,\"threshold\":5.42},\"violence\":{\"is_enabled\":false,\"threshold\":5.42},\"harassment\":{\"is_enabled\":false,\"threshold\":5.42},\"self_harm\":{\"is_enabled\":false,\"threshold\":5.42},\"profanity\":{\"is_enabled\":false,\"threshold\":5.42},\"religion_or_politics\":{\"is_enabled\":false,\"threshold\":5.42},\"medical_and_legal_information\":{\"is_enabled\":false,\"threshold\":5.42}}";

        var instance = TestJson.Deserialize<global::ElevenLabs.ContentConfig>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.ContentConfig did not round-trip."
        );
    }
}
