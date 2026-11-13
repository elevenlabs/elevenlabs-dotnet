using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ExotelApiSubdomain.ExotelApiSubdomainSerializer))]
[Serializable]
public readonly record struct ExotelApiSubdomain : IStringEnum
{
    public static readonly ExotelApiSubdomain ApiInExotelCom = new(Values.ApiInExotelCom);

    public static readonly ExotelApiSubdomain ApiExotelCom = new(Values.ApiExotelCom);

    public ExotelApiSubdomain(string value)
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
    public static ExotelApiSubdomain FromCustom(string value)
    {
        return new ExotelApiSubdomain(value);
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

    public static bool operator ==(ExotelApiSubdomain value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ExotelApiSubdomain value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ExotelApiSubdomain value) => value.Value;

    public static explicit operator ExotelApiSubdomain(string value) => new(value);

    internal class ExotelApiSubdomainSerializer : JsonConverter<ExotelApiSubdomain>
    {
        public override ExotelApiSubdomain Read(
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
            return new ExotelApiSubdomain(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ExotelApiSubdomain value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ExotelApiSubdomain ReadAsPropertyName(
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
            return new ExotelApiSubdomain(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ExotelApiSubdomain value,
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
        public const string ApiInExotelCom = "api.in.exotel.com";

        public const string ApiExotelCom = "api.exotel.com";
    }
}
