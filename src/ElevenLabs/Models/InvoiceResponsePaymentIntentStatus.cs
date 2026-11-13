using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(InvoiceResponsePaymentIntentStatus.InvoiceResponsePaymentIntentStatusSerializer)
)]
[Serializable]
public readonly record struct InvoiceResponsePaymentIntentStatus : IStringEnum
{
    public static readonly InvoiceResponsePaymentIntentStatus Canceled = new(Values.Canceled);

    public static readonly InvoiceResponsePaymentIntentStatus Processing = new(Values.Processing);

    public static readonly InvoiceResponsePaymentIntentStatus RequiresAction = new(
        Values.RequiresAction
    );

    public static readonly InvoiceResponsePaymentIntentStatus RequiresCapture = new(
        Values.RequiresCapture
    );

    public static readonly InvoiceResponsePaymentIntentStatus RequiresConfirmation = new(
        Values.RequiresConfirmation
    );

    public static readonly InvoiceResponsePaymentIntentStatus RequiresPaymentMethod = new(
        Values.RequiresPaymentMethod
    );

    public static readonly InvoiceResponsePaymentIntentStatus Succeeded = new(Values.Succeeded);

    public InvoiceResponsePaymentIntentStatus(string value)
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
    public static InvoiceResponsePaymentIntentStatus FromCustom(string value)
    {
        return new InvoiceResponsePaymentIntentStatus(value);
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

    public static bool operator ==(InvoiceResponsePaymentIntentStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(InvoiceResponsePaymentIntentStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(InvoiceResponsePaymentIntentStatus value) => value.Value;

    public static explicit operator InvoiceResponsePaymentIntentStatus(string value) => new(value);

    internal class InvoiceResponsePaymentIntentStatusSerializer
        : JsonConverter<InvoiceResponsePaymentIntentStatus>
    {
        public override InvoiceResponsePaymentIntentStatus Read(
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
            return new InvoiceResponsePaymentIntentStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            InvoiceResponsePaymentIntentStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override InvoiceResponsePaymentIntentStatus ReadAsPropertyName(
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
            return new InvoiceResponsePaymentIntentStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            InvoiceResponsePaymentIntentStatus value,
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
