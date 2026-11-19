# ElevenLabs C# Library

![LOGO](https://github.com/elevenlabs/elevenlabs-python/assets/12028621/21267d89-5e82-4e7e-9c81-caf30b237683)

[![fern shield](https://img.shields.io/badge/%F0%9F%8C%BF-SDK%20generated%20by%20Fern-brightgreen)](https://buildwithfern.com/?utm_source=fern-elevenlabs/elevenlabs-dotnet/readme)
[![Discord](https://badgen.net/badge/black/ElevenLabs/icon?icon=discord&label)](https://discord.gg/elevenlabs)
[![Twitter](https://badgen.net/badge/black/elevenlabsio/icon?icon=twitter&label)](https://twitter.com/elevenlabsio)
[![nuget shield](https://img.shields.io/nuget/v/elevenlabs-dotnet-sdk)](https://nuget.org/packages/elevenlabs-dotnet-sdk)

The official C# SDK for [ElevenLabs](https://elevenlabs.io/). ElevenLabs brings the most compelling, rich and lifelike voices to creators and developers in just a few lines of code.

## 📖 API & Docs

Check out the [HTTP API documentation](https://elevenlabs.io/docs/api-reference). A full reference for this library is available [here](./reference.md).

## Install

```sh
dotnet add package elevenlabs-dotnet-sdk
```

## Usage

### Main Models

1. **Eleven v4** (`eleven_v4`)
    - Highest quality and most expressive speech, with reliable voice cloning across long generations
    - 90+ languages with consistent voice quality across language switches
    - Up to 10,000 characters (~10 minutes of audio) per request
    - Used via the [Text to Dialogue API](https://elevenlabs.io/docs/api-reference/text-to-dialogue/convert)

2. **Eleven v4 Turbo** (`eleven_v4_turbo`)
    - State-of-the-art real-time speech, with a median latency of ~100ms
    - 90+ languages
    - Ideal for voice agents and other latency-sensitive use cases

3. **Eleven Multilingual v2** (`eleven_multilingual_v2`)
    - Excels in stability, language diversity, and accent accuracy
    - The most stable choice for long-form Text to Speech
    - Supports 29 languages

4. **Eleven Flash v2.5** (`eleven_flash_v2_5`)
    - Ultra-low latency and lowest cost
    - Supports 32 languages

For more detailed information about these models and others, visit the [ElevenLabs Models documentation](https://elevenlabs.io/docs/models).

Instantiate and use the client with the following:

```csharp
using ElevenLabs;

// Reads the API key from the ELEVENLABS_API_KEY environment variable.
// Pass it explicitly with new ElevenLabsClient("YOUR_API_KEY") if you prefer.
var client = new ElevenLabsClient();

await using var audio = await client.TextToSpeech.ConvertAsync(
    "JBFqnCBsd6RMkjVDRZzb",
    new ConvertTextToSpeechRequest
    {
        OutputFormat = ConvertTextToSpeechRequestOutputFormat.Mp344100128,
        Body = new BodyTextToSpeechFull
        {
            Text = "The first move is what sets everything in motion.",
            ModelId = "eleven_multilingual_v2",
        },
    }
);

// The response is an audio stream; copy it to a file.
await using var file = File.Create("output.mp3");
await audio.CopyToAsync(file);
```

### Text to Dialogue (Eleven v4)

Eleven v4 and Eleven v4 Turbo are served through the Text to Dialogue API, which turns a list of speaker turns into a single expressive audio stream.

```csharp
await using var audio = await client.TextToDialogue.ConvertAsync(
    new ConvertTextToDialogueRequest
    {
        OutputFormat = ConvertTextToDialogueRequestOutputFormat.Mp344100128,
        Body = new BodyTextToDialogueMultiVoiceV1TextToDialoguePost
        {
            ModelId = "eleven_v4",
            Inputs = new List<DialogueInput>
            {
                new() { Text = "[giggling] Knock knock", VoiceId = "JBFqnCBsd6RMkjVDRZzb" },
                new() { Text = "[curious] Who is there?", VoiceId = "Aw4FAjKCGjjNkVhN1Xmq" },
            },
        },
    }
);

await using var file = File.Create("dialogue.mp3");
await audio.CopyToAsync(file);
```

## Voices

List all your available voices with `SearchAsync`.

```csharp
var response = await client.Voices.SearchAsync(new SearchVoicesRequest());
foreach (var voice in response.Voices)
{
    Console.WriteLine(voice.Name);
}
```

For information about the structure of the voices output, please refer to the [official ElevenLabs API documentation for Get Voices](https://elevenlabs.io/docs/api-reference/get-voices).

## Streaming

Stream audio in real-time, as it's being generated. `StreamAsync` returns the HTTP response body as a
`Stream`, so you can read and play or write each chunk before the server has finished.

```csharp
await using var audio = await client.TextToSpeech.StreamAsync(
    "JBFqnCBsd6RMkjVDRZzb",
    new StreamTextToSpeechRequest
    {
        OutputFormat = StreamTextToSpeechRequestOutputFormat.Mp344100128,
        Body = new BodyTextToSpeechStream
        {
            Text = "This is a... streaming voice.",
            ModelId = "eleven_multilingual_v2",
        },
    }
);

await using var file = File.Create("output.mp3");
await audio.CopyToAsync(file);
```

## Environments

This SDK allows you to configure different environments for API requests. It defaults to the production environment.

```csharp
using ElevenLabs;

var client = new ElevenLabsClient(
    clientOptions: new ClientOptions
    {
        BaseUrl = ElevenLabsClientEnvironment.ProductionUs,
    }
);
```

Available environments:
- `ElevenLabsClientEnvironment.Production`
- `ElevenLabsClientEnvironment.ProductionUs`
- `ElevenLabsClientEnvironment.ProductionEu`
- `ElevenLabsClientEnvironment.ProductionIndia`
- `ElevenLabsClientEnvironment.ProductionSingapore`

## Exception Handling

When the API returns a non-success status code (4xx or 5xx response), a subclass of
`ElevenLabsClientApiException` is thrown. The HTTP status code is available via `StatusCode` and the
raw response body via `Body`. Specific status codes throw named subclasses (for example `NotFoundError`
for a 404), so you can catch the one you care about.

```csharp
using ElevenLabs;

try
{
    var response = await client.TextToSpeech.ConvertAsync(...);
}
catch (NotFoundError)
{
    // Handle a 404 specifically.
}
catch (ElevenLabsClientApiException e)
{
    Console.WriteLine($"API error occurred: {e.Message}");
    Console.WriteLine($"Status code: {e.StatusCode}");
    Console.WriteLine($"Response body: {e.Body}");
}
```

## WebSockets

Real-time channels are created from the client with a `Create...Api` factory. Subscribe to the
channel's receive event, call `ConnectAsync`, then `Send` messages (typed, `string`, or `byte[]`);
`CloseAsync` or disposal closes the connection.

```csharp
await using var dubbing = client.CreateDubbingApi(
    new DubbingApi.Options
    {
        TargetLanguage = "es",
        SourceLanguage = "en",
    }
);

dubbing.ReceiveDubbingStreamMessage.Subscribe(message =>
{
    // Handle each message.
});

await dubbing.ConnectAsync();
await dubbing.Send(/* a SendDubbingStreamMessage */);

await dubbing.CloseAsync();
```

The SDK has one channel per factory:

- `client.CreateDubbingApi(...)` returns an `IDubbingApi`
- `client.CreateTextToSpeechApi(...)` returns an `ITextToSpeechApi`
- `client.CreateTextToSpeechMultiContextApi(...)` returns an `ITextToSpeechMultiContextApi`
- `client.CreateTextToDialogueApi(...)` returns an `ITextToDialogueApi`
- `client.CreateTextToDialogueMultiContextApi(...)` returns an `ITextToDialogueMultiContextApi`
- `client.CreateSpeechToTextApi(...)` returns an `ISpeechToTextApi`
- `client.CreateSpeechEngineApi(...)` returns an `ISpeechEngineApi`
- `client.CreateTranslationApi(...)` returns an `ITranslationApi`

## Webhooks

ElevenLabs signs each webhook it sends with your webhook secret. `client.Webhooks.ConstructEvent`
verifies the `ElevenLabs-Signature` header and returns the decoded event as a `JsonObject`. Pass the
raw request body exactly as received: re-serializing a deserialized body changes the bytes and breaks
verification.

```csharp
using ElevenLabs;

// In an ASP.NET Core minimal API handler:
using var reader = new StreamReader(request.Body);
var rawBody = await reader.ReadToEndAsync();

try
{
    var evt = client.Webhooks.ConstructEvent(
        rawBody,
        request.Headers["ElevenLabs-Signature"].ToString(),
        Environment.GetEnvironmentVariable("ELEVENLABS_WEBHOOK_SECRET")!
    );
    Console.WriteLine(evt["type"]);
}
catch (ElevenLabsClientApiException)
{
    // Missing or invalid signature, or a timestamp older than 30 minutes.
    return Results.BadRequest();
}
```

`ElevenLabs.Webhooks.WebhookVerifier.ConstructEvent` does the same without a client.

## Composing music with metadata

`POST /v1/music/detailed` returns the song's metadata and its audio file in one `multipart/mixed`
response. `MusicDetailed.ComposeDetailedAsync` sends that request and splits the response for you.

```csharp
using ElevenLabs;
using ElevenLabs.Music;

var client = new ElevenLabsClient();
var music = new MusicDetailed(client);

var song = await music.ComposeDetailedAsync(
    new ComposeDetailedMusicRequest
    {
        Body = new BodyComposeMusicWithADetailedResponseV1MusicDetailedPost
        {
            Prompt = "Epic orchestral music with dramatic strings and powerful brass",
            MusicLengthMs = 60000,
        },
    }
);

Console.WriteLine(song.Json["song_metadata"]?["title"]);
File.WriteAllBytes(song.Filename, song.Audio);
```

- `Json` is the metadata part as the API sends it: `composition_plan`, `song_metadata` and
  `words_timestamps`.
- `Audio` is the audio file's bytes and `Filename` the name the API suggests for it.
- `SongId` is set when the request has `StoreForInpainting` enabled.
- Use this rather than `client.Music.ComposeDetailedAsync`, which can't decode the multipart
  response.

## Flows: wait for a generation

Flows generations and template runs finish asynchronously: `CreateAsync` returns straight away
with a `pending` status. `CreateAndWaitAsync` creates the generation, then polls `GetAsync` until it
is `completed` or `failed` and returns the final response. It is on `client.Flows.Image`,
`client.Flows.Video`, `client.Flows.TextToSpeech` and `client.Flows.Templates.Runs`.

```csharp
using ElevenLabs;
using ElevenLabs.Flows;

var client = new ElevenLabsClient();

var generation = await client.Flows.Image.CreateAndWaitAsync(
    new CreateImageRequest
    {
        Body = new ImageGenerationRequest(
            new ImageGenerationRequest.BytedanceSeedream5Lite(
                new BytedanceSeedream5LiteRequest
                {
                    Prompt = "A corgi in a tiny lifeguard chair on a sunlit beach, photorealistic",
                    ModelId = BytedanceSeedream5LiteRequestModelId.BytedanceSeedream5Lite,
                }
            )
        ),
    },
    new FlowsWaitOptions { WaitTimeout = TimeSpan.FromMinutes(5) }
);

if (generation.IsCompleted)
{
    Console.WriteLine(generation.AsCompleted().ContentUrl);
}
else
{
    Console.WriteLine(generation.AsFailed().ErrorMessage);
}
```

- A `failed` generation or run is returned, not thrown. Check the status on the result.
- Between status checks it waits as long as the server's `Retry-After` header says, never less
  than `MinPollInterval` (3 seconds by default, 0.5 seconds at the least), plus up to 20% jitter.
- `WaitTimeout` bounds the whole wait. It defaults to `null`, which waits indefinitely. When it
  runs out, `FlowsWaitTimeoutException` is thrown with the `Id` (and `TemplateId` for a run) so you
  can resume with `GetAsync`. The work keeps running on the server.
- `RequestOptions` apply to the create call and to every status check, except
  `AdditionalBodyProperties`, which only the create call gets.

For a template run, pass the template id:

```csharp
using ElevenLabs.Flows.Templates;

var run = await client.Flows.Templates.Runs.CreateAndWaitAsync(
    "tpl_123",
    new CreateRunsRequest { Body = new TemplateRunCreateRequest() }
);
```

Waiting holds a process open, so this suits scripts and quickstarts. In production, set `Webhook`
on the request and handle the webhook event instead.

## Agent tools as code

`ElevenLabs.AgentTools` builds agent tools in code: webhook tools, client tools and system tools
such as ending or transferring the call. `Build()` validates the tool and returns the
`ToolRequestModel` that `client.Agents.Tools.CreateAsync` and `UpdateAsync` accept. `ToJsonString()`
writes the same format the ElevenLabs CLI keeps in `tool_configs/*.json`, and `Tool.FromJson` loads it
back for editing.

```csharp
using ElevenLabs;
using ElevenLabs.Agents;
using ElevenLabs.AgentTools;
using ElevenLabs.AgentWorkflows;
// ElevenLabs.Tool is a generated model, so name the builder explicitly.
using Tool = ElevenLabs.AgentTools.Tool;

var getOrder = Tool.Webhook("get_order", "Look up an order by the number the caller gives")
    .Get("https://api.example.com/orders/{order_id}")
    .PathParam("order_id", Schema.String().Describe("The order number, e.g. A-1042"))
    .QueryParam("include", Schema.String().Constant("items"))
    .Header("Authorization", Header.Secret("sec_orders_api"))
    .Header("X-Caller", Header.Variable("system__caller_id"))
    .Assign("order_status", "order.status")
    .Options(new WebhookToolOptions { ResponseTimeoutSecs = 10, PreToolSpeech = "force" });

var refund = Tool.Webhook("issue_refund", "Refund an order the caller asked to return")
    .Post("https://api.example.com/refunds")
    .Body(
        Schema.Object()
            .Property("order_id", Schema.String().FromVariable("order_id"))
            .Property("reason", Schema.String().Describe("Why the caller wants a refund").Choices("damaged", "late", "other"))
            .Property("note", Schema.String().Describe("Anything else the caller said").Optional())
    );

var transfer = SystemTool.TransferToNumber()
    .Transfer("Caller asks for billing", Destination.Phone("+15551234567"))
    .Transfer(
        "Caller asks for a manager",
        Destination.SipVariable("manager_sip"),
        new SystemTransferOptions { TransferType = "sip_refer" }
    );

var client = new ElevenLabsClient();
var created = await client.Agents.Tools.CreateAsync(new CreateToolsRequest { Body = getOrder.Build() });
File.WriteAllText("tool_configs/issue_refund.json", refund.ToJsonString());
var builtInTools = new BuiltInToolsInput { TransferToNumber = transfer.BuildConfig() };
```

- Every literal param needs exactly one value source: `Describe` (the LLM provides it),
  `FromVariable`, `Constant`, `SystemProvided` or `Omit`. Properties are required unless marked
  `Optional()`.
- `Schema` values are immutable, so one schema can be shared by several tools. `Schema.String()`,
  `Integer()`, `Number()` and `Bool()` return a `LiteralSchema`, `Object()` an `ObjectSchema` and
  `Array(items)` an `ArraySchema`; methods that only apply to one kind live on that type.
- `Build()`, `BuildConfig()` and `ToJson()` report every problem at once in a
  `ToolValidationException`, whose `Issues` carry stable codes such as `missing_url` or
  `missing_value_source`. Pass `onWarning` to `Build()` to see warnings.
- Attach webhook and client tools to an agent by id in `prompt.tool_ids`. A system tool goes in
  `prompt.built_in_tools`, from `BuildConfig()`.
- `Destination` and the transfer option names are shared with the workflow builder in
  `ElevenLabs.AgentWorkflows`.
- A loaded tool of a type the builder can't edit, such as an MCP tool, has `Kind == ToolKind.Other`.
  It round-trips unchanged, and `Build()` warns with `unknown_tool_type`.

## Advanced

### Retries

The SDK is instrumented with automatic retries with exponential backoff. A request will be retried as long
as the request is deemed retryable and the number of retry attempts has not grown larger than the configured
retry limit (default: 2).

A request is deemed retryable when any of the following HTTP status codes is returned:

- [408](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/408) (Timeout)
- [429](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/429) (Too Many Requests)
- [5XX](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/500) (Internal Server Errors)

Use the `MaxRetries` request option to configure this behavior.

```csharp
var response = await client.TextToSpeech.ConvertAsync(
    ...,
    new RequestOptions {
        MaxRetries = 0 // Override MaxRetries at the request level
    }
);
```

### Timeouts

The SDK defaults to a 240 second timeout. Use the `Timeout` option to configure this behavior.

```csharp
var response = await client.TextToSpeech.ConvertAsync(
    ...,
    new RequestOptions {
        Timeout = TimeSpan.FromSeconds(3) // Override timeout to 3s
    }
);
```

### Raw Response

Access raw HTTP response data (status code, headers, URL) alongside parsed response data using the `.WithRawResponse()` method.

```csharp
using ElevenLabs;

// Access raw response data (status code, headers, etc.) alongside the parsed response
var result = await client.Voices.SearchAsync(new SearchVoicesRequest()).WithRawResponse();

// Access the parsed data
var data = result.Data;

// Access raw response metadata
var statusCode = result.RawResponse.StatusCode;
var headers = result.RawResponse.Headers;
var url = result.RawResponse.Url;

// Access specific headers (case-insensitive)
if (headers.TryGetValue("X-Request-Id", out var requestId))
{
    Console.WriteLine($"Request ID: {requestId}");
}
```

### Additional Headers

If you would like to send additional headers as part of the request, use the `AdditionalHeaders` request option.

```csharp
var response = await client.Voices.SearchAsync(
    ...,
    new RequestOptions {
        AdditionalHeaders = new Dictionary<string, string?>
        {
            { "X-Custom-Header", "custom-value" }
        }
    }
);
```

### Additional Query Parameters

If you would like to send additional query parameters as part of the request, use the `AdditionalQueryParameters` request option.

```csharp
var response = await client.Voices.SearchAsync(
    ...,
    new RequestOptions {
        AdditionalQueryParameters = new Dictionary<string, string>
        {
            { "custom_param", "custom-value" }
        }
    }
);
```

### Forward Compatible Enums

This SDK uses forward-compatible enums that can handle unknown values gracefully.

```csharp
using ElevenLabs;

// Using a built-in value
var outputFormat = ConvertTextToSpeechRequestOutputFormat.Mp344100128;

// Using a custom value
var customOutputFormat = ConvertTextToSpeechRequestOutputFormat.FromCustom("custom-value");

// Using in a switch statement
switch (outputFormat.Value)
{
    case ConvertTextToSpeechRequestOutputFormat.Values.Mp344100128:
        Console.WriteLine("mp3_44100_128");
        break;
    default:
        Console.WriteLine($"Unknown value: {outputFormat.Value}");
        break;
}

// Explicit casting
string outputFormatString = (string)ConvertTextToSpeechRequestOutputFormat.Mp344100128;
ConvertTextToSpeechRequestOutputFormat outputFormatFromString = (ConvertTextToSpeechRequestOutputFormat)"mp3_44100_128";
```

## Languages Supported

Explore [all models & languages](https://elevenlabs.io/docs/models).

## Contributing

While we value open-source contributions to this SDK, this library is generated programmatically.
Additions made directly to this library would have to be moved over to our generation code,
otherwise they would be overwritten upon the next generated release. Feel free to open a PR as
a proof of concept, but know that we will not be able to merge it as-is. We suggest opening
an issue first to discuss with us!

On the other hand, contributions to the README are always very welcome!
