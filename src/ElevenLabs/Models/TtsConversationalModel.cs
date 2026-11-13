using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(TtsConversationalModel.TtsConversationalModelSerializer))]
[Serializable]
public readonly record struct TtsConversationalModel : IStringEnum
{
    public static readonly TtsConversationalModel ElevenTurboV2 = new(Values.ElevenTurboV2);

    public static readonly TtsConversationalModel ElevenTurboV25 = new(Values.ElevenTurboV25);

    public static readonly TtsConversationalModel ElevenFlashV2 = new(Values.ElevenFlashV2);

    public static readonly TtsConversationalModel ElevenFlashV25 = new(Values.ElevenFlashV25);

    public static readonly TtsConversationalModel ElevenMultilingualV2 = new(
        Values.ElevenMultilingualV2
    );

    public static readonly TtsConversationalModel ElevenV3Conversational = new(
        Values.ElevenV3Conversational
    );

    public static readonly TtsConversationalModel ElevenV4 = new(Values.ElevenV4);

    public static readonly TtsConversationalModel ElevenV4Turbo = new(Values.ElevenV4Turbo);

    public TtsConversationalModel(string value)
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
    public static TtsConversationalModel FromCustom(string value)
    {
        return new TtsConversationalModel(value);
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

    public static bool operator ==(TtsConversationalModel value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TtsConversationalModel value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TtsConversationalModel value) => value.Value;

    public static explicit operator TtsConversationalModel(string value) => new(value);

    internal class TtsConversationalModelSerializer : JsonConverter<TtsConversationalModel>
    {
        public override TtsConversationalModel Read(
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
            return new TtsConversationalModel(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TtsConversationalModel value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TtsConversationalModel ReadAsPropertyName(
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
            return new TtsConversationalModel(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TtsConversationalModel value,
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
        public const string ElevenTurboV2 = "eleven_turbo_v2";

        public const string ElevenTurboV25 = "eleven_turbo_v2_5";

        public const string ElevenFlashV2 = "eleven_flash_v2";

        public const string ElevenFlashV25 = "eleven_flash_v2_5";

        public const string ElevenMultilingualV2 = "eleven_multilingual_v2";

        public const string ElevenV3Conversational = "eleven_v3_conversational";

        public const string ElevenV4 = "eleven_v4";

        public const string ElevenV4Turbo = "eleven_v4_turbo";
    }
}
