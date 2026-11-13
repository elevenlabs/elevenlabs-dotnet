using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The type of podcast to create.</summary>
[JsonConverter(typeof(PodcastConversationModeType.PodcastConversationModeTypeSerializer))]
[Serializable]
public readonly record struct PodcastConversationModeType : IStringEnum
{
    public static readonly PodcastConversationModeType Conversation = new(Values.Conversation);

    public PodcastConversationModeType(string value)
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
    public static PodcastConversationModeType FromCustom(string value)
    {
        return new PodcastConversationModeType(value);
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

    public static bool operator ==(PodcastConversationModeType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PodcastConversationModeType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PodcastConversationModeType value) => value.Value;

    public static explicit operator PodcastConversationModeType(string value) => new(value);

    internal class PodcastConversationModeTypeSerializer
        : JsonConverter<PodcastConversationModeType>
    {
        public override PodcastConversationModeType Read(
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
            return new PodcastConversationModeType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PodcastConversationModeType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PodcastConversationModeType ReadAsPropertyName(
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
            return new PodcastConversationModeType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PodcastConversationModeType value,
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
        public const string Conversation = "conversation";
    }
}
