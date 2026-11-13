using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Agents;

[JsonConverter(typeof(OutboundChannel.OutboundChannelSerializer))]
[Serializable]
public readonly record struct OutboundChannel : IStringEnum
{
    public static readonly OutboundChannel Phone = new(Values.Phone);

    public static readonly OutboundChannel Whatsapp = new(Values.Whatsapp);

    public OutboundChannel(string value)
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
    public static OutboundChannel FromCustom(string value)
    {
        return new OutboundChannel(value);
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

    public static bool operator ==(OutboundChannel value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OutboundChannel value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OutboundChannel value) => value.Value;

    public static explicit operator OutboundChannel(string value) => new(value);

    internal class OutboundChannelSerializer : JsonConverter<OutboundChannel>
    {
        public override OutboundChannel Read(
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
            return new OutboundChannel(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            OutboundChannel value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override OutboundChannel ReadAsPropertyName(
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
            return new OutboundChannel(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            OutboundChannel value,
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
        public const string Phone = "phone";

        public const string Whatsapp = "whatsapp";
    }
}
