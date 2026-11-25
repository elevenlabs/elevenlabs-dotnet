using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(SubtitlingQueueOverflowErrorMessageType.SubtitlingQueueOverflowErrorMessageTypeSerializer)
)]
[Serializable]
public readonly record struct SubtitlingQueueOverflowErrorMessageType : IStringEnum
{
    public static readonly SubtitlingQueueOverflowErrorMessageType QueueOverflow = new(
        Values.QueueOverflow
    );

    public SubtitlingQueueOverflowErrorMessageType(string value)
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
    public static SubtitlingQueueOverflowErrorMessageType FromCustom(string value)
    {
        return new SubtitlingQueueOverflowErrorMessageType(value);
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

    public static bool operator ==(SubtitlingQueueOverflowErrorMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SubtitlingQueueOverflowErrorMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SubtitlingQueueOverflowErrorMessageType value) =>
        value.Value;

    public static explicit operator SubtitlingQueueOverflowErrorMessageType(string value) =>
        new(value);

    internal class SubtitlingQueueOverflowErrorMessageTypeSerializer
        : JsonConverter<SubtitlingQueueOverflowErrorMessageType>
    {
        public override SubtitlingQueueOverflowErrorMessageType Read(
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
            return new SubtitlingQueueOverflowErrorMessageType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SubtitlingQueueOverflowErrorMessageType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SubtitlingQueueOverflowErrorMessageType ReadAsPropertyName(
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
            return new SubtitlingQueueOverflowErrorMessageType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SubtitlingQueueOverflowErrorMessageType value,
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
