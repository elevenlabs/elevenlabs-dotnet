using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(SipUriDynamicVariableDestinationInputType.SipUriDynamicVariableDestinationInputTypeSerializer)
)]
[Serializable]
public readonly record struct SipUriDynamicVariableDestinationInputType : IStringEnum
{
    public static readonly SipUriDynamicVariableDestinationInputType SipUriDynamicVariable = new(
        Values.SipUriDynamicVariable
    );

    public SipUriDynamicVariableDestinationInputType(string value)
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
    public static SipUriDynamicVariableDestinationInputType FromCustom(string value)
    {
        return new SipUriDynamicVariableDestinationInputType(value);
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
        SipUriDynamicVariableDestinationInputType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        SipUriDynamicVariableDestinationInputType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(SipUriDynamicVariableDestinationInputType value) =>
        value.Value;

    public static explicit operator SipUriDynamicVariableDestinationInputType(string value) =>
        new(value);

    internal class SipUriDynamicVariableDestinationInputTypeSerializer
        : JsonConverter<SipUriDynamicVariableDestinationInputType>
    {
        public override SipUriDynamicVariableDestinationInputType Read(
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
            return new SipUriDynamicVariableDestinationInputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SipUriDynamicVariableDestinationInputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SipUriDynamicVariableDestinationInputType ReadAsPropertyName(
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
            return new SipUriDynamicVariableDestinationInputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SipUriDynamicVariableDestinationInputType value,
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
