using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>End the stream with an empty string.</summary>
[JsonConverter(typeof(CloseConnectionText.CloseConnectionTextSerializer))]
[Serializable]
public readonly record struct CloseConnectionText : IStringEnum
{
    public static readonly CloseConnectionText Empty = new(Values.Empty);

    public CloseConnectionText(string value)
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
    public static CloseConnectionText FromCustom(string value)
    {
        return new CloseConnectionText(value);
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

    public static bool operator ==(CloseConnectionText value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CloseConnectionText value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CloseConnectionText value) => value.Value;

    public static explicit operator CloseConnectionText(string value) => new(value);

    internal class CloseConnectionTextSerializer : JsonConverter<CloseConnectionText>
    {
        public override CloseConnectionText Read(
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
            return new CloseConnectionText(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CloseConnectionText value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CloseConnectionText ReadAsPropertyName(
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
            return new CloseConnectionText(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CloseConnectionText value,
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
        public const string Empty = "";
    }
}
