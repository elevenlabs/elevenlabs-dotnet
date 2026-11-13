using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(PhoneNumberDynamicVariableTransferDestinationType.PhoneNumberDynamicVariableTransferDestinationTypeSerializer)
)]
[Serializable]
public readonly record struct PhoneNumberDynamicVariableTransferDestinationType : IStringEnum
{
    public static readonly PhoneNumberDynamicVariableTransferDestinationType PhoneDynamicVariable =
        new(Values.PhoneDynamicVariable);

    public PhoneNumberDynamicVariableTransferDestinationType(string value)
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
    public static PhoneNumberDynamicVariableTransferDestinationType FromCustom(string value)
    {
        return new PhoneNumberDynamicVariableTransferDestinationType(value);
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
        PhoneNumberDynamicVariableTransferDestinationType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        PhoneNumberDynamicVariableTransferDestinationType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        PhoneNumberDynamicVariableTransferDestinationType value
    ) => value.Value;

    public static explicit operator PhoneNumberDynamicVariableTransferDestinationType(
        string value
    ) => new(value);

    internal class PhoneNumberDynamicVariableTransferDestinationTypeSerializer
        : JsonConverter<PhoneNumberDynamicVariableTransferDestinationType>
    {
        public override PhoneNumberDynamicVariableTransferDestinationType Read(
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
            return new PhoneNumberDynamicVariableTransferDestinationType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PhoneNumberDynamicVariableTransferDestinationType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PhoneNumberDynamicVariableTransferDestinationType ReadAsPropertyName(
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
            return new PhoneNumberDynamicVariableTransferDestinationType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PhoneNumberDynamicVariableTransferDestinationType value,
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
        public const string PhoneDynamicVariable = "phone_dynamic_variable";
    }
}
