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
