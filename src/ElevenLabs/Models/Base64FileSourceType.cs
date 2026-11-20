using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(Base64FileSourceType.Base64FileSourceTypeSerializer))]
[Serializable]
public readonly record struct Base64FileSourceType : IStringEnum
{
    public static readonly Base64FileSourceType Base64 = new(Values.Base64);

    public Base64FileSourceType(string value)
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
    public static Base64FileSourceType FromCustom(string value)
    {
        return new Base64FileSourceType(value);
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

    public static bool operator ==(Base64FileSourceType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(Base64FileSourceType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(Base64FileSourceType value) => value.Value;

    public static explicit operator Base64FileSourceType(string value) => new(value);

    internal class Base64FileSourceTypeSerializer : JsonConverter<Base64FileSourceType>
    {
        public override Base64FileSourceType Read(
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
            return new Base64FileSourceType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            Base64FileSourceType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override Base64FileSourceType ReadAsPropertyName(
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
            return new Base64FileSourceType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            Base64FileSourceType value,
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
        public const string Base64 = "base64";
    }
}
