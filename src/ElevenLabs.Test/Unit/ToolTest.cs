using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.Tool</c>.
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
public class ToolTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"name\":\"name\",\"title\":\"title\",\"description\":\"description\",\"inputSchema\":{\"key\":{}},\"execution\":{\"taskSupport\":\"forbidden\"},\"outputSchema\":{\"key\":{}},\"icons\":[{\"src\":\"src\",\"mimeType\":\"mimeType\",\"sizes\":[\"sizes\"],\"theme\":\"light\"}],\"annotations\":{\"title\":\"title\",\"readOnlyHint\":true,\"destructiveHint\":false,\"idempotentHint\":true,\"openWorldHint\":false},\"_meta\":{\"key\":{}}}";

        var instance = TestJson.Deserialize<global::ElevenLabs.Tool>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(wire, serialized, "global::ElevenLabs.Tool did not round-trip.");
    }
}
