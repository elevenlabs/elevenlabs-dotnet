using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(StaticAssetReferenceType.StaticAssetReferenceTypeSerializer))]
[Serializable]
public readonly record struct StaticAssetReferenceType : IStringEnum
{
    public static readonly StaticAssetReferenceType Asset = new(Values.Asset);

    public StaticAssetReferenceType(string value)
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
    public static StaticAssetReferenceType FromCustom(string value)
    {
        return new StaticAssetReferenceType(value);
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

    public static bool operator ==(StaticAssetReferenceType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(StaticAssetReferenceType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(StaticAssetReferenceType value) => value.Value;

    public static explicit operator StaticAssetReferenceType(string value) => new(value);

    internal class StaticAssetReferenceTypeSerializer : JsonConverter<StaticAssetReferenceType>
    {
        public override StaticAssetReferenceType Read(
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
            return new StaticAssetReferenceType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            StaticAssetReferenceType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override StaticAssetReferenceType ReadAsPropertyName(
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
            return new StaticAssetReferenceType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            StaticAssetReferenceType value,
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
        public const string Asset = "asset";
    }
}
