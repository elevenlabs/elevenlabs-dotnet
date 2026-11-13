using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(CreateClientParamsSmbToolType.CreateClientParamsSmbToolTypeSerializer))]
[Serializable]
public readonly record struct CreateClientParamsSmbToolType : IStringEnum
{
    public static readonly CreateClientParamsSmbToolType CreateClient = new(Values.CreateClient);

    public CreateClientParamsSmbToolType(string value)
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
    public static CreateClientParamsSmbToolType FromCustom(string value)
    {
        return new CreateClientParamsSmbToolType(value);
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

    public static bool operator ==(CreateClientParamsSmbToolType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateClientParamsSmbToolType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateClientParamsSmbToolType value) => value.Value;

    public static explicit operator CreateClientParamsSmbToolType(string value) => new(value);

    internal class CreateClientParamsSmbToolTypeSerializer
        : JsonConverter<CreateClientParamsSmbToolType>
    {
        public override CreateClientParamsSmbToolType Read(
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
            return new CreateClientParamsSmbToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateClientParamsSmbToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateClientParamsSmbToolType ReadAsPropertyName(
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
            return new CreateClientParamsSmbToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateClientParamsSmbToolType value,
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
        public const string CreateClient = "create_client";
    }
}
