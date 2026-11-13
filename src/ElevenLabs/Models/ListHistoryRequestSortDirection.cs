using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ListHistoryRequestSortDirection.ListHistoryRequestSortDirectionSerializer))]
[Serializable]
public readonly record struct ListHistoryRequestSortDirection : IStringEnum
{
    public static readonly ListHistoryRequestSortDirection Asc = new(Values.Asc);

    public static readonly ListHistoryRequestSortDirection Desc = new(Values.Desc);

    public ListHistoryRequestSortDirection(string value)
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
    public static ListHistoryRequestSortDirection FromCustom(string value)
    {
        return new ListHistoryRequestSortDirection(value);
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

    public static bool operator ==(ListHistoryRequestSortDirection value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListHistoryRequestSortDirection value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListHistoryRequestSortDirection value) => value.Value;

    public static explicit operator ListHistoryRequestSortDirection(string value) => new(value);

    internal class ListHistoryRequestSortDirectionSerializer
        : JsonConverter<ListHistoryRequestSortDirection>
    {
        public override ListHistoryRequestSortDirection Read(
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
            return new ListHistoryRequestSortDirection(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListHistoryRequestSortDirection value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListHistoryRequestSortDirection ReadAsPropertyName(
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
            return new ListHistoryRequestSortDirection(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListHistoryRequestSortDirection value,
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
        public const string Asc = "asc";

        public const string Desc = "desc";
    }
}
