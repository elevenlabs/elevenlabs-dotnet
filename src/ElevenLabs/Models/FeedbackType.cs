using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(FeedbackType.FeedbackTypeSerializer))]
[Serializable]
public readonly record struct FeedbackType : IStringEnum
{
    public static readonly FeedbackType Feedback = new(Values.Feedback);

    public FeedbackType(string value)
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
    public static FeedbackType FromCustom(string value)
    {
        return new FeedbackType(value);
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

    public static bool operator ==(FeedbackType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FeedbackType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FeedbackType value) => value.Value;

    public static explicit operator FeedbackType(string value) => new(value);

    internal class FeedbackTypeSerializer : JsonConverter<FeedbackType>
    {
        public override FeedbackType Read(
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
            return new FeedbackType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FeedbackType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FeedbackType ReadAsPropertyName(
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
            return new FeedbackType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FeedbackType value,
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
        public const string Feedback = "feedback";
    }
}
