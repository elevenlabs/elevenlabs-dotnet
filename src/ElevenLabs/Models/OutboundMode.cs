using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(OutboundMode.OutboundModeSerializer))]
[Serializable]
public readonly record struct OutboundMode : IStringEnum
{
    public static readonly OutboundMode Voice = new(Values.Voice);

    public static readonly OutboundMode Message = new(Values.Message);

    public OutboundMode(string value)
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
    public static OutboundMode FromCustom(string value)
    {
        return new OutboundMode(value);
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

    public static bool operator ==(OutboundMode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OutboundMode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OutboundMode value) => value.Value;

    public static explicit operator OutboundMode(string value) => new(value);

    internal class OutboundModeSerializer : JsonConverter<OutboundMode>
    {
        public override OutboundMode Read(
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
            return new OutboundMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            OutboundMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override OutboundMode ReadAsPropertyName(
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
            return new OutboundMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            OutboundMode value,
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
        public const string Voice = "voice";

        public const string Message = "message";
    }
}
