using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.RawBusinessInfo</c>.
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
public class RawBusinessInfoTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"company_name\":\"ex dol\",\"description\":\"consequat\",\"business_phone\":\"laboris est\",\"locations\":[{\"name\":\"proide\",\"address\":\"proiden\",\"operating_hours\":{\"key\":{}}}],\"business_country\":\"cupidata\",\"business_state\":\"aliquip qu\",\"suggested_currency\":\"cupidat\",\"suggested_language\":\"inin in\"}";

        var instance = TestJson.Deserialize<global::ElevenLabs.RawBusinessInfo>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.RawBusinessInfo did not round-trip."
        );
    }
}
