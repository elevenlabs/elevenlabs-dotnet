using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(Type4.Type4Serializer))]
[Serializable]
public readonly record struct Type4 : IStringEnum
{
    public static readonly Type4 AgentChatResponsePart = new(Values.AgentChatResponsePart);

    public Type4(string value)
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
    public static Type4 FromCustom(string value)
    {
        return new Type4(value);
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

    public static bool operator ==(Type4 value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(Type4 value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(Type4 value) => value.Value;

    public static explicit operator Type4(string value) => new(value);

    internal class Type4Serializer : JsonConverter<Type4>
    {
        public override Type4 Read(
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
            return new Type4(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            Type4 value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override Type4 ReadAsPropertyName(
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
            return new Type4(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            Type4 value,
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
        public const string AgentChatResponsePart = "agent_chat_response_part";
    }
}
