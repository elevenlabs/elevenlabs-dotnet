using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(BodyCreatesAudioNativeEnabledProjectV1AudioNativePostApplyTextNormalization.BodyCreatesAudioNativeEnabledProjectV1AudioNativePostApplyTextNormalizationSerializer)
)]
[Serializable]
public readonly record struct BodyCreatesAudioNativeEnabledProjectV1AudioNativePostApplyTextNormalization
    : IStringEnum
{
    public static readonly BodyCreatesAudioNativeEnabledProjectV1AudioNativePostApplyTextNormalization Auto =
        new(Values.Auto);

    public static readonly BodyCreatesAudioNativeEnabledProjectV1AudioNativePostApplyTextNormalization On =
        new(Values.On);

    public static readonly BodyCreatesAudioNativeEnabledProjectV1AudioNativePostApplyTextNormalization Off =
        new(Values.Off);

    public static readonly BodyCreatesAudioNativeEnabledProjectV1AudioNativePostApplyTextNormalization ApplyEnglish =
        new(Values.ApplyEnglish);

    public BodyCreatesAudioNativeEnabledProjectV1AudioNativePostApplyTextNormalization(string value)
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
    public static BodyCreatesAudioNativeEnabledProjectV1AudioNativePostApplyTextNormalization FromCustom(
        string value
    )
    {
        return new BodyCreatesAudioNativeEnabledProjectV1AudioNativePostApplyTextNormalization(
            value
        );
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
        BodyCreatesAudioNativeEnabledProjectV1AudioNativePostApplyTextNormalization value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BodyCreatesAudioNativeEnabledProjectV1AudioNativePostApplyTextNormalization value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        BodyCreatesAudioNativeEnabledProjectV1AudioNativePostApplyTextNormalization value
    ) => value.Value;

    public static explicit operator BodyCreatesAudioNativeEnabledProjectV1AudioNativePostApplyTextNormalization(
        string value
    ) => new(value);

    internal class BodyCreatesAudioNativeEnabledProjectV1AudioNativePostApplyTextNormalizationSerializer
        : JsonConverter<BodyCreatesAudioNativeEnabledProjectV1AudioNativePostApplyTextNormalization>
    {
        public override BodyCreatesAudioNativeEnabledProjectV1AudioNativePostApplyTextNormalization Read(
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
            return new BodyCreatesAudioNativeEnabledProjectV1AudioNativePostApplyTextNormalization(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            BodyCreatesAudioNativeEnabledProjectV1AudioNativePostApplyTextNormalization value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BodyCreatesAudioNativeEnabledProjectV1AudioNativePostApplyTextNormalization ReadAsPropertyName(
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
            return new BodyCreatesAudioNativeEnabledProjectV1AudioNativePostApplyTextNormalization(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BodyCreatesAudioNativeEnabledProjectV1AudioNativePostApplyTextNormalization value,
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
