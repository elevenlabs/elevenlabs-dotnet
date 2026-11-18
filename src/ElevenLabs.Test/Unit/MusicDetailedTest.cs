using System.Net;
using System.Text;
using System.Text.Json.Nodes;
using ElevenLabs.Core;
using ElevenLabs.Http.Exceptions;
using ElevenLabs.Music;
using NUnit.Framework;

namespace ElevenLabs.Tests;

/// <summary>
/// Coverage for the hand-written <see cref="MusicDetailed"/>, mirroring
/// <c>tests/test_music_multipart.py</c> in the Python SDK. Requests go through the real client stack
/// to a scripted transport that answers with a <c>multipart/mixed</c> body.
/// </summary>
[TestFixture]
public class MusicDetailedTest
{
    private const string Boundary = "--boundary123";

    private const string Metadata =
        "{\"composition_plan\":{\"positive_global_styles\":[\"pop\"],\"negative_global_styles\":[],\"sections\":[]},"
        + "\"song_metadata\":{\"title\":\"Test\",\"description\":\"A test song\",\"genres\":[\"pop\"],\"languages\":[\"en\"],\"is_explicit\":false},"
        + "\"words_timestamps\":null}";

    /// <summary>Every byte value, so an off-by-one at either end of the audio part shows up.</summary>
    private static readonly byte[] Audio = Enumerable
        .Repeat(Enumerable.Range(0, 256).Select(b => (byte)b), 4)
        .SelectMany(b => b)
        .ToArray();

    private sealed record Seen(string Method, string PathAndQuery, string? Body);

    private sealed class ScriptedTransport(
        byte[] body,
        HttpStatusCode status = HttpStatusCode.OK,
        IReadOnlyDictionary<string, string>? headers = null
    ) : HttpMessageHandler
    {
        internal List<Seen> Requests { get; } = new();

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        )
        {
            var sent =
                request.Content is null
                    ? null
                    : await request.Content.ReadAsStringAsync().ConfigureAwait(false);
            Requests.Add(new Seen(request.Method.Method, request.RequestUri!.PathAndQuery, sent));
            var content = new ByteArrayContent(body);
            content.Headers.TryAddWithoutValidation(
                "Content-Type",
                status == HttpStatusCode.OK
                    ? "multipart/mixed; boundary=boundary123"
                    : "application/json"
            );
            var response = new HttpResponseMessage(status)
            {
                Content = content,
                RequestMessage = request,
            };
            foreach (var header in headers ?? new Dictionary<string, string>())
            {
                response.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
            return response;
        }
    }

    private static (MusicDetailed Music, ScriptedTransport Transport) Music(
        byte[] body,
        HttpStatusCode status = HttpStatusCode.OK,
        IReadOnlyDictionary<string, string>? headers = null
    )
    {
        var transport = new ScriptedTransport(body, status, headers);
        var client = new ElevenLabsClient(
            "test-key",
            new ClientOptions
            {
                BaseUrl = "http://localhost/",
                HttpClient = new HttpClient(transport),
                MaxRetries = 0,
            }
        );
        return (new MusicDetailed(client), transport);
    }

    private static byte[] Multipart(string lineBreak, string? json = null, bool disposition = true)
    {
        var head = new StringBuilder()
            .Append(Boundary)
            .Append(lineBreak)
            .Append("Content-Type: application/json")
            .Append(lineBreak)
            .Append(lineBreak)
            .Append(json ?? Metadata)
            .Append(lineBreak)
            .Append(Boundary)
            .Append(lineBreak)
            .Append("Content-Type: audio/mpeg")
            .Append(lineBreak);
        if (disposition)
        {
            head.Append("Content-Disposition: attachment; filename=\"test_song.mp3\"").Append(lineBreak);
        }
        head.Append(lineBreak);
        var tail = $"{lineBreak}{Boundary}--{lineBreak}";
        return Encoding.UTF8.GetBytes(head.ToString())
            .Concat(Audio)
            .Concat(Encoding.UTF8.GetBytes(tail))
            .ToArray();
    }

    private static ComposeDetailedMusicRequest Request() =>
        new()
        {
            Body = new BodyComposeMusicWithADetailedResponseV1MusicDetailedPost
            {
                Prompt = "Epic orchestral music",
                MusicLengthMs = 10000,
            },
            OutputFormat = ComposeDetailedMusicRequestOutputFormat.Mp344100128,
        };

    [Test]
    public async Task ParsesMetadataAndExactAudioWithCrlfLineEndings()
    {
        var (music, _) = Music(Multipart("\r\n"));

        var song = await music.ComposeDetailedAsync(Request());

        Assert.That(JsonNode.DeepEquals(song.Json, JsonNode.Parse(Metadata)), Is.True);
        Assert.That(song.Audio, Is.EqualTo(Audio), "audio must be byte-for-byte, with the closing delimiter stripped");
        Assert.That(song.Filename, Is.EqualTo("test_song.mp3"));
    }

