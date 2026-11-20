using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(PhoneDestinationOutputType.PhoneDestinationOutputTypeSerializer))]
[Serializable]
public readonly record struct PhoneDestinationOutputType : IStringEnum
{
    public static readonly PhoneDestinationOutputType Phone = new(Values.Phone);

    public PhoneDestinationOutputType(string value)
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
    public static PhoneDestinationOutputType FromCustom(string value)
    {
        return new PhoneDestinationOutputType(value);
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

    public static bool operator ==(PhoneDestinationOutputType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PhoneDestinationOutputType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PhoneDestinationOutputType value) => value.Value;

    public static explicit operator PhoneDestinationOutputType(string value) => new(value);

    internal class PhoneDestinationOutputTypeSerializer : JsonConverter<PhoneDestinationOutputType>
    {
        public override PhoneDestinationOutputType Read(
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
            return new PhoneDestinationOutputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PhoneDestinationOutputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PhoneDestinationOutputType ReadAsPropertyName(
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
            return new PhoneDestinationOutputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PhoneDestinationOutputType value,
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
    }
}
