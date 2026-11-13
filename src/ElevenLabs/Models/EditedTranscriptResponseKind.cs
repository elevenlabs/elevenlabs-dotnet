using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(EditedTranscriptResponseKind.EditedTranscriptResponseKindSerializer))]
[Serializable]
public readonly record struct EditedTranscriptResponseKind : IStringEnum
{
    public static readonly EditedTranscriptResponseKind Transcript = new(Values.Transcript);

    public EditedTranscriptResponseKind(string value)
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
    public static EditedTranscriptResponseKind FromCustom(string value)
    {
        return new EditedTranscriptResponseKind(value);
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

    public static bool operator ==(EditedTranscriptResponseKind value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(EditedTranscriptResponseKind value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(EditedTranscriptResponseKind value) => value.Value;

    public static explicit operator EditedTranscriptResponseKind(string value) => new(value);

    internal class EditedTranscriptResponseKindSerializer
        : JsonConverter<EditedTranscriptResponseKind>
    {
        public override EditedTranscriptResponseKind Read(
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
            return new EditedTranscriptResponseKind(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EditedTranscriptResponseKind value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EditedTranscriptResponseKind ReadAsPropertyName(
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
            return new EditedTranscriptResponseKind(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EditedTranscriptResponseKind value,
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
        public const string Transcript = "transcript";
    }
}
