using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Studio;

[JsonConverter(
    typeof(BodyCreateStudioProjectV1StudioProjectsPostApplyTextNormalization.BodyCreateStudioProjectV1StudioProjectsPostApplyTextNormalizationSerializer)
)]
[Serializable]
public readonly record struct BodyCreateStudioProjectV1StudioProjectsPostApplyTextNormalization
    : IStringEnum
{
    public static readonly BodyCreateStudioProjectV1StudioProjectsPostApplyTextNormalization Auto =
        new(Values.Auto);

    public static readonly BodyCreateStudioProjectV1StudioProjectsPostApplyTextNormalization On =
        new(Values.On);

    public static readonly BodyCreateStudioProjectV1StudioProjectsPostApplyTextNormalization Off =
        new(Values.Off);

    public static readonly BodyCreateStudioProjectV1StudioProjectsPostApplyTextNormalization ApplyEnglish =
        new(Values.ApplyEnglish);

    public BodyCreateStudioProjectV1StudioProjectsPostApplyTextNormalization(string value)
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
    public static BodyCreateStudioProjectV1StudioProjectsPostApplyTextNormalization FromCustom(
        string value
    )
    {
        return new BodyCreateStudioProjectV1StudioProjectsPostApplyTextNormalization(value);
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
        BodyCreateStudioProjectV1StudioProjectsPostApplyTextNormalization value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BodyCreateStudioProjectV1StudioProjectsPostApplyTextNormalization value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        BodyCreateStudioProjectV1StudioProjectsPostApplyTextNormalization value
    ) => value.Value;

    public static explicit operator BodyCreateStudioProjectV1StudioProjectsPostApplyTextNormalization(
        string value
    ) => new(value);

    internal class BodyCreateStudioProjectV1StudioProjectsPostApplyTextNormalizationSerializer
        : JsonConverter<BodyCreateStudioProjectV1StudioProjectsPostApplyTextNormalization>
    {
        public override BodyCreateStudioProjectV1StudioProjectsPostApplyTextNormalization Read(
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
            return new BodyCreateStudioProjectV1StudioProjectsPostApplyTextNormalization(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            BodyCreateStudioProjectV1StudioProjectsPostApplyTextNormalization value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BodyCreateStudioProjectV1StudioProjectsPostApplyTextNormalization ReadAsPropertyName(
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
            return new BodyCreateStudioProjectV1StudioProjectsPostApplyTextNormalization(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BodyCreateStudioProjectV1StudioProjectsPostApplyTextNormalization value,
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
