using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(GetOrderByConfirmationNumberParamsSmbToolType.GetOrderByConfirmationNumberParamsSmbToolTypeSerializer)
)]
[Serializable]
public readonly record struct GetOrderByConfirmationNumberParamsSmbToolType : IStringEnum
{
    public static readonly GetOrderByConfirmationNumberParamsSmbToolType GetOrderByConfirmationNumber =
        new(Values.GetOrderByConfirmationNumber);

    public GetOrderByConfirmationNumberParamsSmbToolType(string value)
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
    public static GetOrderByConfirmationNumberParamsSmbToolType FromCustom(string value)
    {
        return new GetOrderByConfirmationNumberParamsSmbToolType(value);
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
        GetOrderByConfirmationNumberParamsSmbToolType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        GetOrderByConfirmationNumberParamsSmbToolType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(GetOrderByConfirmationNumberParamsSmbToolType value) =>
        value.Value;

    public static explicit operator GetOrderByConfirmationNumberParamsSmbToolType(string value) =>
        new(value);

    internal class GetOrderByConfirmationNumberParamsSmbToolTypeSerializer
        : JsonConverter<GetOrderByConfirmationNumberParamsSmbToolType>
    {
        public override GetOrderByConfirmationNumberParamsSmbToolType Read(
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
            return new GetOrderByConfirmationNumberParamsSmbToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetOrderByConfirmationNumberParamsSmbToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetOrderByConfirmationNumberParamsSmbToolType ReadAsPropertyName(
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
            return new GetOrderByConfirmationNumberParamsSmbToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetOrderByConfirmationNumberParamsSmbToolType value,
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
        public const string GetOrderByConfirmationNumber = "get_order_by_confirmation_number";
    }
}
