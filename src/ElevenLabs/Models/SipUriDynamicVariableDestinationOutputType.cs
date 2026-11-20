using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(SipUriDynamicVariableDestinationOutputType.SipUriDynamicVariableDestinationOutputTypeSerializer)
)]
[Serializable]
public readonly record struct SipUriDynamicVariableDestinationOutputType : IStringEnum
{
    public static readonly SipUriDynamicVariableDestinationOutputType SipUriDynamicVariable = new(
        Values.SipUriDynamicVariable
    );

    public SipUriDynamicVariableDestinationOutputType(string value)
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
    public static SipUriDynamicVariableDestinationOutputType FromCustom(string value)
    {
        return new SipUriDynamicVariableDestinationOutputType(value);
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
        SipUriDynamicVariableDestinationOutputType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        SipUriDynamicVariableDestinationOutputType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(SipUriDynamicVariableDestinationOutputType value) =>
        value.Value;

    public static explicit operator SipUriDynamicVariableDestinationOutputType(string value) =>
        new(value);

    internal class SipUriDynamicVariableDestinationOutputTypeSerializer
        : JsonConverter<SipUriDynamicVariableDestinationOutputType>
    {
        public override SipUriDynamicVariableDestinationOutputType Read(
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
            return new SipUriDynamicVariableDestinationOutputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SipUriDynamicVariableDestinationOutputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SipUriDynamicVariableDestinationOutputType ReadAsPropertyName(
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
            return new SipUriDynamicVariableDestinationOutputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SipUriDynamicVariableDestinationOutputType value,
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
        public const string SipUriDynamicVariable = "sip_uri_dynamic_variable";
    }
}
