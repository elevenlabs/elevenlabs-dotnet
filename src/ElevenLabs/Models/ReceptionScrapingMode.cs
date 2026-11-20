using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ReceptionScrapingMode.ReceptionScrapingModeSerializer))]
[Serializable]
public readonly record struct ReceptionScrapingMode : IStringEnum
{
    public static readonly ReceptionScrapingMode SinglePage = new(Values.SinglePage);

    public static readonly ReceptionScrapingMode DeepScan = new(Values.DeepScan);

    public static readonly ReceptionScrapingMode QuickScan = new(Values.QuickScan);

    public ReceptionScrapingMode(string value)
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
    public static ReceptionScrapingMode FromCustom(string value)
    {
        return new ReceptionScrapingMode(value);
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

    public static bool operator ==(ReceptionScrapingMode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ReceptionScrapingMode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ReceptionScrapingMode value) => value.Value;

    public static explicit operator ReceptionScrapingMode(string value) => new(value);

    internal class ReceptionScrapingModeSerializer : JsonConverter<ReceptionScrapingMode>
    {
        public override ReceptionScrapingMode Read(
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
            return new ReceptionScrapingMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReceptionScrapingMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ReceptionScrapingMode ReadAsPropertyName(
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
            return new ReceptionScrapingMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReceptionScrapingMode value,
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
        public const string SinglePage = "single_page";

        public const string DeepScan = "deep_scan";

        public const string QuickScan = "quick_scan";
    }
}
