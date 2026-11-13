using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.HttpRequestModel</c>.
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
public class HttpRequestModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"http_method\":\"http_method\",\"url\":{\"url_string\":\"url_string\",\"scheme\":\"scheme\",\"hostname\":\"hostname\",\"port\":2,\"path\":\"path\",\"query_string\":\"query_string\"},\"user_agent\":\"user_agent\",\"x_forwarded_for\":[\"x_forwarded_for\"]}";

        var instance = TestJson.Deserialize<global::ElevenLabs.HttpRequestModel>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.HttpRequestModel did not round-trip."
        );
    }
}
