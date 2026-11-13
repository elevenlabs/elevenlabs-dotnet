using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AnalysisItemSource.AnalysisItemSourceSerializer))]
[Serializable]
public readonly record struct AnalysisItemSource : IStringEnum
{
    public static readonly AnalysisItemSource User = new(Values.User);

    public static readonly AnalysisItemSource System = new(Values.System);

    public AnalysisItemSource(string value)
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
    public static AnalysisItemSource FromCustom(string value)
    {
        return new AnalysisItemSource(value);
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

    public static bool operator ==(AnalysisItemSource value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AnalysisItemSource value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AnalysisItemSource value) => value.Value;

    public static explicit operator AnalysisItemSource(string value) => new(value);

    internal class AnalysisItemSourceSerializer : JsonConverter<AnalysisItemSource>
    {
        public override AnalysisItemSource Read(
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
            return new AnalysisItemSource(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AnalysisItemSource value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AnalysisItemSource ReadAsPropertyName(
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
            return new AnalysisItemSource(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AnalysisItemSource value,
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
        public const string User = "user";

        public const string System = "system";
    }
}
