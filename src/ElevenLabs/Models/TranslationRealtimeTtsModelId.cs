using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>TTS model used to synthesize the translated speech.</summary>
[JsonConverter(typeof(TranslationRealtimeTtsModelId.TranslationRealtimeTtsModelIdSerializer))]
[Serializable]
public readonly record struct TranslationRealtimeTtsModelId : IStringEnum
{
    public static readonly TranslationRealtimeTtsModelId ElevenFlashV25 = new(
        Values.ElevenFlashV25
    );

    public static readonly TranslationRealtimeTtsModelId ElevenV3 = new(Values.ElevenV3);

    public static readonly TranslationRealtimeTtsModelId ElevenV4Turbo = new(Values.ElevenV4Turbo);

    public TranslationRealtimeTtsModelId(string value)
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
    public static TranslationRealtimeTtsModelId FromCustom(string value)
    {
        return new TranslationRealtimeTtsModelId(value);
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

    public static bool operator ==(TranslationRealtimeTtsModelId value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TranslationRealtimeTtsModelId value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TranslationRealtimeTtsModelId value) => value.Value;

    public static explicit operator TranslationRealtimeTtsModelId(string value) => new(value);

    internal class TranslationRealtimeTtsModelIdSerializer
        : JsonConverter<TranslationRealtimeTtsModelId>
    {
        public override TranslationRealtimeTtsModelId Read(
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
            return new TranslationRealtimeTtsModelId(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TranslationRealtimeTtsModelId value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TranslationRealtimeTtsModelId ReadAsPropertyName(
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
            return new TranslationRealtimeTtsModelId(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TranslationRealtimeTtsModelId value,
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
        public const string ElevenFlashV25 = "eleven_flash_v2_5";

        public const string ElevenV3 = "eleven_v3";

        public const string ElevenV4Turbo = "eleven_v4_turbo";
    }
}
