using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(SipLogMessageDirection.SipLogMessageDirectionSerializer))]
[Serializable]
public readonly record struct SipLogMessageDirection : IStringEnum
{
    public static readonly SipLogMessageDirection In = new(Values.In);

    public static readonly SipLogMessageDirection Out = new(Values.Out);

    public SipLogMessageDirection(string value)
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
    public static SipLogMessageDirection FromCustom(string value)
    {
        return new SipLogMessageDirection(value);
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

    public static bool operator ==(SipLogMessageDirection value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SipLogMessageDirection value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SipLogMessageDirection value) => value.Value;

    public static explicit operator SipLogMessageDirection(string value) => new(value);

    internal class SipLogMessageDirectionSerializer : JsonConverter<SipLogMessageDirection>
    {
        public override SipLogMessageDirection Read(
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
            return new SipLogMessageDirection(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SipLogMessageDirection value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SipLogMessageDirection ReadAsPropertyName(
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
            return new SipLogMessageDirection(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SipLogMessageDirection value,
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
        public const string In = "in";

        public const string Out = "out";
    }
}
