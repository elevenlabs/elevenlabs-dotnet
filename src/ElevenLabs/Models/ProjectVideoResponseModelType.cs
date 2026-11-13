using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ProjectVideoResponseModelType.ProjectVideoResponseModelTypeSerializer))]
[Serializable]
public readonly record struct ProjectVideoResponseModelType : IStringEnum
{
    public static readonly ProjectVideoResponseModelType Video = new(Values.Video);

    public ProjectVideoResponseModelType(string value)
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
    public static ProjectVideoResponseModelType FromCustom(string value)
    {
        return new ProjectVideoResponseModelType(value);
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

    public static bool operator ==(ProjectVideoResponseModelType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ProjectVideoResponseModelType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ProjectVideoResponseModelType value) => value.Value;

    public static explicit operator ProjectVideoResponseModelType(string value) => new(value);

    internal class ProjectVideoResponseModelTypeSerializer
        : JsonConverter<ProjectVideoResponseModelType>
    {
        public override ProjectVideoResponseModelType Read(
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
            return new ProjectVideoResponseModelType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ProjectVideoResponseModelType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ProjectVideoResponseModelType ReadAsPropertyName(
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
            return new ProjectVideoResponseModelType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ProjectVideoResponseModelType value,
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
        public const string Video = "video";
    }
}
