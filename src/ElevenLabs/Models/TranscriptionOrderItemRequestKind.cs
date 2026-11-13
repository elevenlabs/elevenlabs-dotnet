using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The type of order item.</summary>
[JsonConverter(
    typeof(TranscriptionOrderItemRequestKind.TranscriptionOrderItemRequestKindSerializer)
)]
[Serializable]
public readonly record struct TranscriptionOrderItemRequestKind : IStringEnum
{
    public static readonly TranscriptionOrderItemRequestKind Transcription = new(
        Values.Transcription
    );

    public TranscriptionOrderItemRequestKind(string value)
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
    public static TranscriptionOrderItemRequestKind FromCustom(string value)
    {
        return new TranscriptionOrderItemRequestKind(value);
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

    public static bool operator ==(TranscriptionOrderItemRequestKind value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TranscriptionOrderItemRequestKind value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TranscriptionOrderItemRequestKind value) => value.Value;

    public static explicit operator TranscriptionOrderItemRequestKind(string value) => new(value);

    internal class TranscriptionOrderItemRequestKindSerializer
        : JsonConverter<TranscriptionOrderItemRequestKind>
    {
        public override TranscriptionOrderItemRequestKind Read(
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
            return new TranscriptionOrderItemRequestKind(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TranscriptionOrderItemRequestKind value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TranscriptionOrderItemRequestKind ReadAsPropertyName(
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
            return new TranscriptionOrderItemRequestKind(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TranscriptionOrderItemRequestKind value,
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
        public const string Transcription = "transcription";
    }
}
