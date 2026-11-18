using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;

namespace ElevenLabs.Music;

/// <summary>
/// Splits the <c>multipart/mixed</c> body of <c>POST /v1/music/detailed</c> into its JSON metadata part
/// and its audio part. The generator models this response as JSON, so the generated
/// <c>MusicClient.ComposeDetailedAsync</c> fails to decode it.
/// </summary>
/// <remarks>
/// Works on bytes throughout, so the audio is returned exactly as sent: the line break before each
/// delimiter and the closing <c>--boundary--</c> are stripped, never left on the end of the audio.
/// Hand-written (see <c>.fernignore</c>), mirroring <c>parseMultipart</c> in the TypeScript SDK.
/// </remarks>
internal static class MultipartParser
{
    internal const string DefaultFilename = "generated_music.mp3";

    private static readonly byte[] CrLf = { (byte)'\r', (byte)'\n' };
    private static readonly byte[] Lf = { (byte)'\n' };
    private static readonly byte[] DashDash = { (byte)'-', (byte)'-' };
    private static readonly Regex FilenamePattern = new(
        "filename=\"([^\"]+)\"|filename=([^;\\s]+)",
        RegexOptions.IgnoreCase | RegexOptions.CultureInvariant
    );
    private static readonly Regex BoundaryPattern = new(
        "boundary=(?:\"([^\"]+)\"|([^;\\s]+))",
        RegexOptions.IgnoreCase | RegexOptions.CultureInvariant
    );

    internal readonly struct Parsed
    {
        internal Parsed(JsonObject json, byte[] audio, string filename)
        {
            Json = json;
            Audio = audio;
            Filename = filename;
        }

        internal JsonObject Json { get; }
        internal byte[] Audio { get; }
        internal string Filename { get; }
    }

    private sealed class Part
    {
        internal Part(Dictionary<string, string> headers, byte[] body, bool separated)
        {
            Headers = headers;
            Body = body;
            Separated = separated;
        }

        internal Dictionary<string, string> Headers { get; }
        internal byte[] Body { get; }
        internal bool Separated { get; }

        internal string ContentType =>
            Headers.TryGetValue("content-type", out var type) ? type : string.Empty;
    }

    /// <summary>The <c>boundary</c> parameter of a <c>Content-Type</c> header, unquoted, or null.</summary>
    internal static string? BoundaryFrom(string? contentType)
    {
        if (contentType is null)
        {
            return null;
        }
        var match = BoundaryPattern.Match(contentType);
        if (!match.Success)
        {
            return null;
        }
        return match.Groups[1].Success ? match.Groups[1].Value : match.Groups[2].Value;
    }

    /// <param name="body">The response body.</param>
    /// <param name="boundary">The <c>boundary</c> parameter of the response's <c>Content-Type</c>. Without
    /// it the delimiter is read from the body's first line.</param>
    /// <exception cref="ElevenLabsClientException">The body isn't a complete multipart body with a JSON part
    /// and an audio part, including when it ends before the closing <c>--boundary--</c> (truncated).</exception>
    internal static Parsed Parse(byte[] body, string? boundary = null)
    {
        var delimiter = DelimiterFor(body, boundary);

        // The first delimiter starts the body or a line: anything before it is a preamble, which is ignored.
        int pos;
        if (StartsWithAt(body, 0, delimiter))
        {
            pos = 0;
        }
        else
        {
            var found = IndexOf(body, Concat(Lf, delimiter), 0);
            if (found < 0)
            {
                throw new ElevenLabsClientException(
                    "Could not find the multipart boundary in the music response"
                );
            }
            pos = found + 1;
        }
        // The body uses one line ending throughout; read it from the first delimiter line.
        var lineBreak = StartsWithAt(body, pos + delimiter.Length, CrLf) ? CrLf : Lf;
        var breakThenDelimiter = Concat(lineBreak, delimiter);

        var parts = new List<Part>();
        while (true)
        {
            var after = pos + delimiter.Length;
            if (StartsWithAt(body, after, DashDash))
            {
                break; // Closing delimiter.
            }
            var start = StartsWithAt(body, after, lineBreak) ? after + lineBreak.Length : after;
            var next = IndexOf(body, breakThenDelimiter, start);
            // Every part ends at a delimiter, and the body at `--boundary--`; the API always sends it. A
            // body that stops first was cut off, so its last part (the audio, usually) is incomplete.
            if (next < 0)
            {
                throw new ElevenLabsClientException(
                    "The music response ended before its closing multipart boundary; it is incomplete"
                );
            }
            parts.Add(SplitPart(Slice(body, start, next - start), lineBreak));
            pos = next + lineBreak.Length;
        }

        Part? jsonPart = null;
        Part? audioPart = null;
        foreach (var part in parts)
        {
            var isJson = part.ContentType.StartsWith(
                "application/json",
                StringComparison.OrdinalIgnoreCase
            );
            if (jsonPart is null && isJson)
            {
                jsonPart = part;
            }
            else if (audioPart is null && !isJson)
            {
                audioPart = part;
            }
        }

        if (jsonPart is null)
        {
            throw new ElevenLabsClientException("Could not find the JSON part in the music response");
        }
        JsonObject json;
        try
        {
            json =
                JsonNode.Parse(Encoding.UTF8.GetString(jsonPart.Body).Trim()) as JsonObject
                ?? throw new ElevenLabsClientException(
                    "The JSON part of the music response is not an object"
                );
        }
        catch (JsonException e)
        {
            throw new ElevenLabsClientException(
                $"Could not parse the JSON part of the music response: {e.Message}",
                e
            );
        }
        if (audioPart is null || !audioPart.Separated)
        {
            throw new ElevenLabsClientException("Could not find the audio part in the music response");
        }

        audioPart.Headers.TryGetValue("content-disposition", out var disposition);
        return new Parsed(json, audioPart.Body, Filename(disposition));
    }

