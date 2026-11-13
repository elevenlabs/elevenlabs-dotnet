using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(InvoiceResponsePaymentIntentStatussesItem.InvoiceResponsePaymentIntentStatussesItemSerializer)
)]
[Serializable]
public readonly record struct InvoiceResponsePaymentIntentStatussesItem : IStringEnum
{
    public static readonly InvoiceResponsePaymentIntentStatussesItem Canceled = new(
        Values.Canceled
    );

    public static readonly InvoiceResponsePaymentIntentStatussesItem Processing = new(
        Values.Processing
    );

    public static readonly InvoiceResponsePaymentIntentStatussesItem RequiresAction = new(
        Values.RequiresAction
    );

    public static readonly InvoiceResponsePaymentIntentStatussesItem RequiresCapture = new(
        Values.RequiresCapture
    );

    public static readonly InvoiceResponsePaymentIntentStatussesItem RequiresConfirmation = new(
        Values.RequiresConfirmation
    );

    public static readonly InvoiceResponsePaymentIntentStatussesItem RequiresPaymentMethod = new(
        Values.RequiresPaymentMethod
    );

    public static readonly InvoiceResponsePaymentIntentStatussesItem Succeeded = new(
        Values.Succeeded
    );

    public InvoiceResponsePaymentIntentStatussesItem(string value)
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
    public static InvoiceResponsePaymentIntentStatussesItem FromCustom(string value)
    {
        return new InvoiceResponsePaymentIntentStatussesItem(value);
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

    public static bool operator ==(
        InvoiceResponsePaymentIntentStatussesItem value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        InvoiceResponsePaymentIntentStatussesItem value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(InvoiceResponsePaymentIntentStatussesItem value) =>
        value.Value;

    public static explicit operator InvoiceResponsePaymentIntentStatussesItem(string value) =>
        new(value);

    internal class InvoiceResponsePaymentIntentStatussesItemSerializer
        : JsonConverter<InvoiceResponsePaymentIntentStatussesItem>
    {
        public override InvoiceResponsePaymentIntentStatussesItem Read(
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
            return new InvoiceResponsePaymentIntentStatussesItem(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            InvoiceResponsePaymentIntentStatussesItem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override InvoiceResponsePaymentIntentStatussesItem ReadAsPropertyName(
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
            return new InvoiceResponsePaymentIntentStatussesItem(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            InvoiceResponsePaymentIntentStatussesItem value,
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
        public const string Canceled = "canceled";

        public const string Processing = "processing";

        public const string RequiresAction = "requires_action";

        public const string RequiresCapture = "requires_capture";

        public const string RequiresConfirmation = "requires_confirmation";

        public const string RequiresPaymentMethod = "requires_payment_method";

        public const string Succeeded = "succeeded";
    }
}
