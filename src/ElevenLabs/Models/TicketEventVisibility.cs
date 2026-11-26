using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(TicketEventVisibility.TicketEventVisibilitySerializer))]
[Serializable]
public readonly record struct TicketEventVisibility : IStringEnum
{
    public static readonly TicketEventVisibility Public = new(Values.Public);

    public static readonly TicketEventVisibility Internal = new(Values.Internal);

    public TicketEventVisibility(string value)
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
    public static TicketEventVisibility FromCustom(string value)
    {
        return new TicketEventVisibility(value);
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

    public static bool operator ==(TicketEventVisibility value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TicketEventVisibility value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TicketEventVisibility value) => value.Value;

    public static explicit operator TicketEventVisibility(string value) => new(value);

    internal class TicketEventVisibilitySerializer : JsonConverter<TicketEventVisibility>
    {
        public override TicketEventVisibility Read(
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
            return new TicketEventVisibility(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TicketEventVisibility value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TicketEventVisibility ReadAsPropertyName(
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
            return new TicketEventVisibility(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TicketEventVisibility value,
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
        public const string Public = "public";

        public const string Internal = "internal";
    }
}
