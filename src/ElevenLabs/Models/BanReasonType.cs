using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(BanReasonType.BanReasonTypeSerializer))]
[Serializable]
public readonly record struct BanReasonType : IStringEnum
{
    public static readonly BanReasonType Safety = new(Values.Safety);

    public static readonly BanReasonType Manual = new(Values.Manual);

    public BanReasonType(string value)
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
    public static BanReasonType FromCustom(string value)
    {
        return new BanReasonType(value);
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

    public static bool operator ==(BanReasonType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BanReasonType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BanReasonType value) => value.Value;

    public static explicit operator BanReasonType(string value) => new(value);

    internal class BanReasonTypeSerializer : JsonConverter<BanReasonType>
    {
        public override BanReasonType Read(
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
            return new BanReasonType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BanReasonType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BanReasonType ReadAsPropertyName(
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
            return new BanReasonType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BanReasonType value,
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
        public const string Safety = "safety";

        public const string Manual = "manual";
    }
}
