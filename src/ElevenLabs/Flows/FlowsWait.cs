using global::System;
using global::System.Diagnostics;
using global::System.Net.Http.Headers;
using global::System.Threading;
using global::System.Threading.Tasks;
using ElevenLabs.Core;

namespace ElevenLabs.Flows;

// Hand-written (listed in .fernignore). The polling loop behind the CreateAndWaitAsync helpers on
// client.Flows.Image, .Video, .TextToSpeech and .Templates.Runs, matching create_and_wait in the
// Python SDK and createAndWait in the TypeScript SDK.

/// <summary>
/// Options for the <c>CreateAndWaitAsync</c> helpers on the Flows clients.
/// </summary>
public sealed record FlowsWaitOptions
{
    /// <summary>
    /// The shortest wait between status checks, and the wait used when the server sends no
    /// <c>Retry-After</c> header. Matches the server's shortest <c>Retry-After</c> (3 seconds for
    /// image, audio and text), so the SDK polls no faster than the server would pace it.
    /// </summary>
    public static readonly TimeSpan DefaultMinPollInterval = TimeSpan.FromSeconds(3);

    /// <summary>
    /// The smallest <see cref="MinPollInterval"/> accepted. Below this, a missing server hint would
    /// turn the wait into a tight loop of status checks.
    /// </summary>
    public static readonly TimeSpan SmallestMinPollInterval = TimeSpan.FromMilliseconds(500);

    /// <summary>
    /// How long to wait in total before throwing <see cref="FlowsWaitTimeoutException"/>, which
    /// carries the id so you can resume with <c>GetAsync</c>. <c>null</c> (the default) or
    /// <see cref="Timeout.InfiniteTimeSpan"/> waits indefinitely; otherwise it must be at least
    /// zero, and zero times out straight after the create call. Not to be confused with
    /// <see cref="RequestOptions.Timeout"/>, which limits each HTTP request.
    /// </summary>
    public TimeSpan? WaitTimeout { get; init; }

    /// <summary>
    /// The shortest wait between status checks, and the wait used when the server suggests none.
    /// Must be at least <see cref="SmallestMinPollInterval"/> (0.5 seconds). Defaults to
    /// <see cref="DefaultMinPollInterval"/> (3 seconds).
    /// </summary>
    public TimeSpan MinPollInterval { get; init; } = DefaultMinPollInterval;
}

/// <summary>
/// Thrown by <c>CreateAndWaitAsync</c> when a generation or template run is still unfinished after
/// <see cref="FlowsWaitOptions.WaitTimeout"/>.
/// </summary>
/// <remarks>
/// The work keeps running on the server. Resume waiting by calling <c>GetAsync</c> with
/// <see cref="Id"/> (and <see cref="TemplateId"/> for a template run), or let a webhook deliver
/// the result.
/// </remarks>
public sealed class FlowsWaitTimeoutException : ElevenLabsClientException
{
    internal FlowsWaitTimeoutException(
        string id,
        string? templateId,
        string status,
        object lastResponse,
        TimeSpan waitTimeout
    )
        : base(BuildMessage(id, templateId, status, waitTimeout))
    {
        Id = id;
        TemplateId = templateId;
        Status = status;
        LastResponse = lastResponse;
        WaitTimeout = waitTimeout;
    }

    /// <summary>The generation id, or the run id for a template run.</summary>
    public string Id { get; }

    /// <summary>The template id for a template run; <c>null</c> for a generation.</summary>
    public string? TemplateId { get; }

    /// <summary>The last status seen, such as <c>pending</c> or <c>generating</c>.</summary>
    public string Status { get; }

    /// <summary>
    /// The last response seen: the create response (<see cref="MediaGenerationCreateResponse"/>
    /// or <see cref="TemplateRunResponse"/>) if no status check ran, otherwise the last
    /// <see cref="MediaGenerationResponse"/> or <see cref="TemplateRunResponse"/>.
    /// </summary>
    public object LastResponse { get; }

    /// <summary>The wait timeout that ran out.</summary>
    public TimeSpan WaitTimeout { get; }

