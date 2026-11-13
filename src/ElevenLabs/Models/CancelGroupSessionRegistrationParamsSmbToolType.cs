using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(CancelGroupSessionRegistrationParamsSmbToolType.CancelGroupSessionRegistrationParamsSmbToolTypeSerializer)
)]
[Serializable]
public readonly record struct CancelGroupSessionRegistrationParamsSmbToolType : IStringEnum
{
    public static readonly CancelGroupSessionRegistrationParamsSmbToolType CancelGroupSessionRegistration =
        new(Values.CancelGroupSessionRegistration);

    public CancelGroupSessionRegistrationParamsSmbToolType(string value)
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
    public static CancelGroupSessionRegistrationParamsSmbToolType FromCustom(string value)
    {
        return new CancelGroupSessionRegistrationParamsSmbToolType(value);
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
        CancelGroupSessionRegistrationParamsSmbToolType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CancelGroupSessionRegistrationParamsSmbToolType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CancelGroupSessionRegistrationParamsSmbToolType value) =>
        value.Value;

    public static explicit operator CancelGroupSessionRegistrationParamsSmbToolType(string value) =>
        new(value);

    internal class CancelGroupSessionRegistrationParamsSmbToolTypeSerializer
        : JsonConverter<CancelGroupSessionRegistrationParamsSmbToolType>
    {
        public override CancelGroupSessionRegistrationParamsSmbToolType Read(
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
            return new CancelGroupSessionRegistrationParamsSmbToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CancelGroupSessionRegistrationParamsSmbToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CancelGroupSessionRegistrationParamsSmbToolType ReadAsPropertyName(
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
            return new CancelGroupSessionRegistrationParamsSmbToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CancelGroupSessionRegistrationParamsSmbToolType value,
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
        public const string CancelGroupSessionRegistration = "cancel_group_session_registration";
    }
}
