using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>An empty string. Ignored by the server but resets the inactivity timeout for the context.</summary>
[JsonConverter(typeof(KeepContextAliveText.KeepContextAliveTextSerializer))]
[Serializable]
public readonly record struct KeepContextAliveText : IStringEnum
{
    public static readonly KeepContextAliveText Empty = new(Values.Empty);

    public KeepContextAliveText(string value)
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
    public static KeepContextAliveText FromCustom(string value)
    {
        return new KeepContextAliveText(value);
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

    public static bool operator ==(KeepContextAliveText value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(KeepContextAliveText value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(KeepContextAliveText value) => value.Value;

    public static explicit operator KeepContextAliveText(string value) => new(value);

    internal class KeepContextAliveTextSerializer : JsonConverter<KeepContextAliveText>
    {
        public override KeepContextAliveText Read(
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
            return new KeepContextAliveText(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            KeepContextAliveText value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override KeepContextAliveText ReadAsPropertyName(
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
            return new KeepContextAliveText(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            KeepContextAliveText value,
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
