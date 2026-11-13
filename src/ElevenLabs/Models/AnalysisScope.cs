using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AnalysisScope.AnalysisScopeSerializer))]
[Serializable]
public readonly record struct AnalysisScope : IStringEnum
{
    public static readonly AnalysisScope Conversation = new(Values.Conversation);

    public static readonly AnalysisScope Agent = new(Values.Agent);

    public AnalysisScope(string value)
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
    public static AnalysisScope FromCustom(string value)
    {
        return new AnalysisScope(value);
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

    public static bool operator ==(AnalysisScope value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AnalysisScope value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AnalysisScope value) => value.Value;

    public static explicit operator AnalysisScope(string value) => new(value);

    internal class AnalysisScopeSerializer : JsonConverter<AnalysisScope>
    {
        public override AnalysisScope Read(
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
            return new AnalysisScope(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AnalysisScope value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AnalysisScope ReadAsPropertyName(
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
            return new AnalysisScope(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AnalysisScope value,
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
        public const string Conversation = "conversation";

        public const string Agent = "agent";
    }
}
