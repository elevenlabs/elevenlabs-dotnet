using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The state of the project.</summary>
[JsonConverter(typeof(ProjectState.ProjectStateSerializer))]
[Serializable]
public readonly record struct ProjectState : IStringEnum
{
    public static readonly ProjectState Creating = new(Values.Creating);

    public static readonly ProjectState Default = new(Values.Default);

    public static readonly ProjectState Converting = new(Values.Converting);

    public static readonly ProjectState InQueue = new(Values.InQueue);

    public ProjectState(string value)
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
    public static ProjectState FromCustom(string value)
    {
        return new ProjectState(value);
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

    public static bool operator ==(ProjectState value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ProjectState value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ProjectState value) => value.Value;

    public static explicit operator ProjectState(string value) => new(value);

    internal class ProjectStateSerializer : JsonConverter<ProjectState>
    {
        public override ProjectState Read(
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
            return new ProjectState(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ProjectState value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ProjectState ReadAsPropertyName(
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
            return new ProjectState(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ProjectState value,
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
        public const string Creating = "creating";

        public const string Default = "default";

        public const string Converting = "converting";

        public const string InQueue = "in_queue";
    }
}
