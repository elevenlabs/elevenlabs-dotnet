using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(QueryArrayJsonSchemaPropertyInputType.QueryArrayJsonSchemaPropertyInputTypeSerializer)
)]
[Serializable]
public readonly record struct QueryArrayJsonSchemaPropertyInputType : IStringEnum
{
    public static readonly QueryArrayJsonSchemaPropertyInputType Array = new(Values.Array);

    public QueryArrayJsonSchemaPropertyInputType(string value)
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
    public static QueryArrayJsonSchemaPropertyInputType FromCustom(string value)
    {
        return new QueryArrayJsonSchemaPropertyInputType(value);
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

    public static bool operator ==(QueryArrayJsonSchemaPropertyInputType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(QueryArrayJsonSchemaPropertyInputType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(QueryArrayJsonSchemaPropertyInputType value) =>
        value.Value;

    public static explicit operator QueryArrayJsonSchemaPropertyInputType(string value) =>
        new(value);

    internal class QueryArrayJsonSchemaPropertyInputTypeSerializer
        : JsonConverter<QueryArrayJsonSchemaPropertyInputType>
    {
        public override QueryArrayJsonSchemaPropertyInputType Read(
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
            return new QueryArrayJsonSchemaPropertyInputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            QueryArrayJsonSchemaPropertyInputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override QueryArrayJsonSchemaPropertyInputType ReadAsPropertyName(
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
            return new QueryArrayJsonSchemaPropertyInputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            QueryArrayJsonSchemaPropertyInputType value,
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
        public const string Array = "array";
    }
}
