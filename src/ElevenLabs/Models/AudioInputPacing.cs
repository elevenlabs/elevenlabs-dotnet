using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>``BURSTY`` clients stream ahead of wall time, so decisions use the audio clock.</summary>
[JsonConverter(typeof(AudioInputPacing.AudioInputPacingSerializer))]
[Serializable]
public readonly record struct AudioInputPacing : IStringEnum
{
    public static readonly AudioInputPacing Realtime = new(Values.Realtime);

    public static readonly AudioInputPacing Bursty = new(Values.Bursty);

    public AudioInputPacing(string value)
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
    public static AudioInputPacing FromCustom(string value)
    {
        return new AudioInputPacing(value);
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

    public static bool operator ==(AudioInputPacing value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AudioInputPacing value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AudioInputPacing value) => value.Value;

    public static explicit operator AudioInputPacing(string value) => new(value);

    internal class AudioInputPacingSerializer : JsonConverter<AudioInputPacing>
    {
        public override AudioInputPacing Read(
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
            return new AudioInputPacing(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AudioInputPacing value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AudioInputPacing ReadAsPropertyName(
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
            return new AudioInputPacing(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AudioInputPacing value,
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
        public const string Realtime = "realtime";

        public const string Bursty = "bursty";
    }
}
