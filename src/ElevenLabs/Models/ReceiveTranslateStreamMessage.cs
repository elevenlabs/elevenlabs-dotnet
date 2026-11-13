// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ReceiveTranslateStreamMessage.JsonConverter))]
[Serializable]
public record ReceiveTranslateStreamMessage
{
    internal ReceiveTranslateStreamMessage(string type, object? value)
    {
        MessageType = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of ReceiveTranslateStreamMessage with <see cref="ReceiveTranslateStreamMessage.SessionStarted"/>.
    /// </summary>
    public ReceiveTranslateStreamMessage(ReceiveTranslateStreamMessage.SessionStarted value)
    {
        MessageType = "session_started";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveTranslateStreamMessage with <see cref="ReceiveTranslateStreamMessage.Status"/>.
    /// </summary>
    public ReceiveTranslateStreamMessage(ReceiveTranslateStreamMessage.Status value)
    {
        MessageType = "status";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveTranslateStreamMessage with <see cref="ReceiveTranslateStreamMessage.PartialTranscript"/>.
    /// </summary>
    public ReceiveTranslateStreamMessage(ReceiveTranslateStreamMessage.PartialTranscript value)
    {
        MessageType = "partial_transcript";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveTranslateStreamMessage with <see cref="ReceiveTranslateStreamMessage.FinalTranscript"/>.
    /// </summary>
    public ReceiveTranslateStreamMessage(ReceiveTranslateStreamMessage.FinalTranscript value)
    {
        MessageType = "final_transcript";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveTranslateStreamMessage with <see cref="ReceiveTranslateStreamMessage.Translation"/>.
    /// </summary>
    public ReceiveTranslateStreamMessage(ReceiveTranslateStreamMessage.Translation value)
    {
        MessageType = "translation";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveTranslateStreamMessage with <see cref="ReceiveTranslateStreamMessage.Audio"/>.
    /// </summary>
    public ReceiveTranslateStreamMessage(ReceiveTranslateStreamMessage.Audio value)
    {
        MessageType = "audio";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveTranslateStreamMessage with <see cref="ReceiveTranslateStreamMessage.Error"/>.
    /// </summary>
    public ReceiveTranslateStreamMessage(ReceiveTranslateStreamMessage.Error value)
    {
        MessageType = "error";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveTranslateStreamMessage with <see cref="ReceiveTranslateStreamMessage.AuthError"/>.
    /// </summary>
    public ReceiveTranslateStreamMessage(ReceiveTranslateStreamMessage.AuthError value)
    {
        MessageType = "auth_error";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveTranslateStreamMessage with <see cref="ReceiveTranslateStreamMessage.RateLimited"/>.
    /// </summary>
    public ReceiveTranslateStreamMessage(ReceiveTranslateStreamMessage.RateLimited value)
    {
        MessageType = "rate_limited";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveTranslateStreamMessage with <see cref="ReceiveTranslateStreamMessage.QueueOverflow"/>.
    /// </summary>
    public ReceiveTranslateStreamMessage(ReceiveTranslateStreamMessage.QueueOverflow value)
    {
        MessageType = "queue_overflow";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveTranslateStreamMessage with <see cref="ReceiveTranslateStreamMessage.InputError"/>.
    /// </summary>
    public ReceiveTranslateStreamMessage(ReceiveTranslateStreamMessage.InputError value)
    {
        MessageType = "input_error";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveTranslateStreamMessage with <see cref="ReceiveTranslateStreamMessage.TranscriberError"/>.
    /// </summary>
    public ReceiveTranslateStreamMessage(ReceiveTranslateStreamMessage.TranscriberError value)
    {
        MessageType = "transcriber_error";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveTranslateStreamMessage with <see cref="ReceiveTranslateStreamMessage.TranslationError"/>.
    /// </summary>
    public ReceiveTranslateStreamMessage(ReceiveTranslateStreamMessage.TranslationError value)
    {
        MessageType = "translation_error";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveTranslateStreamMessage with <see cref="ReceiveTranslateStreamMessage.AudioOutputError"/>.
    /// </summary>
    public ReceiveTranslateStreamMessage(ReceiveTranslateStreamMessage.AudioOutputError value)
    {
        MessageType = "audio_output_error";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveTranslateStreamMessage with <see cref="ReceiveTranslateStreamMessage.QuotaExceeded"/>.
    /// </summary>
    public ReceiveTranslateStreamMessage(ReceiveTranslateStreamMessage.QuotaExceeded value)
    {
        MessageType = "quota_exceeded";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveTranslateStreamMessage with <see cref="ReceiveTranslateStreamMessage.PaymentIssue"/>.
    /// </summary>
    public ReceiveTranslateStreamMessage(ReceiveTranslateStreamMessage.PaymentIssue value)
    {
        MessageType = "payment_issue";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveTranslateStreamMessage with <see cref="ReceiveTranslateStreamMessage.UnacceptedTerms"/>.
    /// </summary>
    public ReceiveTranslateStreamMessage(ReceiveTranslateStreamMessage.UnacceptedTerms value)
    {
        MessageType = "unaccepted_terms";
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
    /// Returns true if <see cref="MessageType"/> is "final_transcript"
    /// </summary>
    public bool IsFinalTranscript => MessageType == "final_transcript";

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
    /// Returns true if <see cref="MessageType"/> is "quota_exceeded"
    /// </summary>
    public bool IsQuotaExceeded => MessageType == "quota_exceeded";

    /// <summary>
    /// Returns true if <see cref="MessageType"/> is "payment_issue"
    /// </summary>
    public bool IsPaymentIssue => MessageType == "payment_issue";

    /// <summary>
    /// Returns true if <see cref="MessageType"/> is "unaccepted_terms"
    /// </summary>
    public bool IsUnacceptedTerms => MessageType == "unaccepted_terms";

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TranslateSessionStarted"/> if <see cref="MessageType"/> is 'session_started', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'session_started'.</exception>
    public global::ElevenLabs.TranslateSessionStarted AsSessionStarted() =>
        IsSessionStarted
            ? (global::ElevenLabs.TranslateSessionStarted)Value!
            : throw new global::System.Exception(
                "ReceiveTranslateStreamMessage.MessageType is not 'session_started'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TranslateStatus"/> if <see cref="MessageType"/> is 'status', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'status'.</exception>
    public global::ElevenLabs.TranslateStatus AsStatus() =>
        IsStatus
            ? (global::ElevenLabs.TranslateStatus)Value!
            : throw new global::System.Exception(
                "ReceiveTranslateStreamMessage.MessageType is not 'status'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TranslatePartialTranscript"/> if <see cref="MessageType"/> is 'partial_transcript', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'partial_transcript'.</exception>
    public global::ElevenLabs.TranslatePartialTranscript AsPartialTranscript() =>
        IsPartialTranscript
            ? (global::ElevenLabs.TranslatePartialTranscript)Value!
            : throw new global::System.Exception(
                "ReceiveTranslateStreamMessage.MessageType is not 'partial_transcript'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TranslateFinalTranscript"/> if <see cref="MessageType"/> is 'final_transcript', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'final_transcript'.</exception>
    public global::ElevenLabs.TranslateFinalTranscript AsFinalTranscript() =>
        IsFinalTranscript
            ? (global::ElevenLabs.TranslateFinalTranscript)Value!
            : throw new global::System.Exception(
                "ReceiveTranslateStreamMessage.MessageType is not 'final_transcript'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TranslateTranslation"/> if <see cref="MessageType"/> is 'translation', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'translation'.</exception>
    public global::ElevenLabs.TranslateTranslation AsTranslation() =>
        IsTranslation
            ? (global::ElevenLabs.TranslateTranslation)Value!
            : throw new global::System.Exception(
                "ReceiveTranslateStreamMessage.MessageType is not 'translation'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TranslateAudio"/> if <see cref="MessageType"/> is 'audio', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'audio'.</exception>
    public global::ElevenLabs.TranslateAudio AsAudio() =>
        IsAudio
            ? (global::ElevenLabs.TranslateAudio)Value!
            : throw new global::System.Exception(
                "ReceiveTranslateStreamMessage.MessageType is not 'audio'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TranslateError"/> if <see cref="MessageType"/> is 'error', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'error'.</exception>
    public global::ElevenLabs.TranslateError AsError() =>
        IsError
            ? (global::ElevenLabs.TranslateError)Value!
            : throw new global::System.Exception(
                "ReceiveTranslateStreamMessage.MessageType is not 'error'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TranslateAuthError"/> if <see cref="MessageType"/> is 'auth_error', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'auth_error'.</exception>
    public global::ElevenLabs.TranslateAuthError AsAuthError() =>
        IsAuthError
            ? (global::ElevenLabs.TranslateAuthError)Value!
            : throw new global::System.Exception(
                "ReceiveTranslateStreamMessage.MessageType is not 'auth_error'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TranslateRateLimitedError"/> if <see cref="MessageType"/> is 'rate_limited', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'rate_limited'.</exception>
    public global::ElevenLabs.TranslateRateLimitedError AsRateLimited() =>
        IsRateLimited
            ? (global::ElevenLabs.TranslateRateLimitedError)Value!
            : throw new global::System.Exception(
                "ReceiveTranslateStreamMessage.MessageType is not 'rate_limited'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TranslateQueueOverflowError"/> if <see cref="MessageType"/> is 'queue_overflow', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'queue_overflow'.</exception>
    public global::ElevenLabs.TranslateQueueOverflowError AsQueueOverflow() =>
        IsQueueOverflow
            ? (global::ElevenLabs.TranslateQueueOverflowError)Value!
            : throw new global::System.Exception(
                "ReceiveTranslateStreamMessage.MessageType is not 'queue_overflow'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TranslateInputError"/> if <see cref="MessageType"/> is 'input_error', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'input_error'.</exception>
    public global::ElevenLabs.TranslateInputError AsInputError() =>
        IsInputError
            ? (global::ElevenLabs.TranslateInputError)Value!
            : throw new global::System.Exception(
                "ReceiveTranslateStreamMessage.MessageType is not 'input_error'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TranslateTranscriberError"/> if <see cref="MessageType"/> is 'transcriber_error', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'transcriber_error'.</exception>
    public global::ElevenLabs.TranslateTranscriberError AsTranscriberError() =>
        IsTranscriberError
            ? (global::ElevenLabs.TranslateTranscriberError)Value!
            : throw new global::System.Exception(
                "ReceiveTranslateStreamMessage.MessageType is not 'transcriber_error'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TranslateTranslationError"/> if <see cref="MessageType"/> is 'translation_error', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'translation_error'.</exception>
    public global::ElevenLabs.TranslateTranslationError AsTranslationError() =>
        IsTranslationError
            ? (global::ElevenLabs.TranslateTranslationError)Value!
            : throw new global::System.Exception(
                "ReceiveTranslateStreamMessage.MessageType is not 'translation_error'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TranslateAudioOutputError"/> if <see cref="MessageType"/> is 'audio_output_error', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'audio_output_error'.</exception>
    public global::ElevenLabs.TranslateAudioOutputError AsAudioOutputError() =>
        IsAudioOutputError
            ? (global::ElevenLabs.TranslateAudioOutputError)Value!
            : throw new global::System.Exception(
                "ReceiveTranslateStreamMessage.MessageType is not 'audio_output_error'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TranslateQuotaExceededError"/> if <see cref="MessageType"/> is 'quota_exceeded', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'quota_exceeded'.</exception>
    public global::ElevenLabs.TranslateQuotaExceededError AsQuotaExceeded() =>
        IsQuotaExceeded
            ? (global::ElevenLabs.TranslateQuotaExceededError)Value!
            : throw new global::System.Exception(
                "ReceiveTranslateStreamMessage.MessageType is not 'quota_exceeded'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TranslatePaymentIssueError"/> if <see cref="MessageType"/> is 'payment_issue', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'payment_issue'.</exception>
    public global::ElevenLabs.TranslatePaymentIssueError AsPaymentIssue() =>
        IsPaymentIssue
            ? (global::ElevenLabs.TranslatePaymentIssueError)Value!
            : throw new global::System.Exception(
                "ReceiveTranslateStreamMessage.MessageType is not 'payment_issue'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.TranslateUnacceptedTermsError"/> if <see cref="MessageType"/> is 'unaccepted_terms', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'unaccepted_terms'.</exception>
    public global::ElevenLabs.TranslateUnacceptedTermsError AsUnacceptedTerms() =>
        IsUnacceptedTerms
            ? (global::ElevenLabs.TranslateUnacceptedTermsError)Value!
            : throw new global::System.Exception(
                "ReceiveTranslateStreamMessage.MessageType is not 'unaccepted_terms'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.TranslateSessionStarted, T> onSessionStarted,
        Func<global::ElevenLabs.TranslateStatus, T> onStatus,
        Func<global::ElevenLabs.TranslatePartialTranscript, T> onPartialTranscript,
        Func<global::ElevenLabs.TranslateFinalTranscript, T> onFinalTranscript,
        Func<global::ElevenLabs.TranslateTranslation, T> onTranslation,
        Func<global::ElevenLabs.TranslateAudio, T> onAudio,
        Func<global::ElevenLabs.TranslateError, T> onError,
        Func<global::ElevenLabs.TranslateAuthError, T> onAuthError,
        Func<global::ElevenLabs.TranslateRateLimitedError, T> onRateLimited,
        Func<global::ElevenLabs.TranslateQueueOverflowError, T> onQueueOverflow,
        Func<global::ElevenLabs.TranslateInputError, T> onInputError,
        Func<global::ElevenLabs.TranslateTranscriberError, T> onTranscriberError,
        Func<global::ElevenLabs.TranslateTranslationError, T> onTranslationError,
        Func<global::ElevenLabs.TranslateAudioOutputError, T> onAudioOutputError,
        Func<global::ElevenLabs.TranslateQuotaExceededError, T> onQuotaExceeded,
        Func<global::ElevenLabs.TranslatePaymentIssueError, T> onPaymentIssue,
        Func<global::ElevenLabs.TranslateUnacceptedTermsError, T> onUnacceptedTerms,
        Func<string, object?, T> onUnknown_
    )
    {
        return MessageType switch
        {
            "session_started" => onSessionStarted(AsSessionStarted()),
            "status" => onStatus(AsStatus()),
            "partial_transcript" => onPartialTranscript(AsPartialTranscript()),
            "final_transcript" => onFinalTranscript(AsFinalTranscript()),
            "translation" => onTranslation(AsTranslation()),
            "audio" => onAudio(AsAudio()),
            "error" => onError(AsError()),
            "auth_error" => onAuthError(AsAuthError()),
            "rate_limited" => onRateLimited(AsRateLimited()),
            "queue_overflow" => onQueueOverflow(AsQueueOverflow()),
            "input_error" => onInputError(AsInputError()),
            "transcriber_error" => onTranscriberError(AsTranscriberError()),
            "translation_error" => onTranslationError(AsTranslationError()),
            "audio_output_error" => onAudioOutputError(AsAudioOutputError()),
            "quota_exceeded" => onQuotaExceeded(AsQuotaExceeded()),
            "payment_issue" => onPaymentIssue(AsPaymentIssue()),
            "unaccepted_terms" => onUnacceptedTerms(AsUnacceptedTerms()),
            _ => onUnknown_(MessageType, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.TranslateSessionStarted> onSessionStarted,
        Action<global::ElevenLabs.TranslateStatus> onStatus,
        Action<global::ElevenLabs.TranslatePartialTranscript> onPartialTranscript,
        Action<global::ElevenLabs.TranslateFinalTranscript> onFinalTranscript,
        Action<global::ElevenLabs.TranslateTranslation> onTranslation,
        Action<global::ElevenLabs.TranslateAudio> onAudio,
        Action<global::ElevenLabs.TranslateError> onError,
        Action<global::ElevenLabs.TranslateAuthError> onAuthError,
        Action<global::ElevenLabs.TranslateRateLimitedError> onRateLimited,
        Action<global::ElevenLabs.TranslateQueueOverflowError> onQueueOverflow,
        Action<global::ElevenLabs.TranslateInputError> onInputError,
        Action<global::ElevenLabs.TranslateTranscriberError> onTranscriberError,
        Action<global::ElevenLabs.TranslateTranslationError> onTranslationError,
        Action<global::ElevenLabs.TranslateAudioOutputError> onAudioOutputError,
        Action<global::ElevenLabs.TranslateQuotaExceededError> onQuotaExceeded,
        Action<global::ElevenLabs.TranslatePaymentIssueError> onPaymentIssue,
        Action<global::ElevenLabs.TranslateUnacceptedTermsError> onUnacceptedTerms,
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
            case "final_transcript":
                onFinalTranscript(AsFinalTranscript());
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
            case "quota_exceeded":
                onQuotaExceeded(AsQuotaExceeded());
                break;
            case "payment_issue":
                onPaymentIssue(AsPaymentIssue());
                break;
            case "unaccepted_terms":
                onUnacceptedTerms(AsUnacceptedTerms());
                break;
            default:
                onUnknown_(MessageType, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TranslateSessionStarted"/> and returns true if successful.
    /// </summary>
    public bool TryAsSessionStarted(out global::ElevenLabs.TranslateSessionStarted? value)
    {
        if (MessageType == "session_started")
        {
            value = (global::ElevenLabs.TranslateSessionStarted)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TranslateStatus"/> and returns true if successful.
    /// </summary>
    public bool TryAsStatus(out global::ElevenLabs.TranslateStatus? value)
    {
        if (MessageType == "status")
        {
            value = (global::ElevenLabs.TranslateStatus)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TranslatePartialTranscript"/> and returns true if successful.
    /// </summary>
    public bool TryAsPartialTranscript(out global::ElevenLabs.TranslatePartialTranscript? value)
    {
        if (MessageType == "partial_transcript")
        {
            value = (global::ElevenLabs.TranslatePartialTranscript)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TranslateFinalTranscript"/> and returns true if successful.
    /// </summary>
    public bool TryAsFinalTranscript(out global::ElevenLabs.TranslateFinalTranscript? value)
    {
        if (MessageType == "final_transcript")
        {
            value = (global::ElevenLabs.TranslateFinalTranscript)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TranslateTranslation"/> and returns true if successful.
    /// </summary>
    public bool TryAsTranslation(out global::ElevenLabs.TranslateTranslation? value)
    {
        if (MessageType == "translation")
        {
            value = (global::ElevenLabs.TranslateTranslation)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TranslateAudio"/> and returns true if successful.
    /// </summary>
    public bool TryAsAudio(out global::ElevenLabs.TranslateAudio? value)
    {
        if (MessageType == "audio")
        {
            value = (global::ElevenLabs.TranslateAudio)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TranslateError"/> and returns true if successful.
    /// </summary>
    public bool TryAsError(out global::ElevenLabs.TranslateError? value)
    {
        if (MessageType == "error")
        {
            value = (global::ElevenLabs.TranslateError)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TranslateAuthError"/> and returns true if successful.
    /// </summary>
    public bool TryAsAuthError(out global::ElevenLabs.TranslateAuthError? value)
    {
        if (MessageType == "auth_error")
        {
            value = (global::ElevenLabs.TranslateAuthError)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TranslateRateLimitedError"/> and returns true if successful.
    /// </summary>
    public bool TryAsRateLimited(out global::ElevenLabs.TranslateRateLimitedError? value)
    {
        if (MessageType == "rate_limited")
        {
            value = (global::ElevenLabs.TranslateRateLimitedError)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TranslateQueueOverflowError"/> and returns true if successful.
    /// </summary>
    public bool TryAsQueueOverflow(out global::ElevenLabs.TranslateQueueOverflowError? value)
    {
        if (MessageType == "queue_overflow")
        {
            value = (global::ElevenLabs.TranslateQueueOverflowError)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TranslateInputError"/> and returns true if successful.
    /// </summary>
    public bool TryAsInputError(out global::ElevenLabs.TranslateInputError? value)
    {
        if (MessageType == "input_error")
        {
            value = (global::ElevenLabs.TranslateInputError)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TranslateTranscriberError"/> and returns true if successful.
    /// </summary>
    public bool TryAsTranscriberError(out global::ElevenLabs.TranslateTranscriberError? value)
    {
        if (MessageType == "transcriber_error")
        {
            value = (global::ElevenLabs.TranslateTranscriberError)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TranslateTranslationError"/> and returns true if successful.
    /// </summary>
    public bool TryAsTranslationError(out global::ElevenLabs.TranslateTranslationError? value)
    {
        if (MessageType == "translation_error")
        {
            value = (global::ElevenLabs.TranslateTranslationError)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TranslateAudioOutputError"/> and returns true if successful.
    /// </summary>
    public bool TryAsAudioOutputError(out global::ElevenLabs.TranslateAudioOutputError? value)
    {
        if (MessageType == "audio_output_error")
        {
            value = (global::ElevenLabs.TranslateAudioOutputError)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TranslateQuotaExceededError"/> and returns true if successful.
    /// </summary>
    public bool TryAsQuotaExceeded(out global::ElevenLabs.TranslateQuotaExceededError? value)
    {
        if (MessageType == "quota_exceeded")
        {
            value = (global::ElevenLabs.TranslateQuotaExceededError)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TranslatePaymentIssueError"/> and returns true if successful.
    /// </summary>
    public bool TryAsPaymentIssue(out global::ElevenLabs.TranslatePaymentIssueError? value)
    {
        if (MessageType == "payment_issue")
        {
            value = (global::ElevenLabs.TranslatePaymentIssueError)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.TranslateUnacceptedTermsError"/> and returns true if successful.
    /// </summary>
    public bool TryAsUnacceptedTerms(out global::ElevenLabs.TranslateUnacceptedTermsError? value)
    {
        if (MessageType == "unaccepted_terms")
        {
            value = (global::ElevenLabs.TranslateUnacceptedTermsError)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator ReceiveTranslateStreamMessage(
        ReceiveTranslateStreamMessage.SessionStarted value
    ) => new(value);

    public static implicit operator ReceiveTranslateStreamMessage(
        ReceiveTranslateStreamMessage.Status value
    ) => new(value);

    public static implicit operator ReceiveTranslateStreamMessage(
        ReceiveTranslateStreamMessage.PartialTranscript value
    ) => new(value);

    public static implicit operator ReceiveTranslateStreamMessage(
        ReceiveTranslateStreamMessage.FinalTranscript value
    ) => new(value);

    public static implicit operator ReceiveTranslateStreamMessage(
        ReceiveTranslateStreamMessage.Translation value
    ) => new(value);

    public static implicit operator ReceiveTranslateStreamMessage(
        ReceiveTranslateStreamMessage.Audio value
    ) => new(value);

    public static implicit operator ReceiveTranslateStreamMessage(
        ReceiveTranslateStreamMessage.Error value
    ) => new(value);

    public static implicit operator ReceiveTranslateStreamMessage(
        ReceiveTranslateStreamMessage.AuthError value
    ) => new(value);

    public static implicit operator ReceiveTranslateStreamMessage(
        ReceiveTranslateStreamMessage.RateLimited value
    ) => new(value);

    public static implicit operator ReceiveTranslateStreamMessage(
        ReceiveTranslateStreamMessage.QueueOverflow value
    ) => new(value);

    public static implicit operator ReceiveTranslateStreamMessage(
        ReceiveTranslateStreamMessage.InputError value
    ) => new(value);

    public static implicit operator ReceiveTranslateStreamMessage(
        ReceiveTranslateStreamMessage.TranscriberError value
    ) => new(value);

    public static implicit operator ReceiveTranslateStreamMessage(
        ReceiveTranslateStreamMessage.TranslationError value
    ) => new(value);

    public static implicit operator ReceiveTranslateStreamMessage(
        ReceiveTranslateStreamMessage.AudioOutputError value
    ) => new(value);

    public static implicit operator ReceiveTranslateStreamMessage(
        ReceiveTranslateStreamMessage.QuotaExceeded value
    ) => new(value);

    public static implicit operator ReceiveTranslateStreamMessage(
        ReceiveTranslateStreamMessage.PaymentIssue value
    ) => new(value);

    public static implicit operator ReceiveTranslateStreamMessage(
        ReceiveTranslateStreamMessage.UnacceptedTerms value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<ReceiveTranslateStreamMessage>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(ReceiveTranslateStreamMessage).IsAssignableFrom(typeToConvert);

        public override ReceiveTranslateStreamMessage Read(
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
                "session_started" => json.Deserialize<global::ElevenLabs.TranslateSessionStarted?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.TranslateSessionStarted"
                    ),
                "status" => json.Deserialize<global::ElevenLabs.TranslateStatus?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.TranslateStatus"
                    ),
                "partial_transcript" =>
                    json.Deserialize<global::ElevenLabs.TranslatePartialTranscript?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.TranslatePartialTranscript"
                        ),
                "final_transcript" =>
                    json.Deserialize<global::ElevenLabs.TranslateFinalTranscript?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.TranslateFinalTranscript"
                        ),
                "translation" => json.Deserialize<global::ElevenLabs.TranslateTranslation?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.TranslateTranslation"
                    ),
                "audio" => json.Deserialize<global::ElevenLabs.TranslateAudio?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.TranslateAudio"
                    ),
                "error" => json.Deserialize<global::ElevenLabs.TranslateError?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.TranslateError"
                    ),
                "auth_error" => json.Deserialize<global::ElevenLabs.TranslateAuthError?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.TranslateAuthError"
                    ),
                "rate_limited" => json.Deserialize<global::ElevenLabs.TranslateRateLimitedError?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.TranslateRateLimitedError"
                    ),
                "queue_overflow" =>
                    json.Deserialize<global::ElevenLabs.TranslateQueueOverflowError?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.TranslateQueueOverflowError"
                        ),
                "input_error" => json.Deserialize<global::ElevenLabs.TranslateInputError?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.TranslateInputError"
                    ),
                "transcriber_error" =>
                    json.Deserialize<global::ElevenLabs.TranslateTranscriberError?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.TranslateTranscriberError"
                        ),
                "translation_error" =>
                    json.Deserialize<global::ElevenLabs.TranslateTranslationError?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.TranslateTranslationError"
                        ),
                "audio_output_error" =>
                    json.Deserialize<global::ElevenLabs.TranslateAudioOutputError?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.TranslateAudioOutputError"
                        ),
                "quota_exceeded" =>
                    json.Deserialize<global::ElevenLabs.TranslateQuotaExceededError?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.TranslateQuotaExceededError"
                        ),
                "payment_issue" => json.Deserialize<global::ElevenLabs.TranslatePaymentIssueError?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.TranslatePaymentIssueError"
                    ),
                "unaccepted_terms" =>
                    json.Deserialize<global::ElevenLabs.TranslateUnacceptedTermsError?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.TranslateUnacceptedTermsError"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new ReceiveTranslateStreamMessage(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReceiveTranslateStreamMessage value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.MessageType switch
                {
                    "session_started" => JsonSerializer.SerializeToNode(value.Value, options),
                    "status" => JsonSerializer.SerializeToNode(value.Value, options),
                    "partial_transcript" => JsonSerializer.SerializeToNode(value.Value, options),
                    "final_transcript" => JsonSerializer.SerializeToNode(value.Value, options),
                    "translation" => JsonSerializer.SerializeToNode(value.Value, options),
                    "audio" => JsonSerializer.SerializeToNode(value.Value, options),
                    "error" => JsonSerializer.SerializeToNode(value.Value, options),
                    "auth_error" => JsonSerializer.SerializeToNode(value.Value, options),
                    "rate_limited" => JsonSerializer.SerializeToNode(value.Value, options),
                    "queue_overflow" => JsonSerializer.SerializeToNode(value.Value, options),
                    "input_error" => JsonSerializer.SerializeToNode(value.Value, options),
                    "transcriber_error" => JsonSerializer.SerializeToNode(value.Value, options),
                    "translation_error" => JsonSerializer.SerializeToNode(value.Value, options),
                    "audio_output_error" => JsonSerializer.SerializeToNode(value.Value, options),
                    "quota_exceeded" => JsonSerializer.SerializeToNode(value.Value, options),
                    "payment_issue" => JsonSerializer.SerializeToNode(value.Value, options),
                    "unaccepted_terms" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["message_type"] = value.MessageType;
            json.WriteTo(writer, options);
        }

        public override ReceiveTranslateStreamMessage ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new ReceiveTranslateStreamMessage(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReceiveTranslateStreamMessage value,
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
        public SessionStarted(global::ElevenLabs.TranslateSessionStarted value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TranslateSessionStarted Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveTranslateStreamMessage.SessionStarted(
            global::ElevenLabs.TranslateSessionStarted value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for status
    /// </summary>
    [Serializable]
    public struct Status
    {
        public Status(global::ElevenLabs.TranslateStatus value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TranslateStatus Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveTranslateStreamMessage.Status(
            global::ElevenLabs.TranslateStatus value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for partial_transcript
    /// </summary>
    [Serializable]
    public struct PartialTranscript
    {
        public PartialTranscript(global::ElevenLabs.TranslatePartialTranscript value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TranslatePartialTranscript Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveTranslateStreamMessage.PartialTranscript(
            global::ElevenLabs.TranslatePartialTranscript value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for final_transcript
    /// </summary>
    [Serializable]
    public struct FinalTranscript
    {
        public FinalTranscript(global::ElevenLabs.TranslateFinalTranscript value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TranslateFinalTranscript Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveTranslateStreamMessage.FinalTranscript(
            global::ElevenLabs.TranslateFinalTranscript value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for translation
    /// </summary>
    [Serializable]
    public struct Translation
    {
        public Translation(global::ElevenLabs.TranslateTranslation value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TranslateTranslation Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveTranslateStreamMessage.Translation(
            global::ElevenLabs.TranslateTranslation value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for audio
    /// </summary>
    [Serializable]
    public struct Audio
    {
        public Audio(global::ElevenLabs.TranslateAudio value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TranslateAudio Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveTranslateStreamMessage.Audio(
            global::ElevenLabs.TranslateAudio value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for error
    /// </summary>
    [Serializable]
    public struct Error
    {
        public Error(global::ElevenLabs.TranslateError value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TranslateError Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveTranslateStreamMessage.Error(
            global::ElevenLabs.TranslateError value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for auth_error
    /// </summary>
    [Serializable]
    public struct AuthError
    {
        public AuthError(global::ElevenLabs.TranslateAuthError value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TranslateAuthError Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveTranslateStreamMessage.AuthError(
            global::ElevenLabs.TranslateAuthError value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for rate_limited
    /// </summary>
    [Serializable]
    public struct RateLimited
    {
        public RateLimited(global::ElevenLabs.TranslateRateLimitedError value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TranslateRateLimitedError Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveTranslateStreamMessage.RateLimited(
            global::ElevenLabs.TranslateRateLimitedError value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for queue_overflow
    /// </summary>
    [Serializable]
    public struct QueueOverflow
    {
        public QueueOverflow(global::ElevenLabs.TranslateQueueOverflowError value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TranslateQueueOverflowError Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveTranslateStreamMessage.QueueOverflow(
            global::ElevenLabs.TranslateQueueOverflowError value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for input_error
    /// </summary>
    [Serializable]
    public struct InputError
    {
        public InputError(global::ElevenLabs.TranslateInputError value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TranslateInputError Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveTranslateStreamMessage.InputError(
            global::ElevenLabs.TranslateInputError value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for transcriber_error
    /// </summary>
    [Serializable]
    public struct TranscriberError
    {
        public TranscriberError(global::ElevenLabs.TranslateTranscriberError value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TranslateTranscriberError Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveTranslateStreamMessage.TranscriberError(
            global::ElevenLabs.TranslateTranscriberError value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for translation_error
    /// </summary>
    [Serializable]
    public struct TranslationError
    {
        public TranslationError(global::ElevenLabs.TranslateTranslationError value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TranslateTranslationError Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveTranslateStreamMessage.TranslationError(
            global::ElevenLabs.TranslateTranslationError value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for audio_output_error
    /// </summary>
    [Serializable]
    public struct AudioOutputError
    {
        public AudioOutputError(global::ElevenLabs.TranslateAudioOutputError value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TranslateAudioOutputError Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveTranslateStreamMessage.AudioOutputError(
            global::ElevenLabs.TranslateAudioOutputError value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for quota_exceeded
    /// </summary>
    [Serializable]
    public struct QuotaExceeded
    {
        public QuotaExceeded(global::ElevenLabs.TranslateQuotaExceededError value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TranslateQuotaExceededError Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveTranslateStreamMessage.QuotaExceeded(
            global::ElevenLabs.TranslateQuotaExceededError value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for payment_issue
    /// </summary>
    [Serializable]
    public struct PaymentIssue
    {
        public PaymentIssue(global::ElevenLabs.TranslatePaymentIssueError value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TranslatePaymentIssueError Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveTranslateStreamMessage.PaymentIssue(
            global::ElevenLabs.TranslatePaymentIssueError value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for unaccepted_terms
    /// </summary>
    [Serializable]
    public struct UnacceptedTerms
    {
        public UnacceptedTerms(global::ElevenLabs.TranslateUnacceptedTermsError value)
        {
            Value = value;
        }

        internal global::ElevenLabs.TranslateUnacceptedTermsError Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveTranslateStreamMessage.UnacceptedTerms(
            global::ElevenLabs.TranslateUnacceptedTermsError value
        ) => new(value);
    }
}
