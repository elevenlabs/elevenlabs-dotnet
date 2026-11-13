using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(CheckServiceAvailabilityParamsSmbToolType.CheckServiceAvailabilityParamsSmbToolTypeSerializer)
)]
[Serializable]
public readonly record struct CheckServiceAvailabilityParamsSmbToolType : IStringEnum
{
    public static readonly CheckServiceAvailabilityParamsSmbToolType CheckServiceAvailability = new(
        Values.CheckServiceAvailability
    );

    public CheckServiceAvailabilityParamsSmbToolType(string value)
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
    public static CheckServiceAvailabilityParamsSmbToolType FromCustom(string value)
    {
        return new CheckServiceAvailabilityParamsSmbToolType(value);
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

    public static bool operator ==(
        CheckServiceAvailabilityParamsSmbToolType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CheckServiceAvailabilityParamsSmbToolType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CheckServiceAvailabilityParamsSmbToolType value) =>
        value.Value;

    public static explicit operator CheckServiceAvailabilityParamsSmbToolType(string value) =>
        new(value);

    internal class CheckServiceAvailabilityParamsSmbToolTypeSerializer
        : JsonConverter<CheckServiceAvailabilityParamsSmbToolType>
    {
        public override CheckServiceAvailabilityParamsSmbToolType Read(
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
            return new CheckServiceAvailabilityParamsSmbToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CheckServiceAvailabilityParamsSmbToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CheckServiceAvailabilityParamsSmbToolType ReadAsPropertyName(
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
            return new CheckServiceAvailabilityParamsSmbToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CheckServiceAvailabilityParamsSmbToolType value,
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
        public const string CheckServiceAvailability = "check_service_availability";
    }
}