    [Test]
    public async Task ParsesLfLineEndings()
    {
        var (music, _) = Music(Multipart("\n"));

        var song = await music.ComposeDetailedAsync(Request());

        Assert.That(song.Json["song_metadata"]!["title"]!.GetValue<string>(), Is.EqualTo("Test"));
        Assert.That(song.Audio, Is.EqualTo(Audio));
    }

    [Test]
    public async Task SendsTheGeneratedRequest()
    {
        var (music, transport) = Music(Multipart("\r\n"));

        await music.ComposeDetailedAsync(Request());

        var seen = transport.Requests.Single();
        Assert.That(seen.Method, Is.EqualTo("POST"));
        Assert.That(seen.PathAndQuery, Does.StartWith("/v1/music/detailed"));
        Assert.That(seen.PathAndQuery, Does.Contain("output_format=mp3_44100_128"));
        var body = JsonNode.Parse(seen.Body!)!;
        Assert.That(body["prompt"]!.GetValue<string>(), Is.EqualTo("Epic orchestral music"));
        Assert.That(body["music_length_ms"]!.GetValue<int>(), Is.EqualTo(10000));
    }

    [Test]
    public async Task ReturnsTheSongIdHeaderAndTheRawResponse()
    {
        var (music, _) = Music(
            Multipart("\r\n"),
            headers: new Dictionary<string, string> { ["song-id"] = "song_abc" }
        );

        var result = await music.ComposeDetailedAsync(Request()).WithRawResponse();

        Assert.That(result.Data.SongId, Is.EqualTo("song_abc"));
        Assert.That((int)result.RawResponse.StatusCode, Is.EqualTo(200));
    }

    [Test]
    public async Task SongIdIsNullWithoutTheHeader()
    {
        var (music, _) = Music(Multipart("\r\n"));

        Assert.That((await music.ComposeDetailedAsync(Request())).SongId, Is.Null);
    }

    [Test]
    public async Task DefaultsTheFilenameWithoutContentDisposition()
    {
        var (music, _) = Music(Multipart("\r\n", disposition: false));

        var song = await music.ComposeDetailedAsync(Request());

        Assert.That(song.Filename, Is.EqualTo(MultipartParser.DefaultFilename));
        Assert.That(song.Audio, Is.EqualTo(Audio));
    }

    [Test]
    public async Task ParsesPrettyPrintedJson()
    {
        var pretty = JsonNode.Parse(Metadata)!
            .ToJsonString(new System.Text.Json.JsonSerializerOptions { WriteIndented = true })
            .Replace("\r\n", "\n")
            .Replace("\n", "\r\n");
        var (music, _) = Music(Multipart("\r\n", pretty));

        var song = await music.ComposeDetailedAsync(Request());

        Assert.That(JsonNode.DeepEquals(song.Json, JsonNode.Parse(Metadata)), Is.True);
    }

    [Test]
    public void ThrowsWithoutAJsonPart()
    {
        var body = Encoding.UTF8.GetBytes($"{Boundary}\r\nContent-Type: audio/mpeg\r\n\r\n")
            .Concat(Audio)
            .Concat(Encoding.UTF8.GetBytes($"\r\n{Boundary}--\r\n"))
            .ToArray();
        var (music, _) = Music(body);

        var error = Assert.ThrowsAsync<ElevenLabsClientException>(async () =>
            await music.ComposeDetailedAsync(Request())
        );
        Assert.That(error!.Message, Does.Contain("JSON part"));
    }

    [Test]
    public void ThrowsWithoutAnAudioPart()
    {
        var body = Encoding.UTF8.GetBytes(
            $"{Boundary}\r\nContent-Type: application/json\r\n\r\n{{}}\r\n{Boundary}--\r\n"
        );
        var (music, _) = Music(body);

        var error = Assert.ThrowsAsync<ElevenLabsClientException>(async () =>
            await music.ComposeDetailedAsync(Request())
        );
        Assert.That(error!.Message, Does.Contain("audio part"));
    }

    [Test]
    public void ApiErrorsKeepTheGeneratedErrorHandling()
    {
        var (music, _) = Music(Encoding.UTF8.GetBytes("{\"detail\":\"bad\"}"), HttpStatusCode.UnprocessableEntity);

        // The generated pipeline maps the status to its typed error (an ElevenLabsClientApiException).
        Assert.ThrowsAsync<UnprocessableEntityError>(async () =>
            await music.ComposeDetailedAsync(Request())
        );
    }

