using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ProjectExtendedResponseSourceType.ProjectExtendedResponseSourceTypeSerializer)
)]
[Serializable]
public readonly record struct ProjectExtendedResponseSourceType : IStringEnum
{
    public static readonly ProjectExtendedResponseSourceType Blank = new(Values.Blank);

    public static readonly ProjectExtendedResponseSourceType Book = new(Values.Book);

    public static readonly ProjectExtendedResponseSourceType Article = new(Values.Article);

    public static readonly ProjectExtendedResponseSourceType Genfm = new(Values.Genfm);

    public static readonly ProjectExtendedResponseSourceType Video = new(Values.Video);

    public static readonly ProjectExtendedResponseSourceType Screenplay = new(Values.Screenplay);

    public ProjectExtendedResponseSourceType(string value)
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
    public static ProjectExtendedResponseSourceType FromCustom(string value)
    {
        return new ProjectExtendedResponseSourceType(value);
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

    public static bool operator ==(ProjectExtendedResponseSourceType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ProjectExtendedResponseSourceType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ProjectExtendedResponseSourceType value) => value.Value;

    public static explicit operator ProjectExtendedResponseSourceType(string value) => new(value);

    internal class ProjectExtendedResponseSourceTypeSerializer
        : JsonConverter<ProjectExtendedResponseSourceType>
    {
        public override ProjectExtendedResponseSourceType Read(
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
            return new ProjectExtendedResponseSourceType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ProjectExtendedResponseSourceType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ProjectExtendedResponseSourceType ReadAsPropertyName(
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
            return new ProjectExtendedResponseSourceType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ProjectExtendedResponseSourceType value,
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
