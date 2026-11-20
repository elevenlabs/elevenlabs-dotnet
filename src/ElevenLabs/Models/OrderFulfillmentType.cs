using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>How an order reaches the customer.</summary>
[JsonConverter(typeof(OrderFulfillmentType.OrderFulfillmentTypeSerializer))]
[Serializable]
public readonly record struct OrderFulfillmentType : IStringEnum
{
    public static readonly OrderFulfillmentType Pickup = new(Values.Pickup);

    public static readonly OrderFulfillmentType Delivery = new(Values.Delivery);

    public static readonly OrderFulfillmentType Digital = new(Values.Digital);

    public OrderFulfillmentType(string value)
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
    public static OrderFulfillmentType FromCustom(string value)
    {
        return new OrderFulfillmentType(value);
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

    public static bool operator ==(OrderFulfillmentType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OrderFulfillmentType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OrderFulfillmentType value) => value.Value;

    public static explicit operator OrderFulfillmentType(string value) => new(value);

    internal class OrderFulfillmentTypeSerializer : JsonConverter<OrderFulfillmentType>
    {
        public override OrderFulfillmentType Read(
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
            return new OrderFulfillmentType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            OrderFulfillmentType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override OrderFulfillmentType ReadAsPropertyName(
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
            return new OrderFulfillmentType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            OrderFulfillmentType value,
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
        public const string Pickup = "pickup";

        public const string Delivery = "delivery";

        public const string Digital = "digital";
    }
}
