using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(InlineAudioReferenceType.InlineAudioReferenceTypeSerializer))]
[Serializable]
public readonly record struct InlineAudioReferenceType : IStringEnum
{
    public static readonly InlineAudioReferenceType InlineBase64 = new(Values.InlineBase64);

    public InlineAudioReferenceType(string value)
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
    public static InlineAudioReferenceType FromCustom(string value)
    {
        return new InlineAudioReferenceType(value);
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

    public static bool operator ==(InlineAudioReferenceType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(InlineAudioReferenceType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(InlineAudioReferenceType value) => value.Value;

    public static explicit operator InlineAudioReferenceType(string value) => new(value);

    internal class InlineAudioReferenceTypeSerializer : JsonConverter<InlineAudioReferenceType>
    {
        public override InlineAudioReferenceType Read(
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
            return new InlineAudioReferenceType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            InlineAudioReferenceType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override InlineAudioReferenceType ReadAsPropertyName(
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
            return new InlineAudioReferenceType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            InlineAudioReferenceType value,
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
        public const string InlineBase64 = "inline_base64";
    }
}
