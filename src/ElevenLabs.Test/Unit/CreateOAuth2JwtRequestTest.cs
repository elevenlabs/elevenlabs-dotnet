using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Round-trip coverage for <c>global::ElevenLabs.CreateOAuth2JwtRequest</c>.
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
public class CreateOAuth2JwtRequestTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"name\":\"name\",\"auth_type\":\"oauth2_jwt\",\"provider\":\"provider\",\"algorithm\":\"HS256\",\"key_id\":\"key_id\",\"issuer\":\"issuer\",\"audience\":\"audience\",\"subject\":\"subject\",\"expiration_seconds\":3600,\"extra_params\":{\"key\":\"extra_params\"},\"extra_headers\":{\"key\":\"extra_headers\"},\"token_url\":\"token_url\",\"scopes\":[\"scopes\"],\"token_response_field\":\"access_token\",\"jwt_usage\":\"authorization_grant\",\"secret_key\":\"secret_key\"}";

        var instance = TestJson.Deserialize<global::ElevenLabs.CreateOAuth2JwtRequest>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::ElevenLabs.CreateOAuth2JwtRequest did not round-trip."
        );
    }
}
