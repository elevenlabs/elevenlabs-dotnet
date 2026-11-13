using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ConversationFeedbackType.ConversationFeedbackTypeSerializer))]
[Serializable]
public readonly record struct ConversationFeedbackType : IStringEnum
{
    public static readonly ConversationFeedbackType Thumbs = new(Values.Thumbs);

    public static readonly ConversationFeedbackType Rating = new(Values.Rating);

    public ConversationFeedbackType(string value)
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
    public static ConversationFeedbackType FromCustom(string value)
    {
        return new ConversationFeedbackType(value);
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

    public static bool operator ==(ConversationFeedbackType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConversationFeedbackType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConversationFeedbackType value) => value.Value;

    public static explicit operator ConversationFeedbackType(string value) => new(value);

    internal class ConversationFeedbackTypeSerializer : JsonConverter<ConversationFeedbackType>
    {
        public override ConversationFeedbackType Read(
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
            return new ConversationFeedbackType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConversationFeedbackType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConversationFeedbackType ReadAsPropertyName(
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
            return new ConversationFeedbackType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConversationFeedbackType value,
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
        public const string Thumbs = "thumbs";

        public const string Rating = "rating";
    }
}
