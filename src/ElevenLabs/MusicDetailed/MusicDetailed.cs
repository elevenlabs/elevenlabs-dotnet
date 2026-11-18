using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ElevenLabs.Config;
using ElevenLabs.Core;
using ElevenLabs.Http;
using ElevenLabs.Http.Extensions;
using ElevenLabs.Services;

namespace ElevenLabs.Music;

/// <summary>
/// Compose a song and get its metadata and audio file as separate fields.
/// </summary>
/// <example>
/// <code>
/// var music = new MusicDetailed(client);
/// var song = await music.ComposeDetailedAsync(new ComposeDetailedMusicRequest
/// {
///     Body = new BodyComposeMusicWithADetailedResponseV1MusicDetailedPost
///     {
///         Prompt = "Epic orchestral music with dramatic strings",
///         MusicLengthMs = 60000,
///     },
/// });
/// Console.WriteLine(song.Json["song_metadata"]?["title"]);
/// File.WriteAllBytes(song.Filename, song.Audio);
/// </code>
/// </example>
/// <remarks>
/// The API answers <c>POST /v1/music/detailed</c> with a <c>multipart/mixed</c> body (a JSON part, then
/// the audio). The generated <c>client.Music.ComposeDetailedAsync</c> tries to decode that body as JSON,
/// so this sends the same request through the client's own HTTP pipeline (same base URL, credentials,
/// retries, timeout and error handling) and parses the parts.
///
/// Hand-written rather than generated (see <c>.fernignore</c>). The generated method can't be overridden
/// with a different return type, so this is a separate entry point rather than a method on
/// <c>client.Music</c>. Per-call <see cref="RequestOptions"/> apply; configuration set with
/// <c>client.Music.SetConfig</c> or <c>SetComposeDetailedAsyncConfig</c> does not. Mirrors
/// <c>music.compose_detailed</c> in the Python SDK.
/// </remarks>
public sealed class MusicDetailed
{
    private readonly MusicDetailedService _service;

    /// <param name="client">The root client. Its HTTP pipeline sends the request.</param>
    public MusicDetailed(ElevenLabsClient client)
    {
        if (client is null)
        {
            throw new ArgumentNullException(nameof(client));
        }
        _service = new MusicDetailedService(client.SharedHttpClient);
    }

    /// <summary>
    /// Compose a song from a prompt or a composition plan, and return its metadata and audio.
    /// </summary>
    /// <exception cref="ElevenLabsClientApiException">The API returned an error status.</exception>
    /// <exception cref="ElevenLabsClientException">The response isn't a multipart body with a JSON part and an audio part.</exception>
    public WithRawResponseTask<ComposeDetailedResponse> ComposeDetailedAsync(
        ComposeDetailedMusicRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<ComposeDetailedResponse>(
            WithRawResponseAdapter.Wrap(options, () => ComposeAsync(request, cancellationToken))
        );

    private async Task<ComposeDetailedResponse> ComposeAsync(
        ComposeDetailedMusicRequest request,
        CancellationToken cancellationToken
    )
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }
        using var response = await _service
            .SendAsync(
                request.Body,
                request.OutputFormat,
                request.EnableLogging,
                request.XiApiKey,
                cancellationToken
            )
            .ConfigureAwait(false);
        var body = await response
            .Content
#if NET5_0_OR_GREATER
            .ReadAsByteArrayAsync(cancellationToken)
#else
            .ReadAsByteArrayAsync()
#endif
            .ConfigureAwait(false);
        var parsed = MultipartParser.Parse(body);
        var songId = response.Headers.TryGetValues("song-id", out var values)
            ? values.FirstOrDefault()
            : null;
        return new ComposeDetailedResponse(parsed.Json, parsed.Audio, parsed.Filename, songId);
    }
}

/// <summary>
/// Sends <c>POST /v1/music/detailed</c> exactly as the generated <c>MusicService.ComposeDetailedAsync</c>
/// builds it, but through the binary download path, and returns the HTTP response unread.
/// </summary>
internal sealed class MusicDetailedService : BaseService
{
    internal MusicDetailedService(Client httpClient)
        : base(httpClient) { }

    internal async Task<HttpResponseMessage> SendAsync(
        BodyComposeMusicWithADetailedResponseV1MusicDetailedPost input,
        ComposeDetailedMusicRequestOutputFormat? outputFormat,
        bool? enableLogging,
        string? xiApiKey,
        CancellationToken cancellationToken
    )
    {
        if (input is null)
        {
            throw new ArgumentNullException(nameof(input));
        }

        var resolvedConfig = GetResolvedConfig(null, null);

        var request = new RequestBuilder(HttpMethod.Post, "v1/music/detailed")
            .SetOptionalQueryParameter("output_format", outputFormat?.Value)
            .SetOptionalQueryParameter("enable_logging", enableLogging)
            .SetOptionalHeader("xi-api-key", xiApiKey)
            .SetContentAsJson(input, _jsonSerializerOptions)
            .Build();

        return await ExecuteDownloadAsync(request, resolvedConfig, cancellationToken)
            .ConfigureAwait(false);
    }
}
