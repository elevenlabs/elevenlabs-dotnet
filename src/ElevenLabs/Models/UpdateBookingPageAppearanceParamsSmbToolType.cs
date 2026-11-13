using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(UpdateBookingPageAppearanceParamsSmbToolType.UpdateBookingPageAppearanceParamsSmbToolTypeSerializer)
)]
[Serializable]
public readonly record struct UpdateBookingPageAppearanceParamsSmbToolType : IStringEnum
{
    public static readonly UpdateBookingPageAppearanceParamsSmbToolType UpdateBookingPageAppearance =
        new(Values.UpdateBookingPageAppearance);

    public UpdateBookingPageAppearanceParamsSmbToolType(string value)
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
    public static UpdateBookingPageAppearanceParamsSmbToolType FromCustom(string value)
    {
        return new UpdateBookingPageAppearanceParamsSmbToolType(value);
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
        UpdateBookingPageAppearanceParamsSmbToolType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        UpdateBookingPageAppearanceParamsSmbToolType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(UpdateBookingPageAppearanceParamsSmbToolType value) =>
        value.Value;

    public static explicit operator UpdateBookingPageAppearanceParamsSmbToolType(string value) =>
        new(value);

    internal class UpdateBookingPageAppearanceParamsSmbToolTypeSerializer
        : JsonConverter<UpdateBookingPageAppearanceParamsSmbToolType>
    {
        public override UpdateBookingPageAppearanceParamsSmbToolType Read(
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
            return new UpdateBookingPageAppearanceParamsSmbToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateBookingPageAppearanceParamsSmbToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdateBookingPageAppearanceParamsSmbToolType ReadAsPropertyName(
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
            return new UpdateBookingPageAppearanceParamsSmbToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateBookingPageAppearanceParamsSmbToolType value,
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
        public const string UpdateBookingPageAppearance = "update_booking_page_appearance";
    }
}