    private static string BuildMessage(
        string id,
        string? templateId,
        string status,
        TimeSpan waitTimeout
    )
    {
        var after = FormatSeconds(waitTimeout);
        return templateId is null
            ? $"Generation {id} is still {status} after {after}; call GetAsync with this id to keep waiting"
            : $"Template run {id} of template {templateId} is still {status} after {after}; call Runs.GetAsync with the template id and run id to keep waiting";
    }

    private static string FormatSeconds(TimeSpan value) =>
        value.TotalSeconds.ToString("0.###", global::System.Globalization.CultureInfo.InvariantCulture)
        + "s";
}

/// <summary>
/// The timing seams of the wait: how to sleep, read a monotonic clock, read the wall clock (for
/// HTTP-date <c>Retry-After</c> values) and draw jitter. Tests swap in a fake with
/// <see cref="Use"/> so nothing actually sleeps.
/// </summary>
internal class FlowsPoller
{
    // Spreads out clients that started together so their status checks don't arrive in lockstep.
    internal const double PollJitter = 0.2;

    // Task.Delay rejects anything longer than int.MaxValue milliseconds (about 24.8 days).
    private static readonly TimeSpan LongestDelay = TimeSpan.FromMilliseconds(int.MaxValue);

    private static readonly FlowsPoller Default = new();
    private static readonly AsyncLocal<FlowsPoller?> Override = new();
    private static readonly object RandomLock = new();
    private static readonly Random SharedRandom = new();

    internal static FlowsPoller Current => Override.Value ?? Default;

    /// <summary>Makes <paramref name="poller"/> the current poller for this async flow until disposed.</summary>
    internal static IDisposable Use(FlowsPoller poller)
    {
        var previous = Override.Value;
        Override.Value = poller;
        return new Restore(previous);
    }

    internal virtual Task DelayAsync(TimeSpan delay, CancellationToken cancellationToken) =>
        Task.Delay(delay, cancellationToken);

    /// <summary>Starts a monotonic clock and returns a function reading the time elapsed since.</summary>
    internal virtual Func<TimeSpan> StartClock()
    {
        var stopwatch = Stopwatch.StartNew();
        return () => stopwatch.Elapsed;
    }

    internal virtual DateTimeOffset UtcNow => DateTimeOffset.UtcNow;

    /// <summary>A number in [0, 1).</summary>
    internal virtual double NextJitter()
    {
        lock (RandomLock)
        {
            return SharedRandom.NextDouble();
        }
    }

    internal static void CheckOptions(FlowsWaitOptions options)
    {
        if (options.MinPollInterval < FlowsWaitOptions.SmallestMinPollInterval)
        {
            throw new ArgumentOutOfRangeException(
                nameof(FlowsWaitOptions.MinPollInterval),
                options.MinPollInterval,
                $"MinPollInterval must be at least {FlowsWaitOptions.SmallestMinPollInterval.TotalSeconds}s."
            );
        }
        if (
            options.WaitTimeout is { } timeout
            && timeout != Timeout.InfiniteTimeSpan
            && timeout < TimeSpan.Zero
        )
        {
            throw new ArgumentOutOfRangeException(
                nameof(FlowsWaitOptions.WaitTimeout),
                timeout,
                "WaitTimeout must be at least zero, or null or Timeout.InfiniteTimeSpan to wait indefinitely."
            );
        }
    }

    /// <summary>
    /// The caller's options for the status checks: everything except
    /// <see cref="RequestOptions.AdditionalBodyProperties"/>, which only the create call takes.
    /// </summary>
    internal static RequestOptions? PollRequestOptions(RequestOptions? options) =>
        options?.AdditionalBodyProperties is null
            ? options
            : new RequestOptions
            {
                BaseUrl = options.BaseUrl,
                HttpClient = options.HttpClient,
                AdditionalHeaders = options.AdditionalHeaders,
                MaxRetries = options.MaxRetries,
                Retry = options.Retry,
                Timeout = options.Timeout,
                AdditionalQueryParameters = options.AdditionalQueryParameters,
            };

