using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(SfxModelId.SfxModelIdSerializer))]
[Serializable]
public readonly record struct SfxModelId : IStringEnum
{
    public static readonly SfxModelId ElevenTextToSoundV2 = new(Values.ElevenTextToSoundV2);

    public static readonly SfxModelId ElevenTextToSoundV3 = new(Values.ElevenTextToSoundV3);

    public SfxModelId(string value)
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
    public static SfxModelId FromCustom(string value)
    {
        return new SfxModelId(value);
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

    public static bool operator ==(SfxModelId value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(SfxModelId value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SfxModelId value) => value.Value;

    public static explicit operator SfxModelId(string value) => new(value);

    internal class SfxModelIdSerializer : JsonConverter<SfxModelId>
    {
        public override SfxModelId Read(
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
            return new SfxModelId(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SfxModelId value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SfxModelId ReadAsPropertyName(
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
            return new SfxModelId(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SfxModelId value,
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
        public const string ElevenTextToSoundV2 = "eleven_text_to_sound_v2";

        public const string ElevenTextToSoundV3 = "eleven_text_to_sound_v3";
    }
}
