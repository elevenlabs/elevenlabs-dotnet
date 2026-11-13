using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(MaxResponseOutputTokens21.MaxResponseOutputTokens21Serializer))]
[Serializable]
public readonly record struct MaxResponseOutputTokens21 : IStringEnum
{
    public static readonly MaxResponseOutputTokens21 Inf = new(Values.Inf);

    public MaxResponseOutputTokens21(string value)
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
    public static MaxResponseOutputTokens21 FromCustom(string value)
    {
        return new MaxResponseOutputTokens21(value);
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

    public static bool operator ==(MaxResponseOutputTokens21 value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(MaxResponseOutputTokens21 value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MaxResponseOutputTokens21 value) => value.Value;

    public static explicit operator MaxResponseOutputTokens21(string value) => new(value);

    internal class MaxResponseOutputTokens21Serializer : JsonConverter<MaxResponseOutputTokens21>
    {
        public override MaxResponseOutputTokens21 Read(
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
            return new MaxResponseOutputTokens21(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            MaxResponseOutputTokens21 value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override MaxResponseOutputTokens21 ReadAsPropertyName(
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
            return new MaxResponseOutputTokens21(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            MaxResponseOutputTokens21 value,
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
        public const string Inf = "inf";
    }
}
