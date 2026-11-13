using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>A string parameter to control text normalization.</summary>
[JsonConverter(
    typeof(TextToDialogueMultiContextRealtimeApplyTextNormalization.TextToDialogueMultiContextRealtimeApplyTextNormalizationSerializer)
)]
[Serializable]
public readonly record struct TextToDialogueMultiContextRealtimeApplyTextNormalization : IStringEnum
{
    public static readonly TextToDialogueMultiContextRealtimeApplyTextNormalization Auto = new(
        Values.Auto
    );

    public static readonly TextToDialogueMultiContextRealtimeApplyTextNormalization On = new(
        Values.On
    );

    public static readonly TextToDialogueMultiContextRealtimeApplyTextNormalization Off = new(
        Values.Off
    );

    public static readonly TextToDialogueMultiContextRealtimeApplyTextNormalization ApplyEnglish =
        new(Values.ApplyEnglish);

    public TextToDialogueMultiContextRealtimeApplyTextNormalization(string value)
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
    public static TextToDialogueMultiContextRealtimeApplyTextNormalization FromCustom(string value)
    {
        return new TextToDialogueMultiContextRealtimeApplyTextNormalization(value);
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
        TextToDialogueMultiContextRealtimeApplyTextNormalization value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        TextToDialogueMultiContextRealtimeApplyTextNormalization value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        TextToDialogueMultiContextRealtimeApplyTextNormalization value
    ) => value.Value;

    public static explicit operator TextToDialogueMultiContextRealtimeApplyTextNormalization(
        string value
    ) => new(value);

    internal class TextToDialogueMultiContextRealtimeApplyTextNormalizationSerializer
        : JsonConverter<TextToDialogueMultiContextRealtimeApplyTextNormalization>
    {
        public override TextToDialogueMultiContextRealtimeApplyTextNormalization Read(
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
            return new TextToDialogueMultiContextRealtimeApplyTextNormalization(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TextToDialogueMultiContextRealtimeApplyTextNormalization value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TextToDialogueMultiContextRealtimeApplyTextNormalization ReadAsPropertyName(
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
            return new TextToDialogueMultiContextRealtimeApplyTextNormalization(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TextToDialogueMultiContextRealtimeApplyTextNormalization value,
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
