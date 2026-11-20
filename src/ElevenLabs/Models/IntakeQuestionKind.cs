using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Answer shape for a per-item intake question.</summary>
[JsonConverter(typeof(IntakeQuestionKind.IntakeQuestionKindSerializer))]
[Serializable]
public readonly record struct IntakeQuestionKind : IStringEnum
{
    public static readonly IntakeQuestionKind Text = new(Values.Text);

    public static readonly IntakeQuestionKind Number = new(Values.Number);

    public static readonly IntakeQuestionKind Choice = new(Values.Choice);

    public IntakeQuestionKind(string value)
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
    public static IntakeQuestionKind FromCustom(string value)
    {
        return new IntakeQuestionKind(value);
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

    public static bool operator ==(IntakeQuestionKind value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(IntakeQuestionKind value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(IntakeQuestionKind value) => value.Value;

    public static explicit operator IntakeQuestionKind(string value) => new(value);

    internal class IntakeQuestionKindSerializer : JsonConverter<IntakeQuestionKind>
    {
        public override IntakeQuestionKind Read(
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
            return new IntakeQuestionKind(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            IntakeQuestionKind value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override IntakeQuestionKind ReadAsPropertyName(
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
            return new IntakeQuestionKind(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            IntakeQuestionKind value,
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
        public const string Text = "text";

        public const string Number = "number";

        public const string Choice = "choice";
    }
}
