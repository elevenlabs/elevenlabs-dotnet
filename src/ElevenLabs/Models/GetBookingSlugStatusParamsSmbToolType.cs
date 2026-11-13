using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(GetBookingSlugStatusParamsSmbToolType.GetBookingSlugStatusParamsSmbToolTypeSerializer)
)]
[Serializable]
public readonly record struct GetBookingSlugStatusParamsSmbToolType : IStringEnum
{
    public static readonly GetBookingSlugStatusParamsSmbToolType GetBookingSlugStatus = new(
        Values.GetBookingSlugStatus
    );

    public GetBookingSlugStatusParamsSmbToolType(string value)
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
    public static GetBookingSlugStatusParamsSmbToolType FromCustom(string value)
    {
        return new GetBookingSlugStatusParamsSmbToolType(value);
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

    public static bool operator ==(GetBookingSlugStatusParamsSmbToolType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetBookingSlugStatusParamsSmbToolType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetBookingSlugStatusParamsSmbToolType value) =>
        value.Value;

    public static explicit operator GetBookingSlugStatusParamsSmbToolType(string value) =>
        new(value);

    internal class GetBookingSlugStatusParamsSmbToolTypeSerializer
        : JsonConverter<GetBookingSlugStatusParamsSmbToolType>
    {
        public override GetBookingSlugStatusParamsSmbToolType Read(
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
            return new GetBookingSlugStatusParamsSmbToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetBookingSlugStatusParamsSmbToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetBookingSlugStatusParamsSmbToolType ReadAsPropertyName(
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
            return new GetBookingSlugStatusParamsSmbToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetBookingSlugStatusParamsSmbToolType value,
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
        public const string GetBookingSlugStatus = "get_booking_slug_status";
    }
}
