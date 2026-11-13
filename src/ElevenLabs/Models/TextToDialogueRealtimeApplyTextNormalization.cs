using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>A string parameter to control text normalization.</summary>
[JsonConverter(
    typeof(TextToDialogueRealtimeApplyTextNormalization.TextToDialogueRealtimeApplyTextNormalizationSerializer)
)]
[Serializable]
public readonly record struct TextToDialogueRealtimeApplyTextNormalization : IStringEnum
{
    public static readonly TextToDialogueRealtimeApplyTextNormalization Auto = new(Values.Auto);

    public static readonly TextToDialogueRealtimeApplyTextNormalization On = new(Values.On);

    public static readonly TextToDialogueRealtimeApplyTextNormalization Off = new(Values.Off);

    public static readonly TextToDialogueRealtimeApplyTextNormalization ApplyEnglish = new(
        Values.ApplyEnglish
    );

    public TextToDialogueRealtimeApplyTextNormalization(string value)
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
    public static TextToDialogueRealtimeApplyTextNormalization FromCustom(string value)
    {
        return new TextToDialogueRealtimeApplyTextNormalization(value);
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
        TextToDialogueRealtimeApplyTextNormalization value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        TextToDialogueRealtimeApplyTextNormalization value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(TextToDialogueRealtimeApplyTextNormalization value) =>
        value.Value;

    public static explicit operator TextToDialogueRealtimeApplyTextNormalization(string value) =>
        new(value);

    internal class TextToDialogueRealtimeApplyTextNormalizationSerializer
        : JsonConverter<TextToDialogueRealtimeApplyTextNormalization>
    {
        public override TextToDialogueRealtimeApplyTextNormalization Read(
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
            return new TextToDialogueRealtimeApplyTextNormalization(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TextToDialogueRealtimeApplyTextNormalization value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TextToDialogueRealtimeApplyTextNormalization ReadAsPropertyName(
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
            return new TextToDialogueRealtimeApplyTextNormalization(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TextToDialogueRealtimeApplyTextNormalization value,
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

        public const string ApplyEnglish = "apply_english";
    }
}
