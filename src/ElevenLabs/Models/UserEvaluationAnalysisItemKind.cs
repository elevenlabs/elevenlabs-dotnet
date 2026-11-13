using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(UserEvaluationAnalysisItemKind.UserEvaluationAnalysisItemKindSerializer))]
[Serializable]
public readonly record struct UserEvaluationAnalysisItemKind : IStringEnum
{
    public static readonly UserEvaluationAnalysisItemKind Evaluation = new(Values.Evaluation);

    public UserEvaluationAnalysisItemKind(string value)
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
    public static UserEvaluationAnalysisItemKind FromCustom(string value)
    {
        return new UserEvaluationAnalysisItemKind(value);
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

    public static bool operator ==(UserEvaluationAnalysisItemKind value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UserEvaluationAnalysisItemKind value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UserEvaluationAnalysisItemKind value) => value.Value;

    public static explicit operator UserEvaluationAnalysisItemKind(string value) => new(value);

    internal class UserEvaluationAnalysisItemKindSerializer
        : JsonConverter<UserEvaluationAnalysisItemKind>
    {
        public override UserEvaluationAnalysisItemKind Read(
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
            return new UserEvaluationAnalysisItemKind(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UserEvaluationAnalysisItemKind value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UserEvaluationAnalysisItemKind ReadAsPropertyName(
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
            return new UserEvaluationAnalysisItemKind(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UserEvaluationAnalysisItemKind value,
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
    }
}
