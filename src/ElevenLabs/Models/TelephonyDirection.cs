using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(TelephonyDirection.TelephonyDirectionSerializer))]
[Serializable]
public readonly record struct TelephonyDirection : IStringEnum
{
    public static readonly TelephonyDirection Inbound = new(Values.Inbound);

    public static readonly TelephonyDirection Outbound = new(Values.Outbound);

    public TelephonyDirection(string value)
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
    public static TelephonyDirection FromCustom(string value)
    {
        return new TelephonyDirection(value);
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

    public static bool operator ==(TelephonyDirection value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TelephonyDirection value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TelephonyDirection value) => value.Value;

    public static explicit operator TelephonyDirection(string value) => new(value);

    internal class TelephonyDirectionSerializer : JsonConverter<TelephonyDirection>
    {
        public override TelephonyDirection Read(
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
            return new TelephonyDirection(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TelephonyDirection value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TelephonyDirection ReadAsPropertyName(
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
            return new TelephonyDirection(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TelephonyDirection value,
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
        public const string Inbound = "inbound";

        public const string Outbound = "outbound";
    }
}
