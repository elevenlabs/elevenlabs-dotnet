using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.BaseTurnConfig</c>.
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
public class BaseTurnConfigTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"turn_timeout\":7,\"initial_wait_time\":9.71,\"silence_end_call_timeout\":-1,\"turn_eagerness\":\"patient\",\"spelling_patience\":\"auto\",\"speculative_turn\":true,\"retranscribe_on_turn_timeout\":false,\"turn_model\":\"turn_v2\",\"interruption_ignore_terms\":[\"interruption_ignore_terms\"],\"interruption_ignore_term_languages\":[\"interruption_ignore_term_languages\"],\"merge_with_default_ignore_terms\":true,\"transcribe_on_disabled_interruptions\":false}";

        var instance = TestJson.Deserialize<global::ElevenLabs.BaseTurnConfig>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.BaseTurnConfig did not round-trip."
        );
    }
}
