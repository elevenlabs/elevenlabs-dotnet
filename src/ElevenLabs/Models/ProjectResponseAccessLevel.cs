using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The access level of the project.</summary>
[JsonConverter(typeof(ProjectResponseAccessLevel.ProjectResponseAccessLevelSerializer))]
[Serializable]
public readonly record struct ProjectResponseAccessLevel : IStringEnum
{
    public static readonly ProjectResponseAccessLevel Admin = new(Values.Admin);

    public static readonly ProjectResponseAccessLevel Editor = new(Values.Editor);

    public static readonly ProjectResponseAccessLevel Commenter = new(Values.Commenter);

    public static readonly ProjectResponseAccessLevel Viewer = new(Values.Viewer);

    public ProjectResponseAccessLevel(string value)
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
    public static ProjectResponseAccessLevel FromCustom(string value)
    {
        return new ProjectResponseAccessLevel(value);
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

    public static bool operator ==(ProjectResponseAccessLevel value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ProjectResponseAccessLevel value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ProjectResponseAccessLevel value) => value.Value;

    public static explicit operator ProjectResponseAccessLevel(string value) => new(value);

    internal class ProjectResponseAccessLevelSerializer : JsonConverter<ProjectResponseAccessLevel>
    {
        public override ProjectResponseAccessLevel Read(
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
            return new ProjectResponseAccessLevel(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ProjectResponseAccessLevel value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ProjectResponseAccessLevel ReadAsPropertyName(
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
            return new ProjectResponseAccessLevel(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ProjectResponseAccessLevel value,
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
        public const string Admin = "admin";

        public const string Editor = "editor";

        public const string Commenter = "commenter";

        public const string Viewer = "viewer";
    }
}
