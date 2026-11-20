using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>
/// Regulatory standing of a number in a country that requires paperwork.
///
/// Null for numbers that need no paperwork, such as US and Canadian numbers.
/// </summary>
[JsonConverter(typeof(ReceptionPhoneRegulatoryStatus.ReceptionPhoneRegulatoryStatusSerializer))]
[Serializable]
public readonly record struct ReceptionPhoneRegulatoryStatus : IStringEnum
{
    public static readonly ReceptionPhoneRegulatoryStatus Held = new(Values.Held);

    public static readonly ReceptionPhoneRegulatoryStatus Approved = new(Values.Approved);

    public ReceptionPhoneRegulatoryStatus(string value)
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
    public static ReceptionPhoneRegulatoryStatus FromCustom(string value)
    {
        return new ReceptionPhoneRegulatoryStatus(value);
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

    public static bool operator ==(ReceptionPhoneRegulatoryStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ReceptionPhoneRegulatoryStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ReceptionPhoneRegulatoryStatus value) => value.Value;

    public static explicit operator ReceptionPhoneRegulatoryStatus(string value) => new(value);

    internal class ReceptionPhoneRegulatoryStatusSerializer
        : JsonConverter<ReceptionPhoneRegulatoryStatus>
    {
        public override ReceptionPhoneRegulatoryStatus Read(
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
            return new ReceptionPhoneRegulatoryStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReceptionPhoneRegulatoryStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ReceptionPhoneRegulatoryStatus ReadAsPropertyName(
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
            return new ReceptionPhoneRegulatoryStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReceptionPhoneRegulatoryStatus value,
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
        public const string Held = "held";

        public const string Approved = "approved";
    }
}
