using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(TranslateStatusMessageType.TranslateStatusMessageTypeSerializer))]
[Serializable]
public readonly record struct TranslateStatusMessageType : IStringEnum
{
    public static readonly TranslateStatusMessageType Status = new(Values.Status);

    public TranslateStatusMessageType(string value)
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
    public static TranslateStatusMessageType FromCustom(string value)
    {
        return new TranslateStatusMessageType(value);
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

    public static bool operator ==(TranslateStatusMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TranslateStatusMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TranslateStatusMessageType value) => value.Value;

    public static explicit operator TranslateStatusMessageType(string value) => new(value);

    internal class TranslateStatusMessageTypeSerializer : JsonConverter<TranslateStatusMessageType>
    {
        public override TranslateStatusMessageType Read(
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
            return new TranslateStatusMessageType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TranslateStatusMessageType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TranslateStatusMessageType ReadAsPropertyName(
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
            return new TranslateStatusMessageType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TranslateStatusMessageType value,
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
        public const string Status = "status";
    }
}
