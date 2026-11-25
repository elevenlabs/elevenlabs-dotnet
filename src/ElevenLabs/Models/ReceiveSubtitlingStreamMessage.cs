// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ReceiveSubtitlingStreamMessage.JsonConverter))]
[Serializable]
public record ReceiveSubtitlingStreamMessage
{
    internal ReceiveSubtitlingStreamMessage(string type, object? value)
    {
        MessageType = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of ReceiveSubtitlingStreamMessage with <see cref="ReceiveSubtitlingStreamMessage.SessionStarted"/>.
    /// </summary>
    public ReceiveSubtitlingStreamMessage(ReceiveSubtitlingStreamMessage.SessionStarted value)
    {
        MessageType = "session_started";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveSubtitlingStreamMessage with <see cref="ReceiveSubtitlingStreamMessage.Status"/>.
    /// </summary>
    public ReceiveSubtitlingStreamMessage(ReceiveSubtitlingStreamMessage.Status value)
    {
        MessageType = "status";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveSubtitlingStreamMessage with <see cref="ReceiveSubtitlingStreamMessage.PartialTranscript"/>.
    /// </summary>
    public ReceiveSubtitlingStreamMessage(ReceiveSubtitlingStreamMessage.PartialTranscript value)
    {
        MessageType = "partial_transcript";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveSubtitlingStreamMessage with <see cref="ReceiveSubtitlingStreamMessage.FinalTranscript"/>.
    /// </summary>
    public ReceiveSubtitlingStreamMessage(ReceiveSubtitlingStreamMessage.FinalTranscript value)
    {
        MessageType = "final_transcript";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveSubtitlingStreamMessage with <see cref="ReceiveSubtitlingStreamMessage.PartialSubtitle"/>.
    /// </summary>
    public ReceiveSubtitlingStreamMessage(ReceiveSubtitlingStreamMessage.PartialSubtitle value)
    {
        MessageType = "partial_subtitle";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveSubtitlingStreamMessage with <see cref="ReceiveSubtitlingStreamMessage.CommittedSubtitle"/>.
    /// </summary>
    public ReceiveSubtitlingStreamMessage(ReceiveSubtitlingStreamMessage.CommittedSubtitle value)
    {
        MessageType = "committed_subtitle";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveSubtitlingStreamMessage with <see cref="ReceiveSubtitlingStreamMessage.Error"/>.
    /// </summary>
    public ReceiveSubtitlingStreamMessage(ReceiveSubtitlingStreamMessage.Error value)
    {
        MessageType = "error";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveSubtitlingStreamMessage with <see cref="ReceiveSubtitlingStreamMessage.AuthError"/>.
    /// </summary>
    public ReceiveSubtitlingStreamMessage(ReceiveSubtitlingStreamMessage.AuthError value)
    {
        MessageType = "auth_error";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveSubtitlingStreamMessage with <see cref="ReceiveSubtitlingStreamMessage.RateLimited"/>.
    /// </summary>
    public ReceiveSubtitlingStreamMessage(ReceiveSubtitlingStreamMessage.RateLimited value)
    {
        MessageType = "rate_limited";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveSubtitlingStreamMessage with <see cref="ReceiveSubtitlingStreamMessage.QueueOverflow"/>.
    /// </summary>
    public ReceiveSubtitlingStreamMessage(ReceiveSubtitlingStreamMessage.QueueOverflow value)
    {
        MessageType = "queue_overflow";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveSubtitlingStreamMessage with <see cref="ReceiveSubtitlingStreamMessage.InputError"/>.
    /// </summary>
    public ReceiveSubtitlingStreamMessage(ReceiveSubtitlingStreamMessage.InputError value)
    {
        MessageType = "input_error";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveSubtitlingStreamMessage with <see cref="ReceiveSubtitlingStreamMessage.TranscriberError"/>.
    /// </summary>
    public ReceiveSubtitlingStreamMessage(ReceiveSubtitlingStreamMessage.TranscriberError value)
    {
        MessageType = "transcriber_error";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveSubtitlingStreamMessage with <see cref="ReceiveSubtitlingStreamMessage.TranslationError"/>.
    /// </summary>
    public ReceiveSubtitlingStreamMessage(ReceiveSubtitlingStreamMessage.TranslationError value)
    {
        MessageType = "translation_error";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveSubtitlingStreamMessage with <see cref="ReceiveSubtitlingStreamMessage.QuotaExceeded"/>.
    /// </summary>
    public ReceiveSubtitlingStreamMessage(ReceiveSubtitlingStreamMessage.QuotaExceeded value)
    {
        MessageType = "quota_exceeded";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveSubtitlingStreamMessage with <see cref="ReceiveSubtitlingStreamMessage.PaymentIssue"/>.
    /// </summary>
    public ReceiveSubtitlingStreamMessage(ReceiveSubtitlingStreamMessage.PaymentIssue value)
    {
        MessageType = "payment_issue";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ReceiveSubtitlingStreamMessage with <see cref="ReceiveSubtitlingStreamMessage.UnacceptedTerms"/>.
    /// </summary>
    public ReceiveSubtitlingStreamMessage(ReceiveSubtitlingStreamMessage.UnacceptedTerms value)
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
    /// Returns true if <see cref="MessageType"/> is "partial_subtitle"
    /// </summary>
    public bool IsPartialSubtitle => MessageType == "partial_subtitle";

    /// <summary>
    /// Returns true if <see cref="MessageType"/> is "committed_subtitle"
    /// </summary>
    public bool IsCommittedSubtitle => MessageType == "committed_subtitle";

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
    /// Returns the value as a <see cref="global::ElevenLabs.SubtitlingSessionStarted"/> if <see cref="MessageType"/> is 'session_started', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'session_started'.</exception>
    public global::ElevenLabs.SubtitlingSessionStarted AsSessionStarted() =>
        IsSessionStarted
            ? (global::ElevenLabs.SubtitlingSessionStarted)Value!
            : throw new global::System.Exception(
                "ReceiveSubtitlingStreamMessage.MessageType is not 'session_started'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SubtitlingStatus"/> if <see cref="MessageType"/> is 'status', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'status'.</exception>
    public global::ElevenLabs.SubtitlingStatus AsStatus() =>
        IsStatus
            ? (global::ElevenLabs.SubtitlingStatus)Value!
            : throw new global::System.Exception(
                "ReceiveSubtitlingStreamMessage.MessageType is not 'status'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SubtitlingPartialTranscript"/> if <see cref="MessageType"/> is 'partial_transcript', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'partial_transcript'.</exception>
    public global::ElevenLabs.SubtitlingPartialTranscript AsPartialTranscript() =>
        IsPartialTranscript
            ? (global::ElevenLabs.SubtitlingPartialTranscript)Value!
            : throw new global::System.Exception(
                "ReceiveSubtitlingStreamMessage.MessageType is not 'partial_transcript'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SubtitlingFinalTranscript"/> if <see cref="MessageType"/> is 'final_transcript', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'final_transcript'.</exception>
    public global::ElevenLabs.SubtitlingFinalTranscript AsFinalTranscript() =>
        IsFinalTranscript
            ? (global::ElevenLabs.SubtitlingFinalTranscript)Value!
            : throw new global::System.Exception(
                "ReceiveSubtitlingStreamMessage.MessageType is not 'final_transcript'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SubtitlingPartialSubtitle"/> if <see cref="MessageType"/> is 'partial_subtitle', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'partial_subtitle'.</exception>
    public global::ElevenLabs.SubtitlingPartialSubtitle AsPartialSubtitle() =>
        IsPartialSubtitle
            ? (global::ElevenLabs.SubtitlingPartialSubtitle)Value!
            : throw new global::System.Exception(
                "ReceiveSubtitlingStreamMessage.MessageType is not 'partial_subtitle'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SubtitlingCommittedSubtitle"/> if <see cref="MessageType"/> is 'committed_subtitle', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'committed_subtitle'.</exception>
    public global::ElevenLabs.SubtitlingCommittedSubtitle AsCommittedSubtitle() =>
        IsCommittedSubtitle
            ? (global::ElevenLabs.SubtitlingCommittedSubtitle)Value!
            : throw new global::System.Exception(
                "ReceiveSubtitlingStreamMessage.MessageType is not 'committed_subtitle'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SubtitlingError"/> if <see cref="MessageType"/> is 'error', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'error'.</exception>
    public global::ElevenLabs.SubtitlingError AsError() =>
        IsError
            ? (global::ElevenLabs.SubtitlingError)Value!
            : throw new global::System.Exception(
                "ReceiveSubtitlingStreamMessage.MessageType is not 'error'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SubtitlingAuthError"/> if <see cref="MessageType"/> is 'auth_error', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'auth_error'.</exception>
    public global::ElevenLabs.SubtitlingAuthError AsAuthError() =>
        IsAuthError
            ? (global::ElevenLabs.SubtitlingAuthError)Value!
            : throw new global::System.Exception(
                "ReceiveSubtitlingStreamMessage.MessageType is not 'auth_error'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SubtitlingRateLimitedError"/> if <see cref="MessageType"/> is 'rate_limited', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'rate_limited'.</exception>
    public global::ElevenLabs.SubtitlingRateLimitedError AsRateLimited() =>
        IsRateLimited
            ? (global::ElevenLabs.SubtitlingRateLimitedError)Value!
            : throw new global::System.Exception(
                "ReceiveSubtitlingStreamMessage.MessageType is not 'rate_limited'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SubtitlingQueueOverflowError"/> if <see cref="MessageType"/> is 'queue_overflow', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'queue_overflow'.</exception>
    public global::ElevenLabs.SubtitlingQueueOverflowError AsQueueOverflow() =>
        IsQueueOverflow
            ? (global::ElevenLabs.SubtitlingQueueOverflowError)Value!
            : throw new global::System.Exception(
                "ReceiveSubtitlingStreamMessage.MessageType is not 'queue_overflow'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SubtitlingInputError"/> if <see cref="MessageType"/> is 'input_error', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'input_error'.</exception>
    public global::ElevenLabs.SubtitlingInputError AsInputError() =>
        IsInputError
            ? (global::ElevenLabs.SubtitlingInputError)Value!
            : throw new global::System.Exception(
                "ReceiveSubtitlingStreamMessage.MessageType is not 'input_error'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SubtitlingTranscriberError"/> if <see cref="MessageType"/> is 'transcriber_error', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'transcriber_error'.</exception>
    public global::ElevenLabs.SubtitlingTranscriberError AsTranscriberError() =>
        IsTranscriberError
            ? (global::ElevenLabs.SubtitlingTranscriberError)Value!
            : throw new global::System.Exception(
                "ReceiveSubtitlingStreamMessage.MessageType is not 'transcriber_error'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SubtitlingTranslationError"/> if <see cref="MessageType"/> is 'translation_error', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'translation_error'.</exception>
    public global::ElevenLabs.SubtitlingTranslationError AsTranslationError() =>
        IsTranslationError
            ? (global::ElevenLabs.SubtitlingTranslationError)Value!
            : throw new global::System.Exception(
                "ReceiveSubtitlingStreamMessage.MessageType is not 'translation_error'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SubtitlingQuotaExceededError"/> if <see cref="MessageType"/> is 'quota_exceeded', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'quota_exceeded'.</exception>
    public global::ElevenLabs.SubtitlingQuotaExceededError AsQuotaExceeded() =>
        IsQuotaExceeded
            ? (global::ElevenLabs.SubtitlingQuotaExceededError)Value!
            : throw new global::System.Exception(
                "ReceiveSubtitlingStreamMessage.MessageType is not 'quota_exceeded'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SubtitlingPaymentIssueError"/> if <see cref="MessageType"/> is 'payment_issue', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'payment_issue'.</exception>
    public global::ElevenLabs.SubtitlingPaymentIssueError AsPaymentIssue() =>
        IsPaymentIssue
            ? (global::ElevenLabs.SubtitlingPaymentIssueError)Value!
            : throw new global::System.Exception(
                "ReceiveSubtitlingStreamMessage.MessageType is not 'payment_issue'"
            );

    /// <summary>
    /// Returns the value as a <see cref="global::ElevenLabs.SubtitlingUnacceptedTermsError"/> if <see cref="MessageType"/> is 'unaccepted_terms', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="MessageType"/> is not 'unaccepted_terms'.</exception>
    public global::ElevenLabs.SubtitlingUnacceptedTermsError AsUnacceptedTerms() =>
        IsUnacceptedTerms
            ? (global::ElevenLabs.SubtitlingUnacceptedTermsError)Value!
            : throw new global::System.Exception(
                "ReceiveSubtitlingStreamMessage.MessageType is not 'unaccepted_terms'"
            );

    public T Match<T>(
        Func<global::ElevenLabs.SubtitlingSessionStarted, T> onSessionStarted,
        Func<global::ElevenLabs.SubtitlingStatus, T> onStatus,
        Func<global::ElevenLabs.SubtitlingPartialTranscript, T> onPartialTranscript,
        Func<global::ElevenLabs.SubtitlingFinalTranscript, T> onFinalTranscript,
        Func<global::ElevenLabs.SubtitlingPartialSubtitle, T> onPartialSubtitle,
        Func<global::ElevenLabs.SubtitlingCommittedSubtitle, T> onCommittedSubtitle,
        Func<global::ElevenLabs.SubtitlingError, T> onError,
        Func<global::ElevenLabs.SubtitlingAuthError, T> onAuthError,
        Func<global::ElevenLabs.SubtitlingRateLimitedError, T> onRateLimited,
        Func<global::ElevenLabs.SubtitlingQueueOverflowError, T> onQueueOverflow,
        Func<global::ElevenLabs.SubtitlingInputError, T> onInputError,
        Func<global::ElevenLabs.SubtitlingTranscriberError, T> onTranscriberError,
        Func<global::ElevenLabs.SubtitlingTranslationError, T> onTranslationError,
        Func<global::ElevenLabs.SubtitlingQuotaExceededError, T> onQuotaExceeded,
        Func<global::ElevenLabs.SubtitlingPaymentIssueError, T> onPaymentIssue,
        Func<global::ElevenLabs.SubtitlingUnacceptedTermsError, T> onUnacceptedTerms,
        Func<string, object?, T> onUnknown_
    )
    {
        return MessageType switch
        {
            "session_started" => onSessionStarted(AsSessionStarted()),
            "status" => onStatus(AsStatus()),
            "partial_transcript" => onPartialTranscript(AsPartialTranscript()),
            "final_transcript" => onFinalTranscript(AsFinalTranscript()),
            "partial_subtitle" => onPartialSubtitle(AsPartialSubtitle()),
            "committed_subtitle" => onCommittedSubtitle(AsCommittedSubtitle()),
            "error" => onError(AsError()),
            "auth_error" => onAuthError(AsAuthError()),
            "rate_limited" => onRateLimited(AsRateLimited()),
            "queue_overflow" => onQueueOverflow(AsQueueOverflow()),
            "input_error" => onInputError(AsInputError()),
            "transcriber_error" => onTranscriberError(AsTranscriberError()),
            "translation_error" => onTranslationError(AsTranslationError()),
            "quota_exceeded" => onQuotaExceeded(AsQuotaExceeded()),
            "payment_issue" => onPaymentIssue(AsPaymentIssue()),
            "unaccepted_terms" => onUnacceptedTerms(AsUnacceptedTerms()),
            _ => onUnknown_(MessageType, Value),
        };
    }

    public void Visit(
        Action<global::ElevenLabs.SubtitlingSessionStarted> onSessionStarted,
        Action<global::ElevenLabs.SubtitlingStatus> onStatus,
        Action<global::ElevenLabs.SubtitlingPartialTranscript> onPartialTranscript,
        Action<global::ElevenLabs.SubtitlingFinalTranscript> onFinalTranscript,
        Action<global::ElevenLabs.SubtitlingPartialSubtitle> onPartialSubtitle,
        Action<global::ElevenLabs.SubtitlingCommittedSubtitle> onCommittedSubtitle,
        Action<global::ElevenLabs.SubtitlingError> onError,
        Action<global::ElevenLabs.SubtitlingAuthError> onAuthError,
        Action<global::ElevenLabs.SubtitlingRateLimitedError> onRateLimited,
        Action<global::ElevenLabs.SubtitlingQueueOverflowError> onQueueOverflow,
        Action<global::ElevenLabs.SubtitlingInputError> onInputError,
        Action<global::ElevenLabs.SubtitlingTranscriberError> onTranscriberError,
        Action<global::ElevenLabs.SubtitlingTranslationError> onTranslationError,
        Action<global::ElevenLabs.SubtitlingQuotaExceededError> onQuotaExceeded,
        Action<global::ElevenLabs.SubtitlingPaymentIssueError> onPaymentIssue,
        Action<global::ElevenLabs.SubtitlingUnacceptedTermsError> onUnacceptedTerms,
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
            case "partial_subtitle":
                onPartialSubtitle(AsPartialSubtitle());
                break;
            case "committed_subtitle":
                onCommittedSubtitle(AsCommittedSubtitle());
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
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SubtitlingSessionStarted"/> and returns true if successful.
    /// </summary>
    public bool TryAsSessionStarted(out global::ElevenLabs.SubtitlingSessionStarted? value)
    {
        if (MessageType == "session_started")
        {
            value = (global::ElevenLabs.SubtitlingSessionStarted)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SubtitlingStatus"/> and returns true if successful.
    /// </summary>
    public bool TryAsStatus(out global::ElevenLabs.SubtitlingStatus? value)
    {
        if (MessageType == "status")
        {
            value = (global::ElevenLabs.SubtitlingStatus)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SubtitlingPartialTranscript"/> and returns true if successful.
    /// </summary>
    public bool TryAsPartialTranscript(out global::ElevenLabs.SubtitlingPartialTranscript? value)
    {
        if (MessageType == "partial_transcript")
        {
            value = (global::ElevenLabs.SubtitlingPartialTranscript)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SubtitlingFinalTranscript"/> and returns true if successful.
    /// </summary>
    public bool TryAsFinalTranscript(out global::ElevenLabs.SubtitlingFinalTranscript? value)
    {
        if (MessageType == "final_transcript")
        {
            value = (global::ElevenLabs.SubtitlingFinalTranscript)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SubtitlingPartialSubtitle"/> and returns true if successful.
    /// </summary>
    public bool TryAsPartialSubtitle(out global::ElevenLabs.SubtitlingPartialSubtitle? value)
    {
        if (MessageType == "partial_subtitle")
        {
            value = (global::ElevenLabs.SubtitlingPartialSubtitle)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SubtitlingCommittedSubtitle"/> and returns true if successful.
    /// </summary>
    public bool TryAsCommittedSubtitle(out global::ElevenLabs.SubtitlingCommittedSubtitle? value)
    {
        if (MessageType == "committed_subtitle")
        {
            value = (global::ElevenLabs.SubtitlingCommittedSubtitle)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SubtitlingError"/> and returns true if successful.
    /// </summary>
    public bool TryAsError(out global::ElevenLabs.SubtitlingError? value)
    {
        if (MessageType == "error")
        {
            value = (global::ElevenLabs.SubtitlingError)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SubtitlingAuthError"/> and returns true if successful.
    /// </summary>
    public bool TryAsAuthError(out global::ElevenLabs.SubtitlingAuthError? value)
    {
        if (MessageType == "auth_error")
        {
            value = (global::ElevenLabs.SubtitlingAuthError)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SubtitlingRateLimitedError"/> and returns true if successful.
    /// </summary>
    public bool TryAsRateLimited(out global::ElevenLabs.SubtitlingRateLimitedError? value)
    {
        if (MessageType == "rate_limited")
        {
            value = (global::ElevenLabs.SubtitlingRateLimitedError)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SubtitlingQueueOverflowError"/> and returns true if successful.
    /// </summary>
    public bool TryAsQueueOverflow(out global::ElevenLabs.SubtitlingQueueOverflowError? value)
    {
        if (MessageType == "queue_overflow")
        {
            value = (global::ElevenLabs.SubtitlingQueueOverflowError)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SubtitlingInputError"/> and returns true if successful.
    /// </summary>
    public bool TryAsInputError(out global::ElevenLabs.SubtitlingInputError? value)
    {
        if (MessageType == "input_error")
        {
            value = (global::ElevenLabs.SubtitlingInputError)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SubtitlingTranscriberError"/> and returns true if successful.
    /// </summary>
    public bool TryAsTranscriberError(out global::ElevenLabs.SubtitlingTranscriberError? value)
    {
        if (MessageType == "transcriber_error")
        {
            value = (global::ElevenLabs.SubtitlingTranscriberError)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SubtitlingTranslationError"/> and returns true if successful.
    /// </summary>
    public bool TryAsTranslationError(out global::ElevenLabs.SubtitlingTranslationError? value)
    {
        if (MessageType == "translation_error")
        {
            value = (global::ElevenLabs.SubtitlingTranslationError)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SubtitlingQuotaExceededError"/> and returns true if successful.
    /// </summary>
    public bool TryAsQuotaExceeded(out global::ElevenLabs.SubtitlingQuotaExceededError? value)
    {
        if (MessageType == "quota_exceeded")
        {
            value = (global::ElevenLabs.SubtitlingQuotaExceededError)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SubtitlingPaymentIssueError"/> and returns true if successful.
    /// </summary>
    public bool TryAsPaymentIssue(out global::ElevenLabs.SubtitlingPaymentIssueError? value)
    {
        if (MessageType == "payment_issue")
        {
            value = (global::ElevenLabs.SubtitlingPaymentIssueError)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="global::ElevenLabs.SubtitlingUnacceptedTermsError"/> and returns true if successful.
    /// </summary>
    public bool TryAsUnacceptedTerms(out global::ElevenLabs.SubtitlingUnacceptedTermsError? value)
    {
        if (MessageType == "unaccepted_terms")
        {
            value = (global::ElevenLabs.SubtitlingUnacceptedTermsError)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator ReceiveSubtitlingStreamMessage(
        ReceiveSubtitlingStreamMessage.SessionStarted value
    ) => new(value);

    public static implicit operator ReceiveSubtitlingStreamMessage(
        ReceiveSubtitlingStreamMessage.Status value
    ) => new(value);

    public static implicit operator ReceiveSubtitlingStreamMessage(
        ReceiveSubtitlingStreamMessage.PartialTranscript value
    ) => new(value);

    public static implicit operator ReceiveSubtitlingStreamMessage(
        ReceiveSubtitlingStreamMessage.FinalTranscript value
    ) => new(value);

    public static implicit operator ReceiveSubtitlingStreamMessage(
        ReceiveSubtitlingStreamMessage.PartialSubtitle value
    ) => new(value);

    public static implicit operator ReceiveSubtitlingStreamMessage(
        ReceiveSubtitlingStreamMessage.CommittedSubtitle value
    ) => new(value);

    public static implicit operator ReceiveSubtitlingStreamMessage(
        ReceiveSubtitlingStreamMessage.Error value
    ) => new(value);

    public static implicit operator ReceiveSubtitlingStreamMessage(
        ReceiveSubtitlingStreamMessage.AuthError value
    ) => new(value);

    public static implicit operator ReceiveSubtitlingStreamMessage(
        ReceiveSubtitlingStreamMessage.RateLimited value
    ) => new(value);

    public static implicit operator ReceiveSubtitlingStreamMessage(
        ReceiveSubtitlingStreamMessage.QueueOverflow value
    ) => new(value);

    public static implicit operator ReceiveSubtitlingStreamMessage(
        ReceiveSubtitlingStreamMessage.InputError value
    ) => new(value);

    public static implicit operator ReceiveSubtitlingStreamMessage(
        ReceiveSubtitlingStreamMessage.TranscriberError value
    ) => new(value);

    public static implicit operator ReceiveSubtitlingStreamMessage(
        ReceiveSubtitlingStreamMessage.TranslationError value
    ) => new(value);

    public static implicit operator ReceiveSubtitlingStreamMessage(
        ReceiveSubtitlingStreamMessage.QuotaExceeded value
    ) => new(value);

    public static implicit operator ReceiveSubtitlingStreamMessage(
        ReceiveSubtitlingStreamMessage.PaymentIssue value
    ) => new(value);

    public static implicit operator ReceiveSubtitlingStreamMessage(
        ReceiveSubtitlingStreamMessage.UnacceptedTerms value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<ReceiveSubtitlingStreamMessage>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(ReceiveSubtitlingStreamMessage).IsAssignableFrom(typeToConvert);

        public override ReceiveSubtitlingStreamMessage Read(
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
                "session_started" => json.Deserialize<global::ElevenLabs.SubtitlingSessionStarted?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.SubtitlingSessionStarted"
                    ),
                "status" => json.Deserialize<global::ElevenLabs.SubtitlingStatus?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.SubtitlingStatus"
                    ),
                "partial_transcript" =>
                    json.Deserialize<global::ElevenLabs.SubtitlingPartialTranscript?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.SubtitlingPartialTranscript"
                        ),
                "final_transcript" =>
                    json.Deserialize<global::ElevenLabs.SubtitlingFinalTranscript?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.SubtitlingFinalTranscript"
                        ),
                "partial_subtitle" =>
                    json.Deserialize<global::ElevenLabs.SubtitlingPartialSubtitle?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.SubtitlingPartialSubtitle"
                        ),
                "committed_subtitle" =>
                    json.Deserialize<global::ElevenLabs.SubtitlingCommittedSubtitle?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.SubtitlingCommittedSubtitle"
                        ),
                "error" => json.Deserialize<global::ElevenLabs.SubtitlingError?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.SubtitlingError"
                    ),
                "auth_error" => json.Deserialize<global::ElevenLabs.SubtitlingAuthError?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.SubtitlingAuthError"
                    ),
                "rate_limited" => json.Deserialize<global::ElevenLabs.SubtitlingRateLimitedError?>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.SubtitlingRateLimitedError"
                    ),
                "queue_overflow" =>
                    json.Deserialize<global::ElevenLabs.SubtitlingQueueOverflowError?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.SubtitlingQueueOverflowError"
                        ),
                "input_error" => json.Deserialize<global::ElevenLabs.SubtitlingInputError?>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize global::ElevenLabs.SubtitlingInputError"
                    ),
                "transcriber_error" =>
                    json.Deserialize<global::ElevenLabs.SubtitlingTranscriberError?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.SubtitlingTranscriberError"
                        ),
                "translation_error" =>
                    json.Deserialize<global::ElevenLabs.SubtitlingTranslationError?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.SubtitlingTranslationError"
                        ),
                "quota_exceeded" =>
                    json.Deserialize<global::ElevenLabs.SubtitlingQuotaExceededError?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.SubtitlingQuotaExceededError"
                        ),
                "payment_issue" =>
                    json.Deserialize<global::ElevenLabs.SubtitlingPaymentIssueError?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.SubtitlingPaymentIssueError"
                        ),
                "unaccepted_terms" =>
                    json.Deserialize<global::ElevenLabs.SubtitlingUnacceptedTermsError?>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize global::ElevenLabs.SubtitlingUnacceptedTermsError"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new ReceiveSubtitlingStreamMessage(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReceiveSubtitlingStreamMessage value,
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
                    "partial_subtitle" => JsonSerializer.SerializeToNode(value.Value, options),
                    "committed_subtitle" => JsonSerializer.SerializeToNode(value.Value, options),
                    "error" => JsonSerializer.SerializeToNode(value.Value, options),
                    "auth_error" => JsonSerializer.SerializeToNode(value.Value, options),
                    "rate_limited" => JsonSerializer.SerializeToNode(value.Value, options),
                    "queue_overflow" => JsonSerializer.SerializeToNode(value.Value, options),
                    "input_error" => JsonSerializer.SerializeToNode(value.Value, options),
                    "transcriber_error" => JsonSerializer.SerializeToNode(value.Value, options),
                    "translation_error" => JsonSerializer.SerializeToNode(value.Value, options),
                    "quota_exceeded" => JsonSerializer.SerializeToNode(value.Value, options),
                    "payment_issue" => JsonSerializer.SerializeToNode(value.Value, options),
                    "unaccepted_terms" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["message_type"] = value.MessageType;
            json.WriteTo(writer, options);
        }

        public override ReceiveSubtitlingStreamMessage ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new ReceiveSubtitlingStreamMessage(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReceiveSubtitlingStreamMessage value,
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
        public SessionStarted(global::ElevenLabs.SubtitlingSessionStarted value)
        {
            Value = value;
        }

        internal global::ElevenLabs.SubtitlingSessionStarted Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveSubtitlingStreamMessage.SessionStarted(
            global::ElevenLabs.SubtitlingSessionStarted value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for status
    /// </summary>
    [Serializable]
    public struct Status
    {
        public Status(global::ElevenLabs.SubtitlingStatus value)
        {
            Value = value;
        }

        internal global::ElevenLabs.SubtitlingStatus Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveSubtitlingStreamMessage.Status(
            global::ElevenLabs.SubtitlingStatus value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for partial_transcript
    /// </summary>
    [Serializable]
    public struct PartialTranscript
    {
        public PartialTranscript(global::ElevenLabs.SubtitlingPartialTranscript value)
        {
            Value = value;
        }

        internal global::ElevenLabs.SubtitlingPartialTranscript Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveSubtitlingStreamMessage.PartialTranscript(
            global::ElevenLabs.SubtitlingPartialTranscript value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for final_transcript
    /// </summary>
    [Serializable]
    public struct FinalTranscript
    {
        public FinalTranscript(global::ElevenLabs.SubtitlingFinalTranscript value)
        {
            Value = value;
        }

        internal global::ElevenLabs.SubtitlingFinalTranscript Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveSubtitlingStreamMessage.FinalTranscript(
            global::ElevenLabs.SubtitlingFinalTranscript value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for partial_subtitle
    /// </summary>
    [Serializable]
    public struct PartialSubtitle
    {
        public PartialSubtitle(global::ElevenLabs.SubtitlingPartialSubtitle value)
        {
            Value = value;
        }

        internal global::ElevenLabs.SubtitlingPartialSubtitle Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveSubtitlingStreamMessage.PartialSubtitle(
            global::ElevenLabs.SubtitlingPartialSubtitle value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for committed_subtitle
    /// </summary>
    [Serializable]
    public struct CommittedSubtitle
    {
        public CommittedSubtitle(global::ElevenLabs.SubtitlingCommittedSubtitle value)
        {
            Value = value;
        }

        internal global::ElevenLabs.SubtitlingCommittedSubtitle Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveSubtitlingStreamMessage.CommittedSubtitle(
            global::ElevenLabs.SubtitlingCommittedSubtitle value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for error
    /// </summary>
    [Serializable]
    public struct Error
    {
        public Error(global::ElevenLabs.SubtitlingError value)
        {
            Value = value;
        }

        internal global::ElevenLabs.SubtitlingError Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveSubtitlingStreamMessage.Error(
            global::ElevenLabs.SubtitlingError value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for auth_error
    /// </summary>
    [Serializable]
    public struct AuthError
    {
        public AuthError(global::ElevenLabs.SubtitlingAuthError value)
        {
            Value = value;
        }

        internal global::ElevenLabs.SubtitlingAuthError Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveSubtitlingStreamMessage.AuthError(
            global::ElevenLabs.SubtitlingAuthError value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for rate_limited
    /// </summary>
    [Serializable]
    public struct RateLimited
    {
        public RateLimited(global::ElevenLabs.SubtitlingRateLimitedError value)
        {
            Value = value;
        }

        internal global::ElevenLabs.SubtitlingRateLimitedError Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveSubtitlingStreamMessage.RateLimited(
            global::ElevenLabs.SubtitlingRateLimitedError value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for queue_overflow
    /// </summary>
    [Serializable]
    public struct QueueOverflow
    {
        public QueueOverflow(global::ElevenLabs.SubtitlingQueueOverflowError value)
        {
            Value = value;
        }

        internal global::ElevenLabs.SubtitlingQueueOverflowError Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveSubtitlingStreamMessage.QueueOverflow(
            global::ElevenLabs.SubtitlingQueueOverflowError value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for input_error
    /// </summary>
    [Serializable]
    public struct InputError
    {
        public InputError(global::ElevenLabs.SubtitlingInputError value)
        {
            Value = value;
        }

        internal global::ElevenLabs.SubtitlingInputError Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveSubtitlingStreamMessage.InputError(
            global::ElevenLabs.SubtitlingInputError value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for transcriber_error
    /// </summary>
    [Serializable]
    public struct TranscriberError
    {
        public TranscriberError(global::ElevenLabs.SubtitlingTranscriberError value)
        {
            Value = value;
        }

        internal global::ElevenLabs.SubtitlingTranscriberError Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveSubtitlingStreamMessage.TranscriberError(
            global::ElevenLabs.SubtitlingTranscriberError value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for translation_error
    /// </summary>
    [Serializable]
    public struct TranslationError
    {
        public TranslationError(global::ElevenLabs.SubtitlingTranslationError value)
        {
            Value = value;
        }

        internal global::ElevenLabs.SubtitlingTranslationError Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveSubtitlingStreamMessage.TranslationError(
            global::ElevenLabs.SubtitlingTranslationError value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for quota_exceeded
    /// </summary>
    [Serializable]
    public struct QuotaExceeded
    {
        public QuotaExceeded(global::ElevenLabs.SubtitlingQuotaExceededError value)
        {
            Value = value;
        }

        internal global::ElevenLabs.SubtitlingQuotaExceededError Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveSubtitlingStreamMessage.QuotaExceeded(
            global::ElevenLabs.SubtitlingQuotaExceededError value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for payment_issue
    /// </summary>
    [Serializable]
    public struct PaymentIssue
    {
        public PaymentIssue(global::ElevenLabs.SubtitlingPaymentIssueError value)
        {
            Value = value;
        }

        internal global::ElevenLabs.SubtitlingPaymentIssueError Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveSubtitlingStreamMessage.PaymentIssue(
            global::ElevenLabs.SubtitlingPaymentIssueError value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for unaccepted_terms
    /// </summary>
    [Serializable]
    public struct UnacceptedTerms
    {
        public UnacceptedTerms(global::ElevenLabs.SubtitlingUnacceptedTermsError value)
        {
            Value = value;
        }

        internal global::ElevenLabs.SubtitlingUnacceptedTermsError Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator ReceiveSubtitlingStreamMessage.UnacceptedTerms(
            global::ElevenLabs.SubtitlingUnacceptedTermsError value
        ) => new(value);
    }
}
