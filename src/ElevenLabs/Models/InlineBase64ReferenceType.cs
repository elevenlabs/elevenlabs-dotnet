using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(InlineBase64ReferenceType.InlineBase64ReferenceTypeSerializer))]
[Serializable]
public readonly record struct InlineBase64ReferenceType : IStringEnum
{
    public static readonly InlineBase64ReferenceType InlineBase64 = new(Values.InlineBase64);

    public InlineBase64ReferenceType(string value)
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
    public static InlineBase64ReferenceType FromCustom(string value)
    {
        return new InlineBase64ReferenceType(value);
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

    public static bool operator ==(InlineBase64ReferenceType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(InlineBase64ReferenceType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(InlineBase64ReferenceType value) => value.Value;

    public static explicit operator InlineBase64ReferenceType(string value) => new(value);

    internal class InlineBase64ReferenceTypeSerializer : JsonConverter<InlineBase64ReferenceType>
    {
        public override InlineBase64ReferenceType Read(
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
            return new InlineBase64ReferenceType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            InlineBase64ReferenceType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override InlineBase64ReferenceType ReadAsPropertyName(
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
            return new InlineBase64ReferenceType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            InlineBase64ReferenceType value,
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
