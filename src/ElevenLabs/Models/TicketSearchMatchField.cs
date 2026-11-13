using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(TicketSearchMatchField.TicketSearchMatchFieldSerializer))]
[Serializable]
public readonly record struct TicketSearchMatchField : IStringEnum
{
    public static readonly TicketSearchMatchField Title = new(Values.Title);

    public static readonly TicketSearchMatchField Description = new(Values.Description);

    public static readonly TicketSearchMatchField Comment = new(Values.Comment);

    public static readonly TicketSearchMatchField TurnComment = new(Values.TurnComment);

    public TicketSearchMatchField(string value)
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
    public static TicketSearchMatchField FromCustom(string value)
    {
        return new TicketSearchMatchField(value);
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

    public static bool operator ==(TicketSearchMatchField value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TicketSearchMatchField value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TicketSearchMatchField value) => value.Value;

    public static explicit operator TicketSearchMatchField(string value) => new(value);

    internal class TicketSearchMatchFieldSerializer : JsonConverter<TicketSearchMatchField>
    {
        public override TicketSearchMatchField Read(
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
            return new TicketSearchMatchField(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TicketSearchMatchField value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TicketSearchMatchField ReadAsPropertyName(
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
            return new TicketSearchMatchField(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TicketSearchMatchField value,
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
        public const string Title = "title";

        public const string Description = "description";

        public const string Comment = "comment";

        public const string TurnComment = "turn_comment";
    }
}
