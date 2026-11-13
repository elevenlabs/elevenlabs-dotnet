using global::System.IO;
using global::System.Net.Http;
using global::System.Net.ServerSentEvents;
using global::System.Runtime.CompilerServices;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;

namespace ElevenLabs.Core;

/// <summary>
/// Provides SSE stream enumeration with transparent mid-stream reconnection. When a resumable stream
/// ends before its configured terminator and a last event id is available, this reconnects using the
/// <c>Last-Event-ID</c> header. Ported from Fern's <c>SseReconnectHelper</c>; yields the same
/// terminator-trimmed, discriminator-injected data payloads as <see cref="StreamUtils"/>.
/// </summary>
internal static class SseReconnectHelper
{
    private const int DefaultMaxReconnectAttempts = 5;
    private static readonly TimeSpan DefaultReconnectDelay = TimeSpan.FromSeconds(1);
    private static readonly TimeSpan MaxReconnectDelay = TimeSpan.FromSeconds(30);

    internal static async IAsyncEnumerable<string> EnumerateWithReconnectAsync(
        HttpResponseMessage initialResponse,
        Func<
            string,
            CancellationToken,
            global::System.Threading.Tasks.Task<HttpResponseMessage>
        > reconnectFn,
        int? maxReconnectAttempts,
        bool disableReconnection,
        string? streamTerminator,
        string? eventDiscriminator,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        var response = initialResponse;
        var maxAttempts = maxReconnectAttempts ?? DefaultMaxReconnectAttempts;
        var reconnectAttempts = 0;
        var isReconnectedResponse = false;
        // The last event id from the most recently *dispatched* (yielded) event, per the WHATWG spec:
        // committing an undispatched id would skip an event never delivered to the caller on reconnect.
        string? lastDispatchedEventId = null;
        Exception? lastReconnectException = null;

        while (true)
        {
#if NET5_0_OR_GREATER
            var stream = await response
                .Content.ReadAsStreamAsync(cancellationToken)
                .ConfigureAwait(false);
#else
            var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
#endif
            var parser = SseParser.Create(stream);
            var terminatorReached = false;
            var streamDropped = false;

            var enumerator = parser
                .EnumerateAsync(cancellationToken)
                .GetAsyncEnumerator(cancellationToken);
            try
            {
                while (true)
                {
                    bool hasNext;
                    try
                    {
                        hasNext = await enumerator.MoveNextAsync().ConfigureAwait(false);
                    }
                    catch (IOException)
                    {
                        streamDropped = true;
                        break;
                    }

                    if (!hasNext)
                        break;

                    var item = enumerator.Current;
                    if (string.IsNullOrEmpty(item.Data))
                        continue;

                    if (streamTerminator != null && item.Data == streamTerminator)
                    {
                        terminatorReached = true;
                        break;
                    }

                    yield return InjectEventDiscriminator(
                        item.Data,
                        item.EventType,
                        eventDiscriminator
                    );

                    if (!string.IsNullOrEmpty(parser.LastEventId))
                        lastDispatchedEventId = parser.LastEventId;
                    reconnectAttempts = 0; // reset on each successful dispatch
                }
            }
            finally
            {
                await enumerator.DisposeAsync().ConfigureAwait(false);
            }

            if (terminatorReached)
                yield break;

            // Without a terminator the client cannot distinguish "completed" from "dropped", so
            // reconnection is disabled — surface a drop, otherwise treat EOF as a clean end.
            if (
                disableReconnection
                || streamTerminator == null
                || string.IsNullOrEmpty(lastDispatchedEventId)
            )
            {
                if (streamDropped)
                {
                    throw new IOException(
                        "SSE stream connection lost and reconnection was not attempted."
                    );
                }
                yield break;
            }

            var delay =
                parser.ReconnectionInterval > TimeSpan.Zero
                    ? parser.ReconnectionInterval
                    : DefaultReconnectDelay;
            if (delay > MaxReconnectDelay)
                delay = MaxReconnectDelay;

            // Reconnect the connection itself, not the already-exhausted response, until one succeeds
            // or the attempt cap is hit. A failed attempt retries here rather than looping back to
            // re-read the dead response.
            HttpResponseMessage? newResponse = null;
            while (newResponse == null)
            {
                if (reconnectAttempts >= maxAttempts)
                {
                    throw new IOException(
                        "SSE stream connection lost and reconnection failed after exhausting all attempts.",
                        lastReconnectException
                    );
                }
                reconnectAttempts++;
                await global::System
                    .Threading.Tasks.Task.Delay(delay, cancellationToken)
                    .ConfigureAwait(false);
                try
                {
                    newResponse = await reconnectFn(lastDispatchedEventId!, cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex) when (!cancellationToken.IsCancellationRequested)
                {
                    lastReconnectException = ex;
                }
            }

            lastReconnectException = null;
            if (isReconnectedResponse)
                response.Dispose();
            response = newResponse;
            isReconnectedResponse = true;
        }
    }

    // Mirrors StreamUtils.InjectEventDiscriminator: merges the SSE `event:` name into a JSON-object
    // payload so a protocol-discriminated union dispatches on it. Kept local so this Core helper does
    // not take a namespace dependency on the Utils layer.
    private static string InjectEventDiscriminator(
        string data,
        string? eventType,
        string? discriminatorKey
    )
    {
        if (string.IsNullOrEmpty(discriminatorKey) || string.IsNullOrEmpty(eventType))
            return data;

        JsonObject? obj;
        try
        {
            obj = JsonNode.Parse(data) as JsonObject;
        }
        catch (JsonException)
        {
            return data;
        }

        if (obj == null || obj.ContainsKey(discriminatorKey!))
            return data;

        obj[discriminatorKey!] = eventType;
        return obj.ToJsonString();
    }
}
