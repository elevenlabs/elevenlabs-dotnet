using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Which product surface owns this agent document.</summary>
[JsonConverter(typeof(ConversationProduct.ConversationProductSerializer))]
[Serializable]
public readonly record struct ConversationProduct : IStringEnum
{
    public static readonly ConversationProduct Agents = new(Values.Agents);

    public static readonly ConversationProduct SpeechEngine = new(Values.SpeechEngine);

    public ConversationProduct(string value)
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
    public static ConversationProduct FromCustom(string value)
    {
        return new ConversationProduct(value);
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

    public static bool operator ==(ConversationProduct value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConversationProduct value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConversationProduct value) => value.Value;

    public static explicit operator ConversationProduct(string value) => new(value);

    internal class ConversationProductSerializer : JsonConverter<ConversationProduct>
    {
        public override ConversationProduct Read(
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
            return new ConversationProduct(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConversationProduct value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConversationProduct ReadAsPropertyName(
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
            return new ConversationProduct(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConversationProduct value,
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
        public const string Agents = "agents";

        public const string SpeechEngine = "speech_engine";
    }
}
