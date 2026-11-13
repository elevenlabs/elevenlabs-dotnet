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
/// The Speech Engine upstream WebSocket protocol defines the interface your server must
/// implement so that ElevenLabs can connect to it during a Speech Engine conversation.
/// Unlike other ElevenLabs WebSocket channels where your client connects to ElevenLabs,
/// the Speech Engine reverses this relationship: **ElevenLabs is the WebSocket client and
/// your server is the WebSocket server**.
///
/// This page shows the WebSocket API shape, however we recommend using the provided server side SDKs
/// instead of implementing this yourself. The SDKs include several helper methods and automatically
/// handle auth for you. You can find SDK installation instructions and
/// guides in the [Speech Engine quickstart](/docs/eleven-api/guides/cookbooks/speech-engine).
///
/// Configure your server's publicly reachable WebSocket URL in the `wsUrl` field when
/// creating or updating a Speech Engine via the REST API. When a user starts a conversation
/// with that agent, ElevenLabs will open a WebSocket connection to your server and begin
/// the message exchange described below.
///
/// ## Connection flow
///
/// 1. A user starts a conversation with a Speech Engine agent (via the ElevenLabs client SDK or API).
/// 2. ElevenLabs opens a WebSocket connection to your `wsUrl`.
/// 3. ElevenLabs sends an `init` message containing the conversation ID.
/// 4. As the user speaks, ElevenLabs transcribes the audio and sends `user_transcript` messages with the full conversation history.
/// 5. Your server calls an LLM and streams the response back as one or more `agent_response` messages.
/// 6. ElevenLabs synthesizes the text to speech and streams the audio back to the user.
/// 7. Periodic `ping` messages keep the connection alive; reply with `pong`.
/// 8. When the conversation ends, ElevenLabs sends a `close` message.
///
/// ## Authentication
///
/// Every connection from ElevenLabs includes an `X-Elevenlabs-Speech-Engine-Authorization`
/// header containing a short-lived JWT. Verify this token before accepting the WebSocket
/// upgrade to ensure the connection originates from ElevenLabs.
///
/// The JWT is signed with **HS256** using the SHA-256 hash of your ElevenLabs API key as
/// the HMAC secret, and has:
/// - **Issuer** (`iss`): `https://api.elevenlabs.io/convai/speech-engine`
/// - **Subject** (`sub`): `convai_speech_engine_upstream`
/// - **Expiry** (`exp`): short-lived; a 60-second clock-skew leeway is applied
///
/// ## Interruption handling
///
/// Each `user_transcript` message carries an `event_id`. If the user speaks again before
/// your server finishes responding, a new `user_transcript` arrives with a higher `event_id`.
/// Cancel your in-flight LLM call and begin responding to the new transcript. Any
/// `agent_response` messages sent with an outdated `event_id` are silently discarded by
/// ElevenLabs.
///
/// ## Streaming responses
///
/// Send LLM output as a sequence of `agent_response` messages with `is_final: false` for
/// each text chunk, followed by a final `agent_response` with `is_final: true` and an empty
/// `content` string. ElevenLabs begins synthesizing audio as chunks arrive, minimising
/// latency.
/// </summary>
public partial class SpeechEngineApi
    : ISpeechEngineApi,
        IAsyncDisposable,
        IDisposable,
        INotifyPropertyChanged
{
    private readonly SpeechEngineApi.Options _options;

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
    /// Default constructor
    /// </summary>
    public SpeechEngineApi()
        : this(new SpeechEngineApi.Options()) { }

    /// <summary>
    /// Constructor with options
    /// </summary>
    public SpeechEngineApi(SpeechEngineApi.Options options)
        : this(
            options,
            new List<KeyValuePair<string, string?>>(),
            (_, _, _) =>
                Task.FromResult<IReadOnlyDictionary<string, string>>(
                    new Dictionary<string, string>()
                )
        ) { }

    internal SpeechEngineApi(
        SpeechEngineApi.Options options,
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
                "Options.BaseUrl is empty. Set it to the WebSocket server URL for SpeechEngineApi.",
                nameof(options)
            );
        }
        var uri = new UriBuilder(_options.BaseUrl);
        var query = new ElevenLabs.Core.QueryStringBuilder.Builder(capacity: 0)
            .MergeAdditional(_options.AdditionalQueryParameters)
            .Build();
        if (query.Length > 0)
        {
            uri.Query = query;
        }
        uri.Path = $"{uri.Path.TrimEnd('/')}/speech-engine/upstream";
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
    /// Event handler for ReceiveUpstreamMessage.
    /// Use ReceiveUpstreamMessage.Subscribe(...) to receive messages.
    /// </summary>
    public Event<ReceiveUpstreamMessage> ReceiveUpstreamMessage { get; } = new();

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
        ReceiveUpstreamMessage.Dispose();
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
            if (JsonUtils.TryDeserialize(json, out ReceiveUpstreamMessage? message))
            {
                await ReceiveUpstreamMessage
                    .RaiseEvent((ReceiveUpstreamMessage)message!)
                    .ConfigureAwait(false);
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
        if (_options.XElevenLabsSpeechEngineAuthorization != null)
        {
            requested["X-ElevenLabs-Speech-Engine-Authorization"] =
                _options.XElevenLabsSpeechEngineAuthorization;
        }
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
    /// Sends a SendUpstreamMessage message to the server
    /// </summary>
    public async Task Send(
        SendUpstreamMessage message,
        CancellationToken cancellationToken = default
    )
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

        public string? XElevenLabsSpeechEngineAuthorization { get; set; }

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
