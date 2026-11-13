using global::System;
using global::System.IO;
using global::System.Net.Http;
using global::System.Threading;
using global::System.Threading.Tasks;

namespace ElevenLabs.Core;

/// <summary>
/// The live body of a binary download. It owns the <see cref="HttpResponseMessage"/> it reads from and
/// disposes it exactly once: when the caller disposes the stream, when a read reaches the end of the
/// body, or when a read fails or is cancelled. A failed read ends the stream (<see cref="CanRead"/> turns
/// false and further reads throw <see cref="ObjectDisposedException"/>), because the transport cannot
/// resume a half-read response body. Until then the connection stays open and the bytes the server has
/// already sent are readable, so the first bytes arrive before the server finishes.
/// </summary>
internal sealed class ResponseBodyStream : Stream
{
    private readonly HttpResponseMessage _response;
    private readonly Stream _inner;
    private int _released;
    private volatile bool _closed;
    private volatile bool _atEnd;

    private ResponseBodyStream(HttpResponseMessage response, Stream inner)
    {
        _response = response;
        _inner = inner;
    }

    /// <summary>
    /// Opens the response body for reading and takes ownership of <paramref name="response"/>. If the
    /// body cannot be opened the response is disposed before the exception propagates.
    /// </summary>
    internal static async Task<Stream> OpenAsync(
        HttpResponseMessage response,
        CancellationToken cancellationToken
    )
    {
        try
        {
#if NET5_0_OR_GREATER
            var inner = await response
                .Content.ReadAsStreamAsync(cancellationToken)
                .ConfigureAwait(false);
#else
            cancellationToken.ThrowIfCancellationRequested();
            var inner = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
#endif
            return new ResponseBodyStream(response, inner);
        }
        catch
        {
            response.Dispose();
            throw;
        }
    }

    public override bool CanRead => !_closed;

    public override bool CanSeek => false;

    public override bool CanWrite => false;

    public override long Length => throw new NotSupportedException();

    public override long Position
    {
        get => throw new NotSupportedException();
        set => throw new NotSupportedException();
    }

    public override void Flush() { }

    public override int Read(byte[] buffer, int offset, int count)
    {
        ThrowIfClosed();
        if (_atEnd)
        {
            return 0;
        }
        int read;
        try
        {
            read = _inner.Read(buffer, offset, count);
        }
        catch
        {
            Abandon();
            throw;
        }
        return AfterRead(read, count);
    }

    public override async Task<int> ReadAsync(
        byte[] buffer,
        int offset,
        int count,
        CancellationToken cancellationToken
    )
    {
        ThrowIfClosed();
        if (_atEnd)
        {
            return 0;
        }
        int read;
        try
        {
            read = await _inner
                .ReadAsync(buffer, offset, count, cancellationToken)
                .ConfigureAwait(false);
        }
        catch
        {
            Abandon();
            throw;
        }
        return AfterRead(read, count);
    }

#if NET5_0_OR_GREATER
    public override int Read(Span<byte> buffer)
    {
        ThrowIfClosed();
        if (_atEnd)
        {
            return 0;
        }
        int read;
        try
        {
            read = _inner.Read(buffer);
        }
        catch
        {
            Abandon();
            throw;
        }
        return AfterRead(read, buffer.Length);
    }

    public override async ValueTask<int> ReadAsync(
        Memory<byte> buffer,
        CancellationToken cancellationToken = default
    )
    {
        ThrowIfClosed();
        if (_atEnd)
        {
            return 0;
        }
        int read;
        try
        {
            read = await _inner.ReadAsync(buffer, cancellationToken).ConfigureAwait(false);
        }
        catch
        {
            Abandon();
            throw;
        }
        return AfterRead(read, buffer.Length);
    }
#endif

    public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();

    public override void SetLength(long value) => throw new NotSupportedException();

    public override void Write(byte[] buffer, int offset, int count) =>
        throw new NotSupportedException();

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _closed = true;
            Release();
        }
        base.Dispose(disposing);
    }

    private int AfterRead(int read, int requested)
    {
        if (read == 0 && requested > 0)
        {
            _atEnd = true;
            Release();
        }
        return read;
    }

    private void ThrowIfClosed()
    {
        if (_closed)
        {
            throw new ObjectDisposedException(nameof(ResponseBodyStream));
        }
    }

    private void Abandon()
    {
        _closed = true;
        Release();
    }

    private void Release()
    {
        if (Interlocked.Exchange(ref _released, 1) != 0)
        {
            return;
        }
        _response.Dispose();
    }
}
