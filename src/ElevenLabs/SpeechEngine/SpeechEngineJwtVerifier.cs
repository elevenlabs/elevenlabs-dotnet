using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;

namespace ElevenLabs.SpeechEngine;

/// <summary>
/// Verifies the JWT that the ElevenLabs Speech Engine API presents when it opens an inbound
/// WebSocket connection to a developer-owned Speech Engine server.
/// </summary>
/// <remarks>
/// <para>
/// The token arrives in the <c>X-ElevenLabs-Speech-Engine-Authorization</c> header and is an HS256
/// JWT whose HMAC secret is the SHA-256 hash of the account's API key. Data-residency keys
/// (<c>..._residency_&lt;region&gt;</c>) are signed with the base key, so the suffix is stripped before
/// hashing.
/// </para>
/// <para>
/// This is a hand-written helper (listed in <c>.fernignore</c>): the generator has no concept of the
/// Speech Engine upstream handshake. It mirrors <c>verifySpeechEngineJwt</c> in the TypeScript and
/// Python SDKs so every SDK accepts the same tokens.
/// </para>
/// </remarks>
public static class SpeechEngineJwtVerifier
{
    private const string Issuer = "https://api.elevenlabs.io/convai/speech-engine";
    private const string Subject = "convai_speech_engine_upstream";

    /// <summary>Clock skew, in seconds, allowed on the <c>exp</c> and <c>iat</c> claims.</summary>
    private const long LeewaySeconds = 60;

    private static readonly Regex ResidencyKeySuffix = new(
        "_residency_[a-z0-9]+$",
        RegexOptions.Compiled
    );

    /// <summary>
    /// Verifies an inbound Speech Engine connection token and returns its decoded claims.
    /// </summary>
    /// <param name="token">
    /// The <c>X-ElevenLabs-Speech-Engine-Authorization</c> header value, with or without a
    /// <c>Bearer </c> prefix.
    /// </param>
    /// <param name="apiKey">The account API key the engine was created with.</param>
    /// <returns>The decoded JWT payload (claims) as a <see cref="JsonObject"/>.</returns>
    /// <exception cref="ElevenLabsClientApiException">
    /// If the API key is missing, the token is malformed, the signature does not match, or a claim
    /// (issuer, subject, exp, iat) is invalid.
    /// </exception>
    public static JsonObject Verify(string token, string apiKey)
    {
        if (string.IsNullOrEmpty(apiKey))
        {
            throw Fail("No API key configured for Speech Engine verification");
        }

        token = (token ?? string.Empty).Trim();
        if (token.StartsWith("bearer ", StringComparison.OrdinalIgnoreCase))
        {
            token = token.Substring(7).Trim();
        }

        var parts = token.Split('.');
        if (parts.Length != 3)
        {
            throw Fail("Invalid JWT: expected 3 parts");
        }

        var headerB64 = parts[0];
        var payloadB64 = parts[1];
        var signatureB64 = parts[2];

        byte[] payloadBytes;
        JsonNode? payloadNode;
        try
        {
            payloadBytes = Base64UrlDecode(payloadB64);
            payloadNode = JsonNode.Parse(Encoding.UTF8.GetString(payloadBytes));
        }
        catch (Exception)
        {
            throw Fail("Invalid JWT: failed to decode payload");
        }

        if (payloadNode is not JsonObject payload)
        {
            throw Fail("Invalid JWT: payload is not an object");
        }

        // HMAC secret is the SHA-256 of the residency-suffix-stripped API key.
        byte[] secret;
        using (var sha = SHA256.Create())
        {
            secret = sha.ComputeHash(Encoding.UTF8.GetBytes(NormalizeApiKeyForSigning(apiKey)));
        }

        byte[] expected;
        using (var hmac = new HMACSHA256(secret))
        {
            expected = hmac.ComputeHash(Encoding.UTF8.GetBytes(headerB64 + "." + payloadB64));
        }

        byte[] actual;
        try
        {
            actual = Base64UrlDecode(signatureB64);
        }
        catch (Exception)
        {
            actual = Array.Empty<byte>();
        }

        if (!FixedTimeEquals(expected, actual))
        {
            throw Fail(
                "Invalid JWT: signature mismatch — make sure the API key used by your Speech Engine "
                    + "server matches the one used to create the engine."
            );
        }

        if (GetString(payload, "iss") != Issuer)
        {
            throw Fail("Invalid JWT: unexpected issuer");
        }
        if (GetString(payload, "sub") != Subject)
        {
            throw Fail("Invalid JWT: unexpected subject");
        }

        var now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        if (!TryGetInt64(payload, "exp", out var exp))
        {
            throw Fail("Invalid JWT: missing exp claim");
        }
        if (!TryGetInt64(payload, "iat", out var iat))
        {
            throw Fail("Invalid JWT: missing iat claim");
        }
        if (exp + LeewaySeconds < now)
        {
            throw Fail("Invalid JWT: token has expired");
        }
        if (iat - LeewaySeconds > now)
        {
            throw Fail("Invalid JWT: iat is in the future");
        }

        return payload;
    }

    private static ElevenLabsClientApiException Fail(string message) =>
        new(message, 400, string.Empty);

    private static string NormalizeApiKeyForSigning(string apiKey) =>
        ResidencyKeySuffix.Replace(apiKey.Trim(), string.Empty);

    private static string? GetString(JsonObject payload, string key) =>
        payload.TryGetPropertyValue(key, out var node) && node is JsonValue value
        && value.TryGetValue<string>(out var s)
            ? s
            : null;

    private static bool TryGetInt64(JsonObject payload, string key, out long result)
    {
        result = 0;
        if (
            payload.TryGetPropertyValue(key, out var node)
            && node is JsonValue value
            && value.TryGetValue<long>(out var l)
        )
        {
            result = l;
            return true;
        }
        return false;
    }

    /// <summary>Decode a base64url string (RFC 7515), tolerating missing padding.</summary>
    private static byte[] Base64UrlDecode(string input)
    {
        var padded = input.Replace('-', '+').Replace('_', '/');
        var remainder = padded.Length % 4;
        if (remainder != 0)
        {
            padded += new string('=', 4 - remainder);
        }
        return Convert.FromBase64String(padded);
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
