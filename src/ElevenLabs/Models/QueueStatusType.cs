using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(QueueStatusType.QueueStatusTypeSerializer))]
[Serializable]
public readonly record struct QueueStatusType : IStringEnum
{
    public static readonly QueueStatusType QueueStatus = new(Values.QueueStatus);

    public QueueStatusType(string value)
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
    public static QueueStatusType FromCustom(string value)
    {
        return new QueueStatusType(value);
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

    public static bool operator ==(QueueStatusType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(QueueStatusType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(QueueStatusType value) => value.Value;

    public static explicit operator QueueStatusType(string value) => new(value);

    internal class QueueStatusTypeSerializer : JsonConverter<QueueStatusType>
    {
        public override QueueStatusType Read(
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
            return new QueueStatusType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            QueueStatusType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override QueueStatusType ReadAsPropertyName(
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
            return new QueueStatusType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            QueueStatusType value,
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
        public const string QueueStatus = "queue_status";
    }
}
