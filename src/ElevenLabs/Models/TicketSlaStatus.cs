using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.CustomerSupport;

[JsonConverter(typeof(TicketSlaStatus.TicketSlaStatusSerializer))]
[Serializable]
public readonly record struct TicketSlaStatus : IStringEnum
{
    public static readonly TicketSlaStatus Overdue = new(Values.Overdue);

    public static readonly TicketSlaStatus OnTrack = new(Values.OnTrack);

    public TicketSlaStatus(string value)
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
    public static TicketSlaStatus FromCustom(string value)
    {
        return new TicketSlaStatus(value);
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

    public static bool operator ==(TicketSlaStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TicketSlaStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TicketSlaStatus value) => value.Value;

    public static explicit operator TicketSlaStatus(string value) => new(value);

    internal class TicketSlaStatusSerializer : JsonConverter<TicketSlaStatus>
    {
        public override TicketSlaStatus Read(
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
            return new TicketSlaStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TicketSlaStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TicketSlaStatus ReadAsPropertyName(
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
            return new TicketSlaStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TicketSlaStatus value,
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
