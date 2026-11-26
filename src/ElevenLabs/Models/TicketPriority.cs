using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.CustomerSupport;

[JsonConverter(typeof(TicketPriority.TicketPrioritySerializer))]
[Serializable]
public readonly record struct TicketPriority : IStringEnum
{
    public static readonly TicketPriority Low = new(Values.Low);

    public static readonly TicketPriority Medium = new(Values.Medium);

    public static readonly TicketPriority High = new(Values.High);

    public static readonly TicketPriority Urgent = new(Values.Urgent);

    public TicketPriority(string value)
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
    public static TicketPriority FromCustom(string value)
    {
        return new TicketPriority(value);
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

    public static bool operator ==(TicketPriority value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TicketPriority value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TicketPriority value) => value.Value;

    public static explicit operator TicketPriority(string value) => new(value);

    internal class TicketPrioritySerializer : JsonConverter<TicketPriority>
    {
        public override TicketPriority Read(
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
            return new TicketPriority(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TicketPriority value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TicketPriority ReadAsPropertyName(
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
            return new TicketPriority(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TicketPriority value,
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
        public const string Low = "low";

        public const string Medium = "medium";

        public const string High = "high";

        public const string Urgent = "urgent";
    }
}
