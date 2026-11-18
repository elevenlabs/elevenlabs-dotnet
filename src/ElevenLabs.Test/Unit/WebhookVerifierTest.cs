using System;
using System.Security.Cryptography;
using System.Text;
using ElevenLabs.Webhooks;
using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Coverage for <c>global::ElevenLabs.Webhooks.WebhookVerifier</c>, mirroring the shared cross-SDK
/// suite (see the PHP and Ruby ports).
/// </summary>
[TestFixture]
public class WebhookVerifierTest
{
    // Shared cross-SDK golden vector. The timestamp is far in the future so it stays inside the
    // (past-only) tolerance window forever; every ElevenLabs SDK must accept this exact
    // (secret, header, body) triple.
    private const string Secret = "wsec_0123456789abcdef0123456789abcdef";
    private const string Body =
        "{\"type\":\"post_call_transcription\",\"event_timestamp\":1234567890,\"data\":{\"agent_id\":\"abc123\"}}";
    private const string Header =
        "t=4102444800,v0=01fc9faf23a5c155fbab279c4e0acb2ae059a567b14c10a19bd9f99c88315e99";

    private static string Sign(string timestamp, string body)
    {
        using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(Secret));
        var mac = hmac.ComputeHash(Encoding.UTF8.GetBytes(timestamp + "." + body));
        return "t=" + timestamp + ",v0=" + BitConverter.ToString(mac).Replace("-", "").ToLowerInvariant();
    }

    private static ElevenLabsClientApiException AssertRejected(
        string body,
        string header,
        string secret,
        string message
    )
    {
        var ex = Assert.Throws<ElevenLabsClientApiException>(
            () => WebhookVerifier.ConstructEvent(body, header, secret)
        )!;
        Assert.That(ex.StatusCode, Is.EqualTo(400));
        Assert.That(ex.Message, Does.Contain(message));
        return ex;
    }

    [Test]
    public void GoldenVectorVerifiesAndDecodes()
    {
        var evt = WebhookVerifier.ConstructEvent(Body, Header, Secret);

        Assert.That(evt["type"]!.GetValue<string>(), Is.EqualTo("post_call_transcription"));
        Assert.That(evt["event_timestamp"]!.GetValue<long>(), Is.EqualTo(1234567890L));
        Assert.That(evt["data"]!["agent_id"]!.GetValue<string>(), Is.EqualTo("abc123"));
    }

    [Test]
    public void ClientWebhooksConstructEventDelegatesToVerifier()
    {
        var client = new ElevenLabsClient("test-api-key");

        var evt = client.Webhooks.ConstructEvent(Body, Header, Secret);

        Assert.That(evt["type"]!.GetValue<string>(), Is.EqualTo("post_call_transcription"));
    }

    [Test]
    public void CurrentTimestampVerifies()
    {
        var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
        const string body = "{\"type\":\"ping\"}";

        var evt = WebhookVerifier.ConstructEvent(body, Sign(timestamp, body), Secret);

        Assert.That(evt["type"]!.GetValue<string>(), Is.EqualTo("ping"));
    }

    [Test]
    public void TamperedSignatureIsRejected()
    {
        AssertRejected(
            Body,
            "t=4102444800,v0=" + new string('0', 64),
            Secret,
            "Signature hash does not match"
        );
    }

    [Test]
    public void TamperedBodyIsRejected()
    {
        AssertRejected(Body + " ", Header, Secret, "Signature hash does not match");
    }

    [Test]
    public void WrongSecretIsRejected()
    {
        AssertRejected(Body, Header, Secret + "x", "Signature hash does not match");
    }

    [Test]
    public void OldTimestampIsRejected()
    {
        var timestamp = (DateTimeOffset.UtcNow.ToUnixTimeSeconds() - 31 * 60).ToString();
        const string body = "{\"type\":\"ping\"}";

        AssertRejected(body, Sign(timestamp, body), Secret, "Timestamp outside the tolerance zone");
    }

    [Test]
    public void ToleranceBoundaryIsInclusive()
    {
        var now = DateTimeOffset.FromUnixTimeSeconds(1_700_000_000);
        const string body = "{\"type\":\"ping\"}";

        var atEdge = (now.ToUnixTimeSeconds() - 30 * 60).ToString();
        var evt = WebhookVerifier.ConstructEvent(body, Sign(atEdge, body), Secret, now);
        Assert.That(evt["type"]!.GetValue<string>(), Is.EqualTo("ping"));

        var pastEdge = (now.ToUnixTimeSeconds() - 30 * 60 - 1).ToString();
        var ex = Assert.Throws<ElevenLabsClientApiException>(
            () => WebhookVerifier.ConstructEvent(body, Sign(pastEdge, body), Secret, now)
        )!;
        Assert.That(ex.Message, Does.Contain("Timestamp outside the tolerance zone"));
    }

    [Test]
    public void NonNumericTimestampIsRejected()
    {
        const string body = "{\"type\":\"ping\"}";

        AssertRejected(body, Sign("abc", body), Secret, "Timestamp outside the tolerance zone");
    }

    [Test]
    public void MissingHeaderIsRejected()
    {
        AssertRejected(Body, "", Secret, "Missing signature header");
        AssertRejected(Body, null!, Secret, "Missing signature header");
    }

    [Test]
    public void MissingSecretIsRejected()
    {
        AssertRejected(Body, Header, "", "Webhook secret not configured");
        AssertRejected(Body, Header, null!, "Webhook secret not configured");
    }

    [Test]
    public void HeaderWithoutV0SchemeIsRejected()
    {
        AssertRejected(Body, "t=4102444800", Secret, "No signature hash found with expected scheme v0");
    }

    [Test]
    public void HeaderWithoutTimestampIsRejected()
    {
        AssertRejected(
            Body,
            "v0=01fc9faf23a5c155fbab279c4e0acb2ae059a567b14c10a19bd9f99c88315e99",
            Secret,
            "No signature hash found with expected scheme v0"
        );
    }
}
