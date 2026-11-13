using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Content type for response filtering. Only 'application/json' responses are filtered.</summary>
[JsonConverter(typeof(ResponseFilterContentType.ResponseFilterContentTypeSerializer))]
[Serializable]
public readonly record struct ResponseFilterContentType : IStringEnum
{
    public static readonly ResponseFilterContentType ApplicationJson = new(Values.ApplicationJson);

    public ResponseFilterContentType(string value)
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
    public static ResponseFilterContentType FromCustom(string value)
    {
        return new ResponseFilterContentType(value);
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

    public static bool operator ==(ResponseFilterContentType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ResponseFilterContentType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ResponseFilterContentType value) => value.Value;

    public static explicit operator ResponseFilterContentType(string value) => new(value);

    internal class ResponseFilterContentTypeSerializer : JsonConverter<ResponseFilterContentType>
    {
        public override ResponseFilterContentType Read(
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
            return new ResponseFilterContentType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ResponseFilterContentType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ResponseFilterContentType ReadAsPropertyName(
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
            return new ResponseFilterContentType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ResponseFilterContentType value,
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
        public const string ApplicationJson = "application/json";
    }
}
