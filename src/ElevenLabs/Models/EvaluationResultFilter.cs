using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(EvaluationResultFilter.EvaluationResultFilterSerializer))]
[Serializable]
public readonly record struct EvaluationResultFilter : IStringEnum
{
    public static readonly EvaluationResultFilter Success = new(Values.Success);

    public static readonly EvaluationResultFilter Failure = new(Values.Failure);

    public static readonly EvaluationResultFilter Unknown = new(Values.Unknown);

    public static readonly EvaluationResultFilter Error = new(Values.Error);

    public EvaluationResultFilter(string value)
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
    public static EvaluationResultFilter FromCustom(string value)
    {
        return new EvaluationResultFilter(value);
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

    public static bool operator ==(EvaluationResultFilter value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(EvaluationResultFilter value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(EvaluationResultFilter value) => value.Value;

    public static explicit operator EvaluationResultFilter(string value) => new(value);

    internal class EvaluationResultFilterSerializer : JsonConverter<EvaluationResultFilter>
    {
        public override EvaluationResultFilter Read(
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
            return new EvaluationResultFilter(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EvaluationResultFilter value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EvaluationResultFilter ReadAsPropertyName(
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
            return new EvaluationResultFilter(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EvaluationResultFilter value,
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

        public const string Failure = "failure";

        public const string Unknown = "unknown";

        public const string Error = "error";
    }
}
