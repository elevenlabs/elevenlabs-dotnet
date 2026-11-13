using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AnalysisType.AnalysisTypeSerializer))]
[Serializable]
public readonly record struct AnalysisType : IStringEnum
{
    public static readonly AnalysisType EvaluationCriteria = new(Values.EvaluationCriteria);

    public static readonly AnalysisType DataCollection = new(Values.DataCollection);

    public AnalysisType(string value)
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
    public static AnalysisType FromCustom(string value)
    {
        return new AnalysisType(value);
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

    public static bool operator ==(AnalysisType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AnalysisType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AnalysisType value) => value.Value;

    public static explicit operator AnalysisType(string value) => new(value);

    internal class AnalysisTypeSerializer : JsonConverter<AnalysisType>
    {
        public override AnalysisType Read(
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
            return new AnalysisType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AnalysisType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AnalysisType ReadAsPropertyName(
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
            return new AnalysisType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AnalysisType value,
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
        public const string EvaluationCriteria = "evaluation_criteria";

        public const string DataCollection = "data_collection";
    }
}
