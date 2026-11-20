using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ResellerInvoiceLineKind.ResellerInvoiceLineKindSerializer))]
[Serializable]
public readonly record struct ResellerInvoiceLineKind : IStringEnum
{
    public static readonly ResellerInvoiceLineKind Plan = new(Values.Plan);

    public static readonly ResellerInvoiceLineKind Telephony = new(Values.Telephony);

    public static readonly ResellerInvoiceLineKind Overage = new(Values.Overage);

    public static readonly ResellerInvoiceLineKind Proration = new(Values.Proration);

    public static readonly ResellerInvoiceLineKind Adjustment = new(Values.Adjustment);

    public ResellerInvoiceLineKind(string value)
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
    public static ResellerInvoiceLineKind FromCustom(string value)
    {
        return new ResellerInvoiceLineKind(value);
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

    public static bool operator ==(ResellerInvoiceLineKind value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ResellerInvoiceLineKind value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ResellerInvoiceLineKind value) => value.Value;

    public static explicit operator ResellerInvoiceLineKind(string value) => new(value);

    internal class ResellerInvoiceLineKindSerializer : JsonConverter<ResellerInvoiceLineKind>
    {
        public override ResellerInvoiceLineKind Read(
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
            return new ResellerInvoiceLineKind(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ResellerInvoiceLineKind value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ResellerInvoiceLineKind ReadAsPropertyName(
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
            return new ResellerInvoiceLineKind(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ResellerInvoiceLineKind value,
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
        public const string Plan = "plan";

        public const string Telephony = "telephony";

        public const string Overage = "overage";

        public const string Proration = "proration";

        public const string Adjustment = "adjustment";
    }
}
