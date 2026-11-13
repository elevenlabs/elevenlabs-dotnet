using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The access level of the project.</summary>
[JsonConverter(
    typeof(ProjectExtendedResponseAccessLevel.ProjectExtendedResponseAccessLevelSerializer)
)]
[Serializable]
public readonly record struct ProjectExtendedResponseAccessLevel : IStringEnum
{
    public static readonly ProjectExtendedResponseAccessLevel Admin = new(Values.Admin);

    public static readonly ProjectExtendedResponseAccessLevel Editor = new(Values.Editor);

    public static readonly ProjectExtendedResponseAccessLevel Commenter = new(Values.Commenter);

    public static readonly ProjectExtendedResponseAccessLevel Viewer = new(Values.Viewer);

    public ProjectExtendedResponseAccessLevel(string value)
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
    public static ProjectExtendedResponseAccessLevel FromCustom(string value)
    {
        return new ProjectExtendedResponseAccessLevel(value);
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

    public static bool operator ==(ProjectExtendedResponseAccessLevel value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ProjectExtendedResponseAccessLevel value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ProjectExtendedResponseAccessLevel value) => value.Value;

    public static explicit operator ProjectExtendedResponseAccessLevel(string value) => new(value);

    internal class ProjectExtendedResponseAccessLevelSerializer
        : JsonConverter<ProjectExtendedResponseAccessLevel>
    {
        public override ProjectExtendedResponseAccessLevel Read(
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
            return new ProjectExtendedResponseAccessLevel(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ProjectExtendedResponseAccessLevel value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ProjectExtendedResponseAccessLevel ReadAsPropertyName(
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
            return new ProjectExtendedResponseAccessLevel(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ProjectExtendedResponseAccessLevel value,
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
