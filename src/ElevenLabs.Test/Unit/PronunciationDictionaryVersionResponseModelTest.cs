using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.PronunciationDictionaryVersionResponseModel</c>.
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
public class PronunciationDictionaryVersionResponseModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"version_id\":\"version_id\",\"version_rules_num\":3,\"pronunciation_dictionary_id\":\"pronunciation_dictionary_id\",\"dictionary_name\":\"dictionary_name\",\"version_name\":\"version_name\",\"permission_on_resource\":\"admin\",\"created_by\":\"created_by\",\"creation_time_unix\":2,\"archived_time_unix\":4}";

        var instance =
            TestJson.Deserialize<global::ElevenLabs.PronunciationDictionaryVersionResponseModel>(
                wire
            );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.PronunciationDictionaryVersionResponseModel did not round-trip."
        );
    }
}
