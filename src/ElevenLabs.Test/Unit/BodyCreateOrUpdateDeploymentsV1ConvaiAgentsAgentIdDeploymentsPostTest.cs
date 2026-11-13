using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.Agents.BodyCreateOrUpdateDeploymentsV1ConvaiAgentsAgentIdDeploymentsPost</c>.
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
public class BodyCreateOrUpdateDeploymentsV1ConvaiAgentsAgentIdDeploymentsPostTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"deployment_request\":{\"requests\":[{\"branch_id\":\"agtbrch_8901k4t9z5defmb8vh3e9361y7nj\",\"deployment_strategy\":{\"type\":\"percentage\",\"traffic_percentage\":0.5}}]}}";

        var instance =
            TestJson.Deserialize<global::ElevenLabs.Agents.BodyCreateOrUpdateDeploymentsV1ConvaiAgentsAgentIdDeploymentsPost>(
                wire
            );
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.Agents.BodyCreateOrUpdateDeploymentsV1ConvaiAgentsAgentIdDeploymentsPost did not round-trip."
        );
    }
}
