using System.Net.ServerSentEvents;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace ElevenLabs.Utils;

/// <summary>
/// Utilities for streaming HTTP responses. Parses Server-Sent Events (SSE) with the
/// BCL <see cref="SseParser"/> (WHATWG event stream parsing: multi-line <c>data</c>
/// fields, blank-line event dispatch) and streams other content types line-by-line.
/// </summary>
public static class StreamUtils
{
    /// <summary>
    /// Streams an HTTP response body asynchronously.
    /// For Server-Sent Events (<c>text/event-stream</c>) it yields one string per event —
    /// the <c>data</c> field payload parsed by <see cref="SseParser"/>. For other content
    /// types it yields the body line-by-line. Supports cancellation via the provided token.
    /// </summary>
    /// <param name="response">The HTTP response to stream from.</param>
    /// <param name="streamTerminator">
    /// Spec-declared end-of-stream sentinel; when a <c>data</c> payload equals it the stream ends.
    /// <c>null</c> emits no terminator check (the stream ends at EOF), matching Fern.
    /// </param>
    /// <param name="eventDiscriminator">
    /// When set, the SSE <c>event:</c> name is injected into each JSON-object payload under this key
    /// before it is yielded, so a union discriminated on that field deserializes correctly.
    /// </param>
    /// <param name="cancellationToken">Cancellation token to stop streaming.</param>
    /// <returns>An async enumerable of event payloads (SSE) or lines (plain).</returns>
    public static async IAsyncEnumerable<string> StreamResponseDataAsync(
        HttpResponseMessage response,
        bool isSse,
        string? streamTerminator = null,
        string? eventDiscriminator = null,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
#if NET5_0_OR_GREATER
        using var stream = await response
            .Content.ReadAsStreamAsync(cancellationToken)
            .ConfigureAwait(false);
#else
        // The cancellable overload is .NET 5+; netstandard2.0 and net462 only have the no-arg form.
        using var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
#endif

        // The framing comes from the spec, through the generator, not from the response's
        // content-type header. Two reasons. The header was compared for exact equality, so
        // `text/event-stream; charset=utf-8` -- a legal labelling -- read as a plain line stream.
        // And a spec that declares `x-fern-streaming.format` was overruled by whatever the server
        // happened to label the response, even though the generated code's item type is already
        // fixed at generation time. TypeScript and Go take it from the spec for the same reason.
        if (!isSse)
        {
            // Plain streaming response: yield each line verbatim.
            using var reader = new StreamReader(stream);
            while (!cancellationToken.IsCancellationRequested)
            {
                var line = await reader.ReadLineAsync().ConfigureAwait(false);
                if (line == null)
                    yield break; // end of stream

                yield return line;
            }
            yield break;
        }

        // Server-Sent Events: SseParser handles WHATWG event stream parsing (multi-line
        // `data` join, one-space strip, comment lines, blank-line dispatch; a trailing
        // event not terminated by a blank line is incomplete and is discarded). We layer the
        // spec-driven concerns on top: skip empty-data events (dispatching "" would throw in
        // the deserializer), stop on the declared terminator (no check when none is declared —
        // matching Fern), and inject the SSE `event:` name into the payload when the stream is
        // protocol-discriminated.
        // Cancellation propagates here as OperationCanceledException (SseParser honors the token),
        // unlike the plain-text branch above which stops gracefully — deliberate, mirrors Fern.
        await foreach (
            var item in SseParser
                .Create(stream)
                .EnumerateAsync(cancellationToken)
                .ConfigureAwait(false)
        )
        {
            if (string.IsNullOrEmpty(item.Data))
                continue;

            if (streamTerminator != null && item.Data == streamTerminator)
                yield break;

            yield return InjectEventDiscriminator(item.Data, item.EventType, eventDiscriminator);
        }
    }

    /// <summary>
    /// Merges the SSE <c>event:</c> name into a JSON-object payload under <paramref name="discriminatorKey"/>
    /// so a protocol-discriminated union can dispatch on it. Returns the payload unchanged when there is
    /// no discriminator configured, no event name, the payload is not a JSON object, or the key is
    /// already present.
    /// </summary>
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
