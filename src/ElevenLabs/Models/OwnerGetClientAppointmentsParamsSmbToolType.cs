using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(OwnerGetClientAppointmentsParamsSmbToolType.OwnerGetClientAppointmentsParamsSmbToolTypeSerializer)
)]
[Serializable]
public readonly record struct OwnerGetClientAppointmentsParamsSmbToolType : IStringEnum
{
    public static readonly OwnerGetClientAppointmentsParamsSmbToolType OwnerGetClientAppointments =
        new(Values.OwnerGetClientAppointments);

    public OwnerGetClientAppointmentsParamsSmbToolType(string value)
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
    public static OwnerGetClientAppointmentsParamsSmbToolType FromCustom(string value)
    {
        return new OwnerGetClientAppointmentsParamsSmbToolType(value);
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
        OwnerGetClientAppointmentsParamsSmbToolType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        OwnerGetClientAppointmentsParamsSmbToolType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(OwnerGetClientAppointmentsParamsSmbToolType value) =>
        value.Value;

    public static explicit operator OwnerGetClientAppointmentsParamsSmbToolType(string value) =>
        new(value);

    internal class OwnerGetClientAppointmentsParamsSmbToolTypeSerializer
        : JsonConverter<OwnerGetClientAppointmentsParamsSmbToolType>
    {
        public override OwnerGetClientAppointmentsParamsSmbToolType Read(
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
            return new OwnerGetClientAppointmentsParamsSmbToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            OwnerGetClientAppointmentsParamsSmbToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override OwnerGetClientAppointmentsParamsSmbToolType ReadAsPropertyName(
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
            return new OwnerGetClientAppointmentsParamsSmbToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            OwnerGetClientAppointmentsParamsSmbToolType value,
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
        public const string OwnerGetClientAppointments = "owner_get_client_appointments";
    }
}
