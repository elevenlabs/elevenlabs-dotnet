// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ReceiveTranscription.JsonConverter))]
[Serializable]
public class ReceiveTranscription
{
    private ReceiveTranscription(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Type discriminator
    /// </summary>
    [JsonIgnore]
    public string Type { get; internal set; }

    /// <summary>
    /// Union value
    /// </summary>
    [JsonIgnore]
    public object? Value { get; internal set; }

    /// <summary>
    /// Create a ReceiveTranscription from a SessionStarted value.
    /// </summary>
    public static ReceiveTranscription FromSessionStarted(
        global::ElevenLabs.SessionStarted value
    ) => new("sessionStarted", value);

    /// <summary>
    /// Create a ReceiveTranscription from a PartialTranscript value.
    /// </summary>
    public static ReceiveTranscription FromPartialTranscript(
        global::ElevenLabs.PartialTranscript value
    ) => new("partialTranscript", value);

    /// <summary>
    /// Create a ReceiveTranscription from a CommittedTranscript value.
    /// </summary>
    public static ReceiveTranscription FromCommittedTranscript(
        global::ElevenLabs.CommittedTranscript value
    ) => new("committedTranscript", value);

    /// <summary>
    /// Create a ReceiveTranscription from a DiarizedTranscript value.
    /// </summary>
    public static ReceiveTranscription FromDiarizedTranscript(
        global::ElevenLabs.DiarizedTranscript value
    ) => new("diarizedTranscript", value);

    /// <summary>
    /// Create a ReceiveTranscription from a SpeakersMerged value.
    /// </summary>
    public static ReceiveTranscription FromSpeakersMerged(
        global::ElevenLabs.SpeakersMerged value
    ) => new("speakersMerged", value);

    /// <summary>
    /// Create a ReceiveTranscription from a CommittedTranscriptWithTimestamps value.
    /// </summary>
    public static ReceiveTranscription FromCommittedTranscriptWithTimestamps(
        global::ElevenLabs.CommittedTranscriptWithTimestamps value
    ) => new("committedTranscriptWithTimestamps", value);

    /// <summary>
    /// Create a ReceiveTranscription from a CommittedTranscriptEntities value.
    /// </summary>
    public static ReceiveTranscription FromCommittedTranscriptEntities(
        global::ElevenLabs.CommittedTranscriptEntities value
    ) => new("committedTranscriptEntities", value);

    /// <summary>
    /// Create a ReceiveTranscription from a RedactedTranscript value.
    /// </summary>
    public static ReceiveTranscription FromRedactedTranscript(
        global::ElevenLabs.RedactedTranscript value
    ) => new("redactedTranscript", value);

    /// <summary>
    /// Create a ReceiveTranscription from a EditedTranscript value.
    /// </summary>
    public static ReceiveTranscription FromEditedTranscript(
        global::ElevenLabs.EditedTranscript value
    ) => new("editedTranscript", value);

    /// <summary>
    /// Create a ReceiveTranscription from a ScribeWarning value.
    /// </summary>
    public static ReceiveTranscription FromScribeWarning(global::ElevenLabs.ScribeWarning value) =>
        new("scribeWarning", value);

    /// <summary>
    /// Create a ReceiveTranscription from a ScribeError value.
    /// </summary>
    public static ReceiveTranscription FromScribeError(global::ElevenLabs.ScribeError value) =>
        new("scribeError", value);

    /// <summary>
    /// Create a ReceiveTranscription from a ScribeAuthError value.
    /// </summary>
    public static ReceiveTranscription FromScribeAuthError(
        global::ElevenLabs.ScribeAuthError value
    ) => new("scribeAuthError", value);

    /// <summary>
    /// Create a ReceiveTranscription from a ScribeQuotaExceededError value.
    /// </summary>
    public static ReceiveTranscription FromScribeQuotaExceededError(
        global::ElevenLabs.ScribeQuotaExceededError value
    ) => new("scribeQuotaExceededError", value);

    /// <summary>
    /// Create a ReceiveTranscription from a ScribeThrottledError value.
    /// </summary>
    public static ReceiveTranscription FromScribeThrottledError(
        global::ElevenLabs.ScribeThrottledError value
    ) => new("scribeThrottledError", value);

    /// <summary>
    /// Create a ReceiveTranscription from a ScribeUnacceptedTermsError value.
    /// </summary>
    public static ReceiveTranscription FromScribeUnacceptedTermsError(
        global::ElevenLabs.ScribeUnacceptedTermsError value
    ) => new("scribeUnacceptedTermsError", value);

    /// <summary>
    /// Create a ReceiveTranscription from a ScribeRateLimitedError value.
    /// </summary>
    public static ReceiveTranscription FromScribeRateLimitedError(
        global::ElevenLabs.ScribeRateLimitedError value
    ) => new("scribeRateLimitedError", value);

    /// <summary>
    /// Create a ReceiveTranscription from a ScribeQueueOverflowError value.
    /// </summary>
    public static ReceiveTranscription FromScribeQueueOverflowError(
        global::ElevenLabs.ScribeQueueOverflowError value
    ) => new("scribeQueueOverflowError", value);

    /// <summary>
    /// Create a ReceiveTranscription from a ScribeResourceExhaustedError value.
    /// </summary>
    public static ReceiveTranscription FromScribeResourceExhaustedError(
        global::ElevenLabs.ScribeResourceExhaustedError value
    ) => new("scribeResourceExhaustedError", value);

    /// <summary>
    /// Create a ReceiveTranscription from a ScribeSessionTimeLimitExceededError value.
    /// </summary>
    public static ReceiveTranscription FromScribeSessionTimeLimitExceededError(
        global::ElevenLabs.ScribeSessionTimeLimitExceededError value
    ) => new("scribeSessionTimeLimitExceededError", value);

    /// <summary>
    /// Create a ReceiveTranscription from a ScribeInputError value.
    /// </summary>
    public static ReceiveTranscription FromScribeInputError(
        global::ElevenLabs.ScribeInputError value
    ) => new("scribeInputError", value);

    /// <summary>
    /// Create a ReceiveTranscription from a ScribeInvalidRequestError value.
    /// </summary>
    public static ReceiveTranscription FromScribeInvalidRequestError(
        global::ElevenLabs.ScribeInvalidRequestError value
    ) => new("scribeInvalidRequestError", value);

    /// <summary>
    /// Create a ReceiveTranscription from a ScribeChunkSizeExceededError value.
    /// </summary>
    public static ReceiveTranscription FromScribeChunkSizeExceededError(
        global::ElevenLabs.ScribeChunkSizeExceededError value
    ) => new("scribeChunkSizeExceededError", value);

    /// <summary>
    /// Create a ReceiveTranscription from a ScribeInsufficientAudioActivityError value.
    /// </summary>
    public static ReceiveTranscription FromScribeInsufficientAudioActivityError(
        global::ElevenLabs.ScribeInsufficientAudioActivityError value
    ) => new("scribeInsufficientAudioActivityError", value);

    /// <summary>
    /// Create a ReceiveTranscription from a ScribeTranscriberError value.
    /// </summary>
    public static ReceiveTranscription FromScribeTranscriberError(
        global::ElevenLabs.ScribeTranscriberError value
    ) => new("scribeTranscriberError", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "sessionStarted".
    /// </summary>
    public bool IsSessionStarted() => Type == "sessionStarted";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "partialTranscript".
    /// </summary>
    public bool IsPartialTranscript() => Type == "partialTranscript";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "committedTranscript".
    /// </summary>
    public bool IsCommittedTranscript() => Type == "committedTranscript";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "diarizedTranscript".
    /// </summary>
    public bool IsDiarizedTranscript() => Type == "diarizedTranscript";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "speakersMerged".
    /// </summary>
    public bool IsSpeakersMerged() => Type == "speakersMerged";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "committedTranscriptWithTimestamps".
    /// </summary>
    public bool IsCommittedTranscriptWithTimestamps() =>
        Type == "committedTranscriptWithTimestamps";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "committedTranscriptEntities".
    /// </summary>
    public bool IsCommittedTranscriptEntities() => Type == "committedTranscriptEntities";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "redactedTranscript".
    /// </summary>
    public bool IsRedactedTranscript() => Type == "redactedTranscript";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "editedTranscript".
    /// </summary>
    public bool IsEditedTranscript() => Type == "editedTranscript";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "scribeWarning".
    /// </summary>
    public bool IsScribeWarning() => Type == "scribeWarning";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "scribeError".
    /// </summary>
    public bool IsScribeError() => Type == "scribeError";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "scribeAuthError".
    /// </summary>
    public bool IsScribeAuthError() => Type == "scribeAuthError";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "scribeQuotaExceededError".
    /// </summary>
    public bool IsScribeQuotaExceededError() => Type == "scribeQuotaExceededError";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "scribeThrottledError".
    /// </summary>
    public bool IsScribeThrottledError() => Type == "scribeThrottledError";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "scribeUnacceptedTermsError".
    /// </summary>
    public bool IsScribeUnacceptedTermsError() => Type == "scribeUnacceptedTermsError";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "scribeRateLimitedError".
    /// </summary>
    public bool IsScribeRateLimitedError() => Type == "scribeRateLimitedError";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "scribeQueueOverflowError".
    /// </summary>
    public bool IsScribeQueueOverflowError() => Type == "scribeQueueOverflowError";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "scribeResourceExhaustedError".
    /// </summary>
    public bool IsScribeResourceExhaustedError() => Type == "scribeResourceExhaustedError";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "scribeSessionTimeLimitExceededError".
    /// </summary>
    public bool IsScribeSessionTimeLimitExceededError() =>
        Type == "scribeSessionTimeLimitExceededError";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "scribeInputError".
    /// </summary>
    public bool IsScribeInputError() => Type == "scribeInputError";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "scribeInvalidRequestError".
    /// </summary>
    public bool IsScribeInvalidRequestError() => Type == "scribeInvalidRequestError";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "scribeChunkSizeExceededError".
    /// </summary>
    public bool IsScribeChunkSizeExceededError() => Type == "scribeChunkSizeExceededError";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "scribeInsufficientAudioActivityError".
    /// </summary>
    public bool IsScribeInsufficientAudioActivityError() =>
        Type == "scribeInsufficientAudioActivityError";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "scribeTranscriberError".
    /// </summary>
    public bool IsScribeTranscriberError() => Type == "scribeTranscriberError";

    /// <summary>
    /// Returns the value as a SessionStarted if <see cref="Type"/> is "sessionStarted", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'sessionStarted'.</exception>
    public global::ElevenLabs.SessionStarted AsSessionStarted() =>
        IsSessionStarted()
            ? (global::ElevenLabs.SessionStarted)Value!
            : throw new ElevenLabsClientException("Union type is not 'sessionStarted'");

    /// <summary>
    /// Returns the value as a PartialTranscript if <see cref="Type"/> is "partialTranscript", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'partialTranscript'.</exception>
    public global::ElevenLabs.PartialTranscript AsPartialTranscript() =>
        IsPartialTranscript()
            ? (global::ElevenLabs.PartialTranscript)Value!
            : throw new ElevenLabsClientException("Union type is not 'partialTranscript'");

    /// <summary>
    /// Returns the value as a CommittedTranscript if <see cref="Type"/> is "committedTranscript", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'committedTranscript'.</exception>
    public global::ElevenLabs.CommittedTranscript AsCommittedTranscript() =>
        IsCommittedTranscript()
            ? (global::ElevenLabs.CommittedTranscript)Value!
            : throw new ElevenLabsClientException("Union type is not 'committedTranscript'");

    /// <summary>
    /// Returns the value as a DiarizedTranscript if <see cref="Type"/> is "diarizedTranscript", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'diarizedTranscript'.</exception>
    public global::ElevenLabs.DiarizedTranscript AsDiarizedTranscript() =>
        IsDiarizedTranscript()
            ? (global::ElevenLabs.DiarizedTranscript)Value!
            : throw new ElevenLabsClientException("Union type is not 'diarizedTranscript'");

    /// <summary>
    /// Returns the value as a SpeakersMerged if <see cref="Type"/> is "speakersMerged", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'speakersMerged'.</exception>
    public global::ElevenLabs.SpeakersMerged AsSpeakersMerged() =>
        IsSpeakersMerged()
            ? (global::ElevenLabs.SpeakersMerged)Value!
            : throw new ElevenLabsClientException("Union type is not 'speakersMerged'");

    /// <summary>
    /// Returns the value as a CommittedTranscriptWithTimestamps if <see cref="Type"/> is "committedTranscriptWithTimestamps", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'committedTranscriptWithTimestamps'.</exception>
    public global::ElevenLabs.CommittedTranscriptWithTimestamps AsCommittedTranscriptWithTimestamps() =>
        IsCommittedTranscriptWithTimestamps()
            ? (global::ElevenLabs.CommittedTranscriptWithTimestamps)Value!
            : throw new ElevenLabsClientException(
                "Union type is not 'committedTranscriptWithTimestamps'"
            );

    /// <summary>
    /// Returns the value as a CommittedTranscriptEntities if <see cref="Type"/> is "committedTranscriptEntities", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'committedTranscriptEntities'.</exception>
    public global::ElevenLabs.CommittedTranscriptEntities AsCommittedTranscriptEntities() =>
        IsCommittedTranscriptEntities()
            ? (global::ElevenLabs.CommittedTranscriptEntities)Value!
            : throw new ElevenLabsClientException(
                "Union type is not 'committedTranscriptEntities'"
            );

    /// <summary>
    /// Returns the value as a RedactedTranscript if <see cref="Type"/> is "redactedTranscript", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'redactedTranscript'.</exception>
    public global::ElevenLabs.RedactedTranscript AsRedactedTranscript() =>
        IsRedactedTranscript()
            ? (global::ElevenLabs.RedactedTranscript)Value!
            : throw new ElevenLabsClientException("Union type is not 'redactedTranscript'");

    /// <summary>
    /// Returns the value as a EditedTranscript if <see cref="Type"/> is "editedTranscript", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'editedTranscript'.</exception>
    public global::ElevenLabs.EditedTranscript AsEditedTranscript() =>
        IsEditedTranscript()
            ? (global::ElevenLabs.EditedTranscript)Value!
            : throw new ElevenLabsClientException("Union type is not 'editedTranscript'");

    /// <summary>
    /// Returns the value as a ScribeWarning if <see cref="Type"/> is "scribeWarning", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'scribeWarning'.</exception>
    public global::ElevenLabs.ScribeWarning AsScribeWarning() =>
        IsScribeWarning()
            ? (global::ElevenLabs.ScribeWarning)Value!
            : throw new ElevenLabsClientException("Union type is not 'scribeWarning'");

    /// <summary>
    /// Returns the value as a ScribeError if <see cref="Type"/> is "scribeError", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'scribeError'.</exception>
    public global::ElevenLabs.ScribeError AsScribeError() =>
        IsScribeError()
            ? (global::ElevenLabs.ScribeError)Value!
            : throw new ElevenLabsClientException("Union type is not 'scribeError'");

    /// <summary>
    /// Returns the value as a ScribeAuthError if <see cref="Type"/> is "scribeAuthError", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'scribeAuthError'.</exception>
    public global::ElevenLabs.ScribeAuthError AsScribeAuthError() =>
        IsScribeAuthError()
            ? (global::ElevenLabs.ScribeAuthError)Value!
            : throw new ElevenLabsClientException("Union type is not 'scribeAuthError'");

    /// <summary>
    /// Returns the value as a ScribeQuotaExceededError if <see cref="Type"/> is "scribeQuotaExceededError", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'scribeQuotaExceededError'.</exception>
    public global::ElevenLabs.ScribeQuotaExceededError AsScribeQuotaExceededError() =>
        IsScribeQuotaExceededError()
            ? (global::ElevenLabs.ScribeQuotaExceededError)Value!
            : throw new ElevenLabsClientException("Union type is not 'scribeQuotaExceededError'");

    /// <summary>
    /// Returns the value as a ScribeThrottledError if <see cref="Type"/> is "scribeThrottledError", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'scribeThrottledError'.</exception>
    public global::ElevenLabs.ScribeThrottledError AsScribeThrottledError() =>
        IsScribeThrottledError()
            ? (global::ElevenLabs.ScribeThrottledError)Value!
            : throw new ElevenLabsClientException("Union type is not 'scribeThrottledError'");

    /// <summary>
    /// Returns the value as a ScribeUnacceptedTermsError if <see cref="Type"/> is "scribeUnacceptedTermsError", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'scribeUnacceptedTermsError'.</exception>
    public global::ElevenLabs.ScribeUnacceptedTermsError AsScribeUnacceptedTermsError() =>
        IsScribeUnacceptedTermsError()
            ? (global::ElevenLabs.ScribeUnacceptedTermsError)Value!
            : throw new ElevenLabsClientException("Union type is not 'scribeUnacceptedTermsError'");

    /// <summary>
    /// Returns the value as a ScribeRateLimitedError if <see cref="Type"/> is "scribeRateLimitedError", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'scribeRateLimitedError'.</exception>
    public global::ElevenLabs.ScribeRateLimitedError AsScribeRateLimitedError() =>
        IsScribeRateLimitedError()
            ? (global::ElevenLabs.ScribeRateLimitedError)Value!
            : throw new ElevenLabsClientException("Union type is not 'scribeRateLimitedError'");

    /// <summary>
    /// Returns the value as a ScribeQueueOverflowError if <see cref="Type"/> is "scribeQueueOverflowError", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'scribeQueueOverflowError'.</exception>
    public global::ElevenLabs.ScribeQueueOverflowError AsScribeQueueOverflowError() =>
        IsScribeQueueOverflowError()
            ? (global::ElevenLabs.ScribeQueueOverflowError)Value!
            : throw new ElevenLabsClientException("Union type is not 'scribeQueueOverflowError'");

    /// <summary>
    /// Returns the value as a ScribeResourceExhaustedError if <see cref="Type"/> is "scribeResourceExhaustedError", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'scribeResourceExhaustedError'.</exception>
    public global::ElevenLabs.ScribeResourceExhaustedError AsScribeResourceExhaustedError() =>
        IsScribeResourceExhaustedError()
            ? (global::ElevenLabs.ScribeResourceExhaustedError)Value!
            : throw new ElevenLabsClientException(
                "Union type is not 'scribeResourceExhaustedError'"
            );

    /// <summary>
    /// Returns the value as a ScribeSessionTimeLimitExceededError if <see cref="Type"/> is "scribeSessionTimeLimitExceededError", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'scribeSessionTimeLimitExceededError'.</exception>
    public global::ElevenLabs.ScribeSessionTimeLimitExceededError AsScribeSessionTimeLimitExceededError() =>
        IsScribeSessionTimeLimitExceededError()
            ? (global::ElevenLabs.ScribeSessionTimeLimitExceededError)Value!
            : throw new ElevenLabsClientException(
                "Union type is not 'scribeSessionTimeLimitExceededError'"
            );

    /// <summary>
    /// Returns the value as a ScribeInputError if <see cref="Type"/> is "scribeInputError", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'scribeInputError'.</exception>
    public global::ElevenLabs.ScribeInputError AsScribeInputError() =>
        IsScribeInputError()
            ? (global::ElevenLabs.ScribeInputError)Value!
            : throw new ElevenLabsClientException("Union type is not 'scribeInputError'");

    /// <summary>
    /// Returns the value as a ScribeInvalidRequestError if <see cref="Type"/> is "scribeInvalidRequestError", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'scribeInvalidRequestError'.</exception>
    public global::ElevenLabs.ScribeInvalidRequestError AsScribeInvalidRequestError() =>
        IsScribeInvalidRequestError()
            ? (global::ElevenLabs.ScribeInvalidRequestError)Value!
            : throw new ElevenLabsClientException("Union type is not 'scribeInvalidRequestError'");

    /// <summary>
    /// Returns the value as a ScribeChunkSizeExceededError if <see cref="Type"/> is "scribeChunkSizeExceededError", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'scribeChunkSizeExceededError'.</exception>
    public global::ElevenLabs.ScribeChunkSizeExceededError AsScribeChunkSizeExceededError() =>
        IsScribeChunkSizeExceededError()
            ? (global::ElevenLabs.ScribeChunkSizeExceededError)Value!
            : throw new ElevenLabsClientException(
                "Union type is not 'scribeChunkSizeExceededError'"
            );

    /// <summary>
    /// Returns the value as a ScribeInsufficientAudioActivityError if <see cref="Type"/> is "scribeInsufficientAudioActivityError", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'scribeInsufficientAudioActivityError'.</exception>
    public global::ElevenLabs.ScribeInsufficientAudioActivityError AsScribeInsufficientAudioActivityError() =>
        IsScribeInsufficientAudioActivityError()
            ? (global::ElevenLabs.ScribeInsufficientAudioActivityError)Value!
            : throw new ElevenLabsClientException(
                "Union type is not 'scribeInsufficientAudioActivityError'"
            );

    /// <summary>
    /// Returns the value as a ScribeTranscriberError if <see cref="Type"/> is "scribeTranscriberError", otherwise throws.
    /// </summary>
    /// <exception cref="ElevenLabsClientException">Thrown when <see cref="Type"/> is not 'scribeTranscriberError'.</exception>
    public global::ElevenLabs.ScribeTranscriberError AsScribeTranscriberError() =>
        IsScribeTranscriberError()
            ? (global::ElevenLabs.ScribeTranscriberError)Value!
            : throw new ElevenLabsClientException("Union type is not 'scribeTranscriberError'");

    /// <summary>
    /// Attempts to cast the value to a SessionStarted and returns true if successful.
    /// </summary>
    public bool TryGetSessionStarted(out global::ElevenLabs.SessionStarted? value)
    {
        if (Type == "sessionStarted")
        {
            value = (global::ElevenLabs.SessionStarted)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a PartialTranscript and returns true if successful.
    /// </summary>
    public bool TryGetPartialTranscript(out global::ElevenLabs.PartialTranscript? value)
    {
        if (Type == "partialTranscript")
        {
            value = (global::ElevenLabs.PartialTranscript)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a CommittedTranscript and returns true if successful.
    /// </summary>
    public bool TryGetCommittedTranscript(out global::ElevenLabs.CommittedTranscript? value)
    {
        if (Type == "committedTranscript")
        {
            value = (global::ElevenLabs.CommittedTranscript)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a DiarizedTranscript and returns true if successful.
    /// </summary>
    public bool TryGetDiarizedTranscript(out global::ElevenLabs.DiarizedTranscript? value)
    {
        if (Type == "diarizedTranscript")
        {
            value = (global::ElevenLabs.DiarizedTranscript)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a SpeakersMerged and returns true if successful.
    /// </summary>
    public bool TryGetSpeakersMerged(out global::ElevenLabs.SpeakersMerged? value)
    {
        if (Type == "speakersMerged")
        {
            value = (global::ElevenLabs.SpeakersMerged)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a CommittedTranscriptWithTimestamps and returns true if successful.
    /// </summary>
    public bool TryGetCommittedTranscriptWithTimestamps(
        out global::ElevenLabs.CommittedTranscriptWithTimestamps? value
    )
    {
        if (Type == "committedTranscriptWithTimestamps")
        {
            value = (global::ElevenLabs.CommittedTranscriptWithTimestamps)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a CommittedTranscriptEntities and returns true if successful.
    /// </summary>
    public bool TryGetCommittedTranscriptEntities(
        out global::ElevenLabs.CommittedTranscriptEntities? value
    )
    {
        if (Type == "committedTranscriptEntities")
        {
            value = (global::ElevenLabs.CommittedTranscriptEntities)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a RedactedTranscript and returns true if successful.
    /// </summary>
    public bool TryGetRedactedTranscript(out global::ElevenLabs.RedactedTranscript? value)
    {
        if (Type == "redactedTranscript")
        {
            value = (global::ElevenLabs.RedactedTranscript)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a EditedTranscript and returns true if successful.
    /// </summary>
    public bool TryGetEditedTranscript(out global::ElevenLabs.EditedTranscript? value)
    {
        if (Type == "editedTranscript")
        {
            value = (global::ElevenLabs.EditedTranscript)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a ScribeWarning and returns true if successful.
    /// </summary>
    public bool TryGetScribeWarning(out global::ElevenLabs.ScribeWarning? value)
    {
        if (Type == "scribeWarning")
        {
            value = (global::ElevenLabs.ScribeWarning)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a ScribeError and returns true if successful.
    /// </summary>
    public bool TryGetScribeError(out global::ElevenLabs.ScribeError? value)
    {
        if (Type == "scribeError")
        {
            value = (global::ElevenLabs.ScribeError)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a ScribeAuthError and returns true if successful.
    /// </summary>
    public bool TryGetScribeAuthError(out global::ElevenLabs.ScribeAuthError? value)
    {
        if (Type == "scribeAuthError")
        {
            value = (global::ElevenLabs.ScribeAuthError)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a ScribeQuotaExceededError and returns true if successful.
    /// </summary>
    public bool TryGetScribeQuotaExceededError(
        out global::ElevenLabs.ScribeQuotaExceededError? value
    )
    {
        if (Type == "scribeQuotaExceededError")
        {
            value = (global::ElevenLabs.ScribeQuotaExceededError)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a ScribeThrottledError and returns true if successful.
    /// </summary>
    public bool TryGetScribeThrottledError(out global::ElevenLabs.ScribeThrottledError? value)
    {
        if (Type == "scribeThrottledError")
        {
            value = (global::ElevenLabs.ScribeThrottledError)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a ScribeUnacceptedTermsError and returns true if successful.
    /// </summary>
    public bool TryGetScribeUnacceptedTermsError(
        out global::ElevenLabs.ScribeUnacceptedTermsError? value
    )
    {
        if (Type == "scribeUnacceptedTermsError")
        {
            value = (global::ElevenLabs.ScribeUnacceptedTermsError)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a ScribeRateLimitedError and returns true if successful.
    /// </summary>
    public bool TryGetScribeRateLimitedError(out global::ElevenLabs.ScribeRateLimitedError? value)
    {
        if (Type == "scribeRateLimitedError")
        {
            value = (global::ElevenLabs.ScribeRateLimitedError)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a ScribeQueueOverflowError and returns true if successful.
    /// </summary>
    public bool TryGetScribeQueueOverflowError(
        out global::ElevenLabs.ScribeQueueOverflowError? value
    )
    {
        if (Type == "scribeQueueOverflowError")
        {
            value = (global::ElevenLabs.ScribeQueueOverflowError)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a ScribeResourceExhaustedError and returns true if successful.
    /// </summary>
    public bool TryGetScribeResourceExhaustedError(
        out global::ElevenLabs.ScribeResourceExhaustedError? value
    )
    {
        if (Type == "scribeResourceExhaustedError")
        {
            value = (global::ElevenLabs.ScribeResourceExhaustedError)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a ScribeSessionTimeLimitExceededError and returns true if successful.
    /// </summary>
    public bool TryGetScribeSessionTimeLimitExceededError(
        out global::ElevenLabs.ScribeSessionTimeLimitExceededError? value
    )
    {
        if (Type == "scribeSessionTimeLimitExceededError")
        {
            value = (global::ElevenLabs.ScribeSessionTimeLimitExceededError)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a ScribeInputError and returns true if successful.
    /// </summary>
    public bool TryGetScribeInputError(out global::ElevenLabs.ScribeInputError? value)
    {
        if (Type == "scribeInputError")
        {
            value = (global::ElevenLabs.ScribeInputError)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a ScribeInvalidRequestError and returns true if successful.
    /// </summary>
    public bool TryGetScribeInvalidRequestError(
        out global::ElevenLabs.ScribeInvalidRequestError? value
    )
    {
        if (Type == "scribeInvalidRequestError")
        {
            value = (global::ElevenLabs.ScribeInvalidRequestError)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a ScribeChunkSizeExceededError and returns true if successful.
    /// </summary>
    public bool TryGetScribeChunkSizeExceededError(
        out global::ElevenLabs.ScribeChunkSizeExceededError? value
    )
    {
        if (Type == "scribeChunkSizeExceededError")
        {
            value = (global::ElevenLabs.ScribeChunkSizeExceededError)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a ScribeInsufficientAudioActivityError and returns true if successful.
    /// </summary>
    public bool TryGetScribeInsufficientAudioActivityError(
        out global::ElevenLabs.ScribeInsufficientAudioActivityError? value
    )
    {
        if (Type == "scribeInsufficientAudioActivityError")
        {
            value = (global::ElevenLabs.ScribeInsufficientAudioActivityError)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a ScribeTranscriberError and returns true if successful.
    /// </summary>
    public bool TryGetScribeTranscriberError(out global::ElevenLabs.ScribeTranscriberError? value)
    {
        if (Type == "scribeTranscriberError")
        {
            value = (global::ElevenLabs.ScribeTranscriberError)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        global::System.Func<global::ElevenLabs.SessionStarted, T> onSessionStarted,
        global::System.Func<global::ElevenLabs.PartialTranscript, T> onPartialTranscript,
        global::System.Func<global::ElevenLabs.CommittedTranscript, T> onCommittedTranscript,
        global::System.Func<global::ElevenLabs.DiarizedTranscript, T> onDiarizedTranscript,
        global::System.Func<global::ElevenLabs.SpeakersMerged, T> onSpeakersMerged,
        global::System.Func<
            global::ElevenLabs.CommittedTranscriptWithTimestamps,
            T
        > onCommittedTranscriptWithTimestamps,
        global::System.Func<
            global::ElevenLabs.CommittedTranscriptEntities,
            T
        > onCommittedTranscriptEntities,
        global::System.Func<global::ElevenLabs.RedactedTranscript, T> onRedactedTranscript,
        global::System.Func<global::ElevenLabs.EditedTranscript, T> onEditedTranscript,
        global::System.Func<global::ElevenLabs.ScribeWarning, T> onScribeWarning,
        global::System.Func<global::ElevenLabs.ScribeError, T> onScribeError,
        global::System.Func<global::ElevenLabs.ScribeAuthError, T> onScribeAuthError,
        global::System.Func<
            global::ElevenLabs.ScribeQuotaExceededError,
            T
        > onScribeQuotaExceededError,
        global::System.Func<global::ElevenLabs.ScribeThrottledError, T> onScribeThrottledError,
        global::System.Func<
            global::ElevenLabs.ScribeUnacceptedTermsError,
            T
        > onScribeUnacceptedTermsError,
        global::System.Func<global::ElevenLabs.ScribeRateLimitedError, T> onScribeRateLimitedError,
        global::System.Func<
            global::ElevenLabs.ScribeQueueOverflowError,
            T
        > onScribeQueueOverflowError,
        global::System.Func<
            global::ElevenLabs.ScribeResourceExhaustedError,
            T
        > onScribeResourceExhaustedError,
        global::System.Func<
            global::ElevenLabs.ScribeSessionTimeLimitExceededError,
            T
        > onScribeSessionTimeLimitExceededError,
        global::System.Func<global::ElevenLabs.ScribeInputError, T> onScribeInputError,
        global::System.Func<
            global::ElevenLabs.ScribeInvalidRequestError,
            T
        > onScribeInvalidRequestError,
        global::System.Func<
            global::ElevenLabs.ScribeChunkSizeExceededError,
            T
        > onScribeChunkSizeExceededError,
        global::System.Func<
            global::ElevenLabs.ScribeInsufficientAudioActivityError,
            T
        > onScribeInsufficientAudioActivityError,
        global::System.Func<global::ElevenLabs.ScribeTranscriberError, T> onScribeTranscriberError
    )
    {
        return Type switch
        {
            "sessionStarted" => onSessionStarted(AsSessionStarted()),
            "partialTranscript" => onPartialTranscript(AsPartialTranscript()),
            "committedTranscript" => onCommittedTranscript(AsCommittedTranscript()),
            "diarizedTranscript" => onDiarizedTranscript(AsDiarizedTranscript()),
            "speakersMerged" => onSpeakersMerged(AsSpeakersMerged()),
            "committedTranscriptWithTimestamps" => onCommittedTranscriptWithTimestamps(
                AsCommittedTranscriptWithTimestamps()
            ),
            "committedTranscriptEntities" => onCommittedTranscriptEntities(
                AsCommittedTranscriptEntities()
            ),
            "redactedTranscript" => onRedactedTranscript(AsRedactedTranscript()),
            "editedTranscript" => onEditedTranscript(AsEditedTranscript()),
            "scribeWarning" => onScribeWarning(AsScribeWarning()),
            "scribeError" => onScribeError(AsScribeError()),
            "scribeAuthError" => onScribeAuthError(AsScribeAuthError()),
            "scribeQuotaExceededError" => onScribeQuotaExceededError(AsScribeQuotaExceededError()),
            "scribeThrottledError" => onScribeThrottledError(AsScribeThrottledError()),
            "scribeUnacceptedTermsError" => onScribeUnacceptedTermsError(
                AsScribeUnacceptedTermsError()
            ),
            "scribeRateLimitedError" => onScribeRateLimitedError(AsScribeRateLimitedError()),
            "scribeQueueOverflowError" => onScribeQueueOverflowError(AsScribeQueueOverflowError()),
            "scribeResourceExhaustedError" => onScribeResourceExhaustedError(
                AsScribeResourceExhaustedError()
            ),
            "scribeSessionTimeLimitExceededError" => onScribeSessionTimeLimitExceededError(
                AsScribeSessionTimeLimitExceededError()
            ),
            "scribeInputError" => onScribeInputError(AsScribeInputError()),
            "scribeInvalidRequestError" => onScribeInvalidRequestError(
                AsScribeInvalidRequestError()
            ),
            "scribeChunkSizeExceededError" => onScribeChunkSizeExceededError(
                AsScribeChunkSizeExceededError()
            ),
            "scribeInsufficientAudioActivityError" => onScribeInsufficientAudioActivityError(
                AsScribeInsufficientAudioActivityError()
            ),
            "scribeTranscriberError" => onScribeTranscriberError(AsScribeTranscriberError()),
            _ => throw new ElevenLabsClientException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<global::ElevenLabs.SessionStarted> onSessionStarted,
        global::System.Action<global::ElevenLabs.PartialTranscript> onPartialTranscript,
        global::System.Action<global::ElevenLabs.CommittedTranscript> onCommittedTranscript,
        global::System.Action<global::ElevenLabs.DiarizedTranscript> onDiarizedTranscript,
        global::System.Action<global::ElevenLabs.SpeakersMerged> onSpeakersMerged,
        global::System.Action<global::ElevenLabs.CommittedTranscriptWithTimestamps> onCommittedTranscriptWithTimestamps,
        global::System.Action<global::ElevenLabs.CommittedTranscriptEntities> onCommittedTranscriptEntities,
        global::System.Action<global::ElevenLabs.RedactedTranscript> onRedactedTranscript,
        global::System.Action<global::ElevenLabs.EditedTranscript> onEditedTranscript,
        global::System.Action<global::ElevenLabs.ScribeWarning> onScribeWarning,
        global::System.Action<global::ElevenLabs.ScribeError> onScribeError,
        global::System.Action<global::ElevenLabs.ScribeAuthError> onScribeAuthError,
        global::System.Action<global::ElevenLabs.ScribeQuotaExceededError> onScribeQuotaExceededError,
        global::System.Action<global::ElevenLabs.ScribeThrottledError> onScribeThrottledError,
        global::System.Action<global::ElevenLabs.ScribeUnacceptedTermsError> onScribeUnacceptedTermsError,
        global::System.Action<global::ElevenLabs.ScribeRateLimitedError> onScribeRateLimitedError,
        global::System.Action<global::ElevenLabs.ScribeQueueOverflowError> onScribeQueueOverflowError,
        global::System.Action<global::ElevenLabs.ScribeResourceExhaustedError> onScribeResourceExhaustedError,
        global::System.Action<global::ElevenLabs.ScribeSessionTimeLimitExceededError> onScribeSessionTimeLimitExceededError,
        global::System.Action<global::ElevenLabs.ScribeInputError> onScribeInputError,
        global::System.Action<global::ElevenLabs.ScribeInvalidRequestError> onScribeInvalidRequestError,
        global::System.Action<global::ElevenLabs.ScribeChunkSizeExceededError> onScribeChunkSizeExceededError,
        global::System.Action<global::ElevenLabs.ScribeInsufficientAudioActivityError> onScribeInsufficientAudioActivityError,
        global::System.Action<global::ElevenLabs.ScribeTranscriberError> onScribeTranscriberError
    )
    {
        switch (Type)
        {
            case "sessionStarted":
                onSessionStarted(AsSessionStarted());
                break;
            case "partialTranscript":
                onPartialTranscript(AsPartialTranscript());
                break;
            case "committedTranscript":
                onCommittedTranscript(AsCommittedTranscript());
                break;
            case "diarizedTranscript":
                onDiarizedTranscript(AsDiarizedTranscript());
                break;
            case "speakersMerged":
                onSpeakersMerged(AsSpeakersMerged());
                break;
            case "committedTranscriptWithTimestamps":
                onCommittedTranscriptWithTimestamps(AsCommittedTranscriptWithTimestamps());
                break;
            case "committedTranscriptEntities":
                onCommittedTranscriptEntities(AsCommittedTranscriptEntities());
                break;
            case "redactedTranscript":
                onRedactedTranscript(AsRedactedTranscript());
                break;
            case "editedTranscript":
                onEditedTranscript(AsEditedTranscript());
                break;
            case "scribeWarning":
                onScribeWarning(AsScribeWarning());
                break;
            case "scribeError":
                onScribeError(AsScribeError());
                break;
            case "scribeAuthError":
                onScribeAuthError(AsScribeAuthError());
                break;
            case "scribeQuotaExceededError":
                onScribeQuotaExceededError(AsScribeQuotaExceededError());
                break;
            case "scribeThrottledError":
                onScribeThrottledError(AsScribeThrottledError());
                break;
            case "scribeUnacceptedTermsError":
                onScribeUnacceptedTermsError(AsScribeUnacceptedTermsError());
                break;
            case "scribeRateLimitedError":
                onScribeRateLimitedError(AsScribeRateLimitedError());
                break;
            case "scribeQueueOverflowError":
                onScribeQueueOverflowError(AsScribeQueueOverflowError());
                break;
            case "scribeResourceExhaustedError":
                onScribeResourceExhaustedError(AsScribeResourceExhaustedError());
                break;
            case "scribeSessionTimeLimitExceededError":
                onScribeSessionTimeLimitExceededError(AsScribeSessionTimeLimitExceededError());
                break;
            case "scribeInputError":
                onScribeInputError(AsScribeInputError());
                break;
            case "scribeInvalidRequestError":
                onScribeInvalidRequestError(AsScribeInvalidRequestError());
                break;
            case "scribeChunkSizeExceededError":
                onScribeChunkSizeExceededError(AsScribeChunkSizeExceededError());
                break;
            case "scribeInsufficientAudioActivityError":
                onScribeInsufficientAudioActivityError(AsScribeInsufficientAudioActivityError());
                break;
            case "scribeTranscriberError":
                onScribeTranscriberError(AsScribeTranscriberError());
                break;
            default:
                throw new ElevenLabsClientException($"Unknown union type: {Type}");
        }
    }

    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode = Type.GetHashCode();
            if (Value != null)
            {
                hashCode = (hashCode * 397) ^ Value.GetHashCode();
            }
            return hashCode;
        }
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;
        if (ReferenceEquals(this, obj))
            return true;
        if (obj is not ReceiveTranscription other)
            return false;
        if (Type != other.Type)
            return false;
        return System.Collections.Generic.EqualityComparer<object?>.Default.Equals(
            Value,
            other.Value
        );
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator ReceiveTranscription(global::ElevenLabs.SessionStarted value) =>
        new("sessionStarted", value);

    public static implicit operator ReceiveTranscription(
        global::ElevenLabs.PartialTranscript value
    ) => new("partialTranscript", value);

    public static implicit operator ReceiveTranscription(
        global::ElevenLabs.CommittedTranscript value
    ) => new("committedTranscript", value);

    public static implicit operator ReceiveTranscription(
        global::ElevenLabs.DiarizedTranscript value
    ) => new("diarizedTranscript", value);

    public static implicit operator ReceiveTranscription(global::ElevenLabs.SpeakersMerged value) =>
        new("speakersMerged", value);

    public static implicit operator ReceiveTranscription(
        global::ElevenLabs.CommittedTranscriptWithTimestamps value
    ) => new("committedTranscriptWithTimestamps", value);

    public static implicit operator ReceiveTranscription(
        global::ElevenLabs.CommittedTranscriptEntities value
    ) => new("committedTranscriptEntities", value);

    public static implicit operator ReceiveTranscription(
        global::ElevenLabs.RedactedTranscript value
    ) => new("redactedTranscript", value);

    public static implicit operator ReceiveTranscription(
        global::ElevenLabs.EditedTranscript value
    ) => new("editedTranscript", value);

    public static implicit operator ReceiveTranscription(global::ElevenLabs.ScribeWarning value) =>
        new("scribeWarning", value);

    public static implicit operator ReceiveTranscription(global::ElevenLabs.ScribeError value) =>
        new("scribeError", value);

    public static implicit operator ReceiveTranscription(
        global::ElevenLabs.ScribeAuthError value
    ) => new("scribeAuthError", value);

    public static implicit operator ReceiveTranscription(
        global::ElevenLabs.ScribeQuotaExceededError value
    ) => new("scribeQuotaExceededError", value);

    public static implicit operator ReceiveTranscription(
        global::ElevenLabs.ScribeThrottledError value
    ) => new("scribeThrottledError", value);

    public static implicit operator ReceiveTranscription(
        global::ElevenLabs.ScribeUnacceptedTermsError value
    ) => new("scribeUnacceptedTermsError", value);

    public static implicit operator ReceiveTranscription(
        global::ElevenLabs.ScribeRateLimitedError value
    ) => new("scribeRateLimitedError", value);

    public static implicit operator ReceiveTranscription(
        global::ElevenLabs.ScribeQueueOverflowError value
    ) => new("scribeQueueOverflowError", value);

    public static implicit operator ReceiveTranscription(
        global::ElevenLabs.ScribeResourceExhaustedError value
    ) => new("scribeResourceExhaustedError", value);

    public static implicit operator ReceiveTranscription(
        global::ElevenLabs.ScribeSessionTimeLimitExceededError value
    ) => new("scribeSessionTimeLimitExceededError", value);

    public static implicit operator ReceiveTranscription(
        global::ElevenLabs.ScribeInputError value
    ) => new("scribeInputError", value);

    public static implicit operator ReceiveTranscription(
        global::ElevenLabs.ScribeInvalidRequestError value
    ) => new("scribeInvalidRequestError", value);

    public static implicit operator ReceiveTranscription(
        global::ElevenLabs.ScribeChunkSizeExceededError value
    ) => new("scribeChunkSizeExceededError", value);

    public static implicit operator ReceiveTranscription(
        global::ElevenLabs.ScribeInsufficientAudioActivityError value
    ) => new("scribeInsufficientAudioActivityError", value);

    public static implicit operator ReceiveTranscription(
        global::ElevenLabs.ScribeTranscriberError value
    ) => new("scribeTranscriberError", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<ReceiveTranscription>
    {
        public override ReceiveTranscription? Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            if (reader.TokenType == JsonTokenType.StartObject)
            {
                var document = JsonDocument.ParseValue(ref reader);

                // A payload carrying a member's literal decodes as that member or not at all.
                var matchedLiteral = false;

                if (HasLiteral(document, "message_type", "session_started"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.SessionStarted),
                            options
                        );
                        if (value != null)
                        {
                            return new ReceiveTranscription("sessionStarted", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "message_type", "partial_transcript"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.PartialTranscript),
                            options
                        );
                        if (value != null)
                        {
                            return new ReceiveTranscription("partialTranscript", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "message_type", "committed_transcript"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.CommittedTranscript),
                            options
                        );
                        if (value != null)
                        {
                            return new ReceiveTranscription("committedTranscript", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "message_type", "diarized_transcript"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.DiarizedTranscript),
                            options
                        );
                        if (value != null)
                        {
                            return new ReceiveTranscription("diarizedTranscript", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "message_type", "speakers_merged"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.SpeakersMerged),
                            options
                        );
                        if (value != null)
                        {
                            return new ReceiveTranscription("speakersMerged", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "message_type", "committed_transcript_with_timestamps"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.CommittedTranscriptWithTimestamps),
                            options
                        );
                        if (value != null)
                        {
                            return new ReceiveTranscription(
                                "committedTranscriptWithTimestamps",
                                value
                            );
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "message_type", "committed_transcript_entities"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.CommittedTranscriptEntities),
                            options
                        );
                        if (value != null)
                        {
                            return new ReceiveTranscription("committedTranscriptEntities", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "message_type", "redacted_transcript"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.RedactedTranscript),
                            options
                        );
                        if (value != null)
                        {
                            return new ReceiveTranscription("redactedTranscript", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "message_type", "warning"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.ScribeWarning),
                            options
                        );
                        if (value != null)
                        {
                            return new ReceiveTranscription("scribeWarning", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "message_type", "error"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.ScribeError),
                            options
                        );
                        if (value != null)
                        {
                            return new ReceiveTranscription("scribeError", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "message_type", "auth_error"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.ScribeAuthError),
                            options
                        );
                        if (value != null)
                        {
                            return new ReceiveTranscription("scribeAuthError", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "message_type", "quota_exceeded"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.ScribeQuotaExceededError),
                            options
                        );
                        if (value != null)
                        {
                            return new ReceiveTranscription("scribeQuotaExceededError", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "message_type", "commit_throttled"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.ScribeThrottledError),
                            options
                        );
                        if (value != null)
                        {
                            return new ReceiveTranscription("scribeThrottledError", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "message_type", "unaccepted_terms"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.ScribeUnacceptedTermsError),
                            options
                        );
                        if (value != null)
                        {
                            return new ReceiveTranscription("scribeUnacceptedTermsError", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "message_type", "rate_limited"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.ScribeRateLimitedError),
                            options
                        );
                        if (value != null)
                        {
                            return new ReceiveTranscription("scribeRateLimitedError", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "message_type", "queue_overflow"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.ScribeQueueOverflowError),
                            options
                        );
                        if (value != null)
                        {
                            return new ReceiveTranscription("scribeQueueOverflowError", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "message_type", "resource_exhausted"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.ScribeResourceExhaustedError),
                            options
                        );
                        if (value != null)
                        {
                            return new ReceiveTranscription("scribeResourceExhaustedError", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "message_type", "session_time_limit_exceeded"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.ScribeSessionTimeLimitExceededError),
                            options
                        );
                        if (value != null)
                        {
                            return new ReceiveTranscription(
                                "scribeSessionTimeLimitExceededError",
                                value
                            );
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "message_type", "input_error"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.ScribeInputError),
                            options
                        );
                        if (value != null)
                        {
                            return new ReceiveTranscription("scribeInputError", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "message_type", "invalid_request"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.ScribeInvalidRequestError),
                            options
                        );
                        if (value != null)
                        {
                            return new ReceiveTranscription("scribeInvalidRequestError", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "message_type", "chunk_size_exceeded"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.ScribeChunkSizeExceededError),
                            options
                        );
                        if (value != null)
                        {
                            return new ReceiveTranscription("scribeChunkSizeExceededError", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "message_type", "insufficient_audio_activity"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.ScribeInsufficientAudioActivityError),
                            options
                        );
                        if (value != null)
                        {
                            return new ReceiveTranscription(
                                "scribeInsufficientAudioActivityError",
                                value
                            );
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (HasLiteral(document, "message_type", "transcriber_error"))
                {
                    matchedLiteral = true;
                    try
                    {
                        var value = document.Deserialize(
                            typeof(global::ElevenLabs.ScribeTranscriberError),
                            options
                        );
                        if (value != null)
                        {
                            return new ReceiveTranscription("scribeTranscriberError", value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next member that pins the same literal.
                    }
                }

                if (matchedLiteral)
                {
                    throw new JsonException(
                        "Cannot deserialize JSON object into ReceiveTranscription: it carries a member's literal but does not deserialize as that member"
                    );
                }

                var types = new (string Key, global::System.Type Type)[]
                {
                    ("sessionStarted", typeof(global::ElevenLabs.SessionStarted)),
                    ("partialTranscript", typeof(global::ElevenLabs.PartialTranscript)),
                    ("committedTranscript", typeof(global::ElevenLabs.CommittedTranscript)),
                    ("diarizedTranscript", typeof(global::ElevenLabs.DiarizedTranscript)),
                    ("speakersMerged", typeof(global::ElevenLabs.SpeakersMerged)),
                    (
                        "committedTranscriptWithTimestamps",
                        typeof(global::ElevenLabs.CommittedTranscriptWithTimestamps)
                    ),
                    (
                        "committedTranscriptEntities",
                        typeof(global::ElevenLabs.CommittedTranscriptEntities)
                    ),
                    ("redactedTranscript", typeof(global::ElevenLabs.RedactedTranscript)),
                    ("editedTranscript", typeof(global::ElevenLabs.EditedTranscript)),
                    ("scribeWarning", typeof(global::ElevenLabs.ScribeWarning)),
                    ("scribeError", typeof(global::ElevenLabs.ScribeError)),
                    ("scribeAuthError", typeof(global::ElevenLabs.ScribeAuthError)),
                    (
                        "scribeQuotaExceededError",
                        typeof(global::ElevenLabs.ScribeQuotaExceededError)
                    ),
                    ("scribeThrottledError", typeof(global::ElevenLabs.ScribeThrottledError)),
                    (
                        "scribeUnacceptedTermsError",
                        typeof(global::ElevenLabs.ScribeUnacceptedTermsError)
                    ),
                    ("scribeRateLimitedError", typeof(global::ElevenLabs.ScribeRateLimitedError)),
                    (
                        "scribeQueueOverflowError",
                        typeof(global::ElevenLabs.ScribeQueueOverflowError)
                    ),
                    (
                        "scribeResourceExhaustedError",
                        typeof(global::ElevenLabs.ScribeResourceExhaustedError)
                    ),
                    (
                        "scribeSessionTimeLimitExceededError",
                        typeof(global::ElevenLabs.ScribeSessionTimeLimitExceededError)
                    ),
                    ("scribeInputError", typeof(global::ElevenLabs.ScribeInputError)),
                    (
                        "scribeInvalidRequestError",
                        typeof(global::ElevenLabs.ScribeInvalidRequestError)
                    ),
                    (
                        "scribeChunkSizeExceededError",
                        typeof(global::ElevenLabs.ScribeChunkSizeExceededError)
                    ),
                    (
                        "scribeInsufficientAudioActivityError",
                        typeof(global::ElevenLabs.ScribeInsufficientAudioActivityError)
                    ),
                    ("scribeTranscriberError", typeof(global::ElevenLabs.ScribeTranscriberError)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            return new ReceiveTranscription(key, value);
                        }
                    }
                    catch (JsonException)
                    {
                        // Try the next candidate type.
                    }
                }
            }

            throw new JsonException(
                $"Cannot deserialize JSON token {reader.TokenType} into ReceiveTranscription"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReceiveTranscription value,
            JsonSerializerOptions options
        )
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }

            value.Visit(
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override ReceiveTranscription ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            ReceiveTranscription result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReceiveTranscription value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }

        private static bool HasLiteral(JsonDocument document, string key, string expected)
        {
            if (!document.RootElement.TryGetProperty(key, out var property))
            {
                return false;
            }

            return property.ValueKind == JsonValueKind.String && property.GetString() == expected;
        }
    }
}
