using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>edit_failed: the edit could not be produced.</summary>
[JsonConverter(typeof(TranscriptEditErrorErrorType.TranscriptEditErrorErrorTypeSerializer))]
[Serializable]
public readonly record struct TranscriptEditErrorErrorType : IStringEnum
{
    public static readonly TranscriptEditErrorErrorType EditFailed = new(Values.EditFailed);

    public TranscriptEditErrorErrorType(string value)
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
    public static TranscriptEditErrorErrorType FromCustom(string value)
    {
        return new TranscriptEditErrorErrorType(value);
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

    public static bool operator ==(TranscriptEditErrorErrorType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TranscriptEditErrorErrorType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TranscriptEditErrorErrorType value) => value.Value;

    public static explicit operator TranscriptEditErrorErrorType(string value) => new(value);

    internal class TranscriptEditErrorErrorTypeSerializer
        : JsonConverter<TranscriptEditErrorErrorType>
    {
        public override TranscriptEditErrorErrorType Read(
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
            return new TranscriptEditErrorErrorType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TranscriptEditErrorErrorType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TranscriptEditErrorErrorType ReadAsPropertyName(
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
            return new TranscriptEditErrorErrorType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TranscriptEditErrorErrorType value,
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
        public const string EditFailed = "edit_failed";
    }
}
