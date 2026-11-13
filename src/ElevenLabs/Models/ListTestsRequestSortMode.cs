using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Agents;

/// <summary>Sort mode for listing tests. Use 'folders_first' to place folders before tests.</summary>
[JsonConverter(typeof(ListTestsRequestSortMode.ListTestsRequestSortModeSerializer))]
[Serializable]
public readonly record struct ListTestsRequestSortMode : IStringEnum
{
    public static readonly ListTestsRequestSortMode Default = new(Values.Default);

    public static readonly ListTestsRequestSortMode FoldersFirst = new(Values.FoldersFirst);

    public ListTestsRequestSortMode(string value)
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
    public static ListTestsRequestSortMode FromCustom(string value)
    {
        return new ListTestsRequestSortMode(value);
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

    public static bool operator ==(ListTestsRequestSortMode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListTestsRequestSortMode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListTestsRequestSortMode value) => value.Value;

    public static explicit operator ListTestsRequestSortMode(string value) => new(value);

    internal class ListTestsRequestSortModeSerializer : JsonConverter<ListTestsRequestSortMode>
    {
        public override ListTestsRequestSortMode Read(
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
            return new ListTestsRequestSortMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListTestsRequestSortMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListTestsRequestSortMode ReadAsPropertyName(
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
            return new ListTestsRequestSortMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListTestsRequestSortMode value,
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
        public const string Default = "default";

        public const string FoldersFirst = "folders_first";
    }
}
