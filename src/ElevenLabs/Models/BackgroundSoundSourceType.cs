using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The type of background sound source.</summary>
[JsonConverter(typeof(BackgroundSoundSourceType.BackgroundSoundSourceTypeSerializer))]
[Serializable]
public readonly record struct BackgroundSoundSourceType : IStringEnum
{
    public static readonly BackgroundSoundSourceType Preset = new(Values.Preset);

    public BackgroundSoundSourceType(string value)
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
    public static BackgroundSoundSourceType FromCustom(string value)
    {
        return new BackgroundSoundSourceType(value);
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

    public static bool operator ==(BackgroundSoundSourceType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BackgroundSoundSourceType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BackgroundSoundSourceType value) => value.Value;

    public static explicit operator BackgroundSoundSourceType(string value) => new(value);

    internal class BackgroundSoundSourceTypeSerializer : JsonConverter<BackgroundSoundSourceType>
    {
        public override BackgroundSoundSourceType Read(
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
            return new BackgroundSoundSourceType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BackgroundSoundSourceType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BackgroundSoundSourceType ReadAsPropertyName(
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
            return new BackgroundSoundSourceType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BackgroundSoundSourceType value,
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
        public const string Preset = "preset";
    }
}
