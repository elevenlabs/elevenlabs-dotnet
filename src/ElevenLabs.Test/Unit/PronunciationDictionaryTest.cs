using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.PronunciationDictionaries.PronunciationDictionary</c>.
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
public class PronunciationDictionaryTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"rules\":[{\"string_to_replace\":\"string_to_replace\",\"case_sensitive\":true,\"word_boundaries\":true,\"type\":\"alias\",\"alias\":\"alias\"}]}";

        var instance =
            TestJson.Deserialize<global::ElevenLabs.PronunciationDictionaries.PronunciationDictionary>(
                wire
            );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.PronunciationDictionaries.PronunciationDictionary did not round-trip."
        );
    }
}
