using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ConfirmChangeParamsSmbToolType.ConfirmChangeParamsSmbToolTypeSerializer))]
[Serializable]
public readonly record struct ConfirmChangeParamsSmbToolType : IStringEnum
{
    public static readonly ConfirmChangeParamsSmbToolType SmbConfirmChange = new(
        Values.SmbConfirmChange
    );

    public ConfirmChangeParamsSmbToolType(string value)
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
    public static ConfirmChangeParamsSmbToolType FromCustom(string value)
    {
        return new ConfirmChangeParamsSmbToolType(value);
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

    public static bool operator ==(ConfirmChangeParamsSmbToolType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConfirmChangeParamsSmbToolType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConfirmChangeParamsSmbToolType value) => value.Value;

    public static explicit operator ConfirmChangeParamsSmbToolType(string value) => new(value);

    internal class ConfirmChangeParamsSmbToolTypeSerializer
        : JsonConverter<ConfirmChangeParamsSmbToolType>
    {
        public override ConfirmChangeParamsSmbToolType Read(
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
            return new ConfirmChangeParamsSmbToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConfirmChangeParamsSmbToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConfirmChangeParamsSmbToolType ReadAsPropertyName(
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
            return new ConfirmChangeParamsSmbToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConfirmChangeParamsSmbToolType value,
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
        public const string SmbConfirmChange = "smb_confirm_change";
    }
}
