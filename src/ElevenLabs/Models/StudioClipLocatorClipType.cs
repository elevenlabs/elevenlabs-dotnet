using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(StudioClipLocatorClipType.StudioClipLocatorClipTypeSerializer))]
[Serializable]
public readonly record struct StudioClipLocatorClipType : IStringEnum
{
    public static readonly StudioClipLocatorClipType Video = new(Values.Video);

    public static readonly StudioClipLocatorClipType Image = new(Values.Image);

    public static readonly StudioClipLocatorClipType ExternalAudio = new(Values.ExternalAudio);

    public static readonly StudioClipLocatorClipType TtsNode = new(Values.TtsNode);

    public StudioClipLocatorClipType(string value)
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
    public static StudioClipLocatorClipType FromCustom(string value)
    {
        return new StudioClipLocatorClipType(value);
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

    public static bool operator ==(StudioClipLocatorClipType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(StudioClipLocatorClipType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(StudioClipLocatorClipType value) => value.Value;

    public static explicit operator StudioClipLocatorClipType(string value) => new(value);

    internal class StudioClipLocatorClipTypeSerializer : JsonConverter<StudioClipLocatorClipType>
    {
        public override StudioClipLocatorClipType Read(
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
            return new StudioClipLocatorClipType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            StudioClipLocatorClipType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override StudioClipLocatorClipType ReadAsPropertyName(
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
            return new StudioClipLocatorClipType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            StudioClipLocatorClipType value,
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
        public const string Video = "video";

        public const string Image = "image";

        public const string ExternalAudio = "external_audio";

        public const string TtsNode = "tts_node";
    }
}
