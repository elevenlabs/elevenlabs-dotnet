using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The order direction to use for results from this query.</summary>
[JsonConverter(typeof(ListDubbingRequestOrderDirection.ListDubbingRequestOrderDirectionSerializer))]
[Serializable]
public readonly record struct ListDubbingRequestOrderDirection : IStringEnum
{
    public static readonly ListDubbingRequestOrderDirection Descending = new(Values.Descending);

    public static readonly ListDubbingRequestOrderDirection Ascending = new(Values.Ascending);

    public ListDubbingRequestOrderDirection(string value)
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
    public static ListDubbingRequestOrderDirection FromCustom(string value)
    {
        return new ListDubbingRequestOrderDirection(value);
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

    public static bool operator ==(ListDubbingRequestOrderDirection value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListDubbingRequestOrderDirection value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListDubbingRequestOrderDirection value) => value.Value;

    public static explicit operator ListDubbingRequestOrderDirection(string value) => new(value);

    internal class ListDubbingRequestOrderDirectionSerializer
        : JsonConverter<ListDubbingRequestOrderDirection>
    {
        public override ListDubbingRequestOrderDirection Read(
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
            return new ListDubbingRequestOrderDirection(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListDubbingRequestOrderDirection value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListDubbingRequestOrderDirection ReadAsPropertyName(
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
            return new ListDubbingRequestOrderDirection(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListDubbingRequestOrderDirection value,
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
        public const string Descending = "DESCENDING";

        public const string Ascending = "ASCENDING";
    }
}
