using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Voice category used for filtering</summary>
[JsonConverter(
    typeof(FindSimilarVoicesVoicesRequestCategory.FindSimilarVoicesVoicesRequestCategorySerializer)
)]
[Serializable]
public readonly record struct FindSimilarVoicesVoicesRequestCategory : IStringEnum
{
    public static readonly FindSimilarVoicesVoicesRequestCategory Professional = new(
        Values.Professional
    );

    public static readonly FindSimilarVoicesVoicesRequestCategory Famous = new(Values.Famous);

    public static readonly FindSimilarVoicesVoicesRequestCategory HighQuality = new(
        Values.HighQuality
    );

    public FindSimilarVoicesVoicesRequestCategory(string value)
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
    public static FindSimilarVoicesVoicesRequestCategory FromCustom(string value)
    {
        return new FindSimilarVoicesVoicesRequestCategory(value);
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

    public static bool operator ==(FindSimilarVoicesVoicesRequestCategory value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FindSimilarVoicesVoicesRequestCategory value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FindSimilarVoicesVoicesRequestCategory value) =>
        value.Value;

    public static explicit operator FindSimilarVoicesVoicesRequestCategory(string value) =>
        new(value);

    internal class FindSimilarVoicesVoicesRequestCategorySerializer
        : JsonConverter<FindSimilarVoicesVoicesRequestCategory>
    {
        public override FindSimilarVoicesVoicesRequestCategory Read(
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
            return new FindSimilarVoicesVoicesRequestCategory(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FindSimilarVoicesVoicesRequestCategory value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FindSimilarVoicesVoicesRequestCategory ReadAsPropertyName(
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
            return new FindSimilarVoicesVoicesRequestCategory(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FindSimilarVoicesVoicesRequestCategory value,
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
        public const string Professional = "professional";

        public const string Famous = "famous";

        public const string HighQuality = "high_quality";
    }
}
