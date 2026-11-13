using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Sort criteria. Must be one of: created_date, usage_character_count_1y, trending, cloned_by_count.</summary>
[JsonConverter(typeof(GetSharedVoicesRequestSort.GetSharedVoicesRequestSortSerializer))]
[Serializable]
public readonly record struct GetSharedVoicesRequestSort : IStringEnum
{
    public static readonly GetSharedVoicesRequestSort CreatedDate = new(Values.CreatedDate);

    public static readonly GetSharedVoicesRequestSort UsageCharacterCount1Y = new(
        Values.UsageCharacterCount1Y
    );

    public static readonly GetSharedVoicesRequestSort Trending = new(Values.Trending);

    public static readonly GetSharedVoicesRequestSort ClonedByCount = new(Values.ClonedByCount);

    public GetSharedVoicesRequestSort(string value)
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
    public static GetSharedVoicesRequestSort FromCustom(string value)
    {
        return new GetSharedVoicesRequestSort(value);
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

    public static bool operator ==(GetSharedVoicesRequestSort value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetSharedVoicesRequestSort value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetSharedVoicesRequestSort value) => value.Value;

    public static explicit operator GetSharedVoicesRequestSort(string value) => new(value);

    internal class GetSharedVoicesRequestSortSerializer : JsonConverter<GetSharedVoicesRequestSort>
    {
        public override GetSharedVoicesRequestSort Read(
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
            return new GetSharedVoicesRequestSort(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetSharedVoicesRequestSort value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetSharedVoicesRequestSort ReadAsPropertyName(
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
            return new GetSharedVoicesRequestSort(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetSharedVoicesRequestSort value,
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
        public const string CreatedDate = "created_date";

        public const string UsageCharacterCount1Y = "usage_character_count_1y";

        public const string Trending = "trending";

        public const string ClonedByCount = "cloned_by_count";
    }
}
