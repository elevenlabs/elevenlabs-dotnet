using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(EmbedVariant.EmbedVariantSerializer))]
[Serializable]
public readonly record struct EmbedVariant : IStringEnum
{
    public static readonly EmbedVariant Tiny = new(Values.Tiny);

    public static readonly EmbedVariant Compact = new(Values.Compact);

    public static readonly EmbedVariant Full = new(Values.Full);

    public static readonly EmbedVariant Expandable = new(Values.Expandable);

    public EmbedVariant(string value)
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
    public static EmbedVariant FromCustom(string value)
    {
        return new EmbedVariant(value);
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

    public static bool operator ==(EmbedVariant value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(EmbedVariant value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(EmbedVariant value) => value.Value;

    public static explicit operator EmbedVariant(string value) => new(value);

    internal class EmbedVariantSerializer : JsonConverter<EmbedVariant>
    {
        public override EmbedVariant Read(
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
            return new EmbedVariant(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EmbedVariant value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EmbedVariant ReadAsPropertyName(
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
            return new EmbedVariant(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EmbedVariant value,
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
        public const string Tiny = "tiny";

        public const string Compact = "compact";

        public const string Full = "full";

        public const string Expandable = "expandable";
    }
}
