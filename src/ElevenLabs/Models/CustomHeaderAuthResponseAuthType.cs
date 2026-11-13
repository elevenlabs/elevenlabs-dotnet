using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(CustomHeaderAuthResponseAuthType.CustomHeaderAuthResponseAuthTypeSerializer))]
[Serializable]
public readonly record struct CustomHeaderAuthResponseAuthType : IStringEnum
{
    public static readonly CustomHeaderAuthResponseAuthType CustomHeaderAuth = new(
        Values.CustomHeaderAuth
    );

    public CustomHeaderAuthResponseAuthType(string value)
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
    public static CustomHeaderAuthResponseAuthType FromCustom(string value)
    {
        return new CustomHeaderAuthResponseAuthType(value);
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

    public static bool operator ==(CustomHeaderAuthResponseAuthType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CustomHeaderAuthResponseAuthType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CustomHeaderAuthResponseAuthType value) => value.Value;

    public static explicit operator CustomHeaderAuthResponseAuthType(string value) => new(value);

    internal class CustomHeaderAuthResponseAuthTypeSerializer
        : JsonConverter<CustomHeaderAuthResponseAuthType>
    {
        public override CustomHeaderAuthResponseAuthType Read(
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
            return new CustomHeaderAuthResponseAuthType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CustomHeaderAuthResponseAuthType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CustomHeaderAuthResponseAuthType ReadAsPropertyName(
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
            return new CustomHeaderAuthResponseAuthType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CustomHeaderAuthResponseAuthType value,
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
        public const string CustomHeaderAuth = "custom_header_auth";
    }
}
