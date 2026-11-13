using ElevenLabs.Config;
using ElevenLabs.Http;
using ElevenLabs.Http.Extensions;
using ElevenLabs.Http.Handlers;
using ElevenLabs.Services;

namespace ElevenLabs;

public partial class ElevenLabsClient : IElevenLabsClient
{
    private readonly Client _httpClient;

    public IHistoryClient History { get; }
    public ITextToSoundEffectsClient TextToSoundEffects { get; }
    public IAudioIsolationClient AudioIsolation { get; }
    public IAudioEffectsClient AudioEffects { get; }
    public ElevenLabs.ISamplesClient Samples { get; }
    public IVoicesClient Voices { get; }
    public IDubbingClient Dubbing { get; }
    public IAgentsClient Agents { get; }
    public ElevenLabs.ITextToSpeechClient TextToSpeech { get; }
    public IFlowsClient Flows { get; }
    public ITextToDialogueClient TextToDialogue { get; }
    public ISpeechToSpeechClient SpeechToSpeech { get; }
    public ITextToVoiceClient TextToVoice { get; }
    public IUserClient User { get; }
    public IStudioClient Studio { get; }
    public ElevenLabs.IPronunciationDictionariesClient PronunciationDictionaries { get; }
    public ISpeechToTextClient SpeechToText { get; }
    public IModelsClient Models { get; }
    public IAudioNativeClient AudioNative { get; }
    public IWorkspacesClient Workspaces { get; }
    public IServiceAccountsClient ServiceAccounts { get; }
    public IWorkspaceClient Workspace { get; }
    public IWebhooksClient Webhooks { get; }
    public IMusicClient Music { get; }
    public ITokensClient Tokens { get; }
    public IForcedAlignmentClient ForcedAlignment { get; }
    public ISpeechEngineClient SpeechEngine { get; }
    public IEnvironmentVariablesClient EnvironmentVariables { get; }
    public IEnvironmentsClient Environments { get; }
    public IProductionsClient Productions { get; }
    public IAssetsClient Assets { get; }

    public ElevenLabsClient(string? apiKey = null, ClientOptions? clientOptions = null)
    {
        apiKey ??= clientOptions?.ApiKey;
        apiKey ??= global::System.Environment.GetEnvironmentVariable("ELEVENLABS_API_KEY");
        clientOptions ??= new ClientOptions();
        var defaultHeaders = global::System.Linq.Enumerable.ToList(
            clientOptions.AdditionalHeaders
                ?? global::System.Array.Empty<global::System.Collections.Generic.KeyValuePair<
                    string,
                    string?
                >>()
        );
        if (
            !global::System.Linq.Enumerable.Any(
                defaultHeaders,
                header =>
                    header.Value is not null
                    && global::System.StringComparer.OrdinalIgnoreCase.Equals(
                        header.Key,
                        "xi-api-key"
                    )
            )
        )
        {
            defaultHeaders.Add(
                new global::System.Collections.Generic.KeyValuePair<string, string?>(
                    "xi-api-key",
                    apiKey
                )
            );
        }
        ElevenlabsApiConfig? config = null;
        HttpMessageHandler handler = new ClientOptionsTransport(clientOptions.HttpClient);

        var retryHandler = new RetryHandler(handler, clientOptions.MaxRetries);
        _httpClient = new Client(
            config,
            retryHandler,
            disposeHandler: false,
            defaultHeaders: defaultHeaders
        );
        _httpClient.SetBaseAddress(
            new global::System.Uri(clientOptions.BaseUrl).EnsureTrailingSlash()
        );
        _httpClient.SetTimeout(clientOptions.Timeout);

        History = new HistoryClient(_httpClient);
        TextToSoundEffects = new TextToSoundEffectsClient(_httpClient);
        AudioIsolation = new AudioIsolationClient(_httpClient);
        AudioEffects = new AudioEffectsClient(_httpClient);
        Samples = new ElevenLabs.SamplesClient(_httpClient);
        Voices = new VoicesClient(_httpClient);
        Dubbing = new DubbingClient(_httpClient);
        Agents = new AgentsClient(_httpClient);
        TextToSpeech = new ElevenLabs.TextToSpeechClient(_httpClient);
        Flows = new FlowsClient(_httpClient);
        TextToDialogue = new TextToDialogueClient(_httpClient);
        SpeechToSpeech = new SpeechToSpeechClient(_httpClient);
        TextToVoice = new TextToVoiceClient(_httpClient);
        User = new UserClient(_httpClient);
        Studio = new StudioClient(_httpClient);
        PronunciationDictionaries = new ElevenLabs.PronunciationDictionariesClient(_httpClient);
        SpeechToText = new SpeechToTextClient(_httpClient);
        Models = new ModelsClient(_httpClient);
        AudioNative = new AudioNativeClient(_httpClient);
        Workspaces = new WorkspacesClient(_httpClient);
        ServiceAccounts = new ServiceAccountsClient(_httpClient);
        Workspace = new WorkspaceClient(_httpClient);
        Webhooks = new WebhooksClient(_httpClient);
        Music = new MusicClient(_httpClient);
        Tokens = new TokensClient(_httpClient);
        ForcedAlignment = new ForcedAlignmentClient(_httpClient);
        SpeechEngine = new SpeechEngineClient(_httpClient);
        EnvironmentVariables = new EnvironmentVariablesClient(_httpClient);
        Environments = new EnvironmentsClient(_httpClient);
        Productions = new ProductionsClient(_httpClient);
        Assets = new AssetsClient(_httpClient);
    }

