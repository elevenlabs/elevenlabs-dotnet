using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(EmbeddingModelEnum.EmbeddingModelEnumSerializer))]
[Serializable]
public readonly record struct EmbeddingModelEnum : IStringEnum
{
    public static readonly EmbeddingModelEnum E5Mistral7BInstruct = new(Values.E5Mistral7BInstruct);

    public static readonly EmbeddingModelEnum MultilingualE5LargeInstruct = new(
        Values.MultilingualE5LargeInstruct
    );

    public EmbeddingModelEnum(string value)
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
    public static EmbeddingModelEnum FromCustom(string value)
    {
        return new EmbeddingModelEnum(value);
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

    public static bool operator ==(EmbeddingModelEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(EmbeddingModelEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(EmbeddingModelEnum value) => value.Value;

    public static explicit operator EmbeddingModelEnum(string value) => new(value);

    internal class EmbeddingModelEnumSerializer : JsonConverter<EmbeddingModelEnum>
    {
        public override EmbeddingModelEnum Read(
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
            return new EmbeddingModelEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EmbeddingModelEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EmbeddingModelEnum ReadAsPropertyName(
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
            return new EmbeddingModelEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EmbeddingModelEnum value,
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
        public const string E5Mistral7BInstruct = "e5_mistral_7b_instruct";

        public const string MultilingualE5LargeInstruct = "multilingual_e5_large_instruct";
    }
}
