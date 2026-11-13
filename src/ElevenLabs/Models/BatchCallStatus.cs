using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(BatchCallStatus.BatchCallStatusSerializer))]
[Serializable]
public readonly record struct BatchCallStatus : IStringEnum
{
    public static readonly BatchCallStatus Pending = new(Values.Pending);

    public static readonly BatchCallStatus InProgress = new(Values.InProgress);

    public static readonly BatchCallStatus Completed = new(Values.Completed);

    public static readonly BatchCallStatus Failed = new(Values.Failed);

    public static readonly BatchCallStatus Cancelled = new(Values.Cancelled);

    public BatchCallStatus(string value)
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
    public static BatchCallStatus FromCustom(string value)
    {
        return new BatchCallStatus(value);
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

    public static bool operator ==(BatchCallStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BatchCallStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BatchCallStatus value) => value.Value;

    public static explicit operator BatchCallStatus(string value) => new(value);

    internal class BatchCallStatusSerializer : JsonConverter<BatchCallStatus>
    {
        public override BatchCallStatus Read(
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
            return new BatchCallStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BatchCallStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BatchCallStatus ReadAsPropertyName(
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
            return new BatchCallStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BatchCallStatus value,
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

        public const string InProgress = "in_progress";

        public const string Completed = "completed";

        public const string Failed = "failed";

        public const string Cancelled = "cancelled";
    }
}
