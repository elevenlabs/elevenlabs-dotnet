using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(GetBookingPageSettingsParamsSmbToolType.GetBookingPageSettingsParamsSmbToolTypeSerializer)
)]
[Serializable]
public readonly record struct GetBookingPageSettingsParamsSmbToolType : IStringEnum
{
    public static readonly GetBookingPageSettingsParamsSmbToolType GetBookingPageSettings = new(
        Values.GetBookingPageSettings
    );

    public GetBookingPageSettingsParamsSmbToolType(string value)
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
    public static GetBookingPageSettingsParamsSmbToolType FromCustom(string value)
    {
        return new GetBookingPageSettingsParamsSmbToolType(value);
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

    public static bool operator ==(GetBookingPageSettingsParamsSmbToolType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetBookingPageSettingsParamsSmbToolType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetBookingPageSettingsParamsSmbToolType value) =>
        value.Value;

    public static explicit operator GetBookingPageSettingsParamsSmbToolType(string value) =>
        new(value);

    internal class GetBookingPageSettingsParamsSmbToolTypeSerializer
        : JsonConverter<GetBookingPageSettingsParamsSmbToolType>
    {
        public override GetBookingPageSettingsParamsSmbToolType Read(
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
            return new GetBookingPageSettingsParamsSmbToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetBookingPageSettingsParamsSmbToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetBookingPageSettingsParamsSmbToolType ReadAsPropertyName(
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
            return new GetBookingPageSettingsParamsSmbToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetBookingPageSettingsParamsSmbToolType value,
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
        public const string GetBookingPageSettings = "get_booking_page_settings";
    }
}
