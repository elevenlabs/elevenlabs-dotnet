using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ProjectResponseSourceType.ProjectResponseSourceTypeSerializer))]
[Serializable]
public readonly record struct ProjectResponseSourceType : IStringEnum
{
    public static readonly ProjectResponseSourceType Blank = new(Values.Blank);

    public static readonly ProjectResponseSourceType Book = new(Values.Book);

    public static readonly ProjectResponseSourceType Article = new(Values.Article);

    public static readonly ProjectResponseSourceType Genfm = new(Values.Genfm);

    public static readonly ProjectResponseSourceType Video = new(Values.Video);

    public static readonly ProjectResponseSourceType Screenplay = new(Values.Screenplay);

    public ProjectResponseSourceType(string value)
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
    public static ProjectResponseSourceType FromCustom(string value)
    {
        return new ProjectResponseSourceType(value);
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

    public static bool operator ==(ProjectResponseSourceType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ProjectResponseSourceType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ProjectResponseSourceType value) => value.Value;

    public static explicit operator ProjectResponseSourceType(string value) => new(value);

    internal class ProjectResponseSourceTypeSerializer : JsonConverter<ProjectResponseSourceType>
    {
        public override ProjectResponseSourceType Read(
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
            return new ProjectResponseSourceType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ProjectResponseSourceType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ProjectResponseSourceType ReadAsPropertyName(
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
            return new ProjectResponseSourceType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ProjectResponseSourceType value,
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
