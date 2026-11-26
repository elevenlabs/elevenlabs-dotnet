using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.CustomerSupport;

[JsonConverter(typeof(TicketStatus.TicketStatusSerializer))]
[Serializable]
public readonly record struct TicketStatus : IStringEnum
{
    public static readonly TicketStatus Open = new(Values.Open);

    public static readonly TicketStatus Pending = new(Values.Pending);

    public static readonly TicketStatus Waiting = new(Values.Waiting);

    public static readonly TicketStatus Resolved = new(Values.Resolved);

    public TicketStatus(string value)
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
    public static TicketStatus FromCustom(string value)
    {
        return new TicketStatus(value);
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

    public static bool operator ==(TicketStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TicketStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TicketStatus value) => value.Value;

    public static explicit operator TicketStatus(string value) => new(value);

    internal class TicketStatusSerializer : JsonConverter<TicketStatus>
    {
        public override TicketStatus Read(
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
            return new TicketStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TicketStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TicketStatus ReadAsPropertyName(
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
            return new TicketStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TicketStatus value,
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
        public const string Open = "open";

        public const string Pending = "pending";

        public const string Waiting = "waiting";

        public const string Resolved = "resolved";
    }
}
