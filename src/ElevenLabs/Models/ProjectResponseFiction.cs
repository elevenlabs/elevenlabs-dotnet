using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ProjectResponseFiction.ProjectResponseFictionSerializer))]
[Serializable]
public readonly record struct ProjectResponseFiction : IStringEnum
{
    public static readonly ProjectResponseFiction Fiction = new(Values.Fiction);

    public static readonly ProjectResponseFiction NonFiction = new(Values.NonFiction);

    public ProjectResponseFiction(string value)
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
    public static ProjectResponseFiction FromCustom(string value)
    {
        return new ProjectResponseFiction(value);
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

    public static bool operator ==(ProjectResponseFiction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ProjectResponseFiction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ProjectResponseFiction value) => value.Value;

    public static explicit operator ProjectResponseFiction(string value) => new(value);

    internal class ProjectResponseFictionSerializer : JsonConverter<ProjectResponseFiction>
    {
        public override ProjectResponseFiction Read(
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
            return new ProjectResponseFiction(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ProjectResponseFiction value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ProjectResponseFiction ReadAsPropertyName(
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
            return new ProjectResponseFiction(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ProjectResponseFiction value,
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
