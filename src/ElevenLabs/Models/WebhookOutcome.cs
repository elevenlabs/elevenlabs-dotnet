using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(WebhookOutcome.WebhookOutcomeSerializer))]
[Serializable]
public readonly record struct WebhookOutcome : IStringEnum
{
    public static readonly WebhookOutcome Delivered = new(Values.Delivered);

    public static readonly WebhookOutcome FailedRetryScheduled = new(Values.FailedRetryScheduled);

    public static readonly WebhookOutcome FailedExhausted = new(Values.FailedExhausted);

    public static readonly WebhookOutcome FailedNoRetry = new(Values.FailedNoRetry);

    public static readonly WebhookOutcome FailedRetryError = new(Values.FailedRetryError);

    public static readonly WebhookOutcome DroppedQueueFull = new(Values.DroppedQueueFull);

    public static readonly WebhookOutcome DroppedPayloadTooLarge = new(
        Values.DroppedPayloadTooLarge
    );

    public static readonly WebhookOutcome SkippedDisabled = new(Values.SkippedDisabled);

    public static readonly WebhookOutcome NotSentConfiguration = new(Values.NotSentConfiguration);

    public WebhookOutcome(string value)
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
    public static WebhookOutcome FromCustom(string value)
    {
        return new WebhookOutcome(value);
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

    public static bool operator ==(WebhookOutcome value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(WebhookOutcome value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(WebhookOutcome value) => value.Value;

    public static explicit operator WebhookOutcome(string value) => new(value);

    internal class WebhookOutcomeSerializer : JsonConverter<WebhookOutcome>
    {
        public override WebhookOutcome Read(
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
            return new WebhookOutcome(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WebhookOutcome value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WebhookOutcome ReadAsPropertyName(
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
            return new WebhookOutcome(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WebhookOutcome value,
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
        public const string Delivered = "delivered";

        public const string FailedRetryScheduled = "failed_retry_scheduled";

        public const string FailedExhausted = "failed_exhausted";

        public const string FailedNoRetry = "failed_no_retry";

        public const string FailedRetryError = "failed_retry_error";

        public const string DroppedQueueFull = "dropped_queue_full";

        public const string DroppedPayloadTooLarge = "dropped_payload_too_large";

        public const string SkippedDisabled = "skipped_disabled";

        public const string NotSentConfiguration = "not_sent_configuration";
    }
}
