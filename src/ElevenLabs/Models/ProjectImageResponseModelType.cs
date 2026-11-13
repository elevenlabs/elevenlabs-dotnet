using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ProjectImageResponseModelType.ProjectImageResponseModelTypeSerializer))]
[Serializable]
public readonly record struct ProjectImageResponseModelType : IStringEnum
{
    public static readonly ProjectImageResponseModelType Image = new(Values.Image);

    public ProjectImageResponseModelType(string value)
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
    public static ProjectImageResponseModelType FromCustom(string value)
    {
        return new ProjectImageResponseModelType(value);
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

    public static bool operator ==(ProjectImageResponseModelType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ProjectImageResponseModelType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ProjectImageResponseModelType value) => value.Value;

    public static explicit operator ProjectImageResponseModelType(string value) => new(value);

    internal class ProjectImageResponseModelTypeSerializer
        : JsonConverter<ProjectImageResponseModelType>
    {
        public override ProjectImageResponseModelType Read(
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
            return new ProjectImageResponseModelType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ProjectImageResponseModelType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ProjectImageResponseModelType ReadAsPropertyName(
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
            return new ProjectImageResponseModelType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ProjectImageResponseModelType value,
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
        public const string Image = "image";
    }
}
