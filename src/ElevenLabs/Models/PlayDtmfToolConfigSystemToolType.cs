using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(PlayDtmfToolConfigSystemToolType.PlayDtmfToolConfigSystemToolTypeSerializer))]
[Serializable]
public readonly record struct PlayDtmfToolConfigSystemToolType : IStringEnum
{
    public static readonly PlayDtmfToolConfigSystemToolType PlayKeypadTouchTone = new(
        Values.PlayKeypadTouchTone
    );

    public PlayDtmfToolConfigSystemToolType(string value)
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
    public static PlayDtmfToolConfigSystemToolType FromCustom(string value)
    {
        return new PlayDtmfToolConfigSystemToolType(value);
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

    public static bool operator ==(PlayDtmfToolConfigSystemToolType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PlayDtmfToolConfigSystemToolType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PlayDtmfToolConfigSystemToolType value) => value.Value;

    public static explicit operator PlayDtmfToolConfigSystemToolType(string value) => new(value);

    internal class PlayDtmfToolConfigSystemToolTypeSerializer
        : JsonConverter<PlayDtmfToolConfigSystemToolType>
    {
        public override PlayDtmfToolConfigSystemToolType Read(
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
            return new PlayDtmfToolConfigSystemToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PlayDtmfToolConfigSystemToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PlayDtmfToolConfigSystemToolType ReadAsPropertyName(
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
            return new PlayDtmfToolConfigSystemToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PlayDtmfToolConfigSystemToolType value,
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
        public const string PlayKeypadTouchTone = "play_keypad_touch_tone";
    }
}