    /// <summary>
    /// The server's <c>Retry-After</c>, given as whole seconds or an HTTP date (RFC 9110), or
    /// <c>null</c> if absent or unparseable. A date in the past reads as zero.
    /// </summary>
    internal TimeSpan? ParseRetryAfter(ResponseHeaders headers)
    {
        if (!headers.TryGetValue("Retry-After", out var raw) || raw is null)
        {
            return null;
        }
        if (!RetryConditionHeaderValue.TryParse(raw.Trim(), out var parsed) || parsed is null)
        {
            return null;
        }
        if (parsed.Delta is { } delta)
        {
            return delta;
        }
        if (parsed.Date is { } date)
        {
            var remaining = date - UtcNow;
            return remaining > TimeSpan.Zero ? remaining : TimeSpan.Zero;
        }
        return null;
    }

    /// <summary>
    /// How long to wait before the next status check: the server's <c>Retry-After</c>, never below
    /// <paramref name="minInterval"/>, plus 0-20% jitter.
    /// </summary>
    internal TimeSpan PollDelay(ResponseHeaders headers, TimeSpan minInterval)
    {
        var retryAfter = ParseRetryAfter(headers);
        var delay = retryAfter is { } hint && hint > minInterval ? hint : minInterval;
        var ticks = delay.Ticks * (1 + NextJitter() * PollJitter);
        return ticks >= LongestDelay.Ticks ? LongestDelay : TimeSpan.FromTicks((long)ticks);
    }

    internal static bool IsTerminal(string status) => status is "completed" or "failed";

    /// <summary>
    /// Polls <paramref name="get"/> until the status is <c>completed</c> or <c>failed</c> and
    /// returns that response.
    /// </summary>
    /// <param name="id">The generation or run id, for the timeout error.</param>
    /// <param name="templateId">The template id for a run, for the timeout error.</param>
    /// <param name="firstResponse">The create response.</param>
    /// <param name="firstStatus">The create response's status.</param>
    /// <param name="firstHeaders">The create response's headers.</param>
    /// <param name="get">One status check.</param>
    /// <param name="statusOf">Reads the status of a status-check response.</param>
    /// <param name="elapsed">Time since the wait started, started before the create call.</param>
    /// <param name="options">The validated wait options.</param>
    /// <param name="cancellationToken">Cancels the wait between and during status checks.</param>
    internal async Task<T> WaitAsync<T>(
        string id,
        string? templateId,
        object firstResponse,
        string firstStatus,
        ResponseHeaders firstHeaders,
        Func<Task<WithRawResponse<T>>> get,
        Func<T, string> statusOf,
        Func<TimeSpan> elapsed,
        FlowsWaitOptions options,
        CancellationToken cancellationToken
    )
        where T : notnull
    {
        var waitTimeout =
            options.WaitTimeout is { } timeout && timeout != Timeout.InfiniteTimeSpan
                ? timeout
                : (TimeSpan?)null;
        object current = firstResponse;
        var status = firstStatus;
        var headers = firstHeaders;
        // `current is T` is false only for a generation's create response, whose type differs from
        // the status check's; a create that is already terminal then takes one immediate check.
        while (!(IsTerminal(status) && current is T))
        {
            var delay = TimeSpan.Zero;
            if (!IsTerminal(status))
            {
                delay = PollDelay(headers, options.MinPollInterval);
                if (waitTimeout is { } limit)
                {
                    // The last sleep ends on the deadline; the check after it takes time, so the
                    // next pass throws.
                    var remaining = limit - elapsed();
                    if (remaining <= TimeSpan.Zero)
                    {
                        throw new FlowsWaitTimeoutException(id, templateId, status, current, limit);
                    }
                    if (delay > remaining)
                    {
                        delay = remaining;
                    }
                }
            }
            if (delay > TimeSpan.Zero)
            {
                await DelayAsync(delay, cancellationToken).ConfigureAwait(false);
            }
            cancellationToken.ThrowIfCancellationRequested();
            var next = await get().ConfigureAwait(false);
            current = next.Data;
            status = statusOf(next.Data);
            headers = next.RawResponse.Headers;
        }
        return (T)current;
    }

    private sealed class Restore(FlowsPoller? previous) : IDisposable
    {
        public void Dispose() => Override.Value = previous;
    }
}