    public ITextToDialogueApi CreateTextToDialogueApi()
    {
        return new TextToDialogueApi(
            new TextToDialogueApi.Options { BaseUrl = _httpClient.WebSocketBaseUrl },
            _httpClient.DefaultHeaders,
            _httpClient.HandshakeCredentials
        );
    }

    public ITextToDialogueApi CreateTextToDialogueApi(TextToDialogueApi.Options options)
    {
        if (string.IsNullOrWhiteSpace(options.BaseUrl))
        {
            options.BaseUrl = _httpClient.WebSocketBaseUrl;
        }
        return new TextToDialogueApi(
            options,
            _httpClient.DefaultHeaders,
            _httpClient.HandshakeCredentials
        );
    }

    public ITextToDialogueMultiContextApi CreateTextToDialogueMultiContextApi()
    {
        return new TextToDialogueMultiContextApi(
            new TextToDialogueMultiContextApi.Options { BaseUrl = _httpClient.WebSocketBaseUrl },
            _httpClient.DefaultHeaders,
            _httpClient.HandshakeCredentials
        );
    }

    public ITextToDialogueMultiContextApi CreateTextToDialogueMultiContextApi(
        TextToDialogueMultiContextApi.Options options
    )
    {
        if (string.IsNullOrWhiteSpace(options.BaseUrl))
        {
            options.BaseUrl = _httpClient.WebSocketBaseUrl;
        }
        return new TextToDialogueMultiContextApi(
            options,
            _httpClient.DefaultHeaders,
            _httpClient.HandshakeCredentials
        );
    }

    public ISpeechEngineApi CreateSpeechEngineApi()
    {
        return new SpeechEngineApi(
            new SpeechEngineApi.Options { BaseUrl = _httpClient.WebSocketBaseUrl },
            _httpClient.DefaultHeaders,
            _httpClient.HandshakeCredentials
        );
    }

    public ISpeechEngineApi CreateSpeechEngineApi(SpeechEngineApi.Options options)
    {
        if (string.IsNullOrWhiteSpace(options.BaseUrl))
        {
            options.BaseUrl = _httpClient.WebSocketBaseUrl;
        }
        return new SpeechEngineApi(
            options,
            _httpClient.DefaultHeaders,
            _httpClient.HandshakeCredentials
        );
    }

    public ISpeechToTextApi CreateSpeechToTextApi(SpeechToTextApi.Options options)
    {
        if (string.IsNullOrWhiteSpace(options.BaseUrl))
        {
            options.BaseUrl = _httpClient.WebSocketBaseUrl;
        }
        return new SpeechToTextApi(
            options,
            _httpClient.DefaultHeaders,
            _httpClient.HandshakeCredentials
        );
    }

    public ITextToSpeechApi CreateTextToSpeechApi(TextToSpeechApi.Options options)
    {
        if (string.IsNullOrWhiteSpace(options.BaseUrl))
        {
            options.BaseUrl = _httpClient.WebSocketBaseUrl;
        }
        return new TextToSpeechApi(
            options,
            _httpClient.DefaultHeaders,
            _httpClient.HandshakeCredentials
        );
    }

    public ITextToSpeechMultiContextApi CreateTextToSpeechMultiContextApi(
        TextToSpeechMultiContextApi.Options options
    )
    {
        if (string.IsNullOrWhiteSpace(options.BaseUrl))
        {
            options.BaseUrl = _httpClient.WebSocketBaseUrl;
        }
        return new TextToSpeechMultiContextApi(
            options,
            _httpClient.DefaultHeaders,
            _httpClient.HandshakeCredentials
        );
    }

    public ITranslationApi CreateTranslationApi(TranslationApi.Options options)
    {
        if (string.IsNullOrWhiteSpace(options.BaseUrl))
        {
            options.BaseUrl = _httpClient.WebSocketBaseUrl;
        }
        return new TranslationApi(
            options,
            _httpClient.DefaultHeaders,
            _httpClient.HandshakeCredentials
        );
    }

