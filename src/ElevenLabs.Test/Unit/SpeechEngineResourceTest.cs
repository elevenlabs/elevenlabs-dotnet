using System.Collections.Generic;
using ElevenLabs.SpeechEngine;
using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Coverage for <c>global::ElevenLabs.SpeechEngine.SpeechEngineResource</c>, mirroring the shared
/// cross-SDK suite: request verification (header lookup is case-insensitive, failures return
/// <c>false</c> rather than throwing) and the exposed engine id.
/// </summary>
[TestFixture]
public class SpeechEngineResourceTest
{
    private const string ApiKey = "sk_0123456789abcdef0123456789abcdef";

    private const string Token =
        "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9"
        + ".eyJpc3MiOiJodHRwczovL2FwaS5lbGV2ZW5sYWJzLmlvL2NvbnZhaS9zcGVlY2gtZW5naW5lIiwic3ViIjoiY29udmFpX3NwZWVjaF9lbmdpbmVfdXBzdHJlYW0iLCJpYXQiOjEyMzQ1Njc4OTAsImV4cCI6NDEwMjQ0NDgwMH0"
        + ".UObM4hx1W8NvGViU3aqPv1-IEXhmXgWDgoS9RZZWILk";

    [Test]
    public void VerifyRequestAcceptsValidHeader()
    {
        var resource = new SpeechEngineResource("seng_123", ApiKey);
        Assert.That(
            resource.VerifyRequest(
                new Dictionary<string, string>
                {
                    ["X-ElevenLabs-Speech-Engine-Authorization"] = Token,
                }
            ),
            Is.True
        );
    }

    [Test]
    public void VerifyRequestMatchesHeaderNameCaseInsensitively()
    {
        var resource = new SpeechEngineResource("seng_123", ApiKey);
        Assert.That(
            resource.VerifyRequest(
                new Dictionary<string, string>
                {
                    ["x-elevenlabs-speech-engine-authorization"] = Token,
                }
            ),
            Is.True
        );
    }

    [Test]
    public void VerifyRequestHeaderAcceptsValidValue()
    {
        var resource = new SpeechEngineResource("seng_123", ApiKey);
        Assert.That(resource.VerifyRequestHeader(Token), Is.True);
    }

    [Test]
    public void VerifyRequestRejectsMissingHeader()
    {
        var resource = new SpeechEngineResource("seng_123", ApiKey);
        Assert.That(resource.VerifyRequest(new Dictionary<string, string>()), Is.False);
    }

    [Test]
    public void VerifyRequestRejectsWithoutApiKey()
    {
        var resource = new SpeechEngineResource("seng_123", null);
        Assert.That(
            resource.VerifyRequest(
                new Dictionary<string, string>
                {
                    ["X-ElevenLabs-Speech-Engine-Authorization"] = Token,
                }
            ),
            Is.False
        );
    }

    [Test]
    public void VerifyRequestRejectsBadToken()
    {
        var resource = new SpeechEngineResource("seng_123", ApiKey);
        Assert.That(
            resource.VerifyRequest(
                new Dictionary<string, string>
                {
                    ["X-ElevenLabs-Speech-Engine-Authorization"] = "Bearer not.a.jwt",
                }
            ),
            Is.False
        );
    }

    [Test]
    public void ExposesEngineId()
    {
        var resource = new SpeechEngineResource("seng_123", ApiKey);
        Assert.That(resource.EngineId, Is.EqualTo("seng_123"));
        Assert.That(resource.Config, Is.Null);
    }

    [Test]
    public void CreateSessionReturnsUsableSession()
    {
        var resource = new SpeechEngineResource("seng_123", ApiKey);
        var sent = new List<string>();
        var session = resource.CreateSession(sent.Add);

        session.HandleRawMessage("{\"type\":\"ping\"}");

        Assert.That(sent, Has.Count.EqualTo(1));
        Assert.That(sent[0], Does.Contain("pong"));
    }
}
