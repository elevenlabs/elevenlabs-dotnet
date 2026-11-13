using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(EvaluationSuccessResult.EvaluationSuccessResultSerializer))]
[Serializable]
public readonly record struct EvaluationSuccessResult : IStringEnum
{
    public static readonly EvaluationSuccessResult Success = new(Values.Success);

    public static readonly EvaluationSuccessResult Failure = new(Values.Failure);

    public static readonly EvaluationSuccessResult Unknown = new(Values.Unknown);

    public EvaluationSuccessResult(string value)
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
    public static EvaluationSuccessResult FromCustom(string value)
    {
        return new EvaluationSuccessResult(value);
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

    public static bool operator ==(EvaluationSuccessResult value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(EvaluationSuccessResult value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(EvaluationSuccessResult value) => value.Value;

    public static explicit operator EvaluationSuccessResult(string value) => new(value);

    internal class EvaluationSuccessResultSerializer : JsonConverter<EvaluationSuccessResult>
    {
        public override EvaluationSuccessResult Read(
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
            return new EvaluationSuccessResult(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EvaluationSuccessResult value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EvaluationSuccessResult ReadAsPropertyName(
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
            return new EvaluationSuccessResult(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EvaluationSuccessResult value,
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
    }
}
