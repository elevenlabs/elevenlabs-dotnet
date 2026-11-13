using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Studio;

[JsonConverter(
    typeof(BodyCreateStudioProjectV1StudioProjectsPostSourceType.BodyCreateStudioProjectV1StudioProjectsPostSourceTypeSerializer)
)]
[Serializable]
public readonly record struct BodyCreateStudioProjectV1StudioProjectsPostSourceType : IStringEnum
{
    public static readonly BodyCreateStudioProjectV1StudioProjectsPostSourceType Blank = new(
        Values.Blank
    );

    public static readonly BodyCreateStudioProjectV1StudioProjectsPostSourceType Book = new(
        Values.Book
    );

    public static readonly BodyCreateStudioProjectV1StudioProjectsPostSourceType Article = new(
        Values.Article
    );

    public static readonly BodyCreateStudioProjectV1StudioProjectsPostSourceType Genfm = new(
        Values.Genfm
    );

    public static readonly BodyCreateStudioProjectV1StudioProjectsPostSourceType Video = new(
        Values.Video
    );

    public static readonly BodyCreateStudioProjectV1StudioProjectsPostSourceType Screenplay = new(
        Values.Screenplay
    );

    public BodyCreateStudioProjectV1StudioProjectsPostSourceType(string value)
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
    public static BodyCreateStudioProjectV1StudioProjectsPostSourceType FromCustom(string value)
    {
        return new BodyCreateStudioProjectV1StudioProjectsPostSourceType(value);
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
        BodyCreateStudioProjectV1StudioProjectsPostSourceType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BodyCreateStudioProjectV1StudioProjectsPostSourceType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        BodyCreateStudioProjectV1StudioProjectsPostSourceType value
    ) => value.Value;

    public static explicit operator BodyCreateStudioProjectV1StudioProjectsPostSourceType(
        string value
    ) => new(value);

    internal class BodyCreateStudioProjectV1StudioProjectsPostSourceTypeSerializer
        : JsonConverter<BodyCreateStudioProjectV1StudioProjectsPostSourceType>
    {
        public override BodyCreateStudioProjectV1StudioProjectsPostSourceType Read(
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
            return new BodyCreateStudioProjectV1StudioProjectsPostSourceType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BodyCreateStudioProjectV1StudioProjectsPostSourceType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BodyCreateStudioProjectV1StudioProjectsPostSourceType ReadAsPropertyName(
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
            return new BodyCreateStudioProjectV1StudioProjectsPostSourceType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BodyCreateStudioProjectV1StudioProjectsPostSourceType value,
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
        public const string Blank = "blank";

        public const string Book = "book";

        public const string Article = "article";

        public const string Genfm = "genfm";

        public const string Video = "video";

        public const string Screenplay = "screenplay";
    }
}
