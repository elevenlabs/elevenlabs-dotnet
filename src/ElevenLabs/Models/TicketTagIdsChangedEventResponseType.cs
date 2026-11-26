using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(TicketTagIdsChangedEventResponseType.TicketTagIdsChangedEventResponseTypeSerializer)
)]
[Serializable]
public readonly record struct TicketTagIdsChangedEventResponseType : IStringEnum
{
    public static readonly TicketTagIdsChangedEventResponseType TagIdsChanged = new(
        Values.TagIdsChanged
    );

    public TicketTagIdsChangedEventResponseType(string value)
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
    public static TicketTagIdsChangedEventResponseType FromCustom(string value)
    {
        return new TicketTagIdsChangedEventResponseType(value);
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

    public static bool operator ==(TicketTagIdsChangedEventResponseType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TicketTagIdsChangedEventResponseType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TicketTagIdsChangedEventResponseType value) =>
        value.Value;

    public static explicit operator TicketTagIdsChangedEventResponseType(string value) =>
        new(value);

    internal class TicketTagIdsChangedEventResponseTypeSerializer
        : JsonConverter<TicketTagIdsChangedEventResponseType>
    {
        public override TicketTagIdsChangedEventResponseType Read(
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
            return new TicketTagIdsChangedEventResponseType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TicketTagIdsChangedEventResponseType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TicketTagIdsChangedEventResponseType ReadAsPropertyName(
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
            return new TicketTagIdsChangedEventResponseType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TicketTagIdsChangedEventResponseType value,
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
        public const string TagIdsChanged = "tag_ids_changed";
    }
}
