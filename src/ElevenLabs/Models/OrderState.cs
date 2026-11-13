using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Productions;

[JsonConverter(typeof(OrderState.OrderStateSerializer))]
[Serializable]
public readonly record struct OrderState : IStringEnum
{
    public static readonly OrderState Open = new(Values.Open);

    public static readonly OrderState Submitted = new(Values.Submitted);

    public static readonly OrderState Paid = new(Values.Paid);

    public static readonly OrderState Accepted = new(Values.Accepted);

    public static readonly OrderState Rejected = new(Values.Rejected);

    public static readonly OrderState Done = new(Values.Done);

    public static readonly OrderState Cancelling = new(Values.Cancelling);

    public static readonly OrderState Cancelled = new(Values.Cancelled);

    public static readonly OrderState Expired = new(Values.Expired);

    public static readonly OrderState Merged = new(Values.Merged);

    public OrderState(string value)
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
    public static OrderState FromCustom(string value)
    {
        return new OrderState(value);
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

    public static bool operator ==(OrderState value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(OrderState value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OrderState value) => value.Value;

    public static explicit operator OrderState(string value) => new(value);

    internal class OrderStateSerializer : JsonConverter<OrderState>
    {
        public override OrderState Read(
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
            return new OrderState(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            OrderState value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override OrderState ReadAsPropertyName(
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
            return new OrderState(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            OrderState value,
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

        public const string Submitted = "submitted";

        public const string Paid = "paid";

        public const string Accepted = "accepted";

        public const string Rejected = "rejected";

        public const string Done = "done";

        public const string Cancelling = "cancelling";

        public const string Cancelled = "cancelled";

        public const string Expired = "expired";

        public const string Merged = "merged";
    }
}
