using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using ElevenLabs.SpeechEngine;
using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Coverage for <c>global::ElevenLabs.SpeechEngine.SpeechEngineJwtVerifier</c>, mirroring the shared
/// cross-SDK suite. The golden vector's <c>exp</c> is far in the future so the token stays valid
/// forever; every ElevenLabs SDK must accept this exact (apiKey, token) pair.
/// </summary>
[TestFixture]
public class SpeechEngineJwtVerifierTest
{
    private const string ApiKey = "sk_0123456789abcdef0123456789abcdef";

    private const string Token =
        "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9"
        + ".eyJpc3MiOiJodHRwczovL2FwaS5lbGV2ZW5sYWJzLmlvL2NvbnZhaS9zcGVlY2gtZW5naW5lIiwic3ViIjoiY29udmFpX3NwZWVjaF9lbmdpbmVfdXBzdHJlYW0iLCJpYXQiOjEyMzQ1Njc4OTAsImV4cCI6NDEwMjQ0NDgwMH0"
        + ".UObM4hx1W8NvGViU3aqPv1-IEXhmXgWDgoS9RZZWILk";

    [Test]
    public void GoldenVectorVerifiesAndDecodes()
    {
        var claims = SpeechEngineJwtVerifier.Verify(Token, ApiKey);

        Assert.That(
            claims["iss"]!.GetValue<string>(),
            Is.EqualTo("https://api.elevenlabs.io/convai/speech-engine")
        );
        Assert.That(claims["sub"]!.GetValue<string>(), Is.EqualTo("convai_speech_engine_upstream"));
        Assert.That(claims["exp"]!.GetValue<long>(), Is.EqualTo(4102444800L));
    }

    [Test]
    public void BearerPrefixIsAccepted()
    {
        var claims = SpeechEngineJwtVerifier.Verify("Bearer " + Token, ApiKey);
        Assert.That(claims["sub"]!.GetValue<string>(), Is.EqualTo("convai_speech_engine_upstream"));
    }

    [Test]
    public void ResidencyKeyNormalizesToBaseKey()
    {
        var claims = SpeechEngineJwtVerifier.Verify(Token, ApiKey + "_residency_in");
        Assert.That(claims["sub"]!.GetValue<string>(), Is.EqualTo("convai_speech_engine_upstream"));
    }

    [Test]
    public void WrongApiKeyIsRejected()
    {
        var ex = Assert.Throws<ElevenLabsClientApiException>(
            () => SpeechEngineJwtVerifier.Verify(Token, "sk_wrongwrongwrongwrongwrongwrongwrong")
        );
        Assert.That(ex!.Message, Does.Contain("signature mismatch"));
    }

    [Test]
    public void TamperedPayloadIsRejected()
    {
        var parts = Token.Split('.');
        var forged = Base64Url(
            Encoding.UTF8.GetBytes(
                "{\"iss\":\"https://api.elevenlabs.io/convai/speech-engine\",\"sub\":\"evil\",\"iat\":1234567890,\"exp\":4102444800}"
            )
        );
        var ex = Assert.Throws<ElevenLabsClientApiException>(
            () => SpeechEngineJwtVerifier.Verify($"{parts[0]}.{forged}.{parts[2]}", ApiKey)
        );
        Assert.That(ex!.Message, Does.Contain("signature mismatch"));
    }

    [Test]
    public void ExpiredTokenIsRejected()
    {
        var now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        var token = Sign(
            new Dictionary<string, object>
            {
                ["iss"] = "https://api.elevenlabs.io/convai/speech-engine",
                ["sub"] = "convai_speech_engine_upstream",
                ["iat"] = now - 3600,
                ["exp"] = now - 120,
            }
        );
        var ex = Assert.Throws<ElevenLabsClientApiException>(
            () => SpeechEngineJwtVerifier.Verify(token, ApiKey)
        );
        Assert.That(ex!.Message, Does.Contain("expired"));
    }

    [Test]
    public void FutureIssuedAtIsRejected()
    {
        var now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        var token = Sign(
            new Dictionary<string, object>
            {
                ["iss"] = "https://api.elevenlabs.io/convai/speech-engine",
                ["sub"] = "convai_speech_engine_upstream",
                ["iat"] = now + 3600,
                ["exp"] = now + 7200,
            }
        );
        var ex = Assert.Throws<ElevenLabsClientApiException>(
            () => SpeechEngineJwtVerifier.Verify(token, ApiKey)
        );
        Assert.That(ex!.Message, Does.Contain("iat is in the future"));
    }

    [Test]
    public void WrongIssuerIsRejected()
    {
        var token = Sign(
            new Dictionary<string, object>
            {
                ["iss"] = "https://evil.example.com",
                ["sub"] = "convai_speech_engine_upstream",
                ["iat"] = 1234567890L,
                ["exp"] = 4102444800L,
            }
        );
        var ex = Assert.Throws<ElevenLabsClientApiException>(
            () => SpeechEngineJwtVerifier.Verify(token, ApiKey)
        );
        Assert.That(ex!.Message, Does.Contain("unexpected issuer"));
    }

    [Test]
    public void MalformedTokenIsRejected()
    {
        var ex = Assert.Throws<ElevenLabsClientApiException>(
            () => SpeechEngineJwtVerifier.Verify("not-a-jwt", ApiKey)
        );
        Assert.That(ex!.Message, Does.Contain("expected 3 parts"));
    }

    [Test]
    public void MissingApiKeyIsRejected()
    {
        var ex = Assert.Throws<ElevenLabsClientApiException>(
            () => SpeechEngineJwtVerifier.Verify(Token, "")
        );
        Assert.That(ex!.Message, Does.Contain("No API key configured"));
    }

    // Sign a payload into an HS256 JWT with the test key, mirroring how the API signs.
    private static string Sign(IDictionary<string, object> claims)
    {
        var header = Base64Url(Encoding.UTF8.GetBytes("{\"alg\":\"HS256\",\"typ\":\"JWT\"}"));
        var payload = Base64Url(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(claims)));
        byte[] secret;
        using (var sha = SHA256.Create())
        {
            secret = sha.ComputeHash(Encoding.UTF8.GetBytes(ApiKey));
        }
        byte[] sig;
        using (var hmac = new HMACSHA256(secret))
        {
            sig = hmac.ComputeHash(Encoding.UTF8.GetBytes(header + "." + payload));
        }
        return $"{header}.{payload}.{Base64Url(sig)}";
    }

    private static string Base64Url(byte[] bytes) =>
        Convert.ToBase64String(bytes).Replace('+', '-').Replace('/', '_').TrimEnd('=');
}
