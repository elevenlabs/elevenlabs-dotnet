using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(CreateServiceQuoteRequestParamsSmbToolType.CreateServiceQuoteRequestParamsSmbToolTypeSerializer)
)]
[Serializable]
public readonly record struct CreateServiceQuoteRequestParamsSmbToolType : IStringEnum
{
    public static readonly CreateServiceQuoteRequestParamsSmbToolType CreateServiceQuoteRequest =
        new(Values.CreateServiceQuoteRequest);

    public CreateServiceQuoteRequestParamsSmbToolType(string value)
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
    public static CreateServiceQuoteRequestParamsSmbToolType FromCustom(string value)
    {
        return new CreateServiceQuoteRequestParamsSmbToolType(value);
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
        CreateServiceQuoteRequestParamsSmbToolType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateServiceQuoteRequestParamsSmbToolType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CreateServiceQuoteRequestParamsSmbToolType value) =>
        value.Value;

    public static explicit operator CreateServiceQuoteRequestParamsSmbToolType(string value) =>
        new(value);

    internal class CreateServiceQuoteRequestParamsSmbToolTypeSerializer
        : JsonConverter<CreateServiceQuoteRequestParamsSmbToolType>
    {
        public override CreateServiceQuoteRequestParamsSmbToolType Read(
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
            return new CreateServiceQuoteRequestParamsSmbToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateServiceQuoteRequestParamsSmbToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateServiceQuoteRequestParamsSmbToolType ReadAsPropertyName(
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
            return new CreateServiceQuoteRequestParamsSmbToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateServiceQuoteRequestParamsSmbToolType value,
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
        public const string CreateServiceQuoteRequest = "create_service_quote_request";
    }
}
