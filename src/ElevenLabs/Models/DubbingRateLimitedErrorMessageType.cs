using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(DubbingRateLimitedErrorMessageType.DubbingRateLimitedErrorMessageTypeSerializer)
)]
[Serializable]
public readonly record struct DubbingRateLimitedErrorMessageType : IStringEnum
{
    public static readonly DubbingRateLimitedErrorMessageType RateLimited = new(Values.RateLimited);

    public DubbingRateLimitedErrorMessageType(string value)
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
    public static DubbingRateLimitedErrorMessageType FromCustom(string value)
    {
        return new DubbingRateLimitedErrorMessageType(value);
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

    public static bool operator ==(DubbingRateLimitedErrorMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DubbingRateLimitedErrorMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DubbingRateLimitedErrorMessageType value) => value.Value;

    public static explicit operator DubbingRateLimitedErrorMessageType(string value) => new(value);

    internal class DubbingRateLimitedErrorMessageTypeSerializer
        : JsonConverter<DubbingRateLimitedErrorMessageType>
    {
        public override DubbingRateLimitedErrorMessageType Read(
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
            return new DubbingRateLimitedErrorMessageType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DubbingRateLimitedErrorMessageType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DubbingRateLimitedErrorMessageType ReadAsPropertyName(
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
            return new DubbingRateLimitedErrorMessageType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DubbingRateLimitedErrorMessageType value,
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
