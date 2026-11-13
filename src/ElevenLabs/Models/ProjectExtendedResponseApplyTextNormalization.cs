using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Whether text normalization is applied to the project.</summary>
[JsonConverter(
    typeof(ProjectExtendedResponseApplyTextNormalization.ProjectExtendedResponseApplyTextNormalizationSerializer)
)]
[Serializable]
public readonly record struct ProjectExtendedResponseApplyTextNormalization : IStringEnum
{
    public static readonly ProjectExtendedResponseApplyTextNormalization Auto = new(Values.Auto);

    public static readonly ProjectExtendedResponseApplyTextNormalization On = new(Values.On);

    public static readonly ProjectExtendedResponseApplyTextNormalization Off = new(Values.Off);

    public static readonly ProjectExtendedResponseApplyTextNormalization ApplyEnglish = new(
        Values.ApplyEnglish
    );

    public ProjectExtendedResponseApplyTextNormalization(string value)
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
    public static ProjectExtendedResponseApplyTextNormalization FromCustom(string value)
    {
        return new ProjectExtendedResponseApplyTextNormalization(value);
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

    public static bool operator ==(
        ProjectExtendedResponseApplyTextNormalization value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ProjectExtendedResponseApplyTextNormalization value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ProjectExtendedResponseApplyTextNormalization value) =>
        value.Value;

    public static explicit operator ProjectExtendedResponseApplyTextNormalization(string value) =>
        new(value);

    internal class ProjectExtendedResponseApplyTextNormalizationSerializer
        : JsonConverter<ProjectExtendedResponseApplyTextNormalization>
    {
        public override ProjectExtendedResponseApplyTextNormalization Read(
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
            return new ProjectExtendedResponseApplyTextNormalization(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ProjectExtendedResponseApplyTextNormalization value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ProjectExtendedResponseApplyTextNormalization ReadAsPropertyName(
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
            return new ProjectExtendedResponseApplyTextNormalization(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ProjectExtendedResponseApplyTextNormalization value,
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
        public const string Auto = "auto";

        public const string On = "on";

        public const string Off = "off";

        public const string ApplyEnglish = "apply_english";
    }
}
