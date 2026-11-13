using ElevenLabs.Agents;
using ElevenLabs.Agents.Conversations;
using ElevenLabs.Agents.Dashboard;
using ElevenLabs.Agents.KnowledgeBase;
using ElevenLabs.Agents.McpServers;
using ElevenLabs.Agents.OutboundCampaigns;
using ElevenLabs.Agents.Procedures;
using ElevenLabs.Agents.Tests;
using ElevenLabs.Agents.Widget;
using ElevenLabs.Core;
using ElevenLabs.Core.WebSockets;
using ElevenLabs.Dubbing;
using ElevenLabs.Dubbing.Project;
using ElevenLabs.Dubbing.Project.Language;
using ElevenLabs.EnvironmentVariables;
using ElevenLabs.Flows;
using ElevenLabs.Flows.Templates;
using ElevenLabs.History;
using ElevenLabs.Music;
using ElevenLabs.Productions;
using ElevenLabs.Productions.Orders;
using ElevenLabs.PronunciationDictionaries;
using ElevenLabs.ServiceAccounts;
using ElevenLabs.SpeechEngine;
using ElevenLabs.Studio;
using ElevenLabs.Studio.Projects;
using ElevenLabs.Studio.Projects.Chapters;
using ElevenLabs.Tokens;
using ElevenLabs.Voices;
using ElevenLabs.Voices.Pvc;
using ElevenLabs.Voices.Pvc.Verification;
using ElevenLabs.Workspace;
using ElevenLabs.Workspace.Analytics;
using ElevenLabs.Workspace.Groups;
using global::System.ComponentModel;
using global::System.Text;
using global::System.Text.Json;

namespace ElevenLabs;

