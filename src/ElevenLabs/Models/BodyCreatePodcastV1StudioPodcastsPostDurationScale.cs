using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>
/// Duration of the generated podcast. Must be one of:
/// short - produces podcasts shorter than 3 minutes.
/// default - produces podcasts roughly between 3-7 minutes.
/// long - produces podcasts longer than 7 minutes.
/// </summary>
[JsonConverter(
    typeof(BodyCreatePodcastV1StudioPodcastsPostDurationScale.BodyCreatePodcastV1StudioPodcastsPostDurationScaleSerializer)
)]
[Serializable]
public readonly record struct BodyCreatePodcastV1StudioPodcastsPostDurationScale : IStringEnum
{
    public static readonly BodyCreatePodcastV1StudioPodcastsPostDurationScale Short = new(
        Values.Short
    );

    public static readonly BodyCreatePodcastV1StudioPodcastsPostDurationScale Default = new(
        Values.Default
    );

    public static readonly BodyCreatePodcastV1StudioPodcastsPostDurationScale Long = new(
        Values.Long
    );

    public BodyCreatePodcastV1StudioPodcastsPostDurationScale(string value)
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
    public static BodyCreatePodcastV1StudioPodcastsPostDurationScale FromCustom(string value)
    {
        return new BodyCreatePodcastV1StudioPodcastsPostDurationScale(value);
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
        BodyCreatePodcastV1StudioPodcastsPostDurationScale value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BodyCreatePodcastV1StudioPodcastsPostDurationScale value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        BodyCreatePodcastV1StudioPodcastsPostDurationScale value
    ) => value.Value;

    public static explicit operator BodyCreatePodcastV1StudioPodcastsPostDurationScale(
        string value
    ) => new(value);

    internal class BodyCreatePodcastV1StudioPodcastsPostDurationScaleSerializer
        : JsonConverter<BodyCreatePodcastV1StudioPodcastsPostDurationScale>
    {
        public override BodyCreatePodcastV1StudioPodcastsPostDurationScale Read(
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
            return new BodyCreatePodcastV1StudioPodcastsPostDurationScale(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BodyCreatePodcastV1StudioPodcastsPostDurationScale value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BodyCreatePodcastV1StudioPodcastsPostDurationScale ReadAsPropertyName(
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
            return new BodyCreatePodcastV1StudioPodcastsPostDurationScale(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BodyCreatePodcastV1StudioPodcastsPostDurationScale value,
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
        public const string Short = "short";

        public const string Default = "default";

        public const string Long = "long";
    }
}
