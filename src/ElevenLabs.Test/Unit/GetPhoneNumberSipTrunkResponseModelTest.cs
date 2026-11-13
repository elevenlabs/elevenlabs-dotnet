using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.GetPhoneNumberSipTrunkResponseModel</c>.
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
public class GetPhoneNumberSipTrunkResponseModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"phone_number\":\"phone_number\",\"label\":\"label\",\"supports_inbound\":true,\"supports_outbound\":true,\"phone_number_id\":\"phone_number_id\",\"assigned_agent\":{\"agent_id\":\"agent_id\",\"agent_name\":\"agent_name\",\"environment\":\"environment\",\"branch_id\":\"branch_id\"},\"provider\":\"sip_trunk\",\"provider_config\":{\"address\":\"address\",\"transport\":\"auto\",\"media_encryption\":\"disabled\",\"headers\":{\"key\":\"headers\"},\"attributes_to_headers\":{\"key\":\"attributes_to_headers\"},\"has_auth_credentials\":true,\"username\":\"username\",\"has_outbound_trunk\":false,\"enabled_codecs\":[\"G722/8000\"]},\"outbound_trunk\":{\"address\":\"address\",\"transport\":\"auto\",\"media_encryption\":\"disabled\",\"headers\":{\"key\":\"headers\"},\"attributes_to_headers\":{\"key\":\"attributes_to_headers\"},\"has_auth_credentials\":true,\"username\":\"username\",\"has_outbound_trunk\":false,\"enabled_codecs\":[\"G722/8000\"]},\"inbound_trunk\":{\"allowed_addresses\":[\"allowed_addresses\"],\"allowed_numbers\":[\"allowed_numbers\"],\"media_encryption\":\"disabled\",\"has_auth_credentials\":true,\"username\":\"username\",\"remote_domains\":[\"remote_domains\"],\"attributes_to_headers\":{\"key\":\"attributes_to_headers\"}},\"livekit_stack\":\"standard\",\"store_sip_messages\":true}";

        var instance = TestJson.Deserialize<global::ElevenLabs.GetPhoneNumberSipTrunkResponseModel>(
            wire
        );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.GetPhoneNumberSipTrunkResponseModel did not round-trip."
        );
    }
}
