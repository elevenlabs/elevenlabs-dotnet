using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Reception;

/// <summary>What a time-off entry blocks: a staff member, an asset, or a location.</summary>
[JsonConverter(typeof(TimeOffType1.TimeOffType1Serializer))]
[Serializable]
public readonly record struct TimeOffType1 : IStringEnum
{
    public static readonly TimeOffType1 Staff = new(Values.Staff);

    public static readonly TimeOffType1 Asset = new(Values.Asset);

    public static readonly TimeOffType1 Location = new(Values.Location);

    public TimeOffType1(string value)
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
    public static TimeOffType1 FromCustom(string value)
    {
        return new TimeOffType1(value);
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

    public static bool operator ==(TimeOffType1 value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TimeOffType1 value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TimeOffType1 value) => value.Value;

    public static explicit operator TimeOffType1(string value) => new(value);

    internal class TimeOffType1Serializer : JsonConverter<TimeOffType1>
    {
        public override TimeOffType1 Read(
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
            return new TimeOffType1(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TimeOffType1 value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TimeOffType1 ReadAsPropertyName(
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
            return new TimeOffType1(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TimeOffType1 value,
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
        public const string Staff = "staff";

        public const string Asset = "asset";

        public const string Location = "location";
    }
}
