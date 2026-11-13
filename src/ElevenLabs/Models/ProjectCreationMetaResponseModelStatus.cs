using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The status of the project creation action.</summary>
[JsonConverter(
    typeof(ProjectCreationMetaResponseModelStatus.ProjectCreationMetaResponseModelStatusSerializer)
)]
[Serializable]
public readonly record struct ProjectCreationMetaResponseModelStatus : IStringEnum
{
    public static readonly ProjectCreationMetaResponseModelStatus Draft = new(Values.Draft);

    public static readonly ProjectCreationMetaResponseModelStatus Pending = new(Values.Pending);

    public static readonly ProjectCreationMetaResponseModelStatus Creating = new(Values.Creating);

    public static readonly ProjectCreationMetaResponseModelStatus Finished = new(Values.Finished);

    public static readonly ProjectCreationMetaResponseModelStatus Failed = new(Values.Failed);

    public ProjectCreationMetaResponseModelStatus(string value)
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
    public static ProjectCreationMetaResponseModelStatus FromCustom(string value)
    {
        return new ProjectCreationMetaResponseModelStatus(value);
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

    public static bool operator ==(ProjectCreationMetaResponseModelStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ProjectCreationMetaResponseModelStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ProjectCreationMetaResponseModelStatus value) =>
        value.Value;

    public static explicit operator ProjectCreationMetaResponseModelStatus(string value) =>
        new(value);

    internal class ProjectCreationMetaResponseModelStatusSerializer
        : JsonConverter<ProjectCreationMetaResponseModelStatus>
    {
        public override ProjectCreationMetaResponseModelStatus Read(
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
            return new ProjectCreationMetaResponseModelStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ProjectCreationMetaResponseModelStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ProjectCreationMetaResponseModelStatus ReadAsPropertyName(
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
            return new ProjectCreationMetaResponseModelStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ProjectCreationMetaResponseModelStatus value,
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
        public const string Draft = "draft";

        public const string Pending = "pending";

        public const string Creating = "creating";

        public const string Finished = "finished";

        public const string Failed = "failed";
    }
}
