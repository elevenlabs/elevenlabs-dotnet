using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ScribeSessionTimeLimitExceededErrorMessageType.ScribeSessionTimeLimitExceededErrorMessageTypeSerializer)
)]
[Serializable]
public readonly record struct ScribeSessionTimeLimitExceededErrorMessageType : IStringEnum
{
    public static readonly ScribeSessionTimeLimitExceededErrorMessageType SessionTimeLimitExceeded =
        new(Values.SessionTimeLimitExceeded);

    public ScribeSessionTimeLimitExceededErrorMessageType(string value)
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
    public static ScribeSessionTimeLimitExceededErrorMessageType FromCustom(string value)
    {
        return new ScribeSessionTimeLimitExceededErrorMessageType(value);
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
        ScribeSessionTimeLimitExceededErrorMessageType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ScribeSessionTimeLimitExceededErrorMessageType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ScribeSessionTimeLimitExceededErrorMessageType value) =>
        value.Value;

    public static explicit operator ScribeSessionTimeLimitExceededErrorMessageType(string value) =>
        new(value);

    internal class ScribeSessionTimeLimitExceededErrorMessageTypeSerializer
        : JsonConverter<ScribeSessionTimeLimitExceededErrorMessageType>
    {
        public override ScribeSessionTimeLimitExceededErrorMessageType Read(
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
            return new ScribeSessionTimeLimitExceededErrorMessageType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ScribeSessionTimeLimitExceededErrorMessageType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ScribeSessionTimeLimitExceededErrorMessageType ReadAsPropertyName(
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
            return new ScribeSessionTimeLimitExceededErrorMessageType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ScribeSessionTimeLimitExceededErrorMessageType value,
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
        public const string SessionTimeLimitExceeded = "session_time_limit_exceeded";
    }
}
