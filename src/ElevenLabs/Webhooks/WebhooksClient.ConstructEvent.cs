using System.Text.Json.Nodes;
using ElevenLabs.Webhooks;

namespace ElevenLabs;

// Hand-written (listed in .fernignore). Adds ConstructEvent to the generated, partial
// WebhooksClient / IWebhooksClient so it is reachable as client.Webhooks.ConstructEvent, matching
// client.webhooks.construct_event in the Python SDK. The logic lives in WebhookVerifier, which can
// also be called directly without constructing a client.

public partial interface IWebhooksClient
{
    /// <summary>
    /// Verify an ElevenLabs webhook signature and return the decoded event payload. See
    /// <see cref="WebhookVerifier.ConstructEvent(string, string, string)"/>.
    /// </summary>
    /// <param name="rawBody">The raw request body, exactly as received.</param>
    /// <param name="sigHeader">The value of the <c>ElevenLabs-Signature</c> header.</param>
    /// <param name="secret">Your webhook signing secret.</param>
    /// <returns>The decoded webhook event.</returns>
    /// <exception cref="ElevenLabsClientApiException">
    /// With status code 400 if the header or secret is missing, the timestamp is outside the
    /// tolerance window, or the signature does not match.
    /// </exception>
    JsonObject ConstructEvent(string rawBody, string sigHeader, string secret);
}

public partial class WebhooksClient
{
    /// <inheritdoc />
    public JsonObject ConstructEvent(string rawBody, string sigHeader, string secret) =>
        WebhookVerifier.ConstructEvent(rawBody, sigHeader, secret);
}