/// <summary>
/// The Text-to-Speech WebSockets API is designed to generate audio from partial text input
/// while ensuring consistency throughout the generated audio. Although highly flexible,
/// the WebSockets API isn't a one-size-fits-all solution. It's well-suited for scenarios where:
///   * The input text is being streamed or generated in chunks.
///   * Word-to-audio alignment information is required.
///
/// However, it may not be the best choice when:
///   * The entire input text is available upfront. Given that the generations are partial,
///     some buffering is involved, which could potentially result in slightly higher latency compared
///     to a standard HTTP request.
///   * You want to quickly experiment or prototype. Working with WebSockets can be harder and more
///     complex than using a standard HTTP API, which might slow down rapid development and testing.
/// </summary>
public partial class TextToSpeechApi
    : ITextToSpeechApi,
        IAsyncDisposable,
        IDisposable,
        INotifyPropertyChanged
{
    private readonly TextToSpeechApi.Options _options;

    private readonly WebSocketClient _client;

    private readonly IEnumerable<KeyValuePair<string, string?>> _defaultHeaders;

    private readonly Func<
        bool,
        bool,
        CancellationToken,
        Task<IReadOnlyDictionary<string, string>>
    > _credentials;

    /// <summary>
    /// Event that is raised when a property value changes.
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged
    {
        add => _client.PropertyChanged += value;
        remove => _client.PropertyChanged -= value;
    }

    /// <summary>
    /// Constructor with options
    /// </summary>
    public TextToSpeechApi(TextToSpeechApi.Options options)
        : this(
            options,
            new List<KeyValuePair<string, string?>>(),
            (_, _, _) =>
                Task.FromResult<IReadOnlyDictionary<string, string>>(
                    new Dictionary<string, string>()
                )
        ) { }

    internal TextToSpeechApi(
        TextToSpeechApi.Options options,
        IEnumerable<KeyValuePair<string, string?>> defaultHeaders,
        Func<bool, bool, CancellationToken, Task<IReadOnlyDictionary<string, string>>> credentials
    )
    {
        _options = options;
        _defaultHeaders = defaultHeaders;
        _credentials = credentials;
        if (string.IsNullOrWhiteSpace(_options.BaseUrl))
        {
            throw new ArgumentException(
                "Options.BaseUrl is empty. Set it to the WebSocket server URL for TextToSpeechApi.",
                nameof(options)
            );
        }
        var uri = new UriBuilder(_options.BaseUrl);
        var query = new ElevenLabs.Core.QueryStringBuilder.Builder(capacity: 12)
            .Add("authorization", _options.Authorization)
            .Add("single_use_token", _options.SingleUseToken)
            .Add("model_id", _options.ModelId)
            .Add("language_code", _options.LanguageCode)
            .Add("enable_logging", _options.EnableLogging)
            .Add("output_format", _options.OutputFormat)
            .Add("inactivity_timeout", _options.InactivityTimeout)
            .Add("sync_alignment", _options.SyncAlignment)
            .Add("auto_mode", _options.AutoMode)
            .AddDeepObject("apply_text_normalization", _options.ApplyTextNormalization)
            .Add("seed", _options.Seed)
            .Add("enable_ssml_parsing", _options.EnableSsmlParsing)
            .MergeAdditional(_options.AdditionalQueryParameters)
            .Build();
        if (query.Length > 0)
        {
            uri.Query = query;
        }
        uri.Path =
            $"{uri.Path.TrimEnd('/')}/v1/text-to-speech/{Uri.EscapeDataString(_options.VoiceId)}/stream-input";
        _client = new WebSocketClient(uri.Uri, OnTextMessage);
        _client.HttpInvoker = _options.HttpInvoker;
        _client.IsReconnectionEnabled = _options.IsReconnectionEnabled;
        _client.ReconnectTimeout = _options.ReconnectTimeout;
        _client.ErrorReconnectTimeout = _options.ErrorReconnectTimeout;
        _client.LostReconnectTimeout = _options.LostReconnectTimeout;
        _client.Backoff = _options.ReconnectBackoff;
        _client.ConnectTimeout = _options.ConnectTimeout;
        _client.KeepAliveInterval = _options.KeepAliveInterval;
        _client.KeepAliveTimeout = _options.KeepAliveTimeout;
        _client.LoggerFactory = _options.LoggerFactory;
    }

    /// <summary>
    /// Gets the current connection status of the WebSocket.
    /// </summary>
    public ConnectionStatus Status => _client.Status;

    /// <summary>
    /// Event that is raised when the WebSocket connection is established.
    /// </summary>
    public Event<Connected> Connected => _client.Connected;

    /// <summary>
    /// Event that is raised when the WebSocket connection is closed.
    /// </summary>
    public Event<Closed> Closed => _client.Closed;

    /// <summary>
    /// Event that is raised when an exception occurs during WebSocket operations.
    /// </summary>
    public Event<Exception> ExceptionOccurred => _client.ExceptionOccurred;

    /// <summary>
    /// Event raised when the WebSocket connection is re-established after a disconnect.
    /// </summary>
    public Event<ReconnectionInfo> Reconnecting => _client.Reconnecting;

    /// <summary>
    /// Event handler for ReceiveMessage.
    /// Use ReceiveMessage.Subscribe(...) to receive messages.
    /// </summary>
    public Event<ReceiveMessage> ReceiveMessage { get; } = new();

    /// <summary>
    /// Event handler for unknown/unrecognized message types.
    /// Use UnknownMessage.Subscribe(...) to handle messages from newer server versions.
    /// </summary>
    public Event<JsonElement> UnknownMessage { get; } = new();

    /// <summary>
    /// Event raised with the text of every text frame before it is parsed, including frames that
    /// are not JSON. Use RawMessage.Subscribe(...) to read messages the typed events cannot.
    /// </summary>
    public Event<string> RawMessage { get; } = new();

    /// <summary>
    /// Disposes of event subscriptions
    /// </summary>
    private void DisposeEvents()
    {
        ReceiveMessage.Dispose();
        UnknownMessage.Dispose();
        RawMessage.Dispose();
    }

    /// <summary>
    /// Dispatches incoming WebSocket messages
    /// </summary>
    private async Task OnTextMessage(Stream stream)
    {
        string text;
        using (var reader = new StreamReader(stream, Encoding.UTF8, true, 4096, leaveOpen: true))
        {
            text = await reader.ReadToEndAsync().ConfigureAwait(false);
        }
        await RawMessage.RaiseEvent(text).ConfigureAwait(false);

        JsonDocument? document;
        try
        {
            document = JsonDocument.Parse(text);
        }
        catch (JsonException exception)
        {
            await ExceptionOccurred
                .RaiseEvent(new Exception("Invalid message - Not valid JSON", exception))
                .ConfigureAwait(false);
            return;
        }
        using var json = document;
        if (json == null)
        {
            await ExceptionOccurred
                .RaiseEvent(new Exception("Invalid message - Not valid JSON"))
                .ConfigureAwait(false);
            return;
        }

        {
            if (JsonUtils.TryDeserialize(json, out ReceiveMessage? message))
            {
                await ReceiveMessage.RaiseEvent((ReceiveMessage)message!).ConfigureAwait(false);
                return;
            }
        }

        await UnknownMessage.RaiseEvent(json.RootElement.Clone()).ConfigureAwait(false);
    }

    /// <summary>
    /// Serializes and sends a JSON message to the server
    /// </summary>
    private async Task SendJsonAsync(object message, CancellationToken cancellationToken = default)
    {
        await _client
            .SendInstant(JsonUtils.Serialize(message), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Injects a fake text message for testing. Dispatches through the normal message handling pipeline.
    /// </summary>
    internal async Task InjectTestMessage(string rawJson)
    {
        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(rawJson));
        await OnTextMessage(stream).ConfigureAwait(false);
    }

    /// <summary>
    /// Asynchronously establishes a WebSocket connection.
    /// </summary>
    public async Task ConnectAsync(CancellationToken cancellationToken = default)
    {
#if NET6_0_OR_GREATER
        _client.DeflateOptions = _options.EnableCompression
            ? new System.Net.WebSockets.WebSocketDeflateOptions()
            : null;
#endif
        _client.HandshakeHeaders = ResolveHandshakeHeadersAsync;
        await _client.ConnectAsync(cancellationToken).ConfigureAwait(false);
    }

    private async Task<IReadOnlyDictionary<string, string>> ResolveHandshakeHeadersAsync(
        CancellationToken cancellationToken
    )
    {
        var requested = new Dictionary<string, string?>(StringComparer.OrdinalIgnoreCase);
        foreach (var header in _options.AdditionalHeaders)
        {
            requested[header.Key] = header.Value;
        }
        var headers = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        foreach (var header in _defaultHeaders)
        {
            if (header.Value is not null)
            {
                headers[header.Key] = header.Value;
            }
        }
        var authorizationSupplied = requested.ContainsKey("Authorization");
        var authorizationDefaulted = headers.ContainsKey("Authorization");
        foreach (
            var header in await _credentials(
                    authorizationSupplied,
                    authorizationDefaulted,
                    cancellationToken
                )
                .ConfigureAwait(false)
        )
        {
            headers[header.Key] = header.Value;
        }
        foreach (var header in requested)
        {
            if (header.Value is null)
            {
                headers.Remove(header.Key);
            }
            else
            {
                headers[header.Key] = header.Value;
            }
        }
        return headers;
    }

    /// <summary>
    /// Asynchronously closes the WebSocket connection.
    /// </summary>
    public async Task CloseAsync(CancellationToken cancellationToken = default)
    {
        await _client.CloseAsync(cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Asynchronously disposes the WebSocket client, closing any active connections and cleaning up resources.
    /// </summary>
    public async ValueTask DisposeAsync()
    {
        await _client.DisposeAsync();
        DisposeEvents();
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Synchronously disposes the WebSocket client, closing any active connections and cleaning up resources.
    /// </summary>
    public void Dispose()
    {
        _client.Dispose();
        DisposeEvents();
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Sends a SendMessage message to the server
    /// </summary>
    public async Task Send(SendMessage message, CancellationToken cancellationToken = default)
    {
        await SendJsonAsync(message, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Sends <paramref name="message"/> to the server verbatim as a text frame
    /// </summary>
    public async Task Send(string message, CancellationToken cancellationToken = default)
    {
        await _client.SendInstant(message, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Sends <paramref name="message"/> to the server verbatim as a binary frame
    /// </summary>
    public async Task Send(byte[] message, CancellationToken cancellationToken = default)
    {
        await _client.SendInstant(message, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Options for the API client
    /// </summary>
    public class Options
    {
        /// <summary>
        /// The Websocket URL for the API connection.
        /// </summary>
        public string BaseUrl { get; set; } = "";

        /// <summary>
        /// Enable per-message deflate compression (RFC 7692). When true, the client sets <c>ClientWebSocketOptions.DangerousDeflateOptions</c> before connecting. Compression is negotiated during the handshake; if the server does not support it, the connection proceeds uncompressed. Default: <c>false</c>.
        /// <para><b>Security warning:</b> do not enable compression when transmitting data containing secrets — compressed encrypted payloads are vulnerable to CRIME/BREACH side-channel attacks. See <see href="https://learn.microsoft.com/dotnet/api/system.net.websockets.clientwebsocketoptions.dangerousdeflateoptions">ClientWebSocketOptions.DangerousDeflateOptions</see> for details.</para>
        /// </summary>
        public bool EnableCompression { get; set; } = false;

        /// <summary>
        /// Optional HTTP/2 handler for multiplexed WebSocket connections (.NET 7+).
        /// </summary>
        public System.Net.Http.HttpMessageInvoker? HttpInvoker { get; set; }

        public string? Authorization { get; set; }

        public string? SingleUseToken { get; set; }

        public string? ModelId { get; set; }

        public string? LanguageCode { get; set; }

        public bool? EnableLogging { get; set; }

        public string? OutputFormat { get; set; }

        public int? InactivityTimeout { get; set; }

        public bool? SyncAlignment { get; set; }

        public bool? AutoMode { get; set; }

        public TextToSpeechRealtimeApplyTextNormalization? ApplyTextNormalization { get; set; }

        public int? Seed { get; set; }

        public bool? EnableSsmlParsing { get; set; }

        public required string VoiceId { get; set; }

        /// <summary>
        /// Enable or disable automatic reconnection. Default: false.
        /// </summary>
        public bool IsReconnectionEnabled { get; set; } = false;

        /// <summary>
        /// Time to wait before reconnecting if no message comes from the server. Set null to disable. Default: 1 minute.
        /// </summary>
        public TimeSpan? ReconnectTimeout { get; set; } = TimeSpan.FromMinutes(1);

        /// <summary>
        /// Time to wait before reconnecting if the last reconnection attempt failed. Set null to disable. Default: 1 minute.
        /// </summary>
        public TimeSpan? ErrorReconnectTimeout { get; set; } = TimeSpan.FromMinutes(1);

        /// <summary>
        /// Time to wait before reconnecting if the connection is lost with a transient error. Set null to disable (reconnect immediately). Default: null.
        /// </summary>
        public TimeSpan? LostReconnectTimeout { get; set; }

        /// <summary>
        /// Backoff strategy for reconnection delays. Controls interval growth, jitter, and max attempts. Set to null to use fixed-interval reconnection (legacy behavior). Default: exponential backoff, 1s→60s, unlimited attempts, with jitter.
        /// </summary>
        public ReconnectStrategy? ReconnectBackoff { get; set; } = new ReconnectStrategy();

        /// <summary>
        /// Time to wait for the opening handshake to complete. Default: 5 seconds.
        /// </summary>
        public TimeSpan ConnectTimeout { get; set; } = TimeSpan.FromSeconds(5);

        /// <summary>
        /// Interval for sending keep-alive frames. Set to <c>TimeSpan.Zero</c> to disable keep-alive. Default: <see cref="System.Net.WebSockets.WebSocket.DefaultKeepAliveInterval"/>.
        /// </summary>
        public TimeSpan KeepAliveInterval { get; set; } =
            System.Net.WebSockets.WebSocket.DefaultKeepAliveInterval;

        /// <summary>
        /// Time to wait for the PONG answering a keep-alive PING before the connection is treated as lost (.NET 9+). Default: 20 seconds.
        /// </summary>
        public TimeSpan KeepAliveTimeout { get; set; } = TimeSpan.FromSeconds(20);

        /// <summary>
        /// Creates the logger for connection diagnostics (handler failures, reconnects, close errors). Nothing is logged when unset.
        /// </summary>
        public Microsoft.Extensions.Logging.ILoggerFactory? LoggerFactory { get; set; }

        /// <summary>
        /// Additional headers to send on the opening handshake, including on reconnects. Each replaces a credential or spec header of the same name, matched case-insensitively; a <c>null</c> value removes that header.
        /// </summary>
        public IEnumerable<KeyValuePair<string, string?>> AdditionalHeaders { get; set; } =
            new List<KeyValuePair<string, string?>>();

        /// <summary>
        /// Additional query parameters for the handshake URL. Each replaces a spec query parameter or credential of the same name. Read when the client is constructed.
        /// </summary>
        public IEnumerable<KeyValuePair<string, string>> AdditionalQueryParameters { get; set; } =
            new List<KeyValuePair<string, string>>();
    }
}
