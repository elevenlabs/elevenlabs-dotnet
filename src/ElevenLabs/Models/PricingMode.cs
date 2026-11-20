using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>
/// Whether a catalog item's price and duration are known up front.
///
/// - `fixed`: the catalog price and duration apply (the default).
/// - `quote`: neither is known until the owner has seen the job. The
///   receptionist collects intake answers and files a quote request instead
///   of booking a slot or taking an order.
/// </summary>
[JsonConverter(typeof(PricingMode.PricingModeSerializer))]
[Serializable]
public readonly record struct PricingMode : IStringEnum
{
    public static readonly PricingMode Fixed = new(Values.Fixed);

    public static readonly PricingMode Quote = new(Values.Quote);

    public PricingMode(string value)
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
    public static PricingMode FromCustom(string value)
    {
        return new PricingMode(value);
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

    public static bool operator ==(PricingMode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PricingMode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PricingMode value) => value.Value;

    public static explicit operator PricingMode(string value) => new(value);

    internal class PricingModeSerializer : JsonConverter<PricingMode>
    {
        public override PricingMode Read(
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
            return new PricingMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PricingMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PricingMode ReadAsPropertyName(
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
            return new PricingMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PricingMode value,
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
        public const string Fixed = "fixed";

        public const string Quote = "quote";
    }
}
