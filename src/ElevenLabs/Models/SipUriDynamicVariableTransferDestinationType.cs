using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(SipUriDynamicVariableTransferDestinationType.SipUriDynamicVariableTransferDestinationTypeSerializer)
)]
[Serializable]
public readonly record struct SipUriDynamicVariableTransferDestinationType : IStringEnum
{
    public static readonly SipUriDynamicVariableTransferDestinationType SipUriDynamicVariable = new(
        Values.SipUriDynamicVariable
    );

    public SipUriDynamicVariableTransferDestinationType(string value)
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
    public static SipUriDynamicVariableTransferDestinationType FromCustom(string value)
    {
        return new SipUriDynamicVariableTransferDestinationType(value);
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
        SipUriDynamicVariableTransferDestinationType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        SipUriDynamicVariableTransferDestinationType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(SipUriDynamicVariableTransferDestinationType value) =>
        value.Value;

    public static explicit operator SipUriDynamicVariableTransferDestinationType(string value) =>
        new(value);

    internal class SipUriDynamicVariableTransferDestinationTypeSerializer
        : JsonConverter<SipUriDynamicVariableTransferDestinationType>
    {
        public override SipUriDynamicVariableTransferDestinationType Read(
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
            return new SipUriDynamicVariableTransferDestinationType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SipUriDynamicVariableTransferDestinationType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SipUriDynamicVariableTransferDestinationType ReadAsPropertyName(
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
            return new SipUriDynamicVariableTransferDestinationType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SipUriDynamicVariableTransferDestinationType value,
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
