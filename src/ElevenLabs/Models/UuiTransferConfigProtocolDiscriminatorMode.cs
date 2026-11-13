using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>How to attach protocol_discriminator. 'prefix' prepends the octet to the hex payload (User-to-User=XX&lt;hex&gt;;encoding=hex). 'pd_parameter' sends it as a separate parameter (User-to-User=&lt;hex&gt;;pd=XX;encoding=hex). Ignored when protocol_discriminator is unset.</summary>
[JsonConverter(
    typeof(UuiTransferConfigProtocolDiscriminatorMode.UuiTransferConfigProtocolDiscriminatorModeSerializer)
)]
[Serializable]
public readonly record struct UuiTransferConfigProtocolDiscriminatorMode : IStringEnum
{
    public static readonly UuiTransferConfigProtocolDiscriminatorMode Prefix = new(Values.Prefix);

    public static readonly UuiTransferConfigProtocolDiscriminatorMode PdParameter = new(
        Values.PdParameter
    );

    public UuiTransferConfigProtocolDiscriminatorMode(string value)
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
    public static UuiTransferConfigProtocolDiscriminatorMode FromCustom(string value)
    {
        return new UuiTransferConfigProtocolDiscriminatorMode(value);
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
        UuiTransferConfigProtocolDiscriminatorMode value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        UuiTransferConfigProtocolDiscriminatorMode value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(UuiTransferConfigProtocolDiscriminatorMode value) =>
        value.Value;

    public static explicit operator UuiTransferConfigProtocolDiscriminatorMode(string value) =>
        new(value);

    internal class UuiTransferConfigProtocolDiscriminatorModeSerializer
        : JsonConverter<UuiTransferConfigProtocolDiscriminatorMode>
    {
        public override UuiTransferConfigProtocolDiscriminatorMode Read(
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
            return new UuiTransferConfigProtocolDiscriminatorMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UuiTransferConfigProtocolDiscriminatorMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UuiTransferConfigProtocolDiscriminatorMode ReadAsPropertyName(
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
            return new UuiTransferConfigProtocolDiscriminatorMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UuiTransferConfigProtocolDiscriminatorMode value,
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
        public const string Prefix = "prefix";

        public const string PdParameter = "pd_parameter";
    }
}
