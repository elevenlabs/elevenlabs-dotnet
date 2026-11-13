using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(SessionStartedConfigTimestampsGranularity.SessionStartedConfigTimestampsGranularitySerializer)
)]
[Serializable]
public readonly record struct SessionStartedConfigTimestampsGranularity : IStringEnum
{
    public static readonly SessionStartedConfigTimestampsGranularity None = new(Values.None);

    public static readonly SessionStartedConfigTimestampsGranularity Word = new(Values.Word);

    public static readonly SessionStartedConfigTimestampsGranularity Character = new(
        Values.Character
    );

    public SessionStartedConfigTimestampsGranularity(string value)
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
    public static SessionStartedConfigTimestampsGranularity FromCustom(string value)
    {
        return new SessionStartedConfigTimestampsGranularity(value);
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
        SessionStartedConfigTimestampsGranularity value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        SessionStartedConfigTimestampsGranularity value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(SessionStartedConfigTimestampsGranularity value) =>
        value.Value;

    public static explicit operator SessionStartedConfigTimestampsGranularity(string value) =>
        new(value);

    internal class SessionStartedConfigTimestampsGranularitySerializer
        : JsonConverter<SessionStartedConfigTimestampsGranularity>
    {
        public override SessionStartedConfigTimestampsGranularity Read(
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
            return new SessionStartedConfigTimestampsGranularity(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SessionStartedConfigTimestampsGranularity value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SessionStartedConfigTimestampsGranularity ReadAsPropertyName(
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
            return new SessionStartedConfigTimestampsGranularity(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SessionStartedConfigTimestampsGranularity value,
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
        public const string None = "none";

        public const string Word = "word";

        public const string Character = "character";
    }
}
