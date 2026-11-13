using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Productions.Orders;

[JsonConverter(typeof(OrderItemKind1.OrderItemKind1Serializer))]
[Serializable]
public readonly record struct OrderItemKind1 : IStringEnum
{
    public static readonly OrderItemKind1 Dub = new(Values.Dub);

    public static readonly OrderItemKind1 Subtitles = new(Values.Subtitles);

    public static readonly OrderItemKind1 Transcription = new(Values.Transcription);

    public OrderItemKind1(string value)
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
    public static OrderItemKind1 FromCustom(string value)
    {
        return new OrderItemKind1(value);
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

    public static bool operator ==(OrderItemKind1 value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OrderItemKind1 value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OrderItemKind1 value) => value.Value;

    public static explicit operator OrderItemKind1(string value) => new(value);

    internal class OrderItemKind1Serializer : JsonConverter<OrderItemKind1>
    {
        public override OrderItemKind1 Read(
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
            return new OrderItemKind1(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            OrderItemKind1 value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override OrderItemKind1 ReadAsPropertyName(
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
            return new OrderItemKind1(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            OrderItemKind1 value,
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
        public const string Dub = "dub";

        public const string Subtitles = "subtitles";

        public const string Transcription = "transcription";
    }
}
