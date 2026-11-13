using global::System;
using global::System.Collections.Generic;
using global::System.Net.Http;
using global::System.Threading;
using global::System.Threading.Tasks;

namespace ElevenLabs.Core;

/// <summary>
/// Adapts a legacy <c>Task&lt;T&gt;</c> (or <c>Task</c>) from the internal HTTP runtime into the
/// Fern-shape <c>WithRawResponse&lt;T&gt;</c> / <c>RawResponse</c> envelope, so the public
/// <c>{Group}Client</c> surface returns <c>WithRawResponseTask&lt;T&gt;</c> while delegating execution
/// to the proven legacy runtime.
///
/// The legacy runtime deserializes and discards the <c>HttpResponseMessage</c>, so the real success
/// response is threaded out-of-band (FSM-189): each <c>Wrap*</c> installs an ambient <see cref="Capture"/>
/// before invoking the delegated call, the base service's <c>ExecuteAsync</c> records the live response
/// into it via <see cref="Record"/>, and its status/headers become the <c>RawResponse</c> — the same
/// shape the error path builds from a failed response (FSM-568), via the shared
/// <see cref="RawResponseFactory"/>. The delegated call is passed as a factory so the ambient is
/// installed before it starts running.
/// </summary>
internal static class WithRawResponseAdapter
{
    /// <summary>
    /// Mutable sink shared down the async call chain: the live success response threaded OUT of the
    /// legacy runtime (FSM-189) and the per-call <see cref="ElevenLabs.RequestOptions"/> threaded
    /// IN to it (FSM-190).
    /// </summary>
    internal sealed class Capture
    {
        public HttpResponseMessage? Response;
        public ElevenLabs.RequestOptions? Options;
    }

    private static readonly AsyncLocal<Capture?> Current = new();

    /// <summary>
    /// The per-call request options for the fern call currently in flight, or null when the call did not
    /// originate from a fern client. Read by the base service to apply the per-call escape hatches
    /// (additional headers / query / body) to the outgoing request (FSM-190).
    /// </summary>
    public static ElevenLabs.RequestOptions? CurrentRequestOptions => Current.Value?.Options;

    /// <summary>
    /// Records the live success response into the ambient capture, if one is active. Called by the base
    /// service after the transport returns; a no-op when the call did not originate from a fern client.
    /// </summary>
    public static void Record(HttpResponseMessage response)
    {
        var capture = Current.Value;
        if (capture is not null)
        {
            capture.Response = response;
        }
    }

    public static async Task<WithRawResponse<T>> Wrap<T>(
        ElevenLabs.RequestOptions? options,
        Func<Task<T>> call
    )
    {
        using var scope = CaptureScope.Install(options);
        var data = await call().ConfigureAwait(false);
        return new WithRawResponse<T> { Data = data, RawResponse = scope.ToRawResponse() };
    }

    /// <summary>
    /// Bridges a legacy <c>Task&lt;List&lt;T&gt;&gt;</c> to Fern's covariant <c>IEnumerable&lt;T&gt;</c>
    /// return: <c>Task&lt;List&lt;T&gt;&gt;</c> is invariant to <c>Task&lt;WithRawResponse&lt;IEnumerable&lt;T&gt;&gt;&gt;</c>,
    /// so the widening happens here at the boundary (the legacy runtime keeps using <c>List&lt;T&gt;</c>).
    /// </summary>
    public static async Task<WithRawResponse<IEnumerable<T>>> WrapEnumerable<T>(
        ElevenLabs.RequestOptions? options,
        Func<Task<List<T>>> call
    )
    {
        using var scope = CaptureScope.Install(options);
        var data = await call().ConfigureAwait(false);
        return new WithRawResponse<IEnumerable<T>>
        {
            Data = data,
            RawResponse = scope.ToRawResponse(),
        };
    }

    /// <summary>
    /// Bridges a legacy binary download (<c>Task&lt;Stream&gt;</c>) to Fern's closeable
    /// <c>WithRawResponse&lt;Stream&gt;</c> return (FSDK-1859). The legacy runtime returns the live
    /// response body as soon as the headers arrive, so the first bytes are readable while the server is
    /// still sending; the stream owns the response and disposes it at the end of the body or on
    /// <c>Dispose</c>. The status and headers are captured here, before the caller reads anything.
    /// </summary>
    public static async Task<WithRawResponse<global::System.IO.Stream>> WrapStream(
        ElevenLabs.RequestOptions? options,
        Func<Task<global::System.IO.Stream>> call
    )
    {
        using var scope = CaptureScope.Install(options);
        var data = await call().ConfigureAwait(false);
        return new WithRawResponse<global::System.IO.Stream>
        {
            Data = data,
            RawResponse = scope.ToRawResponse(),
        };
    }

    /// <summary>
    /// Runs a delegated streaming call with the per-call <see cref="ElevenLabs.RequestOptions"/>
    /// installed as the ambient options, so the eager stream method reads them before its first await.
    /// </summary>
    public static TResult WithOptions<TResult>(
        ElevenLabs.RequestOptions? options,
        Func<TResult> call
    )
    {
        using var scope = CaptureScope.Install(options);
        return call();
    }

    public static async Task<ElevenLabs.RawResponse> WrapVoid(
        ElevenLabs.RequestOptions? options,
        Func<global::System.Threading.Tasks.Task> call
    )
    {
        using var scope = CaptureScope.Install(options);
        await call().ConfigureAwait(false);
        return scope.ToRawResponse();
    }

    /// <summary>
    /// Installs the ambient <see cref="Capture"/> for the duration of one delegated call and restores the
    /// previous value on dispose. Shared by all <c>Wrap*</c> so the AsyncLocal save/restore lives in one
    /// place; each caller only expresses its differing await/return shape.
    /// </summary>
    private readonly struct CaptureScope : IDisposable
    {
        private readonly Capture? _previous;
        private readonly Capture _capture;

        private CaptureScope(Capture? previous, Capture capture)
        {
            _previous = previous;
            _capture = capture;
        }

        public static CaptureScope Install(ElevenLabs.RequestOptions? options)
        {
            var previous = Current.Value;
            var capture = new Capture { Options = options };
            Current.Value = capture;
            return new CaptureScope(previous, capture);
        }

        // A success result always has a live response (the delegated method reaches the transport, which
        // Records it); a null capture means the call short-circuited without HTTP — fail loud rather than
        // fabricate a misleading status, matching Fern (which never builds a RawResponse without one).
        public ElevenLabs.RawResponse ToRawResponse() =>
            _capture.Response is null
                ? throw new InvalidOperationException(
                    "No HTTP response was captured for the fern client call; the delegated method did not reach the transport."
                )
                : RawResponseFactory.FromHttpResponseMessage(_capture.Response);

        public void Dispose() => Current.Value = _previous;
    }
}
