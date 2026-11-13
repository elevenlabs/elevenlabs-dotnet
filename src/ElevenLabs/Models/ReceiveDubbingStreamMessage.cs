// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ReceiveDubbingStreamMessage.JsonConverter))]
[Serializable]
public record ReceiveDubbingStreamMessage
{
    internal ReceiveDubbingStreamMessage(string type, object? value)
    {
        MessageType = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of ReceiveDubbingStreamMessage with <see cref="ReceiveDubbingStreamMessage.SessionStarted"/>.
    /// </summary>
    public ReceiveDubbingStreamMessage(ReceiveDubbingStreamMessage.SessionStarted value)
    {
        MessageType = "session_started";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveDubbingStreamMessage with <see cref="ReceiveDubbingStreamMessage.Status"/>.
    /// </summary>
    public ReceiveDubbingStreamMessage(ReceiveDubbingStreamMessage.Status value)
    {
        MessageType = "status";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveDubbingStreamMessage with <see cref="ReceiveDubbingStreamMessage.PartialTranscript"/>.
    /// </summary>
    public ReceiveDubbingStreamMessage(ReceiveDubbingStreamMessage.PartialTranscript value)
    {
        MessageType = "partial_transcript";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveDubbingStreamMessage with <see cref="ReceiveDubbingStreamMessage.CommittedTranscript"/>.
    /// </summary>
    public ReceiveDubbingStreamMessage(ReceiveDubbingStreamMessage.CommittedTranscript value)
    {
        MessageType = "committed_transcript";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveDubbingStreamMessage with <see cref="ReceiveDubbingStreamMessage.Translation"/>.
    /// </summary>
    public ReceiveDubbingStreamMessage(ReceiveDubbingStreamMessage.Translation value)
    {
        MessageType = "translation";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveDubbingStreamMessage with <see cref="ReceiveDubbingStreamMessage.Audio"/>.
    /// </summary>
    public ReceiveDubbingStreamMessage(ReceiveDubbingStreamMessage.Audio value)
    {
        MessageType = "audio";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveDubbingStreamMessage with <see cref="ReceiveDubbingStreamMessage.Error"/>.
    /// </summary>
    public ReceiveDubbingStreamMessage(ReceiveDubbingStreamMessage.Error value)
    {
        MessageType = "error";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveDubbingStreamMessage with <see cref="ReceiveDubbingStreamMessage.AuthError"/>.
    /// </summary>
    public ReceiveDubbingStreamMessage(ReceiveDubbingStreamMessage.AuthError value)
    {
        MessageType = "auth_error";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveDubbingStreamMessage with <see cref="ReceiveDubbingStreamMessage.RateLimited"/>.
    /// </summary>
    public ReceiveDubbingStreamMessage(ReceiveDubbingStreamMessage.RateLimited value)
    {
        MessageType = "rate_limited";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveDubbingStreamMessage with <see cref="ReceiveDubbingStreamMessage.QueueOverflow"/>.
    /// </summary>
    public ReceiveDubbingStreamMessage(ReceiveDubbingStreamMessage.QueueOverflow value)
    {
        MessageType = "queue_overflow";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveDubbingStreamMessage with <see cref="ReceiveDubbingStreamMessage.InvalidRequest"/>.
    /// </summary>
    public ReceiveDubbingStreamMessage(ReceiveDubbingStreamMessage.InvalidRequest value)
    {
        MessageType = "invalid_request";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveDubbingStreamMessage with <see cref="ReceiveDubbingStreamMessage.InputError"/>.
    /// </summary>
    public ReceiveDubbingStreamMessage(ReceiveDubbingStreamMessage.InputError value)
    {
        MessageType = "input_error";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveDubbingStreamMessage with <see cref="ReceiveDubbingStreamMessage.TranscriberError"/>.
    /// </summary>
    public ReceiveDubbingStreamMessage(ReceiveDubbingStreamMessage.TranscriberError value)
    {
        MessageType = "transcriber_error";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveDubbingStreamMessage with <see cref="ReceiveDubbingStreamMessage.TranslationError"/>.
    /// </summary>
    public ReceiveDubbingStreamMessage(ReceiveDubbingStreamMessage.TranslationError value)
    {
        MessageType = "translation_error";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveDubbingStreamMessage with <see cref="ReceiveDubbingStreamMessage.AudioOutputError"/>.
    /// </summary>
    public ReceiveDubbingStreamMessage(ReceiveDubbingStreamMessage.AudioOutputError value)
    {
        MessageType = "audio_output_error";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("message_type")]
    public string MessageType { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="MessageType"/> is "session_started"
    /// </summary>
    public bool IsSessionStarted => MessageType == "session_started";

    /// <summary>
    /// Returns true if <see cref="MessageType"/> is "status"
    /// </summary>
    public bool IsStatus => MessageType == "status";

    /// <summary>
    /// Returns true if <see cref="MessageType"/> is "partial_transcript"
    /// </summary>
    public bool IsPartialTranscript => MessageType == "partial_transcript";

    /// <summary>
    /// Returns true if <see cref="MessageType"/> is "committed_transcript"
    /// </summary>
    public bool IsCommittedTranscript => MessageType == "committed_transcript";

    /// <summary>
    /// Returns true if <see cref="MessageType"/> is "translation"
    /// </summary>
    public bool IsTranslation => MessageType == "translation";

    /// <summary>
    /// Returns true if <see cref="MessageType"/> is "audio"
    /// </summary>
    public bool IsAudio => MessageType == "audio";

    /// <summary>
    /// Returns true if <see cref="MessageType"/> is "error"
    /// </summary>
    public bool IsError => MessageType == "error";

    /// <summary>
    /// Returns true if <see cref="MessageType"/> is "auth_error"
    /// </summary>
    public bool IsAuthError => MessageType == "auth_error";

    /// <summary>
    /// Returns true if <see cref="MessageType"/> is "rate_limited"
    /// </summary>
    public bool IsRateLimited => MessageType == "rate_limited";

    /// <summary>
    /// Returns true if <see cref="MessageType"/> is "queue_overflow"
    /// </summary>
    public bool IsQueueOverflow => MessageType == "queue_overflow";

    /// <summary>
    /// Returns true if <see cref="MessageType"/> is "invalid_request"
    /// </summary>
    public bool IsInvalidRequest => MessageType == "invalid_request";

    /// <summary>
    /// Returns true if <see cref="MessageType"/> is "input_error"
    /// </summary>
    public bool IsInputError => MessageType == "input_error";

    /// <summary>
    /// Returns true if <see cref="MessageType"/> is "transcriber_error"
    /// </summary>
    public bool IsTranscriberError => MessageType == "transcriber_error";

    /// <summary>
    /// Returns true if <see cref="MessageType"/> is "translation_error"
    /// </summary>
    public bool IsTranslationError => MessageType == "translation_error";

    /// <summary>
    /// Returns true if <see cref="MessageType"/> is "audio_output_error"
    /// </summary>
    public bool IsAudioOutputError => MessageType == "audio_output_error";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.DubbingSessionStarted"/> if <see cref="MessageType"/> is 'session_started', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'session_started'.</exception>
    public global::ElevenLabs.DubbingSessionStarted AsSessionStarted() =>
        IsSessionStarted
            ? (global::ElevenLabs.DubbingSessionStarted)Value!
            : throw new global::System.Exception(
                "ReceiveDubbingStreamMessage.MessageType is not 'session_started'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.DubbingStatus"/> if <see cref="MessageType"/> is 'status', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'status'.</exception>
    public global::ElevenLabs.DubbingStatus AsStatus() =>
        IsStatus
            ? (global::ElevenLabs.DubbingStatus)Value!
            : throw new global::System.Exception(
                "ReceiveDubbingStreamMessage.MessageType is not 'status'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.DubbingPartialTranscript"/> if <see cref="MessageType"/> is 'partial_transcript', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'partial_transcript'.</exception>
    public global::ElevenLabs.DubbingPartialTranscript AsPartialTranscript() =>
        IsPartialTranscript
            ? (global::ElevenLabs.DubbingPartialTranscript)Value!
            : throw new global::System.Exception(
                "ReceiveDubbingStreamMessage.MessageType is not 'partial_transcript'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.DubbingCommittedTranscript"/> if <see cref="MessageType"/> is 'committed_transcript', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'committed_transcript'.</exception>
    public global::ElevenLabs.DubbingCommittedTranscript AsCommittedTranscript() =>
        IsCommittedTranscript
            ? (global::ElevenLabs.DubbingCommittedTranscript)Value!
            : throw new global::System.Exception(
                "ReceiveDubbingStreamMessage.MessageType is not 'committed_transcript'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.DubbingTranslation"/> if <see cref="MessageType"/> is 'translation', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'translation'.</exception>
    public global::ElevenLabs.DubbingTranslation AsTranslation() =>
        IsTranslation
            ? (global::ElevenLabs.DubbingTranslation)Value!
            : throw new global::System.Exception(
                "ReceiveDubbingStreamMessage.MessageType is not 'translation'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.DubbingAudio"/> if <see cref="MessageType"/> is 'audio', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'audio'.</exception>
    public global::ElevenLabs.DubbingAudio AsAudio() =>
        IsAudio
            ? (global::ElevenLabs.DubbingAudio)Value!
            : throw new global::System.Exception(
                "ReceiveDubbingStreamMessage.MessageType is not 'audio'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.DubbingErrorPayload"/> if <see cref="MessageType"/> is 'error', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'error'.</exception>
    public global::ElevenLabs.DubbingErrorPayload AsError() =>
        IsError
            ? (global::ElevenLabs.DubbingErrorPayload)Value!
            : throw new global::System.Exception(
                "ReceiveDubbingStreamMessage.MessageType is not 'error'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.DubbingAuthError"/> if <see cref="MessageType"/> is 'auth_error', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'auth_error'.</exception>
    public global::ElevenLabs.DubbingAuthError AsAuthError() =>
        IsAuthError
            ? (global::ElevenLabs.DubbingAuthError)Value!
            : throw new global::System.Exception(
                "ReceiveDubbingStreamMessage.MessageType is not 'auth_error'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.DubbingRateLimitedError"/> if <see cref="MessageType"/> is 'rate_limited', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'rate_limited'.</exception>
    public global::ElevenLabs.DubbingRateLimitedError AsRateLimited() =>
        IsRateLimited
            ? (global::ElevenLabs.DubbingRateLimitedError)Value!
            : throw new global::System.Exception(
                "ReceiveDubbingStreamMessage.MessageType is not 'rate_limited'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.DubbingQueueOverflowError"/> if <see cref="MessageType"/> is 'queue_overflow', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'queue_overflow'.</exception>
    public global::ElevenLabs.DubbingQueueOverflowError AsQueueOverflow() =>
        IsQueueOverflow
            ? (global::ElevenLabs.DubbingQueueOverflowError)Value!
            : throw new global::System.Exception(
                "ReceiveDubbingStreamMessage.MessageType is not 'queue_overflow'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.DubbingInvalidRequestError"/> if <see cref="MessageType"/> is 'invalid_request', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'invalid_request'.</exception>
    public global::ElevenLabs.DubbingInvalidRequestError AsInvalidRequest() =>
        IsInvalidRequest
            ? (global::ElevenLabs.DubbingInvalidRequestError)Value!
            : throw new global::System.Exception(
                "ReceiveDubbingStreamMessage.MessageType is not 'invalid_request'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.DubbingInputError"/> if <see cref="MessageType"/> is 'input_error', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'input_error'.</exception>
    public global::ElevenLabs.DubbingInputError AsInputError() =>
        IsInputError
            ? (global::ElevenLabs.DubbingInputError)Value!
            : throw new global::System.Exception(
                "ReceiveDubbingStreamMessage.MessageType is not 'input_error'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.DubbingTranscriberError"/> if <see cref="MessageType"/> is 'transcriber_error', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'transcriber_error'.</exception>
    public global::ElevenLabs.DubbingTranscriberError AsTranscriberError() =>
        IsTranscriberError
            ? (global::ElevenLabs.DubbingTranscriberError)Value!
            : throw new global::System.Exception(
                "ReceiveDubbingStreamMessage.MessageType is not 'transcriber_error'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.DubbingTranslationError"/> if <see cref="MessageType"/> is 'translation_error', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'translation_error'.</exception>
    public global::ElevenLabs.DubbingTranslationError AsTranslationError() =>
        IsTranslationError
            ? (global::ElevenLabs.DubbingTranslationError)Value!
            : throw new global::System.Exception(
                "ReceiveDubbingStreamMessage.MessageType is not 'translation_error'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.DubbingAudioOutputError"/> if <see cref="MessageType"/> is 'audio_output_error', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'audio_output_error'.</exception>
    public global::ElevenLabs.DubbingAudioOutputError AsAudioOutputError() =>
        IsAudioOutputError
            ? (global::ElevenLabs.DubbingAudioOutputError)Value!
            : throw new global::System.Exception(
                "ReceiveDubbingStreamMessage.MessageType is not 'audio_output_error'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.DubbingSessionStarted, T> onSessionStarted,
        Func<global::ElevenLabs.DubbingStatus, T> onStatus,
        Func<global::ElevenLabs.DubbingPartialTranscript, T> onPartialTranscript,
        Func<global::ElevenLabs.DubbingCommittedTranscript, T> onCommittedTranscript,
        Func<global::ElevenLabs.DubbingTranslation, T> onTranslation,
        Func<global::ElevenLabs.DubbingAudio, T> onAudio,
        Func<global::ElevenLabs.DubbingErrorPayload, T> onError,
        Func<global::ElevenLabs.DubbingAuthError, T> onAuthError,
        Func<global::ElevenLabs.DubbingRateLimitedError, T> onRateLimited,
        Func<global::ElevenLabs.DubbingQueueOverflowError, T> onQueueOverflow,
        Func<global::ElevenLabs.DubbingInvalidRequestError, T> onInvalidRequest,
        Func<global::ElevenLabs.DubbingInputError, T> onInputError,
        Func<global::ElevenLabs.DubbingTranscriberError, T> onTranscriberError,
        Func<global::ElevenLabs.DubbingTranslationError, T> onTranslationError,
        Func<global::ElevenLabs.DubbingAudioOutputError, T> onAudioOutputError,
        Func<string, object?, T> onUnknown_
    )
    {
        return MessageType switch
        {
            "session_started" => onSessionStarted(AsSessionStarted()),
            "status" => onStatus(AsStatus()),
            "partial_transcript" => onPartialTranscript(AsPartialTranscript()),
            "committed_transcript" => onCommittedTranscript(AsCommittedTranscript()),
            "translation" => onTranslation(AsTranslation()),
            "audio" => onAudio(AsAudio()),
            "error" => onError(AsError()),
            "auth_error" => onAuthError(AsAuthError()),
            "rate_limited" => onRateLimited(AsRateLimited()),
            "queue_overflow" => onQueueOverflow(AsQueueOverflow()),
            "invalid_request" => onInvalidRequest(AsInvalidRequest()),
            "input_error" => onInputError(AsInputError()),
            "transcriber_error" => onTranscriberError(AsTranscriberError()),
            "translation_error" => onTranslationError(AsTranslationError()),
            "audio_output_error" => onAudioOutputError(AsAudioOutputError()),
            _ => onUnknown_(MessageType, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.DubbingSessionStarted> onSessionStarted,
        Action<global::ElevenLabs.DubbingStatus> onStatus,
        Action<global::ElevenLabs.DubbingPartialTranscript> onPartialTranscript,
        Action<global::ElevenLabs.DubbingCommittedTranscript> onCommittedTranscript,
        Action<global::ElevenLabs.DubbingTranslation> onTranslation,
        Action<global::ElevenLabs.DubbingAudio> onAudio,
        Action<global::ElevenLabs.DubbingErrorPayload> onError,
        Action<global::ElevenLabs.DubbingAuthError> onAuthError,
        Action<global::ElevenLabs.DubbingRateLimitedError> onRateLimited,
        Action<global::ElevenLabs.DubbingQueueOverflowError> onQueueOverflow,
        Action<global::ElevenLabs.DubbingInvalidRequestError> onInvalidRequest,
        Action<global::ElevenLabs.DubbingInputError> onInputError,
        Action<global::ElevenLabs.DubbingTranscriberError> onTranscriberError,
        Action<global::ElevenLabs.DubbingTranslationError> onTranslationError,
        Action<global::ElevenLabs.DubbingAudioOutputError> onAudioOutputError,
        Action<string, object?> onUnknown_
    )
    {
        switch (MessageType)
        {
            case "session_started":
                onSessionStarted(AsSessionStarted());
                break;
            case "status":
                onStatus(AsStatus());
                break;
            case "partial_transcript":
                onPartialTranscript(AsPartialTranscript());
                break;
            case "committed_transcript":
                onCommittedTranscript(AsCommittedTranscript());
                break;
            case "translation":
                onTranslation(AsTranslation());
                break;
            case "audio":
                onAudio(AsAudio());
                break;
            case "error":
                onError(AsError());
                break;
            case "auth_error":
                onAuthError(AsAuthError());
                break;
            case "rate_limited":
                onRateLimited(AsRateLimited());
                break;
            case "queue_overflow":
                onQueueOverflow(AsQueueOverflow());
                break;
            case "invalid_request":
                onInvalidRequest(AsInvalidRequest());
                break;
            case "input_error":
                onInputError(AsInputError());
                break;
            case "transcriber_error":
                onTranscriberError(AsTranscriberError());
                break;
            case "translation_error":
                onTranslationError(AsTranslationError());
                break;
            case "audio_output_error":
                onAudioOutputError(AsAudioOutputError());
                break;
            default:
                onUnknown_(MessageType, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.DubbingSessionStarted"/> and returns true if successful.
    /// </summary>
    public bool TryAsSessionStarted(out global::ElevenLabs.DubbingSessionStarted? value)
    {
        if (MessageType == "session_started")
        {
            value = (global::ElevenLabs.DubbingSessionStarted)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.DubbingStatus"/> and returns true if successful.
    /// </summary>
    public bool TryAsStatus(out global::ElevenLabs.DubbingStatus? value)
    {
        if (MessageType == "status")
        {
            value = (global::ElevenLabs.DubbingStatus)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.DubbingPartialTranscript"/> and returns true if successful.
    /// </summary>
    public bool TryAsPartialTranscript(out global::ElevenLabs.DubbingPartialTranscript? value)
    {
        if (MessageType == "partial_transcript")
        {
            value = (global::ElevenLabs.DubbingPartialTranscript)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.DubbingCommittedTranscript"/> and returns true if successful.
    /// </summary>
    public bool TryAsCommittedTranscript(out global::ElevenLabs.DubbingCommittedTranscript? value)
    {
        if (MessageType == "committed_transcript")
        {
            value = (global::ElevenLabs.DubbingCommittedTranscript)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.DubbingTranslation"/> and returns true if successful.
    /// </summary>
    public bool TryAsTranslation(out global::ElevenLabs.DubbingTranslation? value)
    {
        if (MessageType == "translation")
        {
            value = (global::ElevenLabs.DubbingTranslation)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.DubbingAudio"/> and returns true if successful.
    /// </summary>
    public bool TryAsAudio(out global::ElevenLabs.DubbingAudio? value)
    {
        if (MessageType == "audio")
        {
            value = (global::ElevenLabs.DubbingAudio)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.DubbingErrorPayload"/> and returns true if successful.
    /// </summary>
    public bool TryAsError(out global::ElevenLabs.DubbingErrorPayload? value)
    {
        if (MessageType == "error")
        {
            value = (global::ElevenLabs.DubbingErrorPayload)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.DubbingAuthError"/> and returns true if successful.
    /// </summary>
    public bool TryAsAuthError(out global::ElevenLabs.DubbingAuthError? value)
    {
        if (MessageType == "auth_error")
        {
            value = (global::ElevenLabs.DubbingAuthError)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.DubbingRateLimitedError"/> and returns true if successful.
    /// </summary>
    public bool TryAsRateLimited(out global::ElevenLabs.DubbingRateLimitedError? value)
    {
        if (MessageType == "rate_limited")
        {
            value = (global::ElevenLabs.DubbingRateLimitedError)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.DubbingQueueOverflowError"/> and returns true if successful.
    /// </summary>
    public bool TryAsQueueOverflow(out global::ElevenLabs.DubbingQueueOverflowError? value)
    {
        if (MessageType == "queue_overflow")
        {
            value = (global::ElevenLabs.DubbingQueueOverflowError)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.DubbingInvalidRequestError"/> and returns true if successful.
    /// </summary>
    public bool TryAsInvalidRequest(out global::ElevenLabs.DubbingInvalidRequestError? value)
    {
        if (MessageType == "invalid_request")
        {
            value = (global::ElevenLabs.DubbingInvalidRequestError)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.DubbingInputError"/> and returns true if successful.
    /// </summary>
    public bool TryAsInputError(out global::ElevenLabs.DubbingInputError? value)
    {
        if (MessageType == "input_error")
        {
            value = (global::ElevenLabs.DubbingInputError)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.DubbingTranscriberError"/> and returns true if successful.
    /// </summary>
    public bool TryAsTranscriberError(out global::ElevenLabs.DubbingTranscriberError? value)
    {
        if (MessageType == "transcriber_error")
        {
            value = (global::ElevenLabs.DubbingTranscriberError)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.DubbingTranslationError"/> and returns true if successful.
    /// </summary>
    public bool TryAsTranslationError(out global::ElevenLabs.DubbingTranslationError? value)
    {
        if (MessageType == "translation_error")
        {
            value = (global::ElevenLabs.DubbingTranslationError)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.DubbingAudioOutputError"/> and returns true if successful.
    /// </summary>
    public bool TryAsAudioOutputError(out global::ElevenLabs.DubbingAudioOutputError? value)
    {
        if (MessageType == "audio_output_error")
        {
            value = (global::ElevenLabs.DubbingAudioOutputError)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator ReceiveDubbingStreamMessage(
        ReceiveDubbingStreamMessage.SessionStarted value
    ) => new(value);

    public static implicit operator ReceiveDubbingStreamMessage(
        ReceiveDubbingStreamMessage.Status value
    ) => new(value);

    public static implicit operator ReceiveDubbingStreamMessage(
        ReceiveDubbingStreamMessage.PartialTranscript value
    ) => new(value);

    public static implicit operator ReceiveDubbingStreamMessage(
        ReceiveDubbingStreamMessage.CommittedTranscript value
    ) => new(value);

    public static implicit operator ReceiveDubbingStreamMessage(
        ReceiveDubbingStreamMessage.Translation value
    ) => new(value);

    public static implicit operator ReceiveDubbingStreamMessage(
        ReceiveDubbingStreamMessage.Audio value
    ) => new(value);

    public static implicit operator ReceiveDubbingStreamMessage(
        ReceiveDubbingStreamMessage.Error value
    ) => new(value);

    public static implicit operator ReceiveDubbingStreamMessage(
        ReceiveDubbingStreamMessage.AuthError value
    ) => new(value);

    public static implicit operator ReceiveDubbingStreamMessage(
        ReceiveDubbingStreamMessage.RateLimited value
    ) => new(value);

    public static implicit operator ReceiveDubbingStreamMessage(
        ReceiveDubbingStreamMessage.QueueOverflow value
    ) => new(value);

    public static implicit operator ReceiveDubbingStreamMessage(
        ReceiveDubbingStreamMessage.InvalidRequest value
    ) => new(value);

    public static implicit operator ReceiveDubbingStreamMessage(
        ReceiveDubbingStreamMessage.InputError value
    ) => new(value);

    public static implicit operator ReceiveDubbingStreamMessage(
        ReceiveDubbingStreamMessage.TranscriberError value
    ) => new(value);

    public static implicit operator ReceiveDubbingStreamMessage(
        ReceiveDubbingStreamMessage.TranslationError value
    ) => new(value);

    public static implicit operator ReceiveDubbingStreamMessage(
        ReceiveDubbingStreamMessage.AudioOutputError value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<ReceiveDubbingStreamMessage>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(ReceiveDubbingStreamMessage).IsAssignableFrom(typeToConvert);

        public override ReceiveDubbingStreamMessage Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (!json.TryGetProperty("message_type", out var discriminatorElement))
            {
                throw new JsonException("Missing discriminator property 'message_type'");
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException("Discriminator property 'message_type' is null");
                }

                throw new JsonException(
                    $"Discriminator property 'message_type' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException("Discriminator property 'message_type' is null");

            var value = discriminator switch
            {
                "session_started" => json.Deserialize<global::ElevenLabs.DubbingSessionStarted?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.DubbingSessionStarted"
                    ),
                "status" => json.Deserialize<global::ElevenLabs.DubbingStatus?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.DubbingStatus"
                    ),
                "partial_transcript" =>
                    json.Deserialize<global::ElevenLabs.DubbingPartialTranscript?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.DubbingPartialTranscript"
                        ),
                "committed_transcript" =>
                    json.Deserialize<global::ElevenLabs.DubbingCommittedTranscript?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.DubbingCommittedTranscript"
                        ),
                "translation" => json.Deserialize<global::ElevenLabs.DubbingTranslation?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.DubbingTranslation"
                    ),
                "audio" => json.Deserialize<global::ElevenLabs.DubbingAudio?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.DubbingAudio"
                    ),
                "error" => json.Deserialize<global::ElevenLabs.DubbingErrorPayload?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.DubbingErrorPayload"
                    ),
                "auth_error" => json.Deserialize<global::ElevenLabs.DubbingAuthError?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.DubbingAuthError"
                    ),
                "rate_limited" => json.Deserialize<global::ElevenLabs.DubbingRateLimitedError?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.DubbingRateLimitedError"
                    ),
                "queue_overflow" => json.Deserialize<global::ElevenLabs.DubbingQueueOverflowError?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.DubbingQueueOverflowError"
                    ),
                "invalid_request" =>
                    json.Deserialize<global::ElevenLabs.DubbingInvalidRequestError?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.DubbingInvalidRequestError"
                        ),
                "input_error" => json.Deserialize<global::ElevenLabs.DubbingInputError?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.DubbingInputError"
                    ),
                "transcriber_error" =>
                    json.Deserialize<global::ElevenLabs.DubbingTranscriberError?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.DubbingTranscriberError"
                        ),
                "translation_error" =>
                    json.Deserialize<global::ElevenLabs.DubbingTranslationError?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.DubbingTranslationError"
                        ),
                "audio_output_error" =>
                    json.Deserialize<global::ElevenLabs.DubbingAudioOutputError?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.DubbingAudioOutputError"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new ReceiveDubbingStreamMessage(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReceiveDubbingStreamMessage value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.MessageType switch
                {
                    "session_started" => JsonSerializer.SerializeToNode(value.Value, options),
                    "status" => JsonSerializer.SerializeToNode(value.Value, options),
                    "partial_transcript" => JsonSerializer.SerializeToNode(value.Value, options),
                    "committed_transcript" => JsonSerializer.SerializeToNode(value.Value, options),
                    "translation" => JsonSerializer.SerializeToNode(value.Value, options),
                    "audio" => JsonSerializer.SerializeToNode(value.Value, options),
                    "error" => JsonSerializer.SerializeToNode(value.Value, options),
                    "auth_error" => JsonSerializer.SerializeToNode(value.Value, options),
                    "rate_limited" => JsonSerializer.SerializeToNode(value.Value, options),
                    "queue_overflow" => JsonSerializer.SerializeToNode(value.Value, options),
                    "invalid_request" => JsonSerializer.SerializeToNode(value.Value, options),
                    "input_error" => JsonSerializer.SerializeToNode(value.Value, options),
                    "transcriber_error" => JsonSerializer.SerializeToNode(value.Value, options),
                    "translation_error" => JsonSerializer.SerializeToNode(value.Value, options),
                    "audio_output_error" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["message_type"] = value.MessageType;
            json.WriteTo(writer, options);
        }

        public override ReceiveDubbingStreamMessage ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new ReceiveDubbingStreamMessage(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReceiveDubbingStreamMessage value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.MessageType);
        }
    }

    /// <summary>
    /// Discriminated union type for session_started
    /// </summary>
    [Serializable]
    public struct SessionStarted
    {
        public SessionStarted(global::ElevenLabs.DubbingSessionStarted value)
        {
            Value = value;
        }

        internal global::ElevenLabs.DubbingSessionStarted Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveDubbingStreamMessage.SessionStarted(
            global::ElevenLabs.DubbingSessionStarted value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for status
    /// </summary>
    [Serializable]
    public struct Status
    {
        public Status(global::ElevenLabs.DubbingStatus value)
        {
            Value = value;
        }

        internal global::ElevenLabs.DubbingStatus Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveDubbingStreamMessage.Status(
            global::ElevenLabs.DubbingStatus value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for partial_transcript
    /// </summary>
    [Serializable]
    public struct PartialTranscript
    {
        public PartialTranscript(global::ElevenLabs.DubbingPartialTranscript value)
        {
            Value = value;
        }

        internal global::ElevenLabs.DubbingPartialTranscript Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveDubbingStreamMessage.PartialTranscript(
            global::ElevenLabs.DubbingPartialTranscript value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for committed_transcript
    /// </summary>
    [Serializable]
    public struct CommittedTranscript
    {
        public CommittedTranscript(global::ElevenLabs.DubbingCommittedTranscript value)
        {
            Value = value;
        }

        internal global::ElevenLabs.DubbingCommittedTranscript Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveDubbingStreamMessage.CommittedTranscript(
            global::ElevenLabs.DubbingCommittedTranscript value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for translation
    /// </summary>
    [Serializable]
    public struct Translation
    {
        public Translation(global::ElevenLabs.DubbingTranslation value)
        {
            Value = value;
        }

        internal global::ElevenLabs.DubbingTranslation Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveDubbingStreamMessage.Translation(
            global::ElevenLabs.DubbingTranslation value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for audio
    /// </summary>
    [Serializable]
    public struct Audio
    {
        public Audio(global::ElevenLabs.DubbingAudio value)
        {
            Value = value;
        }

        internal global::ElevenLabs.DubbingAudio Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveDubbingStreamMessage.Audio(
            global::ElevenLabs.DubbingAudio value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for error
    /// </summary>
    [Serializable]
    public struct Error
    {
        public Error(global::ElevenLabs.DubbingErrorPayload value)
        {
            Value = value;
        }

        internal global::ElevenLabs.DubbingErrorPayload Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveDubbingStreamMessage.Error(
            global::ElevenLabs.DubbingErrorPayload value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for auth_error
    /// </summary>
    [Serializable]
    public struct AuthError
    {
        public AuthError(global::ElevenLabs.DubbingAuthError value)
        {
            Value = value;
        }

        internal global::ElevenLabs.DubbingAuthError Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveDubbingStreamMessage.AuthError(
            global::ElevenLabs.DubbingAuthError value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for rate_limited
    /// </summary>
    [Serializable]
    public struct RateLimited
    {
        public RateLimited(global::ElevenLabs.DubbingRateLimitedError value)
        {
            Value = value;
        }

        internal global::ElevenLabs.DubbingRateLimitedError Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveDubbingStreamMessage.RateLimited(
            global::ElevenLabs.DubbingRateLimitedError value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for queue_overflow
    /// </summary>
    [Serializable]
    public struct QueueOverflow
    {
        public QueueOverflow(global::ElevenLabs.DubbingQueueOverflowError value)
        {
            Value = value;
        }

        internal global::ElevenLabs.DubbingQueueOverflowError Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveDubbingStreamMessage.QueueOverflow(
            global::ElevenLabs.DubbingQueueOverflowError value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for invalid_request
    /// </summary>
    [Serializable]
    public struct InvalidRequest
    {
        public InvalidRequest(global::ElevenLabs.DubbingInvalidRequestError value)
        {
            Value = value;
        }

        internal global::ElevenLabs.DubbingInvalidRequestError Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveDubbingStreamMessage.InvalidRequest(
            global::ElevenLabs.DubbingInvalidRequestError value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for input_error
    /// </summary>
    [Serializable]
    public struct InputError
    {
        public InputError(global::ElevenLabs.DubbingInputError value)
        {
            Value = value;
        }

        internal global::ElevenLabs.DubbingInputError Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveDubbingStreamMessage.InputError(
            global::ElevenLabs.DubbingInputError value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for transcriber_error
    /// </summary>
    [Serializable]
    public struct TranscriberError
    {
        public TranscriberError(global::ElevenLabs.DubbingTranscriberError value)
        {
            Value = value;
        }

        internal global::ElevenLabs.DubbingTranscriberError Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveDubbingStreamMessage.TranscriberError(
            global::ElevenLabs.DubbingTranscriberError value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for translation_error
    /// </summary>
    [Serializable]
    public struct TranslationError
    {
        public TranslationError(global::ElevenLabs.DubbingTranslationError value)
        {
            Value = value;
        }

        internal global::ElevenLabs.DubbingTranslationError Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveDubbingStreamMessage.TranslationError(
            global::ElevenLabs.DubbingTranslationError value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for audio_output_error
    /// </summary>
    [Serializable]
    public struct AudioOutputError
    {
        public AudioOutputError(global::ElevenLabs.DubbingAudioOutputError value)
        {
            Value = value;
        }

        internal global::ElevenLabs.DubbingAudioOutputError Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveDubbingStreamMessage.AudioOutputError(
            global::ElevenLabs.DubbingAudioOutputError value
        ) => new(value);
    }
}
