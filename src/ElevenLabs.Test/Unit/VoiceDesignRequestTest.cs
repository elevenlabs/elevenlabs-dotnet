using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.VoiceDesignRequest</c>.
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
public class VoiceDesignRequestTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"voice_description\":\"A sassy squeaky mouse\",\"text\":\"proident ipsum magna DuisExcepteur dolore quis laboris elitvoluptate esseanimin ex nisielit laborum qui veniam\",\"auto_generate_text\":false,\"loudness\":0.5,\"quality\":0.9,\"seed\":1481804905,\"guidance_scale\":5,\"should_enhance\":true}";

        var instance = TestJson.Deserialize<global::ElevenLabs.VoiceDesignRequest>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.VoiceDesignRequest did not round-trip."
        );
    }
}
