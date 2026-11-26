# ElevenLabs.AspNetCore

ASP.NET Core integration for the [ElevenLabs .NET SDK](https://www.nuget.org/packages/ElevenLabs.Net). It attaches a
[Speech Engine](https://elevenlabs.io/docs/overview/capabilities/speech-engine) server to your application's request
pipeline, so ElevenLabs can connect to your app over WebSocket and you can answer each user transcript with your own logic.

The attach helper lives in this package rather than in `ElevenLabs.Net` so that console, worker and desktop apps using the
core SDK do not take a dependency on the ASP.NET Core shared framework.

## Install

```sh
dotnet add package ElevenLabs.AspNetCore
```

This also installs `ElevenLabs.Net`.

## Usage

```csharp
using ElevenLabs.SpeechEngine;

var app = WebApplication.CreateBuilder(args).Build();

var engine = new SpeechEngineResource(
    "your-speech-engine-id",
    Environment.GetEnvironmentVariable("ELEVENLABS_API_KEY")
);

engine.Attach(app, "/speech-engine", new SpeechEngineCallbacks
{
    OnTranscript = (messages, cancellationToken, session) =>
    {
        // Replace with a call to your LLM. cancellationToken is cancelled when the user speaks again.
        session.SendResponse($"You said: {messages[^1].Content}");
        return Task.CompletedTask;
    },
});

app.Run();
```

`Attach` enables WebSockets, accepts connections on the given path, and rejects any request without a valid
`X-ElevenLabs-Speech-Engine-Authorization` token signed for your API key. It returns a `SpeechEngineAttachment`; call
`Close()` on it to stop accepting new connections without stopping the app.

To verify a request in your own endpoint instead, call `engine.VerifyRequest(httpContext.Request)`.

## Links

- [Speech Engine documentation](https://elevenlabs.io/docs/overview/capabilities/speech-engine)
- [ElevenLabs .NET SDK on GitHub](https://github.com/elevenlabs/elevenlabs-dotnet)
