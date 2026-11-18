using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace ElevenLabs.Webhooks;

/// <summary>
/// Verifies ElevenLabs webhook signatures.
/// </summary>
/// <remarks>
/// <para>
/// ElevenLabs signs each webhook with an HMAC-SHA256 digest, sent in the
/// <c>ElevenLabs-Signature</c> header as a compound value of the form
/// <c>t=&lt;unix_timestamp&gt;,v0=&lt;hex_digest&gt;</c>. The signed message is the timestamp and
/// the raw request body joined with a period (<c>&lt;timestamp&gt;.&lt;raw_body&gt;</c>).
/// </para>
/// <para>
/// This is a hand-written helper rather than generated code (listed in <c>.fernignore</c>): the
/// Fern generator's built-in verifier cannot parse a compound header that carries both the
/// timestamp and the signature. It mirrors <c>construct_event</c> in the Python SDK so every SDK
/// accepts the same signatures. It is also exposed as <c>client.Webhooks.ConstructEvent</c>.
/// </para>
/// </remarks>
public static class WebhookVerifier
{
    /// <summary>
    /// How far in the past, in seconds, a webhook timestamp may be before it is rejected as a
    /// possible replay.
    /// </summary>
    private const long ToleranceSeconds = 30 * 60;

    /// <summary>
    /// Verify a webhook signature and return the decoded event payload.
    /// </summary>
    /// <param name="rawBody">
    /// The raw request body, exactly as received. Must be the unparsed string: re-serializing a
    /// deserialized body changes the bytes and breaks verification.
    /// </param>
    /// <param name="sigHeader">The value of the <c>ElevenLabs-Signature</c> header.</param>
    /// <param name="secret">Your webhook signing secret.</param>
    /// <returns>The decoded webhook event.</returns>
    /// <exception cref="ElevenLabsClientApiException">
    /// With status code 400 if the header or secret is missing, the timestamp is outside the
    /// tolerance window, or the signature does not match.
    /// </exception>
    /// <exception cref="JsonException">
    /// If the signature is valid but the body is not a JSON object.
    /// </exception>
    public static JsonObject ConstructEvent(string rawBody, string sigHeader, string secret) =>
        ConstructEvent(rawBody, sigHeader, secret, DateTimeOffset.UtcNow);

    internal static JsonObject ConstructEvent(
        string rawBody,
        string sigHeader,
        string secret,
        DateTimeOffset now
    )
    {
        if (string.IsNullOrEmpty(sigHeader))
        {
            throw Fail("Missing signature header");
        }

        if (string.IsNullOrEmpty(secret))
        {
            throw Fail("Webhook secret not configured");
        }

        rawBody ??= string.Empty;

        string? timestamp = null;
        string? signature = null;
        foreach (var part in sigHeader.Split(','))
        {
            if (part.StartsWith("t=", StringComparison.Ordinal))
            {
                timestamp = part.Substring(2);
            }
            else if (part.StartsWith("v0=", StringComparison.Ordinal))
            {
                signature = part;
            }
        }

        if (string.IsNullOrEmpty(timestamp) || signature == null)
        {
            throw Fail("No signature hash found with expected scheme v0");
        }

        // A non-numeric timestamp can never be inside the window, so it is rejected the same way
        // as a stale one rather than surfacing a FormatException.
        if (
            !long.TryParse(timestamp, NumberStyles.None, CultureInfo.InvariantCulture, out var ts)
            || ts < now.ToUnixTimeSeconds() - ToleranceSeconds
        )
        {
            throw Fail("Timestamp outside the tolerance zone");
        }

        byte[] mac;
        using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secret)))
        {
            mac = hmac.ComputeHash(Encoding.UTF8.GetBytes(timestamp + "." + rawBody));
        }
        var expected = Encoding.UTF8.GetBytes("v0=" + ToLowerHex(mac));
        var actual = Encoding.UTF8.GetBytes(signature);

        if (!FixedTimeEquals(expected, actual))
        {
            throw Fail("Signature hash does not match the expected signature hash for payload");
        }

        return JsonNode.Parse(rawBody) as JsonObject
            ?? throw new JsonException("Webhook payload is not a JSON object");
    }

    private static ElevenLabsClientApiException Fail(string message) =>
        new(message, 400, string.Empty);

    private static string ToLowerHex(byte[] bytes)
    {
        var sb = new StringBuilder(bytes.Length * 2);
        foreach (var b in bytes)
        {
            sb.Append(b.ToString("x2", CultureInfo.InvariantCulture));
        }
        return sb.ToString();
    }

    private static bool FixedTimeEquals(byte[] left, byte[] right)
    {
#if NET5_0_OR_GREATER || NETSTANDARD2_1
        return CryptographicOperations.FixedTimeEquals(left, right);
#else
        if (left.Length != right.Length)
        {
            return false;
        }
        var result = 0;
        for (var i = 0; i < left.Length; i++)
        {
            result |= left[i] ^ right[i];
        }
        return result == 0;
#endif
    }
}