    private static byte[] DelimiterFor(byte[] body, string? boundary)
    {
        if (!string.IsNullOrEmpty(boundary))
        {
            return Encoding.ASCII.GetBytes("--" + boundary);
        }
        var firstBreak = Array.IndexOf(body, (byte)'\n');
        var firstLineLength = firstBreak < 0 ? body.Length : firstBreak;
        var delimiterText = Encoding.ASCII.GetString(body, 0, firstLineLength).Trim();
        if (!delimiterText.StartsWith("--", StringComparison.Ordinal) || delimiterText.Length < 3)
        {
            throw new ElevenLabsClientException(
                "Could not find the multipart boundary in the music response"
            );
        }
        return Encoding.ASCII.GetBytes(delimiterText);
    }

    private static Part SplitPart(byte[] part, byte[] lineBreak)
    {
        // Prepend a line break so a part with no headers (the blank line straight after the
        // delimiter) is found at offset 0 too.
        var withBreak = Concat(lineBreak, part);
        var separator = IndexOf(withBreak, Concat(lineBreak, lineBreak), 0);
        if (separator < 0)
        {
            return new Part(Headers(part, lineBreak), Array.Empty<byte>(), separated: false);
        }
        var headerLength = Math.Max(0, separator - lineBreak.Length);
        var headerBlock = Slice(withBreak, lineBreak.Length, headerLength);
        var bodyStart = separator + (2 * lineBreak.Length);
        var partBody = Slice(withBreak, bodyStart, withBreak.Length - bodyStart);
        return new Part(Headers(headerBlock, lineBreak), partBody, separated: true);
    }

    private static Dictionary<string, string> Headers(byte[] block, byte[] lineBreak)
    {
        var headers = new Dictionary<string, string>(StringComparer.Ordinal);
        var text = Encoding.UTF8.GetString(block);
        var separator = Encoding.ASCII.GetString(lineBreak);
        foreach (var line in text.Split(new[] { separator }, StringSplitOptions.None))
        {
            var colon = line.IndexOf(':');
            if (colon > 0)
            {
                headers[line.Substring(0, colon).Trim().ToLowerInvariant()] = line.Substring(colon + 1)
                    .Trim();
            }
        }
        return headers;
    }

    private static string Filename(string? disposition)
    {
        if (disposition is not null)
        {
            var match = FilenamePattern.Match(disposition);
            if (match.Success)
            {
                var name = match.Groups[1].Success ? match.Groups[1].Value : match.Groups[2].Value;
                if (name.Length > 0)
                {
                    return name;
                }
            }
        }
        return DefaultFilename;
    }

    private static int IndexOf(byte[] haystack, byte[] needle, int start)
    {
        if (start > haystack.Length)
        {
            return -1;
        }
        var index = ((ReadOnlySpan<byte>)haystack.AsSpan(start)).IndexOf(needle);
        return index < 0 ? -1 : index + start;
    }

    private static bool StartsWithAt(byte[] haystack, int offset, byte[] prefix) =>
        offset + prefix.Length <= haystack.Length
        && ((ReadOnlySpan<byte>)haystack.AsSpan(offset, prefix.Length)).SequenceEqual(prefix);

    private static byte[] Slice(byte[] source, int start, int length) =>
        length <= 0 ? Array.Empty<byte>() : source.AsSpan(start, length).ToArray();

    private static byte[] Concat(byte[] first, byte[] second)
    {
        var result = new byte[first.Length + second.Length];
        Buffer.BlockCopy(first, 0, result, 0, first.Length);
        Buffer.BlockCopy(second, 0, result, first.Length, second.Length);
        return result;
    }
}
