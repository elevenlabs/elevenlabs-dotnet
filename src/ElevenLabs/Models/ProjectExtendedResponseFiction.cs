using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ProjectExtendedResponseFiction.ProjectExtendedResponseFictionSerializer))]
[Serializable]
public readonly record struct ProjectExtendedResponseFiction : IStringEnum
{
    public static readonly ProjectExtendedResponseFiction Fiction = new(Values.Fiction);

    public static readonly ProjectExtendedResponseFiction NonFiction = new(Values.NonFiction);

    public ProjectExtendedResponseFiction(string value)
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
    public static ProjectExtendedResponseFiction FromCustom(string value)
    {
        return new ProjectExtendedResponseFiction(value);
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

    public static bool operator ==(ProjectExtendedResponseFiction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ProjectExtendedResponseFiction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ProjectExtendedResponseFiction value) => value.Value;

    public static explicit operator ProjectExtendedResponseFiction(string value) => new(value);

    internal class ProjectExtendedResponseFictionSerializer
        : JsonConverter<ProjectExtendedResponseFiction>
    {
        public override ProjectExtendedResponseFiction Read(
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
            return new ProjectExtendedResponseFiction(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ProjectExtendedResponseFiction value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ProjectExtendedResponseFiction ReadAsPropertyName(
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
            return new ProjectExtendedResponseFiction(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ProjectExtendedResponseFiction value,
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
        public const string Fiction = "fiction";

        public const string NonFiction = "non-fiction";
    }
}