    public IDubbingApi CreateDubbingApi(DubbingApi.Options options)
    {
        if (string.IsNullOrWhiteSpace(options.BaseUrl))
        {
            options.BaseUrl = _httpClient.WebSocketBaseUrl;
        }
        return new DubbingApi(
            options,
            _httpClient.DefaultHeaders,
            _httpClient.HandshakeCredentials
        );
    }
}

/// <summary>
/// Bridges Fern's <c>ClientOptions.HttpClient</c> to the legacy delegating-handler transport chain.
/// Each request is dispatched on a fresh clone because the retry handler re-sends the same request
/// object, which the caller's <see cref="HttpClient"/> would otherwise reject as already-sent. This
/// is also the single per-attempt content-cloning site (FSM-1136): retryable content is
/// re-materialized into a fresh buffer on every send so a retried request re-sends its full body,
/// mirroring Fern's <c>RawClient.CloneRequestAsync</c>.
/// </summary>
internal sealed class ClientOptionsTransport : HttpMessageHandler
{
    private readonly HttpClient _inner;

    internal ClientOptionsTransport(HttpClient inner)
    {
        _inner = inner;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken
    )
    {
        HttpRequestMessage clone;
        if (Core.RetryableRequestContent.IsRetryable(request))
        {
            // Re-materialize retryable content into a fresh buffer per send so a retried attempt
            // re-sends the full body (the original stays re-readable; the sent clone is what the
            // caller's HttpClient consumes/disposes). Mirrors Fern's RawClient.CloneRequestAsync.
            clone = await Core
                .RetryableRequestContent.CloneWithBufferedContentAsync(request, cancellationToken)
                .ConfigureAwait(false);
        }
        else
        {
            // Non-retryable content (raw streams / multipart with stream parts) can't be re-read, so
            // reuse the original content object and forward it on a fresh envelope: streamed once,
            // never retried (RetryHandler skips the loop for it), preserving streaming semantics.
            clone = new HttpRequestMessage(request.Method, request.RequestUri)
            {
                Version = request.Version,
                Content = request.Content,
            };
            foreach (var header in request.Headers)
            {
                clone.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
        }

        if (IsHeadersOnlySend(request))
        {
            return await SendHeadersOnlyAsync(clone, cancellationToken).ConfigureAwait(false);
        }

        return await _inner.SendAsync(clone, cancellationToken).ConfigureAwait(false);
    }

    private static bool IsHeadersOnlySend(HttpRequestMessage request)
    {
#if NET5_0_OR_GREATER
        return request.Options.TryGetValue(
                new HttpRequestOptionsKey<bool>("_Request_HeadersOnly"),
                out var tagged
            ) && tagged;
#else
        return request.Properties.TryGetValue("_Request_HeadersOnly", out var tagged)
            && tagged is true;
#endif
    }

    // A binary download or a streaming call returns at the response headers so its body can be read
    // as it arrives. A non-success response is buffered here, under the token this send runs with and
    // within the caller's HttpClient.Timeout, so the layers above (retry, token refresh, hooks, the
    // error factory) see the same buffered error response they see on every other call, and a body
    // that stalls or resets surfaces as the timeout / connection exception of the call rather than
    // hanging or escaping raw.
    private async Task<HttpResponseMessage> SendHeadersOnlyAsync(
        HttpRequestMessage clone,
        CancellationToken cancellationToken
    )
    {
        var elapsed = global::System.Diagnostics.Stopwatch.StartNew();
        var response = await _inner
            .SendAsync(clone, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
            .ConfigureAwait(false);
        if (response.IsSuccessStatusCode)
        {
            return response;
        }

        try
        {
            using var bounded = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            if (_inner.Timeout != global::System.Threading.Timeout.InfiniteTimeSpan)
            {
                var remaining = _inner.Timeout - elapsed.Elapsed;
                bounded.CancelAfter(remaining > TimeSpan.Zero ? remaining : TimeSpan.Zero);
            }
#if NET5_0_OR_GREATER
            await response.Content.ReadAsByteArrayAsync(bounded.Token).ConfigureAwait(false);
#else
            var registration = bounded.Token.Register(response.Dispose);
            try
            {
                await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
            }
            catch (Exception) when (bounded.IsCancellationRequested)
            {
                throw new OperationCanceledException(bounded.Token);
            }
            finally
            {
                registration.Dispose();
            }

            if (bounded.IsCancellationRequested)
            {
                throw new OperationCanceledException(bounded.Token);
            }
#endif
        }
        catch
        {
            response.Dispose();
            throw;
        }

        return response;
    }
}

// c029837e0e474b76bc487506e8799df5e3335891efe4fb02bda7a1441840310c