    [Test]
    public void ThrowsWhenTheBodyEndsMidAudio()
    {
        var full = Multipart("\r\n");
        // Cut inside the audio, so the closing delimiter never arrives.
        var cut = full.Take(full.Length - $"\r\n{Boundary}--\r\n".Length - 100).ToArray();
        var (music, _) = Music(cut);

        var error = Assert.ThrowsAsync<ElevenLabsClientException>(async () =>
            await music.ComposeDetailedAsync(Request())
        );
        Assert.That(error!.Message, Does.Contain("incomplete"));
    }

    [Test]
    public void ThrowsOnAPartialClosingBoundary()
    {
        var full = Multipart("\r\n");
        var cut = full.Take(full.Length - "3--\r\n".Length).ToArray(); // ends in "...\r\n--boundary12"
        var (music, _) = Music(cut);

        var error = Assert.ThrowsAsync<ElevenLabsClientException>(async () =>
            await music.ComposeDetailedAsync(Request())
        );
        Assert.That(error!.Message, Does.Contain("incomplete"));
    }

    [Test]
    public async Task SkipsAPreambleUsingTheContentTypeBoundary()
    {
        var body = Encoding.UTF8.GetBytes("This is a multipart message.\r\n")
            .Concat(Multipart("\r\n"))
            .ToArray();
        var (music, _) = Music(body);

        var song = await music.ComposeDetailedAsync(Request());

        Assert.That(JsonNode.DeepEquals(song.Json, JsonNode.Parse(Metadata)), Is.True);
        Assert.That(song.Audio, Is.EqualTo(Audio));
    }

    [Test]
    public void ReadsTheBoundaryParameter()
    {
        Assert.That(MultipartParser.BoundaryFrom("multipart/mixed; boundary=\"abc\""), Is.EqualTo("abc"));
        Assert.That(
            MultipartParser.BoundaryFrom("multipart/mixed; boundary=----boundaryf00"),
            Is.EqualTo("----boundaryf00")
        );
        Assert.That(MultipartParser.BoundaryFrom("application/json"), Is.Null);
        Assert.That(MultipartParser.BoundaryFrom(null), Is.Null);
    }

    /// <summary>Sends the headers, then a body that never finishes arriving.</summary>
    private sealed class StallingTransport : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        )
        {
            var content = new StreamContent(new StallingStream());
            content.Headers.TryAddWithoutValidation("Content-Type", "multipart/mixed; boundary=boundary123");
            return Task.FromResult(
                new HttpResponseMessage(HttpStatusCode.OK) { Content = content, RequestMessage = request }
            );
        }
    }

    private sealed class StallingStream : Stream
    {
        public override bool CanRead => true;
        public override bool CanSeek => false;
        public override bool CanWrite => false;
        public override long Length => throw new NotSupportedException();
        public override long Position
        {
            get => throw new NotSupportedException();
            set => throw new NotSupportedException();
        }

        public override async Task<int> ReadAsync(
            byte[] buffer,
            int offset,
            int count,
            CancellationToken cancellationToken
        )
        {
            await Task.Delay(Timeout.Infinite, cancellationToken).ConfigureAwait(false);
            return 0;
        }

        public override async ValueTask<int> ReadAsync(
            Memory<byte> buffer,
            CancellationToken cancellationToken = default
        )
        {
            await Task.Delay(Timeout.Infinite, cancellationToken).ConfigureAwait(false);
            return 0;
        }

        public override int Read(byte[] buffer, int offset, int count) => throw new NotSupportedException();
        public override void Flush() { }
        public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();
        public override void SetLength(long value) => throw new NotSupportedException();
        public override void Write(byte[] buffer, int offset, int count) => throw new NotSupportedException();
    }

    [Test]
    public void TheTimeoutCoversAStalledBody()
    {
        var client = new ElevenLabsClient(
            "test-key",
            new ClientOptions
            {
                BaseUrl = "http://localhost/",
                HttpClient = new HttpClient(new StallingTransport()),
                MaxRetries = 0,
            }
        );
        var music = new MusicDetailed(client);

        Assert.ThrowsAsync<ApiTimeoutException>(async () =>
            await music.ComposeDetailedAsync(
                Request(),
                new RequestOptions { Timeout = TimeSpan.FromMilliseconds(200) }
            )
        );
    }

    [Test]
    public void ParserFindsTheAudioPartBeforeTheJsonPart()
    {
        var body = Encoding.UTF8.GetBytes($"{Boundary}\r\nContent-Type: audio/mpeg\r\n\r\n")
            .Concat(Audio)
            .Concat(
                Encoding.UTF8.GetBytes(
                    $"\r\n{Boundary}\r\nContent-Type: application/json\r\n\r\n{{\"a\":1}}\r\n{Boundary}--\r\n"
                )
            )
            .ToArray();

        var parsed = MultipartParser.Parse(body);

        Assert.That(parsed.Json["a"]!.GetValue<int>(), Is.EqualTo(1));
        Assert.That(parsed.Audio, Is.EqualTo(Audio));
    }
}
