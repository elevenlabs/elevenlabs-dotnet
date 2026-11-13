using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ProjectExtendedResponseAspectRatio.ProjectExtendedResponseAspectRatioSerializer)
)]
[Serializable]
public readonly record struct ProjectExtendedResponseAspectRatio : IStringEnum
{
    public static readonly ProjectExtendedResponseAspectRatio Sixteen9 = new(Values.Sixteen9);

    public static readonly ProjectExtendedResponseAspectRatio Nine16 = new(Values.Nine16);

    public static readonly ProjectExtendedResponseAspectRatio Four5 = new(Values.Four5);

    public static readonly ProjectExtendedResponseAspectRatio One1 = new(Values.One1);

    public ProjectExtendedResponseAspectRatio(string value)
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
    public static ProjectExtendedResponseAspectRatio FromCustom(string value)
    {
        return new ProjectExtendedResponseAspectRatio(value);
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

    public static bool operator ==(ProjectExtendedResponseAspectRatio value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ProjectExtendedResponseAspectRatio value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ProjectExtendedResponseAspectRatio value) => value.Value;

    public static explicit operator ProjectExtendedResponseAspectRatio(string value) => new(value);

    internal class ProjectExtendedResponseAspectRatioSerializer
        : JsonConverter<ProjectExtendedResponseAspectRatio>
    {
        public override ProjectExtendedResponseAspectRatio Read(
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
            return new ProjectExtendedResponseAspectRatio(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ProjectExtendedResponseAspectRatio value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ProjectExtendedResponseAspectRatio ReadAsPropertyName(
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
            return new ProjectExtendedResponseAspectRatio(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ProjectExtendedResponseAspectRatio value,
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
        public const string Sixteen9 = "16:9";

        public const string Nine16 = "9:16";

        public const string Four5 = "4:5";

        public const string One1 = "1:1";
    }
}
