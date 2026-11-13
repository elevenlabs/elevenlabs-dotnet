using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(OwnerListProductsParamsSmbToolType.OwnerListProductsParamsSmbToolTypeSerializer)
)]
[Serializable]
public readonly record struct OwnerListProductsParamsSmbToolType : IStringEnum
{
    public static readonly OwnerListProductsParamsSmbToolType OwnerListProducts = new(
        Values.OwnerListProducts
    );

    public OwnerListProductsParamsSmbToolType(string value)
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
    public static OwnerListProductsParamsSmbToolType FromCustom(string value)
    {
        return new OwnerListProductsParamsSmbToolType(value);
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

    public static bool operator ==(OwnerListProductsParamsSmbToolType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OwnerListProductsParamsSmbToolType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OwnerListProductsParamsSmbToolType value) => value.Value;

    public static explicit operator OwnerListProductsParamsSmbToolType(string value) => new(value);

    internal class OwnerListProductsParamsSmbToolTypeSerializer
        : JsonConverter<OwnerListProductsParamsSmbToolType>
    {
        public override OwnerListProductsParamsSmbToolType Read(
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
            return new OwnerListProductsParamsSmbToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            OwnerListProductsParamsSmbToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override OwnerListProductsParamsSmbToolType ReadAsPropertyName(
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
            return new OwnerListProductsParamsSmbToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            OwnerListProductsParamsSmbToolType value,
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
        public const string OwnerListProducts = "owner_list_products";
    }
}
