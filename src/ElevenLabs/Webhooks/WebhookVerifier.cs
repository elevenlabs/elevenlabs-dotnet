using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Nodes;

namespace ElevenLabs;

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
/// This is a hand-written helper rather than generated code: the Fern generator's built-in
/// verifier cannot parse a compound header that carries both the timestamp and the signature.
/// It is listed in <c>.fernignore</c> so regeneration leaves it in place.
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
    /// Verifies a webhook signature and returns the decoded event payload.
    /// </summary>
    /// <param name="rawBody">
    /// The raw request body, exactly as received. Must be the unparsed string: re-encoding a
    /// decoded body changes the bytes and breaks verification.
    /// </param>
    /// <param name="sigHeader">The value of the <c>ElevenLabs-Signature</c> header.</param>
    /// <param name="secret">Your webhook signing secret.</param>
    /// <returns>The decoded webhook event.</returns>
    /// <exception cref="ElevenLabsClientApiException">
    /// Thrown if the header or secret is missing, the timestamp is outside the tolerance window,
    /// or the signature does not match.
    /// </exception>
    public static JsonNode ConstructEvent(string rawBody, string sigHeader, string secret)
    {
        if (string.IsNullOrEmpty(sigHeader))
        {
            throw new ElevenLabsClientApiException("Missing signature header", 400, string.Empty);
        }

        if (string.IsNullOrEmpty(secret))
        {
            throw new ElevenLabsClientApiException(
                "Webhook secret not configured",
                400,
                string.Empty
            );
        }

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
            throw new ElevenLabsClientApiException(
                "No signature hash found with expected scheme v0",
                400,
                string.Empty
            );
        }

        // Parse failures collapse to 0, which falls outside the past-only tolerance window and is
        // rejected below, matching the other SDKs' lenient integer coercion.
        _ = long.TryParse(timestamp, out var timestampSeconds);
        var requestTimestampMs = timestampSeconds * 1000L;
        var toleranceMs = (DateTimeOffset.UtcNow.ToUnixTimeSeconds() - ToleranceSeconds) * 1000L;
        if (requestTimestampMs < toleranceMs)
        {
            throw new ElevenLabsClientApiException(
                "Timestamp outside the tolerance zone",
                400,
                string.Empty
            );
        }

        var digest = "v0=" + ComputeHmacSha256Hex(secret, timestamp + "." + rawBody);
        if (!FixedTimeEquals(digest, signature!))
        {
            throw new ElevenLabsClientApiException(
                "Signature hash does not match the expected signature hash for payload",
                400,
                string.Empty
            );
        }

        return JsonNode.Parse(rawBody)
            ?? throw new ElevenLabsClientApiException(
                "Signature hash does not match the expected signature hash for payload",
                400,
                string.Empty
            );
    }

    private static string ComputeHmacSha256Hex(string secret, string message)
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

    private static bool FixedTimeEquals(string left, string right)
    {
        var leftBytes = Encoding.UTF8.GetBytes(left);
        var rightBytes = Encoding.UTF8.GetBytes(right);
#if NET5_0_OR_GREATER || NETSTANDARD2_1
        return CryptographicOperations.FixedTimeEquals(leftBytes, rightBytes);
#else
        // Manual constant-time comparison for targets without CryptographicOperations
        // (net462, netstandard2.0). Compares every byte so timing does not leak where a
        // mismatch occurred; a length difference still fails without short-circuiting.
        if (leftBytes.Length != rightBytes.Length)
        {
            return false;
        }
        var result = 0;
        for (var i = 0; i < leftBytes.Length; i++)
        {
            result |= leftBytes[i] ^ rightBytes[i];
        }
        return result == 0;
#endif
    }
}
