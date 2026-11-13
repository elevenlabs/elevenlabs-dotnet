using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>This parameter controls text normalization with three modes: 'auto', 'on', and 'off'. When set to 'auto', the system will automatically decide whether to apply text normalization (e.g., spelling out numbers). With 'on', text normalization will always be applied, while with 'off', it will be skipped.</summary>
[JsonConverter(
    typeof(BodyTextToSpeechFullWithTimestampsApplyTextNormalization.BodyTextToSpeechFullWithTimestampsApplyTextNormalizationSerializer)
)]
[Serializable]
public readonly record struct BodyTextToSpeechFullWithTimestampsApplyTextNormalization : IStringEnum
{
    public static readonly BodyTextToSpeechFullWithTimestampsApplyTextNormalization Auto = new(
        Values.Auto
    );

    public static readonly BodyTextToSpeechFullWithTimestampsApplyTextNormalization On = new(
        Values.On
    );

    public static readonly BodyTextToSpeechFullWithTimestampsApplyTextNormalization Off = new(
        Values.Off
    );

    public BodyTextToSpeechFullWithTimestampsApplyTextNormalization(string value)
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
    public static BodyTextToSpeechFullWithTimestampsApplyTextNormalization FromCustom(string value)
    {
        return new BodyTextToSpeechFullWithTimestampsApplyTextNormalization(value);
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
        BodyTextToSpeechFullWithTimestampsApplyTextNormalization value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BodyTextToSpeechFullWithTimestampsApplyTextNormalization value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        BodyTextToSpeechFullWithTimestampsApplyTextNormalization value
    ) => value.Value;

    public static explicit operator BodyTextToSpeechFullWithTimestampsApplyTextNormalization(
        string value
    ) => new(value);

    internal class BodyTextToSpeechFullWithTimestampsApplyTextNormalizationSerializer
        : JsonConverter<BodyTextToSpeechFullWithTimestampsApplyTextNormalization>
    {
        public override BodyTextToSpeechFullWithTimestampsApplyTextNormalization Read(
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
            return new BodyTextToSpeechFullWithTimestampsApplyTextNormalization(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BodyTextToSpeechFullWithTimestampsApplyTextNormalization value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BodyTextToSpeechFullWithTimestampsApplyTextNormalization ReadAsPropertyName(
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
            return new BodyTextToSpeechFullWithTimestampsApplyTextNormalization(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BodyTextToSpeechFullWithTimestampsApplyTextNormalization value,
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
