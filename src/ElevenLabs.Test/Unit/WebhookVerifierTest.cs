using System;
using System.Security.Cryptography;
using System.Text;
using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Coverage for <c>global::ElevenLabs.WebhookVerifier</c>, mirroring the shared cross-SDK suite.
/// </summary>
[TestFixture]
public class WebhookVerifierTest
{
    /// <summary>
    /// Shared cross-SDK golden vector. The timestamp is far in the future so it stays inside the
    /// (past-only) tolerance window forever; every ElevenLabs SDK must accept this exact
    /// (secret, header, body) triple.
    /// </summary>
    private const string Secret = "wsec_0123456789abcdef0123456789abcdef";

    private const string Body =
        "{\"type\":\"post_call_transcription\",\"event_timestamp\":1234567890,\"data\":{\"agent_id\":\"abc123\"}}";

    private const string Header =
        "t=4102444800,v0=01fc9faf23a5c155fbab279c4e0acb2ae059a567b14c10a19bd9f99c88315e99";

    [Test]
    public void GoldenVectorVerifiesAndDecodes()
    {
        var @event = WebhookVerifier.ConstructEvent(Body, Header, Secret);

        Assert.That(@event["type"]!.GetValue<string>(), Is.EqualTo("post_call_transcription"));
        Assert.That(@event["event_timestamp"]!.GetValue<long>(), Is.EqualTo(1234567890L));
        Assert.That(@event["data"]!["agent_id"]!.GetValue<string>(), Is.EqualTo("abc123"));
    }

    [Test]
    public void CurrentTimestampVerifies()
    {
        var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
        const string body = "{\"type\":\"ping\"}";
        var header = "t=" + timestamp + ",v0=" + HmacSha256Hex(Secret, timestamp + "." + body);

        var @event = WebhookVerifier.ConstructEvent(body, header, Secret);
        Assert.That(@event["type"]!.GetValue<string>(), Is.EqualTo("ping"));
    }

    [Test]
    public void TamperedSignatureIsRejected()
    {
        var header = "t=4102444800,v0=" + new string('0', 64);

        var ex = Assert.Throws<ElevenLabsClientApiException>(
            () => WebhookVerifier.ConstructEvent(Body, header, Secret)
        );
        Assert.That(ex!.Message, Does.Contain("Signature hash does not match"));
    }

    [Test]
    public void TamperedBodyIsRejected()
    {
        Assert.Throws<ElevenLabsClientApiException>(
            () => WebhookVerifier.ConstructEvent(Body + " ", Header, Secret)
        );
    }

    [Test]
    public void OldTimestampIsRejected()
    {
        var timestamp = (DateTimeOffset.UtcNow.ToUnixTimeSeconds() - 31 * 60).ToString();
        const string body = "{\"type\":\"ping\"}";
        var header = "t=" + timestamp + ",v0=" + HmacSha256Hex(Secret, timestamp + "." + body);

        var ex = Assert.Throws<ElevenLabsClientApiException>(
            () => WebhookVerifier.ConstructEvent(body, header, Secret)
        );
        Assert.That(ex!.Message, Does.Contain("Timestamp outside the tolerance zone"));
    }

    [Test]
    public void MissingHeaderIsRejected()
    {
        var ex = Assert.Throws<ElevenLabsClientApiException>(
            () => WebhookVerifier.ConstructEvent(Body, "", Secret)
        );
        Assert.That(ex!.Message, Does.Contain("Missing signature header"));
    }

    [Test]
    public void MissingSecretIsRejected()
    {
        var ex = Assert.Throws<ElevenLabsClientApiException>(
            () => WebhookVerifier.ConstructEvent(Body, Header, "")
        );
        Assert.That(ex!.Message, Does.Contain("Webhook secret not configured"));
    }

    [Test]
    public void HeaderWithoutV0SchemeIsRejected()
    {
        var ex = Assert.Throws<ElevenLabsClientApiException>(
            () => WebhookVerifier.ConstructEvent(Body, "t=4102444800", Secret)
        );
        Assert.That(ex!.Message, Does.Contain("No signature hash found with expected scheme v0"));
    }

    private static string HmacSha256Hex(string secret, string message)
    {
        using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secret));
        var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
        var builder = new StringBuilder(hash.Length * 2);
        foreach (var b in hash)
        {
            builder.Append(b.ToString("x2"));
        }
        return builder.ToString();
    }
}
