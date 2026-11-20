using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>`open` while the card is still being retried; `void` once retries ran out and the workspace's plan was ended.</summary>
[JsonConverter(typeof(ResellerInvoiceStatus.ResellerInvoiceStatusSerializer))]
[Serializable]
public readonly record struct ResellerInvoiceStatus : IStringEnum
{
    public static readonly ResellerInvoiceStatus Paid = new(Values.Paid);

    public static readonly ResellerInvoiceStatus Open = new(Values.Open);

    public static readonly ResellerInvoiceStatus Void = new(Values.Void);

    public ResellerInvoiceStatus(string value)
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
    public static ResellerInvoiceStatus FromCustom(string value)
    {
        return new ResellerInvoiceStatus(value);
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

    public static bool operator ==(ResellerInvoiceStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ResellerInvoiceStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ResellerInvoiceStatus value) => value.Value;

    public static explicit operator ResellerInvoiceStatus(string value) => new(value);

    internal class ResellerInvoiceStatusSerializer : JsonConverter<ResellerInvoiceStatus>
    {
        public override ResellerInvoiceStatus Read(
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
            return new ResellerInvoiceStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ResellerInvoiceStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ResellerInvoiceStatus ReadAsPropertyName(
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
            return new ResellerInvoiceStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ResellerInvoiceStatus value,
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
        public const string Paid = "paid";

        public const string Open = "open";

        public const string Void = "void";
    }
}
