using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(CreateProductQuoteRequestParamsSmbToolType.CreateProductQuoteRequestParamsSmbToolTypeSerializer)
)]
[Serializable]
public readonly record struct CreateProductQuoteRequestParamsSmbToolType : IStringEnum
{
    public static readonly CreateProductQuoteRequestParamsSmbToolType CreateProductQuoteRequest =
        new(Values.CreateProductQuoteRequest);

    public CreateProductQuoteRequestParamsSmbToolType(string value)
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
    public static CreateProductQuoteRequestParamsSmbToolType FromCustom(string value)
    {
        return new CreateProductQuoteRequestParamsSmbToolType(value);
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

    public static bool operator ==(
        CreateProductQuoteRequestParamsSmbToolType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateProductQuoteRequestParamsSmbToolType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CreateProductQuoteRequestParamsSmbToolType value) =>
        value.Value;

    public static explicit operator CreateProductQuoteRequestParamsSmbToolType(string value) =>
        new(value);

    internal class CreateProductQuoteRequestParamsSmbToolTypeSerializer
        : JsonConverter<CreateProductQuoteRequestParamsSmbToolType>
    {
        public override CreateProductQuoteRequestParamsSmbToolType Read(
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
            return new CreateProductQuoteRequestParamsSmbToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateProductQuoteRequestParamsSmbToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateProductQuoteRequestParamsSmbToolType ReadAsPropertyName(
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
            return new CreateProductQuoteRequestParamsSmbToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateProductQuoteRequestParamsSmbToolType value,
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
        public const string CreateProductQuoteRequest = "create_product_quote_request";
    }
}
