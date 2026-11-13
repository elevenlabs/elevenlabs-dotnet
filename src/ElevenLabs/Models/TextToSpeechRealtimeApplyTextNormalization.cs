using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>This parameter controls text normalization with three modes: 'auto', 'on', and 'off'. When set to 'auto', the system will automatically decide whether to apply text normalization (e.g., spelling out numbers). With 'on', text normalization will always be applied, while with 'off', it will be skipped.</summary>
[JsonConverter(
    typeof(TextToSpeechRealtimeApplyTextNormalization.TextToSpeechRealtimeApplyTextNormalizationSerializer)
)]
[Serializable]
public readonly record struct TextToSpeechRealtimeApplyTextNormalization : IStringEnum
{
    public static readonly TextToSpeechRealtimeApplyTextNormalization Auto = new(Values.Auto);

    public static readonly TextToSpeechRealtimeApplyTextNormalization On = new(Values.On);

    public static readonly TextToSpeechRealtimeApplyTextNormalization Off = new(Values.Off);

    public TextToSpeechRealtimeApplyTextNormalization(string value)
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
    public static TextToSpeechRealtimeApplyTextNormalization FromCustom(string value)
    {
        return new TextToSpeechRealtimeApplyTextNormalization(value);
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
        TextToSpeechRealtimeApplyTextNormalization value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        TextToSpeechRealtimeApplyTextNormalization value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(TextToSpeechRealtimeApplyTextNormalization value) =>
        value.Value;

    public static explicit operator TextToSpeechRealtimeApplyTextNormalization(string value) =>
        new(value);

    internal class TextToSpeechRealtimeApplyTextNormalizationSerializer
        : JsonConverter<TextToSpeechRealtimeApplyTextNormalization>
    {
        public override TextToSpeechRealtimeApplyTextNormalization Read(
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
            return new TextToSpeechRealtimeApplyTextNormalization(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TextToSpeechRealtimeApplyTextNormalization value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TextToSpeechRealtimeApplyTextNormalization ReadAsPropertyName(
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
            return new TextToSpeechRealtimeApplyTextNormalization(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TextToSpeechRealtimeApplyTextNormalization value,
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
        public const string Auto = "auto";

        public const string On = "on";

        public const string Off = "off";
    }
}
