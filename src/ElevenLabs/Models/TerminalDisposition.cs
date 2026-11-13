using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Agents.OutboundCampaigns;

[JsonConverter(typeof(TerminalDisposition.TerminalDispositionSerializer))]
[Serializable]
public readonly record struct TerminalDisposition : IStringEnum
{
    public static readonly TerminalDisposition CampaignEnded = new(Values.CampaignEnded);

    public static readonly TerminalDisposition Removed = new(Values.Removed);

    public static readonly TerminalDisposition DoNotCall = new(Values.DoNotCall);

    public static readonly TerminalDisposition Completed = new(Values.Completed);

    public static readonly TerminalDisposition Cancelled = new(Values.Cancelled);

    public static readonly TerminalDisposition Suppressed = new(Values.Suppressed);

    public static readonly TerminalDisposition AttemptCeilingReached = new(
        Values.AttemptCeilingReached
    );

    public static readonly TerminalDisposition CallbackCeilingReached = new(
        Values.CallbackCeilingReached
    );

    public static readonly TerminalDisposition RedirectCeilingReached = new(
        Values.RedirectCeilingReached
    );

    public static readonly TerminalDisposition PermissionNotGranted = new(
        Values.PermissionNotGranted
    );

    public static readonly TerminalDisposition PermissionDeclined = new(Values.PermissionDeclined);

    public static readonly TerminalDisposition PermissionRequestBlocked = new(
        Values.PermissionRequestBlocked
    );

    public static readonly TerminalDisposition PermissionExpired = new(Values.PermissionExpired);

    public static readonly TerminalDisposition CallbackTimeInvalid = new(
        Values.CallbackTimeInvalid
    );

    public static readonly TerminalDisposition RedirectNumberInvalid = new(
        Values.RedirectNumberInvalid
    );

    public static readonly TerminalDisposition CouldntProcess = new(Values.CouldntProcess);

    public TerminalDisposition(string value)
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
    public static TerminalDisposition FromCustom(string value)
    {
        return new TerminalDisposition(value);
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

    public static bool operator ==(TerminalDisposition value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TerminalDisposition value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TerminalDisposition value) => value.Value;

    public static explicit operator TerminalDisposition(string value) => new(value);

    internal class TerminalDispositionSerializer : JsonConverter<TerminalDisposition>
    {
        public override TerminalDisposition Read(
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
            return new TerminalDisposition(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TerminalDisposition value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TerminalDisposition ReadAsPropertyName(
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
            return new TerminalDisposition(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TerminalDisposition value,
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
        public const string CampaignEnded = "campaign_ended";

        public const string Removed = "removed";

        public const string DoNotCall = "do_not_call";

        public const string Completed = "completed";

        public const string Cancelled = "cancelled";

        public const string Suppressed = "suppressed";

        public const string AttemptCeilingReached = "attempt_ceiling_reached";

        public const string CallbackCeilingReached = "callback_ceiling_reached";

        public const string RedirectCeilingReached = "redirect_ceiling_reached";

        public const string PermissionNotGranted = "permission_not_granted";

        public const string PermissionDeclined = "permission_declined";

        public const string PermissionRequestBlocked = "permission_request_blocked";

        public const string PermissionExpired = "permission_expired";

        public const string CallbackTimeInvalid = "callback_time_invalid";

        public const string RedirectNumberInvalid = "redirect_number_invalid";

        public const string CouldntProcess = "couldnt_process";
    }
}
