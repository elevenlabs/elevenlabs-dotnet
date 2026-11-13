using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(InlineImageReferenceType.InlineImageReferenceTypeSerializer))]
[Serializable]
public readonly record struct InlineImageReferenceType : IStringEnum
{
    public static readonly InlineImageReferenceType InlineBase64 = new(Values.InlineBase64);

    public InlineImageReferenceType(string value)
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
    public static InlineImageReferenceType FromCustom(string value)
    {
        return new InlineImageReferenceType(value);
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

    public static bool operator ==(InlineImageReferenceType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(InlineImageReferenceType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(InlineImageReferenceType value) => value.Value;

    public static explicit operator InlineImageReferenceType(string value) => new(value);

    internal class InlineImageReferenceTypeSerializer : JsonConverter<InlineImageReferenceType>
    {
        public override InlineImageReferenceType Read(
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
            return new InlineImageReferenceType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            InlineImageReferenceType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override InlineImageReferenceType ReadAsPropertyName(
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
            return new InlineImageReferenceType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            InlineImageReferenceType value,
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
