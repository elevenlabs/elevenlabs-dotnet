using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(TransferTypeEnum.TransferTypeEnumSerializer))]
[Serializable]
public readonly record struct TransferTypeEnum : IStringEnum
{
    public static readonly TransferTypeEnum Blind = new(Values.Blind);

    public static readonly TransferTypeEnum Conference = new(Values.Conference);

    public static readonly TransferTypeEnum SipRefer = new(Values.SipRefer);

    public TransferTypeEnum(string value)
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
    public static TransferTypeEnum FromCustom(string value)
    {
        return new TransferTypeEnum(value);
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

    public static bool operator ==(TransferTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TransferTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TransferTypeEnum value) => value.Value;

    public static explicit operator TransferTypeEnum(string value) => new(value);

    internal class TransferTypeEnumSerializer : JsonConverter<TransferTypeEnum>
    {
        public override TransferTypeEnum Read(
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
            return new TransferTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TransferTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TransferTypeEnum ReadAsPropertyName(
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
            return new TransferTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TransferTypeEnum value,
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
        public const string Blind = "blind";

        public const string Conference = "conference";

        public const string SipRefer = "sip_refer";
    }
}
