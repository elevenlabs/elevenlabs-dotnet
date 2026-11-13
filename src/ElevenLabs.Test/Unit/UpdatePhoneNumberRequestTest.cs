using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.Agents.UpdatePhoneNumberRequest</c>.
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
public class UpdatePhoneNumberRequestTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"agent_id\":\"agent_id\",\"label\":\"label\",\"inbound_trunk_config\":{\"allowed_addresses\":[\"allowed_addresses\"],\"allowed_numbers\":[\"allowed_numbers\"],\"media_encryption\":\"disabled\",\"credentials\":{\"username\":\"username\",\"password\":\"password\"},\"remote_domains\":[\"remote_domains\"],\"attributes_to_headers\":{\"key\":\"attributes_to_headers\"}},\"outbound_trunk_config\":{\"address\":\"address\",\"transport\":\"auto\",\"media_encryption\":\"disabled\",\"headers\":{\"key\":\"headers\"},\"attributes_to_headers\":{\"key\":\"attributes_to_headers\"},\"credentials\":{\"username\":\"username\",\"password\":\"password\"},\"enabled_codecs\":[\"G722/8000\"]},\"livekit_stack\":\"standard\",\"store_sip_messages\":true,\"environment\":\"environment\",\"branch_id\":\"branch_id\"}";

        var instance = TestJson.Deserialize<global::ElevenLabs.Agents.UpdatePhoneNumberRequest>(
            wire
        );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.Agents.UpdatePhoneNumberRequest did not round-trip."
        );
    }
}
