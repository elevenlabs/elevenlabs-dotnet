using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The type of resource.</summary>
[JsonConverter(
    typeof(ReaderResourceResponseModelResourceType.ReaderResourceResponseModelResourceTypeSerializer)
)]
[Serializable]
public readonly record struct ReaderResourceResponseModelResourceType : IStringEnum
{
    public static readonly ReaderResourceResponseModelResourceType Read = new(Values.Read);

    public static readonly ReaderResourceResponseModelResourceType Collection = new(
        Values.Collection
    );

    public ReaderResourceResponseModelResourceType(string value)
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
    public static ReaderResourceResponseModelResourceType FromCustom(string value)
    {
        return new ReaderResourceResponseModelResourceType(value);
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

    public static bool operator ==(ReaderResourceResponseModelResourceType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ReaderResourceResponseModelResourceType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ReaderResourceResponseModelResourceType value) =>
        value.Value;

    public static explicit operator ReaderResourceResponseModelResourceType(string value) =>
        new(value);

    internal class ReaderResourceResponseModelResourceTypeSerializer
        : JsonConverter<ReaderResourceResponseModelResourceType>
    {
        public override ReaderResourceResponseModelResourceType Read(
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
            return new ReaderResourceResponseModelResourceType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReaderResourceResponseModelResourceType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ReaderResourceResponseModelResourceType ReadAsPropertyName(
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
            return new ReaderResourceResponseModelResourceType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReaderResourceResponseModelResourceType value,
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
        public const string Read = "read";

        public const string Collection = "collection";
    }
}
