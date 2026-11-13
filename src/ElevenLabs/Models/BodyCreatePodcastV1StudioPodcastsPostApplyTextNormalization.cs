using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(BodyCreatePodcastV1StudioPodcastsPostApplyTextNormalization.BodyCreatePodcastV1StudioPodcastsPostApplyTextNormalizationSerializer)
)]
[Serializable]
public readonly record struct BodyCreatePodcastV1StudioPodcastsPostApplyTextNormalization
    : IStringEnum
{
    public static readonly BodyCreatePodcastV1StudioPodcastsPostApplyTextNormalization Auto = new(
        Values.Auto
    );

    public static readonly BodyCreatePodcastV1StudioPodcastsPostApplyTextNormalization On = new(
        Values.On
    );

    public static readonly BodyCreatePodcastV1StudioPodcastsPostApplyTextNormalization Off = new(
        Values.Off
    );

    public static readonly BodyCreatePodcastV1StudioPodcastsPostApplyTextNormalization ApplyEnglish =
        new(Values.ApplyEnglish);

    public BodyCreatePodcastV1StudioPodcastsPostApplyTextNormalization(string value)
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
    public static BodyCreatePodcastV1StudioPodcastsPostApplyTextNormalization FromCustom(
        string value
    )
    {
        return new BodyCreatePodcastV1StudioPodcastsPostApplyTextNormalization(value);
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
        BodyCreatePodcastV1StudioPodcastsPostApplyTextNormalization value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BodyCreatePodcastV1StudioPodcastsPostApplyTextNormalization value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        BodyCreatePodcastV1StudioPodcastsPostApplyTextNormalization value
    ) => value.Value;

    public static explicit operator BodyCreatePodcastV1StudioPodcastsPostApplyTextNormalization(
        string value
    ) => new(value);

    internal class BodyCreatePodcastV1StudioPodcastsPostApplyTextNormalizationSerializer
        : JsonConverter<BodyCreatePodcastV1StudioPodcastsPostApplyTextNormalization>
    {
        public override BodyCreatePodcastV1StudioPodcastsPostApplyTextNormalization Read(
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
            return new BodyCreatePodcastV1StudioPodcastsPostApplyTextNormalization(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BodyCreatePodcastV1StudioPodcastsPostApplyTextNormalization value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BodyCreatePodcastV1StudioPodcastsPostApplyTextNormalization ReadAsPropertyName(
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
            return new BodyCreatePodcastV1StudioPodcastsPostApplyTextNormalization(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BodyCreatePodcastV1StudioPodcastsPostApplyTextNormalization value,
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
