using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(DubbingQueueOverflowErrorMessageType.DubbingQueueOverflowErrorMessageTypeSerializer)
)]
[Serializable]
public readonly record struct DubbingQueueOverflowErrorMessageType : IStringEnum
{
    public static readonly DubbingQueueOverflowErrorMessageType QueueOverflow = new(
        Values.QueueOverflow
    );

    public DubbingQueueOverflowErrorMessageType(string value)
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
    public static DubbingQueueOverflowErrorMessageType FromCustom(string value)
    {
        return new DubbingQueueOverflowErrorMessageType(value);
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

    public static bool operator ==(DubbingQueueOverflowErrorMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DubbingQueueOverflowErrorMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DubbingQueueOverflowErrorMessageType value) =>
        value.Value;

    public static explicit operator DubbingQueueOverflowErrorMessageType(string value) =>
        new(value);

    internal class DubbingQueueOverflowErrorMessageTypeSerializer
        : JsonConverter<DubbingQueueOverflowErrorMessageType>
    {
        public override DubbingQueueOverflowErrorMessageType Read(
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
            return new DubbingQueueOverflowErrorMessageType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DubbingQueueOverflowErrorMessageType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DubbingQueueOverflowErrorMessageType ReadAsPropertyName(
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
            return new DubbingQueueOverflowErrorMessageType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DubbingQueueOverflowErrorMessageType value,
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
        public const string QueueOverflow = "queue_overflow";
    }
}
