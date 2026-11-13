using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(CreateProductParamsSmbToolType.CreateProductParamsSmbToolTypeSerializer))]
[Serializable]
public readonly record struct CreateProductParamsSmbToolType : IStringEnum
{
    public static readonly CreateProductParamsSmbToolType CreateProduct = new(Values.CreateProduct);

    public CreateProductParamsSmbToolType(string value)
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
    public static CreateProductParamsSmbToolType FromCustom(string value)
    {
        return new CreateProductParamsSmbToolType(value);
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

    public static bool operator ==(CreateProductParamsSmbToolType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateProductParamsSmbToolType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateProductParamsSmbToolType value) => value.Value;

    public static explicit operator CreateProductParamsSmbToolType(string value) => new(value);

    internal class CreateProductParamsSmbToolTypeSerializer
        : JsonConverter<CreateProductParamsSmbToolType>
    {
        public override CreateProductParamsSmbToolType Read(
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
            return new CreateProductParamsSmbToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateProductParamsSmbToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateProductParamsSmbToolType ReadAsPropertyName(
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
            return new CreateProductParamsSmbToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateProductParamsSmbToolType value,
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
        public const string CreateProduct = "create_product";
    }
}
