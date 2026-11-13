using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The initial text that must be sent is a blank space.</summary>
[JsonConverter(typeof(InitializeConnectionMultiText.InitializeConnectionMultiTextSerializer))]
[Serializable]
public readonly record struct InitializeConnectionMultiText : IStringEnum
{
    public static readonly InitializeConnectionMultiText _ = new(Values._);

    public InitializeConnectionMultiText(string value)
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
    public static InitializeConnectionMultiText FromCustom(string value)
    {
        return new InitializeConnectionMultiText(value);
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

    public static bool operator ==(InitializeConnectionMultiText value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(InitializeConnectionMultiText value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(InitializeConnectionMultiText value) => value.Value;

    public static explicit operator InitializeConnectionMultiText(string value) => new(value);

    internal class InitializeConnectionMultiTextSerializer
        : JsonConverter<InitializeConnectionMultiText>
    {
        public override InitializeConnectionMultiText Read(
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
            return new InitializeConnectionMultiText(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            InitializeConnectionMultiText value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override InitializeConnectionMultiText ReadAsPropertyName(
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
            return new InitializeConnectionMultiText(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            InitializeConnectionMultiText value,
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
        public const string _ = " ";
    }
}
