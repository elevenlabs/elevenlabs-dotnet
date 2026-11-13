using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(GetAppointmentByConfirmationNumberParamsSmbToolType.GetAppointmentByConfirmationNumberParamsSmbToolTypeSerializer)
)]
[Serializable]
public readonly record struct GetAppointmentByConfirmationNumberParamsSmbToolType : IStringEnum
{
    public static readonly GetAppointmentByConfirmationNumberParamsSmbToolType GetAppointmentByConfirmationNumber =
        new(Values.GetAppointmentByConfirmationNumber);

    public GetAppointmentByConfirmationNumberParamsSmbToolType(string value)
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
    public static GetAppointmentByConfirmationNumberParamsSmbToolType FromCustom(string value)
    {
        return new GetAppointmentByConfirmationNumberParamsSmbToolType(value);
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
        GetAppointmentByConfirmationNumberParamsSmbToolType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        GetAppointmentByConfirmationNumberParamsSmbToolType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        GetAppointmentByConfirmationNumberParamsSmbToolType value
    ) => value.Value;

    public static explicit operator GetAppointmentByConfirmationNumberParamsSmbToolType(
        string value
    ) => new(value);

    internal class GetAppointmentByConfirmationNumberParamsSmbToolTypeSerializer
        : JsonConverter<GetAppointmentByConfirmationNumberParamsSmbToolType>
    {
        public override GetAppointmentByConfirmationNumberParamsSmbToolType Read(
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
            return new GetAppointmentByConfirmationNumberParamsSmbToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetAppointmentByConfirmationNumberParamsSmbToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetAppointmentByConfirmationNumberParamsSmbToolType ReadAsPropertyName(
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
            return new GetAppointmentByConfirmationNumberParamsSmbToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetAppointmentByConfirmationNumberParamsSmbToolType value,
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
        public const string GetAppointmentByConfirmationNumber =
            "get_appointment_by_confirmation_number";
    }
}
