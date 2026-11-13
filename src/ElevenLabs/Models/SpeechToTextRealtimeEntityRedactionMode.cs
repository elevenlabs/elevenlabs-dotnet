using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>How to format redacted entities. 'redacted' replaces with {REDACTED}, 'entity_type' replaces with {ENTITY_TYPE}, 'enumerated_entity_type' replaces with {ENTITY_TYPE_N} where N enumerates each occurrence. Only used when entity_redaction is set.</summary>
[JsonConverter(
    typeof(SpeechToTextRealtimeEntityRedactionMode.SpeechToTextRealtimeEntityRedactionModeSerializer)
)]
[Serializable]
public readonly record struct SpeechToTextRealtimeEntityRedactionMode : IStringEnum
{
    public static readonly SpeechToTextRealtimeEntityRedactionMode EntityType = new(
        Values.EntityType
    );

    public static readonly SpeechToTextRealtimeEntityRedactionMode EnumeratedEntityType = new(
        Values.EnumeratedEntityType
    );

    public static readonly SpeechToTextRealtimeEntityRedactionMode Redacted = new(Values.Redacted);

    public SpeechToTextRealtimeEntityRedactionMode(string value)
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
    public static SpeechToTextRealtimeEntityRedactionMode FromCustom(string value)
    {
        return new SpeechToTextRealtimeEntityRedactionMode(value);
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

    public static bool operator ==(SpeechToTextRealtimeEntityRedactionMode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SpeechToTextRealtimeEntityRedactionMode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SpeechToTextRealtimeEntityRedactionMode value) =>
        value.Value;

    public static explicit operator SpeechToTextRealtimeEntityRedactionMode(string value) =>
        new(value);

    internal class SpeechToTextRealtimeEntityRedactionModeSerializer
        : JsonConverter<SpeechToTextRealtimeEntityRedactionMode>
    {
        public override SpeechToTextRealtimeEntityRedactionMode Read(
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
            return new SpeechToTextRealtimeEntityRedactionMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SpeechToTextRealtimeEntityRedactionMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SpeechToTextRealtimeEntityRedactionMode ReadAsPropertyName(
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
            return new SpeechToTextRealtimeEntityRedactionMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SpeechToTextRealtimeEntityRedactionMode value,
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
        public const string EntityType = "entity_type";

        public const string EnumeratedEntityType = "enumerated_entity_type";

        public const string Redacted = "redacted";
    }
}
