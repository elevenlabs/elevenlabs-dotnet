using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ListPronunciationDictionariesRequestSort.ListPronunciationDictionariesRequestSortSerializer)
)]
[Serializable]
public readonly record struct ListPronunciationDictionariesRequestSort : IStringEnum
{
    public static readonly ListPronunciationDictionariesRequestSort CreationTimeUnix = new(
        Values.CreationTimeUnix
    );

    public static readonly ListPronunciationDictionariesRequestSort Name = new(Values.Name);

    public ListPronunciationDictionariesRequestSort(string value)
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
    public static ListPronunciationDictionariesRequestSort FromCustom(string value)
    {
        return new ListPronunciationDictionariesRequestSort(value);
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

    public static bool operator ==(
        ListPronunciationDictionariesRequestSort value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListPronunciationDictionariesRequestSort value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ListPronunciationDictionariesRequestSort value) =>
        value.Value;

    public static explicit operator ListPronunciationDictionariesRequestSort(string value) =>
        new(value);

    internal class ListPronunciationDictionariesRequestSortSerializer
        : JsonConverter<ListPronunciationDictionariesRequestSort>
    {
        public override ListPronunciationDictionariesRequestSort Read(
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
            return new ListPronunciationDictionariesRequestSort(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListPronunciationDictionariesRequestSort value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListPronunciationDictionariesRequestSort ReadAsPropertyName(
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
            return new ListPronunciationDictionariesRequestSort(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListPronunciationDictionariesRequestSort value,
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
        public const string CreationTimeUnix = "creation_time_unix";

        public const string Name = "name";
    }
}
