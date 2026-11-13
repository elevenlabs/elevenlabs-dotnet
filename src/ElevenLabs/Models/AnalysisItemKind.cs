using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Agents;

[JsonConverter(typeof(AnalysisItemKind.AnalysisItemKindSerializer))]
[Serializable]
public readonly record struct AnalysisItemKind : IStringEnum
{
    public static readonly AnalysisItemKind Evaluation = new(Values.Evaluation);

    public static readonly AnalysisItemKind DataCollection = new(Values.DataCollection);

    public AnalysisItemKind(string value)
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
    public static AnalysisItemKind FromCustom(string value)
    {
        return new AnalysisItemKind(value);
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

    public static bool operator ==(AnalysisItemKind value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AnalysisItemKind value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AnalysisItemKind value) => value.Value;

    public static explicit operator AnalysisItemKind(string value) => new(value);

    internal class AnalysisItemKindSerializer : JsonConverter<AnalysisItemKind>
    {
        public override AnalysisItemKind Read(
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
            return new AnalysisItemKind(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AnalysisItemKind value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AnalysisItemKind ReadAsPropertyName(
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
            return new AnalysisItemKind(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AnalysisItemKind value,
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
        public const string Evaluation = "evaluation";

        public const string DataCollection = "data_collection";
    }
}
