using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(SessionStartedConfigModelId.SessionStartedConfigModelIdSerializer))]
[Serializable]
public readonly record struct SessionStartedConfigModelId : IStringEnum
{
    public static readonly SessionStartedConfigModelId ScribeV2Realtime = new(
        Values.ScribeV2Realtime
    );

    public static readonly SessionStartedConfigModelId ScribeV3Live = new(Values.ScribeV3Live);

    public SessionStartedConfigModelId(string value)
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
    public static SessionStartedConfigModelId FromCustom(string value)
    {
        return new SessionStartedConfigModelId(value);
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

    public static bool operator ==(SessionStartedConfigModelId value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SessionStartedConfigModelId value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SessionStartedConfigModelId value) => value.Value;

    public static explicit operator SessionStartedConfigModelId(string value) => new(value);

    internal class SessionStartedConfigModelIdSerializer
        : JsonConverter<SessionStartedConfigModelId>
    {
        public override SessionStartedConfigModelId Read(
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
            return new SessionStartedConfigModelId(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SessionStartedConfigModelId value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SessionStartedConfigModelId ReadAsPropertyName(
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
            return new SessionStartedConfigModelId(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SessionStartedConfigModelId value,
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
        public const string ScribeV2Realtime = "scribe_v2_realtime";

        public const string ScribeV3Live = "scribe_v3_live";
    }
}
