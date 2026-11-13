using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Music;

/// <summary>Sort direction (asc or desc)</summary>
[JsonConverter(
    typeof(ListFinetunesRequestSortDirection.ListFinetunesRequestSortDirectionSerializer)
)]
[Serializable]
public readonly record struct ListFinetunesRequestSortDirection : IStringEnum
{
    public static readonly ListFinetunesRequestSortDirection Asc = new(Values.Asc);

    public static readonly ListFinetunesRequestSortDirection Desc = new(Values.Desc);

    public ListFinetunesRequestSortDirection(string value)
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
    public static ListFinetunesRequestSortDirection FromCustom(string value)
    {
        return new ListFinetunesRequestSortDirection(value);
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

    public static bool operator ==(ListFinetunesRequestSortDirection value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListFinetunesRequestSortDirection value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListFinetunesRequestSortDirection value) => value.Value;

    public static explicit operator ListFinetunesRequestSortDirection(string value) => new(value);

    internal class ListFinetunesRequestSortDirectionSerializer
        : JsonConverter<ListFinetunesRequestSortDirection>
    {
        public override ListFinetunesRequestSortDirection Read(
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
            return new ListFinetunesRequestSortDirection(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListFinetunesRequestSortDirection value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListFinetunesRequestSortDirection ReadAsPropertyName(
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
            return new ListFinetunesRequestSortDirection(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListFinetunesRequestSortDirection value,
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
