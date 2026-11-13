using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Valid Twilio region IDs.</summary>
[JsonConverter(typeof(TwilioRegionId.TwilioRegionIdSerializer))]
[Serializable]
public readonly record struct TwilioRegionId : IStringEnum
{
    public static readonly TwilioRegionId Us1 = new(Values.Us1);

    public static readonly TwilioRegionId Ie1 = new(Values.Ie1);

    public static readonly TwilioRegionId Au1 = new(Values.Au1);

    public TwilioRegionId(string value)
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
    public static TwilioRegionId FromCustom(string value)
    {
        return new TwilioRegionId(value);
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

    public static bool operator ==(TwilioRegionId value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TwilioRegionId value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TwilioRegionId value) => value.Value;

    public static explicit operator TwilioRegionId(string value) => new(value);

    internal class TwilioRegionIdSerializer : JsonConverter<TwilioRegionId>
    {
        public override TwilioRegionId Read(
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
            return new TwilioRegionId(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TwilioRegionId value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TwilioRegionId ReadAsPropertyName(
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
            return new TwilioRegionId(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TwilioRegionId value,
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
        public const string Us1 = "us1";

        public const string Ie1 = "ie1";

        public const string Au1 = "au1";
    }
}
