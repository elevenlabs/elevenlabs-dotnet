using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(LanguageDetectionToolConfigSystemToolType.LanguageDetectionToolConfigSystemToolTypeSerializer)
)]
[Serializable]
public readonly record struct LanguageDetectionToolConfigSystemToolType : IStringEnum
{
    public static readonly LanguageDetectionToolConfigSystemToolType LanguageDetection = new(
        Values.LanguageDetection
    );

    public LanguageDetectionToolConfigSystemToolType(string value)
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
    public static LanguageDetectionToolConfigSystemToolType FromCustom(string value)
    {
        return new LanguageDetectionToolConfigSystemToolType(value);
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
        LanguageDetectionToolConfigSystemToolType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        LanguageDetectionToolConfigSystemToolType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(LanguageDetectionToolConfigSystemToolType value) =>
        value.Value;

    public static explicit operator LanguageDetectionToolConfigSystemToolType(string value) =>
        new(value);

    internal class LanguageDetectionToolConfigSystemToolTypeSerializer
        : JsonConverter<LanguageDetectionToolConfigSystemToolType>
    {
        public override LanguageDetectionToolConfigSystemToolType Read(
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
            return new LanguageDetectionToolConfigSystemToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            LanguageDetectionToolConfigSystemToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override LanguageDetectionToolConfigSystemToolType ReadAsPropertyName(
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
            return new LanguageDetectionToolConfigSystemToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            LanguageDetectionToolConfigSystemToolType value,
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
        public const string LanguageDetection = "language_detection";
    }
}
