using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(DocumentUsageModeEnum.DocumentUsageModeEnumSerializer))]
[Serializable]
public readonly record struct DocumentUsageModeEnum : IStringEnum
{
    public static readonly DocumentUsageModeEnum Prompt = new(Values.Prompt);

    public static readonly DocumentUsageModeEnum Auto = new(Values.Auto);

    public DocumentUsageModeEnum(string value)
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
    public static DocumentUsageModeEnum FromCustom(string value)
    {
        return new DocumentUsageModeEnum(value);
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

    public static bool operator ==(DocumentUsageModeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DocumentUsageModeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DocumentUsageModeEnum value) => value.Value;

    public static explicit operator DocumentUsageModeEnum(string value) => new(value);

    internal class DocumentUsageModeEnumSerializer : JsonConverter<DocumentUsageModeEnum>
    {
        public override DocumentUsageModeEnum Read(
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
            return new DocumentUsageModeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DocumentUsageModeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DocumentUsageModeEnum ReadAsPropertyName(
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
            return new DocumentUsageModeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DocumentUsageModeEnum value,
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
        public const string Prompt = "prompt";

        public const string Auto = "auto";
    }
}
