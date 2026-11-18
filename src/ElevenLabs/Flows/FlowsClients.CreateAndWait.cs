using global::System.Threading;
using global::System.Threading.Tasks;
using ElevenLabs.Core;
using ElevenLabs.Flows.Templates;

namespace ElevenLabs.Flows;

// Hand-written (listed in .fernignore). Adds CreateAndWaitAsync to the generated, partial Flows
// clients and their interfaces, so it is reachable as client.Flows.Image.CreateAndWaitAsync (and on
// Video, TextToSpeech and Templates.Runs), matching create_and_wait in the Python SDK. The polling
// loop lives in FlowsPoller (FlowsWait.cs).

internal static class FlowsGenerationWait
{
    internal static async Task<MediaGenerationResponse> CreateAndWaitAsync(
        Func<RequestOptions?, WithRawResponseTask<MediaGenerationCreateResponse>> create,
        Func<string, RequestOptions?, WithRawResponseTask<MediaGenerationResponse>> get,
        FlowsWaitOptions? waitOptions,
        RequestOptions? options,
        CancellationToken cancellationToken
    )
    {
        waitOptions ??= new FlowsWaitOptions();
        FlowsPoller.CheckOptions(waitOptions);
        var poller = FlowsPoller.Current;
        var elapsed = poller.StartClock();
        var created = await create(options).WithRawResponse().ConfigureAwait(false);
        var generationId = created.Data.Id;
        var pollOptions = FlowsPoller.PollRequestOptions(options);
        return await poller
            .WaitAsync(
                generationId,
                templateId: null,
                created.Data,
                created.Data.Status.Value,
                created.RawResponse.Headers,
                () => get(generationId, pollOptions).WithRawResponse(),
                response => response.Status,
                elapsed,
                waitOptions,
                cancellationToken
            )
            .ConfigureAwait(false);
    }
}

