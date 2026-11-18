using global::System.Threading;
using global::System.Threading.Tasks;
using ElevenLabs.Core;

namespace ElevenLabs.Flows.Templates;

// Hand-written (listed in .fernignore). Adds CreateAndWaitAsync to the generated, partial
// RunsClient / IRunsClient, so it is reachable as client.Flows.Templates.Runs.CreateAndWaitAsync,
// matching flows.templates.runs.create_and_wait in the Python SDK. The polling loop lives in
// FlowsPoller (FlowsWait.cs).

public partial interface IRunsClient
{
    /// <summary>
    /// Start a run of a flows template and wait until its status is <c>completed</c> or
    /// <c>failed</c>, then return the final run.
    /// </summary>
    /// <remarks>
    /// Between status checks this waits as long as the server's <c>Retry-After</c> header suggests,
    /// never less than <see cref="FlowsWaitOptions.MinPollInterval"/>, plus up to 20% jitter. This
    /// is meant for scripts and quickstarts: in production, set <c>Webhook</c> on the request and
    /// handle the <c>flows_template_run</c> webhook instead of holding a process open. A
    /// <c>failed</c> run is returned, not thrown; check <c>Status</c> on the result and on each
    /// output.
    /// </remarks>
    /// <param name="templateId">The ID of the template.</param>
    /// <param name="request">The same request <c>CreateAsync</c> takes.</param>
    /// <param name="waitOptions">The wait timeout and minimum poll interval.</param>
    /// <param name="options">
    /// Applied to the create call and to every status check, except
    /// <see cref="RequestOptions.AdditionalBodyProperties"/>, which only the create call gets.
    /// <see cref="RequestOptions.Timeout"/> and retries apply to each request on its own.
    /// </param>
    /// <param name="cancellationToken">Cancels the wait.</param>
    /// <exception cref="FlowsWaitTimeoutException">
    /// The wait timeout ran out first. Carries the run id and the template id.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// The wait timeout is negative or the minimum poll interval is below 0.5 seconds. Thrown
    /// before any request is sent.
    /// </exception>
    Task<TemplateRunResponse> CreateAndWaitAsync(
        string templateId,
        CreateRunsRequest request,
        FlowsWaitOptions? waitOptions = null,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

public partial class RunsClient
{
    /// <inheritdoc />
    public async Task<TemplateRunResponse> CreateAndWaitAsync(
        string templateId,
        CreateRunsRequest request,
        FlowsWaitOptions? waitOptions = null,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        waitOptions ??= new FlowsWaitOptions();
        FlowsPoller.CheckOptions(waitOptions);
        var poller = FlowsPoller.Current;
        var elapsed = poller.StartClock();
        var created = await CreateAsync(templateId, request, options, cancellationToken)
            .WithRawResponse()
            .ConfigureAwait(false);
        var runId = created.Data.Id;
        var pollOptions = FlowsPoller.PollRequestOptions(options);
        var getRequest = new GetRunsRequest { XiApiKey = request.XiApiKey };
        return await poller
            .WaitAsync(
                runId,
                templateId,
                created.Data,
                created.Data.Status.Value,
                created.RawResponse.Headers,
                () =>
                    GetAsync(templateId, runId, getRequest, pollOptions, cancellationToken)
                        .WithRawResponse(),
                response => response.Status.Value,
                elapsed,
                waitOptions,
                cancellationToken
            )
            .ConfigureAwait(false);
    }
}
