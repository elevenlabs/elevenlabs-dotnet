using System.Net;
using System.Text;
using ElevenLabs.Core;
using ElevenLabs.Flows;
using ElevenLabs.Flows.Templates;
using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Coverage for the hand-written <c>CreateAndWaitAsync</c> helpers on the Flows clients, mirroring
/// <c>tests/test_flows_create_and_wait.py</c> in the Python SDK. Requests go through the real client
/// stack to a scripted transport; a fake <see cref="FlowsPoller"/> records the waits instead of
/// sleeping and advances a fake clock by each one.
/// </summary>
[TestFixture]
public class FlowsCreateAndWaitTest
{
    private sealed record Reply(string Body, IReadOnlyDictionary<string, string>? Headers = null);

    private sealed record Seen(string Method, string Path, string? Body, string? TestHeader);

    /// <summary>Answers each request with the next scripted reply and records what was sent.</summary>
    private sealed class ScriptedTransport(IReadOnlyList<Reply> replies) : HttpMessageHandler
    {
        private int _next;

        internal List<Seen> Requests { get; } = new();

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        )
        {
            var body =
                request.Content is null
                    ? null
                    : await request.Content.ReadAsStringAsync().ConfigureAwait(false);
            request.Headers.TryGetValues("x-test", out var testHeader);
            Requests.Add(
                new Seen(
                    request.Method.Method,
                    request.RequestUri!.AbsolutePath,
                    body,
                    testHeader?.FirstOrDefault()
                )
            );
            if (_next >= replies.Count)
            {
                Assert.Fail($"Unexpected request {request.Method} {request.RequestUri}");
            }
            var reply = replies[_next++];
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(reply.Body, Encoding.UTF8, "application/json"),
                RequestMessage = request,
            };
            foreach (var header in reply.Headers ?? new Dictionary<string, string>())
            {
                response.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
            return response;
        }
    }

    /// <summary>Records each wait and advances its clocks by it instead of sleeping.</summary>
    private sealed class FakePoller : FlowsPoller
    {
        private TimeSpan _elapsed;

        internal static readonly DateTimeOffset Epoch = new(2001, 9, 9, 1, 46, 40, TimeSpan.Zero);

        internal List<TimeSpan> Delays { get; } = new();

        internal double Jitter { get; set; }

        internal Action? OnDelay { get; set; }

        internal override Task DelayAsync(TimeSpan delay, CancellationToken cancellationToken)
        {
            Delays.Add(delay);
            _elapsed += delay;
            OnDelay?.Invoke();
            return Task.CompletedTask;
        }

        internal override Func<TimeSpan> StartClock()
        {
            var start = _elapsed;
            return () => _elapsed - start;
        }

        internal override DateTimeOffset UtcNow => Epoch + _elapsed;

        internal override double NextJitter() => Jitter;

        internal IEnumerable<double> DelaySeconds => Delays.Select(d => d.TotalSeconds);
    }

    private FakePoller _poller = null!;
    private IDisposable _pollerScope = null!;

    [SetUp]
    public void SetUp()
    {
        _poller = new FakePoller();
        _pollerScope = FlowsPoller.Use(_poller);
    }

    [TearDown]
    public void TearDown() => _pollerScope.Dispose();

    private static (ElevenLabsClient Client, ScriptedTransport Transport) Client(
        params Reply[] replies
    )
    {
        var transport = new ScriptedTransport(replies);
        var client = new ElevenLabsClient(
            "test-key",
            new ClientOptions
            {
                BaseUrl = "http://localhost/",
                HttpClient = new HttpClient(transport),
                MaxRetries = 0,
            }
        );
        return (client, transport);
    }

    private static Dictionary<string, string> RetryAfter(string value) =>
        new() { ["Retry-After"] = value };

    private static Reply Created(string id = "gen_1", string? retryAfter = null) =>
        new(
            $$"""{"id":"{{id}}","status":"pending"}""",
            retryAfter is null ? null : RetryAfter(retryAfter)
        );

    private static Reply InProgress(string status, string? retryAfter = null) =>
        new(
            $$"""{"id":"gen_1","status":"{{status}}"}""",
            retryAfter is null ? null : RetryAfter(retryAfter)
        );

    private static readonly Reply Completed = new(
        """{"id":"gen_1","status":"completed","content_url":"https://example.com/out.png","content_mime_type":"image/png"}"""
    );

    private static readonly Reply Failed = new(
        """{"id":"gen_1","status":"failed","failure_reason":"model_error","error_message":"boom"}"""
    );

    private static Reply Run(string status, string? retryAfter = null) =>
        new(
            $$$"""{"id":"run_1","template_id":"tpl_1","version_id":"ver_1","status":"{{{status}}}","outputs":{}}""",
            retryAfter is null ? null : RetryAfter(retryAfter)
        );

    private static CreateImageRequest ImageRequest() =>
        new()
        {
            Body = new ImageGenerationRequest(
                new ImageGenerationRequest.BytedanceSeedream5Lite(
                    new BytedanceSeedream5LiteRequest
                    {
                        Prompt = "A corgi on a beach",
                        ModelId = BytedanceSeedream5LiteRequestModelId.BytedanceSeedream5Lite,
                    }
                )
            ),
        };

    private static CreateVideoRequest VideoRequest() =>
        new()
        {
            Body = new VideoGenerationRequest(
                new VideoGenerationRequest.BytedanceSeedanceV2(
                    new BytedanceSeedance2Request
                    {
                        Prompt = "A corgi surfing",
                        ModelId = BytedanceSeedance2RequestModelId.BytedanceSeedanceV2,
                    }
                )
            ),
        };

    private static CreateTextToSpeechRequest TextToSpeechRequest() =>
        new()
        {
            Body = new TextToSpeechGenerationRequest(
                new TextToSpeechGenerationRequest.ElevenFlashV2_5(
                    new ElevenFlashV25Request
                    {
                        Text = "Hello",
                        Voice = "voice_1",
                        ModelId = ElevenFlashV25RequestModelId.ElevenFlashV25,
                    }
                )
            ),
        };

    private static CreateRunsRequest RunsRequest() =>
        new() { Body = new TemplateRunCreateRequest() };

    [Test]
    public async Task ImagePollsUntilCompletedHonouringRetryAfterSeconds()
    {
        var (client, transport) = Client(
            Created(retryAfter: "3"),
            InProgress("generating", retryAfter: "7"),
            Completed
        );

        var result = await client.Flows.Image.CreateAndWaitAsync(ImageRequest());

        Assert.That(result.IsCompleted, Is.True);
        Assert.That(result.AsCompleted().Id, Is.EqualTo("gen_1"));
        Assert.That(_poller.DelaySeconds, Is.EqualTo(new[] { 3.0, 7.0 }));
        Assert.That(
            transport.Requests.Select(r => (r.Method, r.Path)),
            Is.EqualTo(
                new[]
                {
                    ("POST", "/v1/flows/image"),
                    ("GET", "/v1/flows/image/gen_1"),
                    ("GET", "/v1/flows/image/gen_1"),
                }
            )
        );
    }

    [Test]
    public async Task FailedGenerationIsReturnedNotThrown()
    {
        var (client, transport) = Client(Created(), Failed);

        var result = await client.Flows.Video.CreateAndWaitAsync(VideoRequest());

        Assert.That(result.IsFailed, Is.True);
        Assert.That(result.AsFailed().ErrorMessage, Is.EqualTo("boom"));
        Assert.That(_poller.DelaySeconds, Is.EqualTo(new[] { 3.0 }));
        Assert.That(transport.Requests[1].Path, Is.EqualTo("/v1/flows/video/gen_1"));
    }

    [Test]
    public async Task TextToSpeechPollsUntilCompleted()
    {
        var (client, transport) = Client(Created(retryAfter: "4"), Completed);

        var result = await client.Flows.TextToSpeech.CreateAndWaitAsync(TextToSpeechRequest());

        Assert.That(result.IsCompleted, Is.True);
        Assert.That(_poller.DelaySeconds, Is.EqualTo(new[] { 4.0 }));
        Assert.That(transport.Requests[1].Path, Is.EqualTo("/v1/flows/text-to-speech/gen_1"));
    }

    [Test]
    public async Task InfiniteWaitTimeoutPollsUntilCompleted()
    {
        var (client, transport) = Client(Created(retryAfter: "3"), Completed);

        var result = await client.Flows.Image.CreateAndWaitAsync(
            ImageRequest(),
            new FlowsWaitOptions { WaitTimeout = Timeout.InfiniteTimeSpan }
        );

        Assert.That(result.IsCompleted, Is.True);
        Assert.That(transport.Requests, Has.Count.EqualTo(2));
    }

    [Test]
    public async Task RetryAfterAcceptsAnHttpDate()
    {
        // The fake clock reads 01:46:40 GMT, so this date is 10 seconds away.
        var (client, _) = Client(Created(retryAfter: "Sun, 09 Sep 2001 01:46:50 GMT"), Completed);

        await client.Flows.Image.CreateAndWaitAsync(ImageRequest());

        Assert.That(_poller.DelaySeconds, Is.EqualTo(new[] { 10.0 }));
    }

    [Test]
    public async Task MinPollIntervalIsAFloorUnderRetryAfter()
    {
        // A past date, a zero, a nonsense value and a short hint all fall back to the 5s floor.
        var (client, _) = Client(
            Created(retryAfter: "Sun, 09 Sep 2001 01:46:30 GMT"),
            InProgress("generating", retryAfter: "0"),
            InProgress("generating", retryAfter: "not-a-date"),
            InProgress("generating", retryAfter: "2"),
            InProgress("generating", retryAfter: "8"),
            Completed
        );

        await client.Flows.Image.CreateAndWaitAsync(
            ImageRequest(),
            new FlowsWaitOptions { MinPollInterval = TimeSpan.FromSeconds(5) }
        );

        Assert.That(_poller.DelaySeconds, Is.EqualTo(new[] { 5.0, 5.0, 5.0, 5.0, 8.0 }));
    }

    [Test]
    public async Task JitterAddsUpToTwentyPercent()
    {
        _poller.Jitter = 0.5;
        var (client, _) = Client(Created(retryAfter: "5"), Completed);

        await client.Flows.Image.CreateAndWaitAsync(ImageRequest());

        Assert.That(_poller.DelaySeconds.Single(), Is.EqualTo(5.5).Within(1e-9));
    }

    [Test]
    public void TimeoutThrowsWithTheGenerationId()
    {
        var (client, transport) = Client(
            Created(retryAfter: "30"),
            InProgress("generating", retryAfter: "30")
        );

        var error = Assert.ThrowsAsync<FlowsWaitTimeoutException>(() =>
            client.Flows.Image.CreateAndWaitAsync(
                ImageRequest(),
                new FlowsWaitOptions { WaitTimeout = TimeSpan.FromSeconds(10) }
            )
        )!;

        // The 30s hint is cut to the 10s left; the next pass finds no time left and throws.
        Assert.That(_poller.DelaySeconds, Is.EqualTo(new[] { 10.0 }));
        Assert.That(error.Id, Is.EqualTo("gen_1"));
        Assert.That(error.TemplateId, Is.Null);
        Assert.That(error.Status, Is.EqualTo("generating"));
        Assert.That(error.WaitTimeout, Is.EqualTo(TimeSpan.FromSeconds(10)));
        Assert.That(error.LastResponse, Is.InstanceOf<MediaGenerationResponse>());
        Assert.That(error.Message, Does.Contain("Generation gen_1 is still generating after 10s"));
        Assert.That(error.Message, Does.Contain("call GetAsync with this id to keep waiting"));
        Assert.That(error, Is.InstanceOf<ElevenLabsClientException>());
        Assert.That(transport.Requests, Has.Count.EqualTo(2));
    }

    [Test]
    public void ZeroTimeoutThrowsStraightAfterTheCreate()
    {
        var (client, transport) = Client(Created());

        var error = Assert.ThrowsAsync<FlowsWaitTimeoutException>(() =>
            client.Flows.Image.CreateAndWaitAsync(
                ImageRequest(),
                new FlowsWaitOptions { WaitTimeout = TimeSpan.Zero }
            )
        )!;

        Assert.That(error.Status, Is.EqualTo("pending"));
        Assert.That(error.LastResponse, Is.InstanceOf<MediaGenerationCreateResponse>());
        Assert.That(_poller.Delays, Is.Empty);
        Assert.That(transport.Requests, Has.Count.EqualTo(1));
    }

    private static IEnumerable<TestCaseData> InvalidOptions()
    {
        yield return new TestCaseData(
            new FlowsWaitOptions { MinPollInterval = TimeSpan.FromMilliseconds(499) }
        ).SetName("MinPollIntervalBelowFloor");
        yield return new TestCaseData(
            new FlowsWaitOptions { MinPollInterval = Timeout.InfiniteTimeSpan }
        ).SetName("MinPollIntervalInfinite");
        yield return new TestCaseData(
            new FlowsWaitOptions { WaitTimeout = TimeSpan.FromSeconds(-1) }
        ).SetName("NegativeWaitTimeout");
    }

    [TestCaseSource(nameof(InvalidOptions))]
    public void InvalidOptionsAreRejectedBeforeAnyRequest(FlowsWaitOptions waitOptions)
    {
        var (client, transport) = Client(Created(), Completed);

        Assert.ThrowsAsync<ArgumentOutOfRangeException>(() =>
            client.Flows.Image.CreateAndWaitAsync(ImageRequest(), waitOptions)
        );
        Assert.ThrowsAsync<ArgumentOutOfRangeException>(() =>
            client.Flows.Templates.Runs.CreateAndWaitAsync("tpl_1", RunsRequest(), waitOptions)
        );
        Assert.That(transport.Requests, Is.Empty);
    }

    [Test]
    public async Task TemplateRunPollsUntilCompleted()
    {
        var (client, transport) = Client(Run("pending", retryAfter: "2"), Run("completed"));

        var result = await client.Flows.Templates.Runs.CreateAndWaitAsync(
            "tpl_1",
            RunsRequest(),
            new FlowsWaitOptions { MinPollInterval = TimeSpan.FromSeconds(1) }
        );

        Assert.That(result.Status, Is.EqualTo(TemplateRunStatus.Completed));
        Assert.That(_poller.DelaySeconds, Is.EqualTo(new[] { 2.0 }));
        Assert.That(
            transport.Requests.Select(r => (r.Method, r.Path)),
            Is.EqualTo(
                new[]
                {
                    ("POST", "/v1/flows/templates/tpl_1/runs"),
                    ("GET", "/v1/flows/templates/tpl_1/runs/run_1"),
                }
            )
        );
    }

    [Test]
    public async Task FailedTemplateRunIsReturnedNotThrown()
    {
        var (client, _) = Client(Run("generating"), Run("failed"));

        var result = await client.Flows.Templates.Runs.CreateAndWaitAsync("tpl_1", RunsRequest());

        Assert.That(result.Status, Is.EqualTo(TemplateRunStatus.Failed));
    }

    [Test]
    public async Task TemplateRunAlreadyTerminalOnCreateSkipsPolling()
    {
        var (client, transport) = Client(Run("completed"));

        var result = await client.Flows.Templates.Runs.CreateAndWaitAsync("tpl_1", RunsRequest());

        Assert.That(result.Status, Is.EqualTo(TemplateRunStatus.Completed));
        Assert.That(_poller.Delays, Is.Empty);
        Assert.That(transport.Requests, Has.Count.EqualTo(1));
    }

    [Test]
    public void TemplateRunTimeoutCarriesTheTemplateId()
    {
        var (client, _) = Client(Run("pending"));

        var error = Assert.ThrowsAsync<FlowsWaitTimeoutException>(() =>
            client.Flows.Templates.Runs.CreateAndWaitAsync(
                "tpl_1",
                RunsRequest(),
                new FlowsWaitOptions { WaitTimeout = TimeSpan.Zero }
            )
        )!;

        Assert.That(error.Id, Is.EqualTo("run_1"));
        Assert.That(error.TemplateId, Is.EqualTo("tpl_1"));
        Assert.That(error.Message, Does.Contain("Template run run_1 of template tpl_1"));
        Assert.That(
            error.Message,
            Does.Contain("call Runs.GetAsync with the template id and run id to keep waiting")
        );
    }

    [Test]
    public async Task BodyPropertiesGoToTheCreateOnlyAndHeadersToEveryRequest()
    {
        var (client, transport) = Client(Created(), Completed);

        await client.Flows.Image.CreateAndWaitAsync(
            ImageRequest(),
            options: new RequestOptions
            {
                AdditionalBodyProperties = new { extra = 1 },
                AdditionalHeaders = new[] { new KeyValuePair<string, string?>("x-test", "1") },
            }
        );

        Assert.That(transport.Requests[0].Body, Does.Contain("\"extra\""));
        Assert.That(transport.Requests[1].Body, Is.Null.Or.Empty);
        Assert.That(transport.Requests.Select(r => r.TestHeader), Is.All.EqualTo("1"));
    }

    [Test]
    public void PollRequestOptionsDropsOnlyBodyProperties()
    {
        var options = new RequestOptions
        {
            AdditionalBodyProperties = new { extra = 1 },
            MaxRetries = 4,
            Timeout = TimeSpan.FromSeconds(9),
            AdditionalHeaders = new[] { new KeyValuePair<string, string?>("x-test", "1") },
            AdditionalQueryParameters = new[] { new KeyValuePair<string, string>("q", "1") },
        };

        var poll = FlowsPoller.PollRequestOptions(options)!;

        Assert.That(poll.AdditionalBodyProperties, Is.Null);
        Assert.That(poll.MaxRetries, Is.EqualTo(4));
        Assert.That(poll.Timeout, Is.EqualTo(TimeSpan.FromSeconds(9)));
        Assert.That(poll.AdditionalHeaders, Is.EqualTo(options.AdditionalHeaders));
        Assert.That(poll.AdditionalQueryParameters, Is.EqualTo(options.AdditionalQueryParameters));
        Assert.That(FlowsPoller.PollRequestOptions(null), Is.Null);
    }

    [Test]
    public void CancellationDuringTheWaitStopsPolling()
    {
        var (client, transport) = Client(Created(), InProgress("generating"));
        using var cancellation = new CancellationTokenSource();
        _poller.OnDelay = cancellation.Cancel;

        Assert.That(
            () =>
                client.Flows.Image.CreateAndWaitAsync(
                    ImageRequest(),
                    cancellationToken: cancellation.Token
                ),
            Throws.InstanceOf<OperationCanceledException>()
        );
        Assert.That(transport.Requests, Has.Count.EqualTo(1));
    }
}
