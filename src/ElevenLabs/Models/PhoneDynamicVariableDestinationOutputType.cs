using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(PhoneDynamicVariableDestinationOutputType.PhoneDynamicVariableDestinationOutputTypeSerializer)
)]
[Serializable]
public readonly record struct PhoneDynamicVariableDestinationOutputType : IStringEnum
{
    public static readonly PhoneDynamicVariableDestinationOutputType PhoneDynamicVariable = new(
        Values.PhoneDynamicVariable
    );

    public PhoneDynamicVariableDestinationOutputType(string value)
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
    public static PhoneDynamicVariableDestinationOutputType FromCustom(string value)
    {
        return new PhoneDynamicVariableDestinationOutputType(value);
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
        PhoneDynamicVariableDestinationOutputType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        PhoneDynamicVariableDestinationOutputType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(PhoneDynamicVariableDestinationOutputType value) =>
        value.Value;

    public static explicit operator PhoneDynamicVariableDestinationOutputType(string value) =>
        new(value);

    internal class PhoneDynamicVariableDestinationOutputTypeSerializer
        : JsonConverter<PhoneDynamicVariableDestinationOutputType>
    {
        public override PhoneDynamicVariableDestinationOutputType Read(
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
            return new PhoneDynamicVariableDestinationOutputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PhoneDynamicVariableDestinationOutputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PhoneDynamicVariableDestinationOutputType ReadAsPropertyName(
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
            return new PhoneDynamicVariableDestinationOutputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PhoneDynamicVariableDestinationOutputType value,
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
