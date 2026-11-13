using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Studio;

[JsonConverter(
    typeof(BodyCreateStudioProjectV1StudioProjectsPostTargetAudience.BodyCreateStudioProjectV1StudioProjectsPostTargetAudienceSerializer)
)]
[Serializable]
public readonly record struct BodyCreateStudioProjectV1StudioProjectsPostTargetAudience
    : IStringEnum
{
    public static readonly BodyCreateStudioProjectV1StudioProjectsPostTargetAudience Children = new(
        Values.Children
    );

    public static readonly BodyCreateStudioProjectV1StudioProjectsPostTargetAudience YoungAdult =
        new(Values.YoungAdult);

    public static readonly BodyCreateStudioProjectV1StudioProjectsPostTargetAudience Adult = new(
        Values.Adult
    );

    public static readonly BodyCreateStudioProjectV1StudioProjectsPostTargetAudience AllAges = new(
        Values.AllAges
    );

    public BodyCreateStudioProjectV1StudioProjectsPostTargetAudience(string value)
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
    public static BodyCreateStudioProjectV1StudioProjectsPostTargetAudience FromCustom(string value)
    {
        return new BodyCreateStudioProjectV1StudioProjectsPostTargetAudience(value);
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
        BodyCreateStudioProjectV1StudioProjectsPostTargetAudience value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BodyCreateStudioProjectV1StudioProjectsPostTargetAudience value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        BodyCreateStudioProjectV1StudioProjectsPostTargetAudience value
    ) => value.Value;

    public static explicit operator BodyCreateStudioProjectV1StudioProjectsPostTargetAudience(
        string value
    ) => new(value);

    internal class BodyCreateStudioProjectV1StudioProjectsPostTargetAudienceSerializer
        : JsonConverter<BodyCreateStudioProjectV1StudioProjectsPostTargetAudience>
    {
        public override BodyCreateStudioProjectV1StudioProjectsPostTargetAudience Read(
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
            return new BodyCreateStudioProjectV1StudioProjectsPostTargetAudience(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BodyCreateStudioProjectV1StudioProjectsPostTargetAudience value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BodyCreateStudioProjectV1StudioProjectsPostTargetAudience ReadAsPropertyName(
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
            return new BodyCreateStudioProjectV1StudioProjectsPostTargetAudience(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BodyCreateStudioProjectV1StudioProjectsPostTargetAudience value,
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
        public const string Children = "children";

        public const string YoungAdult = "young adult";

        public const string Adult = "adult";

        public const string AllAges = "all ages";
    }
}
