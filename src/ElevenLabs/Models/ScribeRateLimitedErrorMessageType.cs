using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ScribeRateLimitedErrorMessageType.ScribeRateLimitedErrorMessageTypeSerializer)
)]
[Serializable]
public readonly record struct ScribeRateLimitedErrorMessageType : IStringEnum
{
    public static readonly ScribeRateLimitedErrorMessageType RateLimited = new(Values.RateLimited);

    public ScribeRateLimitedErrorMessageType(string value)
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
    public static ScribeRateLimitedErrorMessageType FromCustom(string value)
    {
        return new ScribeRateLimitedErrorMessageType(value);
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

    public static bool operator ==(ScribeRateLimitedErrorMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ScribeRateLimitedErrorMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ScribeRateLimitedErrorMessageType value) => value.Value;

    public static explicit operator ScribeRateLimitedErrorMessageType(string value) => new(value);

    internal class ScribeRateLimitedErrorMessageTypeSerializer
        : JsonConverter<ScribeRateLimitedErrorMessageType>
    {
        public override ScribeRateLimitedErrorMessageType Read(
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
            return new ScribeRateLimitedErrorMessageType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ScribeRateLimitedErrorMessageType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ScribeRateLimitedErrorMessageType ReadAsPropertyName(
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
            return new ScribeRateLimitedErrorMessageType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ScribeRateLimitedErrorMessageType value,
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
        public const string RateLimited = "rate_limited";
    }
}
