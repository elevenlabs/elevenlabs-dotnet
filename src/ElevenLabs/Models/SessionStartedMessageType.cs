using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(SessionStartedMessageType.SessionStartedMessageTypeSerializer))]
[Serializable]
public readonly record struct SessionStartedMessageType : IStringEnum
{
    public static readonly SessionStartedMessageType SessionStarted = new(Values.SessionStarted);

    public SessionStartedMessageType(string value)
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
    public static SessionStartedMessageType FromCustom(string value)
    {
        return new SessionStartedMessageType(value);
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

    public static bool operator ==(SessionStartedMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SessionStartedMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SessionStartedMessageType value) => value.Value;

    public static explicit operator SessionStartedMessageType(string value) => new(value);

    internal class SessionStartedMessageTypeSerializer : JsonConverter<SessionStartedMessageType>
    {
        public override SessionStartedMessageType Read(
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
            return new SessionStartedMessageType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SessionStartedMessageType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SessionStartedMessageType ReadAsPropertyName(
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
            return new SessionStartedMessageType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SessionStartedMessageType value,
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
        public const string SessionStarted = "session_started";
    }
}
