using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Music;

/// <summary>Sort by field (created_at or name)</summary>
[JsonConverter(typeof(ListFinetunesRequestSort.ListFinetunesRequestSortSerializer))]
[Serializable]
public readonly record struct ListFinetunesRequestSort : IStringEnum
{
    public static readonly ListFinetunesRequestSort CreatedAt = new(Values.CreatedAt);

    public static readonly ListFinetunesRequestSort Name = new(Values.Name);

    public ListFinetunesRequestSort(string value)
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
    public static ListFinetunesRequestSort FromCustom(string value)
    {
        return new ListFinetunesRequestSort(value);
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

    public static bool operator ==(ListFinetunesRequestSort value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListFinetunesRequestSort value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListFinetunesRequestSort value) => value.Value;

    public static explicit operator ListFinetunesRequestSort(string value) => new(value);

    internal class ListFinetunesRequestSortSerializer : JsonConverter<ListFinetunesRequestSort>
    {
        public override ListFinetunesRequestSort Read(
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
            return new ListFinetunesRequestSort(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListFinetunesRequestSort value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListFinetunesRequestSort ReadAsPropertyName(
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
            return new ListFinetunesRequestSort(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListFinetunesRequestSort value,
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
