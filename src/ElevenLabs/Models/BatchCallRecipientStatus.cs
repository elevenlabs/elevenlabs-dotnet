using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(BatchCallRecipientStatus.BatchCallRecipientStatusSerializer))]
[Serializable]
public readonly record struct BatchCallRecipientStatus : IStringEnum
{
    public static readonly BatchCallRecipientStatus Pending = new(Values.Pending);

    public static readonly BatchCallRecipientStatus Dispatched = new(Values.Dispatched);

    public static readonly BatchCallRecipientStatus Initiated = new(Values.Initiated);

    public static readonly BatchCallRecipientStatus InProgress = new(Values.InProgress);

    public static readonly BatchCallRecipientStatus Completed = new(Values.Completed);

    public static readonly BatchCallRecipientStatus Failed = new(Values.Failed);

    public static readonly BatchCallRecipientStatus Cancelled = new(Values.Cancelled);

    public static readonly BatchCallRecipientStatus Voicemail = new(Values.Voicemail);

    public BatchCallRecipientStatus(string value)
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
    public static BatchCallRecipientStatus FromCustom(string value)
    {
        return new BatchCallRecipientStatus(value);
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

    public static bool operator ==(BatchCallRecipientStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BatchCallRecipientStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BatchCallRecipientStatus value) => value.Value;

    public static explicit operator BatchCallRecipientStatus(string value) => new(value);

    internal class BatchCallRecipientStatusSerializer : JsonConverter<BatchCallRecipientStatus>
    {
        public override BatchCallRecipientStatus Read(
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
            return new BatchCallRecipientStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BatchCallRecipientStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BatchCallRecipientStatus ReadAsPropertyName(
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
            return new BatchCallRecipientStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BatchCallRecipientStatus value,
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
        public const string Pending = "pending";

        public const string Dispatched = "dispatched";

        public const string Initiated = "initiated";

        public const string InProgress = "in_progress";

        public const string Completed = "completed";

        public const string Failed = "failed";

        public const string Cancelled = "cancelled";

        public const string Voicemail = "voicemail";
    }
}