public partial interface IImageClient
{
    /// <summary>
    /// Start an image generation and wait until it is <c>completed</c> or <c>failed</c>, then
    /// return the final generation.
    /// </summary>
    /// <remarks>
    /// Between status checks this waits as long as the server's <c>Retry-After</c> header suggests,
    /// never less than <see cref="FlowsWaitOptions.MinPollInterval"/>, plus up to 20% jitter. This
    /// is meant for scripts and quickstarts: in production, set <c>Webhook</c> on the request and
    /// handle the webhook event instead of holding a process open. A <c>failed</c> generation is
    /// returned, not thrown; check <c>IsCompleted</c> / <c>IsFailed</c> on the result.
    /// </remarks>
    /// <param name="request">The same request <c>CreateAsync</c> takes.</param>
    /// <param name="waitOptions">The wait timeout and minimum poll interval.</param>
    /// <param name="options">
    /// Applied to the create call and to every status check, except
    /// <see cref="RequestOptions.AdditionalBodyProperties"/>, which only the create call gets.
    /// <see cref="RequestOptions.Timeout"/> and retries apply to each request on its own.
    /// </param>
    /// <param name="cancellationToken">Cancels the wait.</param>
    /// <exception cref="FlowsWaitTimeoutException">The wait timeout ran out first.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// The wait timeout is negative or the minimum poll interval is below 0.5 seconds. Thrown
    /// before any request is sent.
    /// </exception>
    Task<MediaGenerationResponse> CreateAndWaitAsync(
        CreateImageRequest request,
        FlowsWaitOptions? waitOptions = null,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

public partial class ImageClient
{
    /// <inheritdoc />
    public Task<MediaGenerationResponse> CreateAndWaitAsync(
        CreateImageRequest request,
        FlowsWaitOptions? waitOptions = null,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        FlowsGenerationWait.CreateAndWaitAsync(
            createOptions => CreateAsync(request, createOptions, cancellationToken),
            (id, pollOptions) =>
                GetAsync(
                    id,
                    new GetImageRequest { XiApiKey = request.XiApiKey },
                    pollOptions,
                    cancellationToken
                ),
            waitOptions,
            options,
            cancellationToken
        );
}

public partial interface IVideoClient
{
    /// <summary>
    /// Start a video generation and wait until it is <c>completed</c> or <c>failed</c>, then
    /// return the final generation.
    /// </summary>
    /// <remarks>
    /// Between status checks this waits as long as the server's <c>Retry-After</c> header suggests,
    /// never less than <see cref="FlowsWaitOptions.MinPollInterval"/>, plus up to 20% jitter. This
    /// is meant for scripts and quickstarts: in production, set <c>Webhook</c> on the request and
    /// handle the webhook event instead of holding a process open. A <c>failed</c> generation is
    /// returned, not thrown; check <c>IsCompleted</c> / <c>IsFailed</c> on the result.
    /// </remarks>
    /// <param name="request">The same request <c>CreateAsync</c> takes.</param>
    /// <param name="waitOptions">The wait timeout and minimum poll interval.</param>
    /// <param name="options">
    /// Applied to the create call and to every status check, except
    /// <see cref="RequestOptions.AdditionalBodyProperties"/>, which only the create call gets.
    /// <see cref="RequestOptions.Timeout"/> and retries apply to each request on its own.
    /// </param>
    /// <param name="cancellationToken">Cancels the wait.</param>
    /// <exception cref="FlowsWaitTimeoutException">The wait timeout ran out first.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// The wait timeout is negative or the minimum poll interval is below 0.5 seconds. Thrown
    /// before any request is sent.
    /// </exception>
    Task<MediaGenerationResponse> CreateAndWaitAsync(
        CreateVideoRequest request,
        FlowsWaitOptions? waitOptions = null,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

public partial class VideoClient
{
    /// <inheritdoc />
    public Task<MediaGenerationResponse> CreateAndWaitAsync(
        CreateVideoRequest request,
        FlowsWaitOptions? waitOptions = null,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        FlowsGenerationWait.CreateAndWaitAsync(
            createOptions => CreateAsync(request, createOptions, cancellationToken),
            (id, pollOptions) =>
                GetAsync(
                    id,
                    new GetVideoRequest { XiApiKey = request.XiApiKey },
                    pollOptions,
                    cancellationToken
                ),
            waitOptions,
            options,
            cancellationToken
        );
}

public partial interface ITextToSpeechClient
{
    /// <summary>
    /// Start a text-to-speech generation and wait until it is <c>completed</c> or <c>failed</c>,
    /// then return the final generation.
    /// </summary>
    /// <remarks>
    /// Between status checks this waits as long as the server's <c>Retry-After</c> header suggests,
    /// never less than <see cref="FlowsWaitOptions.MinPollInterval"/>, plus up to 20% jitter. This
    /// is meant for scripts and quickstarts: in production, set <c>Webhook</c> on the request and
    /// handle the webhook event instead of holding a process open. A <c>failed</c> generation is
    /// returned, not thrown; check <c>IsCompleted</c> / <c>IsFailed</c> on the result.
    /// </remarks>
    /// <param name="request">The same request <c>CreateAsync</c> takes.</param>
    /// <param name="waitOptions">The wait timeout and minimum poll interval.</param>
    /// <param name="options">
    /// Applied to the create call and to every status check, except
    /// <see cref="RequestOptions.AdditionalBodyProperties"/>, which only the create call gets.
    /// <see cref="RequestOptions.Timeout"/> and retries apply to each request on its own.
    /// </param>
    /// <param name="cancellationToken">Cancels the wait.</param>
    /// <exception cref="FlowsWaitTimeoutException">The wait timeout ran out first.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// The wait timeout is negative or the minimum poll interval is below 0.5 seconds. Thrown
    /// before any request is sent.
    /// </exception>
    Task<MediaGenerationResponse> CreateAndWaitAsync(
        CreateTextToSpeechRequest request,
        FlowsWaitOptions? waitOptions = null,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

public partial class TextToSpeechClient
{
    /// <inheritdoc />
    public Task<MediaGenerationResponse> CreateAndWaitAsync(
        CreateTextToSpeechRequest request,
        FlowsWaitOptions? waitOptions = null,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        FlowsGenerationWait.CreateAndWaitAsync(
            createOptions => CreateAsync(request, createOptions, cancellationToken),
            (id, pollOptions) =>
                GetAsync(
                    id,
                    new GetTextToSpeechRequest { XiApiKey = request.XiApiKey },
                    pollOptions,
                    cancellationToken
                ),
            waitOptions,
            options,
            cancellationToken
        );
}
