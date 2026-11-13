using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(SayNodePromptMessageInputType.SayNodePromptMessageInputTypeSerializer))]
[Serializable]
public readonly record struct SayNodePromptMessageInputType : IStringEnum
{
    public static readonly SayNodePromptMessageInputType Prompt = new(Values.Prompt);

    public SayNodePromptMessageInputType(string value)
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
    public static SayNodePromptMessageInputType FromCustom(string value)
    {
        return new SayNodePromptMessageInputType(value);
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

    public static bool operator ==(SayNodePromptMessageInputType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SayNodePromptMessageInputType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SayNodePromptMessageInputType value) => value.Value;

    public static explicit operator SayNodePromptMessageInputType(string value) => new(value);

    internal class SayNodePromptMessageInputTypeSerializer
        : JsonConverter<SayNodePromptMessageInputType>
    {
        public override SayNodePromptMessageInputType Read(
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
            return new SayNodePromptMessageInputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SayNodePromptMessageInputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SayNodePromptMessageInputType ReadAsPropertyName(
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
            return new SayNodePromptMessageInputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SayNodePromptMessageInputType value,
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
        public const string Prompt = "prompt";
    }
}
