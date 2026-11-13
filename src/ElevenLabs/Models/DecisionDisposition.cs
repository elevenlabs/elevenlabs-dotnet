using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>How a settled call's decision left its lead.</summary>
[JsonConverter(typeof(DecisionDisposition.DecisionDispositionSerializer))]
[Serializable]
public readonly record struct DecisionDisposition : IStringEnum
{
    public static readonly DecisionDisposition Completed = new(Values.Completed);

    public static readonly DecisionDisposition RetryQueued = new(Values.RetryQueued);

    public static readonly DecisionDisposition CallbackQueued = new(Values.CallbackQueued);

    public static readonly DecisionDisposition RedirectQueued = new(Values.RedirectQueued);

    public static readonly DecisionDisposition Attention = new(Values.Attention);

    public static readonly DecisionDisposition Cancelled = new(Values.Cancelled);

    public static readonly DecisionDisposition DoNotCall = new(Values.DoNotCall);

    public static readonly DecisionDisposition Suppressed = new(Values.Suppressed);

    public static readonly DecisionDisposition WindowSuspended = new(Values.WindowSuspended);

    public static readonly DecisionDisposition AttemptCeilingReached = new(
        Values.AttemptCeilingReached
    );

    public static readonly DecisionDisposition CallbackCeilingReached = new(
        Values.CallbackCeilingReached
    );

    public static readonly DecisionDisposition RedirectCeilingReached = new(
        Values.RedirectCeilingReached
    );

    public static readonly DecisionDisposition CallbackTimeInvalid = new(
        Values.CallbackTimeInvalid
    );

    public static readonly DecisionDisposition RedirectNumberInvalid = new(
        Values.RedirectNumberInvalid
    );

    public static readonly DecisionDisposition CouldntProcess = new(Values.CouldntProcess);

    public static readonly DecisionDisposition SuppressedDoNotCall = new(
        Values.SuppressedDoNotCall
    );

    public static readonly DecisionDisposition SuppressedAfterStop = new(
        Values.SuppressedAfterStop
    );

    public static readonly DecisionDisposition PermissionNotGranted = new(
        Values.PermissionNotGranted
    );

    public static readonly DecisionDisposition PermissionDeclined = new(Values.PermissionDeclined);

    public static readonly DecisionDisposition PermissionRequestBlocked = new(
        Values.PermissionRequestBlocked
    );

    public static readonly DecisionDisposition PermissionExpired = new(Values.PermissionExpired);

    public DecisionDisposition(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static DecisionDisposition FromCustom(string value)
    {
        return new DecisionDisposition(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(DecisionDisposition value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DecisionDisposition value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DecisionDisposition value) => value.Value;

    public static explicit operator DecisionDisposition(string value) => new(value);

    internal class DecisionDispositionSerializer : JsonConverter<DecisionDisposition>
    {
        public override DecisionDisposition Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new DecisionDisposition(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DecisionDisposition value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DecisionDisposition ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new DecisionDisposition(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DecisionDisposition value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Completed = "completed";

        public const string RetryQueued = "retry_queued";

        public const string CallbackQueued = "callback_queued";

        public const string RedirectQueued = "redirect_queued";

        public const string Attention = "attention";

        public const string Cancelled = "cancelled";

        public const string DoNotCall = "do_not_call";

        public const string Suppressed = "suppressed";

        public const string WindowSuspended = "window_suspended";

        public const string AttemptCeilingReached = "attempt_ceiling_reached";

        public const string CallbackCeilingReached = "callback_ceiling_reached";

        public const string RedirectCeilingReached = "redirect_ceiling_reached";

        public const string CallbackTimeInvalid = "callback_time_invalid";

        public const string RedirectNumberInvalid = "redirect_number_invalid";

        public const string CouldntProcess = "couldnt_process";

        public const string SuppressedDoNotCall = "suppressed_do_not_call";

        public const string SuppressedAfterStop = "suppressed_after_stop";

        public const string PermissionNotGranted = "permission_not_granted";

        public const string PermissionDeclined = "permission_declined";

        public const string PermissionRequestBlocked = "permission_request_blocked";

        public const string PermissionExpired = "permission_expired";
    }
}
