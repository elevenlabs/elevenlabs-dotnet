using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ProjectCreationMetaType.ProjectCreationMetaTypeSerializer))]
[Serializable]
public readonly record struct ProjectCreationMetaType : IStringEnum
{
    public static readonly ProjectCreationMetaType Blank = new(Values.Blank);

    public static readonly ProjectCreationMetaType GeneratePodcast = new(Values.GeneratePodcast);

    public static readonly ProjectCreationMetaType AutoAssignVoices = new(Values.AutoAssignVoices);

    public static readonly ProjectCreationMetaType DubVideo = new(Values.DubVideo);

    public static readonly ProjectCreationMetaType ImportSpeech = new(Values.ImportSpeech);

    public ProjectCreationMetaType(string value)
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
    public static ProjectCreationMetaType FromCustom(string value)
    {
        return new ProjectCreationMetaType(value);
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

    public static bool operator ==(ProjectCreationMetaType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ProjectCreationMetaType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ProjectCreationMetaType value) => value.Value;

    public static explicit operator ProjectCreationMetaType(string value) => new(value);

    internal class ProjectCreationMetaTypeSerializer : JsonConverter<ProjectCreationMetaType>
    {
        public override ProjectCreationMetaType Read(
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
            return new ProjectCreationMetaType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ProjectCreationMetaType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ProjectCreationMetaType ReadAsPropertyName(
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
            return new ProjectCreationMetaType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ProjectCreationMetaType value,
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

        public const string GeneratePodcast = "generate_podcast";

        public const string AutoAssignVoices = "auto_assign_voices";

        public const string DubVideo = "dub_video";

        public const string ImportSpeech = "import_speech";
    }
}
