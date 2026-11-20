using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(Type3.Type3Serializer))]
[Serializable]
public readonly record struct Type3 : IStringEnum
{
    public static readonly Type3 AgentResponse = new(Values.AgentResponse);

    public Type3(string value)
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
    public static Type3 FromCustom(string value)
    {
        return new Type3(value);
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

    public static bool operator ==(Type3 value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(Type3 value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(Type3 value) => value.Value;

    public static explicit operator Type3(string value) => new(value);

    internal class Type3Serializer : JsonConverter<Type3>
    {
        public override Type3 Read(
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
            return new Type3(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            Type3 value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override Type3 ReadAsPropertyName(
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
            return new Type3(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            Type3 value,
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
        public const string AgentResponse = "agent_response";
    }
}
