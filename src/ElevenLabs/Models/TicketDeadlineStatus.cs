using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.CustomerSupport;

[JsonConverter(typeof(TicketDeadlineStatus.TicketDeadlineStatusSerializer))]
[Serializable]
public readonly record struct TicketDeadlineStatus : IStringEnum
{
    public static readonly TicketDeadlineStatus Overdue = new(Values.Overdue);

    public static readonly TicketDeadlineStatus OnTrack = new(Values.OnTrack);

    public TicketDeadlineStatus(string value)
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
    public static TicketDeadlineStatus FromCustom(string value)
    {
        return new TicketDeadlineStatus(value);
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

    public static bool operator ==(TicketDeadlineStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TicketDeadlineStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TicketDeadlineStatus value) => value.Value;

    public static explicit operator TicketDeadlineStatus(string value) => new(value);

    internal class TicketDeadlineStatusSerializer : JsonConverter<TicketDeadlineStatus>
    {
        public override TicketDeadlineStatus Read(
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
            return new TicketDeadlineStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TicketDeadlineStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TicketDeadlineStatus ReadAsPropertyName(
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
            return new TicketDeadlineStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TicketDeadlineStatus value,
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
        public const string Overdue = "overdue";

        public const string OnTrack = "on_track";
    }
}
