using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Whether the entry closes the target for the whole range or replaces its working hours.</summary>
[JsonConverter(typeof(HolidayType.HolidayTypeSerializer))]
[Serializable]
public readonly record struct HolidayType : IStringEnum
{
    public static readonly HolidayType Closed = new(Values.Closed);

    public static readonly HolidayType Override = new(Values.Override);

    public HolidayType(string value)
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
    public static HolidayType FromCustom(string value)
    {
        return new HolidayType(value);
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

    public static bool operator ==(HolidayType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(HolidayType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(HolidayType value) => value.Value;

    public static explicit operator HolidayType(string value) => new(value);

    internal class HolidayTypeSerializer : JsonConverter<HolidayType>
    {
        public override HolidayType Read(
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
            return new HolidayType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            HolidayType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override HolidayType ReadAsPropertyName(
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
            return new HolidayType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            HolidayType value,
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
        public const string Closed = "closed";

        public const string Override = "override";
    }
}
