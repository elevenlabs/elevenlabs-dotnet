using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.FeaturesUsageCommonModel</c>.
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
public class FeaturesUsageCommonModelTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"language_detection\":{\"enabled\":false,\"used\":false},\"transfer_to_agent\":{\"enabled\":false,\"used\":false},\"transfer_to_number\":{\"enabled\":false,\"used\":false},\"multivoice\":{\"enabled\":false,\"used\":false},\"dtmf_tones\":{\"enabled\":false,\"used\":false},\"external_mcp_servers\":{\"enabled\":false,\"used\":false},\"pii_zrm_workspace\":true,\"pii_zrm_agent\":false,\"tool_dynamic_variable_updates\":{\"enabled\":false,\"used\":false},\"is_livekit\":false,\"voicemail_detection\":{\"enabled\":false,\"used\":false},\"dtmf_input\":{\"enabled\":false,\"used\":false},\"workflow\":{\"enabled\":true,\"tool_node\":{\"enabled\":false,\"used\":false},\"standalone_agent_node\":{\"enabled\":false,\"used\":false},\"phone_number_node\":{\"enabled\":false,\"used\":false},\"end_node\":{\"enabled\":false,\"used\":false},\"override_agent_node\":{\"enabled\":false,\"used\":false}},\"agent_testing\":{\"enabled\":true,\"tests_ran_after_last_modification\":true,\"tests_ran_in_last_7_days\":false},\"versioning\":{\"enabled\":false,\"used\":false},\"file_input\":{\"enabled\":false,\"used\":false},\"freeform_procedure\":{\"enabled\":false,\"used\":false},\"structured_procedure\":{\"enabled\":false,\"used\":false}}";

        var instance = TestJson.Deserialize<global::ElevenLabs.FeaturesUsageCommonModel>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.FeaturesUsageCommonModel did not round-trip."
        );
    }
}
