using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ElevenLabs.SpeechEngine;
using NUnit.Framework;

namespace ElevenLabs.AspNetCore.Tests;

/// <summary>
/// Coverage for the ASP.NET Core attach helpers shipped in the <c>elevenlabs-dotnet-aspnetcore</c>
/// companion package: the <c>VerifyRequest(HttpRequest)</c> and <c>Attach</c> extension methods on
/// <see cref="SpeechEngineResource"/>.
/// </summary>
[TestFixture]
public class SpeechEngineAspNetCoreExtensionsTest
{
    // Shared cross-SDK golden vector (see SpeechEngineJwtVerifierTest).
    private const string ApiKey = "sk_0123456789abcdef0123456789abcdef";
    private const string Token =
        "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9."
        + "eyJpc3MiOiJodHRwczovL2FwaS5lbGV2ZW5sYWJzLmlvL2NvbnZhaS9zcGVlY2gtZW5naW5lIiwic3ViIjoiY29udmFpX3NwZWVjaF9lbmdpbmVfdXBzdHJlYW0iLCJpYXQiOjEyMzQ1Njc4OTAsImV4cCI6NDEwMjQ0NDgwMH0."
        + "UObM4hx1W8NvGViU3aqPv1-IEXhmXgWDgoS9RZZWILk";
    private const string AuthHeader = "X-ElevenLabs-Speech-Engine-Authorization";

    [Test]
    public void VerifyRequestAcceptsTheGoldenTokenFromAnHttpRequest()
    {
        var resource = new SpeechEngineResource("seng_1", ApiKey);
        var context = new DefaultHttpContext();
        context.Request.Headers[AuthHeader] = Token;

        Assert.That(resource.VerifyRequest(context.Request), Is.True);
    }

    [Test]
    public void VerifyRequestRejectsWhenTheHeaderIsMissing()
    {
        var resource = new SpeechEngineResource("seng_1", ApiKey);
        var context = new DefaultHttpContext();

        Assert.That(resource.VerifyRequest(context.Request), Is.False);
    }

    [Test]
    public void AttachReturnsAnAttachmentThatCloses()
    {
        var resource = new SpeechEngineResource("seng_1", ApiKey);
        var app = new ApplicationBuilder(new ServiceCollection().BuildServiceProvider());

        var attachment = resource.Attach(app, "/speech-engine", new SpeechEngineCallbacks());

        Assert.That(attachment, Is.Not.Null);
        Assert.That(attachment.IsClosed, Is.False);

        attachment.Close();
        Assert.That(attachment.IsClosed, Is.True);
    }

    [Test]
    public void AttachThrowsOnNullApplicationBuilder()
    {
        var resource = new SpeechEngineResource("seng_1", ApiKey);

        Assert.That(
            () => resource.Attach(null!, "/speech-engine", new SpeechEngineCallbacks()),
            Throws.ArgumentNullException
        );
    }
}
