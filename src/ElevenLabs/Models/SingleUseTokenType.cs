using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Tokens;

[JsonConverter(typeof(SingleUseTokenType.SingleUseTokenTypeSerializer))]
[Serializable]
public readonly record struct SingleUseTokenType : IStringEnum
{
    public static readonly SingleUseTokenType RealtimeScribe = new(Values.RealtimeScribe);

    public static readonly SingleUseTokenType BatchScribe = new(Values.BatchScribe);

    public static readonly SingleUseTokenType TtsWebsocket = new(Values.TtsWebsocket);

    public SingleUseTokenType(string value)
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
    public static SingleUseTokenType FromCustom(string value)
    {
        return new SingleUseTokenType(value);
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

    public static bool operator ==(SingleUseTokenType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SingleUseTokenType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SingleUseTokenType value) => value.Value;

    public static explicit operator SingleUseTokenType(string value) => new(value);

    internal class SingleUseTokenTypeSerializer : JsonConverter<SingleUseTokenType>
    {
        public override SingleUseTokenType Read(
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
            return new SingleUseTokenType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SingleUseTokenType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SingleUseTokenType ReadAsPropertyName(
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
            return new SingleUseTokenType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SingleUseTokenType value,
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
        public const string RealtimeScribe = "realtime_scribe";

        public const string BatchScribe = "batch_scribe";

        public const string TtsWebsocket = "tts_websocket";
    }
}
