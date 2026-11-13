using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The field to use for ordering results from this query.</summary>
[JsonConverter(typeof(ListDubbingRequestOrderBy.ListDubbingRequestOrderBySerializer))]
[Serializable]
public readonly record struct ListDubbingRequestOrderBy : IStringEnum
{
    public static readonly ListDubbingRequestOrderBy CreatedAt = new(Values.CreatedAt);

    public static readonly ListDubbingRequestOrderBy Name = new(Values.Name);

    public ListDubbingRequestOrderBy(string value)
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
    public static ListDubbingRequestOrderBy FromCustom(string value)
    {
        return new ListDubbingRequestOrderBy(value);
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

    public static bool operator ==(ListDubbingRequestOrderBy value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListDubbingRequestOrderBy value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListDubbingRequestOrderBy value) => value.Value;

    public static explicit operator ListDubbingRequestOrderBy(string value) => new(value);

    internal class ListDubbingRequestOrderBySerializer : JsonConverter<ListDubbingRequestOrderBy>
    {
        public override ListDubbingRequestOrderBy Read(
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
            return new ListDubbingRequestOrderBy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListDubbingRequestOrderBy value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListDubbingRequestOrderBy ReadAsPropertyName(
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
            return new ListDubbingRequestOrderBy(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListDubbingRequestOrderBy value,
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
        public const string CreatedAt = "created_at";

        public const string Name = "name";
    }
}
