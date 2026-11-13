using System.Text.Json;
using ElevenLabs.Config;
using ElevenLabs.Http;
using ElevenLabs.Http.Exceptions;
using ElevenLabs.Http.Extensions;
using ElevenLabs.Json;
using ElevenLabs.Utils;

namespace ElevenLabs.Services;

/// <summary>
/// Base service class providing core HTTP request execution and JSON serialization for all service endpoints.
/// </summary>
internal class BaseService
{
    /// <summary>
    /// Constant representing the absence of a specific HTTP status code, used for default error mappings.
    /// </summary>
    protected const int NoStatusCode = 0;

    protected readonly Client _httpClient;
    protected readonly JsonSerializerOptions _jsonSerializerOptions;
    private RequestConfig? _serviceConfig;

    public BaseService(Client httpClient)
    {
        _httpClient = httpClient;
        _jsonSerializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web)
        {
            Converters =
            {
                new global::ElevenLabs.Core.OneOfSerializer(),
                new DateTimeSerializer(),
            },
        };
        _jsonSerializerOptions.PropertyNameCaseInsensitive = false;
        _jsonSerializerOptions.DefaultIgnoreCondition = global::System
            .Text
            .Json
            .Serialization
            .JsonIgnoreCondition
            .WhenWritingNull;
        _jsonSerializerOptions.Converters.Add(
            new global::ElevenLabs.Core.OptionalJsonConverterFactory()
        );
        _jsonSerializerOptions.TypeInfoResolver =
            new global::System.Text.Json.Serialization.Metadata.DefaultJsonTypeInfoResolver
            {
                Modifiers =
                {
                    global::ElevenLabs.Core.JsonOptions.NullableOptionalModifier,
                    global::ElevenLabs.Core.JsonOptions.JsonAccessAndIgnoreModifier,
                    global::ElevenLabs.Core.JsonOptions.HandleExtensionDataFields,
                },
            };
    }

    /// <summary>
    /// Sets service-level configuration that applies to all methods in this service.
    /// Service-level config is overridden by method-level and request-level config.
    /// </summary>
    public BaseService SetConfig(RequestConfig config)
    {
        _serviceConfig = config;
        return this;
    }

    /// <summary>
    /// Resolves configuration by merging service, method, and request configs.
    /// Priority order (highest to lowest): request config > method config > service config > SDK config.
    /// </summary>
    protected RequestConfig? GetResolvedConfig(
        RequestConfig? methodConfig,
        RequestConfig? requestConfig
    )
    {
        if (_serviceConfig == null && methodConfig == null && requestConfig == null)
        {
            return null;
        }

        return new RequestConfig(
            BaseUrl: requestConfig?.BaseUrl ?? methodConfig?.BaseUrl ?? _serviceConfig?.BaseUrl,
            Environment: requestConfig?.Environment
                ?? methodConfig?.Environment
                ?? _serviceConfig?.Environment,
            Timeout: requestConfig?.Timeout ?? methodConfig?.Timeout ?? _serviceConfig?.Timeout,
            RetryConfig: requestConfig?.RetryConfig
                ?? methodConfig?.RetryConfig
                ?? _serviceConfig?.RetryConfig,
            IdempotencyKey: requestConfig?.IdempotencyKey
                ?? methodConfig?.IdempotencyKey
                ?? _serviceConfig?.IdempotencyKey
        );
    }

    /// <summary>
    /// Executes an HTTP request, applying any per-request configuration overrides.
    /// </summary>
    /// <param name="request">The HTTP request message to send.</param>
    /// <param name="resolvedConfig">Optional resolved configuration with per-request overrides.</param>
    /// <param name="cancellationToken">Optional cancellation token to cancel the operation.</param>
    /// <returns>The HTTP response message if the request succeeds.</returns>
    protected async Task<HttpResponseMessage> ExecuteAsync(
        Request request,
        RequestConfig? resolvedConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        CancellationTokenSource? timeoutCts = null;
        TimeSpan? appliedTimeout = null;
        // Kept before `cancellationToken` is replaced by the linked timeout token below: the linked
        // source cancels for either reason and records neither, so this is the only thing that keeps
        // a timeout distinguishable from the caller cancelling (FSDK-1585).
        var callerToken = cancellationToken;

        try
        {
            resolvedConfig = global::ElevenLabs.Core.RequestOptionsMerger.MergeConfig(
                resolvedConfig,
                global::ElevenLabs.Core.WithRawResponseAdapter.CurrentRequestOptions
            );
            if (resolvedConfig?.Timeout != null)
            {
                appliedTimeout = resolvedConfig.Timeout.Value;
                timeoutCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
                timeoutCts.CancelAfter(resolvedConfig.Timeout.Value);
                cancellationToken = timeoutCts.Token;
            }

            ApplyRequestConfigOverrides(request, resolvedConfig);
            await global::ElevenLabs
                .Core.RequestOptionsMerger.ApplyAsync(
                    request.HttpRequestMessage,
                    global::ElevenLabs.Core.WithRawResponseAdapter.CurrentRequestOptions,
                    cancellationToken
                )
                .ConfigureAwait(false);

            var response = await _httpClient
                .SendAsync(request, cancellationToken)
                .ConfigureAwait(false);
            global::ElevenLabs.Core.WithRawResponseAdapter.Record(response);
            return response;
        }
        catch (OperationCanceledException ex) when (IsRequestTimeout(timeoutCts, callerToken))
        {
            throw new ApiTimeoutException($"The request timed out after {appliedTimeout}.", ex);
        }
        finally
        {
            // Safe to dispose here: SendAsync has completed and the response body
            // is buffered by the time we return. Streaming requests use a separate
            // ExecuteStreamAsync path and are not affected.
            timeoutCts?.Dispose();
        }
    }

    /// <summary>
    /// Executes a request whose success response is a binary download. Returns as soon as the response
    /// headers arrive and leaves the body unread, so the caller can stream it while the server is still
    /// sending. The response is handed to the caller, who must dispose it (<c>ResponseBodyStream</c> does
    /// so when its stream is disposed or read to the end). A non-success status throws the typed
    /// exception before any body is exposed, and the error factory disposes that response.
    /// </summary>
    /// <remarks>
    /// The configured Timeout bounds the wait for the response headers only: the body is read lazily under
    /// the caller's own token, so a per-call timeout cannot cut a download that is still arriving. The
    /// request is tagged so the client transport returns at the headers for this call alone; it buffers a
    /// non-success body under the same token, so an error body stays bound by the per-call Timeout, the
    /// HttpClient.Timeout and the caller's token like every other call's.
    /// </remarks>
    protected async Task<HttpResponseMessage> ExecuteDownloadAsync(
        Request request,
        RequestConfig? resolvedConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        CancellationTokenSource? timeoutCts = null;
        TimeSpan? appliedTimeout = null;
        var callerToken = cancellationToken;

        try
        {
            resolvedConfig = global::ElevenLabs.Core.RequestOptionsMerger.MergeConfig(
                resolvedConfig,
                global::ElevenLabs.Core.WithRawResponseAdapter.CurrentRequestOptions
            );
            if (resolvedConfig?.Timeout != null)
            {
                appliedTimeout = resolvedConfig.Timeout.Value;
                timeoutCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
                timeoutCts.CancelAfter(resolvedConfig.Timeout.Value);
                cancellationToken = timeoutCts.Token;
            }

            ApplyRequestConfigOverrides(request, resolvedConfig);
            await global::ElevenLabs
                .Core.RequestOptionsMerger.ApplyAsync(
                    request.HttpRequestMessage,
                    global::ElevenLabs.Core.WithRawResponseAdapter.CurrentRequestOptions,
                    cancellationToken
                )
                .ConfigureAwait(false);

#if NET5_0_OR_GREATER
            request.HttpRequestMessage.Options.Set(
                new HttpRequestOptionsKey<bool>("_Request_HeadersOnly"),
                true
            );
#else
            request.HttpRequestMessage.Properties["_Request_HeadersOnly"] = true;
#endif

            var response = await _httpClient
                .SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
                .ConfigureAwait(false);
            global::ElevenLabs.Core.WithRawResponseAdapter.Record(response);
            return response;
        }
        catch (OperationCanceledException ex) when (IsRequestTimeout(timeoutCts, callerToken))
        {
            throw new ApiTimeoutException($"The request timed out after {appliedTimeout}.", ex);
        }
        finally
        {
            timeoutCts?.Dispose();
        }
    }

    /// <summary>
    /// Whether an <see cref="OperationCanceledException"/> came from the per-request timeout rather
    /// than from the caller. The BCL raises <see cref="TaskCanceledException"/> for both and the
    /// linked <see cref="CancellationTokenSource"/> records neither cause, so the test is: the
    /// timeout source fired AND the caller's own token did not. When both fire the caller wins and
    /// the original cancellation propagates untouched (FSDK-1585).
    /// </summary>
    private static bool IsRequestTimeout(
        CancellationTokenSource? timeoutCts,
        CancellationToken callerToken
    )
    {
        return timeoutCts is not null
            && timeoutCts.IsCancellationRequested
            && !callerToken.IsCancellationRequested;
    }

    /// <summary>
    /// Applies BaseUrl and authentication overrides from the resolved config to the outgoing request.
    /// BaseUrl is applied by rewriting the request URI; auth overrides are passed via request options
    /// so that the delegating handlers in the pipeline can apply them instead of their stored credentials.
    /// </summary>
    private static void ApplyRequestConfigOverrides(Request request, RequestConfig? resolvedConfig)
    {
        if (resolvedConfig == null)
            return;

        if (resolvedConfig.BaseUrl != null)
        {
            var baseUri = new Uri(resolvedConfig.BaseUrl.TrimEnd('/') + "/");
            request.HttpRequestMessage.RequestUri = new Uri(baseUri, request.Url);
        }

        if (resolvedConfig.RetryConfig != null)
        {
#if NET5_0_OR_GREATER
            request.HttpRequestMessage.Options.Set(
                new HttpRequestOptionsKey<RetryConfig>("_RequestConfig_RetryConfig"),
                resolvedConfig.RetryConfig
            );
#else
            request.HttpRequestMessage.Properties["_RequestConfig_RetryConfig"] =
                resolvedConfig.RetryConfig;
#endif
        }

        // Carried as a request option rather than written straight onto the headers here, because
        // the header NAME comes from the spec's declared idempotency header and RetryHandler is
        // where that list lives. RetryHandler stamps it onto the request before the retry gate
        // reads it, which is still upstream of the transport, so the server sees it (FSDK-1712).
        if (!string.IsNullOrWhiteSpace(resolvedConfig.IdempotencyKey))
        {
#if NET5_0_OR_GREATER
            request.HttpRequestMessage.Options.Set(
                new HttpRequestOptionsKey<string>("_RequestConfig_IdempotencyKey"),
                resolvedConfig.IdempotencyKey
            );
#else
            request.HttpRequestMessage.Properties["_RequestConfig_IdempotencyKey"] =
                resolvedConfig.IdempotencyKey;
#endif
        }
    }

    /// <summary>
    /// Executes a streaming HTTP request using Server-Sent Events (SSE) protocol.
    /// Streams JSON objects line-by-line and deserializes each into type T.
    /// Invalid JSON lines are automatically skipped.
    /// </summary>
    /// <typeparam name="T">The type to deserialize each streamed JSON line into.</typeparam>
    /// <param name="request">The HTTP request to execute.</param>
    /// <param name="cancellationToken">Cancellation token for the streaming operation.</param>
    /// <returns>An async enumerable of deserialized objects from the stream.</returns>
    protected async IAsyncEnumerable<T> ExecuteStreamAsync<T>(
        Request request,
        RequestConfig? resolvedConfig = null,
        string? streamTerminator = null,
        string? eventDiscriminator = null,
        [System.Runtime.CompilerServices.EnumeratorCancellation]
            CancellationToken cancellationToken = default
    )
    {
        CancellationTokenSource? timeoutCts = null;
        TimeSpan? appliedTimeout = null;
        // See ExecuteAsync: the caller's token is kept so a timeout stays distinguishable from a
        // caller-initiated cancellation (FSDK-1585).
        var callerToken = cancellationToken;
        try
        {
            if (resolvedConfig?.Timeout != null)
            {
                appliedTimeout = resolvedConfig.Timeout.Value;
                timeoutCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
                timeoutCts.CancelAfter(resolvedConfig.Timeout.Value);
                cancellationToken = timeoutCts.Token;
            }

            ApplyRequestConfigOverrides(request, resolvedConfig);

            // The send is wrapped on its own rather than the whole method body: an iterator cannot
            // `yield return` from inside a try that has a catch clause.
            HttpResponseMessage response;
            try
            {
                response = await _httpClient
                    .SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (OperationCanceledException ex) when (IsRequestTimeout(timeoutCts, callerToken))
            {
                throw new ApiTimeoutException($"The request timed out after {appliedTimeout}.", ex);
            }

            await response.EnsureSuccessfulResponseAsync().ConfigureAwait(false);

            await foreach (
                var line in StreamUtils.StreamResponseDataAsync(
                    response,
                    true,
                    streamTerminator,
                    eventDiscriminator,
                    cancellationToken
                )
            )
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                // Fail loud: a malformed streamed event surfaces as an exception instead of
                // being silently skipped.
                T? item;
                try
                {
                    item = JsonSerializer.Deserialize<T>(line, _jsonSerializerOptions);
                }
                catch (JsonException ex)
                {
                    throw new ElevenLabs.ElevenLabsClientException(
                        $"Failed to deserialize streamed event into {typeof(T).Name}.",
                        ex
                    );
                }

                if (item != null)
                {
                    yield return item;
                }
            }
        }
        finally
        {
            timeoutCts?.Dispose();
        }
    }

    /// <summary>
    /// Executes a streaming request and returns the parsed stream alongside the raw HTTP response
    /// metadata (status, url, headers) captured once the response headers arrive.
    /// </summary>
    protected async global::System.Threading.Tasks.Task<global::ElevenLabs.WithRawResponse<global::System.Collections.Generic.IAsyncEnumerable<T>>> ExecuteStreamWithRawResponseAsync<T>(
        Request request,
        // Required and ahead of the optional parameters, deliberately. A default would mean a call
        // site that forgets this silently gets SSE framing -- the very failure this parameter
        // exists to stop. Placed here rather than appended because C# requires optional parameters
        // last, and because it makes any stale positional call a compile error instead of binding
        // the terminator string to a bool.
        bool isSse,
        // Required for the same reason as `isSse`: a default would let a call site that forgets it
        // quietly JSON-decode an untyped payload, the failure this flag exists to stop. C# requires
        // optional parameters last, so both flags sit ahead of `resolvedConfig`.
        bool rawText,
        RequestConfig? resolvedConfig = null,
        string? streamTerminator = null,
        string? eventDiscriminator = null,
        bool resumable = false,
        CancellationToken cancellationToken = default
    )
    {
        // The configured Timeout bounds header retrieval only, not the stream body: an SSE stream is
        // long-lived by design, so a per-call timeout must not abort a live stream mid-body. The body
        // is read lazily under the caller's token (this matches the HttpCompletionOption.ResponseHeadersRead
        // model, unlike the unary/legacy path where the timeout spans the whole call).
        var requestOptions = global::ElevenLabs.Core.WithRawResponseAdapter.CurrentRequestOptions;
        resolvedConfig = global::ElevenLabs.Core.RequestOptionsMerger.MergeConfig(
            resolvedConfig,
            requestOptions
        );
        var callerToken = cancellationToken;
        CancellationTokenSource? timeoutCts = null;
        TimeSpan? appliedTimeout = null;
        if (resolvedConfig?.Timeout != null)
        {
            appliedTimeout = resolvedConfig.Timeout.Value;
            timeoutCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            timeoutCts.CancelAfter(resolvedConfig.Timeout.Value);
        }

        ApplyRequestConfigOverrides(request, resolvedConfig);
        await global::ElevenLabs
            .Core.RequestOptionsMerger.ApplyAsync(
                request.HttpRequestMessage,
                requestOptions,
                cancellationToken
            )
            .ConfigureAwait(false);
        MarkHeadersOnly(request.HttpRequestMessage);

        HttpResponseMessage response;
        try
        {
            response = await _httpClient
                .SendAsync(
                    request,
                    HttpCompletionOption.ResponseHeadersRead,
                    timeoutCts?.Token ?? cancellationToken
                )
                .ConfigureAwait(false);
        }
        catch (OperationCanceledException ex) when (IsRequestTimeout(timeoutCts, callerToken))
        {
            timeoutCts?.Dispose();
            throw new ApiTimeoutException($"The request timed out after {appliedTimeout}.", ex);
        }
        timeoutCts?.Dispose();

        await response.EnsureSuccessfulResponseAsync().ConfigureAwait(false);

        return new global::ElevenLabs.WithRawResponse<global::System.Collections.Generic.IAsyncEnumerable<T>>
        {
            Data = ReadStreamAsync(),
            RawResponse = global::ElevenLabs.Core.RawResponseFactory.FromHttpResponseMessage(
                response
            ),
        };

        static void MarkHeadersOnly(HttpRequestMessage message)
        {
#if NET5_0_OR_GREATER
            message.Options.Set(new HttpRequestOptionsKey<bool>("_Request_HeadersOnly"), true);
#else
            message.Properties["_Request_HeadersOnly"] = true;
#endif
        }

        async global::System.Threading.Tasks.Task<HttpResponseMessage> ReconnectAsync(
            string lastEventId,
            CancellationToken ct
        )
        {
            var clone = await global::ElevenLabs
                .Core.RetryableRequestContent.CloneWithBufferedContentAsync(
                    request.HttpRequestMessage,
                    ct
                )
                .ConfigureAwait(false);
            MarkHeadersOnly(clone);
            clone.Headers.Remove("Last-Event-ID");
            clone.Headers.TryAddWithoutValidation("Last-Event-ID", lastEventId);
            var reconnectRequest = request with { HttpRequestMessage = clone };
            return await _httpClient
                .SendAsync(reconnectRequest, HttpCompletionOption.ResponseHeadersRead, ct)
                .ConfigureAwait(false);
        }

        async global::System.Collections.Generic.IAsyncEnumerable<T> ReadStreamAsync(
            [System.Runtime.CompilerServices.EnumeratorCancellation]
                CancellationToken streamToken = default
        )
        {
            // A resumable SSE stream reconnects transparently on a mid-stream drop (Last-Event-ID);
            // otherwise the response is parsed once by StreamUtils.
            var lines = resumable
                ? global::ElevenLabs.Core.SseReconnectHelper.EnumerateWithReconnectAsync(
                    response,
                    ReconnectAsync,
                    null,
                    false,
                    streamTerminator,
                    eventDiscriminator,
                    streamToken
                )
                : StreamUtils.StreamResponseDataAsync(
                    response,
                    isSse,
                    streamTerminator,
                    eventDiscriminator,
                    streamToken
                );
            await foreach (var line in lines.ConfigureAwait(false))
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                T? item;
                // An untyped (`type: string`) payload is handed over verbatim. The spec does not
                // say what is inside `data:`, so deserializing it into a string throws on the JSON
                // object a real server sends and on bare text, and quietly unquotes a JSON string
                // literal. The cast goes through `object` because T is only `string` by
                // construction when rawText is set.
                if (rawText)
                {
                    yield return (T)(object)line;
                    continue;
                }

                try
                {
                    item = JsonSerializer.Deserialize<T>(line, _jsonSerializerOptions);
                }
                catch (JsonException ex)
                {
                    throw new ElevenLabs.ElevenLabsClientException(
                        $"Failed to deserialize streamed event into {typeof(T).Name}.",
                        ex
                    );
                }

                if (item != null)
                {
                    yield return item;
                }
            }
        }
    }
}
