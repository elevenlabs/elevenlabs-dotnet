using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ScribeQuotaExceededErrorMessageType.ScribeQuotaExceededErrorMessageTypeSerializer)
)]
[Serializable]
public readonly record struct ScribeQuotaExceededErrorMessageType : IStringEnum
{
    public static readonly ScribeQuotaExceededErrorMessageType QuotaExceeded = new(
        Values.QuotaExceeded
    );

    public ScribeQuotaExceededErrorMessageType(string value)
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
    public static ScribeQuotaExceededErrorMessageType FromCustom(string value)
    {
        return new ScribeQuotaExceededErrorMessageType(value);
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

    public static bool operator ==(ScribeQuotaExceededErrorMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ScribeQuotaExceededErrorMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ScribeQuotaExceededErrorMessageType value) =>
        value.Value;

    public static explicit operator ScribeQuotaExceededErrorMessageType(string value) => new(value);

    internal class ScribeQuotaExceededErrorMessageTypeSerializer
        : JsonConverter<ScribeQuotaExceededErrorMessageType>
    {
        public override ScribeQuotaExceededErrorMessageType Read(
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
            return new ScribeQuotaExceededErrorMessageType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ScribeQuotaExceededErrorMessageType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ScribeQuotaExceededErrorMessageType ReadAsPropertyName(
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
            return new ScribeQuotaExceededErrorMessageType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ScribeQuotaExceededErrorMessageType value,
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
        public const string QuotaExceeded = "quota_exceeded";
    }
}
