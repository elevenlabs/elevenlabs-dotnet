using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(CancelOrderParamsSmbToolType.CancelOrderParamsSmbToolTypeSerializer))]
[Serializable]
public readonly record struct CancelOrderParamsSmbToolType : IStringEnum
{
    public static readonly CancelOrderParamsSmbToolType CancelOrder = new(Values.CancelOrder);

    public CancelOrderParamsSmbToolType(string value)
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
    public static CancelOrderParamsSmbToolType FromCustom(string value)
    {
        return new CancelOrderParamsSmbToolType(value);
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

    public static bool operator ==(CancelOrderParamsSmbToolType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CancelOrderParamsSmbToolType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CancelOrderParamsSmbToolType value) => value.Value;

    public static explicit operator CancelOrderParamsSmbToolType(string value) => new(value);

    internal class CancelOrderParamsSmbToolTypeSerializer
        : JsonConverter<CancelOrderParamsSmbToolType>
    {
        public override CancelOrderParamsSmbToolType Read(
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
            return new CancelOrderParamsSmbToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CancelOrderParamsSmbToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CancelOrderParamsSmbToolType ReadAsPropertyName(
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
            return new CancelOrderParamsSmbToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CancelOrderParamsSmbToolType value,
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
        public const string CancelOrder = "cancel_order";
    }
}
