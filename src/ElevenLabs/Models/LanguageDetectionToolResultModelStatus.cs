using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(LanguageDetectionToolResultModelStatus.LanguageDetectionToolResultModelStatusSerializer)
)]
[Serializable]
public readonly record struct LanguageDetectionToolResultModelStatus : IStringEnum
{
    public static readonly LanguageDetectionToolResultModelStatus Success = new(Values.Success);

    public LanguageDetectionToolResultModelStatus(string value)
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
    public static LanguageDetectionToolResultModelStatus FromCustom(string value)
    {
        return new LanguageDetectionToolResultModelStatus(value);
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

    public static bool operator ==(LanguageDetectionToolResultModelStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(LanguageDetectionToolResultModelStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(LanguageDetectionToolResultModelStatus value) =>
        value.Value;

    public static explicit operator LanguageDetectionToolResultModelStatus(string value) =>
        new(value);

    internal class LanguageDetectionToolResultModelStatusSerializer
        : JsonConverter<LanguageDetectionToolResultModelStatus>
    {
        public override LanguageDetectionToolResultModelStatus Read(
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
            return new LanguageDetectionToolResultModelStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            LanguageDetectionToolResultModelStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override LanguageDetectionToolResultModelStatus ReadAsPropertyName(
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
            return new LanguageDetectionToolResultModelStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            LanguageDetectionToolResultModelStatus value,
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
        public const string Success = "success";
    }
}
