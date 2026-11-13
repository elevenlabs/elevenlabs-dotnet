using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Dubbing;

/// <summary>Sort by creation time; newest first by default.</summary>
[JsonConverter(typeof(ListProjectRequestSortDirection.ListProjectRequestSortDirectionSerializer))]
[Serializable]
public readonly record struct ListProjectRequestSortDirection : IStringEnum
{
    public static readonly ListProjectRequestSortDirection Ascending = new(Values.Ascending);

    public static readonly ListProjectRequestSortDirection Descending = new(Values.Descending);

    public ListProjectRequestSortDirection(string value)
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
    public static ListProjectRequestSortDirection FromCustom(string value)
    {
        return new ListProjectRequestSortDirection(value);
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

    public static bool operator ==(ListProjectRequestSortDirection value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListProjectRequestSortDirection value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListProjectRequestSortDirection value) => value.Value;

    public static explicit operator ListProjectRequestSortDirection(string value) => new(value);

    internal class ListProjectRequestSortDirectionSerializer
        : JsonConverter<ListProjectRequestSortDirection>
    {
        public override ListProjectRequestSortDirection Read(
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
            return new ListProjectRequestSortDirection(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListProjectRequestSortDirection value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListProjectRequestSortDirection ReadAsPropertyName(
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
            return new ListProjectRequestSortDirection(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListProjectRequestSortDirection value,
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
        public const string Ascending = "ASCENDING";

        public const string Descending = "DESCENDING";
    }
}
